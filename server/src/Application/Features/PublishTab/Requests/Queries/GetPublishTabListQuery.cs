using Application.DTO.PublishTab;
using MediatR;

namespace Application.Features.PublishTab.Requests.Queries
{
    public class GetPublishTabListQuery : IRequest<ICollection<PublishTabDto>>
    {
    }
}