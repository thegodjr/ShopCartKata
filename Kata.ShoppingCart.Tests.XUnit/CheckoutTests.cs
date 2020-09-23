using System;
using Xunit;

namespace Kata.ShoppingCart.Tests.XUnit
{
    public class CheckoutTests
    {
        [Fact]
        public void Checkout_GetTotal_WhenNotImplemented_ShouldThrow()
        {
            var checkout = new Checkout();
            Assert.Throws<NotImplementedException>(() => checkout.GetTotal("A"));
        }
    }
}