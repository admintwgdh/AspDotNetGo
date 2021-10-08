using System;
using System.Collections.Generic;
using System.Text;

namespace AspDotNetGo.Model.ApiResultHelper
{
    public class ApiResult
    {
        public int Status { get; set; }
        public string Msg { get; set; }
        public object Datas { get; set; }
        public long Total { get; set; }
    }
    
}
