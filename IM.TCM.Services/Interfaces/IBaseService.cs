using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IM.TCM.Services.Interfaces
{
   public interface IBaseService<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        T GetById(Guid id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
