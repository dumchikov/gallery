using System.Collections.Generic;
using System.Linq;
using Shop.Domain.Interfaces.DAL;
using Shop.Domain.Interfaces.Services;
using Shop.Domain.Models;

namespace Shop.Services
{
    public abstract class BaseService<T> : IService<T> where T : Entity
    {
        protected BaseService(IRepository<T> repository)
        {
            this.Repository = repository;
        }

        protected IRepository<T> Repository;

        public IList<T> GetAll()
        {
            return Repository.ToList();
        }

        public void Save(T entity)
        {
            Repository.Save(entity);
        }

        public void Remove(T entity)
        {
            Repository.Remove(entity);
        }

        public T GetById(int id)
        {
            var entity = Repository.SingleOrDefault(x => x.Id == id);
            return entity;
        }
    }
}