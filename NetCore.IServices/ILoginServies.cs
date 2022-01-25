using NetCore.Model.DTO.Response;
using System;
using NetCore.Model.DTO.SystemModels;

namespace NetCore.IServices
{
    public interface ILoginServices : IDependency
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public Response<LoginResponseOutput> Login(LoginRequestInput req);
    }
}
