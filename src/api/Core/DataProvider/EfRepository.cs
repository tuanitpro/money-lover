namespace Core.DataProvider
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Core.Entities;

    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DataContext _dbContext;

        public EfRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual IQueryable<T> Table
        {
            get
            {
                return _dbContext.Set<T>();
            }
        }

        public virtual T Get(object id)
        {
            return _dbContext.Set<T>().SingleOrDefault(e => e.Id == int.Parse(id.ToString()));
        }

        public virtual IEnumerable<T> All()
        {
            return _dbContext.Set<T>().ToList();
        }

        public virtual T Insert(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public virtual int Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            return _dbContext.SaveChanges();
        }

        public virtual int Update(T entity)
        {
            _dbContext.Update(entity);
            return _dbContext.SaveChanges();
        }

        public virtual T Get(Expression<Func<T, bool>> expression)
        {
            return _dbContext.Set<T>().SingleOrDefault(expression);
        }

        public virtual int Insert(IEnumerable<T> items)
        {
            _dbContext.AddRange(items);
            return _dbContext.SaveChanges();
        }

        public virtual int Update(IEnumerable<T> items)
        {
            _dbContext.UpdateRange(items);
            return _dbContext.SaveChanges();
        }

        public virtual int Delete(object id)
        {
            T entity = Get(id);
            if (entity != null) return Delete(entity);
            return -1;
        }

        public virtual int Delete(IEnumerable<T> items)
        {
            _dbContext.Set<T>().RemoveRange(items);
            return _dbContext.SaveChanges();
        }
    }
}