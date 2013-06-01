using System;
using System.Web;
using System.Web.Mvc;
using Shop.Domain.Interfaces.Services;
using Shop.Domain.Models;
using Shop.Services;
using Shop.Web.Attributes;

namespace Shop.Web.Controllers
{
    public class PhotosController : Controller
    {
        private readonly PhotosService photosService;

        private readonly UserService userService;

        private readonly IImageManager imageManager;

        public PhotosController(PhotosService photosService, IImageManager imageManager, UserService userService)
        {
            this.photosService = photosService;
            this.imageManager = imageManager;
            this.userService = userService;
        }

        public ActionResult Index(string login)
        {
            if (login == null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    login = this.User.Identity.Name;
                    return this.Redirect("/" + login);
                }

                return this.Redirect("/Account/Login");
            }

            var photos = this.photosService.GetByUser(login);
            return View(photos);
        }

        //[Transaction]
        public ActionResult Add()
        {
            HttpPostedFileBase image = this.Request.Files[0];
            var name = this.imageManager.Save(image);
            var user = this.userService.GetByLogin(this.User.Identity.Name);
            user.Photos.Add(new Image { Name = name });
            user.Birthday = DateTime.Now;
            this.userService.Save(user);
            return this.Content(name);
        }

        public ActionResult AddUser(string login, string password, string email)
        {
            var user = new User {Email = email, Login = login, Password = password};
            this.userService.Save(user);
            return this.Content("success");
        }
    }
}
