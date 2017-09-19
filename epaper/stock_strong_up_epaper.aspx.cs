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
public partial class epaper_stock_strong_up_epaper : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["jump"];
    string sql_insert = "";
    string mail_list = "";
   
    string mail_list_alarm_on_taget = "";
    DataSet ds_temp = new DataSet();
    DataSet ds_temp1 = new DataSet();
    DataSet ds_temp2 = new DataSet();
    DataSet ds_tempX = new DataSet();
    
    string sql_temp1 = "";
    string sql_temp3 = "";
    string sql_temp2 = "";
    string sql_temp4 = "";
    string today = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd");
    string after_7_date = DateTime.Now.AddDays(+7).ToString("yyyy/MM/dd");
    string today_detail = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd HH:mm");

    Int32 max_sn = 0;
        
    protected void Page_Load(object sender, EventArgs e)
    {

       

        WebClient w = new WebClient();
        w.Encoding = Encoding.GetEncoding("Big5");
        string strHTML = w.DownloadString("http://localhost:8080/Stock_new/Stock_strong_volume1.aspx?page=1");

        string sql=" select count(*) as count_num  from (                                                                       "+
"                                                                                                        "+
" SELECT format(t.dttm,'yyyy/MM/dd') as date1,t.stock_id,Mid ( t.stock_name,5, 5 )as stock_name ,t.price,t.price-t.yesturday_price as up_down ,round((t.price-t.yesturday_price)/t.yesturday_price,4)*100 &'%' as K_percentage,t.yesturday_price,t.volume,round(t.price*1.0691,2) as top_price " +
" FROM strong_up_myself t                                                                                                                                                                                                                                                                      " +
" where  format(t.dttm,'yyyy/MM/dd')>=format(now(),'YYYY/MM/DD')                                                                                                                                                                                                                             " +
" and t.volume>=10000                                                                                                                                                                                                                                                                          "+
" )                                                                                                      "+
"                                                                                                        "+
"                                                                                                        ";
        ds_temp=func.get_dataSet_access(sql,conn) ;

      

       

        string title = "股市氣象台電子報-今日我最夯<==Strong_UP==> " + DateTime.Now.ToString("yyyy/MM/dd") + "【共 " + ds_temp .Tables[0].Rows[0][0].ToString()+ " 筆資料 】";
       // ArrayList maillist = func.FileToArray(Server.MapPath("..\\") + "\\maillist\\strong_up_maillist.txt");
        #region GET mEMBER E-MAIL
        sql_temp3 = " select t.mail  from stock_user t where  t.expire_date>= format('" + today + "','yyyy/MM/dd') and  t.mail  is not null";
        sql_temp4 = " select t.mail  from stock_user t where  t.expire_date>= format('" + today + "','yyyy/MM/dd') and  t.mail  is not null and t.alarm_flag='T'";

        mail_list = func.MergeMailListToString(sql_temp3, conn, "mail");
        mail_list_alarm_on_taget = func.MergeMailListToString(sql_temp4, conn, "mail");
        #endregion

        BindGridView();

        SendEmail("vsoscar@ms26.url.com.tw", "vsoscar0115@gmail.com", title, strHTML, "", "");//
        //SendEmail("vsoscar@ms26.url.com.tw", "vsoscar2003@yahoo.com.hk", title, strHTML, "");//測試寄送程式
        //jrrsc@ms96.url.com.tw
        //fdlsongyy888@hotmail.com,vsoscar2003@yahoo.com.hk,liu.chang@msa.hinet.net,phyllis0531@hotmail.com,m8903157@yahoo.com.tw,benjamin6522@hotmail.com,dai.ww@msa.hinet.net,vrmouse@hotmail.com,roger.liu@infomax.com.tw,Yu.ChiaHao@gmail.com,chin-1520@yahoo.com.tw,heavenlibra@yahoo.com.tw,scm.shen@msa.hinet.net,bakery1202@gmail.com
        //write_log("MAIL");
        WebClient w1 = new WebClient();
        w1.Encoding = Encoding.GetEncoding("utf-8");
        //string strHTML1 = w.DownloadString("http://vsoscar.no-ip.org/stock/three_top_open_cross.php");
        //SAVE_CREATE_FILE(strHTML1);
        func.write_log("Send 股市氣象台電子報-今日我最夯<==Strong_UP==> ", Server.MapPath("..\\") + "\\RUN_LOG\\", "log");
        func.delete_log_file(Server.MapPath("..\\") + "\\RUN_LOG\\", "*.log", -30);
       
        Response.Write("<script language=\"javascript\">setTimeout(\"window.opener=null;window.open('','_self');  window.close();\",null)</script>");
    }

    public static void SendEmail(string from, string to, string subject, string body, string cca, string file_path)
    {
        //smtp.gmail.com 
        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 25);

        smtp.Credentials = new System.Net.NetworkCredential("vsoscar0115@gmail.com", "oscar0115");
        smtp.EnableSsl = true;
        MailMessage email = new MailMessage(from, to, subject, body);
        if (cca == "")
        {
        }
        else
        {
            email.CC.Add(cca);
            //email.Bcc.Add(cca);
        }

        if (!file_path.Equals(""))
        {
            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment(file_path);
            email.Attachments.Add(attachment);

        }

        email.IsBodyHtml = true;

        smtp.Send(email);


    } 

    public void BindGridView()
    {
        string sql_cnn = System.Configuration.ConfigurationSettings.AppSettings["jump"];
        string sql_str = " SELECT format(t.dttm,'yyyy/MM/dd') as date1,t.stock_id,Mid ( t.stock_name,5, 5 )as stock_name ,t.price,t.price-t.yesturday_price as up_down ,round((t.price-t.yesturday_price)/t.yesturday_price,4)*100  as K_percentage,t.yesturday_price,t.volume,round(t.price*1.0691,2) as top_price,round((t.price-t.yesturday_price)/t.yesturday_price,4)*t.volume as kpi,round(((price-low_price)-(top_price-price)),2) as turtle " +
" FROM strong_up_myself t                                                                                                                                                                                                                                                                      " +
" where format(t.dttm,'yyyy/MM/dd')>=format(now(),'YYYY/MM/DD')                                                                                                                                                                                                                              " +
" and t.volume>=10000                                                                                                                                                                                                                                                                          ";

        

        //DATEADD(day, 1, @CountDate)  

        ds_temp1 = func.get_dataSet_access(sql_str, sql_cnn);
        Int32 counter=1;
        for (int i = 0; i <= ds_temp1.Tables[0].Rows.Count-1; i++)
        {
           
            sql_insert = " INSERT INTO strong_up_history (sn, date1, stock_name,stock_id,price1,percent1,volume1,K_percentage,hot_price,kpi,turtle)" +
" VALUES (" + counter + ", '" + ds_temp1.Tables[0].Rows[i]["date1"] + "', '" + ds_temp1.Tables[0].Rows[i]["stock_name"] + "','" + ds_temp1.Tables[0].Rows[i]["stock_id"] + "'," + ds_temp1.Tables[0].Rows[i]["price"] + "," + ds_temp1.Tables[0].Rows[i]["K_percentage"] + "," + ds_temp1.Tables[0].Rows[i]["volume"] + "," + ds_temp1.Tables[0].Rows[i]["K_percentage"] + "," + ds_temp1.Tables[0].Rows[i]["top_price"] + "," + ds_temp1.Tables[0].Rows[i]["kpi"] +","+ ds_temp1.Tables[0].Rows[i]["turtle"] + ")                                       ";



            func.get_sql_execute(sql_insert, conn);
            counter++;
        }

        // FullAuto Add Record  To  stock_on_target_report
       
        sql_temp1 = "select max(sn)as sn from  stock_on_target_report ";
        ds_tempX = func.get_dataSet_access(sql_temp1, conn);
        max_sn = Convert.ToInt32(ds_tempX.Tables[0].Rows[0]["sn"].ToString());
        max_sn++;

        for (int i = 0; i <= ds_temp1.Tables[0].Rows.Count - 1; i++)
        {

            sql_temp2 = " INSERT INTO stock_on_target_report (date1, stock_id, stock_price,flag,email,sn,user_id,dttm,interval_time,last_send_time)" +
" VALUES ('" + after_7_date + "', '" + ds_temp1.Tables[0].Rows[i]["stock_id"] + "', " + ds_temp1.Tables[0].Rows[i]["top_price"] + ",'Y','" + mail_list_alarm_on_taget + "'," + max_sn + ",'Oscar','" + today_detail + "',15,'" + today_detail + "')                                       ";

            func.get_sql_execute(sql_temp2, conn);

            max_sn++;
        }
            
      
       


    }
}
