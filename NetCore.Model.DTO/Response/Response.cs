using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Model.DTO.Response
{
    public class Response
    {
        public Response()
        {
            Message = "操作成功";
            Code = 200;
        }

        public string Message { get; set; }

        public int Code { get; set; }

    }

    public class Response<T> : Response
    {
        public T Result { get; set; }
    }
}
