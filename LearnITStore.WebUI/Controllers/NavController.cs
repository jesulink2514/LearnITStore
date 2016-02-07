using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnITStore.Domain.Abstract;

namespace LearnITStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private readonly IProductRepository _productRepository;

        public NavController
            (IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ActionResult Menu(string categoria=null)
        {
            ViewBag.categoria = categoria;
            var categories =
                _productRepository.Products.
                    Select(x => x.Category)
                    .Distinct().OrderBy(x => x);   
                  
            return PartialView(categories);
        }
    }
}