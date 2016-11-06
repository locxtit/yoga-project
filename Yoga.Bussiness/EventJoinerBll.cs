using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoga.Entity;
using Yoga.Entity.Enums;

namespace Yoga.Bussiness
{
    public class EventJoinerBll
    {
        private YogaContext _context = new YogaContext();

        public List<EventJoiner> GetAll()
        {
            return _context.EventJoiners.Where(x => x.StatusId != StatusEnum.DELETED.ToString()).ToList();
        }

        public List<EventJoiner> GetByEventId(int eventId)
        {
            return _context.EventJoiners.Where(x => x.StatusId != StatusEnum.DELETED.ToString() && x.EventId == eventId).ToList();
        }

        public EventJoiner GetById(int eventJoinerId)
        {
            var eventJoiner = _context.EventJoiners.SingleOrDefault(x => x.EventJoinerId == eventJoinerId);
            return eventJoiner;
        }

        public bool Delete(int eventJoinerId)
        {
            try
            {
                EventJoiner entity = _context.EventJoiners.SingleOrDefault(x => x.EventJoinerId == eventJoinerId);
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
