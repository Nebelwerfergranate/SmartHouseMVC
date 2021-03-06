﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SmartHouseMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            // Положение экрана со времени последнего запроса храниться в куках.
            Response.Cookies["scrollTop"].Value = 0.ToString();
            Response.Cookies["scrollLeft"].Value = 0.ToString();
        }
    }
}
