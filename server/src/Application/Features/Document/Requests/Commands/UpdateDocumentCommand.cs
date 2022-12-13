
using MediatR;

namespace Application.Features.Document.Requests.Commands
{
    public class UpdateDocumentCommand : IRequest
    {
        public int DocId { get; set; }
        public byte[] FileBytes { get; set; }
        public string FileName { get; set; }
        public string DocType { get; set; }
    }
}