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
            var basketItemList = await GetBasketItemListAsync(basketItem.UserName);
            if (basketItemList == null)
            {
                basketItemList = new List<BasketItem>();
            }
            basketItemList.Add(basketItem);

            string jsonBasketIteList = JsonConvert.SerializeObject(basketItemList);

            var isAdded = await _context.Redis.StringSetAsync(basketItem.UserName, jsonBasketIteList);

            if (!isAdded)
            {
                return false;
            }

            return true;
        }

        public async Task<List<BasketItem>> GetBasketItemListAsync(string userName)
        {
            var basketItemList =  await _context.Redis.StringGetAsync(userName);

            if (basketItemList.IsNullOrEmpty)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<List<BasketItem>>(basketItemList);
        }
    }
}
