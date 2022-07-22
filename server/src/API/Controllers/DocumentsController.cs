using API.Extensions;
using Application.Features.Document.Requests.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class DocumentsController : BaseApiController
    {
        [HttpPost("users/{userId}")]
        public async Task<ActionResult> CreateDocument(IFormFile file, int userId)
        {
            var fileBytes = await file.GetBytesAsync();

            await Mediator.Send(new CreateDocumentCommand { UserId = userId, FileName = file.FileName, File = fileBytes });

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDocument(int id)
        {
            await Mediator.Send(new UpdateDocumentCommand { Id = id });

            return NoContent();
        }
    }
}