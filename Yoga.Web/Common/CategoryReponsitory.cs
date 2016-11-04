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
    }
}