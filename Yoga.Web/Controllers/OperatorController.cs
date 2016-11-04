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
    public class OperatorController : Controller
    {
        //
        // GET: /Operator/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList()
        {
            try
            {
                var operatorBll = new OperatorBll();
                var myList = operatorBll.GetAll().OrderBy(x => x.Username);
                return Json(myList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Edit(int? operatorId)
        {
            var oper = new Operator();
            if (operatorId.HasValue)
                oper = new OperatorBll().GetById(operatorId.Value);
            return PartialView("_EditOperator", oper);
        }

        public ActionResult Update(Operator model)
        {
            var errorMessage = new ErrorMessage()
            {
                Result = false,
                ErrorString = "Cập nhật thất bại"
            };
            if (ModelState.IsValid)
            {
                errorMessage.Result = new OperatorBll().SaveOrUpdate(model);
                if (errorMessage.Result)
                {
                    errorMessage.ErrorString = "Cập nhật thành công";
                }
            }
            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int operatorId)
        {
            var response = new ErrorMessage()
            {
                Result = false,
            };
            var operatorBll = new OperatorBll();
            var oper = operatorBll.GetById(operatorId);
            if (oper == null)
            {
                response.ErrorString = "Không tồn tại Người dùng";
            }
            else
            {
                response.Result = operatorBll.Delete(operatorId);
                if (!response.Result)
                    response.ErrorString = "Xóa thất bại";

            }
            return Json(response, JsonRequestBehavior.AllowGet);

        }

    }
}
