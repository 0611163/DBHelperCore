using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBUtil
{
    /// <summary>
    /// DBHelper 接口
    /// </summary>
    public interface ISessionHelper
    {
        /// <summary>
        /// 获取 ISession
        /// </summary>
        ISession GetSession();

        /// <summary>
        /// 获取 ISession (异步)
        /// </summary>
        Task<ISession> GetSessionAsync();

    }
}
