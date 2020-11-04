using Basket.API.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Basket.API.UnitTests.Datas
{
    public class PostBasketCartItem_ValidBasketItem_ReturnTrue : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new BasketItemViewModel() { Color = "Red", Price = 1.1M, ProductId = 123, ProductName = "T-Shirt", Quantity = 1, UserName = "Erdi" } };
            yield return new object[] { new BasketItemViewModel() { Color = "Red", Price = 1.1M, ProductId = 123, ProductName = "T-Shirt", Quantity = 9, UserName = "Erdi" } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class PostBasketCartItem_OutOfStockItem_ReturnFalse : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new BasketItemViewModel() { Color = "Red", Price = 1.1M, ProductId = 123, ProductName = "T-Shirt", Quantity = 10, UserName = "Erdi" } };
            yield return new object[] { new BasketItemViewModel() { Color = "Red", Price = 1.1M, ProductId = 123, ProductName = "T-Shirt", Quantity = 100, UserName = "Erdi" } };
            yield return new object[] { new BasketItemViewModel() { Color = "Blue", Price = 1.1M, ProductId = 123, ProductName = "T-Shirt", Quantity = 1, UserName = "Erdi" } };
            yield return new object[] { new BasketItemViewModel() { Color = "Red", Price = 1.1M, ProductId = 111, ProductName = "T-Shirt", Quantity = 10, UserName = "Erdi" } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    public class PostBasketCartItem_InvalidBasket_InvalidBasketItemException : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new BasketItemViewModel() { Color = "Red", Price = 0, ProductId = 123, ProductName = "T-Shirt", Quantity = 1, UserName = "Erdi" } };
            yield return new object[] { new BasketItemViewModel() { Color = "Red", Price = 1.1M, ProductId = 0, ProductName = "T-Shirt", Quantity = 1, UserName = "Erdi" } };
            yield return new object[] { new BasketItemViewModel() { Color = "Red", Price = 1.1M, ProductId = 123, ProductName = null, Quantity = 1, UserName = "Erdi" } };
            yield return new object[] { new BasketItemViewModel() { Color = "Red", Price = 1.1M, ProductId = 123, ProductName = "T-Shirt", Quantity = 0, UserName = null } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
