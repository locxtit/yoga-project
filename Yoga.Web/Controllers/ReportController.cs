using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoga.Bussiness;
using Yoga.Entity;
using Yoga.Web.Infrastructure.Extensions;
using Yoga.Web.Models;

namespace Yoga.Web.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/

        [Authorized]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetImportList(string fromDate, string toDate)
        {
            if (string.IsNullOrEmpty(fromDate) || string.IsNullOrEmpty(toDate))
            {
                return Json(new List<ReportImportModel>(), JsonRequestBehavior.AllowGet);
            }
            var results = new OrderBll().GetList(DateTime.ParseExact(fromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact(toDate, "dd/MM/yyyy", CultureInfo.InvariantCulture));
            var model = results.Select(x => new ReportImportModel
            {
                OrderId = x.OrderId,
                OrderCode = x.OrderCode,
                OperatorId = x.OperatorId,
                OrderStatusId = x.OrderStatusId,
                PaymentDate = x.PaymentDate,
                Price = x.Price,
                PriceForTrainer = x.PriceForTrainer,
                TotalPaid = x.TotalPaid,
                TotalPaidForTrainer = x.TotalPaidForTrainer,
                ClassInfoId = x.ClassInfoId,
                ContactAddress = x.ContactAddress,
                ContactEmail = x.ContactEmail,
                ContactName = x.ContactName,
                CustomerPhone = x.CustomerPhone,
                Note = x.Note,
                NumOfDays = x.NumOfDays,
                CreatedDate = x.CreatedDate,
                OperatorName = x.Operator.OperatorName,
                ClassInfoName = x.ClassInfo.ClassName,
                OrderStatusName = x.OrderStatus.OrderStatusName,
                CustomerName = x.ClassInfo.Customer.Name
            });

            Session["ImportListTotal"] = model.Sum(x => x.Total);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTotalImportList()
        {
            var total = 0.0;
            if (Session["ImportListTotal"] != null)
            {
                total = (double)Session["ImportListTotal"];
            }
            return Json(total, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetExportList(string fromDate, string toDate)
        {
            if (string.IsNullOrEmpty(fromDate) || string.IsNullOrEmpty(toDate))
            {
                return Json(new List<ReportImportModel>(), JsonRequestBehavior.AllowGet);
            }
            var results = new OrderInternalBll().GetList(DateTime.ParseExact(fromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture), DateTime.ParseExact(toDate, "dd/MM/yyyy", CultureInfo.InvariantCulture));

            Session["ExportListTotal"] = results.Sum(x => x.Total);
            return Json(results, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTotalExportList()
        {
            var total = 0.0;
            if (Session["ExportListTotal"] != null)
            {
                total = (double)Session["ExportListTotal"];
            }
            return Json(total, JsonRequestBehavior.AllowGet);
        }
    }
}
