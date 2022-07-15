using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using DBUtil;

namespace PostgreSQLTest
{
    public partial class PostgreSQLTest
    {
        [TestMethod]
        public void TestUpdate()
        {
            try
            {
                using (var session = DBHelper.GetSession())
                {
                    SysUser user = session.FindBySql<SysUser>("select * from sys_user");
                    user.UserName = "testUser";
                    user.RealName = "测试插入用户";
                    user.Password = "123456";
                    user.UpdateUserid = "1";
                    user.UpdateTime = DateTime.Now;
                    session.Update(user);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }
    }
}
