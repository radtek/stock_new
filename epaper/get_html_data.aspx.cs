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
using HtmlAgilityPack;
using System.Net;
using System.IO;
using System.Text;
using System.Net.Mail;



public partial class epaper_get_html_data : System.Web.UI.Page
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

    protected void Page_Load(object sender, EventArgs e)
    {


        Double target_value = 0;
        string sql_temp = "";
        string sql_temp123 = "";


        sql_temp123 = "select  format(t.date1,'yyyy/mm/dd') as date1 ,t.stock_id,t.stock_price,t.email,format(last_send_time,'yyyy/MM/dd HH:mm') as last_send_time1,t.interval_time,t.sn from stock_on_target_report t where t.date1>=format('" + today + "','yyyy/mm/dd') and t.flag='Y' ";

        ds_temp1 = func.get_dataSet_access(sql_temp123, conn);

        for (int i = 0; i <= ds_temp1.Tables[0].Rows.Count - 1; i++)
        {


            Check_function(ds_temp1.Tables[0].Rows[i]["stock_id"].ToString(), Convert.ToDouble(ds_temp1.Tables[0].Rows[i]["stock_price"].ToString()), ds_temp1.Tables[0].Rows[i]["email"].ToString(), ds_temp1.Tables[0].Rows[i]["last_send_time1"].ToString(), Convert.ToInt32(ds_temp1.Tables[0].Rows[i]["interval_time"].ToString()), Convert.ToInt32(ds_temp1.Tables[0].Rows[i]["sn"].ToString()));


        }

        func.write_log("Send  epaper_get_html_data", Server.MapPath("..\\") + "\\RUN_LOG\\", "log");
        func.delete_log_file(Server.MapPath("..\\") + "\\RUN_LOG\\", "*.log", -30);
        Response.Write("<script language=\"javascript\">setTimeout(\"window.opener=null;window.open('','_self');  window.close();\",null)</script>");
    }

    public void Check_function(string stock_idX, Double target_valueX, string target_emailX, string last_send_timeX, Int32 interval_timeX, Int32 snX)
    {
        string stock_id = stock_idX;
        Double target_value = target_valueX;
        string target_email = target_emailX;
        string last_send_time = last_send_timeX;
        Int32 interval_time = interval_timeX;
        Int32 sn = snX;
        // 下載 Yahoo 奇摩股市資料 (範例為 2317 鴻海)
        WebClient client = new WebClient();
        MemoryStream ms = new MemoryStream(client.DownloadData(
    "http://tw.stock.yahoo.com/q/q?s=" + stock_id + ""));

        // 使用預設編碼讀入 HTML
        HtmlDocument doc = new HtmlDocument();
        doc.Load(ms, Encoding.Default);

        // 裝載第一層查詢結果
        HtmlDocument docStockContext = new HtmlDocument();

        docStockContext.LoadHtml(doc.DocumentNode.SelectSingleNode(
    "/html[1]/body[1]/center[1]/table[2]/tr[1]/td[1]/table[1]").InnerHtml);

        // 取得個股標頭
        HtmlNodeCollection nodeHeaders =
     docStockContext.DocumentNode.SelectNodes("./tr[1]/th");
        // 取得個股數值
        string[] values = docStockContext.DocumentNode.SelectSingleNode(
    "./tr[2]").InnerText.Trim().Split('\n');

        // 輸出資料

        string[] title ={ "股票代號", "時間", "成交", "買進", "賣出", "漲跌", "張數", "昨收", "開盤", "最高", "最低", "個股資料" };
        for (int i = 0; i <= values.Length - 2; i++)
        {
            Response.Write("Header:" + title[i] + values[i].ToString().Replace("加到投資組合", "") + "<br>");
        }
        string abc = values[2].Trim();

        Double last_price = System.Convert.ToDouble(abc);

        Response.Write(last_price + "<br>");
        Response.Write("Send taget Mail.<br>");
        //Response.Write(sss);
        sql_insert1 = "SELECT DATEDIFF('n','" + last_send_time + "','" + today_detail + "') AS DiffDate ";
        ds_temp2 = func.get_dataSet_access(sql_insert1, conn);
        Int32 interval_data = Convert.ToInt32(ds_temp2.Tables[0].Rows[0]["DiffDate"].ToString());

        if (last_price >= target_value && interval_data > interval_time)
        {

            Response.Write("On TIME TO SELL.<br>");

            WebClient w = new WebClient();
            w.Encoding = Encoding.GetEncoding("Big5");
            string strHTML = w.DownloadString("http://tw.stock.yahoo.com/q/q?s=" + stock_id + "");




            string mail_title = "股市氣象台電子報-<==達標回報==> " + DateTime.Now.ToString("yyyy/MM/dd") + "【 " + values[0].Trim().ToString().Replace("加到投資組合", "") + " 目前價格 (" + values[2].Trim() + ") 達標價格( " + target_value + ") 】";
            ArrayList maillist = func.FileToArray(Server.MapPath("..\\") + "\\maillist\\strong_up_maillist.txt");
            maillist[0] = "";

            SendEmail("vsoscar@ms26.url.com.tw", target_email, mail_title, strHTML, maillist[0].ToString());//
            //SendEmail("vsoscar@ms26.url.com.tw", "vsoscar2003@yahoo.com.hk", title, strHTML, "");//測試寄送程式
            //jrrsc@ms96.url.com.tw
            //fdlsongyy888@hotmail.com,vsoscar2003@yahoo.com.hk,liu.chang@msa.hinet.net,phyllis0531@hotmail.com,m8903157@yahoo.com.tw,benjamin6522@hotmail.com,dai.ww@msa.hinet.net,vrmouse@hotmail.com,roger.liu@infomax.com.tw,Yu.ChiaHao@gmail.com,chin-1520@yahoo.com.tw,heavenlibra@yahoo.com.tw,scm.shen@msa.hinet.net,bakery1202@gmail.com
            //write_log("MAIL");
            WebClient w1 = new WebClient();
            w1.Encoding = Encoding.GetEncoding("utf-8");
            //string strHTML1 = w.DownloadString("http://vsoscar.no-ip.org/stock/three_top_open_cross.php");
            //SAVE_CREATE_FILE(strHTML1);
            sql_update = "update stock_on_target_report set last_send_time=format('" + today_detail + "','yyyy/MM/dd HH:mm')  where sn=" + sn + " ";
            func.get_sql_execute(sql_update, conn);
        }

        doc = null;
        docStockContext = null;
        client = null;
        ms.Close();

        Response.Write("Completed.");



        //Response.Write("<script language='javascript'>\n");
        //Response.Write("window.open('http://www.kimo.com.tw', '_blank', 'height=800, width=1000, left=0, top=0, location=no, menubar=no, resizable=yes, scrollbars=yes, titlebar=no, toolbar=no', true);\n");

        //Response.Write("</script>");



    }


    public static void SendEmail(string from, string to, string subject, string body, string cca)
    {
        SmtpClient smtp = new SmtpClient("ms28.hinet.net");
        MailMessage email = new MailMessage(from, to.ToString().Replace("\n", "").Replace("\r", ""), subject, body);
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
