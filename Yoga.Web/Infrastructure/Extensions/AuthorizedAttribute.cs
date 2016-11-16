using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Yoga.Web.Common;

namespace Yoga.Web.Infrastructure.Extensions
{
    public class AuthorizedAttribute: ActionFilterAttribute
    {        
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var isLogon = HttpContext.Current.Session[SessionConstant.SESSION_OPERATOR] != null;
            var currentPage = HttpContext.Current.Request.RawUrl.ToString();
            if (!isLogon)
            {
                //Forward error Page.
                if (!string.IsNullOrEmpty(currentPage))
                {
                    filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary { { "Controller", "Login" }, { "Action", "Login" }, { "redirectUrl", currentPage } });
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary { { "Controller", "Login" }, { "Action", "Login" } });
                }

            }
        }
    }
}