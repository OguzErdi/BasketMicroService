using System.Threading.Tasks;

namespace Basket.Core.Providers
{
    public interface IStockProvider
    {
        Task<bool> IsInStock(int productId, string Color, int quantity);
    }
}