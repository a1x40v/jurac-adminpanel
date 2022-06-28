using Application.Contracts.Infrastructure;
using Application.Features.Users.Requests.Commands;
using MediatR;

namespace Application.Features.Users.Handlers.Commands
{
    public class SendEmailToUserCommandHandler : IRequestHandler<SendEmailToUserCommand>
    {
        private readonly IEmailSender _emailSender;
        public SendEmailToUserCommandHandler(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task<Unit> Handle(SendEmailToUserCommand request, CancellationToken cancellationToken)
        {
            await _emailSender.SendEmailAsync(new[] { request.UserEmail }, request.Subject, request.Content);

            return Unit.Value;
        }
    }
}