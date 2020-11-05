using Basket.Application.Exceptions;
using FluentValidation;
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

        public class BasketItemValidator : AbstractValidator<BasketItemModel>
        {
            public BasketItemValidator()
            {
                RuleFor(x => x.UserName).NotEmpty().OnAnyFailure(request => throw new InvalidBasketItemModelException($"{nameof(request.UserName)} paramater is invalid"));
                RuleFor(x => x.Quantity).GreaterThan(0).OnAnyFailure(request => throw new InvalidBasketItemModelException($"{nameof(request.Quantity)} paramater is invalid"));
                RuleFor(x => x.Price).GreaterThan(0).OnAnyFailure(request => throw new InvalidBasketItemModelException($"{nameof(request.Price)} paramater is invalid"));
                RuleFor(x => x.ProductId).GreaterThan(0).OnAnyFailure(request => throw new InvalidBasketItemModelException($"{nameof(request.ProductId)} paramater is invalid"));
                RuleFor(x => x.ProductName).NotEmpty().OnAnyFailure(request => throw new InvalidBasketItemModelException($"{nameof(request.ProductName)} paramater is invalid"));
            }
        }
    }
}
