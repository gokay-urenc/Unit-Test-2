using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShoppingCart.Tests
{
    [TestClass]
    public class CartTests
    {
        private CartItem _cartItem;
        private CartManager _cartManager;

        [TestInitialize]
        public void TestInitialize()
        {
            _cartManager = new CartManager();
            _cartItem = new CartItem
            {
                Product = new Product()
                {
                    ProductId = 1,
                    ProductName = "Laptop",
                    UnitPrice = 2500
                },
                Quantity = 1
            };
            _cartManager.Add(_cartItem);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _cartManager.Clear();
        }

        [TestMethod]
        public void Products_must_be_added_to_the_cart()
        {
            // Arrange
            const int expected = 1;

            // Act
            var totalNumberOfCartItems = _cartManager.TotalItems;

            // Assert
            Assert.AreEqual(expected, totalNumberOfCartItems);
        }

        [TestMethod]
        public void Products_must_be_removed_from_the_cart()
        {
            // Arrange
            var totalNumberOfCartItems = _cartManager.TotalItems;

            // Act
            _cartManager.Remove(1);
            var totalNumberOfCartItemsLeft = _cartManager.TotalItems;

            // Assert
            Assert.AreEqual(totalNumberOfCartItems - 1, totalNumberOfCartItemsLeft);
        }

        [TestMethod]
        public void The_card_must_be_cleared()
        {
            // Arrange

            // Act
            _cartManager.Clear();

            // Assert
            Assert.AreEqual(0, _cartManager.TotalQuantity);
            Assert.AreEqual(0, _cartManager.TotalItems);
        }
    }
}