using DatingAppCore.Repo.Members;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatingAppCore.BLL.Helpers
{
    class UserProfileComparer : IEqualityComparer<UserProfileField>
    {
        public bool Equals(UserProfileField x, UserProfileField y)
        {
            return x.Name == y.Name && x.UserID == y.UserID && x.IsSetting == y.IsSetting;
        }

        public int GetHashCode(UserProfileField obj)
        {
            return base.GetHashCode();
        }
    }
}
