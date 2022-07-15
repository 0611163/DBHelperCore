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
        #region 分页获取列表
        /// <summary>
        /// 分页获取列表
        /// </summary>
        PageModel FindPageBySql<T>(string sql, string orderby, int pageSize, int currentPage) where T : new();

        /// <summary>
        /// 分页获取列表
        /// </summary>
        Task<PageModel> FindPageBySqlAsync<T>(string sql, string orderby, int pageSize, int currentPage) where T : new();
        #endregion

        #region 分页获取列表(参数化查询)
        /// <summary>
        /// 分页获取列表
        /// </summary>
        PageModel FindPageBySql<T>(string sql, string orderby, int pageSize, int currentPage, params DbParameter[] cmdParms) where T : new();

        /// <summary>
        /// 分页获取列表
        /// </summary>
        Task<PageModel> FindPageBySqlAsync<T>(string sql, string orderby, int pageSize, int currentPage, params DbParameter[] cmdParms) where T : new();
        #endregion

        #region 分页获取列表(返回DataSet)
        /// <summary>
        /// 分页(任意entity，尽量少的字段)
        /// </summary>
        DataSet FindPageBySql(string sql, string orderby, int pageSize, int currentPage, out int totalCount, params DbParameter[] cmdParms);
        #endregion

    }
}
