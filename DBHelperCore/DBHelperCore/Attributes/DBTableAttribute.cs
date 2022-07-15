using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBUtil
{
    /// <summary>
    /// 标识数据库表
    /// </summary>
    [Serializable, AttributeUsage(AttributeTargets.Class)]
    public class DBTableAttribute : Attribute
    {
        public string TableName { get; set; }

        /// <summary>
        /// 标识数据库表
        /// </summary>
        /// <param name="tableName">数据库表名</param>
        public DBTableAttribute(string tableName = null)
        {
            TableName = tableName;
        }
    }
}
