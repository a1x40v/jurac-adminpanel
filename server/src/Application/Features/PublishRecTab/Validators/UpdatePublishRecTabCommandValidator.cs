using Application.Features.PublishRecTab.Requests.Commands;
using FluentValidation;

namespace Application.Features.PublishRecTab.Validators
{
    public class UpdatePublishRecTabCommandValidator : AbstractValidator<UpdatePublishRecTabCommand>
    {
        public UpdatePublishRecTabCommandValidator()
        {
            Include(new BasePublishRecTabCommandValidator());
        }
    }
}