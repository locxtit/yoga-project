using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoga.Entity
{
    //test
    public class Bank
    {
        [StringLength(50)]
        public string BankId { get; set; }

        [StringLength(100)]
        public string BankName { get; set; }
    }
}
