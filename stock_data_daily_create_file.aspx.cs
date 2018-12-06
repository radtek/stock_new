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
using System.Net;
using System.IO;
using HtmlAgilityPack;
using System.Text;

public partial class stock_data_daily_create_file : System.Web.UI.Page
{
    Int32 counter = 1;
    ArrayList al = new ArrayList();

    protected void Page_Load(object sender, EventArgs e)
    {
      

        //get_loader_data_RSI("");
        counter = 1;
        get_loader_data("");

        func.write_log("stock_data_daily_create_file", Server.MapPath(".\\") + "\\RUN_LOG\\", "log");
        func.delete_log_file(Server.MapPath(".\\") + "\\RUN_LOG\\", "*.log", -30);



        al = func.FileToArray(Server.MapPath(".") + "\\config\\stock_today.txt");

        //for (int i = 0; i <= 4; i++)
        //{


        //    write_line_file("Robert2" + i.ToString(), Server.MapPath(".") + "\\TPO\\", "txt", al[i].ToString());

        //}
        string frmClose = @"<script language='javascript' type='text/JavaScript'> 

window.opener=null; 
window.open('','_self'); 
window.close(); 
</script>";

        //呼叫 javascript 
        this.Page.RegisterStartupScript("", frmClose); 

        
    }


    public string get_loader_data(string stock_idX)
    {
        string stock_id = stock_idX;

        // 下載 Yahoo 奇摩股市資料 (範例為 2317 鴻海)
        WebClient client = new WebClient();
        MemoryStream ms = new MemoryStream(client.DownloadData(
   "https://fubon-ebrokerdj.fbs.com.tw/z/zg/zg_DD_0_3.djhtm" + stock_id + ""));
        
    //    MemoryStream ms = new MemoryStream(client.DownloadData(
    //"http://jsjustweb.jihsun.com.tw/z/zg/zgb/zgb0_1360_1.djhtm" + stock_id + ""));
  //"http://jsjustweb.jihsun.com.tw/z/zk/zk4/zkparse_880_3.djhtm" + stock_id + ""));
 //http://www.emega.com.tw/z/zg/zg_DD_0_3.djhtm

        //http://jsjustweb.jihsun.com.tw/z/zg/zgb/zgb0_1360_1.djhtm

        //        MemoryStream ms = new MemoryStream(client.DownloadData(
        //"http://tw.stock.yahoo.com/q/q?s=" + stock_id + ""));


        // 使用預設編碼讀入 HTML
        HtmlDocument doc = new HtmlDocument();
        doc.Load(ms);
        //doc.Load(ms, Encoding.UTF8);
        HtmlDocument docStockContext = new HtmlDocument();
        // 裝載第一層查詢結果

        docStockContext.LoadHtml(doc.DocumentNode.SelectSingleNode(
    "/html[1]/body[1]/div[1]/table[1]/tr[2]/td[2]/table[1]/tr[1]/td[1]/table[1]").InnerHtml);

        // 取得個股標頭  get tr node number_count
        HtmlNodeCollection nodeHeaders =
     docStockContext.DocumentNode.SelectNodes("./tr");
        // 取得個股數值
        Int32 j = 3;  //from tr[4] to tr[i-4]
        for (int i = 0; i <= nodeHeaders.Count - 3; i++)
        {

            string[] values = docStockContext.DocumentNode.SelectSingleNode(
  "./tr[" + j + "]").InnerText.Trim().Split('\r');

            write_loader_file("stock_today", Server.MapPath(".\\") + "config\\", "txt", values[1].ToString().Replace(@"
&nbsp;", "").Replace(@"

", ""));

            Response.Write("Header:" + values[0].ToString().Replace("加到投資組合", "") + "<br>");
            j++;
        }


        // 輸出資料

        string[] title ={ "金融機構", "現金賣出", "現金買進" };


        //for (int i = 0; i <= values.Length - 1; i++)
        //{
        //    //Response.Write("Header:" + title[i] + values[i].ToString().Replace("加到投資組合", "") + "<br>");
        //    Response.Write("Header:" +values[].ToString().Replace("加到投資組合", "") + "<br>");
        //}
        string[] abc ={ "", "", "" };
        abc[0] = "";
        //abc[0] = values[0].Trim();
        // abc[1] = values[1].Trim(); //stock_price
        //abc[2] = values[2].Trim();//stock_name 

        //Double last_price = System.Convert.ToDouble(abc);

        doc = null;
        docStockContext = null;
        client = null;
        ms.Close();

        //return abc[0] + "," + abc[1] + "," + abc[2];

        return abc[0];

    }


    public string get_loader_data_RSI(string stock_idX)
    {
        string stock_id = stock_idX;

        // 下載 Yahoo 奇摩股市資料 (範例為 2317 鴻海)
        WebClient client = new WebClient();
        MemoryStream ms = new MemoryStream(client.DownloadData(
   "https://fubon-ebrokerdj.fbs.com.tw/z/zg/zg_DD_0_3.djhtm" + stock_id + ""));

        //    MemoryStream ms = new MemoryStream(client.DownloadData(
        //"http://jsjustweb.jihsun.com.tw/z/zg/zgb/zgb0_1360_1.djhtm" + stock_id + ""));
        //"http://jsjustweb.jihsun.com.tw/z/zk/zk4/zkparse_880_3.djhtm" + stock_id + ""));
        //http://www.emega.com.tw/z/zg/zg_DD_0_3.djhtm

        //http://jsjustweb.jihsun.com.tw/z/zg/zgb/zgb0_1360_1.djhtm

        //        MemoryStream ms = new MemoryStream(client.DownloadData(
        //"http://tw.stock.yahoo.com/q/q?s=" + stock_id + ""));


        // 使用預設編碼讀入 HTML
        HtmlDocument doc = new HtmlDocument();
        doc.Load(ms);
        //doc.Load(ms, Encoding.UTF8);
        HtmlDocument docStockContext = new HtmlDocument();
        // 裝載第一層查詢結果

        docStockContext.LoadHtml(doc.DocumentNode.SelectSingleNode(
    "/html[1]/body[1]/div[1]/table[1]/tr[2]/td[1]/table[1]").InnerHtml);

        // 取得個股標頭  get tr node number_count
        HtmlNodeCollection nodeHeaders =
     docStockContext.DocumentNode.SelectNodes("./tr");
        // 取得個股數值
        Int32 j = 2;  //from tr[0] to tr[0-2]
        for (int i = 0; i <= nodeHeaders.Count - 2; i++)
        {

            string[] values = docStockContext.DocumentNode.SelectSingleNode(
  "./tr[" + j + "]").InnerText.Trim().Split('\r');

            write_loader_file("stock_rsi", Server.MapPath(".\\") + "config\\", "txt", values[0].ToString().Replace("加到投資組合", ""));

            Response.Write("Header:" + values[0].ToString().Replace("加到投資組合", "") + "<br>");
            j++;
        }


        // 輸出資料

        string[] title ={ "金融機構", "現金賣出", "現金買進" };


        //for (int i = 0; i <= values.Length - 1; i++)
        //{
        //    //Response.Write("Header:" + title[i] + values[i].ToString().Replace("加到投資組合", "") + "<br>");
        //    Response.Write("Header:" +values[].ToString().Replace("加到投資組合", "") + "<br>");
        //}
        string[] abc ={ "", "", "" };
        abc[0] = "";
        //abc[0] = values[0].Trim();
        // abc[1] = values[1].Trim(); //stock_price
        //abc[2] = values[2].Trim();//stock_name 

        //Double last_price = System.Convert.ToDouble(abc);

        doc = null;
        docStockContext = null;
        client = null;
        ms.Close();

        //return abc[0] + "," + abc[1] + "," + abc[2];

        return abc[0];

    }


    public void write_loader_file(string program_name, string file_path, string file_type, string stock_name)
    {
        
        StreamWriter sw;
        DirectoryInfo di;//宣告目錄 
        FileInfo fi;//宣告檔案 
        string program_name1 = program_name;
        //di = new DirectoryInfo(Server.MapPath(".") + "\\RUN_LOG\\" ); //DateTime.Now.ToString("yyyyMMdd") 
        di = new DirectoryInfo(file_path); //DateTime.Now.ToString("yyyyMMdd") 
        //fi = new FileInfo(Server.MapPath(".") + "\\RUN_LOG\\" + DateTime.Now.ToString("yyyyMMdd") + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".log");
        fi = new FileInfo(file_path + program_name1 + "." + file_type);

        if (!di.Exists)
        {
            di.Create();//目錄不存在 產生目錄 
        }

        if (counter==1)
        {
            fi.Delete();
        
        }
        if (fi.Exists == true)
        {
            //檔案存在 寫檔案 
            //sw = File.AppendText(Server.MapPath(".") + "\\RUN_LOG\\" + DateTime.Now.ToString("yyyyMMdd") + ".log");
            sw = File.AppendText(file_path + program_name1 + "." + file_type);
        }
        else
        {
            sw = fi.CreateText(); //檔案不存在 產生檔案 
        }

        //sw.WriteLine("Create log file");
        sw.WriteLine(stock_name);

        sw.Close();
        counter++;

    }


    public void write_line_file(string program_name, string file_path, string file_type, string stock_name)
    {
        //StreamWriter sw = new StreamWriter("",Encoding.ASCII); 

        StreamWriter sw;
        DirectoryInfo di;//宣告目錄 
        FileInfo fi;//宣告檔案 
        string program_name1 = program_name;
        //di = new DirectoryInfo(Server.MapPath(".") + "\\RUN_LOG\\" ); //DateTime.Now.ToString("yyyyMMdd") 
        di = new DirectoryInfo(file_path); //DateTime.Now.ToString("yyyyMMdd") 
        //fi = new FileInfo(Server.MapPath(".") + "\\RUN_LOG\\" + DateTime.Now.ToString("yyyyMMdd") + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".log");
        fi = new FileInfo(file_path + program_name1 + "." + file_type);

        if (!di.Exists)
        {
            di.Create();//目錄不存在 產生目錄 
        }

        if (counter==1)
        {
            fi.Delete();

        }
        if (fi.Exists == true)
        {
            //檔案存在 寫檔案 
            //sw = File.AppendText(Server.MapPath(".") + "\\RUN_LOG\\" + DateTime.Now.ToString("yyyyMMdd") + ".log");
            sw = File.AppendText(file_path + program_name1 + "." + file_type);
       
        }
        else
        {
            sw = fi.CreateText(); //檔案不存在 產生檔案 
        }
        //System.Text.Encoding code = System.Text.Encoding.GetEncoding("UTF-8");
        string tmpp = "," + stock_name;



        //sw.WriteLine("Create log file");
        sw.WriteLine(tmpp.Substring(0,5).ToString());

        sw.Close();
        counter++;

    }
}
