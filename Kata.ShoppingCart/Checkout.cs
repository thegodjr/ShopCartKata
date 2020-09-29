using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Kata.ShoppingCart
{
    public class Checkout : ICheckout
    {
        private Dictionary<char, decimal> skuPrices = new Dictionary<char, decimal>
        {
            { 'A', 50 },
            { 'B', 30},
            { 'C', 20},
            { 'D', 15},
        };

        private Dictionary<char, Tuple<int, decimal>> skuDiscounts = new Dictionary<char, Tuple<int, decimal>>
        {
            { 'A', new Tuple<int, decimal> (3, 130) },
            { 'B', new Tuple<int, decimal> (2, 45) }
        };

        public double GetTotal(string items)
        {
            var skusCount = new Dictionary<char, Tuple<int, decimal, decimal>>();
            foreach (var item in items)
            {
                decimal skuPrice;
                if (skuPrices.TryGetValue(item, out skuPrice))
                {
                    Tuple<int, decimal, decimal> skuCount;
                    if (skusCount.TryGetValue(item, out skuCount))
                    {
                        skusCount[item] = new Tuple<int, decimal, decimal>(skuCount.Item1 + 1, skuCount.Item2 + skuPrice, skuPrice);
                    }
                    else
                    {
                        skusCount[item] = new Tuple<int, decimal, decimal>(1, skuPrice, skuPrice);
                    }
                }
            }

            decimal sum = 0;
            foreach (var item in skusCount)
            {
                Tuple<int, decimal> skuDiscount;

                if (skuDiscounts.TryGetValue(item.Key, out skuDiscount))
                {
                    int skusCountWithoutDiscounts;
                    var multiplicator = Math.DivRem(item.Value.Item1, skuDiscount.Item1, out skusCountWithoutDiscounts);

                    sum += multiplicator * skuDiscount.Item2 + skusCountWithoutDiscounts * item.Value.Item3;
                }
                else
                {
                    sum += item.Value.Item2;
                }
            }

            return (double)sum;
        }
    }
}