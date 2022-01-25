using NetCore.Model.DTO.Response;
using NetCore.Model.DTO.SystemModels.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.IServices.System
{
    public interface IUserServices : IDependency
    {
        Response<List<GetUserListOutput>> GetUserList(GetUserListInput input);

        Response<GetUserListByPageOutput> GetUserListPage(GetUserListByPageInput input);

        Task<Response<GetUserListByPageOutput>> GetUserListPageAsync(GetUserListByPageInput input);

        Task<Response> Add(AddUserInput input);

        Task<Response> Update(UpdateUserInput input);
    }
}
