using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoga.Bussiness;
using Yoga.Entity;
using Yoga.Entity.Models;
using Yoga.Web.Infrastructure.Extensions;

namespace Yoga.Web.Controllers
{
    [Authorized]
    public class ProvinceController : BaseController
    {
        //
        // GET: /Province/
        [Authorized]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList()
        {
            try
            {
                var provinceBll = new ProvinceBll();
                var myList = provinceBll.GetAll().OrderBy(x=>x.ProvinceName);
                return Json(myList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Edit(int? provinceId)
        {
            var province = new Province();
            if (provinceId.HasValue)
                province = new ProvinceBll().GetById(provinceId.Value);
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
                    CategoryBll.Provinces = null;
                }
            }
            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int provinceId)
        {
            var response = new ErrorMessage()
            {
                Result = false,
            };
            var provinceBll = new ProvinceBll();
            var province = provinceBll.GetById(provinceId);
            if (province == null)
            {
                response.ErrorString = "Không tồn tại Tỉnh";
            }
            else
            {
                response.Result = provinceBll.Delete(provinceId);
                if (!response.Result)
                    response.ErrorString = "Xóa thất bại";

            }
            return Json(response, JsonRequestBehavior.AllowGet);

        }

    }
}
