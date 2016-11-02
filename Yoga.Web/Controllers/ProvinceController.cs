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
    public class ProvinceController : Controller
    {
        //
        // GET: /Province/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList()
        {
            try
            {
                var provinceBll = new ProvinceBll();
                var myList = provinceBll.GetAll();
                return Json(myList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Edit(int provinceId)
        {
            var province = new ProvinceBll().GetById(provinceId);
            return PartialView("_EditProvince", province);
        }

        public ActionResult Update(Province model)
        {
            var errorMessage = new ErrorMessage()
            {
                Result = false,
                ErrorString = "Cập nhật thất bại"
            };
            if (ModelState.IsValid)
            {
                errorMessage.Result = new ProvinceBll().SaveOrUpdate(model);
                if (errorMessage.Result)
                {
                    errorMessage.ErrorString = "Cập nhật thành công";
                }
            }
            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

    }
}
