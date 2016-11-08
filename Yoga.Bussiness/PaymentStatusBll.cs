using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoga.Entity;

namespace Yoga.Bussiness
{
    public class PaymentStatusBll
    {
        YogaContext _context = new YogaContext();

        public PaymentStatus GetById(string paymentStatusId)
        {
            return _context.PaymentStatuses.SingleOrDefault(x => x.PaymentStatusId == paymentStatusId);
        }

        public List<PaymentStatus> GetAll()
        {
            return _context.PaymentStatuses.ToList();
        }
    }
}
