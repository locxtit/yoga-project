using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoga.Entity
{
    public class OrderInternal
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderInternalId { get; set; }

        public int OperatorId { get; set; }

        public double Total { get; set; }

        [StringLength(1000)]
        [Required]
        public string Content { get; set; }

        [StringLength(200)]
        [Required]
        public string Payer { get; set; }

        [StringLength(1000)]
        public string Note { get; set; }

        public virtual Operator Operator { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
