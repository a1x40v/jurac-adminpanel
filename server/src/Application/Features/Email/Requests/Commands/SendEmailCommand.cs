using MediatR;

namespace Application.Features.Email.Requests.Commands
{
    public class SendEmailCommand : IRequest
    {
        public int UserId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}