using Basket.Application.Interfaces;
using Basket.Application.Mapper;
using Basket.Application.Models;
using Basket.Core.Entites;
using Basket.Core.Providers;
using Basket.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Basket.Application.Models.BasketItemModel;

namespace Basket.Application.Services
{
    public class BasketService: IBasketService
    {
        private readonly IBasketRepository _repository;
        private readonly IStockProvider _stockProvider;

        public BasketService(IBasketRepository repository, IStockProvider stockProvider)
        {
            _repository = repository;
            _stockProvider = stockProvider;
        }

        public async Task<bool> AddItemToBasket(BasketItemModel basketCartItemModel)
        {
            var validator = new BasketItemValidator();
            validator.Validate(basketCartItemModel);

            var mapped = ObjectMapper.Mapper.Map<BasketItem>(basketCartItemModel);
            if (mapped == null)
            {
                throw new ApplicationException($"Entity could not be mapped.");
            }

            var isInStock = await _stockProvider.IsInStock(basketCartItemModel.ProductId, basketCartItemModel.Color, basketCartItemModel.Quantity);
            if (!isInStock)
            {
                return false;
            }

            return await _repository.AddItemToBasket(mapped);
        }
    }
}
