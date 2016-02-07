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
    }
}
