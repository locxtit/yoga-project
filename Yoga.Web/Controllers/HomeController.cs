using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoga.Web.Infrastructure.Extensions;

namespace Yoga.Web.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/
        [Authorized]
        public ActionResult Index()
        {
            if (CurrentOperator == null)
                return RedirectToAction("Login", "Login");
            return View();
        }

    }
}
