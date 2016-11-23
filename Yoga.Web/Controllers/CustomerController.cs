using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoga.Bussiness;
using Yoga.Entity;
using Yoga.Entity.Enums;
using Yoga.Entity.Models;
using Yoga.Web.Helpers;
using Yoga.Web.Infrastructure.Extensions;
using Yoga.Web.Models;

namespace Yoga.Web.Controllers
{
    
    public class CustomerController : BaseController
    {
        //
        // GET: /Customer/

        [Authorized]
        public ActionResult Index()
        {
            return View();
        }

        private string GetClassInfoName(ICollection<ClassInfo> classInfos)
        {
            if (classInfos != null)
            {
                var result = "";

                var lst = classInfos.Where(x => x.StatusId == StatusEnum.CONSULTANT.ToString() || x.StatusId == StatusEnum.LEARN_TEST.ToString());
                foreach (var item in lst)
                {
                    result += string.Format("{0} ({1})<br/>", item.ClassName, item.Status.StatusName);
                }
                return result;
            }
            return null;
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
                        Note = x.Note,
                        ClassInfoNames = x.ClassInfos.Where(y => y.StatusId == StatusEnum.CONSULTANT.ToString() || y.StatusId == StatusEnum.LEARN_TEST.ToString()).Count().ToString()
                    });
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
                    CategoryBll.Customers = null;
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

        public ActionResult IsExistEmail(string email)
        {
            var response = new ErrorMessage()
            {
                Result = true,
            };
            var customerBll = new CustomerBll();
            var customer = customerBll.GetByEmail(email);
            if (customer != null)
            {
                response.Result = false;
                response.ErrorString = "Email đã rồn tại. Vui lòng nhập email khác.";
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

    }
}
