using API.DTO.Document;
using API.Extensions;
using Application.Features.Document.Requests.Commands;
using Application.Features.Document.Requests.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class DocumentsController : BaseApiController
    {
        [HttpGet("users/{userId}")]
        public async Task<ActionResult> GetDocumentsForUser(int userId)
        {
            return Ok(await Mediator.Send(new GetUserDocumentListQuery { UserId = userId }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetDocument(int id)
        {
            return Ok(await Mediator.Send(new GetDocumentDetailQuery { Id = id }));
        }

        [HttpPost("users/{userId}")]
        public async Task<ActionResult> CreateDocument(int userId, [FromForm] CreateDocumentDto dto)
        {
            if (userId != dto.UserId) return BadRequest();

            var fileBytes = await dto.File.GetBytesAsync();
            await Mediator.Send(new CreateDocumentCommand { UserId = dto.UserId, FileName = dto.FileName, FileBytes = fileBytes, DocType = dto.DocType });

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDocument(int id, [FromForm] UpdateDocumentDto dto)
        {
            if (id != dto.DocId) return BadRequest();

            var fileBytes = dto.File != null ? await dto.File.GetBytesAsync() : new byte[] { };
            await Mediator.Send(new UpdateDocumentCommand { DocId = dto.DocId, FileName = dto.FileName, FileBytes = fileBytes, DocType = dto.DocType });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDocument(int id)
        {
            await Mediator.Send(new DeleteDocumentCommand { Id = id });

            return NoContent();
        }

        [HttpGet("{id}/content")]
        public async Task<ActionResult> GetDocumentContent(int id)
        {
            var stream = await Mediator.Send(new GetDocumentContentQuery { Id = id });
            stream.Flush();
            stream.Position = 0;
            return File(stream, "application/octet-stream", "filecontent");
        }
    }
}