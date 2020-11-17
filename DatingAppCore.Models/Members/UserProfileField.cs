using CommonCore.Repo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppCore.Entities.Members
{
    public class UserProfileField : EntityBase
    {
        public Guid UserID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsSetting { get; set; } = false;

        public override bool Equals(object obj)
        {
            if(obj is UserProfileField)
            {
                var pf = obj as UserProfileField;
                return this.Name == pf.Name
                    && this.UserID == pf.UserID
                    && this.IsSetting == pf.IsSetting;
            }
            return false;
        }
    }
}
