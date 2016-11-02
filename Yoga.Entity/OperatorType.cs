using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoga.Entity
{
    public class OperatorType
    {
        [StringLength(50)]
        public string OperatorTypeId { get; set; }

        [StringLength(100)]
        public string OperatorTypeName { get; set; }
    }
}
