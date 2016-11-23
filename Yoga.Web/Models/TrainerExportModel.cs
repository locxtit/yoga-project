using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Yoga.Web.Models
{
    public class TrainerExportModel
    {
        [DisplayName("Tên")]
        public string TrainerName { get; set; }

        [DisplayName("Số điện thoại")]
        public string Phone { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Địa chỉ")]
        public string Address { get; set; }

        [DisplayName("Kinh Nghiệm")]
        public string Experience { get; set; }

        [DisplayName("Chuyên môn")]
        public string Subject { get; set; }

        [DisplayName("Ngân hàng")]
        public string BankId { get; set; }

        [DisplayName("Tên tài khoản")]
        public string BankName { get; set; }

        [DisplayName("Số tài khoản")]
        public string BankNumber { get; set; }

        [DisplayName("Chi nhánh")]
        public string BankBrand { get; set; }

        [DisplayName("Trạng thái")]
        public string StatusName { get; set; }

        [DisplayName("Ghi chú")]
        public string Note { get; set; }

    }
}