using System.Web;
using System.Web.Security;
using Shop.Domain.Interfaces.DAL;
using Shop.Domain.Interfaces.Services.Authorization;
using Shop.Domain.Models;
using System.Linq;

namespace Shop.Services.Authorization
{
    public class AuthorizationProvider : IAuthorizationProvider
    {
        private readonly IRepository<User> users;

        public AuthorizationProvider(IRepository<User> users)
        {
            this.users = users;
        }

        public IAuthorizationResult LogOn(HttpResponseBase response, string email, string password)
        {
            var user = this.users.SingleOrDefault(x => x.Email == email && x.Password == password);
            bool success = false;

            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Login, false);
                success = true;
            }

            return new AuthorizationResult (success){User = user};
        }

        public void LogOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}