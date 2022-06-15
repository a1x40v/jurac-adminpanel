using MediatR;

namespace Application.Features.PublishRecTab.Requests.Commands
{
    public class DeletePublishRecTabCommand : IRequest
    {
        public int Id { get; set; }
    }
}