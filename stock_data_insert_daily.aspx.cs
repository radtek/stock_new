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
using System.Net;
using System.Collections.Generic;

public partial class stock_data_insert_daily : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["stock_insert"];
    string sql_temp1 = "";
    string sql_temp2 = "";
    DataSet Ds_temp1 = new DataSet();
    DataSet Ds_temp2 = new DataSet();
    ArrayList Arr_list = new ArrayList();
    ArrayList Arr_list_rsi = new ArrayList();
    DataTable DT_temp = new DataTable();


    protected void Page_Load(object sender, EventArgs e)
    {

        Arr_list = func.FileToArray(Server.MapPath(".") + "\\config\\stock_today.txt");

        Arr_list_rsi = func.FileToArray(Server.MapPath(".") + "\\config\\stock_rsi.txt");

        // judge  both appear first use dictionary  case a

        Dictionary<string, int> dict = new Dictionary<string, int>();



        for (int n = 0; n <= Arr_list.Count - 1; n++)
        {

            dict.Add(Arr_list[n].ToString(), n);


        }

        for (int k = 0; k <= Arr_list_rsi.Count-1; k++)
        {


            if (dict.ContainsKey(Arr_list_rsi[k].ToString()) == true)
            {
                Check_function(Arr_list_rsi[k].ToString().Substring(0, 4), 0);
              
            }

        }

        //  case b  use two loop to find out both appear

        //for (int m = 0; m <= Arr_list.Count-1; m++)
        //{


        //    for (int n = 0; n <= Arr_list_rsi.Count-1; n++)
        //    {
        //        if (Arr_list[m].ToString().Equals(Arr_list_rsi[n].ToString()))

        //        {

        //            Check_function(Arr_list[m].ToString().Substring(0, 4), 0);
        //        }


        //    }
        //}


        func.write_log("stock_data_insert_daily", Server.MapPath(".\\") + "\\RUN_LOG\\", "log");
        func.delete_log_file(Server.MapPath(".\\") + "\\RUN_LOG\\", "*.log", -30);
        Response.Write("<script language=\"javascript\">setTimeout(\"window.opener=null;window.open('','_self');  window.close();\",null)</script>");
    }


    public string Check_function(string stock_idX, Double target_valueX)
    {
        string stock_id = stock_idX;
        Double target_value = target_valueX;

        // 下載 Yahoo 奇摩股市資料 (範例為 2317 鴻海)
        WebClient client = new WebClient();
        ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        MemoryStream ms = new MemoryStream(client.DownloadData(
    "https://tw.stock.yahoo.com/q/q?s=" + stock_id + ""));

        // 使用預設編碼讀入 HTML
        HtmlDocument doc = new HtmlDocument();
        doc.Load(ms, Encoding.Default);

        // 裝載第一層查詢結果
        HtmlDocument docStockContext = new HtmlDocument();

        try
        {
            docStockContext.LoadHtml(doc.DocumentNode.SelectSingleNode(
"/html[1]/body[1]/center[1]/table[2]/tr[1]/td[1]/table[1]").InnerHtml);
           
        }
        catch (Exception)
        {
            return stock_id+"error";
            throw;
        }

        



        // 取得個股標頭
        HtmlNodeCollection nodeHeaders =
     docStockContext.DocumentNode.SelectNodes("./tr[1]/th");
        // 取得個股數值
        string[] values = docStockContext.DocumentNode.SelectSingleNode(
    "./tr[2]").InnerText.Trim().Split('\n');

        // 輸出資料

        string[] title ={ "股票代號", "時間", "成交", "買進", "賣出", "漲跌", "張數", "昨收", "開盤", "最高", "最低", "個股資料" };
        //for (int i = 0; i <= values.Length - 2; i++)
        //{
        //    Response.Write("Header:" + title[i] + values[i].ToString().Replace("加到投資組合", "") + "<br>");
        //}
        string abc0 = values[0].Trim().Replace("加到投資組合", "");
        string abc1 = values[1].Trim();
        string abc2 = values[2].Trim();
        string abc3 = values[3].Trim().Replace("－", "0");
        string abc4 = values[4].Trim().Replace("－", "0");
        string abc5 = values[5].Trim();
        string abc6 = values[6].Trim().Replace(",", "");
        string abc7 = values[7].Trim();
        string abc8 = values[8].Trim();
        string abc9 = values[9].Trim().Replace("－", "0");
        string abc10 = values[10].Trim().Replace("－", "0");

        string sql_insert = "";


        sql_insert = " INSERT INTO strong_up_myself (stock_id, dttm, price,buy_price,sell_price,up_down,volume,yesturday_price,first_price,top_price,low_price,stock_name)" +
" VALUES ('" + abc0.Substring(0, 4) + "', date(), " + abc2 + "," + abc3 + "," + abc4 + ",'" + abc5 + "'," + abc6 + "," + abc7 + "," + abc8 + "," + abc9 + "," + abc10 + ",'" + abc0 + "')                                                                                                         ";
        func.get_sql_execute(sql_insert, conn);

        Double last_price = System.Convert.ToDouble(abc2);

        //Response.Write("Header:" + "<br>");
        //Response.Write("股票代號<br>");
        //Response.Write(abc0 + "<br>");
        //Response.Write("時間<br>");
        //Response.Write(abc1 + "<br>");
        //Response.Write("成交<br>");
        //Response.Write(abc2 + "<br>");
        //Response.Write("買進<br>");
        //Response.Write(abc3 + "<br>");
        //Response.Write("賣出<br>");
        //Response.Write(abc4 + "<br>");
        //Response.Write("漲跌<br>");
        //Response.Write(abc5 + "<br>");
        //Response.Write("張數<br>");
        //Response.Write(abc6 + "<br>");
        //Response.Write("昨收<br>");
        //Response.Write(abc7 + "<br>");
        //Response.Write("開盤<br>");
        //Response.Write(abc8 + "<br>");
        //Response.Write("最高<br>");
        //Response.Write(abc9 + "<br>");



        doc = null;
        docStockContext = null;
        client = null;
        ms.Close();

        //Response.Write("Completed.");
       

        return "OK";



    }
}
