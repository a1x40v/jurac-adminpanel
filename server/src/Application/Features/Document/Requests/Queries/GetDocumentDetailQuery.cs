using Application.DTO.Document;
using MediatR;

namespace Application.Features.Document.Requests.Queries
{
    public class GetDocumentDetailQuery : IRequest<DocumentDto>
    {
        public int Id { get; set; }
    }
}