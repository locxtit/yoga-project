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


        private static List<Province> _provinces;
        public static List<Province> Provinces
        {
            get
            {
                if (_provinces == null)
                {
                    _provinces = new ProvinceBll().GetProvinceActive();
                }
                return _provinces;
            }
        }

        private static List<OperatorType> _operatorTypes;
        public static List<OperatorType> OperatorTypes
        {
            get
            {
                if (_operatorTypes == null)
                {
                    _operatorTypes = new OperatorTypeBll().GetAll();
                }
                return _operatorTypes;
            }
        }

        private static List<Trainer> _trainers;
        public static List<Trainer> Trainers
        {
            get
            {
                if (_trainers == null)
                {
                    _trainers = new TrainerBll().GetAll();
                }
                return _trainers;
            }
        }

        private static List<Customer> _customers;
        public static List<Customer> Customers
        {
            get
            {
                if (_customers == null)
                {
                    _customers = new CustomerBll().GetAll();
                }
                return _customers;
            }
        }
    }
}
