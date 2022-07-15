using System;
using System.Collections.Generic;
using System.Linq;
using DBUtil;

namespace Models
{
    /// <summary>
    /// 订单表
    /// </summary>
    [Serializable]
    [DBTable("bs_order")]
    public partial class BsOrder
    {

        /// <summary>
        /// 主键
        /// </summary>
        [DBKey]
        [DBField]
        public string Id { get; set; }

        /// <summary>
        /// 订单时间
        /// </summary>
        [DBField("order_time")]
        public DateTime OrderTime { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        [DBField]
        public decimal? Amount { get; set; }

        /// <summary>
        /// 下单用户
        /// </summary>
        [DBField("order_userid")]
        public long OrderUserid { get; set; }

        /// <summary>
        /// 订单状态(0草稿 1已下单 2已付款 3已发货 4完成)
        /// </summary>
        [DBField]
        public int Status { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [DBField]
        public string Remark { get; set; }

        /// <summary>
        /// 创建者ID
        /// </summary>
        [DBField("create_userid")]
        public string CreateUserid { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DBField("create_time")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新者ID
        /// </summary>
        [DBField("update_userid")]
        public string UpdateUserid { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [DBField("update_time")]
        public DateTime? UpdateTime { get; set; }

    }
}
