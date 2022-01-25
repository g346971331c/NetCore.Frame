using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Frame.Filter
{
    /// <summary>
    /// 全局过滤器
    /// </summary>
    public class GlobalHttpHeaderOperationFilter : IOperationFilter
    {
        private IConfiguration _configuration { get; set; }

        public GlobalHttpHeaderOperationFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            //如果配置认证地址，则不执行下面的验证
            if (_configuration.GetSection("Appsetting.IdentityServerUrl").Value != "")
            {
                return;
            }
            var actionAttrs = context.ApiDescription.ActionDescriptor.EndpointMetadata;
            //判断当前拦截器对应控制器里的方法里是否有AllowAnonymousAttribute特性，如果有该特性，则不添加x-token 公共参数
            var isAnonymous = actionAttrs.Any(a => a.GetType() == typeof(AllowAnonymousAttribute));
            if (!isAnonymous) //不包含，则添加
            {
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "X-token",//新加参数注释名称
                    In = ParameterLocation.Header,//参数来源，此处定义为从Http头
                    Description = "当前用户登录token",
                    Required = false
                });
            }
        }
    }
}
