using AutoMapper;
using Basket.API.Controllers;
using Basket.API.UnitTests.Datas;
using Basket.API.ViewModels;
using Basket.Application.Interfaces;
using Basket.Application.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Basket.API.UnitTests.Controllers
{
    public class BasketControllerTest
    {
        private readonly Mock<IBasketService> _mockBasketService;
        private readonly Mock<IMapper> _mockMapper;

        public BasketControllerTest()
        {
            _mockBasketService = new Mock<IBasketService>();
            _mockMapper = new Mock<IMapper>();
        }

        [Theory]
        [ClassData(typeof(PostBasketCartItem_ValidBasketItem_ReturnTrue))]
        public async Task PostBasketCartItem_ValidBasketItem_ReturnTrue(BasketItemViewModel basketItemModel)
        {
            //arrange
            _mockBasketService.Setup(x => x.AddItemToBasket(It.IsAny<BasketItemModel>())).ReturnsAsync(true);
            var basketController = new BasketController(_mockBasketService.Object, _mockMapper.Object);

            //act
            var result = await basketController.PostBasketCartItem(basketItemModel);

            //assert
            Assert.True(result.Value);
            _mockBasketService.Verify(x => x.AddItemToBasket(It.IsAny<BasketItemModel>()), Times.Once);
        }

        [Theory]
        [ClassData(typeof(PostBasketCartItem_ValidBasketItem_ReturnTrue))]
        public async Task PostBasketCartItem_OutOfStockItem_ReturnFalse(BasketItemViewModel basketItemModel)
        {
            //arrange
            _mockBasketService.Setup(x => x.AddItemToBasket(It.IsAny<BasketItemModel>()))
                .Returns((BasketItemModel basketItemModel) =>
                {
                    if (basketItemModel.ProductId == 123 && basketItemModel.Color == "Red" && basketItemModel.Quantity < 10)
                    {
                        return Task.FromResult(true);
                    }

                    return Task.FromResult(false);
                }
            );

            var basketService = new BasketController(_mockBasketService.Object, _mockMapper.Object);

            //act
            var result = await basketService.PostBasketCartItem(basketItemModel);

            //assert
            Assert.False(result.Value);
            _mockBasketService.Verify(x => x.AddItemToBasket(It.IsAny<BasketItemModel>()), Times.Once);
        }

        [Theory]
        [ClassData(typeof(PostBasketCartItem_InvalidBasket_InvalidBasketItemException))]
        public async Task PostBasketCartItem_InvalidBasket_InvalidBasketItemException(BasketItemViewModel basketItemModel)
        {
            //arrange
            var basketController = new BasketController(_mockBasketService.Object, _mockMapper.Object);

            //act & assert
            await Assert.ThrowsAsync<ArgumentException>(() => basketController.PostBasketCartItem(basketItemModel));
        }
    }
}
