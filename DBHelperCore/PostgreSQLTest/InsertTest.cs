using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using DBUtil;

namespace PostgreSQLTest
{
    public partial class PostgreSQLTest
    {
        [TestMethod]
        public void TestInsert()
        {
            try
            {
                Random rnd = new Random();
                SysUser user = new SysUser();
                user.Id = rnd.Next(0, 1000000);
                user.UserName = "testUser";
                user.RealName = "测试插入用户";
                user.Password = "123456";
                user.CreateUserid = "1";

                using (var session = DBHelper.GetSession())
                {
                    user.CreateTime = DateTime.Now;
                    session.Insert(user);
                    //long id = session.GetSingle<long>("select @@IDENTITY");
                    //user.Id = id;
                }

                Console.WriteLine("user.Id=" + user.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }
    }
}
