using Application.DTO.PublishRecTab;
using MediatR;

namespace Application.Features.PublishRecTab.Requests.Queries
{
    public class GetPublishRecTabDetailQuery : IRequest<PublishRecTabDto>
    {
        public int UserId { get; set; }
    }
}