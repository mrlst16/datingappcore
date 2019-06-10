using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Dto.Requests
{
    public class SetPropertiesRequest
    {
        public Guid UserID { get; set; }
        public IDictionary<string, string> Properties { get; set; }
    }
}