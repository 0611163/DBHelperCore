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
        #region FindListBySql<T> 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        public List<T> FindListBySql<T>(string sql) where T : new()
        {
            List<T> list = new List<T>();
            IDataReader rd = null;

            try
            {
                rd = ExecuteReader(sql);

                DataReaderToList(rd, ref list);
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

            return list;
        }
        #endregion

        #region FindListBySqlAsync<T> 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        public async Task<List<T>> FindListBySqlAsync<T>(string sql) where T : new()
        {
            List<T> list = new List<T>();
            IDataReader rd = null;

            try
            {
                rd = await ExecuteReaderAsync(sql);

                DataReaderToList(rd, ref list);
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

            return list;
        }
        #endregion


        #region 获取列表(参数化查询)
        /// <summary>
        /// 获取列表
        /// </summary>
        public List<T> FindListBySql<T>(string sql, params DbParameter[] cmdParms) where T : new()
        {
            List<T> list = new List<T>();
            IDataReader rd = null;

            try
            {
                rd = ExecuteReader(sql, cmdParms);

                DataReaderToList(rd, ref list);
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

            return list;
        }
        #endregion

        #region FindListBySqlAsync<T> 获取列表(参数化查询)
        /// <summary>
        /// 获取列表
        /// </summary>
        public async Task<List<T>> FindListBySqlAsync<T>(string sql, params DbParameter[] cmdParms) where T : new()
        {
            List<T> list = new List<T>();
            IDataReader rd = null;

            try
            {
                rd = await ExecuteReaderAsync(sql, cmdParms);

                DataReaderToList(rd, ref list);
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

            return list;
        }
        #endregion


        #region DataReaderToList
        /// <summary>
        /// DataReaderToList
        /// </summary>
        private void DataReaderToList<T>(IDataReader rd, ref List<T> list) where T : new()
        {
            if (typeof(T) == typeof(int))
            {
                while (rd.Read())
                {
                    list.Add((T)rd[0]);
                }
            }
            else if (typeof(T) == typeof(string))
            {
                while (rd.Read())
                {
                    list.Add((T)rd[0]);
                }
            }
            else
            {
                PropertyInfoEx[] propertyInfoList = GetEntityProperties(typeof(T));

                int fcnt = rd.FieldCount;
                Dictionary<string, string> fields = new Dictionary<string, string>();
                for (int i = 0; i < fcnt; i++)
                {
                    string field = rd.GetName(i).ToUpper();
                    if (!fields.ContainsKey(field))
                    {
                        fields.Add(field, null);
                    }
                }

                while (rd.Read())
                {
                    IDataRecord record = rd;
                    T obj = new T();

                    foreach (PropertyInfoEx propertyInfoEx in propertyInfoList)
                    {
                        PropertyInfo propertyInfo = propertyInfoEx.PropertyInfo;

                        if (!fields.ContainsKey(propertyInfoEx.FieldName.ToUpper())) continue;

                        object val = record[propertyInfoEx.FieldName];

                        if (val == DBNull.Value) continue;

                        val = val == DBNull.Value ? null : ConvertValue(val, propertyInfo.PropertyType);

                        propertyInfo.SetValue(obj, val);
                    }

                    list.Add((T)obj);
                }
            }
        }
        #endregion

    }
}
