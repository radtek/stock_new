using System;
using System.Data;
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
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Diagnostics;
using HtmlAgilityPack;
using System.Net.Mail;
using System.Threading;

/// <summary>
/// func 的摘要描述
/// </summary>
public class func
{
    public func()
    {
        //
        // TODO: 在此加入建構函式的程式碼
        //
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

    public static void start_process(string cmd_string)
    {

        Process prc = new Process();
        prc.StartInfo.FileName = @"cmd.exe ";
        prc.StartInfo.UseShellExecute = false;
        prc.StartInfo.RedirectStandardInput = true;
        prc.StartInfo.RedirectStandardOutput = true;
        prc.StartInfo.RedirectStandardError = true;
        prc.StartInfo.CreateNoWindow = false;

        prc.Start();

        string cmd = @"net use z: \\192.168.1.1\tmp pass /user:name ";
        cmd = cmd_string;
        prc.StandardInput.WriteLine(cmd);
        prc.StandardInput.Close();

    }

    public static void zip_file(string winrar_program_path, string destination_file, string target_file)
    {

        //System.Diagnostics.Process.Start(Server.MapPath("winrar.exe"), " a -ep " + Server.MapPath("abc.zip") + " " + Server.MapPath(".\\top.aspx")); 
        Process.Start(winrar_program_path, " a -ep " + destination_file + " " + target_file);


    }



    public static string get_netdrive_id()
    {
        string add_drive_id = "";
        string[] drives = Directory.GetLogicalDrives();

        if (drives[drives.Length - 1] == "C:\\")
            add_drive_id = "D";
        if (drives[drives.Length - 1] == "D:\\")
            add_drive_id = "E";
        if (drives[drives.Length - 1] == "E:\\")
            add_drive_id = "F";
        if (drives[drives.Length - 1] == "F:\\")
            add_drive_id = "G";
        if (drives[drives.Length - 1] == "H:\\")
            add_drive_id = "I";
        if (drives[drives.Length - 1] == "I:\\")
            add_drive_id = "J";
        if (drives[drives.Length - 1] == "J:\\")
            add_drive_id = "K";
        if (drives[drives.Length - 1] == "K:\\")
            add_drive_id = "L";
        if (drives[drives.Length - 1] == "L:\\")
            add_drive_id = "M";
        if (drives[drives.Length - 1] == "M:\\")
            add_drive_id = "N";
        if (drives[drives.Length - 1] == "N:\\")
            add_drive_id = "O";
        if (drives[drives.Length - 1] == "O:\\")
            add_drive_id = "P";
        if (drives[drives.Length - 1] == "P:\\")
            add_drive_id = "Q";
        if (drives[drives.Length - 1] == "Q:\\")
            add_drive_id = "R";
        if (drives[drives.Length - 1] == "R:\\")
            add_drive_id = "S";
        if (drives[drives.Length - 1] == "S:\\")
            add_drive_id = "T";
        if (drives[drives.Length - 1] == "T:\\")
            add_drive_id = "U";

        if (drives[drives.Length - 1] == "U:\\")
            add_drive_id = "V";
        if (drives[drives.Length - 1] == "V:\\")
            add_drive_id = "W";
        if (drives[drives.Length - 1] == "W:\\")
            add_drive_id = "X";
        if (drives[drives.Length - 1] == "X:\\")
            add_drive_id = "Y";
        if (drives[drives.Length - 1] == "Y:\\")
            add_drive_id = "Z";

        if (drives[drives.Length - 1] == "Z:\\")
            add_drive_id = "A";

        return add_drive_id;


    }

    public static void CreatePIC(string html_Path, string tool_path, string SavePath)
    {

        //string aaa = "M:\\report\\Stock_new\\wkhtmltopdf\\bin\\wkhtmltopdf.exe";
        ////string aaa = Server.MapPath(".")  + "\\wkhtmltopdf\\bin\\wkhtmltopdf.exe";

        //CreatePDF("http://vsoscar.ddns.net:8080/stocK_new/Stock_strong_volume1.aspx", aaa, Server.MapPath(".") + "\\File\\" + today_detail + ".pdf");


        Process _process = new Process();
        _process.StartInfo.FileName = tool_path;
        _process.StartInfo.Arguments = @"" + html_Path + " " + SavePath + "";
        _process.StartInfo.Arguments = @"SiteShoter.exe /URL "+"\""+html_Path+"\" /Filename \""+SavePath+"\" /DisableScrollBars 1 /BrowserWidth 800 /BrowserHeight 1024 /ImageSizePerCent 80";
        _process.Start();


        while (_process.HasExited)
        {
            //讓執行續暫停1秒  
            Thread.Sleep(600000);
        }


    }
 

    public static void CreatePDF(string html_Path, string tool_path, string SavePath)
    {

        //string aaa = "M:\\report\\Stock_new\\wkhtmltopdf\\bin\\wkhtmltopdf.exe";
        ////string aaa = Server.MapPath(".")  + "\\wkhtmltopdf\\bin\\wkhtmltopdf.exe";

        //CreatePDF("http://vsoscar.ddns.net:8080/stocK_new/Stock_strong_volume1.aspx", aaa, Server.MapPath(".") + "\\File\\" + today_detail + ".pdf");

        
        Process _process = new Process();
        _process.StartInfo.FileName = tool_path;
        _process.StartInfo.Arguments = @"" + html_Path + " " + SavePath + "";
        _process.Start();


        while (_process.HasExited)
        {
            //讓執行續暫停1秒  
            Thread.Sleep(600000);
        } 


    }


    public static void write_log(string program_name, string file_path, string file_type)
    {
        //Encoding enc = Encoding.GetEncoding("big5");
        //MemoryStream ms = new MemoryStream();

        StreamWriter sw;
        //UTF8Encoding utf8 = new UTF8Encoding();

        // sw.Encoding = System.Text.UTF8Encoding();
        //StreamWriter sw = new StreamWriter(Encoding.UTF8);

        DirectoryInfo di;//宣告目錄 
        FileInfo fi;//宣告檔案 
        string program_name1 = program_name;
        //di = new DirectoryInfo(Server.MapPath(".") + "\\RUN_LOG\\" ); //DateTime.Now.ToString("yyyyMMdd") 
        di = new DirectoryInfo(file_path); //DateTime.Now.ToString("yyyyMMdd") 
        //fi = new FileInfo(Server.MapPath(".") + "\\RUN_LOG\\" + DateTime.Now.ToString("yyyyMMdd") + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".log");
        fi = new FileInfo(file_path + DateTime.Now.ToString("yyyyMMdd") + "." + file_type);

        if (!di.Exists)
        {
            di.Create();//目錄不存在 產生目錄 
        }
        if (fi.Exists == true)
        {
            //檔案存在 寫檔案 
            //sw = File.AppendText(Server.MapPath(".") + "\\RUN_LOG\\" + DateTime.Now.ToString("yyyyMMdd") + ".log");
            sw = File.AppendText(file_path + DateTime.Now.ToString("yyyyMMdd") + "." + file_type);
        }
        else
        {
            sw = fi.CreateText(); //檔案不存在 產生檔案 
        }

        sw.WriteLine("Create log file");
        sw.WriteLine(DateTime.Now.ToString("u") + " " + program_name1 + " Program Start");
        sw.WriteLine(DateTime.Now.ToString("u") + " " + program_name1 + " Program END ");
        sw.WriteLine("");
        //byte[] encodebyte = utf8.GetBytes(sw);
        //string decodestring = utf8.GetString(sw);
        sw.Close();


    }



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

    public static void delete_log_dir(string file_path, string file_type, Double dayAgo)
    {
        //DirectoryInfo dir = new DirectoryInfo(Server.MapPath(".") + "\\CF\\Save_file\\"); 
        DirectoryInfo dir = new DirectoryInfo(file_path);
        // FileInfo[] files = dir.GetFiles("*.xls"); 
        //FileInfo[] files = dir.GetFiles(file_type); 

        DirectoryInfo[] subdir = dir.GetDirectories();


        for (int i = 0; i <= subdir.Length - 1; i++)
        {
            if (subdir[i].CreationTime < DateTime.Now.AddDays(dayAgo))
            {
                FileInfo[] files = subdir[i].GetFiles(file_type);

                for (int j = 0; j <= files.Length - 1; j++)
                {
                    if (files[j].CreationTime < DateTime.Now.AddDays(dayAgo))
                    {

                        files[j].Delete();
                    }



                }

                subdir[i].Delete();
            }



        }

        //Int32 counter = 0; 
        // Display the name of all the files. 
        #region MyRegion
        //foreach (FileInfo file in files) 
        //{ 
        // counter = counter + 1; 
        // Response.Write(counter + "."); 

        // Response.Write("Name: " + file.Name + " "); 
        // Response.Write("<br/>"); 
        // Response.Write("Size: " + file.Length.ToString()); 
        // Response.Write("<br/>"); 
        //} 
        #endregion



    }



    public static string get_ticket(string location, string user_id)
    {
        ArrayList al_temp = new ArrayList();
        al_temp = func.FileToArray(location);

        Int32 initial = 0;

        string str_ticket = "N";

        for (int i = 0; i < al_temp.Count; i++)
        {
            if (al_temp[i].ToString() == user_id)
            {
                initial++;
            }
        }


        if (initial > 0)
        {
            str_ticket = "Y";

        }
        return str_ticket;

    }

    public static string GetWeekOfCurrDate(DateTime dt)
    {
        int Week = 1;
        int nYear = dt.Year;
        System.DateTime FirstDayInYear = new DateTime(nYear, 1, 1);
        System.DateTime LastDayInYear = new DateTime(nYear, 12, 31);
        int DaysOfYear = Convert.ToInt32(LastDayInYear.DayOfYear);
        int WeekNow = Convert.ToInt32(FirstDayInYear.DayOfWeek) - 1;
        if (WeekNow < 0) WeekNow = 6;
        int DayAdd = 6 - WeekNow;
        System.DateTime BeginDayOfWeek = new DateTime(nYear, 1, 1);
        System.DateTime EndDayOfWeek = BeginDayOfWeek.AddDays(DayAdd);
        Week = 2;
        for (int i = DayAdd + 1; i <= DaysOfYear; i++)
        {
            BeginDayOfWeek = FirstDayInYear.AddDays(i);
            if (i + 6 > DaysOfYear)
            {
                EndDayOfWeek = BeginDayOfWeek.AddDays(DaysOfYear - i - 1);
            }
            else
            {
                EndDayOfWeek = BeginDayOfWeek.AddDays(6);
            }

            if (dt.Month == EndDayOfWeek.Month && dt.Day <= EndDayOfWeek.Day)
            {
                break;
            }
            Week++;
            i = i + 6;
        }
        string date_year_week = dt.Year + Week.ToString();
        return date_year_week;
    }


    public static string MergeMailListToString(string sql, string conn, string colume_name)
    {
        DataSet maillistX = new DataSet();

        string connx = System.Configuration.ConfigurationManager.AppSettings["OARPT"];

        connx = conn;
        string sql_mailist = "select * from dmbs_ce_alarm_mail_cfg t                                 " +
                             "where t.material_group='Chemical' and t.material='DMSO' and plan='T1'  ";


        sql_mailist = sql;

        //ArrayList maillist = new ArrayList();

        // maillist = func.FileToArray(Server.MapPath(".") + "\\maillist.txt"); 
        maillistX = func.get_dataSet_access(sql_mailist, connx);

        string maillist1 = "";
        string maillist2 = "";

        for (int i = 0; i <= maillistX.Tables[0].Rows.Count - 1; i++)
        {

            if (maillistX.Tables[0].Rows.Count == 1)
            {
                maillist1 = maillistX.Tables[0].Rows[i][colume_name].ToString();
            }
            else if (i <= maillistX.Tables[0].Rows.Count - 2)
            {
                maillist1 = maillistX.Tables[0].Rows[i][colume_name].ToString() + ","; //呈現每一個 DataSet Row[i] 
            }
            else
            {

                maillist1 = maillistX.Tables[0].Rows[i][colume_name].ToString();
            }


            maillist2 = maillist2 + maillist1; //將每個 DataSet Row[i] 的值串起來 
        }
        return maillist2;
    }

    public static void get_sql_execute(string sql_str, string strConn)
    {
        string strConn2;
        strConn2 = strConn;

        //strConn2 = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=c:\\stock.mdb; Persist Security Info=True;"; 
        string sql_str2;

        sql_str2 = sql_str;



        OleDbConnection myConnection = new OleDbConnection(strConn2);

        OleDbCommand myCommand = new OleDbCommand(sql_str2, myConnection);
        myConnection.Open();

        OleDbDataReader MyReader = myCommand.ExecuteReader();

        MyReader.Read();

        MyReader.Close();

        myConnection.Close();



    }

    public static string Check_function_futures(string hyperlink)
    {
        string link = "http://tw.futures.finance.yahoo.com/future/l/future_1.html?rr=13517452708010.42279897451273523";

        // 下載 Yahoo 奇摩期貨資料 (範例為 2317 鴻海)
        WebClient client = new WebClient(); ;
        
        MemoryStream ms = new MemoryStream(client.DownloadData(
   link));

        // 使用預設編碼讀入 HTML
        HtmlDocument doc = new HtmlDocument();
        doc.Load(ms, Encoding.Default);

        // 裝載第一層查詢結果
        HtmlDocument docStockContext = new HtmlDocument();

        docStockContext.LoadHtml(doc.DocumentNode.SelectSingleNode(
    "/html[1]/body[1]/center[1]/a[1]/table[2]/tr[1]/td[1]/table[2]/").InnerHtml);

        // 取得個股標頭
        HtmlNodeCollection nodeHeaders =
     docStockContext.DocumentNode.SelectNodes("./tr[2]/th");
        // 取得個股數值
        string[] values = docStockContext.DocumentNode.SelectSingleNode(
    "./tr[2]").InnerText.Trim().Split('\n');

        // 輸出資料

        string[] title ={ "名稱", "時間", "成交價", "買進", "賣出", "漲跌", "張數", "總量", "基差", "昨收", "開盤", "最高","最低" };
        for (int i = 0; i <= values.Length - 2; i++)
        {
            //Response.Write("Header:" + title[i] + values[i].ToString().Replace("加到投資組合", "") + "<br>");
        }
        string abc = values[2].Trim();

        Double last_price = System.Convert.ToDouble(abc);





        doc = null;
        docStockContext = null;
        client = null;
        ms.Close();

        return abc;



    }

    public static string Check_function_USA_price(string stock_idX)
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
        string[] abc ={ "", "", "" };
        abc[0] = values[0].Trim();
        abc[1] = values[1].Trim(); //stock_price
        abc[2] = values[2].Trim();//stock_name 

        //Double last_price = System.Convert.ToDouble(abc);

        doc = null;
        docStockContext = null;
        client = null;
        ms.Close();

        return abc[0] + "," + abc[1] + "," + abc[2];



    }

    public static string Check_function(string stock_idX)
    {
        string stock_id = stock_idX;

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
            //Response.Write("Header:" + title[i] + values[i].ToString().Replace("加到投資組合", "") + "<br>");
        }
        string abc = values[2].Trim();
        
         //Double last_price = System.Convert.ToDouble(abc);





        doc = null;
        docStockContext = null;
        client = null;
        ms.Close();

        return abc;



    }


    public static string Check_function_volume(string stock_idX)
    {
        string stock_id = stock_idX;

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
            //Response.Write("Header:" + title[i] + values[i].ToString().Replace("加到投資組合", "") + "<br>");
        }
        string abc = values[6].Trim();

        //Double last_price = System.Convert.ToDouble(abc);





        doc = null;
        docStockContext = null;
        client = null;
        ms.Close();

        return abc;



    }

    public static string Check_function_price_stock_name(string stock_idX)
    {
        string stock_id = stock_idX;

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
            //Response.Write("Header:" + title[i] + values[i].ToString().Replace("加到投資組合", "") + "<br>");
        }
        string[] abc ={ "", "" };
        abc[0] = values[2].Trim(); //stock_price
        abc[1] = values[0].Trim();//stock_name 

        //Double last_price = System.Convert.ToDouble(abc);





        doc = null;
        docStockContext = null;
        client = null;
        ms.Close();

        return abc[0] + "," + abc[1];



    }


    public static DataTable add_column(DataSet ds, string add_col)
    {
        DataSet ds_x = new DataSet();

        DataTable dtNew = new DataTable();

        ds_x = ds;
        dtNew = ds_x.Tables[0];

        dtNew.Columns.Add(add_col, typeof(string));

        return dtNew;

    }


    public static DataTable Table_add_column(DataTable dt, string add_col)
    {


        DataTable dtNew = new DataTable();


        dtNew = dt;

        dtNew.Columns.Add(add_col, typeof(string));

        return dtNew;

    }

    public static DataSet get_dataSet_access(string sql_str, string strConn)
    {
        string strConn2;
        strConn2 = strConn;

        //strConn2 = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=c:\\stock.mdb; Persist Security Info=True;"; 
        string sql_str2;

        sql_str2 = sql_str;

        OleDbDataAdapter oda2 = new OleDbDataAdapter(sql_str2, strConn2);

        DataSet myDataSet2 = new DataSet();
        oda2.Fill(myDataSet2, "AccessInfo");
        return myDataSet2;

    }



    private static DataTable get_dataTable(string sql_str, string strConn)
    {
        string strConn2;
        strConn2 = strConn;

        //strConn2 = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=c:\\stock.mdb; Persist Security Info=True;"; 
        string sql_str2;

        sql_str2 = sql_str;

        OleDbDataAdapter oda2 = new OleDbDataAdapter(sql_str2, strConn2);

        DataTable myDataTable2 = new DataTable();
        oda2.Fill(myDataTable2, "AccessInfo");
        return myDataTable2;

    }



    public static DataTable Table_transport(DataTable dt)
    {
        DataTable dtNew = new DataTable();
        dtNew.Columns.Add("ColumnName", typeof(string));
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dtNew.Columns.Add("Column" + (i + 1).ToString(), typeof(string));
        }
        foreach (DataColumn dc in dt.Columns)
        {
            DataRow drNew = dtNew.NewRow();
            drNew["ColumnName"] = dc.ColumnName;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                drNew[i + 1] = dt.Rows[i][dc].ToString();
            }
            dtNew.Rows.Add(drNew);
        }

        return dtNew;
    }



    public static ArrayList FileToArray(string srtPath)
    {
        StreamReader ReadFile = new StreamReader(srtPath, // 檔案路徑
    //System.Text.Encoding.Default); // 編碼方式
    System.Text.Encoding.UTF8); // 編碼方式

        ArrayList arrFile = new ArrayList(); //make our temporary storage object
        string strTmp;

        //loop through all the rows, stopping when we reach the end of file
        do
        {
            strTmp = ReadFile.ReadLine();
            if (strTmp != null)
            {
                strTmp = strTmp.Trim();
                if (strTmp.Length != 0) arrFile.Add(strTmp); //add each element to our ArrayList
            }
        } while (strTmp != null);
        ReadFile.Close();
        return arrFile;
    }


    //public static void BindGridView(string sql, string strConn)
    //{
    //    string sql_str, strConn2;
    //    DataSet myDataSet123 = new DataSet();
    //    sql_str = sql;
    //    //sql_str = "select * from stock_macd_1 WHERE DATE>DATEADD('d',-1,NOW()) order by DATE desc"; 
    //    //GridView GridViewn = new GridView(); 

    //    //DATEADD(day, 1, @CountDate) 
    //    strConn2 = strConn;

    //    myDataSet123 = get_dataSet_access(sql_str, strConn2);

    //    GridView1.DataSource = myDataSet123.Tables["AccessInfo"].DefaultView;
    //    GridView1.DataBind();
    //} 



    public static string ArrayListToString(string file_path)
    {

        ArrayList maillist = new ArrayList();

        // maillist = func.FileToArray(Server.MapPath(".") + "\\maillist.txt"); 
        maillist = func.FileToArray(file_path);

        string maillist1 = "";
        string maillist2 = "";

        for (int i = 0; i <= maillist.Count - 1; i++)
        {

            if (i == maillist.Count - 1)
            {
                maillist1 = maillist[i].ToString();
            }
            else

                maillist1 = maillist[i] + ","; //呈現每一個 ArrayList[i] 
            maillist2 = maillist2 + maillist1; //將每個ArrayList[i]的值串起來 
        }
        return maillist2;
    }


    private static void Upload(string filename, string ftpServerIP, string Account, string ftppassword)
    {

        FileInfo fileInf = new FileInfo(filename);

        string uri = "ftp://" + ftpServerIP + "/" + fileInf.Name;

        FtpWebRequest reqFTP;

        // Create FtpWebRequest object from the Uri provided

        reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + fileInf.Name));//此段關鍵

        // Provide the WebPermission Credintials

        reqFTP.Credentials = new NetworkCredential(Account, ftppassword);

        // By default KeepAlive is true, where the control connection is not closed

        // after a command is executed.

        reqFTP.KeepAlive = false;

        // Specify the command to be executed.

        reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

        // Specify the data transfer type.

        reqFTP.UseBinary = true;

        // Notify the server about the size of the uploaded file

        reqFTP.ContentLength = fileInf.Length;

        // The buffer size is set to 2kb

        int buffLength = 2048;

        byte[] buff = new byte[buffLength];

        int contentLen;

        // Opens a file stream (System.IO.FileStream) to read the file to be uploaded

        FileStream fs = fileInf.OpenRead();

        try
        {

            // Stream to which the file to be upload is written

            Stream strm = reqFTP.GetRequestStream();

            // Read from the file stream 2kb at a time

            contentLen = fs.Read(buff, 0, buffLength);

            // Till Stream content ends

            while (contentLen != 0)
            {

                // Write Content from the file stream to the FTP Upload Stream

                strm.Write(buff, 0, contentLen);

                contentLen = fs.Read(buff, 0, buffLength);

            }

            // Close the file stream and the Request Stream

            strm.Close();

            fs.Close();

        }


        catch (Exception ex)
        {

            //MessageBox.Show(ex.Message, "Upload Error");

        }

    }

    

}
