using Application.Features.Users.Requests.Commands;
using Domain.Constants;
using FluentValidation;

namespace Application.Features.Users.Validators
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();

            RuleFor(x => x.SendingStatus)
                .Must(status =>
                {
                    var statuses = new string[] {
                        UserDocSendingStatus.Error, UserDocSendingStatus.No, UserDocSendingStatus.Send,
                        UserDocSendingStatus.Working, UserDocSendingStatus.Success, UserDocSendingStatus.Back
                    };
                    return statuses.Contains(status);
                })
                .WithMessage("Incorrect sending status value.");

            RuleFor(x => x.CompleteFlag).NotNull();
            RuleFor(x => x.AgreementFlag).NotNull();
            RuleFor(x => x.WorkFlag).NotNull();
            RuleFor(x => x.SuccessFlag).NotNull();
        }
    }
}