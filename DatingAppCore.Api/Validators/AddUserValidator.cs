using CommonCore.Interfaces.Repository;
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
        private readonly ICrudRepository<User> _repository;

        public AddUserValidator(
            ICrudRepositoryFactory crudRepositoryFactory
            )
        {
            _repository = crudRepositoryFactory.Get<User>();

            RuleFor(x => x.Birthday)
                .NotNull()
                .NotEmpty()
                .WithMessage(Errors.Messages.NoBirthday)
                .WithErrorCode(Errors.Codes.NoBirthday);

            RuleFor(x => x.UserName)
                .NotNull()
                .NotEmpty()
                .WithMessage(Errors.Messages.NoUsername)
                .WithErrorCode(Errors.Codes.NoUsername);

            RuleFor(x => x)
                .Must(y =>
                {
                    if (y.IdType != Entities.Enum.IDTypeEnum.Internal)
                        return !string.IsNullOrWhiteSpace(y.ExternalID);
                    else return true;
                });

            RuleFor(x => x)
                .MustAsync((x, c) => UserNotYetExist(x))
                .WithMessage(Errors.Messages.UserExists)
                .WithErrorCode(Errors.Codes.UserExists);
        }

        public async Task<bool> UserNotYetExist(User user)
        {
            var existingUser = await _repository.First(x => x.UserName == user.UserName);
            return existingUser == null;
        }
    }
}
