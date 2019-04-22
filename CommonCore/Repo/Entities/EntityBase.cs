using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonCore.Repo.Entities
{
    public abstract class EntityBase : IEntity
    {
        public Guid ID { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;
        public DateTime? LastUpdated { get; set; } = DateTime.UtcNow;

        public override bool Equals(Object obj)
        {
            if (!(obj is EntityBase))
                return false;
            return ((EntityBase)obj).ID == ID;
        }
    }
}
