using System.Linq;

namespace Shop.Domain.Interfaces.DAL
{
    public interface ISpecification<T> 
    {
        IQueryable<T> SatisfiedBy(IQueryable<T> candidates);
    }    
}