using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NetCore.Repository.BaseEntitys
{
    /// <summary>
    /// 实体类基类
    /// </summary>
    public class EntityBase
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Browsable(false)]
        public string Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        //public DateTime CreateTime { get; set; }

        ///// <summary>
        ///// 创建人
        ///// </summary>
        //public string Creator { get; set; }

        ///// <summary>
        ///// 更新时间
        ///// </summary>
        //public DateTime UpdateTime { get; set; }

        ///// <summary>
        ///// 更新人
        ///// </summary>
        //public string Updator { get; set; }

        public EntityBase()
        {
            //该属性不需要外部赋值
            Id = Guid.NewGuid().ToString();
        }
    }
}
