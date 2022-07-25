using Application.DTO.Documentuser;
using MediatR;

namespace Application.Features.Document.Requests.Queries
{
    public class GetUserDocumentListQuery : IRequest<ICollection<DocumentDto>>
    {
        public int UserId { get; set; }
    }
}