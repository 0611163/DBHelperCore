# DBHelper

## 简介

一款轻量级ORM，查询使用原生SQL，查询结果映射到实体类，增删改支持实体类，支持Oracle、MSSQL、MySQL、PostgreSQL、SQLite等多种数据库，有配套Model生成器，方便自己扩展以支持更多数据库

## 特点

1. 支持Oracle、MSSQL、MySQL、PostgreSQL、SQLite五种数据库
2. 方便扩展以支持更多关系数据库
3. 有配套的Model生成器
4. insert、update、delete操作无需写SQL
5. 查询使用原生SQL
6. 查询结果通过映射转成实体类或实体类集合
7. 支持参数化查询，通过SqlString类提供非常方便的参数化查询
8. 支持连接多个数据源
9. 单表查询、单表分页查询、简单的联表分页查询支持Lambda表达式
10. 支持原生SQL和Lambda表达式混写

## 优点

1. 代码实现比较简单，有经验的程序员容易掌控代码，自己修改和扩展
2. 查询使用原生SQL

## 缺点

1. 联表查询对Lambda表达式的支持比较弱
2. 复杂查询不支持Lambda表达式

## 建议

1. 单表查询可以使用Lambda表达式
2. 联表查询以及复杂查询建议使用原生SQL或原生SQL和Lambda表达式混写

## 开发环境

1. VS2019
2. .NET 5

## 作者邮箱

    651029594@qq.com

## 示例

### 定义数据库对象

```C#
public class DBHelper
{
    #region 变量
    private static ISessionHelper _sessionHelper = new SessionHelper(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString(), DBType.MySQL);
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
```

### 使用Model生成器生成实体类

1. 实体类放在Models文件夹中
2. 扩展实体类放在ExtModels文件夹中
3. 实体类和扩展实体类使用partial修饰，实际上是一个类，放在不同的文件中
4. 如果需要添加自定义属性，请修改ExtModels，不要修改Models

#### 实体类示例

```C#
/// <summary>
/// 订单表
/// </summary>
[Serializable]
[DBTable("bs_order")]
public partial class BsOrder
{

    /// <summary>
    /// 主键
    /// </summary>
    [DBKey]
    [DBField]
    public string Id { get; set; }

    /// <summary>
    /// 订单时间
    /// </summary>
    [DBField("order_time")]
    public DateTime OrderTime { get; set; }

    /// <summary>
    /// 订单金额
    /// </summary>
    [DBField]
    public decimal? Amount { get; set; }

    /// <summary>
    /// 下单用户
    /// </summary>
    [DBField("order_userid")]
    public long OrderUserid { get; set; }

    /// <summary>
    /// 订单状态(0草稿 1已下单 2已付款 3已发货 4完成)
    /// </summary>
    [DBField]
    public int Status { get; set; }

    /// <summary>
    /// 备注
    /// </summary>
    [DBField]
    public string Remark { get; set; }

    /// <summary>
    /// 创建者ID
    /// </summary>
    [DBField("create_userid")]
    public string CreateUserid { get; set; }

    /// <summary>
    /// 创建时间
    /// </summary>
    [DBField("create_time")]
    public DateTime CreateTime { get; set; }

    /// <summary>
    /// 更新者ID
    /// </summary>
    [DBField("update_userid")]
    public string UpdateUserid { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    [DBField("update_time")]
    public DateTime? UpdateTime { get; set; }

}
```

### 修改扩展实体类

1. 修改扩展实体类，添加自定义属性
2. 下面的扩展实体类中，查询时OrderUserRealName会被自动填充，查询SQL：select t.*, u.real_name as OrderUserRealName from ......
3. DetailList不会被自动填充，需要手动查询

#### 扩展实体类示例

```C#
/// <summary>
/// 订单表
/// </summary>
public partial class BsOrder
{
    /// <summary>
    /// 订单明细集合
    /// </summary>
    public List<BsOrderDetail> DetailList { get; set; }

    /// <summary>
    /// 下单用户姓名
    /// </summary>
    public string OrderUserRealName { get; set; }

    /// <summary>
    /// 下单用户名
    /// </summary>
    public string OrderUserName { get; set; }
}
```

### 添加

```C#
public void Insert(SysUser info)
{
    using (var session = DBHelper.GetSession())
    {
        session.Insert(info);
    }
}
```

### 批量添加

```C#
public void Insert(List<SysUser> list)
{
    using (var session = DBHelper.GetSession())
    {
        session.Insert(list);
    }
}
```

### 修改

```C#
public void Update(SysUser info)
{
    using (var session = DBHelper.GetSession())
    {
        session.Update(info);
    }
}
```

### 批量修改

```C#
public void Update(List<SysUser> list)
{
    using (var session = DBHelper.GetSession())
    {
        session.Update(list);
    }
}
```

### 删除


```C#
public void Delete(string id)
{
    using (var session = DBHelper.GetSession())
    {
        session.DeleteById<SysUser>(id);
    }
}
```

### 条件删除

```C#
using (var session = DBHelper.GetSession())
{
    session.DeleteByCondition<SysUser>(string.Format("id>=12"));
}
```

### 查询单个记录

```C#
public SysUser Get(string id)
{
    using (var session = DBHelper.GetSession())
    {
        return session.FindById<SysUser>(id);
    }
}
```

```C#
using (var session = DBHelper.GetSession())
{
    return session.FindBySql<SysUser>("select * from sys_user");
}
```

### 简单查询

```C#
using (var session = DBHelper.GetSession())
{
    string sql = "select * from CARINFO_MERGE";
    List<CarinfoMerge> result = session.FindListBySql<CarinfoMerge>(sql);
}
```

### 条件查询

```C#
public List<BsOrder> GetList(int? status, string remark, DateTime? startTime, DateTime? endTime)
{
    using (var session = DBHelper.GetSession())
    {
        SqlString sql = session.CreateSqlString(@"
            select t.*, u.real_name as OrderUserRealName
            from bs_order t
            left join sys_user u on t.order_userid=u.id
            where 1=1");

        sql.AppendIf(status.HasValue, " and t.status=@status", status);

        sql.AppendIf(!string.IsNullOrWhiteSpace(remark), " and t.remark like concat('%',@remark,'%')", remark);

        sql.AppendIf(startTime.HasValue, " and t.order_time>=STR_TO_DATE(@startTime, '%Y-%m-%d %H:%i:%s') ", startTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));

        sql.AppendIf(endTime.HasValue, " and t.order_time<=STR_TO_DATE(@endTime, '%Y-%m-%d %H:%i:%s') ", endTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));

        sql.Append(" order by t.order_time desc, t.id asc ");

        List<BsOrder> list = session.FindListBySql<BsOrder>(sql.SQL, sql.Params);
        return list;
    }
}
```


### 分页查询

```C#
public List<BsOrder> GetListPage(ref PageModel pageModel, int? status, string remark, DateTime? startTime, DateTime? endTime)
{
    using (var session = DBHelper.GetSession())
    {
        SqlString sql = session.CreateSqlString(@"
            select t.*, u.real_name as OrderUserRealName
            from bs_order t
            left join sys_user u on t.order_userid=u.id
            where 1=1");

        sql.AppendIf(status.HasValue, " and t.status=@status", status);

        sql.AppendIf(!string.IsNullOrWhiteSpace(remark), " and t.remark like concat('%',@remark,'%')", remark);

        sql.AppendIf(startTime.HasValue, " and t.order_time>=STR_TO_DATE(@startTime, '%Y-%m-%d %H:%i:%s') ", startTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));

        sql.AppendIf(endTime.HasValue, " and t.order_time<=STR_TO_DATE(@endTime, '%Y-%m-%d %H:%i:%s') ", endTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));

        string orderby = " order by t.order_time desc, t.id asc ";
        pageModel = session.FindPageBySql<BsOrder>(sql.SQL, orderby, pageModel.PageSize, pageModel.CurrentPage, sql.Params);
        return pageModel.GetResult<BsOrder>();
    }
}
```


### 事务

```C#
public string Insert(BsOrder order, List<BsOrderDetail> detailList)
{
    using (var session = DBHelper.GetSession())
    {
        try
        {
            session.BeginTransaction();

            order.Id = Guid.NewGuid().ToString("N");
            order.CreateTime = DateTime.Now;

            decimal amount = 0;
            foreach (BsOrderDetail detail in detailList)
            {
                detail.Id = Guid.NewGuid().ToString("N");
                detail.OrderId = order.Id;
                detail.CreateTime = DateTime.Now;
                amount += detail.Price * detail.Quantity;
                session.Insert(detail);
            }
            order.Amount = amount;

            session.Insert(order);

            session.CommitTransaction();

            return order.Id;
        }
        catch (Exception ex)
        {
            session.RollbackTransaction();
            Console.WriteLine(ex.Message + "\r\n" + ex.StackTrace);
            throw ex;
        }
    }
}
```

### 异步查询

```C#
public async Task<List<BsOrder>> GetListPageAsync(PageModel pageModel, int? status, string remark, DateTime? startTime, DateTime? endTime)
{
    using (var session = await DBHelper.GetSessionAsync())
    {
        SqlString sql = session.CreateSqlString(@"
            select t.*, u.real_name as OrderUserRealName
            from bs_order t
            left join sys_user u on t.order_userid=u.id
            where 1=1");

        sql.AppendIf(status.HasValue, " and t.status=@status", status);

        sql.AppendIf(!string.IsNullOrWhiteSpace(remark), " and t.remark like concat('%',@remark,'%')", remark);

        sql.AppendIf(startTime.HasValue, " and t.order_time>=STR_TO_DATE(@startTime, '%Y-%m-%d %H:%i:%s') ", startTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));

        sql.AppendIf(endTime.HasValue, " and t.order_time<=STR_TO_DATE(@endTime, '%Y-%m-%d %H:%i:%s') ", endTime.Value.ToString("yyyy-MM-dd HH:mm:ss"));

        string orderby = " order by t.order_time desc, t.id asc ";
        pageModel = await session.FindPageBySqlAsync<BsOrder>(sql.SQL, orderby, pageModel.PageSize, pageModel.CurrentPage, sql.Params);
        return pageModel.GetResult<BsOrder>();
    }
}
```

### 条件查询(使用 ForContains、ForStartsWith、ForEndsWith、ForDateTime、ForList 等辅助方法)

```C#
public List<BsOrder> GetListExt(int? status, string remark, DateTime? startTime, DateTime? endTime, string ids)
{
    using (var session = DBHelper.GetSession())
    {
        SqlString sql = session.CreateSqlString(@"
            select t.*, u.real_name as OrderUserRealName
            from bs_order t
            left join sys_user u on t.order_userid=u.id
            where 1=1");

        sql.AppendIf(status.HasValue, " and t.status=@status", status);

        sql.AppendIf(!string.IsNullOrWhiteSpace(remark), " and t.remark like @remark", sql.ForContains(remark));

        sql.AppendIf(startTime.HasValue, " and t.order_time >= @startTime ", sql.ForDateTime(startTime.Value));

        sql.AppendIf(endTime.HasValue, " and t.order_time <= @endTime ", sql.ForDateTime(endTime.Value));

        sql.Append(" and t.id in @ids ", sql.ForList(ids.Split(',').ToList()));

        sql.Append(" order by t.order_time desc, t.id asc ");

        List<BsOrder> list = session.FindListBySql<BsOrder>(sql.SQL, sql.Params);
        return list;
    }
}
```

### 使用Lambda表达式单表查询

单表分页查询使用ToPageList替换ToList即可

```C#
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
```

### 使用Lambda表达式联表分页查询(简单的联表查询，复杂情况请使用原生SQL或原生SQL和Lambda表达式混写)

```C#
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
```

### 原生SQL和Lambda表达式混写

```C#
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
```
