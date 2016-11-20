using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yoga.Entity;

namespace Yoga.Web.Models
{
    public class TrainerViewModel
    {
        public int TrainerId { get; set; }

        
        public string TrainerName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Experience { get; set; }

        public string Subject { get; set; }

        public string StatusId { get; set; }

        public string Note { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual Status Status { get; set; }
    }
}