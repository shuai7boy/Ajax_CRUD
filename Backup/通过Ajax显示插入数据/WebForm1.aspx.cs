using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Users.BLL;
using Model;
using CRUD.Utility;

namespace 通过Ajax显示插入数据
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取数据绑定控件
            GetDataForBind();
        }

        private void GetDataForBind()
        {            
            int pageindex, pagesize, pagecount, recordcount;
            pageindex = string.IsNullOrEmpty(Context.Request.QueryString["pageindex"]) ? 1 : Convert.ToInt32(Context.Request.QueryString["pageindex"]);
            pagesize = string.IsNullOrEmpty(Context.Request.QueryString["pagesize"]) ? 3 : Convert.ToInt32(Context.Request.QueryString["pagesize"]);
            UserHandlerBLL bll = new UserHandlerBLL();
            List<TblArea>  list=bll.GetData(pageindex, pagesize, out pagecount, out recordcount);
            this.Repeater1.DataSource = list;
            this.Repeater1.DataBind();
          this.Literal1.Text=PagerHelper.strPage(recordcount, pagesize, pagecount, pageindex, "WebForm1.aspx?pagesize=" + pagesize + "&pageindex=");

        }
    }
}