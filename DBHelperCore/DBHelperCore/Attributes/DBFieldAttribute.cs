using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBUtil
{
    /// <summary>
    /// 标识该属性是数据库字段
    /// </summary>
    [Serializable, AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public class DBFieldAttribute : Attribute
    {
        public string FieldName { get; set; }

        /// <summary>
        /// 标识该属性是数据库字段
        /// </summary>
        /// <param name="tableName">数据库字段名</param>
        public DBFieldAttribute(string fieldName = null)
        {
            FieldName = fieldName;
        }
    }
}
