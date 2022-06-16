using System.Text;
using Application.Common.Exceptions;
using Application.Contracts.Identity;
using Application.DTO.Account;
using Application.Features.Account.Requests.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Features.Account.Handlers.Queries
{
    public class AuthenticateQueryHandler : IRequestHandler<AuthenticateQuery, AuthenticateResponse>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IPasswordHashingService _hashingService;
        private readonly ITokenService _tokenService;
        public AuthenticateQueryHandler(ApplicationDbContext dbContext, IPasswordHashingService hashingService, ITokenService tokenService)
        {
            _dbContext = dbContext;
            _hashingService = hashingService;
            _tokenService = tokenService;
        }

        public async Task<AuthenticateResponse> Handle(AuthenticateQuery request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.AuthUsers.FirstOrDefaultAsync(x => x.Username == request.Username && x.IsStaff == true);

            if (user == null)
            {
                throw new AuthException("Wrong email or password.");
            }

            const int hashByteSize = 32;

            string[] passData = user.Password.Split('$');

            int iterations = int.Parse(passData[1]);

            byte[] saltBytes = Encoding.ASCII.GetBytes(passData[2]);
            string saltString = Convert.ToBase64String(saltBytes);

            string pwdHash = passData[3];

            bool isValid = _hashingService.ValidatePassword(request.Password, saltString, iterations, hashByteSize, pwdHash);

            if (!isValid)
            {
                throw new AuthException("Wrong email or password.");
            }

            var jwtToken = _tokenService.GenerateJwtToken(user);

            return new AuthenticateResponse
            {
                JwtToken = jwtToken,
                Account = new AccountDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    IsSuperUser = user.IsSuperuser
                }
            };
        }
    }
}