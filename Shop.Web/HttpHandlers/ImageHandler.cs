using System;
using System.Globalization;
using System.IO;
using System.Web;
using System.Web.Routing;
using ImageResizer;
using Microsoft.Practices.ServiceLocation;
using Shop.Domain.Interfaces.Services;
using File = Shop.Domain.Interfaces.Services.File;

public class ImageHandler : IHttpHandler
{
    private readonly IImageManager _imageManager;

    public ImageHandler()
    {
        _imageManager = ServiceLocator.Current.GetInstance<IImageManager>();
    }

    public void ProcessRequest(HttpContext ctx)
    {
        HttpRequest req = ctx.Request;
        string path = req.Path;
        var fileName = Path.GetFileName(path);
        var file = this._imageManager.Get(fileName);

        if (file == null)
        {
            ctx.Response.StatusDescription = "Image not found";
            ctx.Response.StatusCode = 404;
        }
        else
        {

            string contentType = null;
            switch (file.Extension)
            {
                case "gif":
                    contentType = "image/gif";
                    break;
                case "jpg":
                    contentType = "image/jpeg";
                    break;
                case "png":
                    contentType = "image/png";
                    break;
                default:
                    throw new NotSupportedException("Unrecognized image type.");
            }
            var stream = new MemoryStream(file.Bytes, 0, file.Bytes.Length);
            var destStream = new MemoryStream();
            ImageBuilder.Current.Build(stream, destStream, new ResizeSettings("format=jpg;quality=100;maxwidth=400;s.grayscale=bt709;"));
            var destBytes = destStream.ToArray();
            ctx.Response.StatusCode = 200;
            ctx.Response.ContentType = contentType;
            ctx.Response.OutputStream.Write(destBytes, 0, destBytes.Length);
        }

    }

    public bool IsReusable { get { return true; } }
}