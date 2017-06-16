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





public partial class stock_epaper : System.Web.UI.Page
{
    //StreamWriter sww;
    
    protected void Page_Load(object sender, EventArgs e)
    {

        WebClient w = new WebClient();
        w.Encoding = Encoding.GetEncoding("Big5");
        string sql_count = " select count(*) as count1  from (                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         " +
" select * from ( select * from(SELECT stock_name, count(stock_name) as 次數,round(avg(price),2) as 均價,max(price) as 最大價格,stock_id,round((round(max(price),2)-round(avg(price),2)) ,2)as 價差,(round((round((round(max(price),2)-round(avg(price),2)) ,2)/(round(avg(price),2))),4))*100 as 獲利,round(avg(volume),0) as 平均成交量 FROM stock_three where date>DateAdd('d',-17, Now()) group by stock_name,stock_id) order by 獲利 desc ) t1 where t1.stock_id in ( select stock_id from stock_macd_1 where 1=1 AND Date <=DateAdd('d',-15, Now()) AND Date >= DateAdd('d',-17, Now()) order by date desc,rsi ) order by iif(次數=3,1,2),獲利 desc  " +
" )                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        ";
        
        string strHTML = w.DownloadString("http://vsoscar.no-ip.org/stock/three_top_open_cross.php");
        string title = "股市氣象台電子報" + DateTime.Now.ToString("yyyy/MM/dd");
        DataSet ds_count = new DataSet();
        string conn=System.Configuration.ConfigurationSettings.AppSettings["jump"];
        ds_count = func.get_dataSet_access(sql_count, conn);

        title = title + "【 共 " + ds_count.Tables[0].Rows[0]["count1"].ToString() + " 筆資料】";

        ArrayList  maillist=func.FileToArray(Server.MapPath("..\\") + "\\maillist\\maillist.txt");

        func.SendEmail("vsoscar@ms26.url.com.tw", "jrrsc@ms96.url.com.tw", title, strHTML, maillist[0].ToString());//
        //SendEmail("vsoscar@ms26.url.com.tw", "vsoscar2003@yahoo.com.hk", title, strHTML, "");//測試寄送程式
        //jrrsc@ms96.url.com.tw
        //fdlsongyy888@hotmail.com,vsoscar2003@yahoo.com.hk,liu.chang@msa.hinet.net,phyllis0531@hotmail.com,m8903157@yahoo.com.tw,benjamin6522@hotmail.com,dai.ww@msa.hinet.net,vrmouse@hotmail.com,roger.liu@infomax.com.tw,Yu.ChiaHao@gmail.com,chin-1520@yahoo.com.tw,heavenlibra@yahoo.com.tw,scm.shen@msa.hinet.net,bakery1202@gmail.com
        //write_log("MAIL");
        
        WebClient w1 = new WebClient();
        w1.Encoding = Encoding.GetEncoding("utf-8");
        //string strHTML1 = w.DownloadString("http://vsoscar.no-ip.org/stock/three_top_open_cross.php");
        //SAVE_CREATE_FILE(strHTML1);
        Response.Write("<script language=\"javascript\">setTimeout(\"window.opener=null;window.open('','_self');  window.close();\",null)</script>");

        //StringWriter sw = new StringWriter();
        //        HtmlTextWriter htw = new HtmlTextWriter(sw);
        //        Server.Execute("http://172.16.15.10/alarm/QueryForm3.php", htw);
        //        SendEmail("Alarm@innolux.com", "oscar.hsieh@innolux.com,bunny.su@innolux.com", "Alarm Event TOP ", sw.ToString(), "");
        //        //Response.Redirect("mail_detail2.aspx?aid=" + Request.QueryString["aid"].ToString(), false);
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
    //public void write_log(string program_name)
    //{
    //    StreamWriter sww;
    //    DirectoryInfo di;//宣告目錄
    //    FileInfo fi;//宣告檔案
    //    string program_name1 = program_name;
    //    fi = new FileInfo(Server.MapPath(".") + "\\RUN_LOG\\" + DateTime.Now.ToString("yyyyMMdd") + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".log");
    //    di = new DirectoryInfo(Server.MapPath(".") + "\\RUN_LOG\\" + DateTime.Now.ToString("yyyyMMdd")); //DateTime.Now.ToString("yyyyMMdd") 		
    //    if (!di.Exists)
    //    {
    //        di.Create();//目錄不存在 產生目錄
    //    }
    //    if (fi.Exists == true)
    //    {
    //        //檔案存在 寫檔案 
    //        sww = File.AppendText(Server.MapPath(".") + "\\RUN_LOG\\" + DateTime.Now.ToString("yyyyMMdd") + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".log");
    //    }
    //    else
    //    {
    //        sww = fi.CreateText(); //檔案不存在 產生檔案
    //    }

    //    //sww.WriteLine
    //    sww.WriteLine("Create log file");
    //    sww.WriteLine(DateTime.Now.ToString("u") + "  " + program_name1 + " Program Start");
    //    sww.WriteLine(DateTime.Now.ToString("u") + "  " + program_name1 + " Program END ");
    //    sww.WriteLine("");
    //    sww.Close();


    //}
    //public void SAVE_CREATE_FILE(string content)
    //{
    //    StreamWriter sw;
    //    DirectoryInfo di;//宣告目錄
    //    FileInfo fi;//宣告檔案
    //    string program_name1 = content;
    //    fi = new FileInfo(Server.MapPath(".") + "\\CREATE_FILE\\" + DateTime.Now.ToString("yyyyMMdd") + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".html");
    //    di = new DirectoryInfo(Server.MapPath(".") + "\\CREATE_FILE\\" + DateTime.Now.ToString("yyyyMMdd")); //DateTime.Now.ToString("yyyyMMdd") 		
    //    if (!di.Exists)
    //    {
    //        di.Create();//目錄不存在 產生目錄
    //    }
    //    if (fi.Exists == true)
    //    {
    //        //檔案存在 寫檔案 
    //        sw = File.AppendText(Server.MapPath(".") + "\\CREATE_FILE\\" + DateTime.Now.ToString("yyyyMMdd") + "\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".html");
    //    }
    //    else
    //    {
    //        sw = fi.CreateText(); //檔案不存在 產生檔案


    //    }

    //    sw.WriteLine(program_name1);
        

    //    sw.Close();


    //}



}
