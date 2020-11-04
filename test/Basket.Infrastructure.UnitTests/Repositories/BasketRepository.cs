using Basket.Core.Entites;
using Basket.Infrastructure.UnitTests.TestData;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Basket.Infrastructure.UnitTests.Repositories
{
    public class BasketRepository
    {
        [Theory]
        [ClassData(typeof(AddItemToBasket_ValidBasketItem_ReturnTrue_TestData))]
        public void AddItemToBasket_ValidBasketItem_ReturnTrue(BasketItem basketItem)
        {
            //arrange

            //act

            //assert
        }
    }
}
