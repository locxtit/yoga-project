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

        [Index("IX_TrainerIdAndEventId", 1, IsUnique = true)]
        public int TrainerId { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(1000)]
        public string Note { get; set; }

        [StringLength(1000)]
        public string Opinion { get; set; }

        [Index("IX_TrainerIdAndEventId", 2, IsUnique = true)]
        public int EventId { get; set; }

        [StringLength(50)]
        public string StatusId { get; set; }

        public virtual Event Event { get; set; }

        public virtual Status Status { get; set; }

        public virtual Trainer Trainer { get; set; }
    }
}
