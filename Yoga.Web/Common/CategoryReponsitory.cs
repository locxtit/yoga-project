﻿using System;
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
        public static SelectList GetStatusForProvinces()
        {
            var selectListItems = new List<SelectListItem>();
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
    }
}