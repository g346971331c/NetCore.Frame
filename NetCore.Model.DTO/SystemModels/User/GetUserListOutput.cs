using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Model.DTO.SystemModels.User
{
    /// <summary>
    ///获取用户列表出参
    /// </summary>
    public class GetUserListOutput
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string AppId { get; set; }
    }
}
