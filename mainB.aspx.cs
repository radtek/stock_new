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
using System.Drawing;

public partial class mainB : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Label2.Text = "歡迎登入：" + Session["user_name"] + "(" + Session["user_id"] + ")";
        string today = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd HH:mm:ss");
        string date2 = DateTime.Now.DayOfWeek.ToString();
        string date3 = func.GetWeekOfCurrDate(DateTime.Now);
        Label3.Text = today;
        Label3.ForeColor = Color.Blue;
        Label4.Text = date2;
        Label4.ForeColor = Color.Blue;
        if (date3.Length == 6)
        {
            Label5.Text = date3.Substring(4, 2);

        }
        else
        {

            Label5.Text = date3.Substring(4, 1);
        }
        Label5.ForeColor = Color.Blue;

        DateTime dt = DateTime.Parse(today);
        string AA = dt.ToString("dddd");
        Label1.Text = AA;
        Label1.ForeColor = Color.Red;
    }
}
