using LearnITStore.Domain.Abstract;
using LearnITStore.Domain.Entities;
using LearnITStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnITStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        //este tipo de dato no puede ser cambiado, no puede ser reemplazado
        //por otro objeto
        private readonly IProductRepository _productRepository;
        //El constructor va a pedir que le pasen el producto
        public CartController(IProductRepository productRepository)
        {
            _productRepository = productRepository;   
        }

        //Metodo que devuelve una acción
        //Debe de recibir los mismos nombres que están en la vista de ProductSummary
        public ActionResult AddToCart(Cart cart, int productID, string returnUrl)
        {
            //Para buscar, traer cualquier producto usamos el objeto repository
            //FirstOrDefault si no lo encuentra devuelve nullo
            var product = _productRepository.Products.FirstOrDefault(x => x.ProductID == productID);

            if (product!=null)
            {
                //Obtiene un carrito y lo agrega
                cart.Add(product, 1);
            }
            //le pasas la vista index y el tipo de dato URL
            //el index no esta creado, por defecto tomaría el index de la carpeta Cart

            //return View("Index", new { returnUrl });
            return RedirectToAction("Index", new { returnUrl });
        }

        public ActionResult RemoveFromCart(Cart cart,int productID, string returnUrl)
        {
            var product = _productRepository.Products.FirstOrDefault(x => x.ProductID == productID);

            if (product!=null)
            {
                cart.Remove(product);
            }

            //return View("Index", new { returnUrl });
            return RedirectToAction("Index", new { returnUrl });
        }
        public ActionResult Index(Cart cart, string returnUrl)
        {
            var model = new CartViewModel()
            {
                Cart = cart,
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        //Pedira el carrito para pasarselo, muestra summary
        public ActionResult Summary(Cart cart)
        {
            return PartialView(cart);
        } 

        //Llamamos el Binder borramos el metodo GetCart() y lo colocamos
        //en los métodos anteriores
        //private Cart GetCart()
        //{
        //    //obtiene un objeto de tipo cart, la Session necesita una clave
        //    //la clave (valor) es cart, ya que la sesion es como un diccionario
        //    var cart = Session["cart"] as Cart;
        //    //si no hay nada en el carrito
        //    if (cart==null)
        //    {
        //        //lo creo de nuevo
        //        cart = new Cart();
        //        Session["cart"] = cart;
        //    }
        //    return cart;
        //}
    }
}