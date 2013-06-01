using System.Web.Mvc;
using CommonServiceLocator.NinjectAdapter.Unofficial;
using Marker.NHibernate;
using Microsoft.Practices.ServiceLocation;
using NHibernate;
using Ninject;
using Ninject.Web.Common;
using Shop.Core.Managers;
using Shop.Core.NHibernate;
using Shop.Domain.Interfaces.DAL;
using Ninject.Extensions.Conventions;
using Shop.Domain.Interfaces.Services;
using Shop.Domain.Interfaces.Services.Authorization;
using Shop.Services;
using Shop.Services.Authorization;

namespace Shop.Core.Ninject
{
    public class NinjectConfigurator
    {
        private readonly IKernel _ninjectKernel;

        public NinjectConfigurator()
        {
            _ninjectKernel = new StandardKernel();
        }

        public void Register()
        {
            _ninjectKernel.Bind<ISessionFactory>().ToProvider<NHibernateProvider>().InSingletonScope();
            _ninjectKernel.Bind<ISession>().ToMethod(x => x.Kernel.Get<ISessionFactory>()
                .OpenSession())
                .InRequestScope();

            _ninjectKernel.Bind(typeof(IRepository<>)).To(typeof(NhibernateRepository<>));
            this.RegisterServices();
            
            DependencyResolver.SetResolver(new NinjectDependencyResolver(_ninjectKernel));
            this.SetServiceLocator();
            
        }

        private void SetServiceLocator()
        {
            var locator = new NinjectServiceLocator(_ninjectKernel);
            ServiceLocator.SetLocatorProvider(() => locator);
        }

        private void RegisterServices()
        {
            _ninjectKernel.Bind(scan => scan.FromAssemblyContaining<UserService>());
            _ninjectKernel.Bind(typeof(IAuthorizationProvider)).To(typeof(AuthorizationProvider));
            _ninjectKernel.Bind(typeof(IImageManager)).To(typeof(ImageManager));
            _ninjectKernel.Bind(typeof (ITransactionManager)).To(typeof (TransactionManager));
        }
    }
}