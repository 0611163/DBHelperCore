using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBUtil
{
    public partial interface ISession
    {
        #region 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        List<T> FindListBySql<T>(string sql) where T : new();

        /// <summary>
        /// 获取列表
        /// </summary>
        Task<List<T>> FindListBySqlAsync<T>(string sql) where T : new();
        #endregion

        #region 获取列表(参数化查询)
        /// <summary>
        /// 获取列表
        /// </summary>
        List<T> FindListBySql<T>(string sql, params DbParameter[] cmdParms) where T : new();

        /// <summary>
        /// 获取列表
        /// </summary>
        Task<List<T>> FindListBySqlAsync<T>(string sql, params DbParameter[] cmdParms) where T : new();
        #endregion

    }
}
