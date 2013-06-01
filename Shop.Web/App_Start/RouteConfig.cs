using System.Web.Mvc;
using System.Web.Routing;

namespace Shop.Web.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.Add("Images", new Route("images/{*file}", new ImageRouteHandler()));

            routes.MapRoute(
                name: "Main",
                url: "{login}",
                defaults: new { controller = "Photos", action = "Index", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Photos", action = "Index", id = UrlParameter.Optional });
        }
    }
}