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

public partial class futures : System.Web.UI.Page
{
  
    string today = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd");

    string today_minus7 = DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd");
    string today_minus15 = DateTime.Now.AddDays(-15).ToString("yyyy/MM/dd");

    string today_detail = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd HH:mm:ss");
    string sql_insert = "";
    string conn = System.Configuration.ConfigurationSettings.AppSettings["jump"];
 
    protected void Page_Load(object sender, EventArgs e)
    {

        string rowdata = "";
        string rowdataAAA = "";


    
        //rowdata = Check_function_futures("http://tw.futures.finance.yahoo.com/future/l/future_1.html?rr=13517452708010.42279897451273523");

        //rowdata = Check_function_futures1("http://www.cnyes.com/futures/indexftr3.aspx");

        rowdata = Check_function_futures2("http://www.cnyes.com/futures/indexftr3.aspx");

        

        rowdataAAA = rowdata ;

        //string[] receive = rowdataAAA.Split(',');
        string[] receive = rowdataAAA.Split('!');

      


        
        
        
        
        
        
        
        
        
        
        //跌
        //13:44!       時間 0
        //?唳???1!   名稱 1
        //7737!        買價 2
        //7739!        賣價 3
        //7739!        成交 4 
        //00-197!      漲跌 5
        //00-2!        漲%  6
        //487859!      開盤 7
        //7870!        最高 8
        //7733!        最低 9
        //128490!      成交量 10
        //51406!       未平倉 11
        //7936         昨收   12

        //漲            
        //13:45!        時間 0
        //?唳???1!    名稱 1
        //7727!         買價 2
        //7728!         賣價 3
        //7728!         成交 4
        //0020!         漲跌 5
        //267737!       漲%   6  
        //00!           開盤
        //7745!         最高 7
        //7713!         最低 8
        //59185!        成交量 9 
        //52252!        未平倉 10
        //7708          昨收   11

        //20130409  oscar

//        sql_insert = " INSERT INTO newfutures (SN, NAME, DATETIMES,PRICE,BUY_price,SELL_price,UP_DOWN,volume,diff,yes_price,open_price,high_price,low_price,dttm)" +
//" VALUES (1, '" + "台指期近1" + "' , format('" + today + " {0}','yyyy/MM/dd HH:mm:ss'),{1},{2},{3},{4},{5},0,{6},0,{7},{8},date())    ";


        //台指近月!
        //8633!      BUY_price
        //8634!      SELL_price
        //8633!      PRICE
        //90!
        //0.10!
        //1!
        //51315!
        //8664!
        //8622

        //20131231 oscar

        sql_insert = " INSERT INTO newfutures (SN, NAME, DATETIMES,PRICE,BUY_price,SELL_price,UP_DOWN,volume,diff,yes_price,open_price,high_price,low_price,dttm)" +
" VALUES (1, '" + "台指期近1" + "' , format('" + today_detail + "','yyyy/MM/dd HH:mm:ss'),{0},{1},{2},{3},{4},0,{5},0,{6},{7},date())    ";



                                                                                                                     // updown              UP_DOWN                   volume
        sql_insert = string.Format(sql_insert, receive[3].ToString(), receive[1].ToString(), receive[2].ToString(), receive[4].ToString(), "0", receive[7].ToString(), receive[8].ToString(), receive[9].ToString());




        //if (Convert.ToInt32(receive[5].ToString().Replace("00", "")) > 0)
        //{
        //    //           sql_insert = " INSERT INTO newfutures (SN, NAME, DATETIMES,PRICE,BUY_price,SELL_price,UP_DOWN,volume,diff,yes_price,open_price,high_price,low_price,dttm)" +
        //    //" VALUES (1, '" + "台指期近1" + "' , format('" + today + " " + receive[0].ToString() + "','yyyy/MM/dd HH:mm:ss')," + receive[4].ToString() + "," + receive[2].ToString() + "," + receive[3].ToString() + "," + receive[5].ToString().ToString().Replace("▽", "-").Replace("△", "") + "," + receive[10].ToString() + ",0," + receive[12].ToString() + ",0," + receive[8].ToString() + "," + receive[9].ToString() + ",date())    ";                                                                                                  

        //    sql_insert = string.Format(sql_insert, receive[0].ToString(), receive[4].ToString(), receive[2].ToString(), receive[3].ToString(), receive[5].ToString().ToString().Replace("▽", "-").Replace("△", ""), receive[10].ToString(), receive[12].ToString(), receive[8].ToString(), receive[9].ToString());


        //}
        //else
        //{
        //    sql_insert = string.Format(sql_insert, receive[0].ToString(), receive[4].ToString(), receive[2].ToString(), receive[3].ToString(), receive[5].ToString().ToString().Replace("▽", "-").Replace("△", ""), receive[11].ToString(), receive[13].ToString(), receive[9].ToString(), receive[10].ToString());
        
        //}


        

       
        
        
        func.get_sql_execute(sql_insert, conn);



        string frmClose = @"<script language='javascript' type='text/JavaScript'> 

window.opener=null; 
window.open('','_self'); 
window.close(); 
</script>";

        //呼叫 javascript 
        this.Page.RegisterStartupScript("", frmClose); 

        //Response.Write(rowdataAAA);
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
        for (int i = 0; i <= values.Length - 1; i++)
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

    public string Check_function_futures1(string hyperlink)
    {
        string link = "http://tw.futures.finance.yahoo.com/future/l/future_1.html?rr=13517452708010.42279897451273523";
        //http://www.cnyes.com/futures/indexftr3.aspx

        link = hyperlink;

        // 下載 Yahoo 奇摩期貨資料 (範例為 近台指期)
        WebClient client = new WebClient(); ;

        MemoryStream ms = new MemoryStream(client.DownloadData(
   link));

        // 使用預設編碼讀入 HTML
        HtmlDocument doc = new HtmlDocument();
        //doc.Load(ms, Encoding.Default);
        doc.Load(ms, Encoding.Default);

        // 裝載第一層查詢結果
        HtmlDocument docStockContext = new HtmlDocument();

        docStockContext.LoadHtml(doc.DocumentNode.SelectSingleNode(
    "/html[1]/body[1]/div[4]/div[2]/div[1]/div[1]/div[1]/table[1]").InnerHtml);

        // 取得個股標頭
        HtmlNodeCollection nodeHeaders =
     docStockContext.DocumentNode.SelectNodes("./tr[2]/th");

        // 取得個股數值
        string[] values = docStockContext.DocumentNode.SelectSingleNode("./tr[3]").InnerText.Trim().Split('\n');

        // 輸出資料

        string[] title ={ "時間", "名稱", "買價", "賣價", "成交", "漲跌", "漲%", "開盤", "最高", "最低", "成交量", "未平倉", "昨收" };
        string[] abc ={ "", "", "", "", "", "", "", "", "", "", "", "" };
        string tmp = "";
        for (int i = 0; i <= values.Length - 1; i++)
        {
            //Response.Write("Header:" + title[i] + values[i].ToString().Replace("加到投資組合", "") + "<br>");
            //abc[i] = values[i].Trim();
            if (i == 0)
            {
                tmp = values[i].Trim().Replace("\r","");
            }
            else if (i == 4)
            {
                //7,934.0031.000.397,944.00+   成交 漲跌 漲% 開盤
                string[] split_value = values[i].Trim().ToString().Split('.');

        



                for (int j = 0; j <= split_value.Length-1; j++)
                {

                    tmp = tmp + "!" + split_value[j].ToString();

                }



               

            }
            else
            {

                tmp = tmp + "!" + values[i].Trim().Replace(",", "");
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

        //13:45+      時間
        //?唳???1+  名稱
        //7,934.00+   買價
        //7,936.00+   賣價
        //7,934.0031.000.397,944.00+   成交 漲跌 漲% 開盤
        //7,953.00+   最高
        //7,910.00+   最低
        //67,479+     成交量
        //51,567+     未平倉
        //7,903.00    昨收
#endregion


        //tmp = tmp.Replace(",", "").Replace(".00","").Replace("+00","").Replace("+000","");
        //tmp = tmp.Replace(",", "").Replace(".00", "").Replace("!000","").Replace("!00!","!");

        tmp = tmp.Replace(",", "").Replace(".00", "").Replace("!000", "");

        //Double last_price = System.Convert.ToDouble(abc);

        doc = null;
        docStockContext = null;
        client = null;
        ms.Close();

        // monitor  program  write log
        func.write_log("on time future report...", Server.MapPath(".") + "\\RUN_LOG\\", "log");
        return tmp;






    }

    public string Check_function_futures2(string hyperlink)
    {
        string link = "http://tw.futures.finance.yahoo.com/future/l/future_1.html?rr=13517452708010.42279897451273523";
        //http://www.cnyes.com/futures/indexftr3.aspx

        link = hyperlink;

        link = "http://www.capitalfutures.com.tw/quotations/list.asp";

        // 下載 Yahoo 奇摩期貨資料 (範例為 近台指期)
        WebClient client = new WebClient(); ;

        MemoryStream ms = new MemoryStream(client.DownloadData(
   link));

        // 使用預設編碼讀入 HTML
        HtmlDocument doc = new HtmlDocument();
        //doc.Load(ms, Encoding.Default);
        doc.Load(ms, Encoding.Default);

        // 裝載第一層查詢結果
        HtmlDocument docStockContext = new HtmlDocument();

        docStockContext.LoadHtml(doc.DocumentNode.SelectSingleNode(
    "/html[1]/body[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/table[3]").InnerHtml);

        // 取得個股標頭
        HtmlNodeCollection nodeHeaders =
     docStockContext.DocumentNode.SelectNodes("./tr[1]/th");

        // 取得個股數值
        string[] values = docStockContext.DocumentNode.SelectSingleNode("./tr[5]").InnerText.Trim().Split('\n');

        // 輸出資料

        string[] title ={ "時間", "名稱", "買價", "賣價", "成交", "漲跌", "漲%", "開盤", "最高", "最低", "成交量", "未平倉", "昨收" };
        
        //名稱 	買進 	賣出 	成交價 	漲跌 	幅度 	單量 	成交量 	最高 	最低
        
        string[] abc ={ "", "", "", "", "", "", "", "", "", "" };
        string tmp = "";
        for (int i = 0; i <= values.Length - 1; i++)
        {
            //Response.Write("Header:" + title[i] + values[i].ToString().Replace("加到投資組合", "") + "<br>");
            if (i == values.Length - 1)
            {
                tmp = tmp + values[i].Trim();
            }
            else 
            
            {
                tmp = tmp + values[i].Trim()+"!";
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

        //13:45+      時間
        //?唳???1+  名稱
        //7,934.00+   買價
        //7,936.00+   賣價
        //7,934.0031.000.397,944.00+   成交 漲跌 漲% 開盤
        //7,953.00+   最高
        //7,910.00+   最低
        //67,479+     成交量
        //51,567+     未平倉
        //7,903.00    昨收
        #endregion


        //tmp = tmp.Replace(",", "").Replace(".00","").Replace("+00","").Replace("+000","");
        //tmp = tmp.Replace(",", "").Replace(".00", "").Replace("!000","").Replace("!00!","!");

        tmp = tmp.Replace(",", "").Replace(".00", "").Replace("&nbsp;", "").Replace("!!!", "!").Replace("!!", "!").Replace("△", "").Replace("▽", "-").Replace(".000","");
        
        //Double last_price = System.Convert.ToDouble(abc);

        doc = null;
        docStockContext = null;
        client = null;
        ms.Close();

        // monitor  program  write log
        func.write_log("on time future report...", Server.MapPath(".") + "\\RUN_LOG\\", "log");
        return tmp;






    }
}
