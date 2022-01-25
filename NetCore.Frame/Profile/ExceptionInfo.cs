using NetCore.Model.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Frame.Profile
{
    public static class ExceptionInfo
    {
        /// <summary>
        /// 异常处理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="res"></param>
        /// <param name="ex"></param>
        public static void CatchExp(ref Response res, Exception ex)
        {
            res.Code = 500;
            res.Message = "接口内部错误，请查看相关日志文件";
            Console.WriteLine(ex.Message);
        }
    }
}
