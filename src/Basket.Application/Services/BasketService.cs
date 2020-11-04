using Basket.Application.Interfaces;
using Basket.Application.Models;
using Basket.Core.Entites;
using Basket.Core.Providers;
using Basket.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Services
{
    public class BasketService: IBasketService
    {
        private IBasketRepository _repository;

        public BasketService(IBasketRepository repository, IStockProvider stockProvider)
        {
            _repository = repository;
        }

        public Task<bool> AddItemToBasket(BasketItemModel basketCartItemModel)
        {
            throw new NotImplementedException();
        }
    }
}
