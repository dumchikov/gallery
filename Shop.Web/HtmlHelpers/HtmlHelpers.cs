using System.Web.Mvc;

namespace Shop.Web.HtmlHelpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString Image(this HtmlHelper helper, string name, string width = "", string height = "", string alt = "")
        {
            var image = string.Format("<img src=\'/images/{0}\' width=\'{1}\' heigh=\'{2}\' alt=\'{3}\'/>", name, width, height, alt);
            return new MvcHtmlString(image);
        }
    }
}