using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yoga.Entity.Models
{
    public class SearchCustomerCriteriaModel
    {
        public string CustomerName { get; set; }

        public string Phone { get; set; }

        public string CustomerTypeId { get; set; }

        public string CustomerStatusId { get; set; }
    }
}