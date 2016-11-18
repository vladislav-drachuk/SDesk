using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Http.Routing.Constraints;
using SDesk.API.Util;

namespace SDesk.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            var constraintResolver = new DefaultInlineConstraintResolver();
            constraintResolver.ConstraintMap.Add("jiraid", typeof(JiraIdConstraint));
            config.MapHttpAttributeRoutes(constraintResolver);
            




          

               config.Routes.MapHttpRoute(
                  name: "DefaultStringApi",
                  routeTemplate: "api/{controller}/{id}",
                  defaults: new { action = "GetByString" },
                  constraints: new { id = new JiraIdConstraint() } 
              );

            config.Routes.MapHttpRoute(
                  name: "DefaultDigitApi",
                  routeTemplate: "api/jiraitems/{id}",
                  defaults: new
                  {
                      controller = "jiraitems",
                      action = "GetById",
                      id = 1
                  });
            /*  config.Routes.MapHttpRoute(
                  name: "DefaultApi",
                  routeTemplate: "api/{controller}/{id}",
                  defaults: new { id = RouteParameter.Optional }
              );
              */
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
               // constraints: new { id = new LongRouteConstraint() }
                );

        }
    }
}
