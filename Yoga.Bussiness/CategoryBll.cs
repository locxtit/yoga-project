using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yoga.Entity;

namespace Yoga.Bussiness
{
    public class CategoryBll
    {
        private static List<Status> _statuses;
        public static List<Status> Statuses
        {
            get
            {
                if (_statuses == null)
                {
                    _statuses = new StatusBll().GetAll();
                }
                return _statuses;
            }
        }
    }
}
