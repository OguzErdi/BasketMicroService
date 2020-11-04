using Basket.Core.Exceptions;
using FluentValidation;
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
        public int ProductId { get; set; }
        //denormalize the table for higher perfromance
        public string ProductName { get; set; }
    }

    public class BasketItemValidator : AbstractValidator<BasketItem>
    {
        public BasketItemValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().OnAnyFailure(request => throw new InvalidBasketItemException($"{nameof(request.UserName)} paramater is invalid"));
            RuleFor(x => x.Quantity).GreaterThan(0).OnAnyFailure(request => throw new InvalidBasketItemException($"{nameof(request.Quantity)} paramater is invalid"));
            RuleFor(x => x.Price).GreaterThan(0).OnAnyFailure(request => throw new InvalidBasketItemException($"{nameof(request.Price)} paramater is invalid"));
            RuleFor(x => x.ProductId).GreaterThan(0).OnAnyFailure(request => throw new InvalidBasketItemException($"{nameof(request.ProductId)} paramater is invalid"));
            RuleFor(x => x.ProductName).NotEmpty().OnAnyFailure(request => throw new InvalidBasketItemException($"{nameof(request.ProductName)} paramater is invalid"));
        }
    }
}
