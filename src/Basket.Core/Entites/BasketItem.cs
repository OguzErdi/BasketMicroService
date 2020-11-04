using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Core.Entites
{
    public class BasketItem
    {
        public string UserName { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string ProductId { get; set; }
        //denormalize the table for higher perfromance
        public string ProductName { get; set; }
    }
}
