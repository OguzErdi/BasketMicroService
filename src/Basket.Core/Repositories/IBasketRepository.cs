using Basket.Core.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Core.Repositories
{
    public interface IBasketRepository
    {
        Task<bool> AddItemToBasket(BasketItem basketCartItem);
    }
}
