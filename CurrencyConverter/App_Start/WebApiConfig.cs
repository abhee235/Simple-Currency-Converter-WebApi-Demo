﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace CurrencyConverter
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            //config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //    "DefaultApiWithAction",
            //    "api/{controller}/{action}");

            //config.Routes.MapHttpRoute(
            //    "DefaultApiGet",
            //    "Api/{controller}",
            //    new { action = "Get" },
            //    new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) });


            config.Formatters.Remove(config.Formatters.XmlFormatter);
            
            //routes.MapHttpRoute("DefaultApiPost", "Api/{controller}", new { action = "Post" }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) });
        }
    }
}
