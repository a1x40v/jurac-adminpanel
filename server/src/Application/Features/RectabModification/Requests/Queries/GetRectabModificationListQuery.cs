using Application.DTO.RectabModification;
using MediatR;

namespace Application.Features.RectabModification.Requests.Queries
{
    public class GetRectabModificationListQuery : IRequest<ICollection<RectabModificationDto>>
    {
    }
}