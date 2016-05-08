﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net.Mail;
using System.Diagnostics;
using System.Threading;

public partial class epaper_finance_create_pdf : System.Web.UI.Page
{
    string today_yyyymmdd = DateTime.Now.AddDays(+0).ToString("yyyyMMdd");
    string today_yyyymmddHH = DateTime.Now.AddDays(+0).ToString("yyyyMMddHH");
    string today_detail = DateTime.Now.AddDays(+0).ToString("yyyyMMddHHmmss");
    string today_HH = DateTime.Now.AddDays(+0).ToString("HH");
    string today_DD = DateTime.Now.AddDays(+0).ToString("DD");
    string tool = "";
    string website = "";
    string title = "";
    string strHTML = "";
    string mail_list = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        member oscar = new member();

        ArrayList maillist = func.FileToArray(Server.MapPath("..\\") + "\\maillist\\fund_price.txt");

        oscar.today_detail = DateTime.Now.AddDays(+0).ToString("yyyyMMddHHmmss");

        //oscar.tool = Server.MapPath("..\\") + "\\wkhtmltopdf\\bin\\wkhtmltopdf.exe";
        oscar.tool = Server.MapPath("..\\") + "\\siteshoter\\SiteShoter.exe";


        oscar.website = "http://www.wantgoo.com/global/";

        oscar.title = " 國際股市快遞【" + today_yyyymmdd + "】";


        oscar.strHTML = "投資的路上 平安喜樂<br>http://www.wantgoo.com/global/";
        oscar.mail_list = "vsoscar0115@gmail.com,oscar0115.iim01g@g2.nctu.edu.tw";

        PIC_FACTORY(oscar);

        if (today_HH.Equals("19"))
        {

            oscar.today_detail = DateTime.Now.AddDays(+0).ToString("yyyyMMddHHmmss");

            oscar.tool = Server.MapPath("..\\") + "\\siteshoter\\SiteShoter.exe";

            //oscar.website = "http://www.cnyes.com/futures/flashchart/TX1.html";



            oscar.title = " 台指期貨<未平倉>快遞【" + today_yyyymmdd + "】";

            oscar.website = "http://stock.wearn.com/taifexphoto.asp";

            oscar.strHTML = "投資的路上 平安喜樂<br>http://stock.wearn.com/taifexphoto.asp";
            oscar.mail_list = "vsoscar0115@gmail.com,alex9tw@gmail.com,aq3283@gmail.com";
            PIC_FACTORY(oscar);



        }
        if (today_HH.Equals("19") )
        {

            oscar.today_detail = DateTime.Now.AddDays(+0).ToString("yyyyMMddHHmmss");

            oscar.tool = Server.MapPath("..\\") + "\\siteshoter\\SiteShoter.exe";

            //oscar.website = "http://www.cnyes.com/futures/flashchart/TX1.html";



            oscar.title = " 台指<OX圖>快遞【" + today_yyyymmdd + "】";

            oscar.website = "http://stockcharts.com/def/servlet/SharpChartv05.ServletDriver?c=%24TWII,PWTADANRRO[PA][D][F1!3!!!2!20]&pnf=y";

            oscar.strHTML = "投資的路上 平安喜樂<br>http://stockcharts.com/def/servlet/SharpChartv05.ServletDriver?c=%24TWII,PWTADANRRO[PA][D][F1!3!!!2!20]&pnf=y";
            oscar.mail_list = "vsoscar0115@gmail.com";
            PIC_FACTORY(oscar);



        }

        if (today_HH.Equals("19"))
        {

            oscar.today_detail = DateTime.Now.AddDays(+0).ToString("yyyyMMddHHmmss");

            oscar.tool = Server.MapPath("..\\") + "\\siteshoter\\SiteShoter.exe";

            //oscar.website = "http://www.cnyes.com/futures/flashchart/TX1.html";



            oscar.title = "台股盤後多空<技術指標>快遞【" + today_yyyymmdd + "】";

            oscar.website = "http://stock.wearn.com/finance_chart.asp?stockid=&timekind=0&timeblock=180&sma1=5&sma2=23&sma3=35&volume=0&indicator1=RSI&indicator2=MACD&indicator3=Vol&=http%3A//stock.wearn.com/CallAjaxStock.asp";

            oscar.strHTML = "投資的路上 平安喜樂<br>http://stock.wearn.com/finance_chart.asp?stockid=&timekind=0&timeblock=180&sma1=5&sma2=23&sma3=35&volume=0&indicator1=RSI&indicator2=MACD&indicator3=Vol&=http%3A//stock.wearn.com/CallAjaxStock.asp";
            oscar.mail_list = "vsoscar0115@gmail.com";
            PIC_FACTORY(oscar);



        }



       if( today_HH.Equals("22") || today_HH.Equals("08"))
       {



           oscar.today_detail = DateTime.Now.AddDays(+0).ToString("yyyyMMddHHmmss");

           oscar.tool = Server.MapPath("..\\") + "\\siteshoter\\SiteShoter.exe";

           //oscar.website = "http://www.cnyes.com/futures/flashchart/TX1.html";



           oscar.title = " 市場風向球【" + today_yyyymmdd + "】";

           oscar.website = "http://www.moneydj.com/funddj/ya/yp051000.djhtm?a=FA000004";

           oscar.strHTML = "投資的路上 平安喜樂<br>http://www.moneydj.com/funddj/ya/yp051000.djhtm?a=FA000004";
           oscar.mail_list = "vsoscar0115@gmail.com";
           PIC_FACTORY(oscar);
       
       
       }



        //if (1==1)
        if (today_HH.Equals("18") )
        {

            oscar.today_detail = DateTime.Now.AddDays(+0).ToString("yyyyMMddHHmmss");

            oscar.tool = Server.MapPath("..\\") + "\\siteshoter\\SiteShoter.exe";

            //oscar.website = "http://www.cnyes.com/futures/flashchart/TX1.html";
          


            oscar.title = " 德盛金雞母<淨值>快遞【" + today_yyyymmdd + "】";

            oscar.website = "http://fund.bot.com.tw/w/wb/wb02a.DJHTM?A=tlz64-0532&B=7&C=0&D=0&customershowall=0";

            oscar.strHTML = "投資的路上 平安喜樂<br>http://fund.bot.com.tw/w/wb/wb02a.DJHTM?A=tlz64-0532&B=7&C=0&D=0&customershowall=0";
            oscar.mail_list = maillist[0].ToString();
            PIC_FACTORY(oscar);

           

        }
        //if (1 == 1)
        if (today_HH.Equals("18"))
        {
            oscar.today_detail = DateTime.Now.AddDays(+0).ToString("yyyyMMddHHmmss");

            //oscar.tool = Server.MapPath("..\\") + "\\wkhtmltopdf\\bin\\wkhtmltopdf.exe";
            oscar.tool = Server.MapPath("..\\") + "\\siteshoter\\SiteShoter.exe";


            oscar.website = "http://fund.bot.com.tw/w/wb/wb05.djhtm?a=TLZ64-0532&customershowall=0";

            oscar.title = " 德盛金雞母<配息>快遞【" + today_yyyymmdd + "】";

            oscar.strHTML = "投資的路上 平安喜樂<br>http://fund.bot.com.tw/w/wb/wb05.djhtm?a=TLZ64-0532&customershowall=0";
            oscar.mail_list = maillist[0].ToString();
            PIC_FACTORY(oscar);

        }

        if (today_HH.Equals("22"))
        {
            oscar.today_detail = DateTime.Now.AddDays(+0).ToString("yyyyMMddHHmmss");

            //oscar.tool = Server.MapPath("..\\") + "\\wkhtmltopdf\\bin\\wkhtmltopdf.exe";
            oscar.tool = Server.MapPath("..\\") + "\\siteshoter\\SiteShoter.exe";


            oscar.website = "http://www.etf.com/etfanalytics/etf-fund-flows-tool";

            oscar.title = " ETF<現金流>快遞【" + today_yyyymmdd + "】";

            oscar.strHTML = "投資的路上 平安喜樂<br>http://www.etf.com/etfanalytics/etf-fund-flows-tool";
            oscar.mail_list = "vsoscar0115@gmail.com";
            PIC_FACTORY(oscar);

        }


        if (today_HH.Equals("19") || today_HH.Equals("08"))
        {
            oscar.today_detail = DateTime.Now.AddDays(+0).ToString("yyyyMMddHHmmss");

            //oscar.tool = Server.MapPath("..\\") + "\\wkhtmltopdf\\bin\\wkhtmltopdf.exe";
            oscar.tool = Server.MapPath("..\\") + "\\siteshoter\\SiteShoter.exe";


            oscar.website = "http://histock.tw/stock/foreign.aspx";

            oscar.title = " 期貨<法人成本>快遞【" + today_yyyymmdd + "】";

            oscar.strHTML = "投資的路上 平安喜樂<br>http://histock.tw/stock/foreign.aspx";
            oscar.mail_list = "vsoscar0115@gmail.com,alex9tw@gmail.com,aq3283@gmail.com";
            PIC_FACTORY(oscar);

        }

        if (today_DD.Equals("20"))
        {
            //oscar.today_detail = DateTime.Now.AddDays(+0).ToString("yyyyMMddHHmmss");

            ////oscar.tool = Server.MapPath("..\\") + "\\wkhtmltopdf\\bin\\wkhtmltopdf.exe";
            //oscar.tool = Server.MapPath("..\\") + "\\siteshoter\\SiteShoter.exe";


            //oscar.website = "http://fund.cnyes.com/detail/%E5%BE%B7%E7%9B%9B%E5%AE%89%E8%81%AF%E6%94%B6%E7%9B%8A%E6%88%90%E9%95%B7%E5%9F%BA%E9%87%91-AM%E7%A9%A9%E5%AE%9A%E6%9C%88%E6%94%B6%E9%A1%9E%E8%82%A1%EF%BC%88%E7%BE%8E%E5%85%83/b20,073/dividend/";

            //oscar.title = " 德盛金雞母<配息率>快遞【" + today_yyyymmdd + "】";

            //oscar.strHTML = "投資的路上 平安喜樂<br>http://fund.cnyes.com/detail/%E5%BE%B7%E7%9B%9B%E5%AE%89%E8%81%AF%E6%94%B6%E7%9B%8A%E6%88%90%E9%95%B7%E5%9F%BA%E9%87%91-AM%E7%A9%A9%E5%AE%9A%E6%9C%88%E6%94%B6%E9%A1%9E%E8%82%A1%EF%BC%88%E7%BE%8E%E5%85%83/b20,073/dividend/";
            //oscar.mail_list = "vsoscar0115@gmail.com";
            //PIC_FACTORY(oscar);

        }
        if (today_DD.Equals("20")||today_HH.Equals("18"))
        {
            oscar.today_detail = DateTime.Now.AddDays(+0).ToString("yyyyMMddHHmmss");

            //oscar.tool = Server.MapPath("..\\") + "\\wkhtmltopdf\\bin\\wkhtmltopdf.exe";
            oscar.tool = Server.MapPath("..\\") + "\\siteshoter\\SiteShoter.exe";


            oscar.website = "http://fund.cnyes.com/detail/%E5%BE%B7%E7%9B%9B%E5%AE%89%E8%81%AF%E6%94%B6%E7%9B%8A%E6%88%90%E9%95%B7%E5%9F%BA%E9%87%91-AM%E7%A9%A9%E5%AE%9A%E6%9C%88%E6%94%B6%E9%A1%9E%E8%82%A1%EF%BC%88%E7%BE%8E%E5%85%83/b20,073/holdings/";

            oscar.title = " 德盛金雞母<持股分析>快遞【" + today_yyyymmdd + "】";

            oscar.strHTML = "投資的路上 平安喜樂<br>http://fund.cnyes.com/detail/%E5%BE%B7%E7%9B%9B%E5%AE%89%E8%81%AF%E6%94%B6%E7%9B%8A%E6%88%90%E9%95%B7%E5%9F%BA%E9%87%91-AM%E7%A9%A9%E5%AE%9A%E6%9C%88%E6%94%B6%E9%A1%9E%E8%82%A1%EF%BC%88%E7%BE%8E%E5%85%83/b20,073/holdings/";
            oscar.mail_list = "vsoscar0115@gmail.com";
            PIC_FACTORY(oscar);

        }
         //if (1==1)
         if(today_HH.Equals("18")||today_HH.Equals("08"))
        {
            oscar.today_detail = DateTime.Now.AddDays(+0).ToString("yyyyMMddHHmmss");

            //oscar.tool = Server.MapPath("..\\") + "\\wkhtmltopdf\\bin\\wkhtmltopdf.exe";
            oscar.tool = Server.MapPath("..\\") + "\\siteshoter\\SiteShoter.exe";
            //oscar.website = "http://www.cnyes.com/futures/flashchart/TX1.html";
            oscar.website = "http://stockcharts.com/h-sc/ui?s=%24TWII&p=D&b=4&g=0&id=p37399354271";


        
            oscar.title = " 台指期貨快遞【" + today_yyyymmdd + "】";

            oscar.strHTML = "投資的路上 平安喜樂<br>http://stockcharts.com/h-sc/ui?s=%24TWII&p=D&b=4&g=0&id=p37399354271";
            oscar.mail_list = "vsoscar0115@gmail.com";
            PIC_FACTORY(oscar);

        }

     



   
       


    



        Response.Write("<script language=\"javascript\">setTimeout(\"window.opener=null;window.open('','_self');  window.close();\",null)</script>");

    }

    private void PDF_FACTORY(member oscar)
    {
        Send_PDF(oscar.tool, oscar.title, oscar.strHTML, oscar.title, oscar.website,oscar.today_detail);
        SendEmail("vsoscar@ms26.url.com.tw", oscar.mail_list, oscar.title, oscar.strHTML, "", Server.MapPath("..\\") + "\\File\\" + oscar.today_detail + ".pdf");//

    }
    private void PIC_FACTORY(member oscar)
    {
        Send_PIC(oscar.tool, oscar.title, oscar.strHTML, oscar.title, oscar.website, oscar.today_detail);
        SendEmail("vsoscar@ms26.url.com.tw", oscar.mail_list, oscar.title, oscar.strHTML, "", Server.MapPath("..\\") + "\\File\\" + oscar.today_detail + ".jpg");//

    }
    public class member 

    {
        

        private string _today_detail;
        public string today_detail
        {
            set { _today_detail = value; }
            get { return _today_detail; }
        }

        private string _tool;
        public string tool
        {
            set { _tool = value; }
            get { return _tool; }
        }
        private string _website;
        public string website
        {
            set { _website = value; }
            get { return _website; }
        }
        private string _title;
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }

        private string _strHTML;
        public string strHTML
        {
            set { _strHTML = value; }
            get { return _strHTML; }
        }

        private string _mail_list;
        public string mail_list
        {
            set { _mail_list = value; }
            get { return _mail_list; }
        }
       




    } 


    private void Send_PDF(string tool, string title, string strHTML, string mail_list, string website,string _today_detail)
    {
        func.CreatePDF(website, tool, Server.MapPath("..\\") + "\\File\\" + _today_detail + ".pdf");
        func.write_log("Send 國際股市==> ", Server.MapPath("..\\") + "\\RUN_LOG\\", "log");
        func.delete_log_file(Server.MapPath("..\\") + "\\RUN_LOG\\", "*.log", -30);
        func.delete_log_file(Server.MapPath("..\\") + "\\File\\", "*.pdf", -3);

        System.Threading.Thread.Sleep(80000);
    }


    private void Send_PIC(string tool, string title, string strHTML, string mail_list, string website, string _today_detail)
    {
        func.CreatePIC(website, tool, Server.MapPath("..\\") + "\\File\\" + _today_detail + ".jpg");
        func.write_log("Send 國際股市==> ", Server.MapPath("..\\") + "\\RUN_LOG\\", "log");
        func.delete_log_file(Server.MapPath("..\\") + "\\RUN_LOG\\", "*.log", -30);
        func.delete_log_file(Server.MapPath("..\\") + "\\File\\", "*.jpg", -3);

        System.Threading.Thread.Sleep(20000);
    }

  
    public static void SendEmail(string from, string to, string subject, string body, string cca, string file_path)
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

        if (!file_path.Equals(""))
        {
            System.Net.Mail.Attachment attachment;
            attachment = new System.Net.Mail.Attachment(file_path);
            email.Attachments.Add(attachment);

        }



        email.IsBodyHtml = true;
        smtp.Send(email);


    } 
}
