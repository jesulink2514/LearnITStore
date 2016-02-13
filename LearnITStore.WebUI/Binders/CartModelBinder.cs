using LearnITStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnITStore.WebUI.Binders
{
    public class CartModelBinder:IModelBinder
    {
        //controlador actual
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var cart = controllerContext.HttpContext.Session["cart"] as Cart;

            if (cart==null)
            {
                cart = new Cart();
                controllerContext.HttpContext.Session["cart"] = cart;
            }
            return cart;
        }
    }
}