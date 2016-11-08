using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoga.Entity;
using Yoga.Entity.Enums;

namespace Yoga.Bussiness
{
    public class ServiceBll
    {
        private YogaContext _context = new YogaContext();

        public List<Service> GetAll()
        {
            return _context.Services.Where(x=>x.StatusId != StatusEnum.DELETED.ToString()).ToList();
        }

        public List<Service> GetServiceActive()
        {
            return _context.Services.Where(x => x.StatusId == StatusEnum.ACTIVE.ToString()).ToList();
        }

        public Service GetById(int serviceId)
        {
            var service = _context.Services.SingleOrDefault(x => x.ServiceId == serviceId);
            return service;
        }

        public bool Delete(int serviceId)
        {
            try
            {
                Service entity = _context.Services.SingleOrDefault(x => x.ServiceId == serviceId);
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

        public bool SaveOrUpdate(Service service)
        {
            try
            {
                Service entity = _context.Services.SingleOrDefault(x => x.ServiceId == service.ServiceId);
                if (entity == null)
                {
                    service.StatusId = StatusEnum.ACTIVE.ToString();
                    _context.Services.Add(service);
                    
                }
                else
                {
                    entity.ServiceName = service.ServiceName;
                    entity.StatusId = service.StatusId;
                    entity.Price = service.Price;
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
