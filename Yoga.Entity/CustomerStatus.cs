using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoga.Entity
{
    public class CustomerStatus
    {
        [StringLength(100)]
        public string CustomerStatusId { get; set; }

        [StringLength(100)]
        public string CustomerStatusName { get; set; }
    }
}
