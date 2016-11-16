using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoga.Web.Infrastructure.Extensions;

namespace Yoga.Web.Controllers
{
    [Authorized]
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            if (CurrentOperator == null)
                return RedirectToAction("Login", "Login");
            return View();
        }

    }
}
