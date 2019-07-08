using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheOne.Model.Blogs.ViewModel
{
    public class ReplyModel
    {
        public virtual string id { get; set; }

        /// <summary>
        /// 回复时间
        /// </summary>
        public virtual DateTime? 回复时间 { get; set; }
        /// <summary>
        /// 回复内容
        /// </summary>
        public virtual string 回复内容 { get; set; }

    }
}
