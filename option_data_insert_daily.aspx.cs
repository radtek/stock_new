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

public partial class option_data_insert_daily : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["stock_insert"];
    string sql_temp1 = "";
    string sql_temp2 = "";
    DataSet Ds_temp1 = new DataSet();
    DataSet Ds_temp2 = new DataSet();
    ArrayList Arr_list = new ArrayList();
    DataTable DT_temp = new DataTable();


    protected void Page_Load(object sender, EventArgs e)
    {

     

     

            Check_function("", 0);



      
        func.write_log("option_insert_daily", Server.MapPath(".\\") + "\\RUN_LOG\\", "log");
        func.delete_log_file(Server.MapPath(".\\") + "\\RUN_LOG\\", "*.log", -30);
        Response.Write("<script language=\"javascript\">setTimeout(\"window.opener=null;window.open('','_self');  window.close();\",null)</script>");
    }


    public string Check_function(string stock_idX, Double target_valueX)
    {
        string stock_id = stock_idX;
        Double target_value = target_valueX;

        // 下載 Yahoo 奇摩股市資料 (範例為 2317 鴻海)
        WebClient client = new WebClient();
        MemoryStream ms = new MemoryStream(client.DownloadData(
    "http://www.taifex.com.tw/cht/3/optDailyMarketExcel" + stock_id + ""));

    //http://www.taifex.com.tw/cht/3/optDailyMarketReport
        
        // 使用預設編碼讀入 HTML
        HtmlDocument doc = new HtmlDocument();
        //doc.Load(ms, Encoding.Default);
        doc.Load(ms, Encoding.UTF8);

        // 裝載第一層查詢結果
        HtmlDocument docStockContext = new HtmlDocument();

        try
        {
            docStockContext.LoadHtml(doc.DocumentNode.SelectSingleNode(
"/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/table[1]/").InnerHtml);

//            docStockContext.LoadHtml(doc.DocumentNode.SelectSingleNode(
//"/html[1]/body[1]/div[1]/div[1]/div[1]/div[1]/div[2]/table[1]/tbody[1]/tr[2]/td[1]/table[2]/tbody[1]").InnerHtml);

        }
        catch (Exception)
        {
            return stock_id + "error";
            throw;
        }





     //   // 取得個股標頭
     //   HtmlNodeCollection nodeHeaders =
     //docStockContext.DocumentNode.SelectNodes("./tr[1]/th");



          // 取得個股標頭  get tr node number_count
        HtmlNodeCollection nodeHeaders =
     docStockContext.DocumentNode.SelectNodes("./tr[1]/th");
        // 取得個股數值
        Int32 j = 2;  //from tr[4] to tr[i-4]
        for (int i = 0; i <= nodeHeaders.Count; i++)
        {
            Int32 index = i + 2;



            char[] separator = new char[] { '\n', '\r', '\t' }; 

//            string[] values = docStockContext.DocumentNode.SelectSingleNode(
//"./tr[" + i+2 + "]").InnerText.Trim().Replace("\n\n", "AA").Replace("\t", "").Replace("\r", "").Split(separator,StringSplitOptions.RemoveEmptyEntries);

            string[] values = docStockContext.DocumentNode.SelectSingleNode(
"./tr[" + index + "]").InnerText.Trim().Replace("\n\n", "AA").Replace("\t", "").Replace("\r", "").Replace("??","").Split('\n');
         

            ArrayList myArrayList = new ArrayList();
            myArrayList.AddRange(values);


            //for (int k = 0; k <= myArrayList.Count-1; k++)
            //{

            //    if (myArrayList[k].ToString().Trim().Equals(""))
            //    {

            //        myArrayList.RemoveAt(k);
                
            //    }



            //}



            //ArrayList myArrayList1 = new ArrayList();
            //myArrayList1.AddRange(myArrayList);


            //for (int d = 0; d <= myArrayList1.Count - 1; d++)
            //{

            //    if (myArrayList1[d].ToString().Trim().Equals("") || myArrayList1[d].ToString().Equals(" "))
            //    {

            //        myArrayList1.RemoveAt(d);

            //    }



            //}



            ArrayList myArrayList1 = new ArrayList();



            for (int m = 0; m <= myArrayList.Count - 1; m++)
            {

                if (!myArrayList[m].ToString().Trim().Equals(""))
                {

                    myArrayList1.Add(myArrayList[m].ToString().Replace("-","0").Replace("%","0").Replace("??","00"));
                
                
                }

            }

            if (myArrayList1.Count>=19)
            {

                Response.Write("Over column");
            }

            string[] title ={ "契約", "到期月份", "履約價", "買賣權", "開盤價", "最高價", "最低價", "最後成交價", "結算價", "漲跌價", "漲跌%", "成交量", "未沖銷量", "最後最佳買價", "最後最佳賣價", "歷史最高價", "歷史最低價", "DTTM" };
            //for (int i = 0; i <= values.Length - 2; i++)
            //{
            //    Response.Write("Header:" + title[i] + values[i].ToString().Replace("加到投資組合", "") + "<br>");
            //}
            string KINDS = myArrayList1[0].ToString().Trim();
            string DUE_TIME = myArrayList1[1].ToString().Trim();
            string PRO_VALUE = myArrayList1[2].ToString().Trim();
            string CP_TYPE = myArrayList1[3].ToString().Trim();
            string OPEN_PRICE = myArrayList1[4].ToString().Trim();
            string HIGH_PRICE = myArrayList1[5].ToString().Trim();
            string LOW_PRICE = myArrayList1[6].ToString().Trim();
            string PRICE = myArrayList1[7].ToString().Trim();

            string UP_DOWN = myArrayList1[9].ToString().Trim().Replace("▼", "").Replace("▲", "").Replace("??","0");

            string volume = myArrayList1[13].ToString().Trim();
            string OI_volume = myArrayList1[14].ToString().Trim();

            string HIS_HIGH_PRICE = myArrayList1[17].ToString().Trim();
            string HIS_LOW_PRICE = myArrayList1[18].ToString().Trim();

            string sql_insert = "";


            sql_insert = " INSERT INTO OPTION_DATA (KINDS, DUE_TIME, PRO_VALUE,CP_TYPE,OPEN_PRICE,HIGH_PRICE,LOW_PRICE,PRICE,UP_DOWN,volume,OI_volume,HIS_HIGH_PRICE,HIS_LOW_PRICE,dttm)" +
    " VALUES ('" + KINDS + "', '" + DUE_TIME + "', " + PRO_VALUE + ",'" + CP_TYPE + "'," + OPEN_PRICE + "," + HIGH_PRICE + "," + LOW_PRICE + "," + PRICE + ",'" + UP_DOWN + "'," + volume + "," + OI_volume + "," + HIS_HIGH_PRICE + "," + HIS_LOW_PRICE + ",date()" + ")                                                                                                         ";
            func.get_sql_execute(sql_insert, conn);

            //Double last_price = System.Convert.ToDouble(abc2);

        }
       

        doc = null;
        docStockContext = null;
        client = null;
        ms.Close();

        //Response.Write("Completed.");


        return "OK";



    }
}
