using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnITStore.Domain.Abstract;
using LearnITStore.WebUI.HtmlHelpers;
using LearnITStore.WebUI.Models;

namespace LearnITStore.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository _repository;
        public int PageSize = 4;
        public ProductsController
            (IProductRepository repository)
        {
            _repository = repository;
        }

        public ActionResult List(string categoria,int page=1)
        {
            var products = _repository.Products
                .Where(x=> categoria == null || 
                x.Category == categoria);

            var p = products.Paginar(page, PageSize);                        

            var pi = new PageInfo()
            {
                PageSize = PageSize,
                Page = page,
                Total = products.Count()
            };            
            var model = new ProductsViewModel()
            {
                PageInfo = pi,
                Products = p,
                CurrentCategory = categoria
            };
            return View(model);
        }
    }
}