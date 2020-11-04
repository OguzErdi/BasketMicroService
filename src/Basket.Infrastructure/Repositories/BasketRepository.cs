using Basket.Core.Entites;
using Basket.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Infrastructure.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        public Task<bool> AddItemToBasket(BasketItem basketCartItem)
        {
            throw new NotImplementedException();
        }
    }
}
