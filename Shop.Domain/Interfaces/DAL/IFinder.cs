using System.Linq;

namespace Shop.Domain.Interfaces.DAL
{
    public interface IFinder<TEntity> 
    {
        IQueryable<TEntity> All(ISpecification<TEntity> specification);

        TEntity One(ISingleSpecification<TEntity> specification);
    }
}
