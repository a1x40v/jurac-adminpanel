using MediatR;

namespace Application.Features.Document.Requests.Queries
{
    public class GetDocumentContentQuery : IRequest<MemoryStream>
    {
        public int Id { get; set; }
    }
}