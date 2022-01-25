using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Model.DTO.SystemModels
{
    /// <summary>
    /// 登录成功输出类
    /// </summary>
    public class LoginResponseOutput
    {
        /// <summary>
        /// 登录token
        /// </summary>
        public string Token { get; set; }
    }
}
