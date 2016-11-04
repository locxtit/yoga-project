using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoga.Bussiness;
using Yoga.Entity.Models;
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
                var customers = customerBll.Search(criteria).OrderBy(x => x.CreatedDate).Select(x => new CustomerViewModel
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
                return Json(customers, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
