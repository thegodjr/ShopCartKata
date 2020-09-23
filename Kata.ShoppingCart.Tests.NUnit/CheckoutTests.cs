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
        public void Checkout_GetTotal_WhenNotImplemented_ShouldThrow()
        {
            var checkout = new Checkout();
            Assert.Throws<NotImplementedException>(() => checkout.GetTotal("A"));
        }
    }
}