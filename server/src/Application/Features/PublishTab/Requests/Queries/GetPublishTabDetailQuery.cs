using Application.DTO.PublishTab;
using MediatR;

namespace Application.Features.PublishTab.Requests.Queries
{
    public class GetPublishTabDetailQuery : IRequest<PublishTabDto>
    {
        public int UserId { get; set; }
    }
}