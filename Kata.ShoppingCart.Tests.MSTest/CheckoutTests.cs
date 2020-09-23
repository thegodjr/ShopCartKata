using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata.ShoppingCart.Tests.MSTest
{
    [TestClass]
    public class CheckoutTests
    {
        [TestMethod]
        public void Checkout_GetTotal_WhenNotImplemented_ShouldThrow()
        {
            var checkout = new Checkout();
            Action act = () => checkout.GetTotal("A");
            act.Should().ThrowExactly<NotImplementedException>();
        }
    }
}