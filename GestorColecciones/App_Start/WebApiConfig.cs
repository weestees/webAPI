using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GestorColecciones
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API

            // Verificar si la ruta ya existe antes de agregarla
            if (!config.Routes.Any(r => r.RouteTemplate == "api/{controller}/{id}"))
            {
                config.MapHttpAttributeRoutes();

                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
            }
        }
    }
}
