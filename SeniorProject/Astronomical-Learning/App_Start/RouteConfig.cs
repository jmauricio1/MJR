using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Astronomical_Learning
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "SpaceXLaunchList",
                url: "api/spacex-launchlist",
                defaults: new { controller = "SpaceCompanies", action = "SpaceXLaunchList"}
            );

            routes.MapRoute(
                name: "UpdateUsernameNavbar",
                url: "Manage/Update",
                defaults: new { controller = "Manage", action = "UpdateUsernamePartial" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
