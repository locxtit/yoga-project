using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoga.Entity;
using Yoga.Entity.Enums;

namespace Yoga.Bussiness
{
    public class CustomerTypeBll
    {
        private YogaContext _context = new YogaContext();

        public List<CustomerType> GetAll()
        {
            return _context.CustomerTypes.ToList();
        }

        public CustomerType GetById(string customerTypeId)
        {
            var customerType = _context.CustomerTypes.SingleOrDefault(x => x.CustomerTypeId == customerTypeId);
            return customerType;
        }
    }
}
