using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoga.Entity
{
    public class Event
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }

        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(400)]
        public string Description { get; set; }

        [StringLength(4000)]
        public string ContentDetail { get; set; }

        [StringLength(50)]
        public string EventTypeId { get; set; }

        [StringLength(50)]
        public string StatusId { get; set; }

        [StringLength(200)]
        public string OrganizerName { get; set; }

        [StringLength(12)]
        public string OrganizerPhone { get; set; }

        [StringLength(100)]
        public string OrganizerEmail { get; set; }

        [StringLength(200)]
        public string OrganizerAddress { get; set; }

        public int OperatorId { get; set; }

        public int? CountMember { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? StartDate { get; set; }

        public virtual Status Status { get; set; }

        public virtual EventType EventType { get; set; }

        public virtual Operator Operator { get; set; }

        public virtual ICollection<EventJoiner> EventJoiners { get; set; }

        [NotMapped]
        public string TrainerNames
        {
            get
            {
                if (EventJoiners == null) return null;
                var lst = EventJoiners.Select(x => x.Trainer.TrainerName);
                var value = string.Join(", ", lst);
                return value;
            }
        }
    }
}
