using Basket.Core.Data;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Infrastructure.Data
{
    public class BasketDbContext : IBasketDbContext
    {
        //to craete connection with redis db
        private readonly ConnectionMultiplexer _redisConnection;

        //get ConnectionMultiplexer via Dependency Injection
        public BasketDbContext(ConnectionMultiplexer redisConnection)
        {
            _redisConnection = redisConnection;
            Redis = _redisConnection.GetDatabase();
        }

        public IDatabase Redis { get; }
    }
}
