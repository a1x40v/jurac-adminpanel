using MediatR;

namespace Application.Features.Document.Requests.Commands
{
    public class CreateDocumentCommand : IRequest
    {
        public int UserId { get; set; }
        public byte[] FileBytes { get; set; }
        public string FileName { get; set; }
        public string DocType { get; set; }
    }
}