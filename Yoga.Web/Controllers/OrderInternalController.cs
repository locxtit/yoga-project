using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoga.Bussiness;
using Yoga.Entity;
using Yoga.Entity.Models;
using Yoga.Web.Helpers;
using Yoga.Web.Infrastructure.Extensions;

namespace Yoga.Web.Controllers
{
    [Authorized]
    public class OrderInternalController : BaseController
    {
        //
        // GET: /OrderInternal/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList(int? operatorId)
        {
            try
            {
                var criteria = new SearchOrderInternalCriteriaModel()
                {
                    OperatorId = operatorId
                };
                var orderInternalBll = new OrderInternalBll();
                var orderInternals = orderInternalBll.Search(criteria).OrderByDescending(x => x.CreatedDate);

                return Json(orderInternals, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Edit(int? orderInternalId)
        {
            var orderInternal = new OrderInternal();
            if (orderInternalId.HasValue)
                orderInternal = new OrderInternalBll().GetById(orderInternalId.Value);
            return PartialView("_EditOrderInternal", orderInternal);
        }

        public ActionResult Update(OrderInternal model)
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
                    model.OperatorId = CurrentOperator.OperatorId;
                    errorMessage.Result = new OrderInternalBll().SaveOrUpdate(model);
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

        public ActionResult Delete(int OrderInternalId)
        {
            var response = new ErrorMessage()
            {
                Result = false,
            };
            var OrderInternalBll = new OrderInternalBll();
            var OrderInternal = OrderInternalBll.GetById(OrderInternalId);
            if (OrderInternal == null)
            {
                response.ErrorString = "Không tồn tại Thông tin sử dụng dịch vụ";
            }
            else
            {
                response.Result = OrderInternalBll.Delete(OrderInternalId);
                if (!response.Result)
                    response.ErrorString = "Xóa thất bại";

            }
            return Json(response, JsonRequestBehavior.AllowGet);

        }

    }
}
