using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoga.Entity.Models
{
    public class EventViewModel
    {
        public int EventId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ContentDetail { get; set; }

        public string EventTypeId { get; set; }

        public string StatusId { get; set; }

        public string OrganizerName { get; set; }

        public string OrganizerPhone { get; set; }

        public string OrganizerEmail { get; set; }

        public string OrganizerAddress { get; set; }

        public int OperatorId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? StartDate { get; set; }

        public virtual Status Status { get; set; }

        public virtual EventType EventType { get; set; }

        public virtual Operator Operator { get; set; }

        public string TrainerNames { get; set; }

        public int? CountMember { get; set; }
    }
}
