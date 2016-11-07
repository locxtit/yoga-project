using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoga.Bussiness;
using Yoga.Entity;
using Yoga.Entity.Models;
using Yoga.Web.Helpers;

namespace Yoga.Web.Controllers
{
    public class ClassInfoController : Controller
    {
        //
        // GET: /ClassInfo/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList(int? trainerId, string customerName)
        {
            try
            {
                SearchClassInfoCriteriaModel criteria = new SearchClassInfoCriteriaModel()
                {
                    TrainerId = trainerId,
                    CustomerName = customerName,
                };
                var classInfoBll = new ClassInfoBll();
                var classInfos = classInfoBll.Search(criteria).OrderByDescending(x => x.CreatedDate);

                return Json(classInfos, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Edit(int? classInfoId)
        {
            var classInfo = new ClassInfo();
            if (classInfoId.HasValue)
                classInfo = new ClassInfoBll().GetById(classInfoId.Value);
            return PartialView("_EditClassInfo", classInfo);
        }

        public ActionResult Update(ClassInfo model)
        {
            var errorMessage = new ErrorMessage()
            {
                Result = false,
                ErrorString = "Cập nhật thất bại"
            };
            if (ModelState.IsValid)
            {
                errorMessage.Result = new ClassInfoBll().SaveOrUpdate(model);
                if (errorMessage.Result)
                {
                    errorMessage.ErrorString = "Cập nhật thành công";
                }
            }
            else
                errorMessage.ErrorString = Util.GetModelStateErrors(ModelState);
            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int classInfoId)
        {
            var response = new ErrorMessage()
            {
                Result = false,
            };
            var classInfoBll = new ClassInfoBll();
            var classInfo = classInfoBll.GetById(classInfoId);
            if (classInfo == null)
            {
                response.ErrorString = "Không tồn tại Lớp";
            }
            else
            {
                response.Result = classInfoBll.Delete(classInfoId);
                if (!response.Result)
                    response.ErrorString = "Xóa thất bại";

            }
            return Json(response, JsonRequestBehavior.AllowGet);

        }

    }
}
