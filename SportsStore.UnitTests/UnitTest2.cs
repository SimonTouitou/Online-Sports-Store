using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain.Abstract;
using Moq;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void Can_Create_Categories()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {ProductID = 1, Name = "P1", Category="Apples"},
                new Product {ProductID = 2, Name = "P2", Category="Apples"},
                new Product {ProductID = 3, Name = "P3", Category="Plums"},
                new Product {ProductID = 4, Name = "P4", Category="Plums"},
                new Product {ProductID = 5, Name = "P5", Category="Oranges"}
            });

            // Arrange
            NavController controller = new NavController(mock.Object);

            // Act
            string[] result = ((IEnumerable<string>)controller.Menu().Model).ToArray();

            // Assert
            Assert.AreEqual(result.Length, 3);
            Assert.AreEqual(result[0], "Apples");
            Assert.AreEqual(result[1], "Oranges");
            Assert.AreEqual(result[2], "Plums");
        }

        [TestMethod]
        public void Indicate_Selected_Category()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {ProductID = 1, Name = "P1", Category="Apples"},
                new Product {ProductID = 4, Name = "P2", Category="Oranges"},
            });

            // Arrange
            NavController controller = new NavController(mock.Object);

            // Arrange
            string categoryToSelect = "Apples";

            // Act
            string result = controller.Menu(categoryToSelect).ViewBag.SelectedCategory;

            // Assert
            Assert.AreEqual(categoryToSelect, result);
        }


    }
}
