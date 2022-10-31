using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API;
using Application.Contracts.Identity;
using Domain;
using Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using MySqlConnector;
using NUnit.Framework;
using Persistence;
using Respawn;

namespace IntegrationTests
{
    [SetUpFixture]
    public class Testing
    {
        private static IConfiguration _configuration;
        private static IServiceScopeFactory _scopeFactory;
        private static Checkpoint _checkpoint;
        private static int _currentUserId;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            var fullPath = Directory.GetCurrentDirectory();
            var binFoldIdx = fullPath.IndexOf("/bin");
            var path = binFoldIdx > 0 ? fullPath.Substring(0, binFoldIdx) : fullPath;

            var builder = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();

            var services = new ServiceCollection();
            var startup = new Startup(_configuration);

            // Mocking IWebHostEnvironment service
            services.AddSingleton(Mock.Of<IWebHostEnvironment>(w =>
                w.ApplicationName == "API" &&
                w.EnvironmentName == "Development"
            ));

            startup.ConfigureServices(services);

            // Replace service registration for IUserAccessor
            var userAccessorServiceDescriptor = services.FirstOrDefault(d =>
                d.ServiceType == typeof(IUserAccessor));

            services.Remove(userAccessorServiceDescriptor);

            services.AddScoped(provider => Mock.Of<IUserAccessor>(x =>
                x.GetUserId() == _currentUserId
            ));

            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();

            _checkpoint = new Checkpoint
            {
                DbAdapter = DbAdapter.MySql,
                SchemasToInclude = new[] { "juractest" }
            };

            EnsureDatabase();
        }

        private void EnsureDatabase()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.EnsureCreated();
            }
        }

        public static async Task ResetState()
        {
            using (var conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                await conn.OpenAsync();

                await _checkpoint.Reset(conn);
            }

            _currentUserId = 0;
        }

        public static async Task<List<TEntity>> GetAllAsync<TEntity>()
            where TEntity : class
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

                return await context.Set<TEntity>().ToListAsync();
            }
        }

        public static async Task RemoveAllAsync<TEntity>()
            where TEntity : class
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

                var entities = context.Set<TEntity>().ToList();
                foreach (var ent in entities)
                    context.Remove(ent);

                await context.SaveChangesAsync();
            }
        }

        public static async Task<TEntity> FindAsync<TEntity>(int id)
           where TEntity : class
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            return await context.FindAsync<TEntity>(id);
        }

        public static async Task<AuthUser> FindUserAsync(int authUserId)
        {
            using var scope = _scopeFactory.CreateScope();

            var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

            return await context.AuthUsers
                .Include(x => x.RegabiturCustomuser)
                .Include(x => x.RegabiturAdditionalinfo)
                .ThenInclude(x => x.RegabiturAdditionalinfoEducationProfiles)
                .ThenInclude(x => x.Choicesprofile)
                .FirstOrDefaultAsync(x => x.Id == authUserId);
        }

        public static async Task AddAsync<TEntity>(TEntity entity)
            where TEntity : class
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Add(entity);

                await context.SaveChangesAsync();
            }
        }

        public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = _scopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetService<IMediator>();

            return await mediator.Send(request);
        }

        public static async Task<int> RunAsUserAsync(bool addCustom = false, bool addProfiles = false, bool addPublishes = false)
        {
            var authUser = new AuthUser
            {
                Password = "password",
                IsSuperuser = false,
                Username = "testusername",
                FirstName = "Testfirstname",
                LastName = "Testlastname",
                Email = "test@example.com",
                IsStaff = false,
                IsActive = false,
                DateJoined = DateTime.Now
            };

            // Custom User
            if (addCustom)
            {
                var customUser = new RegabiturCustomuser
                {
                    DateOfBirth = DateTime.Now,
                    Patronymic = "Testpatronymic",
                    PhoneNumber = "123456",
                    SendingStatus = UserDocSendingStatus.No,
                    CompleteFlag = false,
                    AgreementFlag = false,
                    WorkFlag = false,
                    SuccessFlag = false,
                    Address = "Test address",
                    CommentAdmin = "Test comment admin",
                    DateOfDoc = "Test date of doc",
                    NameUz = "Test name uz",
                    Passport = "12345678",
                    Snils = "12345678901",
                    Message = "Test message"
                };
                authUser.RegabiturCustomuser = customUser;
            }

            // Additional Info
            if (addProfiles)
            {
                var addInfo = new RegabiturAdditionalinfo();
                authUser.RegabiturAdditionalinfo = addInfo;

                // Choises profile
                addInfo.RegabiturAdditionalinfoEducationProfiles = new List<RegabiturAdditionalinfoEducationProfile>
                {
                     new RegabiturAdditionalinfoEducationProfile
                     {
                         Additionalinfo = addInfo,
                         Choicesprofile = new RegabiturChoicesprofile { Description = UserChoisesProfile.BakOfoUp}
                     },
                     new RegabiturAdditionalinfoEducationProfile
                     {
                         Additionalinfo = addInfo,
                         Choicesprofile = new RegabiturChoicesprofile { Description = UserChoisesProfile.BakOfoGp}
                     }
                };
            }

            // Documentuser
            var docUser = new RegabiturDocumentuser
            {
                NameDoc = "Test name doc",
                Doc = "Test doc"
            };
            authUser.RegabiturDocumentusers = new List<RegabiturDocumentuser> {
                docUser
            };

            if (addPublishes)
            {
                // Publishtab
                var publishtab = new RegabiturPublishtab
                {
                    IndividualStr = "Test Ind Str",
                    TestType = "Test testtype"
                };
                authUser.RegabiturPublishtab = publishtab;

                var publishRecTab = new RegabiturPublishrectab
                {
                    TestType = "Test testtype",
                    Advantage = "adv",
                    SostType = "sost",
                    Sogl = "sogl",
                    Comment = "comment"
                };
                authUser.RegabiturPublishrectab = publishRecTab;
            }

            await AddAsync<AuthUser>(authUser);

            _currentUserId = authUser.Id;

            return _currentUserId;
        }
    }
}