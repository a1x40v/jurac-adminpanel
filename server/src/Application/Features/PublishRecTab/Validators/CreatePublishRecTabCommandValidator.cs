using Application.Features.PublishRecTab.Requests.Commands;
using FluentValidation;

namespace Application.Features.PublishRecTab.Validators
{
    public class CreatePublishRecTabCommandValidator : AbstractValidator<CreatePublishRecTabCommand>
    {
        public CreatePublishRecTabCommandValidator()
        {
            Include(new BasePublishRecTabCommandValidator());
        }
    }
}