using DBUtil;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBHelper
    {
        #region 变量
        private static ISessionHelper _sessionHelper;
        #endregion

        #region 静态构造函数
        static DBHelper()
        {
            var configurationBuilder = new ConfigurationBuilder().AddJsonFile("config.json");
            var configuration = configurationBuilder.Build();
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            _sessionHelper = new SessionHelper(connectionString, DBType.MySQL);
        }
        #endregion

        #region 获取 ISession
        /// <summary>
        /// 获取 ISession
        /// </summary>
        public static ISession GetSession()
        {
            return _sessionHelper.GetSession();
        }
        #endregion

        #region 获取 ISession (异步)
        /// <summary>
        /// 获取 ISession (异步)
        /// </summary>
        public static async Task<ISession> GetSessionAsync()
        {
            return await _sessionHelper.GetSessionAsync();
        }
        #endregion

    }
}
