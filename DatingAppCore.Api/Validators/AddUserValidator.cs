using DatingAppCore.Entities.Members;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAppCore.Api.Validators
{
    public class AddUserValidator : AbstractValidator<User>
    {

        public AddUserValidator()
        {
            RuleFor(x => x.Birthday)
                .NotNull()
                .WithMessage("Birthday may not be null");

            RuleFor(x => x)
                .Must(y =>
                {
                    if (y.IdType != Entities.Enum.IDTypeEnum.Internal)
                        return !string.IsNullOrWhiteSpace(y.ExternalID);
                    else return true;
                });

            RuleFor(x => x.ClientID)
                .Must(x => x != Guid.Empty)
                .WithMessage("ClientId must be provided");

        }
    }
}
