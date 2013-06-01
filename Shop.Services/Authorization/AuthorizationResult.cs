using Shop.Domain.Interfaces.Services.Authorization;
using Shop.Domain.Models;

namespace Shop.Services.Authorization
{
    public class AuthorizationResult : IAuthorizationResult
    {
        public AuthorizationResult()
        {
        }

        public AuthorizationResult(bool success)
        {
            this.Success = success;
            this.Message = success ? string.Empty : "Incorrect login or password";
        }

        public bool Success { get; set; }

        public string Message { get; set; }

        public User User { get; set; }
    }
}