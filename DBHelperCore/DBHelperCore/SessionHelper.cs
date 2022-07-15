using System;
using System.Threading.Tasks;

namespace DBUtil
{
    /// <summary>
    /// 数据库操作类
    /// </summary>
    public class SessionHelper : ISessionHelper
    {
        #region 变量
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private string _connectionString;

        /// <summary>
        /// 数据库类型
        /// </summary>
        private DBType _dbType;

        /// <summary>
        /// 主键自增全局配置
        /// </summary>
        private bool _autoIncrement;
        #endregion

        #region 构造函数
        /// <summary>
        /// 数据库操作类 构造函数
        /// </summary>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <param name="dbType">数据库类型</param>
        /// <param name="autoIncrement">主键自增全局配置(如果实体类或实体类的主键添加了AutoIncrementAttribute特性则不使用全局配置)</param>
        public SessionHelper(string connectionString, DBType dbType, bool autoIncrement = false)
        {
            _connectionString = connectionString;
            _dbType = dbType;
            _autoIncrement = autoIncrement;

        }
        #endregion

        #region 获取 ISession
        /// <summary>
        /// 获取 ISession
        /// </summary>
        public ISession GetSession()
        {
            DBSession dbSession = new DBSession(_connectionString, _dbType, _autoIncrement);
            dbSession.InitConn();
            return dbSession;
        }
        #endregion

        #region 获取 ISession (异步)
        /// <summary>
        /// 获取 ISession (异步)
        /// </summary>
        public async Task<ISession> GetSessionAsync()
        {
            DBSession dbHelper = new DBSession(_connectionString, _dbType, _autoIncrement);
            await dbHelper.InitConnAsync();
            return dbHelper;
        }
        #endregion

    }
}
