using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Newaz_1271713_Code_First
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Newaz",
                url: "RN/OrderPlace/{id}",
                defaults: new { controller = "OrderPlace", action = "List", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "OrderPlace", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
