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
    public class OrderBll
    {
        private YogaContext _context = new YogaContext();

        public List<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public IEnumerable<Order> GetByClassInfoId(int classInfoId)
        {
            return _context.Orders.Where(x => x.ClassInfoId == classInfoId);
        }

        public IEnumerable<Order> GetList(DateTime fromDate, DateTime toDate)
        {
            fromDate = new DateTime(fromDate.Year, fromDate.Month, fromDate.Day, 0, 0, 0);
            toDate = new DateTime(toDate.Year, toDate.Month, toDate.Day, 23, 59, 59);
            return _context.Orders.Where(x => x.OrderStatusId == OrderStatusEnum.PAID.ToString() && x.CreatedDate >= fromDate && x.CreatedDate <= toDate);
        }

        public Order GetById(int orderId)
        {
            var order = _context.Orders.SingleOrDefault(x => x.OrderId == orderId);
            return order;
        }

        public bool Delete(int orderId)
        {
            try
            {
                Order entity = _context.Orders.SingleOrDefault(x => x.OrderId == orderId);
                if (entity != null)
                {
                    _context.Orders.Remove(entity);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        public bool SaveOrUpdate(Order order)
        {
            try
            {
                var entity = _context.Orders.SingleOrDefault(x => x.OrderId == order.OrderId);
                if (entity == null)
                {
                    order.OrderCode = "O" + DateTime.Now.ToString("yyMMddHHmmss");
                    order.CreatedDate = DateTime.Now;
                    _context.Orders.Add(order);
                }
                else
                {
                    entity.OrderStatusId = order.OrderStatusId;
                    entity.PaymentDate = order.PaymentDate;
                    entity.TaxCode = order.TaxCode;
                    entity.BillAddress = order.BillAddress;
                    entity.BillCompany = order.BillCompany;
                }
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex){ }
            return false;
        }
    }
}
