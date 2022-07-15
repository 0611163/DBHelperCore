using DBUtil;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace PostgreSQLTest
{
    [TestClass]
    public partial class PostgreSQLTest
    {
        [TestMethod]
        public void TestQuery()
        {
            try
            {
                List<SysUser> list = new List<Models.SysUser>();
                using (var session = DBHelper.GetSession())
                {
                    list = session.FindListBySql<SysUser>("select * from sys_user");
                }

                foreach (SysUser item in list)
                {
                    Console.WriteLine(ModelToStringUtil.ToString(item));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

        [TestMethod]
        public void TestPageQuery()
        {
            try
            {
                using (var session = DBHelper.GetSession())
                {
                    PageModel pageModel = new PageModel();
                    pageModel.CurrentPage = 2;
                    pageModel.PageSize = 5;

                    SqlString sql = session.CreateSqlString(@"
                        select t.*
                        from sys_user t
                        where 1=1");

                    sql.Append(@" and t.""RealName"" like concat('%',@RealName,'%')", "测试");

                    string orderby = @" order by t.""Id"" ";
                    pageModel = session.FindPageBySql<SysUser>(sql.SQL, orderby, pageModel.PageSize, pageModel.CurrentPage, sql.Params);
                    List<SysUser> list = pageModel.GetResult<SysUser>();
                    foreach (SysUser item in list)
                    {
                        Console.WriteLine(ModelToStringUtil.ToString(item));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }
        }

        /// <summary>
        /// Lambda表达式 单表分页查询
        /// </summary>
        [TestMethod]
        public void TestQueryByLambda()
        {
            try
            {
                using (var session = DBHelper.GetSession())
                {
                    SqlString<SysUser> sql = session.CreateSqlString<SysUser>();

                    int total = 0;
                    string realName = "测试";

                    List<SysUser> list = sql.Query()

                        .WhereIf(!string.IsNullOrWhiteSpace(realName),
                            t => t.RealName.Contains(realName)
                            && t.CreateTime < DateTime.Now
                            && t.CreateUserid == "1")

                        .OrderBy(t => t.Id)
                        .ToPageList(1, 20, out total);

                    foreach (SysUser item in list)
                    {
                        Console.WriteLine(ModelToStringUtil.ToString(item));
                    }
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
