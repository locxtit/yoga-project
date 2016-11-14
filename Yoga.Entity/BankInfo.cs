using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoga.Entity
{
    public class BankInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BankInfoId { get; set; }

        [StringLength(50)]
        [Required]
        public string BankNumber { get; set; }

        [StringLength(200)]
        [Required]
        public string BankBrand { get; set; }

        public bool IsMain { get; set; }

        [StringLength(50)]
        public string StatusId { get; set; }

        public Status Status { get; set; }

        [StringLength(50)]
        [Required]
        public string BankId { get; set; }

        public int TrainerId { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual Bank Bank { get; set; }

        public virtual Trainer Trainer { get; set; }
    }
}
