using Application.Features.PublishRecTab.Requests.Commands;
using Domain.Constants;
using FluentValidation;

namespace Application.Features.PublishRecTab.Validators
{
    public class BasePublishRecTabCommandValidator : AbstractValidator<IPublishRecTabCommand>
    {
        public BasePublishRecTabCommandValidator()
        {
            RuleFor(x => x.TestType)
                .Must(testType =>
                {
                    var acceptedValues = new string[] { UserTestType.Ege, UserTestType.VI };
                    return acceptedValues.Contains(testType);
                });
        }
    }
}