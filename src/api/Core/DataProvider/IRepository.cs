namespace Core.DataProvider
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Core.Entities;

    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> Table { get; }

        IEnumerable<T> All();

        T Get(object id);

        T Get(Expression<Func<T, bool>> expression);

        T Insert(T entity);

        int Insert(IEnumerable<T> items);

        int Update(T entity);

        int Update(IEnumerable<T> items);

        int Delete(object id);

        int Delete(IEnumerable<T> items);
    }
}