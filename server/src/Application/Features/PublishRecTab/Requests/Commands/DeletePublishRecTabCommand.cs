using MediatR;

namespace Application.Features.PublishRecTab.Requests.Commands
{
    public class DeletePublishRecTabCommand : IRequest
    {
        public int UserId { get; set; }
    }
}