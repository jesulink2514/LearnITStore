using LearnITStore.Domain.Entities;
using LearnITStore.WebUI.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LearnITStore.WebUI
{
    //Se ejecuta la primera vez, todo lo que se tiene ejecutar por primera vez se debe de colocar aquí
    //Registrar el Model Binder
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //Agregamos un nuevo model Binder
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
            //Para verlo en funcionamiento ir a CartController, borrar getCart()
        }
    }
}
