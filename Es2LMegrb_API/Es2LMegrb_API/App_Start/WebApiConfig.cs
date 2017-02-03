using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Es2LMegrb_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();
            // Web API routes
            config.MapHttpAttributeRoutes();
          
            // Map this rule first
            config.Routes.MapHttpRoute(
                  name: "WithActionApi",
                 routeTemplate: "api/{controller}/{action}/{id}",
                 defaults: new { id = RouteParameter.Optional }
             );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
