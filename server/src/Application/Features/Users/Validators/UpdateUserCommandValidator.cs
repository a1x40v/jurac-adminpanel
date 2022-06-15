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

            RuleFor(x => x.ChoicesProfiles)
                .Must(profiles =>
                {
                    var acceptedProfiles = new List<string> {
                        UserChoisesProfile.BakOfoUp, UserChoisesProfile.BakZfoUp, UserChoisesProfile.BakOzfoUp,
                        UserChoisesProfile.BakOfoGp, UserChoisesProfile.BakZfoGp, UserChoisesProfile.BakOzfoGp,
                        UserChoisesProfile.SpecOfoSd, UserChoisesProfile.MagOfoPo, UserChoisesProfile.MagZfoPo,
                        UserChoisesProfile.MagOfoTp, UserChoisesProfile.MagZfoTp,
                        UserChoisesProfile.AspOfoTip, UserChoisesProfile.AspZfoTip,
                        UserChoisesProfile.AspOfoUp, UserChoisesProfile.AspZfoUp,
                        UserChoisesProfile.AspOfoKs, UserChoisesProfile.AspZfoKs,
                        UserChoisesProfile.AspOfoGp, UserChoisesProfile.AspOfoUgp,
                    };

                    foreach (var profile in profiles)
                    {
                        if (!acceptedProfiles.Contains(profile)) return false;
                    }

                    return true;
                });

            RuleFor(x => x.CompleteFlag).NotNull();
            RuleFor(x => x.AgreementFlag).NotNull();
            RuleFor(x => x.WorkFlag).NotNull();
            RuleFor(x => x.SuccessFlag).NotNull();
        }
    }
}