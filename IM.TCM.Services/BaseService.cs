using IM.TCM.Data.Repositories;
using IM.TCM.Data.Repositories.Interfaces;
using IM.TCM.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IM.TCM.Services
{
    public abstract class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            _repository = baseRepository;
        }

        public void Add(T entity)
        {
            _repository.Add(entity);
            _repository.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = this.GetById(id);
            _repository.Delete(entity);
            _repository.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public T GetById(Guid id)
        {
            return _repository.GetById(id);
        }


        public void Update(T entity)
        {
            _repository.Update(entity);
            _repository.SaveChanges();
        }
    }
}
