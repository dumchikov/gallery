using System;
using System.Web.Mvc;
using Shop.Domain.Interfaces.Services.Authorization;
using Shop.Domain.Models;
using Shop.Services;
using Shop.Web.Models;

namespace Shop.Web.Controllers
{
    public class AccountController : Controller
    {
        private IAuthorizationProvider authorization;

        public AccountController(IAuthorizationProvider authorization)
        {
            this.authorization = authorization;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            var result = this.authorization.LogOn(this.Response, model.Email, model.Password);
            if (!result.Success)
            {
                ViewBag.Error = result.Message;
                return View();
            }

            return this.Redirect("/" + result.User.Login);
        }
    }
}
