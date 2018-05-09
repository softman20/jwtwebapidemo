using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.Repositories.Interfaces
{
    public interface IGenericRepository<TContext> : IDisposable
    {
        IQueryable<T> GetAll<T>() where T : class;

        IQueryable<T> FindBy<T>(Expression<Func<T, bool>> predicate) where T : class;

        T GetById<T>(int id) where T : class;

        void Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        bool Save();
    }
}
