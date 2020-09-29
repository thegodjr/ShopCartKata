using System;
using NUnit.Framework;

namespace Kata.ShoppingCart.Tests.NUnit
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Checkout_GetTotal_EachSkus_ShouldPass()
        {
            var checkout = new Checkout();
            var total = checkout.GetTotal("ABCD");

            Assert.AreEqual(115, total);
        }

        [Test]
        public void Checkout_GetTotal_3A_ShouldHaveDiscounts()
        {
            var checkout = new Checkout();
            var total = checkout.GetTotal("AAA");

            Assert.AreEqual(130, total);
        }

        [Test]
        public void Checkout_GetTotal_2B_ShouldHaveDiscounts()
        {
            var checkout = new Checkout();
            var total = checkout.GetTotal("BB");

            Assert.AreEqual(45, total);
        }

        [Test]
        public void Checkout_GetTotal_2C_ShouldNotHaveDiscounts()
        {
            var checkout = new Checkout();
            var total = checkout.GetTotal("CC");

            Assert.AreEqual(40, total);
        }

        [Test]
        public void Checkout_GetTotal_4A2Bcd_ShouldHaveDiscounts()
        {
            var checkout = new Checkout();
            var total = checkout.GetTotal("ADABCABA");

            Assert.AreEqual(260, total);
        }
    }
}