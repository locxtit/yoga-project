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

        public IEnumerable<EventJoiner> GetByEventId(int eventId)
        {
            return _context.EventJoiners.Where(x => x.StatusId != StatusEnum.DELETED.ToString() && x.EventId == eventId).OrderByDescending(x => x.CreatedDate);
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
                    _context.EventJoiners.Remove(entity);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public bool DeleteByEventId(int eventId)
        {
            try
            {
                var eventJoinerIds = _context.EventJoiners.Where(x => x.EventId == eventId).Select(x=>x.EventJoinerId).ToList();
                return Delete(eventJoinerIds);
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public bool Delete(List<int> eventJoinerIds)
        {
            try
            {
                foreach (var eventJoinerId in eventJoinerIds)
                {

                    EventJoiner entity = _context.EventJoiners.SingleOrDefault(x => x.EventJoinerId == eventJoinerId);
                    if (entity != null)
                    {
                        _context.EventJoiners.Remove(entity);
                    }
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public bool SaveOrUpdate(EventJoiner eventJoiner)
        {
            try
            {
                var entity = _context.EventJoiners.SingleOrDefault(x => x.EventJoinerId == eventJoiner.EventJoinerId);
                if (entity == null)
                {
                    eventJoiner.CreatedDate = DateTime.Now;
                    _context.EventJoiners.Add(eventJoiner);
                    
                }
                else
                {
                    entity.StatusId = eventJoiner.StatusId;
                    entity.Note = eventJoiner.Note;
                    entity.Opinion = eventJoiner.Opinion;
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
