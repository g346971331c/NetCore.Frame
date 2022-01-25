using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Model.DTO.SystemModels
{
    public class LoginRequestInput
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// AppId
        /// </summary>
        public string AppId { get; set; }
    }
}
