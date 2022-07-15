using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DBUtil
{
    public partial class DBSession : ISession
    {
        #region FindById<T> 根据Id获取实体
        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        public T FindById<T>(object id) where T : new()
        {
            Type type = typeof(T);

            DbParameter[] cmdParms = new DbParameter[1];
            cmdParms[0] = _provider.GetDbParameter(_parameterMark + GetIdName(type), id);

            string sql = string.Format("select * from {0} where {2}={1}{2}", GetTableName(type), _parameterMark, GetIdName(type));

            object result = Find(type, sql, cmdParms);

            if (result != null)
            {
                return (T)result;
            }
            else
            {
                return default(T);
            }
        }
        #endregion

        #region FindByIdAsync<T> 根据Id获取实体
        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        public async Task<T> FindByIdAsync<T>(object id) where T : new()
        {
            Type type = typeof(T);

            DbParameter[] cmdParms = new DbParameter[1];
            cmdParms[0] = _provider.GetDbParameter(_parameterMark + GetIdName(type), id);

            string sql = string.Format("select * from {0} where {2}={1}{2}", GetTableName(type), _parameterMark, GetIdName(type));

            object result = await FindAsync(type, sql, cmdParms);

            if (result != null)
            {
                return (T)result;
            }
            else
            {
                return default(T);
            }
        }
        #endregion


        #region FindBySql<T> 根据sql获取实体
        /// <summary>
        /// 根据sql获取实体
        /// </summary>
        public T FindBySql<T>(string sql) where T : new()
        {
            Type type = typeof(T);
            object result = Find(type, sql, null);

            if (result != null)
            {
                return (T)result;
            }
            else
            {
                return default(T);
            }
        }
        #endregion

        #region FindBySqlAsync<T> 根据sql获取实体
        /// <summary>
        /// 根据sql获取实体
        /// </summary>
        public async Task<T> FindBySqlAsync<T>(string sql) where T : new()
        {
            Type type = typeof(T);
            object result = await FindAsync(type, sql, null);

            if (result != null)
            {
                return (T)result;
            }
            else
            {
                return default(T);
            }
        }
        #endregion


        #region FindBySql<T> 根据sql获取实体(参数化查询)
        /// <summary>
        /// 根据sql获取实体
        /// </summary>
        public T FindBySql<T>(string sql, params DbParameter[] args) where T : new()
        {
            Type type = typeof(T);
            object result = Find(type, sql, args);

            if (result != null)
            {
                return (T)result;
            }
            else
            {
                return default(T);
            }
        }
        #endregion

        #region FindBySqlAsync<T> 根据sql获取实体(参数化查询)
        /// <summary>
        /// 根据sql获取实体
        /// </summary>
        public async Task<T> FindBySqlAsync<T>(string sql, params DbParameter[] args) where T : new()
        {
            Type type = typeof(T);
            object result = await FindAsync(type, sql, args);

            if (result != null)
            {
                return (T)result;
            }
            else
            {
                return default(T);
            }
        }
        #endregion


        #region Find 根据实体获取实体
        /// <summary>
        /// 根据实体获取实体
        /// </summary>
        private object Find(object obj)
        {
            Type type = obj.GetType();

            string sql = string.Format("select * from {0} where {1}", GetTableName(type), CreatePkCondition(_provider, obj.GetType(), obj));

            return Find(type, sql, null);
        }
        #endregion

        #region Find 根据实体获取实体
        /// <summary>
        /// 根据实体获取实体
        /// </summary>
        private Task<object> FindAsync(object obj)
        {
            Type type = obj.GetType();

            string sql = string.Format("select * from {0} where {1}", GetTableName(type), CreatePkCondition(_provider, obj.GetType(), obj));

            return FindAsync(type, sql, null);
        }
        #endregion

        #region Find 获取实体
        /// <summary>
        /// 获取实体
        /// </summary>
        private object Find(Type type, string sql, DbParameter[] args)
        {
            object result = Activator.CreateInstance(type);
            IDataReader rd = null;
            bool hasValue = false;

            try
            {
                if (args == null)
                {
                    rd = ExecuteReader(sql);
                }
                else
                {
                    rd = ExecuteReader(sql, args);
                }

                DataReaderToEntity(type, rd, ref result, ref hasValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (rd != null && !rd.IsClosed)
                {
                    rd.Close();
                    rd.Dispose();
                }
            }

            if (hasValue)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region FindAsync 获取实体
        /// <summary>
        /// 获取实体
        /// </summary>
        private async Task<object> FindAsync(Type type, string sql, DbParameter[] args)
        {
            object result = Activator.CreateInstance(type);
            IDataReader rd = null;
            bool hasValue = false;

            try
            {
                if (args == null)
                {
                    rd = await ExecuteReaderAsync(sql);
                }
                else
                {
                    rd = await ExecuteReaderAsync(sql, args);
                }

                DataReaderToEntity(type, rd, ref result, ref hasValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (rd != null && !rd.IsClosed)
                {
                    rd.Close();
                    rd.Dispose();
                }
            }

            if (hasValue)
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region DataReaderToEntity
        /// <summary>
        /// DataReaderToEntity
        /// </summary>
        private void DataReaderToEntity(Type type, IDataReader rd, ref object result, ref bool hasValue)
        {
            PropertyInfoEx[] propertyInfoList = GetEntityProperties(type);

            int fieldCount = rd.FieldCount;
            Dictionary<string, string> fields = new Dictionary<string, string>();
            for (int i = 0; i < fieldCount; i++)
            {
                string field = rd.GetName(i).ToUpper();
                if (!fields.ContainsKey(field))
                {
                    fields.Add(field, null);
                }
            }

            while (rd.Read())
            {
                hasValue = true;
                IDataRecord record = rd;

                foreach (PropertyInfoEx propertyInfoEx in propertyInfoList)
                {
                    PropertyInfo propertyInfo = propertyInfoEx.PropertyInfo;

                    if (!fields.ContainsKey(propertyInfoEx.FieldName.ToUpper())) continue;

                    object val = record[propertyInfoEx.FieldName];

                    if (val == DBNull.Value) continue;

                    val = val == DBNull.Value ? null : ConvertValue(val, propertyInfo.PropertyType);

                    propertyInfo.SetValue(result, val);
                }
            }
        }
        #endregion

    }
}
