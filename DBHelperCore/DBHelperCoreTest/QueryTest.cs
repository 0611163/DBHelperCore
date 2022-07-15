using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using DAL;
using System.Collections.Generic;
using DBUtil;
using Utils;

namespace DBHelperCoreTest
{
    [TestClass]
    public class QueryTest
    {
        #region 变量
        private BsOrderDal m_BsOrderDal = ServiceHelper.Get<BsOrderDal>();
        #endregion

        #region 构造函数
        public QueryTest()
        {
            m_BsOrderDal.Preheat();
        }
        #endregion

        #region 测试查询订单集合
        [TestMethod]
        public void TestQuery()
        {
            List<BsOrder> list = m_BsOrderDal.GetList(0, "订单", DateTime.MinValue, DateTime.Now.AddDays(1), "100001,100002,100003");

            foreach (BsOrder item in list)
            {
                Console.WriteLine(ModelToStringUtil.ToString(item));
            }
        }
        #endregion

        #region 测试分页查询订单集合
        [TestMethod]
        public void TestQueryPage()
        {
            PageModel pageModel = new PageModel();
            pageModel.CurrentPage = 1;
            pageModel.PageSize = 10;

            List<BsOrder> list = m_BsOrderDal.GetListPage(ref pageModel, 0, null, DateTime.MinValue, DateTime.Now.AddDays(1));

            foreach (BsOrder item in list)
            {
                Console.WriteLine(ModelToStringUtil.ToString(item));
            }
        }
        #endregion

        #region 测试查询订单集合(使用 ForContains、ForStartsWith、ForEndsWith、ForDateTime、ForList 等辅助方法)
        [TestMethod]
        public void TestQueryExt()
        {
            List<BsOrder> list = m_BsOrderDal.GetListExt(0, "订单", DateTime.MinValue, DateTime.Now.AddDays(1), "100001,100002,100003");

            foreach (BsOrder item in list)
            {
                Console.WriteLine(ModelToStringUtil.ToString(item));
            }
        }
        #endregion

        #region 测试查询订单集合(使用 Lambda 表达式)(传变量)
        [TestMethod]
        public void TestQueryByLambda1()
        {
            int status = 0;
            string remark = "订单";
            DateTime? startTime = new DateTime(2010, 1, 1);
            DateTime? endTime = DateTime.Now.AddDays(1);

            using (var session = DBHelper.GetSession())
            {
                SqlString<BsOrder> sql = session.CreateSqlString<BsOrder>(@"
                    select t.*, u.real_name as OrderUserRealName
                    from bs_order t
                    left join sys_user u on t.order_userid=u.id
                    where 1=1");

                List<BsOrder> list = sql.Where(t => t.Status == status
                    && t.Remark.Contains(remark.ToString())
                    && t.OrderTime >= startTime.Value
                    && t.OrderTime <= endTime.Value)
                    .OrderByDescending(t => t.OrderTime).OrderBy(t => t.Id)
                    .ToList();

                foreach (BsOrder item in list)
                {
                    Console.WriteLine(ModelToStringUtil.ToString(item));
                }
            }
        }
        #endregion

        #region 测试查询订单集合(使用 Lambda 表达式)(传值)
        [TestMethod]
        public void TestQueryByLambda2()
        {
            using (var session = DBHelper.GetSession())
            {
                SqlString<BsOrder> sql = session.CreateSqlString<BsOrder>(@"
                    select t.*, u.real_name as OrderUserRealName
                    from bs_order t
                    left join sys_user u on t.order_userid=u.id
                    where 1=1");

                List<BsOrder> list = sql.Where(t => t.Status == int.Parse("0")
                    && t.Status == new BsOrder().Status
                    && t.Remark.Contains("订单")
                    && t.Remark != null
                    && t.OrderTime >= new DateTime(2010, 1, 1)
                    && t.OrderTime <= DateTime.Now.AddDays(1))
                    .OrderByDescending(t => t.OrderTime).OrderBy(t => t.Id)
                    .ToList();

                foreach (BsOrder item in list)
                {
                    Console.WriteLine(ModelToStringUtil.ToString(item));
                }
            }
        }
        #endregion

        #region 测试查询订单集合(使用 Lambda 表达式)(传对象的变量)
        [TestMethod]
        public void TestQueryByLambda3()
        {
            BsOrder order = new BsOrder();
            order.Status = 0;
            order.Remark = "订单";

            var time = new
            {
                startTime = new DateTime(2010, 1, 1),
                endTime = DateTime.Now.AddDays(1)
            };

            List<string> idsNotIn = new List<string>() { "100007", "100008", "100009" };

            using (var session = DBHelper.GetSession())
            {
                SqlString<BsOrder> sql = session.CreateSqlString<BsOrder>(@"
                    select t.*, u.real_name as OrderUserRealName
                    from bs_order t
                    left join sys_user u on t.order_userid=u.id
                    where 1=1");

                List<BsOrder> list = sql.Where(t => t.Status == order.Status
                    && t.Remark.Contains(order.Remark.ToString())
                    && t.OrderTime >= time.startTime
                    && t.OrderTime <= time.endTime
                    && !idsNotIn.Contains(t.Id))
                    .OrderByDescending(t => t.OrderTime).OrderBy(t => t.Id)
                    .ToList();

                foreach (BsOrder item in list)
                {
                    Console.WriteLine(ModelToStringUtil.ToString(item));
                }
            }
        }
        #endregion

        #region 测试查询订单集合(使用 Lambda 表达式)(单个条件)
        [TestMethod]
        public void TestQueryByLambda4()
        {
            var time = new
            {
                startTime = new DateTime(2010, 1, 1),
                endTime = DateTime.Now.AddDays(1)
            };

            DateTime dt = new DateTime(2010, 1, 1);

            List<string> ids = new List<string>() { "100001", "100002", "100003" };

            List<string> idsNotIn = new List<string>() { "100007", "100008", "100009" };

            using (var session = DBHelper.GetSession())
            {
                SqlString<BsOrder> sql = session.CreateSqlString<BsOrder>(@"
                    select t.*, u.real_name as OrderUserRealName
                    from bs_order t
                    left join sys_user u on t.order_userid=u.id
                    where 1=1");

                sql.Where(t => t.Status >= 0);

                sql.Where(t => t.Remark.StartsWith("订单"));

                sql.Where(t => t.Remark.StartsWith(GetStr(9)));

                sql.Where(t => t.OrderTime >= time.startTime);

                sql.Where(t => t.OrderTime >= dt);

                sql.Where(t => t.OrderTime >= DateTime.Parse(new DateTime(2010, 1, 1).ToString("yyyy-MM-dd HH:mm:ss")));

                // sql.Where<BsOrder>(t => ids.Contains(t.Id)); //同一个字段不能同时 in 和 not in

                sql.Where(t => !idsNotIn.Contains(t.Id));

                sql.Append(" order by t.order_time desc, t.id asc ");

                List<BsOrder> list = session.FindListBySql<BsOrder>(sql.SQL, sql.Params);
                foreach (BsOrder item in list)
                {
                    Console.WriteLine(ModelToStringUtil.ToString(item));
                }
            }
        }

        private string GetStr(int n)
        {
            return "订单";
        }
        #endregion

        #region 测试查询订单集合(使用 Lambda 表达式)(单表查询)
        [TestMethod]
        public void TestQueryByLambda6()
        {
            using (var session = DBHelper.GetSession())
            {
                SqlString<BsOrder> sql = session.CreateSqlString<BsOrder>();

                string remark = "测试";

                List<BsOrder> list = sql.Query()

                    .WhereIf(!string.IsNullOrWhiteSpace(remark),
                        t => t.Remark.Contains(remark)
                        && t.CreateTime < DateTime.Now
                        && t.CreateUserid == "10")

                    .OrderByDescending(t => t.OrderTime).OrderBy(t => t.Id)
                    .ToList();

                foreach (BsOrder item in list)
                {
                    Console.WriteLine(ModelToStringUtil.ToString(item));
                }
            }
        }
        #endregion

        #region 测试查询订单集合(使用 Lambda 表达式)(单表分页查询)
        [TestMethod]
        public void TestQueryByLambda8()
        {
            using (var session = DBHelper.GetSession())
            {
                SqlString<BsOrder> sql = session.CreateSqlString<BsOrder>();

                int total = 0;
                string remark = "测试";

                List<BsOrder> list = sql.Query()

                    .WhereIf(!string.IsNullOrWhiteSpace(remark),
                        t => t.Remark.Contains(remark)
                        && t.CreateTime < DateTime.Now
                        && t.CreateUserid == "10")

                    .OrderByDescending(t => t.OrderTime).OrderBy(t => t.Id)
                    .ToPageList(1, 20, out total);

                foreach (BsOrder item in list)
                {
                    Console.WriteLine(ModelToStringUtil.ToString(item));
                }
            }
        }
        #endregion

        #region 测试查询订单集合(使用 Lambda 表达式)(连表查询)
        [TestMethod]
        public void TestQueryByLambda5()
        {
            using (var session = DBHelper.GetSession())
            {
                SqlString<BsOrder> sql = session.CreateSqlString<BsOrder>();

                List<BsOrder> list = sql.Query()
                    .Select<SysUser>(u => u.UserName, t => t.OrderUserName)
                    .Select<SysUser>(u => u.RealName, t => t.OrderUserRealName)
                    .LeftJoin<SysUser>((t, u) => t.OrderUserid == u.Id)
                    .LeftJoin<BsOrderDetail>((t, d) => t.Id == d.OrderId)
                    .Where<SysUser, BsOrderDetail>((t, u, d) => t.Remark.Contains("订单") && u.CreateUserid == "1" && d.GoodsName == "电脑")
                    .WhereIf<BsOrder>(true, t => t.Remark.Contains("测试"))
                    .WhereIf<SysUser>(true, u => u.CreateUserid == "1")
                    .OrderByDescending(t => t.OrderTime).OrderBy(t => t.Id)
                    .ToList();

                foreach (BsOrder item in list)
                {
                    Console.WriteLine(ModelToStringUtil.ToString(item));
                }
            }
        }
        #endregion

        #region 测试查询订单集合(使用 Lambda 表达式)(连表分页查询)
        [TestMethod]
        public void TestQueryByLambda7()
        {
            using (var session = DBHelper.GetSession())
            {
                SqlString<BsOrder> sql = session.CreateSqlString<BsOrder>();

                int total;
                List<string> idsNotIn = new List<string>() { "100007", "100008", "100009" };

                List<BsOrder> list = sql.Query()
                    .Select<SysUser>(u => u.UserName, t => t.OrderUserName)
                    .Select<SysUser>(u => u.RealName, t => t.OrderUserRealName)
                    .LeftJoin<SysUser>((t, u) => t.OrderUserid == u.Id)
                    .LeftJoin<BsOrderDetail>((t, d) => t.Id == d.OrderId)
                    .Where<SysUser, BsOrderDetail>((t, u, d) => t.Remark.Contains("订单") && u.CreateUserid == "1" && d.GoodsName != null)
                    .WhereIf<BsOrder>(true, t => t.Remark.Contains("测试"))
                    .WhereIf<BsOrder>(true, t => !idsNotIn.Contains(t.Id))
                    .WhereIf<SysUser>(true, u => u.CreateUserid == "1")
                    .OrderByDescending(t => t.OrderTime).OrderBy(t => t.Id)
                    .ToPageList(1, 20, out total);

                foreach (BsOrder item in list)
                {
                    Console.WriteLine(ModelToStringUtil.ToString(item));
                }
            }
        }
        #endregion

        #region 测试查询订单集合(使用 Lambda 表达式)(原生SQL和Lambda表达式混写)
        [TestMethod]
        public void TestQueryByLambda9()
        {
            using (var session = DBHelper.GetSession())
            {
                SqlString<BsOrder> sql = session.CreateSqlString<BsOrder>(@"
                    select t.*, u.real_name as OrderUserRealName
                    from bs_order t
                    left join sys_user u on t.order_userid=u.id
                    where 1=1");

                List<BsOrder> list = sql.Where(t => t.Status == int.Parse("0")
                    && t.Status == new BsOrder().Status
                    && t.Remark.Contains("订单")
                    && t.Remark != null
                    && t.OrderTime >= new DateTime(2010, 1, 1)
                    && t.OrderTime <= DateTime.Now.AddDays(1))
                    .WhereIf<SysUser>(true, u => u.CreateTime < DateTime.Now)
                    .OrderByDescending(t => t.OrderTime).OrderBy(t => t.Id)
                    .ToList();

                foreach (BsOrder item in list)
                {
                    Console.WriteLine(ModelToStringUtil.ToString(item));
                }
            }
        }
        #endregion

        #region 测试查询订单集合(使用 Lambda 表达式)(临时测试)
        [TestMethod]
        public void TestQueryByLambda10()
        {
            using (var session = DBHelper.GetSession())
            {
                SqlString<BsOrder> sql = session.CreateSqlString<BsOrder>();

                string remark = "测试";

                List<BsOrder> list = sql.Query()

                    .WhereIf(!string.IsNullOrWhiteSpace(remark),
                        t => t.Remark.Contains(remark)
                        && t.CreateTime < DateTime.Now
                        && !t.CreateUserid.Contains(string.Format("12{0}", 3)))

                    .OrderByDescending(t => t.OrderTime).OrderBy(t => t.Id)
                    .ToList();

                foreach (BsOrder item in list)
                {
                    Console.WriteLine(ModelToStringUtil.ToString(item));
                }
            }
        }
        #endregion

    }
}
