using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonCore.Repo.Entities;
using Microsoft.EntityFrameworkCore;

namespace CommonCore.Repo.Repository
{
    public class Repository<T> : IRepository<T, Repository<T>>, IRepoAdapter
        where T : class
    {
        protected DbContext _context { get; set; }
        protected DbSet<T> _set;
        protected IQueryable<T> _query;

        Repository()
        {
        }

        public Repository(DbContext context)
        {
            _context = context;
        }

        public Repository<T> Add(T item, bool save = true)
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

        public Repository<T> Add(T item, IComparer<T> comparer, bool save)
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

        public Repository<T> AddRange(IEnumerable<T> range, bool save = false)
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

        public Repository<T> Save()
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


        public static Repository<T> Create()
        {
            return new Repository<T>();
        }

        public Repository<T> CreateOrUpdate(IEnumerable<T> range, bool save)
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

        public Repository<T> CreateOrUpdate(IEnumerable<T> range, IComparer<T> comparer, bool save = false)
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

        public Repository<T> Remove(T item, bool save = false)
        {
            GetSet().Remove(item);

            if (save) Save();
            return this;
        }

        public Repository<T> RemoveRange(IEnumerable<T> range, bool save = false)
        {
            GetSet().RemoveRange(range);

            if (save) Save();
            return this;
        }
    }
}