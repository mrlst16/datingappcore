using DatingAppCore.Dto.Requests;
using DatingAppCore.Entities.Members;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAppCore.Api.Validators
{
    public class SetPropertiesRequestValidator : AbstractValidator<SetPropertiesRequest>
    {
        public SetPropertiesRequestValidator()
        {
            RuleFor(x => x.UserID)
                .NotEmpty()
                .NotNull()
                .WithMessage(Errors.Messages.NoUserId)
                .WithErrorCode(Errors.Codes.NoUserId);
        }
    }
}
