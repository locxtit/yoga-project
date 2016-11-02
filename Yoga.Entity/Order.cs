using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoga.Entity
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [StringLength(10)]
        public string OrderCode { get; set; }

        public DateTime CreatedDate { get; set; }

        public int OperatorId { get; set; }

        [StringLength(100)]
        public string ContactEmail { get; set; }

        [StringLength(12)]
        public string CustomerPhone { get; set; }

        [StringLength(200)]
        public string ContactAddress { get; set; }

        public double TotalPaid { get; set; }

        [StringLength(50)]
        public string OrderStatusId { get; set; }

        public int ClassInfoId { get; set; }

        [StringLength(200)]
        public string Note { get; set; }

        public ClassInfo ClassInfo { get; set; }

        public Operator Operator { get; set; }

        public OrderStatus OrderStatus { get; set; }
    }
}
