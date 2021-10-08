using System;
using System.Collections.Generic;
using System.Text;

namespace AspDotNetGo.Model.ApiResultHelper
{
    public static class ApiResultHelper
    {
        public static ApiResult Success()
        {
            return new ApiResult()
            {
                Status = 200,
            };
        }
        public static ApiResult Success(object data, string msg = "")
        {
            return new ApiResult()
            {
                Status = 200,
                Datas = data,
                Msg = msg
            };
        }
        public static ApiResult Success(object data, long total, string msg = "")
        {
            return new ApiResult()
            {
                Status = 200,
                Datas = data,
                Total = total,
                Msg = msg
            };
        }
        public static ApiResult Failure(string errMsg)
        {
            return new ApiResult()
            {
                Status = 500,
                Msg = errMsg,
            };
        }
    }
}
