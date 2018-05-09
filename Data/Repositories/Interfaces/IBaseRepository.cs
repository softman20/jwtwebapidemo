using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        T GetById(Guid id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate) ;
        /// <summary>
        /// Add entity
        /// </summary>
        ///<param>T</param>
        /// <returns>T</returns>
        T Add(T entity);
        /// <summary>
        /// Update
        /// </summary>
        ///<param>T</param>
        /// <returns>T</returns>
        void Update(T entity);


        /// <summary>
        /// Delete entity
        /// </summary>
        ///<param>T</param>
        /// <returns>T</returns>
        T Delete(T entity);
        /// <summary>
        /// DeleteMulti 
        /// </summary>
        ///<param>where</param>
        /// <returns>T</returns>     
        void DeleteMulti(Expression<Func<T, bool>> where);
        /// <summary>
        /// GetQuery 
        /// </summary>
        /// <returns>IQueryable<T></returns> 
        IQueryable<T> GetQuery();
        /// <summary>
        /// Find 
        /// </summary>
        ///<param>T</param>
        /// <returns>T</returns> 
        List<T> Find(Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                              Expression<Func<T, T>> selector = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        /// <summary>
        /// Find 
        /// </summary>
        ///<param>T</param>
        /// <returns>T</returns> 
        Task<List<T>> FindAsync(Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                              Expression<Func<T, T>> selector = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        /// <summary>
        /// Count  
        /// </summary>
        ///<param>where</param>
        /// <returns>int</returns> 
        int Count(Expression<Func<T, bool>> where);
        /// <summary>
        /// Count Async
        /// </summary>
        ///<param>where</param>
        /// <returns>Task<int></returns> 
        Task<int> CountAsync(Expression<Func<T, bool>> where);

        bool CheckContains(Expression<Func<T, bool>> predicate);
        void SaveChanges();
    }
}
