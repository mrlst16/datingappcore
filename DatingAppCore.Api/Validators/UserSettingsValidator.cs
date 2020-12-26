using DatingAppCore.Entities.Members;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAppCore.Api.Validators
{
    public class UserSettingsValidator : AbstractValidator<UserSettings>
    {
        public UserSettingsValidator()
        {
            RuleFor(x => x.UserID)
               .NotEmpty()
               .NotNull()
               .WithMessage(Errors.Messages.NoUserId)
               .WithErrorCode(Errors.Codes.NoUserId);
        }
    }
}
