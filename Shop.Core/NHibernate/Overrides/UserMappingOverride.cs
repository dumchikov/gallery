using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using Shop.Domain.Models;

public class UserMappingOverride : IAutoMappingOverride<User>
{
    public void Override(AutoMapping<User> mapping)
    {
        mapping.HasMany(x => x.Photos).Cascade.All();
    }
}