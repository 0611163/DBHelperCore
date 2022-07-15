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
        #region ����
        private BsOrderDal m_BsOrderDal = ServiceHelper.Get<BsOrderDal>();
        private SysUserDal m_SysUserDal = ServiceHelper.Get<SysUserDal>();
        private Random _rnd = new Random();
        private int _count = 10000;
        #endregion

        #region ���캯��
        public CrudPerformanceTest()
        {
            m_BsOrderDal.Preheat(); //Ԥ��
            Log("Ԥ�����");
        }
        #endregion

        #region ɾ��
        [TestMethod]
        public void DeleteTest()
        {
            Log("ɾ�� ��ʼ");
            using (var session = DBHelper.GetSession())
            {
                session.DeleteByCondition<SysUser>(string.Format("id>=12"));
            }
            Log("ɾ�� ���");
        }
        #endregion

        #region ���������޸�
        [TestMethod]
        public void BatchUpdateTest()
        {
            List<SysUser> userList = m_SysUserDal.GetList("select t.* from sys_user t where t.id > 20");

            foreach (SysUser user in userList)
            {
                user.Remark = "�����޸��û�" + _rnd.Next(1, 10000);
                user.UpdateUserid = "1";
                user.UpdateTime = DateTime.Now;
            }

            Log("�����޸� ��ʼ count=" + userList.Count);
            DateTime dt = DateTime.Now;

            m_SysUserDal.Update(userList);

            string time = DateTime.Now.Subtract(dt).TotalSeconds.ToString("0.000");
            Log("�����޸� ��ɣ���ʱ��" + time + "��");
        }
        #endregion

        #region �����������
        [TestMethod]
        public void BatchInsertTest()
        {
            List<SysUser> userList = new List<SysUser>();
            for (int i = 1; i <= _count; i++)
            {
                SysUser user = new SysUser();
                user.UserName = "testUser";
                user.RealName = "���Բ����û�";
                user.Password = "123456";
                user.CreateUserid = "1";
                userList.Add(user);
            }

            Log("������� ��ʼ count=" + userList.Count);
            DateTime dt = DateTime.Now;

            m_SysUserDal.Insert(userList);

            string time = DateTime.Now.Subtract(dt).TotalSeconds.ToString("0.000");
            Log("������� ��ɣ���ʱ��" + time + "��");
        }
        #endregion

        #region ����ѭ���޸�
        [TestMethod]
        public void LoopUpdateTest()
        {
            List<SysUser> userList = m_SysUserDal.GetList("select t.* from sys_user t where t.id > 20");

            foreach (SysUser user in userList)
            {
                user.Remark = "�����޸��û�" + _rnd.Next(1, 10000);
                user.UpdateUserid = "1";
                user.UpdateTime = DateTime.Now;
            }

            Log("ѭ���޸� ��ʼ count=" + userList.Count);
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
            Log("ѭ���޸� ��ɣ���ʱ��" + time + "��");
        }
        #endregion

        #region ����ѭ�����
        [TestMethod]
        public void LoopInsertTest()
        {
            List<SysUser> userList = new List<SysUser>();
            for (int i = 1; i <= _count; i++)
            {
                SysUser user = new SysUser();
                user.UserName = "testUser";
                user.RealName = "���Բ����û�";
                user.Password = "123456";
                user.CreateUserid = "1";
                userList.Add(user);
            }

            Log("ѭ����� ��ʼ count=" + userList.Count);
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
            Log("ѭ����� ��ɣ���ʱ��" + time + "��");
        }
        #endregion

        #region ��ѯ
        [TestMethod]
        public void QueryTest()
        {
            Log("��ѯ ��ʼ");
            DateTime dt = DateTime.Now;

            for (int i = 0; i < 10; i++)
            {
                using (var session = DBHelper.GetSession())
                {
                    SqlString sql = session.CreateSqlString(@"
                            select t.* 
                            from sys_user t 
                            where t.id > @id 
                            and t.real_name like concat('%',@remark,'%')", 20, "����");

                    string orderBy = " order by t.create_time desc, t.id asc";

                    List<SysUser> userList = session.FindListBySql<SysUser>(sql.SQL + orderBy, sql.Params);
                    Log("��ѯ��� count=" + userList.Count.ToString());
                }
            }

            string time = DateTime.Now.Subtract(dt).TotalSeconds.ToString("0.000");
            Log("��ѯ ��ɣ���ʱ��" + time + "��");
        }
        #endregion

        #region ��ҳ��ѯ
        [TestMethod]
        public void QueryPageTest()
        {
            Log("��ҳ��ѯ ��ʼ");
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
                                and t.real_name like concat('%',@remark,'%')", 20, "����");

                        string orderBy = " order by t.create_time desc, t.id asc";

                        userList.AddRange(session.FindPageBySql<SysUser>(sql.SQL, orderBy, pageSize, page, sql.Params).Result as List<SysUser>);
                    }
                    Log("��ҳ��ѯ��� count=" + userList.Count.ToString());
                }
            }

            string time = DateTime.Now.Subtract(dt).TotalSeconds.ToString("0.000");
            Log("��ҳ��ѯ ��ɣ���ʱ��" + time + "��");
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
