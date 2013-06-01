using System.Linq;

namespace Shop.Domain.Interfaces.DAL
{
    public interface ISingleSpecification<T> 
    {
        T SatisfiedBy(IQueryable<T> candidates);
    }    
}