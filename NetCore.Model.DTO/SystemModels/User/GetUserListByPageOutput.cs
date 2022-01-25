using NetCore.Model.DTO.PageModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Model.DTO.SystemModels.User
{
    public class GetUserListByPageOutput
    {
        public PagingCollection<UserOutput> Items { get; set; }
    }

    public class UserOutput
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string AppId { get; set; }
    }
}
