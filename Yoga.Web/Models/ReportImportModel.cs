using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yoga.Web.Models
{
    public class ReportImportModel
    {
        public int OrderId { get; set; }

        public string OrderCode { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? PaymentDate { get; set; }

        public int OperatorId { get; set; }

        public string ContactName { get; set; }

        public string ContactEmail { get; set; }

        public string CustomerPhone { get; set; }

        public string ContactAddress { get; set; }

        public int NumOfDays { get; set; }

        public double Price { get; set; }

        public double PriceForTrainer { get; set; }

        public double TotalPaid { get; set; }

        public double TotalPaidForTrainer { get; set; }

        public string OrderStatusId { get; set; }

        public int ClassInfoId { get; set; }

        public string Note { get; set; }

        public string OperatorName { get; set; }

        public string ClassInfoName { get; set; }

        public string OrderStatusName { get; set; }

        public string CustomerName { get; set; }

        public double Total
        {
            get
            {
                return TotalPaid - TotalPaidForTrainer;
            }
        }
    }
}