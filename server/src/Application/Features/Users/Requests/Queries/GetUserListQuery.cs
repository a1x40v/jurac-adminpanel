using Application.Common.QueryString;
using Application.DTO.User;
using MediatR;

namespace Application.Features.Users.Requests.Queries
{
    public class GetUserListQuery : IRequest<UserListVm>
    {
        public UserQueryParameters QueryParams { get; set; }
    }
}