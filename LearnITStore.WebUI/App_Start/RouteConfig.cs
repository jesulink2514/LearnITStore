using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LearnITStore.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Catalogo",
                url: "pagina{page}",
                defaults: new
                {
                    controller = "Products",
                    action = "List" ,
                    categoria =(string)null
                },                
                constraints: new { page = @"\d+"}
            );

            routes.MapRoute(
                name: "PCategoria",
                url: "{categoria}",
                defaults: new
                {
                    controller = "Products",
                    action = "List",
                    page = 1
                }                
            );

            routes.MapRoute(
                name: "CategoriaPagina",
                url: "{categoria}/pagina{page}",
                defaults: new
                {
                    controller = "Products",
                    action = "List",
                    page = 1
                },
                constraints: new
                {
                    page=@"\d+"
                }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Products",
                    action = "List",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}
