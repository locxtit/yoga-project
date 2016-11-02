using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoga.Entity
{
    public class CustomerType
    {
        [StringLength(100)]
        public string CustomerTypeId { get; set; }

        [StringLength(100)]
        public string CustomerTypeName { get; set; }
    }
}
