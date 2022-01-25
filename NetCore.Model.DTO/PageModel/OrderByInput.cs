using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Model.DTO.PageModel
{
    /// <summary>
    /// 排序
    /// </summary>
    public class OrderByInput
    {
        /// <summary>
        /// 是否倒排序，false：表示正序，true：表示倒序
        /// </summary>
        public virtual bool IsDescending { get; set; }
        /// <summary>
        /// 排序字段名
        /// </summary>
        public virtual string PropertyName { get; set; } = "Id";
    }
}
