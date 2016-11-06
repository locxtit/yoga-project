using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoga.Entity;

namespace Yoga.Bussiness
{
    public class EventTypeBll
    {
        YogaContext _context = new YogaContext();

        public EventType GetById(string eventTypeId)
        {
            return _context.EventTypes.SingleOrDefault(x => x.EventTypeId == eventTypeId);
        }

        public List<EventType> GetAll()
        {
            return _context.EventTypes.ToList();
        }
    }
}
