using System.Web.Mvc;
using LearnITStore.Domain.Entities;

namespace LearnITStore.WebUI.Binders
{
    public class CartModelBinder
        :IModelBinder
    {
        public object BindModel(
            ControllerContext controllerContext, 
            ModelBindingContext bindingContext)
        {                        
            var cart = controllerContext.HttpContext
                .Session["cart"] as Cart;

            if (cart == null)
            {
                cart = new Cart();
                controllerContext.HttpContext
                    .Session["cart"] = cart;
            }
            return cart;
        }
    }
}