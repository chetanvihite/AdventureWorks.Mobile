using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AdventureWorks.Mobile.Services
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "AdventureWorks",
                routeTemplate: "api/AdventureWorks/Authenticate/{mobileNumber}/{password}",
                defaults: new {
                    mobileNumber = RouteParameter.Optional,
                    password = RouteParameter.Optional }
            );

        }
    }
}
