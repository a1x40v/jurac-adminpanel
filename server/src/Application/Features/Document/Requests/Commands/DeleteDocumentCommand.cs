using MediatR;

namespace Application.Features.Document.Requests.Commands
{
    public class DeleteDocumentCommand : IRequest
    {
        public int Id { get; set; }
    }
}