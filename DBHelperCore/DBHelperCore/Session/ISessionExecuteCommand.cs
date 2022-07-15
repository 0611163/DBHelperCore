using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBUtil
{
    public partial interface ISession
    {
        #region 执行简单SQL语句

        /// <summary>
        /// 是否存在
        /// </summary>
        bool Exists(string sqlString);

        /// <summary>
        /// 是否存在
        /// </summary>
        Task<bool> ExistsAsync(string sqlString);

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sqlString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        int ExecuteSql(string sqlString);

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sqlString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        Task<int> ExecuteSqlAsync(string sqlString);

        /// <summary>
        /// 查询单个值
        /// </summary>
        object GetSingle(string sqlString);

        /// <summary>
        /// 查询单个值
        /// </summary>
        T GetSingle<T>(string sqlString);

        /// <summary>
        /// 查询单个值
        /// </summary>
        Task<object> GetSingleAsync(string sqlString);

        /// <summary>
        /// 查询单个值
        /// </summary>
        Task<T> GetSingleAsync<T>(string sqlString);

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        DataSet Query(string sqlString);

        #endregion

        #region 执行带参数的SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        int ExecuteSql(string SQLString, params DbParameter[] cmdParms);

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        Task<int> ExecuteSqlAsync(string SQLString, params DbParameter[] cmdParms);

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        DataSet Query(string sqlString, params DbParameter[] cmdParms);

        #endregion

    }
}
