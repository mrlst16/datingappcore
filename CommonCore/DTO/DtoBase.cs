using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Validation;

namespace CommonCore.DTO
{
    public class DtoBase : IValidatable
    {
        public Guid ID { get; set; }

        public bool Validate()
        {
            return Validator.Validate(this);
        }
    }
}
