﻿using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Core.Data
{
    public interface IBasketDbContext
    {
        IDatabase Redis { get; }
    }
}
