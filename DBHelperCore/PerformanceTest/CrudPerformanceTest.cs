using DAL;
using DBUtil;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utils;

namespace CrudPerformanceTest
{
    [TestClass]
    public class CrudPerformanceTest
    {
        #region 变量
        private BsOrderDal m_BsOrderDal = ServiceHelper.Get<BsOrderDal>();
        private SysUserDal m_SysUserDal = ServiceHelper.Get<SysUserDal>();
        private Random _rnd = new Random();
        private int _count = 10000;
        #endregion

        #region 构造函数
        public CrudPerformanceTest()
        {
            m_BsOrderDal.Preheat(); //预热
            Log("预热完成");
        }
        #endregion

        #region 删除
        [TestMethod]
        public void DeleteTest()
        {
            Log("删除 开始");
            using (var session = DBHelper.GetSession())
            {
                session.DeleteByCondition<SysUser>(string.Format("id>=12"));
            }
            Log("删除 完成");
        }
        #endregion

        #region 测试批量修改
        [TestMethod]
        public void BatchUpdateTest()
        {
            List<SysUser> userList = m_SysUserDal.GetList("select t.* from sys_user t where t.id > 20");

            foreach (SysUser user in userList)
            {
                user.Remark = "测试修改用户" + _rnd.Next(1, 10000);
                user.UpdateUserid = "1";
                user.UpdateTime = DateTime.Now;
            }

            Log("批量修改 开始 count=" + userList.Count);
            DateTime dt = DateTime.Now;

            m_SysUserDal.Update(userList);

            string time = DateTime.Now.Subtract(dt).TotalSeconds.ToString("0.000");
            Log("批量修改 完成，耗时：" + time + "秒");
        }
        #endregion

        #region 测试批量添加
        [TestMethod]
        public void BatchInsertTest()
        {
            List<SysUser> userList = new List<SysUser>();
            for (int i = 1; i <= _count; i++)
            {
                SysUser user = new SysUser();
                user.UserName = "testUser";
                user.RealName = "测试插入用户";
                user.Password = "123456";
                user.CreateUserid = "1";
                userList.Add(user);
            }

            Log("批量添加 开始 count=" + userList.Count);
            DateTime dt = DateTime.Now;

            m_SysUserDal.Insert(userList);

            string time = DateTime.Now.Subtract(dt).TotalSeconds.ToString("0.000");
            Log("批量添加 完成，耗时：" + time + "秒");
        }
        #endregion

        #region 测试循环修改
        [TestMethod]
        public void LoopUpdateTest()
        {
            List<SysUser> userList = m_SysUserDal.GetList("select t.* from sys_user t where t.id > 20");

            foreach (SysUser user in userList)
            {
                user.Remark = "测试修改用户" + _rnd.Next(1, 10000);
                user.UpdateUserid = "1";
                user.UpdateTime = DateTime.Now;
            }

            Log("循环修改 开始 count=" + userList.Count);
            DateTime dt = DateTime.Now;

            using (var session = DBHelper.GetSession())
            {
                try
                {
                    session.BeginTransaction();
                    foreach (SysUser user in userList)
                    {
                        session.Update(user);
                    }
                    session.CommitTransaction();
                }
                catch (Exception ex)
                {
                    session.RollbackTransaction();
                    throw ex;
                }
            }

            string time = DateTime.Now.Subtract(dt).TotalSeconds.ToString("0.000");
            Log("循环修改 完成，耗时：" + time + "秒");
        }
        #endregion

        #region 测试循环添加
        [TestMethod]
        public void LoopInsertTest()
        {
            List<SysUser> userList = new List<SysUser>();
            for (int i = 1; i <= _count; i++)
            {
                SysUser user = new SysUser();
                user.UserName = "testUser";
                user.RealName = "测试插入用户";
                user.Password = "123456";
                user.CreateUserid = "1";
                userList.Add(user);
            }

            Log("循环添加 开始 count=" + userList.Count);
            DateTime dt = DateTime.Now;

            using (var session = DBHelper.GetSession())
            {
                try
                {
                    session.BeginTransaction();
                    foreach (SysUser user in userList)
                    {
                        session.Insert(user);
                    }
                    session.CommitTransaction();
                }
                catch (Exception ex)
                {
                    session.RollbackTransaction();
                    throw ex;
                }
            }

            string time = DateTime.Now.Subtract(dt).TotalSeconds.ToString("0.000");
            Log("循环添加 完成，耗时：" + time + "秒");
        }
        #endregion

        #region 查询
        [TestMethod]
        public void QueryTest()
        {
            Log("查询 开始");
            DateTime dt = DateTime.Now;

            for (int i = 0; i < 10; i++)
            {
                using (var session = DBHelper.GetSession())
                {
                    SqlString sql = session.CreateSqlString(@"
                            select t.* 
                            from sys_user t 
                            where t.id > @id 
                            and t.real_name like concat('%',@remark,'%')", 20, "测试");

                    string orderBy = " order by t.create_time desc, t.id asc";

                    List<SysUser> userList = session.FindListBySql<SysUser>(sql.SQL + orderBy, sql.Params);
                    Log("查询结果 count=" + userList.Count.ToString());
                }
            }

            string time = DateTime.Now.Subtract(dt).TotalSeconds.ToString("0.000");
            Log("查询 完成，耗时：" + time + "秒");
        }
        #endregion

        #region 分页查询
        [TestMethod]
        public void QueryPageTest()
        {
            Log("分页查询 开始");
            DateTime dt = DateTime.Now;

            for (int i = 0; i < 10; i++)
            {
                int total = m_SysUserDal.GetTotalCount();
                int pageSize = 100;
                int pageCount = (total - 1) / pageSize + 1;
                using (var session = DBHelper.GetSession())
                {
                    List<SysUser> userList = new List<SysUser>();
                    for (int page = 1; page <= pageCount; page++)
                    {
                        SqlString sql = session.CreateSqlString(@"
                                select t.* 
                                from sys_user t 
                                where 1=1 
                                and t.id > @id 
                                and t.real_name like concat('%',@remark,'%')", 20, "测试");

                        string orderBy = " order by t.create_time desc, t.id asc";

                        userList.AddRange(session.FindPageBySql<SysUser>(sql.SQL, orderBy, pageSize, page, sql.Params).Result as List<SysUser>);
                    }
                    Log("分页查询结果 count=" + userList.Count.ToString());
                }
            }

            string time = DateTime.Now.Subtract(dt).TotalSeconds.ToString("0.000");
            Log("分页查询 完成，耗时：" + time + "秒");
        }
        #endregion

        #region Log
        public void Log(string log)
        {
            Console.WriteLine(log);
        }
        #endregion

    }
}
