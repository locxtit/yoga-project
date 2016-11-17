using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoga.Entity;

namespace Yoga.Bussiness
{
    public class BankBll
    {
        YogaContext _context = new YogaContext();

        public Bank GetById(string BankId)
        {
            return _context.Banks.SingleOrDefault(x => x.BankId == BankId);
        }

        public List<Bank> GetAll()
        {
            return _context.Banks.ToList();
        }
    }
}
