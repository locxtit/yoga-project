using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoga.Entity
{
    public class Operator
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OperatorId { get; set; }

        [StringLength(100)]
        public string Username { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        [StringLength(200)]
        public string OperatorName { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(12)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string OperatorTypeId { get; set; }

        [StringLength(50)]
        public string StatusId { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual OperatorType OperatorType { get; set; }

        public virtual Status Status { get; set; }
    }
}
