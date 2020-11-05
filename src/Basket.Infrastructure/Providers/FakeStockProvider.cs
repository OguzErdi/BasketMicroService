using Basket.Core.Providers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Basket.Infrastructure.Providers
{
    public class FakeStockProvider : IStockProvider
    {
        public Task<bool> IsInStock(int productId, string color, int quantity)
        {
            return Task.FromResult(true);
        }
    }
}
