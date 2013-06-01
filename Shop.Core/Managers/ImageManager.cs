using System;
using System.IO;
using System.Web;
using Shop.Domain.Interfaces.Services;
using File = Shop.Domain.Interfaces.Services.File;

namespace Shop.Core.Managers
{
    public class ImageManager : IImageManager
    {
        private readonly string _storage = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "storage", "images");

        public string Save(HttpPostedFileBase image)
        {
            try
            {
                var ext = Path.GetExtension(image.FileName);
                var name = Guid.NewGuid().ToString().Substring(0, 8);
                var fullName = string.Concat(name, ext);

                var path = Path.Combine(_storage, fullName);
                image.SaveAs(path);
                return fullName;
            }
            catch
            {
                return null;
            }
        }

        public File Get(string uniqueName)
        {
            var path = Path.Combine(_storage, uniqueName);
            try
            {
                byte[] bytes = System.IO.File.ReadAllBytes(path);

                return new File
                {
                    Bytes = bytes,
                    Extension = uniqueName.Split('.')[1]
                };
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}