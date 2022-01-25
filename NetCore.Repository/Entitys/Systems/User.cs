using NetCore.Repository.BaseEntitys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NetCore.Repository.Entitys.Systems
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Table("User")]
    public class User : EntityBase
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Column("UserName")]
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Column("Password")]

        public string Password { get; set; }

        [Column("AppId")]
        public string AppId { get; set; }

    }
}
