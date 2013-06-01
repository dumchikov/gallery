using Shop.Core.Ninject;

namespace Shop.Web.App_Start
{
    public static class NinjectConfig
    {
        public static void Init()
        {
            new NinjectConfigurator().Register();
        }
    }
}