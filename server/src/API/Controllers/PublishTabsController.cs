using Application.DTO.PublishTab;
using Application.Features.PublishTab.Requests.Commands;
using Application.Features.PublishTab.Requests.Queries;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PublishTabsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<ICollection<PublishTabDto>>> GetAllPublishTabs()
        {
            return Ok(await Mediator.Send(new GetPublishTabListQuery()));
        }

        [HttpGet("users/{userId}")]
        public async Task<ActionResult<ICollection<PublishTabDto>>> GetPublishTabForUser(int userId)
        {
            return Ok(await Mediator.Send(new GetPublishTabDetailQuery { UserId = userId }));
        }

        [HttpPost]
        public async Task<ActionResult> CreatePublishTab(CreatePublishTabCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("users/{userId}")]
        public async Task<ActionResult> UpdatePublishTabForUser(int userId, UpdatePublishTabCommand command)
        {
            if (userId != command.UserId) return BadRequest();

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("users/{userId}")]
        public async Task<ActionResult> DeletePublishTabForUser(int userId)
        {
            await Mediator.Send(new DeletePublishTabCommand { UserId = userId });

            return NoContent();
        }

    }
}