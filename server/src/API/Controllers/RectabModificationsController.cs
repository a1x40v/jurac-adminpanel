using Application.DTO.RectabModification;
using Application.Features.RectabModification.Requests.Queries;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class RectabModificationsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<ICollection<RectabModificationDto>>> GetAllModification()
        {
            return Ok(await Mediator.Send(new GetRectabModificationListQuery()));
        }
    }
}