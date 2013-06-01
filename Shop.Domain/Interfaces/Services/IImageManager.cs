using System.Web;

namespace Shop.Domain.Interfaces.Services
{
    public class File
    {
        public byte[] Bytes { get; set; }

        public string Extension { get; set; }
    }

    public interface IImageManager
    {
        string Save(HttpPostedFileBase file);

        File Get(string uniqueName);
    }
}