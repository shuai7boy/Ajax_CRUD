using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Users.BLL;

namespace 通过Ajax显示插入数据
{
    /// <summary>
    /// DeleteDataById 的摘要说明
    /// </summary>
    public class DeleteDataById : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
           //接收用户传过来的id，执行删除语句
            int id =int.Parse(context.Request.QueryString["id"]);
            UserHandlerBLL bll = new UserHandlerBLL();
            int rec=bll.DeleteData(id);
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