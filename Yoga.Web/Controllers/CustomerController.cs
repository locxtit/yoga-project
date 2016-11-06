using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoga.Bussiness;
using Yoga.Entity;
using Yoga.Entity.Models;
using Yoga.Web.Helpers;
using Yoga.Web.Models;

namespace Yoga.Web.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList(string customerName, string phone, string customerTypeId, string customerStatusId)
        {
            try
            {
                SearchCustomerCriteriaModel criteria = new SearchCustomerCriteriaModel()
                {
                    CustomerTypeId = customerTypeId,
                    CustomerStatusId = customerStatusId,
                    CustomerName = customerName,
                    Phone = phone
                };
                var customerBll = new CustomerBll();
                var customers = customerBll.Search(criteria).OrderByDescending(x => x.CreatedDate);
                var response = customers.Select(x => new CustomerViewModel
                {
                    CustomerId = x.CustomerId,
                    Email = x.Email,
                    Phone = x.Phone,
                    CustomerStatusName = x.CustomerStatus.CustomerStatusName,
                    CustomerTypeName = x.CustomerType.CustomerTypeName,
                    StatusName = x.Status.StatusName,
                    Name = x.Name,
                    Note = x.Note
                })
                .ToList();
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Edit(int? customerId)
        {
            var customer = new Customer();
            if (customerId.HasValue)
                customer = new CustomerBll().GetById(customerId.Value);
            return PartialView("_EditCustomer", customer);
        }

        public ActionResult Update(Customer model)
        {
            var errorMessage = new ErrorMessage()
            {
                Result = false,
                ErrorString = "Cập nhật thất bại"
            };
            if (ModelState.IsValid)
            {
                errorMessage.Result = new CustomerBll().SaveOrUpdate(model);
                if (errorMessage.Result)
                {
                    errorMessage.ErrorString = "Cập nhật thành công";
                }
            }
            else
                errorMessage.ErrorString = Util.GetModelStateErrors(ModelState);
            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int customerId)
        {
            var response = new ErrorMessage()
            {
                Result = false,
            };
            var customerBll = new CustomerBll();
            var customer = customerBll.GetById(customerId);
            if (customer == null)
            {
                response.ErrorString = "Không tồn tại Khách hàng";
            }
            else
            {
                response.Result = customerBll.Delete(customerId);
                if (!response.Result)
                    response.ErrorString = "Xóa thất bại";

            }
            return Json(response, JsonRequestBehavior.AllowGet);

        }

    }
}
