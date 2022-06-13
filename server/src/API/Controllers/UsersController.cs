using Application.Common.QueryString;
using Application.DTO.User;
using Application.Features.Users.Requests.Commands;
using Application.Features.Users.Requests.Queries;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<UserListVm>> GetAllUsers([FromQuery] UserQueryParameters param)
        {
            if (!param.ValidDateJoinedRange) return BadRequest("Invalid date joied range");

            return await Mediator.Send(new GetUserListQuery { QueryParams = param });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetailVm>> GetUserById(int id)
        {
            return await Mediator.Send(new GetUserDetailQuery { Id = id });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, UpdateUserCommand command)
        {
            if (id != command.Id) return BadRequest();

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await Mediator.Send(new DeleteUserCommand { Id = id });

            return NoContent();
        }

        [HttpPost("export")]
        public async Task<ActionResult> ExportUsers(ExportUsersQuery query)
        {
            MemoryStream stream = await Mediator.Send(query);
            var content = stream.ToArray();

            return File(
                content,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "users.xlsx");
        }
    }

}