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
    public class NotifyController : BaseController
    {
        //
        // GET: /Notify/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList(int? operatorAddId, int? operatorRecieptId, string statusId)
        {
            try
            {
                var criteria = new SearchNotifyCriteriaModel()
                {
                    OperatorAddId = operatorAddId,
                    OperatorRecieptId = operatorRecieptId,
                    StatusId = statusId
                };
                var notifyBll = new NotifyBll();
                var notifys = notifyBll.Search(criteria).OrderByDescending(x => x.CreatedDate);

                return Json(notifys, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Edit(int? notifyId)
        {
            var notify = new Notify();
            notify.StartDate = DateTime.Now;
            if (notifyId.HasValue)
                notify = new NotifyBll().GetById(notifyId.Value);
            return PartialView("_EditNotify", notify);
        }

        public ActionResult Update(Notify model)
        {
            var errorMessage = new ErrorMessage()
            {
                Result = false,
                ErrorString = "Cập nhật thất bại"
            };

            if (CurrentOperator == null)
            {
                errorMessage.ErrorString = "Vui lòng đăng nhập";
            }
            else
            {

                if (ModelState.IsValid)
                {
                    model.OperatorAddId = CurrentOperator.OperatorId;
                    errorMessage.Result = new NotifyBll().SaveOrUpdate(model);
                    if (errorMessage.Result)
                    {
                        errorMessage.ErrorString = "Cập nhật thành công";
                    }
                }
                else
                    errorMessage.ErrorString = Util.GetModelStateErrors(ModelState);
            }
            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int NotifyId)
        {
            var response = new ErrorMessage()
            {
                Result = false,
            };
            var NotifyBll = new NotifyBll();
            var Notify = NotifyBll.GetById(NotifyId);
            if (Notify == null)
            {
                response.ErrorString = "Không tồn tại Thông tin sử dụng dịch vụ";
            }
            else
            {
                response.Result = NotifyBll.Delete(NotifyId);
                if (!response.Result)
                    response.ErrorString = "Xóa thất bại";

            }
            return Json(response, JsonRequestBehavior.AllowGet);

        }

    }
}
