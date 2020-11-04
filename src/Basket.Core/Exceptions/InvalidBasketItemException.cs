using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Core.Exceptions
{
    public class InvalidBasketItemException : Exception
    {
        internal InvalidBasketItemException(string businessMessage)
            : base(businessMessage)
        {
        }

        internal InvalidBasketItemException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
