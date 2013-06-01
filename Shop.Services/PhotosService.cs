using System.Collections.Generic;
using Shop.Domain.Interfaces.DAL;
using Shop.Domain.Models;
using System.Linq;

namespace Shop.Services
{
    public class PhotosService : BaseService<Image>
    {
        public PhotosService(IRepository<Image> repository) : base(repository)
        {
        }

        public IList<Image> GetByUser(string login)
        {
            return Repository.Where(x => x.User.Login == login).ToList();
        }
    }
}
