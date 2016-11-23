using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoga.Entity
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(12)]
        [Required(ErrorMessage = "Vui lòng nhập thông tin số điên thoại")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\d{10})$|^(\d{11})$", ErrorMessage = "Số điện thoại không hợp lệ")]
        public string Phone { get; set; }

        [StringLength(12)]
        public string SecondaryPhone { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerTypeId { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerStatusId { get; set; }

        [StringLength(4000)]
        public string Note { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string StatusId { get; set; }

        [Required]
        public int ProvinceId { get; set; }

        public virtual Province Province { get; set; }

        public virtual CustomerStatus CustomerStatus { get; set; }

        public virtual CustomerType CustomerType { get; set; }

        public virtual Status Status { get; set; }

        public virtual ICollection<ClassInfo> ClassInfos { get; set; }

        
    }
}
