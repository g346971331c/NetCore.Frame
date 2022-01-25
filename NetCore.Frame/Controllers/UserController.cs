using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCore.Frame.Profile;
using NetCore.IServices.System;
using NetCore.Model.DTO.Response;
using NetCore.Model.DTO.SystemModels.User;

namespace NetCore.Frame.Controllers
{
    /// <summary>
    /// 用户管理
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userService;
        public UserController(IUserServices userServices)
        {
            _userService = userServices;
        }

        /// <summary>
        /// 用户列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public Response<List<GetUserListOutput>> GetUserList(GetUserListInput input)
        {
            var result = new Response<List<GetUserListOutput>>();
            try
            {
                result = _userService.GetUserList(input);
            }
            catch (Exception ex)
            {
                result.Code = 500;
                result.Message = ex.Message;
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        /// <summary>
        /// 用户分页列表
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public Response<GetUserListByPageOutput> GetUserPageList(GetUserListByPageInput input)
        {
            var result = new Response<GetUserListByPageOutput>();
            try
            {
                result = _userService.GetUserListPage(input);
            }
            catch (Exception ex)
            {
                result.Code = 500;
                result.Message = ex.Message;
                Console.WriteLine(ex.Message);
            }
            return result;
        }


        /// <summary>
        /// 获取分页数据（异步）
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns> 
        [HttpPost]
        public async Task<Response<GetUserListByPageOutput>> GetAsyncUserPageList(GetUserListByPageInput input)
        {
            var result = new Response<GetUserListByPageOutput>();
            try
            {
                result = await _userService.GetUserListPageAsync(input);
            }
            catch (Exception ex)
            {
                result.Code = 500;
                result.Message = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Response> Add(AddUserInput input)
        {
            var result = new Response();
            try
            {
                result = await _userService.Add(input);
            }
            catch (Exception ex)
            {
                ExceptionInfo.CatchExp(ref result, ex);
            }
            return result;
        }
    }
}