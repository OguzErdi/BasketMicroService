using Basket.Core.Entites;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Basket.Infrastructure.UnitTests.TestData
{
    public class AddItemToBasket_ValidBasketItem_ReturnTrue_TestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new BasketItem() { Color = "Red", Price = 10.1M, ProductId = "12", ProductName = "Çiçek", Quantity = 1, UserName = "erdi" } };
            yield return new object[] { new BasketItem() { Color = "Purple", Price = 8.1M, ProductId = "32", ProductName = "Böcek", Quantity = 2, UserName = "emre" } };
            yield return new object[] { new BasketItem() { Color = "Yellow", Price = 9.1M, ProductId = "14", ProductName = "Saksı", Quantity = 3, UserName = "enes" } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
