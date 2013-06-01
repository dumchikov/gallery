using System.Web;
using System.Web.Routing;

public class ImageRouteHandler : IRouteHandler
{
    public IHttpHandler GetHttpHandler(RequestContext requestContext)
    {
        return new ImageHandler();
    }
}