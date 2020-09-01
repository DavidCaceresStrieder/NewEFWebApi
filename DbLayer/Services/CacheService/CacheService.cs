using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLayer.Services.CacheService
{
    public class CacheService
    {
        private IMemoryCache _cache;
        public CacheService(IMemoryCache memoryCache)
        {
            this._cache = memoryCache;
        }


        public string CacheTryGetValueSet(string KeyValue)
        {
            string cacheEntry;

            // Look for cache key.
            if (!_cache.TryGetValue(KeyValue, out cacheEntry))
            {
                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(3));

                // Save data in cache.
                _cache.Set(KeyValue, cacheEntry, cacheEntryOptions);
            }

            return cacheEntry;
        }


    }
}
