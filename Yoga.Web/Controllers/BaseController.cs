using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoga.Entity;
using Yoga.Web.Common;

namespace Yoga.Web.Controllers
{
    public class BaseController : Controller
    {
        protected Operator CurrentOperator
        {
            get
            {
                if (Session[SessionConstant.SESSION_OPERATOR] != null)
                {
                    return (Operator)Session[SessionConstant.SESSION_OPERATOR];
                }
                return null;
            }
        }

    }
}
