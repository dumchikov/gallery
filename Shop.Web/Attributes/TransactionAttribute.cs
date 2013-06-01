using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using Shop.Core.NHibernate;

namespace Shop.Web.Attributes
{
    /// <summary>
    /// Sharp architecture attribute
    /// </summary>
    [System.AttributeUsage(System.AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public class TransactionAttribute : ActionFilterAttribute
    {
        private readonly TransactionManager _engine = ServiceLocator.Current.GetInstance<TransactionManager>();

        #region Methods
        /// <summary>
        /// Called by the MVC framework after the action method executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (_engine.IsActive && ((filterContext.Exception != null) && filterContext.ExceptionHandled))
            {
                _engine.Rollback();
            }
        }

        /// <summary>
        /// Called by the MVC framework before the action method executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _engine.Begin();
        }

        /// <summary>
        /// Called by the MVC framework after the action result executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
            //try
            //{
                if (_engine.IsActive)
                {
                    if ((filterContext.Exception != null) && !filterContext.ExceptionHandled)
                    {
                        _engine.Rollback();
                    }
                    else
                    {
                        _engine.Commit();
                    }
                }
            //}
            //finally
            //{
            //    _engine.Dispose();
            //}
        }
        #endregion
    }
}