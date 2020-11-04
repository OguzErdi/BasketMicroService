using Basket.Core.Data;
using Basket.Core.Entites;
using Basket.Core.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Infrastructure.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IBasketDbContext _context;

        public BasketRepository(IBasketDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddItemToBasket(BasketItem basketItem)
        {
            string jsonBasketItem = JsonConvert.SerializeObject(basketItem);
            var isAdded = await _context.Redis.StringSetAsync(basketItem.UserName, jsonBasketItem);

            if (!isAdded)
            {
                return false;
            }

            return true;
        }
    }
}
