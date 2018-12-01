namespace Core.DataProvider
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using Core.Entities;

    public interface IRepositoryAsync<T> where T : BaseEntity
    {
        Task<IQueryable<T>> TableAsync { get; }

        Task<IEnumerable<T>> AllAsync();

        Task<T> GetAsync(object id);

        Task<T> GetAsync(Expression<Func<T, bool>> expression);

        Task<T> InsertAsync(T entity);

        Task<int> InsertAsync(IEnumerable<T> items);

        Task<int> UpdateAsync(T entity);

        Task<int> UpdateAsync(IEnumerable<T> items);

        Task<int> DeleteAsync(object id);

        Task<int> DeleteAsync(IEnumerable<T> items);
    }
}