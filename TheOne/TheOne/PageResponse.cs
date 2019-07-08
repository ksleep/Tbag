using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheOne
{
    public class PageResponse
    {
        public PageResponse(long Count, dynamic Data, int Code = 0, string Msg = "")
        {
            count = Count;
            data = Data;
            code = Code;
            msg = Msg;
        }

        /// <summary>
        /// 状态码 默认为0 非必填
        /// </summary>
        public int code { get; set; } = 0;

        /// <summary>
        /// 消息
        /// </summary>
        public string msg { get; set; } = "";

        public long count { get; set; }

        public dynamic data { get; set; }
    }
}
