using MediatR;

namespace Application.Features.PublishTab.Requests.Commands
{
    public class DeletePublishTabCommand : IRequest
    {
        public int UserId { get; set; }
    }
}