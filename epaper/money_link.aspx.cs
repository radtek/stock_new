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
using System.Data.OleDb;
using System.Drawing;

using System.Net.Mail;
using System.Net;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

public partial class money_link : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        WebClient w = new WebClient();
        //GetEncoding depend on get html web site character set
        w.Encoding = Encoding.GetEncoding("utf-8");
        string strHTML = w.DownloadString("http://www.money-link.com.tw/");
        string title = "MoneyLink-" + DateTime.Now.ToString("yyyy/MM/dd");

        ArrayList maillist = func.FileToArray(Server.MapPath("..\\") + "\\maillist\\money_link_maillist.txt");

        SendEmail("vsoscar@ms26.url.com.tw", maillist[0].ToString(), title, strHTML, "");//

        func.write_log("Send MoneyLink", Server.MapPath("..\\") + "\\RUN_LOG\\", "log");
        func.delete_log_file(Server.MapPath("..\\") + "\\RUN_LOG\\", "*.log", -30);

        Response.Write("<script language=\"javascript\">setTimeout(\"window.opener=null;window.open('','_self');  window.close();\",null)</script>");
        //StringWriter sw = new StringWriter();
        //        HtmlTextWriter htw = new HtmlTextWriter(sw);
        //        Server.Execute("http://172.16.15.10/alarm/QueryForm3.php", htw);
        //        SendEmail("Alarm@innolux.com", "oscar.hsieh@innolux.com,bunny.su@innolux.com", "Alarm Event TOP ", sw.ToString(), "");
        //        //Response.Redirect("mail_detail2.aspx?aid=" + Request.QueryString["aid"].ToString(), false);
    }


    public static void SendEmail(string from, string to, string subject, string body, string cca)
    {
        SmtpClient smtp = new SmtpClient("ms28.hinet.net");
        MailMessage email = new MailMessage(from, to, subject, body);
        if (cca == "")
        {
        }
        else
        {
            email.CC.Add(cca);
            //email.Bcc.Add(cca);
        }

        email.IsBodyHtml = true;
        smtp.Send(email);


    } 

}
