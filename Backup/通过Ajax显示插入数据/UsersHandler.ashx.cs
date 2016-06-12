using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Users.BLL;
using Model;
using CRUD.Utility;
using System.Web.Script.Serialization;

namespace 通过Ajax显示插入数据
{
    /// <summary>
    /// UsersHandler 的摘要说明
    /// </summary>
    public class UsersHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int pageindex, pagesize, pagecount, recordcount;
            string pIndex = context.Request.QueryString["pageindex"];
            string pSize = context.Request.QueryString["pagesize"];
            pageindex = String.IsNullOrEmpty(pIndex) ? 1 : int.Parse(pIndex);
            pagesize = String.IsNullOrEmpty(pSize) ? 3 : int.Parse(pSize);
            UserHandlerBLL bll = new UserHandlerBLL();
            List<TblArea> list= bll.GetData(pageindex, pagesize, out pagecount, out recordcount);
            string strIndex = PagerHelper.strPage(recordcount, pagesize, pagecount, pageindex, "UsersHandler.ashx?pagesize=" + pagesize + "&pageindex=");
            var sendData = new { _pageData=list,_pageIndex=strIndex};
            //序列化为json格式
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string strJson = jss.Serialize(sendData);
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