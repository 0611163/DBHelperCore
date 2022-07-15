using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBUtil
{
    /// <summary>
    /// 数据库实现工厂
    /// </summary>
    public class ProviderFactory
    {
        #region 创建数据库 Provider
        /// <summary>
        /// 创建数据库 Provider
        /// </summary>
        /// <param name="dbType">数据库类型</param>
        public static IProvider CreateProvider(DBType dbType)
        {
            if (dbType == DBType.MySQL)
            {
                return new MySQLProvider();
            }

            if (dbType == DBType.Oracle)
            {
                return new OracleProvider();
            }

            if (dbType == DBType.MSSQL)
            {
                return new MSSQLProvider();
            }

            if (dbType == DBType.SQLite)
            {
                return new SQLiteProvider();
            }

            if (dbType == DBType.PostgreSQL)
            {
                return new PostgreSQLProvider();
            }

            throw new NotSupportedException();
        }
        #endregion

    }
}
