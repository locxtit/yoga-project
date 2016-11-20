using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Yoga.Web.Models
{
    public class ClassInfoExportModel
    {
        [DisplayName("Tên lớp")]
        public string ClassName { get; set; }

        [DisplayName("ten khách hàng")]
        public string CustomerName { get; set; }

        [DisplayName("Điện thoại")]
        public string CustomerPhone { get; set; }

        [DisplayName("HLV")]
        public string TrainerName { get; set; }

        [DisplayName("Học phí / buổi")]
        public double Price { get; set; }

        [DisplayName("Ngày bắt đầu")]
        public string StartDate { get; set; }

        [DisplayName("Ngày kết thúc")]
        public string EndDate { get; set; }

        [DisplayName("Tổng số buổi")]
        public int? TotalDays { get; set; }

        [DisplayName("Ghi chú")]
        public string Note { get; set; }

        [DisplayName("Phản hồi")]
        public string Reply { get; set; }
    }
}