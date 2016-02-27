using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnITStore.Domain.Abstract;
using LearnITStore.Domain.Entities;

namespace LearnITStore.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IProductRepository _repository;
        public AdminController(IProductRepository repository)
        {
            _repository = repository;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View(_repository.Products);
        }

        public ActionResult Edit(int productID)
        {
            var p = _repository.Products
                .FirstOrDefault(x => x.ProductID == productID);
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {                                
                _repository.SaveProduct(product);
                TempData["message"] = 
                    string.Format("{0} se ha guardado correctamente.",
                    product.Name);
                return RedirectToAction("Index");                               
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult Delete(int productID)
        {
            var p = _repository.DeleteProduct(productID);
            if (p != null)
            {
                TempData["message"] =
                    String.Format("{0} ha sido eliminado.",
                    p.Name);
            }
            return RedirectToAction("Index");
        }
    }
}