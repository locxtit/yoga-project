using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoga.Entity;
using Yoga.Entity.Enums;

namespace Yoga.Bussiness
{
    public class EventBll
    {
        private YogaContext _context = new YogaContext();

        public List<Event> GetAll()
        {
            return _context.Events.Where(x => x.StatusId != StatusEnum.DELETED.ToString()).ToList();
        }

        public List<Event> GetByEventType(string eventTypeId)
        {
            return _context.Events.Where(x => x.StatusId != StatusEnum.DELETED.ToString() && x.EventTypeId == eventTypeId).ToList();
        }

        public Event GetById(int eventId)
        {
            var events = _context.Events.SingleOrDefault(x => x.EventId == eventId);
            return events;
        }

        public bool Delete(int eventId)
        {
            try
            {
                Event entity = _context.Events.SingleOrDefault(x => x.EventId == eventId);
                if (entity != null)
                {
                    entity.StatusId = StatusEnum.DELETED.ToString();
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public bool SaveOrUpdate(Event events)
        {
            try
            {
                Event entity = _context.Events.SingleOrDefault(x => x.EventId == events.EventId);
                if (entity == null)
                {
                    events.CreatedDate = DateTime.Now;
                    _context.Events.Add(events);
                    
                }
                else
                {
                    entity.StartDate = events.StartDate;
                    entity.Title = events.Title;
                    entity.Description = events.Description;
                    entity.ContentDetail = events.ContentDetail;
                    entity.StatusId = events.StatusId;
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }
    }
}
