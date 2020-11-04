using Basket.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Application.Interfaces
{
    public interface IBasketService
    {
        Task<bool> AddItemToBasket(BasketItemModel basketCartItemModel);
    }
}