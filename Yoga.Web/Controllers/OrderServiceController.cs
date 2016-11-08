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
    public class OrderServiceController : Controller
    {
        //
        // GET: /OrderService/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList(int? customerId, int? serviceId)
        {
            try
            {
                var criteria = new SearchOrderServiceCriteriaModel()
                {
                    CustomerId = customerId,
                    ServiceId = serviceId
                };
                var orderServiceBll = new OrderServiceBll();
                var orderServices = orderServiceBll.Search(criteria).OrderByDescending(x => x.CreatedDate);

                return Json(orderServices, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Edit(int? orderServiceId)
        {
            var orderService = new OrderService();
            if (orderServiceId.HasValue)
                orderService = new OrderServiceBll().GetById(orderServiceId.Value);
            return PartialView("_EditOrderService", orderService);
        }

        public ActionResult Update(OrderService model)
        {
            var errorMessage = new ErrorMessage()
            {
                Result = false,
                ErrorString = "Cập nhật thất bại"
            };
            if (ModelState.IsValid)
            {
                errorMessage.Result = new OrderServiceBll().SaveOrUpdate(model);
                if (errorMessage.Result)
                {
                    errorMessage.ErrorString = "Cập nhật thành công";
                }
            }
            else
                errorMessage.ErrorString = Util.GetModelStateErrors(ModelState);
            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int orderServiceId)
        {
            var response = new ErrorMessage()
            {
                Result = false,
            };
            var orderServiceBll = new OrderServiceBll();
            var orderService = orderServiceBll.GetById(orderServiceId);
            if (orderService == null)
            {
                response.ErrorString = "Không tồn tại Thông tin sử dụng dịch vụ";
            }
            else
            {
                response.Result = orderServiceBll.Delete(orderServiceId);
                if (!response.Result)
                    response.ErrorString = "Xóa thất bại";

            }
            return Json(response, JsonRequestBehavior.AllowGet);

        }

    }
}
