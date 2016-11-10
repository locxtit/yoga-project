using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Yoga.Bussiness;
using Yoga.Entity;
using Yoga.Web.Common;

namespace Yoga.Web.Helpers
{
    public class Support
    {
        public static int GetNotificationCount()
        {
            if (HttpContext.Current.Session[SessionConstant.SESSION_OPERATOR] != null)
            {
                var oper = (Operator)HttpContext.Current.Session[SessionConstant.SESSION_OPERATOR];
                var count = new NotifyBll().GetForNotification(oper.OperatorId).Count();
            }
            return 0;
        }
    }
}