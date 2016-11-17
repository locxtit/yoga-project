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
            set
            {
                _customerStatuses = value;
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
            set
            {
                _provinces = value;
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
            set
            {
                _trainers = value;
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
            set
            {
                _customers = value;
            }
        }

        private static List<Service> _services;
        public static List<Service> Services
        {
            get
            {
                if (_services == null)
                {
                    _services = new ServiceBll().GetServiceActive();
                }
                return _services;
            }
            set
            {
                _services = value;
            }
        }

        private static List<PaymentStatus> _paymentStatuses;
        public static List<PaymentStatus> PaymentStatuses
        {
            get
            {
                if (_paymentStatuses == null)
                {
                    _paymentStatuses = new PaymentStatusBll().GetAll();
                }
                return _paymentStatuses;
            }
        }

        private static List<Operator> _operators;
        public static List<Operator> Operators
        {
            get
            {
                if (_operators == null)
                {
                    _operators = new OperatorBll().GetServiceActive();
                }
                return _operators;
            }
            set
            {
                _operators = value;
            }
        }

        private static List<OrderStatus> _orderStatus;
        public static List<OrderStatus> OrderStatus
        {
            get
            {
                if (_orderStatus == null)
                {
                    _orderStatus = new OrderStatusBll().GetAll();
                }
                return _orderStatus;
            }
        }

        private static List<Bank> _banks;
        public static List<Bank> Banks
        {
            get
            {
                if (_banks == null)
                {
                    _banks = new BankBll().GetAll();
                }
                return _banks;
            }
        }
    }
}
