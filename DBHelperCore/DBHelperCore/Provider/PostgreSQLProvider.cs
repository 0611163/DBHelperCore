using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Collections;

namespace DBUtil
{
    /// <summary>
    /// PostgreSQL 数据库实现
    /// </summary>
    public class PostgreSQLProvider : IProvider
    {
        #region OpenQuote 引号
        /// <summary>
        /// 引号
        /// </summary>
        public string OpenQuote
        {
            get
            {
                return "\"";
            }
        }
        #endregion

        #region CloseQuote 引号
        /// <summary>
        /// 引号
        /// </summary>
        public string CloseQuote
        {
            get
            {
                return "\"";
            }
        }
        #endregion

        #region 创建 DbConnection
        public DbConnection CreateConnection(string connectionString)
        {
            return new NpgsqlConnection(connectionString);
        }
        #endregion

        #region 生成 DbCommand
        public DbCommand GetCommand()
        {
            return new NpgsqlCommand();
        }
        #endregion

        #region 生成 DbCommand
        public DbCommand GetCommand(string sql, DbConnection conn)
        {
            DbCommand command = new NpgsqlCommand(sql);
            command.Connection = conn;
            return command;
        }
        #endregion

        #region 生成 DbParameter
        public DbParameter GetDbParameter(string name, object vallue)
        {
            return new NpgsqlParameter(name, vallue);
        }
        #endregion

        #region 生成 DbDataAdapter
        public DbDataAdapter GetDataAdapter(DbCommand cmd)
        {
            DbDataAdapter dataAdapter = new NpgsqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            return dataAdapter;
        }
        #endregion

        #region GetParameterMark
        public string GetParameterMark()
        {
            return "@";
        }
        #endregion

        #region 创建获取最大编号SQL
        public string CreateGetMaxIdSql(string key, Type type)
        {
            return string.Format("SELECT Max({0}) FROM {1}", key, type.Name);
        }
        #endregion

        #region 创建分页SQL
        public string CreatePageSql(string sql, string orderby, int pageSize, int currentPage, int totalRows)
        {
            StringBuilder sb = new StringBuilder();
            int startRow = 0;
            int endRow = 0;

            #region 分页查询语句
            startRow = pageSize * (currentPage - 1);

            sb.Append("select * from (");
            sb.Append(sql);
            if (!string.IsNullOrWhiteSpace(orderby))
            {
                sb.Append(" ");
                sb.Append(orderby);
            }
            sb.AppendFormat(" ) row_limit limit {0} offset {1}", pageSize, startRow);
            #endregion

            return sb.ToString();
        }
        #endregion

        #region ForContains
        public SqlValue ForContains(string value)
        {
            return new SqlValue("concat('%',{0},'%')", value);
        }
        #endregion

        #region ForStartsWith
        public SqlValue ForStartsWith(string value)
        {
            //todo:ForStartsWith
            throw new NotImplementedException();
        }
        #endregion

        #region ForEndsWith
        public SqlValue ForEndsWith(string value)
        {
            //todo:ForEndsWith
            throw new NotImplementedException();
        }
        #endregion

        #region ForDateTime
        public SqlValue ForDateTime(DateTime dateTime)
        {
            return new SqlValue("TO_TIMESTAMP(CAST({0} as TEXT), 'yyyy-MM-dd hh24:mi:ss')", dateTime.ToString("yyyy-MM-dd HH:mm:ss"));
        }
        #endregion

        #region ForList
        public SqlValue ForList(IList list)
        {
            //todo:ForList
            throw new NotImplementedException();
        }
        #endregion

    }
}
