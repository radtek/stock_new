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


public partial class SMS_Send_SMS : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["jump"];
    string sql_insert = "";
    string sql_insert1 = "";
    string sql_update = "";
    DataSet ds_temp = new DataSet();
    DataSet ds_temp1 = new DataSet();
    DataSet ds_temp2 = new DataSet();
    string today = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd");
    string today_detail = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd HH:mm");
    string ServerName = "api.hiair.hinet.net";
    string ServerPort = "8000";
    string UserID = "";
    string Passwd = "";
    string MobileNum = "";
    string Message = "";
    string Send_Type_Check = "";
    string Reserve_Time = "";
    string Result = "";
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
     UserID=TextBox1.Text;
     Passwd=TextBox2.Text;
     MobileNum=TextBox3.Text;
     Message=TextBox4.Text;
     Object Socket2Air = Server.CreateObject("HiAir.HiNetSMS");
     Result = Socket2Air.StartCon(ServerName,ServerPort,UserID,Passwd);
     Response.Write("傳送結果 : " + Result);


    


  Send_Type_Check = RealTime.Text;
  Reserve_Time = TextBox6.Text;
    }
}
