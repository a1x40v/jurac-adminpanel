using Application.Common.Pagination;

namespace Application.DTO.User
{
    public class UserListVm
    {
        public IEnumerable<UserDto> Users { get; set; }
        public PaginationResult Pagination { get; set; }
    }
}