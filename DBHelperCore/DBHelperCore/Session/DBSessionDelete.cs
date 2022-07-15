using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBUtil
{
    public partial class DBSession : ISession
    {
        #region DeleteById<T> 根据Id删除
        /// <summary>
        /// 根据Id删除
        /// </summary>
        public void DeleteById<T>(int id)
        {
            DeleteById<T>(id.ToString());
        }
        #endregion

        #region DeleteById<T> 根据Id删除
        /// <summary>
        /// 根据Id删除
        /// </summary>
        public void DeleteById<T>(long id)
        {
            DeleteById<T>(id.ToString());
        }
        #endregion

        #region DeleteById<T> 根据Id删除
        /// <summary>
        /// 根据Id删除
        /// </summary>
        public void DeleteById<T>(string id)
        {
            Type type = typeof(T);
            StringBuilder sbSql = new StringBuilder();
            DbParameter[] cmdParms = new DbParameter[1];
            cmdParms[0] = _provider.GetDbParameter(_parameterMark + GetIdName(type), id);
            sbSql.Append(string.Format("delete from {0} where {2}={1}{2}", GetTableName(type), _parameterMark, GetIdName(type)));

            ExecuteSql(sbSql.ToString(), cmdParms);
        }
        #endregion


        #region DeleteByIdAsync<T> 根据Id删除
        /// <summary>
        /// 根据Id删除
        /// </summary>
        public Task DeleteByIdAsync<T>(long id)
        {
            return DeleteByIdAsync<T>(id.ToString());
        }
        #endregion

        #region DeleteByIdAsync<T> 根据Id删除
        /// <summary>
        /// 根据Id删除
        /// </summary>
        public Task DeleteByIdAsync<T>(int id)
        {
            return DeleteByIdAsync<T>(id.ToString());
        }
        #endregion

        #region DeleteByIdAsync<T> 根据Id删除
        /// <summary>
        /// 根据Id删除
        /// </summary>
        public Task DeleteByIdAsync<T>(string id)
        {
            Type type = typeof(T);
            StringBuilder sbSql = new StringBuilder();
            DbParameter[] cmdParms = new DbParameter[1];
            cmdParms[0] = _provider.GetDbParameter(_parameterMark + GetIdName(type), id);
            sbSql.Append(string.Format("delete from {0} where {2}={1}{2}", GetTableName(type), _parameterMark, GetIdName(type)));

            return ExecuteSqlAsync(sbSql.ToString(), cmdParms);
        }
        #endregion


        #region BatchDeleteByIds<T> 根据Id集合删除
        /// <summary>
        /// 根据Id集合删除
        /// </summary>
        public void BatchDeleteByIds<T>(string ids)
        {
            if (string.IsNullOrWhiteSpace(ids)) return;

            Type type = typeof(T);
            StringBuilder sbSql = new StringBuilder();
            string[] idArr = ids.Split(',');
            DbParameter[] cmdParms = new DbParameter[idArr.Length];
            sbSql.AppendFormat("delete from {0} where {1} in (", GetTableName(type), GetIdName(type));
            for (int i = 0; i < idArr.Length; i++)
            {
                cmdParms[i] = _provider.GetDbParameter(_parameterMark + GetIdName(type) + i, idArr[i]);
                sbSql.AppendFormat("{1}{2}{3},", GetTableName(type), _parameterMark, GetIdName(type), i);
            }
            sbSql.Remove(sbSql.Length - 1, 1);
            sbSql.Append(")");

            ExecuteSql(sbSql.ToString(), cmdParms);
        }
        #endregion

        #region BatchDeleteByIdsAsync<T> 根据Id集合删除
        /// <summary>
        /// 根据Id集合删除
        /// </summary>
        public Task BatchDeleteByIdsAsync<T>(string ids)
        {
            if (string.IsNullOrWhiteSpace(ids)) throw new Exception("ids 不能为空");

            Type type = typeof(T);
            StringBuilder sbSql = new StringBuilder();
            string[] idArr = ids.Split(',');
            DbParameter[] cmdParms = new DbParameter[idArr.Length];
            sbSql.AppendFormat("delete from {0} where {1} in (", GetTableName(type), GetIdName(type));
            for (int i = 0; i < idArr.Length; i++)
            {
                cmdParms[i] = _provider.GetDbParameter(_parameterMark + GetIdName(type) + i, idArr[i]);
                sbSql.AppendFormat("{1}{2}{3},", GetTableName(type), _parameterMark, GetIdName(type), i);
            }
            sbSql.Remove(sbSql.Length - 1, 1);
            sbSql.Append(")");

            return ExecuteSqlAsync(sbSql.ToString(), cmdParms);
        }
        #endregion


        #region DeleteByCondition<T> 根据条件删除
        /// <summary>
        /// 根据条件删除
        /// </summary>
        public void DeleteByCondition<T>(string condition)
        {
            if (string.IsNullOrWhiteSpace(condition)) return;

            Type type = typeof(T);
            DeleteByCondition(type, condition);
        }
        #endregion

        #region DeleteByConditionAsync<T> 根据条件删除
        /// <summary>
        /// 根据条件删除
        /// </summary>
        public Task DeleteByConditionAsync<T>(string condition)
        {
            if (string.IsNullOrWhiteSpace(condition)) throw new Exception("condition 不能为空"); ;

            Type type = typeof(T);
            return DeleteByConditionAsync(type, condition);
        }
        #endregion


        #region DeleteByCondition 根据条件删除
        /// <summary>
        /// 根据条件删除
        /// </summary>
        public void DeleteByCondition(Type type, string condition)
        {
            if (string.IsNullOrWhiteSpace(condition)) return;

            StringBuilder sbSql = new StringBuilder();
            SqlFilter(ref condition);
            sbSql.Append(string.Format("delete from {0} where {1}", GetTableName(type), condition));

            ExecuteSql(sbSql.ToString());
        }
        #endregion

        #region DeleteByConditionAsync 根据条件删除
        /// <summary>
        /// 根据条件删除
        /// </summary>
        public Task DeleteByConditionAsync(Type type, string condition)
        {
            if (string.IsNullOrWhiteSpace(condition)) throw new Exception("condition 不能为空");

            StringBuilder sbSql = new StringBuilder();
            SqlFilter(ref condition);
            sbSql.Append(string.Format("delete from {0} where {1}", GetTableName(type), condition));

            return ExecuteSqlAsync(sbSql.ToString());
        }
        #endregion

    }
}
