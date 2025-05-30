using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace demo.Core.Data
{
    public class Repository<T> where T : class
    {
        private readonly DbContext _ctx;
        private readonly DbSet<T> _set;

        public Repository(DbContext ctx)
        {
            _ctx = ctx;
            _set = ctx.Set<T>();
        }

        public IEnumerable<T> All() => _set.ToList();
        public T ById(int id) => _set.Find(id);
        public IEnumerable<T> Where(Expression<Func<T, bool>> f) => _set.Where(f).ToList();

        public void Add(T e) => _set.Add(e);
        public void Remove(T e) => _set.Remove(e);
        public void RemoveById(int id)
        {
            var e = ById(id);
            if (e != null) Remove(e);
        }
    }
}
