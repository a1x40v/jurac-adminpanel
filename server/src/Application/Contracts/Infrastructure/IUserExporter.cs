using Application.DTO.User;

namespace Application.Contracts.Infrastructure
{
    public interface IUserExporter
    {
        MemoryStream ExportUsers(ICollection<ExportedUserDto> users);
    }
}