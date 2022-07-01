using Application.Common.Exceptions;
using Application.Contracts.Identity;
using Application.Contracts.Infrastructure;
using Application.Features.Email.Requests.Commands;
using Domain;
using FluentValidation.Results;
using MediatR;
using Persistence;

namespace Application.Features.Email.Handlers.Commands
{
    public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand>
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IEmailSender _emailSender;
        private readonly IUserAccessor _userAccessor;
        public SendEmailCommandHandler(ApplicationDbContext dbContext, IEmailSender emailSender, IUserAccessor userAccessor)
        {
            _userAccessor = userAccessor;
            _dbContext = dbContext;
            _emailSender = emailSender;
        }

        public async Task<Unit> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            int senderId = _userAccessor.GetUserId();
            var sender = await _dbContext.AuthUsers.FindAsync(senderId);

            if (sender == null)
            {
                throw new NotFoundException("Current User", senderId);
            }

            var recipient = await _dbContext.AuthUsers.FindAsync(request.UserId);

            if (recipient == null)
            {
                throw new NotFoundException("AuthUser", request.UserId);
            }

            if (String.IsNullOrEmpty(recipient.Email))
            {
                var failure = new ValidationFailure("UserId", $"The User with id '{request.UserId}' doesn't have a valid email address");
                throw new ValidationException(new[] { failure });

            }

            // send the email
            try
            {
                await _emailSender.SendEmailAsync(new[] { recipient.Email }, request.Subject, request.Content);
            }
            catch (Exception ex)
            {
                throw new ExternalResourceException(ex.Message);
            }

            // save massage to DB
            var message = new AdminpanelEmailmessage
            {
                Subject = request.Subject,
                Content = request.Content,
                SentAt = DateTime.UtcNow,
                Sender = sender,
                Recipient = recipient,
                RecipientEmail = recipient.Email,
            };

            _dbContext.Add(message);

            var result = await _dbContext.SaveChangesAsync() > 0;

            if (!result)
            {
                throw new DatabaseException("Failed to save an email message");
            }

            return Unit.Value;
        }
    }
}