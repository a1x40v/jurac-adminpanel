using Application.DTO.Account;
using MediatR;

namespace Application.Features.Account.Requests.Queries
{
    public class AuthenticateQuery : IRequest<AuthenticateResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}