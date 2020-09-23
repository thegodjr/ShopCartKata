using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata.ShoppingCart.Tests
{
    [TestClass]
    public class CheckoutTests
    {
        private readonly Checkout _sut = new Checkout();

        [TestMethod]
        public void Checkout_GetTotal_WhenCalled_ShouldNotThrow()
        {
            Action act = () => _sut.GetTotal("A");
            act.Should().NotThrow();
        }

        [TestMethod]
        public void Checkout_GetTotal_WhenCalledWithNullItem_ShouldReturnZero()
        {
            _sut.GetTotal(null).Should().Be(0);
        }

        [TestMethod]
        public void Checkout_GetTotal_WhenCalledWithNoItem_ShouldReturnZero()
        {
            _sut.GetTotal("").Should().Be(0);
        }

        [DataTestMethod]
        [DataRow("A", 50)]
        [DataRow("B", 30)]
        [DataRow("C", 20)]
        [DataRow("D", 15)]
        public void Checkout_GetTotal_WhenCalledWithOneItem_ShouldReturnSingleItemPrice(string item, double price)
        {
            _sut.GetTotal(item).Should().Be(price);
        }

        [DataTestMethod]
        [DataRow("ABCD", 115)]
        [DataRow("AABCD", 165)]
        [DataRow("ABCCD", 135)]
        [DataRow("ABCDD", 130)]
        [DataRow("CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC", 2000)]
        public void Checkout_GetTotal_WhenCalledWithMultipleItems_ShouldReturnTotalPrice(string item, double price)
        {
            _sut.GetTotal(item).Should().Be(price);
        }

        [DataTestMethod]
        [DataRow("AAA", 130)]
        [DataRow("AAAAAA", 260)]
        [DataRow("BB", 45)]
        [DataRow("BBBB", 90)]
        [DataRow("AAABB", 175)]
        [DataRow("BAAAB", 175)]
        [DataRow("BACADAB", 210)]
        public void Checkout_GetTotal_WhenCalledWithWithDiscountedItems_ShouldDiscountAllItems(string item, double price)
        {
            _sut.GetTotal(item).Should().Be(price);
        }

        [DataTestMethod]
        [DataRow("AAAAA", 230)]
        [DataRow("BBB", 75)]
        public void Checkout_GetTotal_WhenCalledWithWithMoreThanRequiredForDiscount_ShouldNotDiscountAdditionalItems(string item, double price)
        {
            _sut.GetTotal(item).Should().Be(price);
        }
    }
}