
using MediatR;

namespace Application.Features.Document.Requests.Commands
{
    public class UpdateDocumentCommand : IRequest
    {
        public int Id { get; set; }
        public byte[] File { get; set; }
        public string FileName { get; set; }
    }
}