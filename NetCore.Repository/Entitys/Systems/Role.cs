using NetCore.Repository.BaseEntitys;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NetCore.Repository.Entitys.Systems
{

    /// <summary>
    /// 角色表
    /// </summary>
    [Table("Role")]
    public class Role : EntityBase
    {
        /// <summary>
        /// 角色名称
        /// </summary>
        [Column("RoleName")]
        public string RoleName { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        [Column("Description")]
        public string Description { get; set; }
    }
}
