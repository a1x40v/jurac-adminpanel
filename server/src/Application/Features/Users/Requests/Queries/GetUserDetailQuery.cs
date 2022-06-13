using Application.DTO.User;
using MediatR;

namespace Application.Features.Users.Requests.Queries
{
    public class GetUserDetailQuery : IRequest<UserDetailVm>
    {
        public int Id { get; set; }
    }
}