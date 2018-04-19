using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class CommonUrl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        HyperLink hy = new HyperLink();

        hy.Text = "台指期貨日盤走勢";
        hy.NavigateUrl = "http://mis.twse.com.tw/stock/futures.jsp";
        hy.Target = "_Blank";

        Page.Controls.Add(hy);

    }
}

