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
    public class OrderServiceBll
    {
        private YogaContext _context = new YogaContext();

        public List<OrderService> GetAll()
        {
            return _context.OrderServices.ToList();
        }

        public IEnumerable<OrderService> Search(SearchOrderServiceCriteriaModel criteria)
        {
            var query = _context.OrderServices.AsEnumerable();
            if (criteria.CustomerId.HasValue)
            {
                query = query.Where(x => x.CustomerId == criteria.CustomerId.Value);
            }
            if (criteria.ServiceId.HasValue)
            {
                query = query.Where(x => x.ServiceId == criteria.ServiceId.Value);
            }
            return query;
        }

        public OrderService GetById(int orderServiceId)
        {
            var orderService = _context.OrderServices.SingleOrDefault(x => x.OrderServiceId == orderServiceId);
            return orderService;
        }

        public bool Delete(int orderServiceId)
        {
            try
            {
                OrderService entity = _context.OrderServices.SingleOrDefault(x => x.OrderServiceId == orderServiceId);
                if (entity != null)
                {
                    _context.OrderServices.Remove(entity);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public bool SaveOrUpdate(OrderService orderService)
        {
            try
            {
                var entity = _context.OrderServices.SingleOrDefault(x => x.OrderServiceId == orderService.OrderServiceId);
                if (entity == null)
                {
                    orderService.CreatedDate = DateTime.Now;
                    _context.OrderServices.Add(orderService);
                    
                }
                else
                {
                    entity.CustomerId = orderService.CustomerId;
                    entity.ServiceId = orderService.ServiceId;
                    entity.Quantity = orderService.Quantity;
                    entity.Price = orderService.Price;
                    entity.Total = orderService.Price * orderService.Quantity;
                    entity.Note = orderService.Note;
                    entity.PaymentStatusId = orderService.PaymentStatusId;
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
