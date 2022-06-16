using Application.DTO.PublishRecTab;
using Application.Features.PublishRecTab.Requests.Commands;
using Application.Features.PublishRecTab.Requests.Queries;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PublishRecTabController : BaseApiController
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

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePublishRecTab(int id, UpdatePublishRecTabCommand command)
        {
            if (id != command.Id) return BadRequest();

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePublishRecTab(int id)
        {
            await Mediator.Send(new DeletePublishRecTabCommand { Id = id });

            return NoContent();
        }
    }
}