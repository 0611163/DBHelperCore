using System;
using System.Collections.Generic;
using System.Linq;
using DBUtil;

namespace Models
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Serializable]
    [DBTable("sys_user")]
    public partial class SysUser
    {

        /// <summary>
        /// 主键
        /// </summary>
        [DBKey]
        [DBField]
        public long Id { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        [DBField("UserName")]
        public string UserName { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        [DBField]
        public string RealName { get; set; }

        /// <summary>
        /// 用户密码
        /// </summary>
        [DBField]
        public string Password { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DBField]
        public string Remark { get; set; }

        /// <summary>
        /// 创建者ID
        /// </summary>
        [DBField]
        public string CreateUserid { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DBField]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新者ID
        /// </summary>
        [DBField]
        public string UpdateUserid { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [DBField]
        public DateTime? UpdateTime { get; set; }

    }
}
