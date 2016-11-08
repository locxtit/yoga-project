using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoga.Entity
{
    public class Service
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceId { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Vui lòng nhập thông tin Dịch vụ")]
        public string ServiceName { get; set; }

        public double Price { get; set; }

        [StringLength(50)]
        public string StatusId { get; set; }

        public virtual Status Status { get; set; }
    }
}
