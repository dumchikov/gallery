using System.Web;

namespace Shop.Domain.Interfaces.Services.Authorization
{
    public interface IAuthorizationProvider
    {
        IAuthorizationResult LogOn(HttpResponseBase response, string email, string password);
        void LogOut();
    }
}