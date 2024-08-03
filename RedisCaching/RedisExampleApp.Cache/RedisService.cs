using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using StackExchange.Redis;
namespace RedisExampleApp.Cache
{
    public class RedisService
    {
        private readonly ConnectionMultiplexer _connectionMultiplexer ;


        public RedisService(string url  )
        {
            _connectionMultiplexer = ConnectionMultiplexer.Connect(url);
        }
    }
}
