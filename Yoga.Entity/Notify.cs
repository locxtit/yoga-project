using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoga.Entity
{
    public class Notify
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int NotifyId { get; set; }

        [StringLength(200)]
        [Required]
        public string Description { get; set; }

        [StringLength(4000)]
        [Required]
        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [StringLength(50)]
        public string StatusId { get; set; }

        public int OperatorAddId { get; set; }

        public int? OperatorRecieptId { get; set; }

        [ForeignKey("OperatorAddId")]
        public virtual Operator OperatorAdd { get; set; }

        [ForeignKey("OperatorRecieptId")]
        public virtual Operator OperatorReciept { get; set; }

        public virtual Status Status {get;set;}
    }
}
