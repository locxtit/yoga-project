using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoga.Entity
{
    public class OrderStatus
    {
        [StringLength(50)]
        public string OrderStatusId { get; set; }

        [StringLength(100)]
        public string OrderStatusName { get; set; }
    }
}
