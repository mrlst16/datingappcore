using CommonCore.Interfaces.RuleTrees;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatingAppCore.Entities.Members
{
    public class UserSettings
    {
        public Guid UserID { get; set; }
        public IRuleTree Preferences { get; set; }
    }
}
