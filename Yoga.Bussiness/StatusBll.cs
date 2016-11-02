using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoga.Entity;

namespace Yoga.Bussiness
{
    public class StatusBll
    {
        YogaContext _context = new YogaContext();

        public Status GetById(string statusId)
        {
            return _context.Statuses.SingleOrDefault(x => x.StatusId == statusId);
        }

        public List<Status> GetAll()
        {
            return _context.Statuses.ToList();
        }
    }
}
