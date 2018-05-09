using Data.EF;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected JWTDemoContext Context { get; }
        protected DbSet<T> DbSet { get; }
        public BaseRepository(JWTDemoContext context)
        {
            this.Context = context;
            this.DbSet = context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return Context.Set<T>();
        }
        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }
        public T GetById(int id) 
        {
            return Context.Set<T>().Find(id);
        }
        public T GetById(Guid id)
        {
            return Context.Set<T>().Find(id);
        }
        public virtual T Add(T entity)
        {
            DbSet.Add(entity);
            return entity;
        }
        public virtual bool CheckContains(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }
        public virtual int Count(Expression<Func<T, bool>> where)
        {
            return DbSet.Count();
        }
        public virtual Task<int> CountAsync(Expression<Func<T, bool>> where)
        {
            return DbSet.CountAsync();
        }
        public virtual T Delete(T entity)
        {
            DbSet.Remove(entity);
            return entity;
        }
        public virtual void DeleteMulti(Expression<Func<T, bool>> where)
        {
            var objects = DbSet.Where(where).ToList();
            foreach (var obj in objects)
                DbSet.Remove(obj);
        }
        public virtual void Update(T entity)
        {
            DbSet.Update(entity);
        }
        public virtual List<T> Find(Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                            Expression<Func<T, T>> selector = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            var query = DbSet.AsQueryable();
            if (where != null)
            {
                query = query.Where(where);
            }
            if (include != null)
            {
                query = include(query);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (selector != null)
            {
                query = query.Select(selector);
            }
            return query.ToList();
        }
        public Task<List<T>> FindAsync(Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Expression<Func<T, T>> selector = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            var query = DbSet.AsQueryable();
            if (where != null)
            {
                query = query.Where(where);
            }
            if (include != null)
            {
                query = include(query);
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (selector != null)
            {
                query = query.Select(selector);
            }
            return query.ToListAsync();
        }

        public void SaveChanges() => this.Context.SaveChanges();

        public void Dispose()
        {
            Context.Dispose();
        }

        public IQueryable<T> GetQuery() => DbSet.AsQueryable();
    }
}
