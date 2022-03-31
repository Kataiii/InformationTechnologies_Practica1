﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PracticaInforTec1.Models
{
    public static class Router
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            Route route = new Route("{controller}/{action}", new MvcRouteHandler());
            routes.Add(route);
        }
    }
}