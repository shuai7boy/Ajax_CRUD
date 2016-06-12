using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;
using 三层__登录;

namespace Users.DAL
{
    public class UserHandlerDAL
    {
        //显示查询到的数据
        public List<TblArea> GetData(int pageindex, int pagesize, out int pagecount, out int recordcount)
        {
            List<TblArea> list = new List<TblArea>();
            string sql = "usp_FenYe";
            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@pageindex",SqlDbType.Int){Value=pageindex},
                new SqlParameter("@pagesize",SqlDbType.Int){Value=pagesize},
                new SqlParameter("@pagecount",SqlDbType.Int){Direction=ParameterDirection.Output},
                new SqlParameter("@recordcount",SqlDbType.Int){Direction=ParameterDirection.Output}
            };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.StoredProcedure, pms))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        TblArea area = new TblArea();
                        area.ContactId = reader.GetInt32(0);
                        area.ContactName = reader.GetString(1);
                        area.CellPhone = reader.GetString(2);
                        area.Email = reader.GetString(3);
                        area.GroupId = new ContactGroup();
                        area.GroupId.GroupId = reader.GetInt32(4);
                        area.GroupId.GroupName = reader.GetString(5);
                        list.Add(area);
                    }
                }
            }
            pagecount =int.Parse(pms[2].Value.ToString());
            recordcount = int.Parse(pms[3].Value.ToString());
            return list;
        }
        //获取下拉列表数据
        public List<ContactGroup> GetList()
        {
            List<ContactGroup> list = new List<ContactGroup>();
            string sql = "select * from ContactGroup";
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ContactGroup group = new ContactGroup();
                        group.GroupId = reader.GetInt32(0);
                        group.GroupName = reader.GetString(1);
                        list.Add(group);
                    }
                }
            }
            return list;
        }
        //向数据库中插入数据
        public int InsertData(TblArea tbl)
        {
            string sql = "insert into TblArea values(@name,@phone,@email,@groupId)";
            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@name",SqlDbType.NVarChar,10){Value=tbl.ContactName},
                new SqlParameter("@phone",SqlDbType.NChar,50){Value=tbl.CellPhone},
                new SqlParameter("@email",SqlDbType.NChar,50){Value=tbl.Email},
                new SqlParameter("@groupId",SqlDbType.Int){Value=tbl.GroupId.GroupId}
            };
            return SqlHelper.ExecuteNonquery(sql, CommandType.Text, pms);
        }
        //删除数据库中的语句
        public int DeleteData(int id)
        {
            string sql = "delete TblArea where contactId=@id";
            SqlParameter pms = new SqlParameter("@id", SqlDbType.Int) { Value = id };
            return SqlHelper.ExecuteNonquery(sql, CommandType.Text, pms);
        }
        //根据id查询编辑的内容
        public TblArea GetDataById(int id)
        {
            TblArea area = new TblArea();
            string sql = "select * from TblArea where contactId=@id";
            SqlParameter pms = new SqlParameter("@id", SqlDbType.Int) { Value = id };
            using (SqlDataReader reader = SqlHelper.ExecuteReader(sql, CommandType.Text, pms))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        area.ContactId = reader.GetInt32(0);
                        area.ContactName = reader.GetString(1);
                        area.CellPhone = reader.GetString(2);
                        area.Email = reader.GetString(3);
                        area.GroupId = new ContactGroup();
                        area.GroupId.GroupId = reader.GetInt32(4);
                    }
                }
            }
            return area;
        }
        //更新用户要编辑的数据
        public int UpdateData(TblArea ta)
        {
            string sql = "update TblArea set contactName=@name,cellPhone=@phone,email=@email,groupId=@gId where contactId=@id";
            SqlParameter[] pms = new SqlParameter[]{
                new SqlParameter("@name",SqlDbType.NVarChar,10){Value=ta.ContactName},
                new SqlParameter("@phone",SqlDbType.NChar,50){Value=ta.CellPhone},
                new SqlParameter("@email",SqlDbType.NChar,50){Value=ta.Email},
                new SqlParameter("@gId",SqlDbType.Int){Value=ta.GroupId.GroupId},
                new SqlParameter("@id",SqlDbType.Int){Value=ta.ContactId}
            };
            return SqlHelper.ExecuteNonquery(sql, CommandType.Text, pms);
        }
    }
}
