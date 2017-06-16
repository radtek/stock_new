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
using System.Collections.Generic;
using System.Text.RegularExpressions;

using System.Text;
using System.IO; 
public partial class epaper_Weather_epaper : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WebClient w = new WebClient();
        w.Encoding = Encoding.GetEncoding("utf-8");
        string strHTML = w.DownloadString("http://www.cwb.gov.tw/V7/forecast/week/week.htm");
        
        string title = "中央氣象電子報-" + DateTime.Now.ToString("yyyy/MM/dd");
        ArrayList maillist = func.FileToArray(Server.MapPath("..\\") + "\\maillist\\money_link_maillist.txt");

        func.SendEmail("vsoscar@ms26.url.com.tw", "vsoscar@ms26.url.com.tw", title, strHTML, "","");//
        //SendEmail("vsoscar@ms26.url.com.tw", "vsoscar2003@yahoo.com.hk", title, strHTML, "");//測試寄送程式
        //jrrsc@ms96.url.com.tw
        //fdlsongyy888@hotmail.com,vsoscar2003@yahoo.com.hk,liu.chang@msa.hinet.net,phyllis0531@hotmail.com,m8903157@yahoo.com.tw,benjamin6522@hotmail.com,dai.ww@msa.hinet.net,vrmouse@hotmail.com,roger.liu@infomax.com.tw,Yu.ChiaHao@gmail.com,chin-1520@yahoo.com.tw,heavenlibra@yahoo.com.tw,scm.shen@msa.hinet.net,bakery1202@gmail.com
        //write_log("MAIL");
        WebClient w1 = new WebClient();
        w1.Encoding = Encoding.GetEncoding("utf-8");
        //string strHTML1 = w.DownloadString("http://vsoscar.no-ip.org/stock/three_top_open_cross.php");
        //SAVE_CREATE_FILE(strHTML1);
        func.write_log("Send 中央氣象電子報", Server.MapPath("..\\") + "\\RUN_LOG\\", "log");
        func.delete_log_file(Server.MapPath("..\\") + "\\RUN_LOG\\", "*.log", -30);

        Response.Write("<script language=\"javascript\">setTimeout(\"window.opener=null;window.open('','_self');  window.close();\",null)</script>");
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
            //email.CC.Add(cca);
            email.Bcc.Add(cca);
        }

        email.IsBodyHtml = true;
        smtp.Send(email);


    }
}
