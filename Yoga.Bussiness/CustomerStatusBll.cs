using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoga.Entity;
using Yoga.Entity.Enums;

namespace Yoga.Bussiness
{
    public class CustomerStatusBll
    {
        private YogaContext _context = new YogaContext();

        public List<CustomerStatus> GetAll()
        {
            return _context.CustomerStatuses.ToList();
        }

        public CustomerStatus GetById(string customerStatusId)
        {
            var customerStatus = _context.CustomerStatuses.SingleOrDefault(x => x.CustomerStatusId == customerStatusId);
            return customerStatus;
        }
    }
}
