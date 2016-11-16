﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Yoga.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //ModelBinders.Binders.Add(typeof(DateTime?), new MyDateTimeModelBinder());
        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
            var info = new CultureInfo(Thread.CurrentThread.CurrentCulture.ToString())
            {
                DateTimeFormat = { ShortDatePattern = "dd/MM/yyyy" }
            };

            Thread.CurrentThread.CurrentCulture = info;
        }
    }
}