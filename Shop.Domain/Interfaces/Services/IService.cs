using System.Collections.Generic;

namespace Shop.Domain.Interfaces.Services
{
    public interface IService<T>
    {
        IList<T> GetAll();

        void Save(T entity);

        void Remove(T entity);

        T GetById(int id);
    }
}