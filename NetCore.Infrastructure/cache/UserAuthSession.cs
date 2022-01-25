using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Infrastructure.cache
{
    /// <summary>
    /// Session缓存对象
    /// </summary>
    public class UserAuthSession
    {
        /// <summary>
        /// 登录后得到的token值
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// AppId
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 登录用户名
        /// </summary>
        public string UserName { get; set; }
         

        public string IpAddress { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
