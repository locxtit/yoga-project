using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoga.Entity
{
    public class OrderService
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderServiceId { get; set; }

        public int CustomerId { get; set; }

        public int ServiceId { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public double Total { get; set; }

        [StringLength(50)]
        public string PaymentStatusId { get; set; }

        [StringLength(200)]
        public string Note { get; set; }

        public virtual PaymentStatus PaymentStatus { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual DateTime CreatedDate { get; set; }
    }
}
