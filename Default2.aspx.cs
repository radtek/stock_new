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
using System.IO;
using System.Net;
using HtmlAgilityPack;
using System.Text;


public partial class Default2 : System.Web.UI.Page
{
     string target="";
   

    string today_detail = DateTime.Now.AddDays(+0).ToString("yyyyMMddHHmmss");
    protected void Page_Load(object sender, EventArgs e)
    {
        
        //target=Check_function_Fund_price("");
        //Response.Write(target);
    
        //*delete_log_file(Server.MapPath(".") + "\\RUN_LOG\\", "*.exe", -30);
        //string aaa = "M:\\report\\Stock_new\\wkhtmltopdf\\bin\\wkhtmltopdf.exe" ;
        string tool = Server.MapPath(".")  + "\\wkhtmltopdf\\bin\\wkhtmltopdf.exe";

        string website = "http://www.wantgoo.com/globalfinance.aspx";

        
        func.CreatePDF(website, tool, Server.MapPath(".") + "\\File\\" + today_detail + ".pdf");

        //CreatePDF(website, tool, Server.MapPath(".") + "\\File\\" + today_detail + ".pdf");

      
    }



    //public static void CreatePDF(string html_Path, string tool_path,string SavePath)
    //{
    //    Process _process = new Process();
    //    _process.StartInfo.FileName = tool_path;
    //    _process.StartInfo.Arguments = @"" + html_Path + " " + SavePath + "";
    //    _process.Start();



    //}

    public static void delete_log_file(string file_path, string file_type, Double dayAgo)
    {
        //DirectoryInfo dir = new DirectoryInfo(Server.MapPath(".") + "\\CF\\Save_file\\");
        DirectoryInfo dir = new DirectoryInfo(file_path);
        // FileInfo[] files = dir.GetFiles("*.xls");
        FileInfo[] files = dir.GetFiles(file_type);


        for (int i = 0; i <= files.Length - 1; i++)
        {
            if (files[i].CreationTime < DateTime.Now.AddDays(dayAgo))
            {

                files[i].Delete();
            }



        }
        DirectoryInfo[] sub_dir = dir.GetDirectories();

        if (sub_dir.Length == 0)
        {
            return;
        }
        else { 

       for (int i = 0; i <= sub_dir.Length-1; i++)
			{
                delete_log_file(file_path + "\\" + sub_dir[i].Name, file_type, dayAgo);
                //FileInfo[] files_sub = sub_dir[i].GetFiles();
                //if(files_sub.Length==0)
                //{
                
                // sub_dir[i].Delete();
                //}
                //sub_dir[i].Delete();
			}
        
       
        
        }






        Int32 counter = 0;
        // Display the name of all the files. 
        #region MyRegion
        //foreach (FileInfo file in files)
        //{
        //    counter = counter + 1;
        //    Response.Write(counter + ".");

        //    Response.Write("Name: " + file.Name + " ");
        //    Response.Write("<br/>");
        //    Response.Write("Size: " + file.Length.ToString());
        //    Response.Write("<br/>");
        //} 
        #endregion



    }

    public static string Check_function_Fund_price(string stock_idX)
    {
        string stock_id = stock_idX;

        // 下載 Yahoo 奇摩股市資料 (範例為 2317 鴻海)
        WebClient client = new WebClient();
        MemoryStream ms = new MemoryStream(client.DownloadData(
    "http://tw.money.yahoo.com/currency_foreign2bank?currency=USD" + stock_id + ""));


//        MemoryStream ms = new MemoryStream(client.DownloadData(
//"http://tw.stock.yahoo.com/q/q?s=" + stock_id + ""));


        // 使用預設編碼讀入 HTML
        HtmlDocument doc = new HtmlDocument();
        doc.Load(ms, Encoding.UTF8);
        HtmlDocument docStockContext = new HtmlDocument();
        // 裝載第一層查詢結果

        docStockContext.LoadHtml(doc.DocumentNode.SelectSingleNode(
    "/html[1]/body[1]/div[1]/div[2]/div[2]/div[1]/div[1]/div[2]/div[2]/table[1]").InnerHtml);

        // 取得個股標頭
        HtmlNodeCollection nodeHeaders =
     docStockContext.DocumentNode.SelectNodes("./tr[1]/td");
        // 取得個股數值
        string[] values = docStockContext.DocumentNode.SelectSingleNode(
    "./tr[3]").InnerText.Trim().Split('\n');

  
        // 輸出資料

        string[] title ={ "金融機構", "現金賣出", "現金買進" };
        for (int i = 0; i <= values.Length - 2; i++)
        {
            //Response.Write("Header:" + title[i] + values[i].ToString().Replace("加到投資組合", "") + "<br>");
        }
        string[] abc ={ "", "","" };
        abc[0] = values[0].Trim();
        abc[1] = values[1].Trim(); //stock_price
        abc[2] = values[2].Trim();//stock_name 

        //Double last_price = System.Convert.ToDouble(abc);





        doc = null;
        docStockContext = null;
        client = null;
        ms.Close();

        return abc[0] + "," + abc[1]+","+abc[2];



    }
}
