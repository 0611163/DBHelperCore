using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DBUtil
{
    public partial class DBSession : ISession
    {
        #region  执行简单SQL语句

        #region Exists 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public bool Exists(string sqlString)
        {
            SqlFilter(ref sqlString);
            if (_conn.State != ConnectionState.Open) _conn.Open();
            using (DbCommand cmd = _provider.GetCommand(sqlString, _conn))
            {
                object obj = cmd.ExecuteScalar();

                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        #endregion

        #region ExistsAsync 是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        public async Task<bool> ExistsAsync(string sqlString)
        {
            SqlFilter(ref sqlString);
            if (_conn.State != ConnectionState.Open)
            {
                await _conn.OpenAsync();
            }
            using (DbCommand cmd = _provider.GetCommand(sqlString, _conn))
            {
                object obj = await cmd.ExecuteScalarAsync();

                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        #endregion


        #region ExecuteSql 执行SQL语句，返回影响的记录数
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sqlString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSql(string sqlString)
        {
            SqlFilter(ref sqlString);
            if (_conn.State != ConnectionState.Open) _conn.Open();
            using (DbCommand cmd = _provider.GetCommand(sqlString, _conn))
            {
                if (_tran != null) cmd.Transaction = _tran;
                int rows = cmd.ExecuteNonQuery();
                return rows;
            }
        }
        #endregion

        #region ExecuteSqlAsync 执行SQL语句，返回影响的记录数
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="sqlString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public async Task<int> ExecuteSqlAsync(string sqlString)
        {
            SqlFilter(ref sqlString);
            if (_conn.State != ConnectionState.Open)
            {
                await _conn.OpenAsync();
            }
            using (DbCommand cmd = _provider.GetCommand(sqlString, _conn))
            {
                if (_tran != null) cmd.Transaction = _tran;
                int rows = await cmd.ExecuteNonQueryAsync();
                return rows;
            }
        }
        #endregion


        #region GetSingle<T> 执行一条计算查询结果语句，返回查询结果
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）
        /// </summary>
        /// <param name="sqlString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public T GetSingle<T>(string sqlString)
        {
            SqlFilter(ref sqlString);
            if (_conn.State != ConnectionState.Open) _conn.Open();
            using (DbCommand cmd = _provider.GetCommand(sqlString, _conn))
            {
                object obj = cmd.ExecuteScalar();

                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return default(T);
                }
                else
                {
                    return (T)Convert.ChangeType(obj, typeof(T));
                }
            }
        }
        #endregion

        #region GetSingle 执行一条计算查询结果语句，返回查询结果
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）
        /// </summary>
        /// <param name="sqlString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public object GetSingle(string sqlString)
        {
            SqlFilter(ref sqlString);
            if (_conn.State != ConnectionState.Open) _conn.Open();
            using (DbCommand cmd = _provider.GetCommand(sqlString, _conn))
            {
                object obj = cmd.ExecuteScalar();

                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return null;
                }
                else
                {
                    return obj;
                }
            }
        }
        #endregion

        #region GetSingleAsync<T> 执行一条计算查询结果语句，返回查询结果
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）
        /// </summary>
        /// <param name="sqlString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public async Task<T> GetSingleAsync<T>(string sqlString)
        {
            SqlFilter(ref sqlString);
            if (_conn.State != ConnectionState.Open) _conn.Open();
            using (DbCommand cmd = _provider.GetCommand(sqlString, _conn))
            {
                object obj = await cmd.ExecuteScalarAsync();

                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return default(T);
                }
                else
                {
                    return (T)Convert.ChangeType(obj, typeof(T));
                }
            }
        }
        #endregion

        #region GetSingleAsync 执行一条计算查询结果语句，返回查询结果
        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）
        /// </summary>
        /// <param name="sqlString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public async Task<object> GetSingleAsync(string sqlString)
        {
            SqlFilter(ref sqlString);
            if (_conn.State != ConnectionState.Open) _conn.Open();
            using (DbCommand cmd = _provider.GetCommand(sqlString, _conn))
            {
                object obj = await cmd.ExecuteScalarAsync();

                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    return null;
                }
                else
                {
                    return obj;
                }
            }
        }
        #endregion


        #region Query 执行查询语句，返回DataSet
        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="sqlString">查询语句</param>
        /// <returns>DataSet</returns>
        public DataSet Query(string sqlString)
        {
            SqlFilter(ref sqlString);
            if (_conn.State != ConnectionState.Open) _conn.Open();
            using (DbCommand cmd = _provider.GetCommand(sqlString, _conn))
            {
                DataSet ds = new DataSet();
                DbDataAdapter adapter = _provider.GetDataAdapter(cmd);
                adapter.Fill(ds, "ds");
                return ds;
            }
        }
        #endregion


        #region ExecuteReader 执行查询语句，返回IDataReader
        /// <summary>
        /// 执行查询语句，返回IDataReader ( 注意：调用该方法后，一定要对IDataReader进行Close )
        /// </summary>
        private DbDataReader ExecuteReader(string sqlString)
        {
            SqlFilter(ref sqlString);
            if (_conn.State != ConnectionState.Open) _conn.Open();
            using (DbCommand cmd = _provider.GetCommand(sqlString, _conn))
            {
                DbDataReader myReader = cmd.ExecuteReader();
                return myReader;
            }
        }
        #endregion

        #endregion

        #region 执行带参数的SQL语句

        #region ExecuteSql 执行SQL语句，返回影响的记录数
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSql(string SQLString, params DbParameter[] cmdParms)
        {
            using (DbCommand cmd = _provider.GetCommand())
            {
                PrepareCommand(cmd, _conn, _tran, SQLString, cmdParms);
                int rows = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return rows;
            }
        }
        #endregion

        #region ExecuteSqlAsync 执行SQL语句，返回影响的记录数
        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public async Task<int> ExecuteSqlAsync(string SQLString, params DbParameter[] cmdParms)
        {
            using (DbCommand cmd = _provider.GetCommand())
            {
                await PrepareCommandAsync(cmd, _conn, _tran, SQLString, cmdParms);
                var task = cmd.ExecuteNonQueryAsync();
                int rows = await task;
                cmd.Parameters.Clear();
                return rows;
            }
        }
        #endregion


        #region 执行查询语句，返回DataSet
        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="sqlString">查询语句</param>
        /// <returns>DataSet</returns>
        public DataSet Query(string sqlString, params DbParameter[] cmdParms)
        {
            using (DbCommand cmd = _provider.GetCommand())
            {
                PrepareCommand(cmd, _conn, null, sqlString, cmdParms);
                using (DbDataAdapter da = _provider.GetDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    da.Fill(ds, "ds");
                    cmd.Parameters.Clear();
                    return ds;
                }
            }
        }
        #endregion


        #region ExecuteReader 执行查询语句，返回IDataReader
        /// <summary>
        /// 执行查询语句，返回IDataReader ( 注意：调用该方法后，一定要对IDataReader进行Close )
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>IDataReader</returns>
        private DbDataReader ExecuteReader(string sqlString, params DbParameter[] cmdParms)
        {
            using (DbCommand cmd = _provider.GetCommand())
            {
                PrepareCommand(cmd, _conn, null, sqlString, cmdParms);
                DbDataReader myReader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return myReader;
            }
        }
        #endregion

        #region ExecuteReaderAsync 执行查询语句，返回IDataReader
        /// <summary>
        /// 执行查询语句，返回IDataReader ( 注意：调用该方法后，一定要对IDataReader进行Close )
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>IDataReader</returns>
        private async Task<DbDataReader> ExecuteReaderAsync(string sqlString, params DbParameter[] cmdParms)
        {
            using (DbCommand cmd = _provider.GetCommand())
            {
                await PrepareCommandAsync(cmd, _conn, null, sqlString, cmdParms);
                DbDataReader myReader = await cmd.ExecuteReaderAsync();
                cmd.Parameters.Clear();
                return myReader;
            }
        }
        #endregion

        #region PrepareCommand
        private static void PrepareCommand(DbCommand cmd, DbConnection conn, DbTransaction trans, string cmdText, DbParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open) conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null) cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;
            if (cmdParms != null)
            {
                foreach (DbParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }
        #endregion

        #region PrepareCommandAsync
        private static async Task PrepareCommandAsync(DbCommand cmd, DbConnection conn, DbTransaction trans, string cmdText, DbParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open) await conn.OpenAsync();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null) cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;
            if (cmdParms != null)
            {
                foreach (DbParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }
        #endregion

        #endregion

    }
}
