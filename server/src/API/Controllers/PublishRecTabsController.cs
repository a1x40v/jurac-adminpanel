using Application.DTO.PublishRecTab;
using Application.Features.PublishRecTab.Requests.Commands;
using Application.Features.PublishRecTab.Requests.Queries;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PublishRecTabsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<ICollection<PublishRecTabDto>>> GetAllPublishRecTabs()
        {
            return Ok(await Mediator.Send(new GetPublishRecTabListQuery()));
        }

        [HttpPost]
        public async Task<ActionResult> CreatePublishRecTabs(CreatePublishRecTabCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("users/{userId}")]
        public async Task<ActionResult> UpdatePublishRecTab(int userId, UpdatePublishRecTabCommand command)
        {
            if (userId != command.UserId) return BadRequest();

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("users/{userId}")]
        public async Task<ActionResult> DeletePublishRecTab(int userId)
        {
            await Mediator.Send(new DeletePublishRecTabCommand { UserId = userId });

            return NoContent();
        }

        [HttpPost("deploy")]
        public async Task<ActionResult> DeployPublishRecTabs()
        {
            await Mediator.Send(new DeployPublishRecTabsCommand());

            return Ok();
        }
    }
}