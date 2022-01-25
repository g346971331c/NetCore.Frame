using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Infrastructure.cache
{
    /// <summary>
    /// 设置内存缓存
    /// </summary>
    public class CacheContext : ICacheContext
    {
        private IMemoryCache _memoryCache;
        public CacheContext(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// 根据key获取缓存对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(string key)
        {
            _memoryCache.Remove(key);
            return true;
        }

        /// <summary>
        /// 设置缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="t"></param>
        /// <param name="expire"></param>
        /// <returns></returns>
        public bool Set<T>(string key, T t, DateTime expire)
        {
            try
            {
                var obj = _memoryCache.Get<T>(key);
                if (obj != null)
                    Remove(key);

                _memoryCache.Set<T>(key, t, new MemoryCacheEntryOptions().SetAbsoluteExpiration(expire));
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("缓存设置失败：" + ex.Message);
                return false;
            }
        }
    }
}
