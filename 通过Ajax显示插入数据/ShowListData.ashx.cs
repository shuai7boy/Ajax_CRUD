using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Users.BLL;
using Model;
using System.Web.Script.Serialization;

namespace 通过Ajax显示插入数据
{
    /// <summary>
    /// ShowListData 的摘要说明
    /// </summary>
    public class ShowListData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //获取下拉列表数据
            UserHandlerBLL bll = new UserHandlerBLL();
            List<ContactGroup> list=bll.GetList();
            //转换为json字符串
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string strJson=jss.Serialize(list);
            context.Response.Clear();
            context.Response.Write(strJson);
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