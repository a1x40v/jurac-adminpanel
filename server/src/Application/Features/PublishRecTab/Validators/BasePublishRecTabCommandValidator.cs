using Application.Features.PublishRecTab.Requests.Commands;
using FluentValidation;

namespace Application.Features.PublishRecTab.Validators
{
    public class BasePublishRecTabCommandValidator : AbstractValidator<IPublishRecTabCommand>
    {
        public BasePublishRecTabCommandValidator()
        {
            RuleFor(x => x.TestType)
                .Must(testType => {
                    var acceptedValues = new string[] { "ЕГЭ", "Вступительные испытания"};
                    return acceptedValues.Contains(testType);
                });
        }
    }
}