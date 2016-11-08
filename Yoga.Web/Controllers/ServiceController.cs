using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoga.Bussiness;
using Yoga.Entity;
using Yoga.Entity.Models;

namespace Yoga.Web.Controllers
{
    public class ServiceController : Controller
    {
        //
        // GET: /Service/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList()
        {
            try
            {
                var serviceBll = new ServiceBll();
                var myList = serviceBll.GetAll().OrderBy(x => x.ServiceName);
                return Json(myList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Edit(int? serviceId)
        {
            var service = new Service();
            if (serviceId.HasValue)
                service = new ServiceBll().GetById(serviceId.Value);
            return PartialView("_EditService", service);
        }

        public ActionResult Update(Service model)
        {
            var errorMessage = new ErrorMessage()
            {
                Result = false,
                ErrorString = "Cập nhật thất bại"
            };
            if (ModelState.IsValid)
            {
                errorMessage.Result = new ServiceBll().SaveOrUpdate(model);
                if (errorMessage.Result)
                {
                    errorMessage.ErrorString = "Cập nhật thành công";
                    CategoryBll.Services = null;
                }
            }

            

            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int serviceId)
        {
            var response = new ErrorMessage()
            {
                Result = false,
            };
            var serviceBll = new ServiceBll();
            var service = serviceBll.GetById(serviceId);
            if (service == null)
            {
                response.ErrorString = "Không tồn tại Dịch vụ";
            }
            else
            {
                response.Result = serviceBll.Delete(serviceId);
                if (!response.Result)
                    response.ErrorString = "Xóa thất bại";

            }
            return Json(response, JsonRequestBehavior.AllowGet);

        }

    }
}
