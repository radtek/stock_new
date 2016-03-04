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

public partial class EMS_EMS_EPAPER : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["jump"];
    string sql = "";
    DataSet ds_temp = new DataSet();
    DataSet ds_temp1 = new DataSet();
     string today_add3 = DateTime.Now.AddDays(+3).ToString("yyyy/MM/dd");
    string today_detail = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd HH:mm");
    protected void Page_Load(object sender, EventArgs e)
    {

      

        WebClient w = new WebClient();
        w.Encoding = Encoding.GetEncoding("Big5");
        //string strHTML = w.DownloadString("");
        string strHTML = "";

        string sql = "select format(t.event_dttm,'yyyy/MM/dd') as event_dttm,t.event_name,t.email  from ems_event t where format(t.event_dttm,'yyyy/MM/dd')='" + today_add3 + "' and t.flag='Y' ";

        ds_temp = func.get_dataSet_access(sql, conn);

        if (ds_temp.Tables[0].Rows.Count>0)
        {
           for (int i = 0; i <= ds_temp.Tables[0].Rows.Count-1; i++)
			{
	
                string title = "EMS 電子報<==溫馨提醒==> " + ds_temp.Tables[0].Rows[i]["event_dttm"].ToString() + " 【 " + ds_temp.Tables[0].Rows[i]["event_name"].ToString() + " 】";
        //ArrayList maillist = func.FileToArray(Server.MapPath("..\\") + "\\maillist\\strong_up_maillist.txt");

                SendEmail("vsoscar@ms26.url.com.tw", ds_temp.Tables[0].Rows[i]["email"].ToString().Replace("\r", "").Replace("\n", ""), title, strHTML, "");//

			}
        
        }
      
       
        //SendEmail("vsoscar@ms26.url.com.tw", "vsoscar2003@yahoo.com.hk", title, strHTML, "");//測試寄送程式
        //jrrsc@ms96.url.com.tw
        //fdlsongyy888@hotmail.com,vsoscar2003@yahoo.com.hk,liu.chang@msa.hinet.net,phyllis0531@hotmail.com,m8903157@yahoo.com.tw,benjamin6522@hotmail.com,dai.ww@msa.hinet.net,vrmouse@hotmail.com,roger.liu@infomax.com.tw,Yu.ChiaHao@gmail.com,chin-1520@yahoo.com.tw,heavenlibra@yahoo.com.tw,scm.shen@msa.hinet.net,bakery1202@gmail.com
        //write_log("MAIL");
        func.write_log("Send EMS 電子報<==溫馨提醒==>", Server.MapPath("..\\") + "\\RUN_LOG\\", "log");
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
