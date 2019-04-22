using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Validation
{
    public class Validator
    {

        public static bool Validate(IValidatable obj)
        {
            if (obj == null) return false;

            bool result = true;
            try
            {
                return !obj.GetType()
                    .GetProperties()
                    .Where(x => IsRequired(x))
                    .Any(x =>
                    {
                        return x.GetValue(obj) == null;
                    });
            }
            catch (Exception e)
            {
                result = false;
            }

            return result;
        }

        public static bool IsRequired(PropertyInfo propertyInfo)
        {
            return propertyInfo
                .GetCustomAttributes(true)
                .Select(x => x.GetType())
                .Contains(typeof(RequiredAttribute));
        }
    }
}
