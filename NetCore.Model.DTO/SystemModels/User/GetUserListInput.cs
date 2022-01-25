using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Model.DTO.SystemModels.User
{
    /// <summary>
    /// 查询用户列表输入参数
    /// </summary>
    public class GetUserListInput
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// AppId
        /// </summary>
        public string AppId { get; set; }
    }
}
