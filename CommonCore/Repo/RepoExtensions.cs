using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Repo.Entities;

namespace CommonCore.Repo
{
    public static class RepoExtensions
    {
        public static T EnsureID<T>(this T obj)
            where T : IEntity
        {
            if(obj.ID == Guid.Empty)
                obj.ID = Guid.NewGuid();
            return obj;
        }
    }
}
