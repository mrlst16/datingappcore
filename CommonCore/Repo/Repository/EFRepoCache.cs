using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Extensions;
using CommonCore.Repo.Entities;
using CommonCore.Repo.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;

namespace CommonCore.Repo.Repository
{
    internal class ContextBag
    {
        internal Type Type;
        internal DbContext Context;
        internal IEnumerable<string> EntityNames;
        internal Dictionary<string, IRepoBridge> RepoAdapters = new Dictionary<string, IRepoBridge>();
    }

    public static class EFRepoCache
    {
        private static List<ContextBag> ContextBags = new List<ContextBag>();

        public static void Initialize(params Type[] contextTypes)
        {
            foreach (var contextType in contextTypes)
            {
                try
                {
                    var context = (DbContext)Activator.CreateInstance(contextType);

                    ContextBag bag = new ContextBag()
                    {
                        Context = context,
                        EntityNames = GetEntityNames(context),
                        Type = contextType
                    };
                    ContextBags.Add(bag);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public static DbContext GetContext(Type type)
            => ContextBags.FirstOrDefault(x => x.Type == type)?.Context ?? null;

        public static IQueryable<T> GetQuery<T>()
            where T : class, IEntity
        {
            return Get<T>().GetQuery();
        }

        public static EFRepository<T> Get<T>()
            where T : class, IEntity
        {
            try
            {
                var key = typeof(T).FullName;
                var contextBag = ContextBags.FirstOrDefault(x => x.EntityNames.Contains(key));

                if (contextBag == null)
                    throw new Exception($"Type {key} could not be found in any of the cached contexts");

                if (!contextBag.RepoAdapters.ContainsKey(key))
                    contextBag.RepoAdapters[key] = new EFRepository<T>(contextBag.Context);
                return (EFRepository<T>)contextBag.RepoAdapters[key];
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static IEnumerable<string> GetEntityNames(DbContext dbContext)
        {
            return dbContext.Model.GetEntityTypes().Select(x => x.Name);
        }

        public static List<ReturnT> RunSproc<ReturnT>(RunSprocRequest request
            )
        where ReturnT : class
        {
            string command = $"exec {request.SprocName} {request.Parameters.ToSqlParamsString()}";

            return GetContext(request.ContextType).Query<ReturnT>().FromSql(new RawSqlString(command)).ToList();
        }

    }
}