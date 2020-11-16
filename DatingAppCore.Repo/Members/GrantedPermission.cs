using CommonCore.Repo.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DatingAppCore.Repo.EF.Members
{
    public class GrantedPermission : EntityBase
    {
        public Guid GrantorID { get; set; }
        public Guid GranteeID { get; set; }
        public int Permissions { get; set; }

        public User Grantor { get; set; }
        public User Grantee { get; set; }
    }
}