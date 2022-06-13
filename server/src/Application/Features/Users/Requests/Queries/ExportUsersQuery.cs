using Application.DTO.User;
using MediatR;

namespace Application.Features.Users.Requests.Queries
{
    public class ExportUsersQuery : IRequest<MemoryStream>
    {
        public ICollection<ExportedUserDto> Users { get; set; }
    }
}