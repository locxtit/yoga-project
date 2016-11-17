using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoga.Bussiness;
using Yoga.Entity.Enums;

namespace Yoga.Web.Common
{
    public class CategoryReponsitory
    {
        public static SelectList GetStatusForProvinces(object selectedValue = null, string defaultOption = null)
        {
            var selectListItems = new List<SelectListItem>();
            if(defaultOption != null)
                selectListItems.Add(new SelectListItem()
                {
                    Value = "",
                    Text = defaultOption
                });

            selectListItems.Add(new SelectListItem()
            {
                Value = StatusEnum.ACTIVE.ToString(),
                Text = CategoryBll.Statuses.SingleOrDefault(x => x.StatusId == StatusEnum.ACTIVE.ToString()).StatusName
            });

            selectListItems.Add(new SelectListItem()
            {
                Value = StatusEnum.INACTIVE.ToString(),
                Text = CategoryBll.Statuses.SingleOrDefault(x => x.StatusId == StatusEnum.INACTIVE.ToString()).StatusName
            });
            return new SelectList(selectListItems, "Value", "Text");
        }

        public static SelectList GetCustomerTypeSelectList(object selectedValue, string defaultOption)
        {
            var selectListItems = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(defaultOption))
                selectListItems.Add(new SelectListItem()
                {
                    Value = "",
                    Text = defaultOption
                });
            selectListItems.AddRange(CategoryBll.CustomerTypes.Select(x => new SelectListItem()
            {
                Value = x.CustomerTypeId,
                Text = x.CustomerTypeName
            }));

            return new SelectList(selectListItems, "Value", "Text", selectedValue);
        }

        public static SelectList GetCustomerStatusSelectList(object selectedValue, string defaultOption)
        {
            var selectListItems = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(defaultOption))
                selectListItems.Add(new SelectListItem()
                {
                    Value = "",
                    Text = defaultOption
                });
            selectListItems.AddRange(CategoryBll.CustomerStatuses.Select(x => new SelectListItem()
            {
                Value = x.CustomerStatusId,
                Text = x.CustomerStatusName
            }));

            return new SelectList(selectListItems, "Value", "Text", selectedValue);
        }

        public static SelectList GetProvinceSelectList(object selectedValue, string defaultOption)
        {
            var selectListItems = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(defaultOption))
                selectListItems.Add(new SelectListItem()
                {
                    Value = "",
                    Text = defaultOption
                });
            selectListItems.AddRange(CategoryBll.Provinces.Select(x => new SelectListItem()
            {
                Value = x.ProvinceId.ToString(),
                Text = x.ProvinceName
            }));

            return new SelectList(selectListItems, "Value", "Text", selectedValue);
        }

        public static SelectList GetOperatorTypeSelectList()
        {
            var selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem()
            {
                Value = OperatorTypeEnum.SUPERVISOR.ToString(),
                Text = CategoryBll.OperatorTypes.SingleOrDefault(x => x.OperatorTypeId == OperatorTypeEnum.SUPERVISOR.ToString()).OperatorTypeName
            });

            selectListItems.Add(new SelectListItem()
            {
                Value = OperatorTypeEnum.NOMAL_USER.ToString(),
                Text = CategoryBll.OperatorTypes.SingleOrDefault(x => x.OperatorTypeId == OperatorTypeEnum.NOMAL_USER.ToString()).OperatorTypeName
            });
            return new SelectList(selectListItems, "Value", "Text");
        }

        public static SelectList GetTrainerSelectList(object selectedValue, string defaultOption)
        {
            var selectListItems = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(defaultOption))
                selectListItems.Add(new SelectListItem()
                {
                    Value = "",
                    Text = defaultOption
                });
            selectListItems.AddRange(CategoryBll.Trainers.Select(x => new SelectListItem()
            {
                Value = x.TrainerId.ToString(),
                Text = x.TrainerName
            }));

            return new SelectList(selectListItems, "Value", "Text", selectedValue);
        }

        public static SelectList GetCustomerSelectList(object selectedValue, string defaultOption)
        {
            var selectListItems = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(defaultOption))
                selectListItems.Add(new SelectListItem()
                {
                    Value = "",
                    Text = defaultOption
                });
            selectListItems.AddRange(CategoryBll.Customers.Select(x => new SelectListItem()
            {
                Value = x.CustomerId.ToString(),
                Text = x.Name + " (" + x.Email + ")"
            }));

            return new SelectList(selectListItems, "Value", "Text", selectedValue);
        }

        public static SelectList GetServiceSelectList(object selectedValue, string defaultOption)
        {
            var selectListItems = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(defaultOption))
                selectListItems.Add(new SelectListItem()
                {
                    Value = "",
                    Text = defaultOption
                });
            selectListItems.AddRange(CategoryBll.Services.Select(x => new SelectListItem()
            {
                Value = x.ServiceId.ToString(),
                Text = x.ServiceName
            }));

            return new SelectList(selectListItems, "Value", "Text", selectedValue);
        }

        public static SelectList GetPaymentStatus()
        {
            var selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem()
            {
                Value = PaymentStatusEnum.PAID.ToString(),
                Text = CategoryBll.PaymentStatuses.SingleOrDefault(x => x.PaymentStatusId == PaymentStatusEnum.PAID.ToString()).PaymentStatusName
            });

            selectListItems.Add(new SelectListItem()
            {
                Value = PaymentStatusEnum.NOPAID.ToString(),
                Text = CategoryBll.PaymentStatuses.SingleOrDefault(x => x.PaymentStatusId == PaymentStatusEnum.NOPAID.ToString()).PaymentStatusName
            });
            return new SelectList(selectListItems, "Value", "Text");
        }

        public static SelectList GetOperatorSelectList(object selectedValue, string defaultOption)
        {
            var selectListItems = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(defaultOption))
                selectListItems.Add(new SelectListItem()
                {
                    Value = "",
                    Text = defaultOption
                });
            selectListItems.AddRange(CategoryBll.Operators.Select(x => new SelectListItem()
            {
                Value = x.OperatorId.ToString(),
                Text = x.OperatorName ?? x.Email
            }));

            return new SelectList(selectListItems, "Value", "Text", selectedValue);
        }

        public static SelectList GetOrderStatusSelectList(object selectedValue = null, string defaultOption = null)
        {
            var selectListItems = new List<SelectListItem>();
            if (defaultOption != null)
                selectListItems.Add(new SelectListItem()
                {
                    Value = "",
                    Text = defaultOption
                });

            selectListItems.Add(new SelectListItem()
            {
                Value = OrderStatusEnum.PAID.ToString(),
                Text = CategoryBll.OrderStatus.SingleOrDefault(x => x.OrderStatusId == OrderStatusEnum.PAID.ToString()).OrderStatusName
            });

            selectListItems.Add(new SelectListItem()
            {
                Value = OrderStatusEnum.WAITING.ToString(),
                Text = CategoryBll.OrderStatus.SingleOrDefault(x => x.OrderStatusId == OrderStatusEnum.WAITING.ToString()).OrderStatusName
            });
            selectListItems.Add(new SelectListItem()
            {
                Value = OrderStatusEnum.CANCEL.ToString(),
                Text = CategoryBll.OrderStatus.SingleOrDefault(x => x.OrderStatusId == OrderStatusEnum.CANCEL.ToString()).OrderStatusName
            });
            return new SelectList(selectListItems, "Value", "Text");
        }

        public static SelectList GetStatusForClassInfo(object selectedValue = null, string defaultOption = null)
        {
            var selectListItems = new List<SelectListItem>();
            if (defaultOption != null)
                selectListItems.Add(new SelectListItem()
                {
                    Value = "",
                    Text = defaultOption
                });

            selectListItems.Add(new SelectListItem()
            {
                Value = StatusEnum.ACTIVE.ToString(),
                Text = CategoryBll.Statuses.SingleOrDefault(x => x.StatusId == StatusEnum.ACTIVE.ToString()).StatusName
            });

            selectListItems.Add(new SelectListItem()
            {
                Value = StatusEnum.INACTIVE.ToString(),
                Text = CategoryBll.Statuses.SingleOrDefault(x => x.StatusId == StatusEnum.INACTIVE.ToString()).StatusName
            });
            selectListItems.Add(new SelectListItem()
            {
                Value = StatusEnum.FINISHED.ToString(),
                Text = CategoryBll.Statuses.SingleOrDefault(x => x.StatusId == StatusEnum.FINISHED.ToString()).StatusName
            });
            return new SelectList(selectListItems, "Value", "Text");
        }

        public static SelectList GetYearReportSelectList()
        {
            var selectListItems = new List<SelectListItem>();
            var year = 2016;
            for (int i = 0; i < 100; i++ )
                selectListItems.Add(new SelectListItem()
                {
                    Value = (year + i).ToString(),
                    Text = (year + i).ToString()
                });
            return new SelectList(selectListItems, "Value", "Text");
        }

        public static SelectList GetMonthReportSelectList()
        {
            var selectListItems = new List<SelectListItem>();
            var month = 1;
            for (int i = 0; i < 12; i++)
                selectListItems.Add(new SelectListItem()
                {
                    Value = (month + i).ToString(),
                    Text = (month + i).ToString()
                });
            return new SelectList(selectListItems, "Value", "Text");
        }

        public static SelectList GetBankSelectList(object selectedValue, string defaultOption)
        {
            var selectListItems = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(defaultOption))
                selectListItems.Add(new SelectListItem()
                {
                    Value = "",
                    Text = defaultOption
                });
            selectListItems.AddRange(CategoryBll.Banks.Select(x => new SelectListItem()
            {
                Value = x.BankId,
                Text = string.Format("{0} - {1}",x.BankId,x.BankName)
            }));

            return new SelectList(selectListItems, "Value", "Text", selectedValue);
        }
    }
}