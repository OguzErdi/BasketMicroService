using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Application.Models
{
    public class BasketItemModel
    {
        public string UserName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
