using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoga.Entity
{
    public class ClassInfo
    {
        public int ClassInfoId { get; set; }

        [StringLength(100)]
        public string ClassName { get; set; }

        [StringLength(50)]
        public string StatusId { get; set; }

        public double TrainerPrice { get; set; }

        public double Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime? PaymentDate { get; set; }

        public int NumDaysOfWeek { get; set; }

        public int CustomerId { get; set; }

        public Status Status { get; set; }

        public Customer Customer { get; set; }
    }
}
