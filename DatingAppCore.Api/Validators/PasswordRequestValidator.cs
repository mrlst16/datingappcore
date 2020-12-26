using CommonCore.Models.Authentication;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAppCore.Api.Validators
{
    public class PasswordRequestValidator : AbstractValidator<PasswordRequest>
    {
        public PasswordRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .WithMessage(Errors.Messages.NoEmail)
                .WithErrorCode(Errors.Codes.NoEmail);
            RuleFor(x => x.UserName)
                .NotNull()
                .NotEmpty()
                .WithMessage(Errors.Messages.NoUsername)
                .WithErrorCode(Errors.Codes.NoUsername);
            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage(Errors.Messages.NoPassword)
                .WithErrorCode(Errors.Codes.NoPassword);
        }
    }
}
