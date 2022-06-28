using MediatR;

namespace Application.Features.Users.Requests.Commands
{
    public class SendEmailToUserCommand : IRequest
    {
        public string UserEmail { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}