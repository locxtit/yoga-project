using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Yoga.Web.Models
{
    public class ImportExportModel
    {
        [DisplayName("Tên HV")]
        public string CustomerName { get; set; }

        [DisplayName("Phí/Buổi")]
        public string Price { get; set; }

        [DisplayName("Số buổi")]
        public int NumOfDays { get; set; }

        [DisplayName("Phí HLV/Buổi")]
        public string PriceForTrainer { get; set; }

        [DisplayName("Tổng thu")]
        public string TotalPaid { get; set; }

        [DisplayName("Tổng chi")]
        public string TotalPaidForTrainer { get; set; }

        [DisplayName("Số tiền còn")]
        public string Total
        {
            get;
            set;
        }

        [DisplayName("Ngày tạo")]
        public string CreatedDate { get; set; }

        [DisplayName("Ngày thanh toán HLV")]
        public string PaymentDate { get; set; }

    }
}