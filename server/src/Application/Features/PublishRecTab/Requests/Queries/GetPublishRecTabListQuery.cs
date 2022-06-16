using Application.DTO.PublishRecTab;
using MediatR;

namespace Application.Features.PublishRecTab.Requests.Queries
{
    public class GetPublishRecTabListQuery : IRequest<ICollection<PublishRecTabDto>>
    {
    }
}