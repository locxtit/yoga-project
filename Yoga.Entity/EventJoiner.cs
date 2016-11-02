using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoga.Entity
{
    public class EventJoiner
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventJoinerId { get; set; }

        public int TrainerId { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(1000)]
        public string Note { get; set; }

        [StringLength(1000)]
        public string Opinion { get; set; }

        public int EventId { get; set; }

        [StringLength(50)]
        public string StatusId { get; set; }

        public Event Event { get; set; }

        public Status Status { get; set; }

        public Trainer Trainer { get; set; }
    }
}
