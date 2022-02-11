using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using NetCore.IServices;
using NetCore.Model.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace NetCore.Frame.Filter
{
    /// <summary>
    /// 控制器方法过滤器
    /// </summary>
    public class ApiFilter : IActionFilter
    {
        private readonly ILoginServices _loginServices;
        private readonly IConfiguration _configuration;

        public ApiFilter(IConfiguration configuration, ILoginServices loginServies)
        {
            _loginServices = loginServies;
            _configuration = configuration;
        }

        /// <summary>
        /// 控制器方法调用后执行
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        /// <summary>
        /// 控制器方法调用前执行
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var descrip = (Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor;
            var allowAnoy = descrip.MethodInfo.GetCustomAttributes(inherit: true).OfType<AllowAnonymousAttribute>().Any();
            if (allowAnoy) //允许匿名访问
                return;
            //没有匿名特性，则要验证是否登录
            if (!_loginServices.CheckLogin())//TODO
            {
                context.HttpContext.Response.StatusCode = 401;
                context.Result = new JsonResult(new Response
                {
                    Code = 401,
                    Message = "Token验证失败，请登录"

                }); ;
            }
        }
    }
}
