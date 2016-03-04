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

public partial class Default4 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string rowdata = "";
        string rowdataAAA = "";

        rowdata = Check_function_futures("http://tw.futures.finance.yahoo.com/future/l/future_1.html?rr=13517452708010.42279897451273523");

        rowdataAAA = rowdata;
    }

  

    public  string  Check_function_futures(string hyperlink)
    {
        string link = "http://tw.futures.finance.yahoo.com/future/l/future_1.html?rr=13517452708010.42279897451273523";

        link = hyperlink;

        // 下載 Yahoo 奇摩期貨資料 (範例為 近台指期)
        WebClient client = new WebClient(); ;
       
        MemoryStream ms = new MemoryStream(client.DownloadData(
   link));

        // 使用預設編碼讀入 HTML
        HtmlDocument doc = new HtmlDocument();
        doc.Load(ms, Encoding.Default);

        // 裝載第一層查詢結果
        HtmlDocument docStockContext = new HtmlDocument();

        docStockContext.LoadHtml(doc.DocumentNode.SelectSingleNode(
    "/html[1]/body[1]/center[1]/a[1]/table[2]/tr[1]/td[1]/table[2]").InnerHtml);

        // 取得個股標頭
        HtmlNodeCollection nodeHeaders =
     docStockContext.DocumentNode.SelectNodes("./tr[2]/th");

        // 取得個股數值
        string[] values = docStockContext.DocumentNode.SelectSingleNode(
    "./tr[2]").InnerText.Trim().Split('\n');

        // 輸出資料

        string[] title ={ "名稱", "時間", "成交價", "買進", "賣出", "漲跌", "總量", "基差", "昨收", "開盤", "最高", "最低" };
        string[] abc ={ "", "", "", "", "", "", "", "", "", "", "", "" };
        string tmp = "";
        for (int i = 0; i <= values.Length - 2; i++)
        {
            //Response.Write("Header:" + title[i] + values[i].ToString().Replace("加到投資組合", "") + "<br>");
            //abc[i] = values[i].Trim();
            if (i == 0)
            {
                tmp = values[i].Trim();
            }
            else
            {
                tmp = tmp + "," + values[i].Trim();
            
            }
            
        }
        #region MyRegion
        //abc[0] = values[0].Trim(); //name
        //abc[1] = values[1].Trim(); //datetime
        //abc[2] = values[2].Trim(); //price
        //abc[3] = values[3].Trim(); //buy
        //abc[4] = values[4].Trim(); //sell
        //abc[5] = values[5].Trim(); //benefit
        //abc[6] = values[6].Trim(); //voluume
        //abc[7] = values[7].Trim(); //diff
        //abc[8] = values[8].Trim(); //yes_close
        //abc[9] = values[9].Trim(); //open
        //abc[10] = values[10].Trim(); //high
        //abc[11] = values[11].Trim(); //low
        #endregion

       


        //Double last_price = System.Convert.ToDouble(abc);

        doc = null;
        docStockContext = null;
        client = null;
        ms.Close();

        return tmp;

        
      



    }

    
}
