using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NetCore.Infrastructure.cache;
using NetCore.IServices;
using NetCore.Model.DTO.Response;
using NetCore.Model.DTO.SystemModels;
using NetCore.Repository;
using NetCore.Repository.Entitys.Systems;
using NetCore.Repository.Interface;
using System;

namespace NetCore.Services.BaseInfo
{
    public class LoginServices : BaseServices<User>, ILoginServices
    {
        private readonly ICacheContext _cacheContext;
        private readonly ILogger<LoginServices> _iLogger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginServices(IRespository<User> respository, ICacheContext cacheContext, ILogger<LoginServices> logger,
            IHttpContextAccessor httpContextAccessor) : base(respository)
        {
            _cacheContext = cacheContext;
            _iLogger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public Response<LoginResponseOutput> Login(LoginRequestInput req)
        {
            var result = new Response<LoginResponseOutput>();
            try
            {
                var isExist = Respository.FindSingle(m => m.UserName == req.UserName &&
                m.Password == req.Password && m.AppId == req.AppId);
                if (isExist != null)
                {
                    //登录成功 
                    var currentSession = new UserAuthSession
                    {
                        UserName = req.UserName,
                        AppId = req.AppId,
                        Token = Guid.NewGuid().ToString().GetHashCode().ToString("x"),
                        CreateTime = DateTime.Now,
                        IpAddress = ""
                    };
                    _cacheContext.Set<UserAuthSession>(currentSession.Token, currentSession, DateTime.Now.AddDays(10));
                    _iLogger.LogInformation("登录信息写入Session成功");
                    var response = new LoginResponseOutput();
                    response.Token = currentSession.Token;

                    result.Result = response;

                }
                else
                {
                    result.Message = "登录失败，请检查用户名或者密码是否正确";
                    result.Result = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

            return result;
        }

        public bool CheckLogin(string token = "", string other = "")
        {
            UserAuthSession userAuthSession;
            if (!string.IsNullOrEmpty(token))
            {
                userAuthSession = _cacheContext.Get<UserAuthSession>(token);
                if (userAuthSession != null)
                    return true;
            }
            else
            {
                token = GetToken();
                if (!string.IsNullOrEmpty(token))
                {
                    userAuthSession = _cacheContext.Get<UserAuthSession>(token);
                    if (userAuthSession != null)
                        return true;
                }
            }
            return false;
        }

        public string GetToken()
        {
            string token = string.Empty;
            token = _httpContextAccessor.HttpContext.Request.Headers["X-token"];
            if (!string.IsNullOrEmpty(token)) return token;
            token = _httpContextAccessor.HttpContext.Request.Query["X-token"];
            if (!string.IsNullOrEmpty(token)) return token;
            token = _httpContextAccessor.HttpContext.Request.Cookies["X-token"];
            if (!string.IsNullOrEmpty(token)) return token;
            return token;
        }

    }
}
