using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoga.Entity
{
    public class EventType
    {

        [StringLength(50)]
        public string EventTypeId { get; set; }

        [StringLength(100)]
        public string EventTypeName { get; set; }
    }
}
