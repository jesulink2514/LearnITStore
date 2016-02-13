using System;
using System.Linq;
using LearnITStore.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LearnITStore.UnitTests
{
    [TestClass]
    public class CartTest
    {
        [TestMethod]
        public void Agrega_producto_nuevo()
        {
            //Arrange
            var cart = new Cart();
            var ptest = new Product() {ProductID = 99};
            var qtest = 3;

            //Act
            cart.Add(ptest,qtest);

            //Assert
            Assert.AreEqual(cart.Lines.Count(),1);
            Assert.AreEqual(cart.Lines.First().Product.ProductID,99);
            Assert.AreEqual(cart.Lines.First().Quantity,qtest);
        }

        [TestMethod]
        public void Agrega_producto_existente()
        {
            //Arrange
            var cart = new Cart();
            var ptest = new Product() { ProductID = 99 };            

            //Act
            cart.Add(ptest,1);
            cart.Add(ptest,4);

            //Assert
            Assert.AreEqual(cart.Lines.Count(), 1);
            Assert.AreEqual(cart.Lines.First().Product.ProductID, 99);
            Assert.AreEqual(cart.Lines.First().Quantity,5);
        }

        [TestMethod]
        public void Remove_quita_producto_existente()
        {
            //Arrange
            var cart = new Cart();
            var ptest = new Product() {ProductID = 13};            
            //Act
            cart.Add(ptest,1);
            cart.Remove(ptest);

            //Assert
            Assert.AreEqual(cart.Lines.Count(),0);
        }

        [TestMethod]
        public void Calcula_precio_productos()
        {
            //Arrange
            var cart = new Cart();
            var ptest = new Product()
            {
                ProductID = 1,Price = 99
            };
            var pse = new Product()
            {
                ProductID = 2,Price = 50
            };

            //Act
            cart.Add(ptest,1);
            cart.Add(pse,2);

            //Assert
            Assert.AreEqual(cart.TotalPrice,199);
        }
        [TestMethod]
        public void Carrito_se_limpia_al_llamar_clear()
        {
            //Arrange
            var carrito = new Cart();
            var producto = new Product() { ProductID = 1 };
            carrito.Add(producto, 3);
            const int items = 0;
            //Act Llama la función
            carrito.Clear();
            //Assert comparar
            Assert.AreEqual(carrito.Lines.Count(), items);
        }
    }
}
