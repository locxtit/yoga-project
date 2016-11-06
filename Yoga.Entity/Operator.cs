using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoga.Entity
{
    public class Operator
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OperatorId { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Vui lòng nhập thông tin Mật khẩu")]
        public string Password { get; set; }

        [StringLength(200)]
        public string OperatorName { get; set; }

        [StringLength(200)]
        [Required(ErrorMessage = "Vui lòng nhập thông tin Email")]
        [DataType(DataType.EmailAddress)]
        [Index("IX_Email", 2, IsUnique = true)]
        public string Email { get; set; }

        [StringLength(12)]
        [Required(ErrorMessage = "Vui lòng nhập thông tin số điên thoại")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\d{10})$|^(\d{11})$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string Phone { get; set; }

        [StringLength(50)]
        public string OperatorTypeId { get; set; }

        [StringLength(50)]
        public string StatusId { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual OperatorType OperatorType { get; set; }

        public virtual Status Status { get; set; }
    }
}
