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

        private static List<CustomerStatus> _customerStatuses;
        public static List<CustomerStatus> CustomerStatuses
        {
            get
            {
                if (_customerStatuses == null)
                {
                    _customerStatuses = new CustomerStatusBll().GetAll();
                }
                return _customerStatuses;
            }
        }

        private static List<CustomerType> _customerTypes;
        public static List<CustomerType> CustomerTypes
        {
            get
            {
                if (_customerTypes == null)
                {
                    _customerTypes = new CustomerTypeBll().GetAll();
                }
                return _customerTypes;
            }
        }
    }
}
