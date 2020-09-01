using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CoreLayer.Services.Redis
{
    public class RedisService : IRedisService 
    {
        private Lazy<ConnectionMultiplexer> _lazyConnection;        
        public RedisService(IConfiguration Configuration)
        {
            if (this._lazyConnection.IsValueCreated)
            {
                _lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
                {
                    return ConnectionMultiplexer.Connect(Configuration["RedisHost"]);
                });                
            }            
        }

        public string ReadData(string Key)
        {
            var cache = _lazyConnection.Value.GetDatabase();                        
            
            var value = cache.StringGet(Key);
            return value;
            
        }

        public bool SaveData(string key,string value)
        {
            try
            {
                var cache = _lazyConnection.Value.GetDatabase();
                cache.StringSet(key, value);

                return true;
            } catch (Exception e)
            {
                //Log 
                return false;
            }
        }
    }
}
