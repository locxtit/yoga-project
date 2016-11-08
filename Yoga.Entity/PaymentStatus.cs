using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoga.Entity
{
    public class PaymentStatus
    {
        [StringLength(50)]
        public string PaymentStatusId { get; set; }

        [StringLength(100)]
        public string PaymentStatusName { get; set; }
    }
}
