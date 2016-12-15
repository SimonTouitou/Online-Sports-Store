using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain.Entities;
using System.Linq;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void Can_Add_New_Lines()
        {
            // Arrange
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };

            // Arrange
            Cart target = new Cart();

            // Act
            target.Additem(p1, 1);
            target.Additem(p2, 1);
            CartLine[] results = target.Lines.ToArray();

            // Assert
            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[0].Product, p1);
            Assert.AreEqual(results[1].Product, p2);
        }

        [TestMethod]
        public void Can_Add_Quantity_For_Existing_Lines()
        {
            // Arrange
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };

            // Arrange
            Cart target = new Cart();

            // Act
            target.Additem(p1, 1);
            target.Additem(p2, 1);
            target.Additem(p1, 10);
            CartLine[] results = target.Lines.OrderBy(p => p.Product.ProductID).ToArray();

            // Assert
            Assert.AreEqual(results.Length, 2);
            Assert.AreEqual(results[0].Quantity, 11);
            Assert.AreEqual(results[1].Quantity, 1);
        }

        [TestMethod]
        public void Can_Remove_Line()
        {
            // Arrange
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Product p3 = new Product { ProductID = 3, Name = "P3" };

            // Arrange
            Cart target = new Cart();

            // Arrange
            target.Additem(p1, 1);
            target.Additem(p2, 3);
            target.Additem(p3, 5);
            target.Additem(p2, 1);

            // Act
            target.RemoveLine(p2);

            // Assert
            Assert.AreEqual(target.Lines.Where(c => c.Product == p2).Count(), 0);
            Assert.AreEqual(target.Lines.Count(), 2);
        }

        [TestMethod]
        public void Calculate_Cart_Total()
        {
            // Arrange
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 10.99M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 30.01M };
            Product p3 = new Product { ProductID = 3, Name = "P3", Price = 110.50M };

            // Arrange
            Cart target = new Cart();

            // Arrange
            target.Additem(p1, 1);
            target.Additem(p2, 3);
            target.Additem(p3, 5);
            target.Additem(p2, 1);

            // Act
            decimal result = target.ComputeTotalValue();

            // Assert
            Assert.AreEqual(result, 683.53M);
        }

        [TestMethod]
        public void Can_Clear_Contents()
        {            
            // Arrange
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 10.99M };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 30.01M };
            Product p3 = new Product { ProductID = 3, Name = "P3", Price = 110.50M };

            // Arrange
            Cart target = new Cart();

            // Arrange
            target.Additem(p1, 1);
            target.Additem(p2, 3);
            target.Additem(p3, 5);
            target.Additem(p2, 1);

            // Act
            target.Clear();

            // Assert
            Assert.AreEqual(target.Lines.Count(), 0);
        }
    }
}
