using DatingAppCore.Dto.Requests;
using FluentValidation;

namespace DatingAppCore.Api.Validators
{
    public class SetPhotosRequestValidator : AbstractValidator<SetPhotosRequest>
    {
        public SetPhotosRequestValidator()
        {
            RuleFor(x => x.UserID)
                .NotEmpty()
                .NotNull()
                .WithMessage(Errors.Messages.NoUserId)
                .WithErrorCode(Errors.Codes.NoUserId);
        }
    }
}
