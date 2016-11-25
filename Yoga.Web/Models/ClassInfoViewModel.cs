using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yoga.Entity;

namespace Yoga.Web.Models
{
    public class ClassInfoViewModel
    {
        public int ClassInfoId { get; set; }

        public string ClassName { get; set; }

        public string StatusId { get; set; }

        public string StatusName { get; set; }

        public double TrainerPrice { get; set; }

        public double Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? TotalDays { get; set; }

        public int NumOfPaidDays { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }

        public string TrainerName { get; set; }

        public bool CompletedPayment { get; set; }
    }
}