using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Yoga.Web.Models
{
    public class CustomerExportModel
    {
        [DisplayName("Tên Khách hàng")]
        public string Name { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Điện thoại")]
        public string Phone { get; set; }

        [DisplayName("Địa chỉ")]
        public string Address { get; set; }

        [DisplayName("Tỉnh")]
        public string ProvinceName { get; set; }

        [DisplayName("Đối tượng")]
        public string CustomerTypeName { get; set; }

        [DisplayName("Danh mục")]
        public string CustomerStatusName { get; set; }

        [DisplayName("Trạng thái")]
        public string StatusName { get; set; }

        [DisplayName("Ghi chú")]
        public string Note { get; set; }
    }
}