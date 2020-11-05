using Basket.Application.Exceptions;
using Basket.Application.Models;
using Basket.Application.Services;
using Basket.Application.UnitTests.TestData;
using Basket.Core.Entites;
using Basket.Core.Providers;
using Basket.Core.Repositories;
using FluentValidation;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Basket.Application.Models.BasketItemModel;

namespace Basket.Application.UnitTests.Services
{
    public class BasketServiceTest
    {
        private readonly Mock<IBasketRepository> _mockBasketRepository;
        private readonly Mock<IStockProvider> _mockStockProvider;
        private readonly IValidator<BasketItemModel> _validator;

        public BasketServiceTest()
        {
            _mockBasketRepository = new Mock<IBasketRepository>();
            _mockStockProvider = new Mock<IStockProvider>();
            //to test real validator
            _validator = new BasketItemModelValidator();
        }

        [Theory]
        [ClassData(typeof(AddItemToBasket_ValidBasketItem_ReturnTrue))]
        public async Task AddItemToBasket_ValidBasketItem_ReturnTrue(BasketItemModel basketItemModel)
        {
            //arrange
            _mockBasketRepository.Setup(x => x.AddItemToBasket(It.IsAny<BasketItem>())).ReturnsAsync(true);
            _mockStockProvider.Setup(x => x.IsInStock(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(true);
            var basketService = new BasketService(_mockBasketRepository.Object, _mockStockProvider.Object, _validator);

            //act
            var result = await basketService.AddItemToBasket(basketItemModel);

            //assert
            Assert.True(result);
            _mockBasketRepository.Verify(x => x.AddItemToBasket(It.IsAny<BasketItem>()), Times.Once);
            _mockStockProvider.Verify(x => x.IsInStock(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>()), Times.Once);
        }

        [Theory]
        [ClassData(typeof(AddItemToBasket_ValidBasketItem_ReturnTrue))]
        public async Task AddItemToBasket_OutOfStockItem_ReturnFalse(BasketItemModel basketItemModel)
        {
            //arrange
            _mockStockProvider.Setup(x => x.IsInStock(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>()))
                .Returns((int productId, string color, int quantity) =>
                {
                    if (productId == 123 && color == "Red" && quantity < 10)
                    {
                        return Task.FromResult(true);
                    }

                    return Task.FromResult(false);
                }
            );

            var basketService = new BasketService(_mockBasketRepository.Object, _mockStockProvider.Object, _validator);

            //act
            var result = await basketService.AddItemToBasket(basketItemModel);

            //assert
            Assert.False(result);
            _mockBasketRepository.Verify(x => x.AddItemToBasket(It.IsAny<BasketItem>()), Times.Once);
            _mockStockProvider.Verify(x => x.IsInStock(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>()), Times.Once);
        }

        [Theory]
        [ClassData(typeof(AddItemToBasket_InvalidBasket_InvalidBasketItemException))]
        public async Task AddItemToBasket_InvalidBasket_InvalidBasketItemException(BasketItemModel basketItemModel)
        {
            //arrange
            _mockStockProvider.Setup(x => x.IsInStock(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync(true);
            var basketService = new BasketService(_mockBasketRepository.Object, _mockStockProvider.Object, _validator);

            //act & assert
            await Assert.ThrowsAsync<InvalidBasketItemModelException>(() => basketService.AddItemToBasket(basketItemModel));
            _mockStockProvider.Verify(x => x.IsInStock(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>()), Times.Never);
            _mockBasketRepository.Verify(x => x.AddItemToBasket(It.IsAny<BasketItem>()), Times.Never);
        }
    }
}
