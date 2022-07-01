using Application.DTO.EmailMessage;
using Application.Features.Email.Requests.Commands;
using Application.Features.Email.Requests.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class EmailController : BaseApiController
    {
        [HttpGet("users/{recipientId}")]
        public async Task<ActionResult<ICollection<EmailMessageDto>>> GetAllMessagesForRecipient(int recipientId)
        {
            return Ok(await Mediator.Send(new GetEmailMessageListRecipientQuery { RecipientId = recipientId }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ICollection<EmailMessageDto>>> GetMessageById(int id)
        {
            return Ok(await Mediator.Send(new GetEmailMessageDetailQuery { Id = id }));
        }

        [HttpPost()]
        public async Task<ActionResult> SendEmail(SendEmailCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }
    }
}