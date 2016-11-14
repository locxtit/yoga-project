using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoga.Entity;

namespace Yoga.Bussiness
{
    public class OrderStatusBll
    {
        YogaContext _context = new YogaContext();

        public OrderStatus GetById(string statusId)
        {
            return _context.OrderStatuses.SingleOrDefault(x => x.OrderStatusId == statusId);
        }

        public List<OrderStatus> GetAll()
        {
            return _context.OrderStatuses.ToList();
        }
    }
}
