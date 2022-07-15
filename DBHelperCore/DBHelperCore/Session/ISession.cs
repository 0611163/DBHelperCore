using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBUtil
{
    public partial interface ISession : IDisposable
    {
        #region 创建SqlString对象
        /// <summary>
        /// 创建SqlString对象
        /// </summary>
        SqlString CreateSqlString(string sql = null, params object[] args);
        #endregion

        #region 创建SqlString对象
        /// <summary>
        /// 创建SqlString对象
        /// </summary>
        SqlString<T> CreateSqlString<T>(string sql = null, params object[] args) where T : new();
        #endregion

        #region 获取最大编号
        /// <summary>
        /// 获取最大编号
        /// </summary>
        /// <typeparam name="T">实体Model</typeparam>
        /// <param name="key">主键</param>
        int GetMaxID<T>(string key);
        #endregion

    }
}
