using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Application.Exceptions
{
    public class InvalidBasketItemModelException : Exception
    {
        internal InvalidBasketItemModelException(string businessMessage)
            : base(businessMessage)
        {
        }

        internal InvalidBasketItemModelException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
