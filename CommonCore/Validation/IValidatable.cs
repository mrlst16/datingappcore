using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Validation
{
    public interface IValidatable
    {
        bool Validate();
    }
}