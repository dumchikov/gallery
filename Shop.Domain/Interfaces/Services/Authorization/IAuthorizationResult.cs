using Shop.Domain.Models;

namespace Shop.Domain.Interfaces.Services.Authorization
{
    public interface IAuthorizationResult
    {
        bool Success { get; set; }

        string Message { get; set; }

        User User { get; set; }
    }
}