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
    public partial class Repeater的使用 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //窗体加载的时候绑定数据
            LoadContacts();
        }

        private void LoadContacts()
        {           
            int pageindex, pagesize, pagecount, recordcount;
            string pIndex = Context.Request.QueryString["pageindex"];
            pageindex = string.IsNullOrEmpty(pIndex) ? 1 : int.Parse(pIndex);
            pagesize = String.IsNullOrEmpty(Context.Request.QueryString["pagesize"]) ? 3 : int.Parse(Context.Request.QueryString["pagesize"]);
            UserHandlerBLL bll = new UserHandlerBLL();
            List<TblArea> area = bll.GetData(pageindex, pagesize, out pagecount, out recordcount);
            this.Repeater1.DataSource = area;
            this.Repeater1.DataBind();
            this.Literal1.Text = PagerHelper.strPage(recordcount, pagesize, pagecount, pageindex, "Repeater.aspx?pagesize=" + pagesize + "&pageindex=");
          
        }
    }
}