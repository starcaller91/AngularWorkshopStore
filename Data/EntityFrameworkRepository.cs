using Model.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class EntityFrameworkRepository<T> : IRepository<T> where T : Entity
    {
        public EntityFrameworkRepository(StoreContext context)
        {
            DbContext = context;
            DbSet = context.Set<T>();
        }

        protected DbSet<T> DbSet { get; }

        protected DbContext DbContext { get; }

        public IQueryable<T> Items => DbSet;

        public IQueryable<T> ItemsIncluding(params Expression<Func<T, object>>[] paths)
        {
            if (paths == null)
            {
                throw new ArgumentNullException(nameof(paths));
            }

            return paths.Aggregate<Expression<Func<T, object>>, IQueryable<T>>(DbSet,
                (current, includeProperty) => current.Include(includeProperty));
        }

        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (item.Id != 0)
            {
                throw new InvalidOperationException("You cannot add entity that has Id set.");
            }

            DbSet.Add(item);
        }

        public virtual void Delete(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            DbSet.Remove(item);
        }

        public virtual void Delete(int id)
        {

            Delete(id);

        }
    }
}
