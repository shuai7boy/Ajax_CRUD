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
    /// ShowDataById 的摘要说明
    /// </summary>
    public class ShowDataById : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
           //根据id获取用户要编辑的内容 并显示到前端
            int id=int.Parse(context.Request.QueryString["id"]);
            UserHandlerBLL bll = new UserHandlerBLL();
            TblArea area=bll.GetDataById(id);
            //转换为json字符串
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string strJson=jss.Serialize(area);
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