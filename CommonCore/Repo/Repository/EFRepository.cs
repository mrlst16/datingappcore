using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Repo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommonCore.Repo.Repository
{
    public class EFRepository<T> : IRepository<T, EFRepository<T>>, IRepoBridge
        where T : class
    {
        protected DbContext _context { get; set; }
        protected DbSet<T> _set;
        protected IQueryable<T> _query;

        EFRepository()
        {
        }

        public EFRepository(DbContext context)
        {
            _context = context;
        }

        public EFRepository<T> Add(T item, bool save = true)
        {
            T f = GetSet().FirstOrDefault(x => x == item);
            if (f != null)
            {
                f = item;
            }
            else
            {
                GetSet().Add(item);
            }
            if (save) Save();
            return this;
        }

        public EFRepository<T> Add(T item, IComparer<T> comparer, bool save)
        {
            T f = GetSet().FirstOrDefault(x => comparer.Compare(x, item) == 1);
            if (f != null)
            {
                f = item;
            }
            else
            {
                GetSet().Add(item);
            }
            if (save) Save();
            return this;
        }

        public EFRepository<T> AddRange(IEnumerable<T> range, bool save = false)
        {
            foreach (var item in range)
            {
                T f = GetSet().FirstOrDefault(x => x == item);
                if (f != null)
                {
                    f = item;
                }
                else
                {
                    GetSet().Add(item);
                }
            }
            if (save) Save();
            return this;
        }

        public IQueryable<T> GetQuery()
        {
            return _query ?? (_query = _context.Set<T>().AsQueryable<T>());
        }

        public EFRepository<T> Save()
        {
            try
            {
                _context.SaveChanges();
                return this;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        protected DbSet<T> GetSet()
        {
            return _set ?? (_set = _context.Set<T>());
        }


        public static EFRepository<T> Create()
        {
            return new EFRepository<T>();
        }

        public EFRepository<T> CreateOrUpdate(IEnumerable<T> range, bool save)
        {

            foreach (var item in range)
            {
                T f = GetSet().FirstOrDefault(x => x == item);
                if (f != null)
                {
                    f = item;
                }
                else
                {
                    GetSet().Add(item);
                }
            }
            if (save) Save();
            return this;
        }

        public EFRepository<T> CreateOrUpdate(IEnumerable<T> range, IComparer<T> comparer, bool save = false)
        {

            foreach (var item in range)
            {
                T f = GetSet().FirstOrDefault(x => comparer.Compare(x, item) == 1);
                if (f != null)
                {
                    f = item;
                }
                else
                {
                    GetSet().Add(item);
                }
            }
            if (save) Save();
            return this;
        }

        public EFRepository<T> Remove(T item, bool save = false)
        {
            GetSet().Remove(item);

            if (save) Save();
            return this;
        }

        public EFRepository<T> RemoveRange(IEnumerable<T> range, bool save = false)
        {
            GetSet().RemoveRange(range);

            if (save) Save();
            return this;
        }
    }
}