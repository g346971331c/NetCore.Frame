using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Model.DTO.PageModel
{
    public class PagingCollection<T>
    {
        /// <summary>
        /// 结果列表
        /// </summary>
        public virtual ICollection<T> Items { get; set; }

        /// <summary>
        /// 总数
        /// </summary>
        public virtual int Count { get; set; }

        /// <summary>
        /// 每页条目数
        /// </summary>
        public virtual int Size { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        public virtual int Number { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public virtual OrderByInput[] Sorts { get; set; }
    }
}
