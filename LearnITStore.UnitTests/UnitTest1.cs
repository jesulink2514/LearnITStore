using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LearnITStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void suma_devuelve_5()
        {
            //Arrange
            var calc = new Calc();
            var s1 = 2;
            var s2 = 3;
            var resultado_esperado = 5;

            //Act
            var r = calc.Sumar(s1, s2);

            //Assert
            Assert.AreEqual(resultado_esperado,r);
        }
    }

    public class Calc
    {
        public int Sumar(int s1, int s2)
        {
            return s1 + s2;
        }
    }
}
