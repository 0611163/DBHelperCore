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
        /// 根据Id删除
        /// </summary>
        void DeleteById<T>(long id);

        /// <summary>
        /// 根据Id删除
        /// </summary>
        void DeleteById<T>(int id);

        /// <summary>
        /// 根据Id删除
        /// </summary>
        void DeleteById<T>(string id);

        /// <summary>
        /// 根据Id删除
        /// </summary>
        Task DeleteByIdAsync<T>(long id);

        /// <summary>
        /// 根据Id删除
        /// </summary>
        Task DeleteByIdAsync<T>(int id);

        /// <summary>
        /// 根据Id删除
        /// </summary>
        Task DeleteByIdAsync<T>(string id);

        /// <summary>
        /// 根据Id集合删除
        /// </summary>
        void BatchDeleteByIds<T>(string ids);

        /// <summary>
        /// 根据Id集合删除
        /// </summary>
        Task BatchDeleteByIdsAsync<T>(string ids);

        /// <summary>
        /// 根据条件删除
        /// </summary>
        void DeleteByCondition<T>(string conditions);

        /// <summary>
        /// 根据条件删除
        /// </summary>
        Task DeleteByConditionAsync<T>(string condition);

        /// <summary>
        /// 根据条件删除
        /// </summary>
        void DeleteByCondition(Type type, string conditions);

        /// <summary>
        /// 根据条件删除
        /// </summary>
        Task DeleteByConditionAsync(Type type, string condition);
    }
}
