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
        #region 根据Id获取实体
        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        T FindById<T>(object id) where T : new();

        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        Task<T> FindByIdAsync<T>(object id) where T : new();
        #endregion

        #region 根据sql获取实体
        /// <summary>
        /// 根据sql获取实体
        /// </summary>
        T FindBySql<T>(string sql) where T : new();

        /// <summary>
        /// 根据sql获取实体
        /// </summary>
        Task<T> FindBySqlAsync<T>(string sql) where T : new();
        #endregion

        #region 根据sql获取实体(参数化查询)
        /// <summary>
        /// 根据sql获取实体
        /// </summary>
        T FindBySql<T>(string sql, params DbParameter[] args) where T : new();

        /// <summary>
        /// 根据sql获取实体
        /// </summary>
        Task<T> FindBySqlAsync<T>(string sql, params DbParameter[] args) where T : new();
        #endregion

    }
}
