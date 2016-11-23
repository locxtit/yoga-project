using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yoga.Web.Models
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CustomerTypeName { get; set; }
        public string CustomerStatusName { get; set; }
        public string StatusName { get; set; }
        public string Note { get; set; }

        public string ClassInfoNames { get; set; }
    }
}