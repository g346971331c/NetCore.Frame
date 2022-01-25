using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Infrastructure.cache
{
    public interface ICacheContext
    {
        public abstract T Get<T>(string key);

        public abstract bool Set<T>(string key, T t, DateTime expire);

        public abstract bool Remove(string key);
    }
}
