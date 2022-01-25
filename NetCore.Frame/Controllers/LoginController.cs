using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NetCore.IServices;
using NetCore.Model.DTO.Response;
using NetCore.Model.DTO.SystemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Frame.Controllers
{
    /// <summary>
    /// 登录相关控制器
    /// </summary>
    [Route("/api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginServices _loginServices;
        private readonly ILogger<LoginController> _iLogger;

        public LoginController(ILoginServices loginServies, ILogger<LoginController> logger)
        {
            _loginServices = loginServies;
            _iLogger = logger;
        }


        /// <summary>
        /// 测试接口
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<Response<LoginResponseOutput>> Login([FromBody]LoginRequestInput req)
        {
            var response = new Response<LoginResponseOutput>();
            try
            {
                _iLogger.LogInformation("登录接口");
                _iLogger.LogDebug("Debug日志");
                response = _loginServices.Login(req);
            }
            catch (Exception ex)
            {
                _iLogger.LogError("登录接口异常：" + ex.Message);
                response.Code = 500;
                response.Message = "登录异常，" + ex.Message;
            }
            return response;
        }
    }
}
