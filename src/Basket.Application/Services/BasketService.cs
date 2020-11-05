using Basket.Application.Interfaces;
using Basket.Application.Mapper;
using Basket.Application.Models;
using Basket.Core.Entites;
using Basket.Core.Providers;
using Basket.Core.Repositories;
using FluentValidation;
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
        private readonly IValidator<BasketItemModel> _validator;

        public BasketService(IBasketRepository repository, IStockProvider stockProvider, IValidator<BasketItemModel> validator)
        {
            _repository = repository;
            _stockProvider = stockProvider;
            _validator = validator;
        }

        public async Task<bool> AddItemToBasket(BasketItemModel basketItemModel)
        {
            _validator.Validate(basketItemModel);

            var mapped = ObjectMapper.Mapper.Map<BasketItem>(basketItemModel);
            if (mapped == null)
            {
                throw new ApplicationException($"Entity could not be mapped.");
            }

            var isInStock = await _stockProvider.IsInStock(basketItemModel.ProductId, basketItemModel.Color, basketItemModel.Quantity);
            if (!isInStock)
            {
                return false;
            }

            return await _repository.AddItemToBasket(mapped);
        }
    }
}
