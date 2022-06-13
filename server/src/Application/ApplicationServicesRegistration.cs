using Application.Common.Behaviours;
using Application.Common.Sorting;
using Application.Contracts.Common;
using Application.DTO.User;
using Application.Features.Users.Requests.Commands;
using Application.MappingProfiles;
using Domain;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddAutoMapper(typeof(UserProfile).Assembly);
            services.AddMediatR(typeof(UpdateUserCommand).Assembly);

            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
                });
            });

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddScoped<ISortHelper<UserDto>, SortHelper<UserDto>>();

            return services;
        }
    }
}