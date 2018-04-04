using System;
using System.Linq;
using System.Linq.Expressions;

namespace Model.Core
{
    public interface IRepository<T> where T : Entity
    {
        IQueryable<T> Items { get; }
        IQueryable<T> ItemsIncluding(params Expression<Func<T, object>>[] paths);
        void Add(T item);
        void Delete(T item);
        void Delete(int id);
    }
}
