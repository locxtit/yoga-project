using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Yoga.Web.Models
{
    public class ExportExportModel
    {
        [DisplayName("Nội dụng")]
        public string Content { get; set; }

        [DisplayName("Tổng tiền")]
        public string Total { get; set; }

        [DisplayName("Ngày tạo")]
        public string CreatedDate { get; set; }

        [DisplayName("Người chi")]
        public string Payer { get; set; }

        [DisplayName("Ghi chú")]
        public string Note { get; set; }
    }
}