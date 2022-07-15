using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBUtil
{
    public partial interface ISession
    {
        /// <summary>
        /// 修改
        /// </summary>
        void Update(object obj);

        /// <summary>
        /// 修改
        /// </summary>
        Task UpdateAsync(object obj);

        /// <summary>
        /// 批量修改
        /// </summary>
        void Update<T>(List<T> list);

        /// <summary>
        /// 批量修改
        /// </summary>
        Task UpdateAsync<T>(List<T> list);
    }
}
