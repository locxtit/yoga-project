using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoga.Entity;

namespace Yoga.Bussiness
{
    public class OperatorTypeBll
    {
        YogaContext _context = new YogaContext();

        public OperatorType GetById(string operatorTypeId)
        {
            return _context.OperatorTypes.SingleOrDefault(x => x.OperatorTypeId == operatorTypeId);
        }

        public List<OperatorType> GetAll()
        {
            return _context.OperatorTypes.ToList();
        }
    }
}
