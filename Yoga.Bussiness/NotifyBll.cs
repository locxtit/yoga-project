using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoga.Entity;
using Yoga.Entity.Enums;
using Yoga.Entity.Models;

namespace Yoga.Bussiness
{
    public class NotifyBll
    {
        private YogaContext _context = new YogaContext();

        public IEnumerable<Notify> GetForNotification(int operatorId)
        {
            var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            var toDate = date.AddDays(1);
            var query = _context.Notifies.Where(x =>
                x.StatusId == StatusEnum.ACTIVE.ToString()
                && (x.OperatorRecieptId == null || x.OperatorRecieptId == operatorId)
                && x.StartDate >= date
                && x.StartDate < toDate
                );
            return query;
        }

        public List<Notify> GetAll()
        {
            return _context.Notifies.ToList();
        }

        public IEnumerable<Notify> Search(SearchNotifyCriteriaModel criteria)
        {
            var query = _context.Notifies.AsEnumerable();
            if (criteria.OperatorAddId.HasValue)
            {
                query = query.Where(x => x.OperatorAddId == criteria.OperatorAddId.Value);
            }

            if (criteria.OperatorRecieptId.HasValue)
            {
                query = query.Where(x => x.OperatorRecieptId == criteria.OperatorRecieptId.Value);
            }

            if (!string.IsNullOrEmpty(criteria.StatusId))
            {
                query = query.Where(x => x.StatusId == criteria.StatusId);
            }
            
            return query;
        }

        public Notify GetById(int notifyId)
        {
            var notify = _context.Notifies.SingleOrDefault(x => x.NotifyId == notifyId);
            return notify;
        }

        public bool Delete(int notifyId)
        {
            try
            {
                Notify entity = _context.Notifies.SingleOrDefault(x => x.NotifyId == notifyId);
                if (entity != null)
                {
                    _context.Notifies.Remove(entity);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public bool SaveOrUpdate(Notify notify)
        {
            try
            {
                var entity = _context.Notifies.SingleOrDefault(x => x.NotifyId == notify.NotifyId);
                if (entity == null)
                {
                    notify.CreatedDate = DateTime.Now;
                    _context.Notifies.Add(notify);
                    
                }
                else
                {
                    entity.OperatorRecieptId = notify.OperatorRecieptId;
                    entity.Description = notify.Description;
                    entity.Content = notify.Content;
                    entity.StartDate = notify.StartDate;
                    entity.StatusId = notify.StatusId;
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
