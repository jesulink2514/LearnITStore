using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnITStore.Domain.Abstract;
using LearnITStore.Domain.Entities;

namespace LearnITStore.Domain.Concrete
{
    public class EFProductRepository:IProductRepository
    {
        private EFDbContext ctx = new EFDbContext();

        public IEnumerable<Product> Products
        {
            get { return ctx.Products; }
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                ctx.Products.Add(product);
            }
            else
            {
                var p = ctx.Products.Find(product.ProductID);
                if (p != null)
                {
                    p.Name = product.Name;
                    p.Price = product.Price;
                    p.Description = product.Description;
                    p.Category = product.Category;
                }
            }
            ctx.SaveChanges();
        }

        public Product DeleteProduct(int productID)
        {
            var p = ctx.Products.Find(productID);
            if (p != null)
            {
                ctx.Products.Remove(p);
                ctx.SaveChanges();
            }
            return p;
        }
    }

}
