using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoga.Bussiness;
using Yoga.Web.Common;

namespace Yoga.Web.Controllers
{
    public class PopularController : Controller
    {
        //
        // GET: /Popular/

        public ActionResult GetServiceById(int serviceId)
        {
            var service = CategoryBll.Services.Where(x => x.ServiceId == serviceId).FirstOrDefault();
            return Json(service, JsonRequestBehavior.AllowGet);
        }

    }
}
