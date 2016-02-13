using LearnITStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnITStore.Domain.Abstract;
using LearnITStore.WebUI.Models;

namespace LearnITStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository _productRepository;
        public CartController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ActionResult AddToCart
            (Cart cart,int productID,string returnUrl)
        {

            var product = _productRepository.Products
                .FirstOrDefault(x => x.ProductID == productID);

            if (product != null)
            {
                cart.Add(product,1);
            }
            return RedirectToAction("Index",new {returnUrl});
        }

        public ActionResult RemoveFromCart
            (Cart cart,int productID,string returnUrl)
        {
            var product = _productRepository.Products
                .FirstOrDefault(x => x.ProductID == productID);
            if (product != null)
            {
                cart.Remove(product);
            }
            return RedirectToAction("Index", new {returnUrl});
        }

        public ActionResult Index(Cart cart,string returnUrl)
        {
            var model = new CartViewModel()
            {
                Cart = cart,
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        public ActionResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
    }
}