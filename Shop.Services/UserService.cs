using System.Linq;
using Shop.Domain.Interfaces.DAL;
using Shop.Domain.Models;

namespace Shop.Services
{
    public class UserService : BaseService<User>
    {
        public UserService(IRepository<User> repository) : base(repository)
        {
        }

        public User GetByLogin(string login)
        {
            return Repository.SingleOrDefault(x => x.Login == login);
        }
    }
}
