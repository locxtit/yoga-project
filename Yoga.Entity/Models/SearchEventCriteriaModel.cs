using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoga.Entity.Models
{
    public class SearchEventCriteriaModel
    {
        public string EventTypeId { get; set; }

        public string OrganizerName { get; set; }

        public string OrganizerPhone { get; set; }

        public string Title { get; set; }

        public int? TrainerId { get; set; }
    }
}
