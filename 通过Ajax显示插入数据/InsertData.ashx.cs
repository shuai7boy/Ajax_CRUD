using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Users.BLL;
using Model;

namespace 通过Ajax显示插入数据
{
    /// <summary>
    /// InsertData 的摘要说明
    /// </summary>
    public class InsertData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //获取用户发送过来的数据
            TblArea area = new TblArea();
            area.ContactName = context.Request.Form["txtName"];
            area.CellPhone = context.Request.Form["txtPhone"];
            area.Email = context.Request.Form["txtEmail"];
            area.GroupId = new ContactGroup();
            area.GroupId.GroupId =int.Parse(context.Request.Form["sel1"]);
            UserHandlerBLL bll = new UserHandlerBLL();
            int rec=bll.InsertData(area);
            context.Response.Clear();
            context.Response.Write(rec);
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