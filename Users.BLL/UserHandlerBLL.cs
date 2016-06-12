using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using Users.DAL;

namespace Users.BLL
{
    public class UserHandlerBLL
    {
          //显示查询到的数据
        UserHandlerDAL dal = new UserHandlerDAL();
        public List<TblArea> GetData(int pageindex, int pagesize, out int pagecount, out int recordcount)
        {           
            return dal.GetData(pageindex, pagesize, out pagecount, out recordcount);
        }
                //获取下拉列表数据
        public List<ContactGroup> GetList()
        {
            return dal.GetList();
        }
        //向数据库中插入数据
        public int InsertData(TblArea tbl)
        {
            return dal.InsertData(tbl);
        }
         //删除数据库中的语句
        public int DeleteData(int id)
        {
            return dal.DeleteData(id);
        }
          //根据id查询编辑的内容
        public TblArea GetDataById(int id)
        {
            return dal.GetDataById(id);
        }
         //更新用户要编辑的数据
        public int UpdateData(TblArea ta)
        {
            return dal.UpdateData(ta);
        }
    }
}
