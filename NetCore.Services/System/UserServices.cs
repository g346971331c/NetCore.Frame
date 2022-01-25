using AutoMapper;
using NetCore.Infrastructure;
using NetCore.IServices.System;
using NetCore.Model.DTO.Response;
using NetCore.Model.DTO.SystemModels.User;
using NetCore.Repository.Entitys.Systems;
using NetCore.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Services.System
{
    public class UserServices : BaseServices<User>, IUserServices
    {
        public UserServices(IRespository<User> Respository) : base(Respository)
        {
        }

        public async Task<Response> Add(AddUserInput input)
        {
            var result = new Response();
            try
            {
                var user = input.MapTo<User>();
                await Respository.AddAsync(user);
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        public async Task<Response> Update(UpdateUserInput input)
        {
            var result = new Response();

            return result;
        }

        public Response<List<GetUserListOutput>> GetUserList(GetUserListInput input)
        {
            var result = new Response<List<GetUserListOutput>>();
            try
            {
                var list = Respository.Find(m => m.UserName.Contains("1"));

                list.OrderBy(m => m.UserName).Skip((1 - 1) * 10).Take(10);
                if (list != null)
                {
                    result.Result = list.Select(a => new GetUserListOutput
                    {
                        Id = a.Id,
                        UserName = a.UserName,
                        AppId = a.AppId,
                        Password = a.Password
                    }).ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }

        /// <summary>
        /// 获取用户分页
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Response<GetUserListByPageOutput> GetUserListPage(GetUserListByPageInput input)
        {
            var result = new Response<GetUserListByPageOutput>();
            var items = new GetUserListByPageOutput();
            try
            {
                var list = Respository.Find(null);

                if (list != null)
                {
                    items.Items = list.Select(a => new UserOutput
                    {
                        Id = a.Id,
                        UserName = a.UserName,
                        AppId = a.AppId,
                        Password = a.Password
                    }).Page(input);
                    result.Result = items;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }

        /// <summary>
        /// 获取分页记录（异步）
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<Response<GetUserListByPageOutput>> GetUserListPageAsync(GetUserListByPageInput input)
        {
            var result = new Response<GetUserListByPageOutput>();
            var items = new GetUserListByPageOutput();
            try
            {
                var list = await Respository.FindAsync(null);

                if (list != null)
                {
                    items.Items = list.Select(a => new UserOutput
                    {
                        Id = a.Id,
                        UserName = a.UserName,
                        AppId = a.AppId,
                        Password = a.Password
                    }).Page(input);
                    result.Result = items;
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }

    }
}
