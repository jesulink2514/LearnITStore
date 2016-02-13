using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnITStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> _lines = new List<CartLine>();
        public IEnumerable<CartLine> Lines
        {
            get
            { return _lines; }
        }

        public decimal TotalPrice
        {
            get
            {                
                return Lines.Sum(x => x.Product.Price*x.Quantity);               
            }
        }

        public void Add(Product product, int quantity)
        {
            var line = _lines
                .FirstOrDefault(x => 
                x.Product.ProductID == product.ProductID);
            if (line != null)
            {
                line.Quantity += quantity;
            }
            else
            {
                _lines.Add(new CartLine()
                {
                    Product = product,Quantity = quantity
                });
            }
        }

        public void Remove(Product product)
        {
            _lines
                .RemoveAll(x =>
                    x.Product.ProductID == product.ProductID);
        }

        public void Clear()
        {
            _lines.Clear();
        }
    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity{ get; set; }

        public decimal SubTotal 
        {
            get { return Quantity * Product.Price; }
        }
    }
}
