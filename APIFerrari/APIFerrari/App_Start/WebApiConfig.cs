using APIFerrari.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace APIFerrari
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			// Serviços e configuração da API da Web
			config.EnableCors();
			//Configurar Token
			config.MessageHandlers.Add(new EsteticaAPI.TokenValidationHandler());
			// Rotas da API da Web
			config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
