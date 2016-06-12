using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Users.BLL;
using Model;

namespace 通过Ajax显示插入数据
{
    /// <summary>
    /// EditDataById 的摘要说明
    /// </summary>
    public class EditDataById : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //将修改的数据进行保存
            //首先根据键值对获要更新的数据
            TblArea tbl = new TblArea();
            tbl.ContactId = int.Parse(context.Request.Form["hidenId"]);
            tbl.ContactName = context.Request.Form["txtName"];
            tbl.CellPhone = context.Request.Form["txtPhone"];
            tbl.Email = context.Request.Form["txtEmail"];
            tbl.GroupId = new ContactGroup();
            tbl.GroupId.GroupId =int.Parse(context.Request.Form["sel2"]);
            UserHandlerBLL bll = new UserHandlerBLL();
            int rec=bll.UpdateData(tbl);
            context.Response.Clear();
            if (rec > 0)
            {
                context.Response.Write("1");
            }
            else
            {
                context.Response.Write("0");
            }

            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}