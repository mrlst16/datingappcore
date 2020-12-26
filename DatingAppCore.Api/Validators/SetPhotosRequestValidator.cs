using DatingAppCore.Dto.Requests;
using DatingAppCore.Entities.Members;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingAppCore.Api.Validators
{
    public class SetPhotosRequestValidator : AbstractValidator<SetPhotosRequest>
    {
        public SetPhotosRequestValidator()
        {

        }
    }
}
