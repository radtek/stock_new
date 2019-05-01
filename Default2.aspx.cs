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
using System.Security.Cryptography;


public partial class Default2 : System.Web.UI.Page
{
     string target="";
   

    string today_detail = DateTime.Now.AddDays(+0).ToString("yyyyMMddHHmmss");
    protected void Page_Load(object sender, EventArgs e)
    {
        string sourceFile = Server.MapPath(".") + "\\a.txt";

        string encryptFile = Server.MapPath(".") + "\\b.txt";

        string decryptFile = Server.MapPath(".") + "\\c.txt";
        TextBox1.Visible = false;
        TextBox5.Visible = false;
        if (!IsPostBack)
        {

            TextBox2.Text = "https://tw.yahoo.com?userid=jolina&flag=Y";
            TextBox3.Text = "12345678";
            TextBox6.Text = "12345678";

            TextBox4.Text = "87654321";
            TextBox7.Text = "87654321";


            HyperLink1.NavigateUrl = "http://vsoscar101.ddns.net:8080/stocK_new/" + "a.txt";
            HyperLink1.Text = "欲加密網址";
            HyperLink1.Target = "_blank";

            HyperLink2.NavigateUrl = "http://vsoscar101.ddns.net:8080/stocK_new/" + "b.txt";
            HyperLink2.Text = "加密後網址";
            HyperLink2.Target = "_blank";

            HyperLink3.NavigateUrl = "http://vsoscar101.ddns.net:8080/stocK_new/" + "c.txt";
            HyperLink3.Text = "解密後網址";
            HyperLink3.Target = "_blank";

        
        }

        
        
       
        

        //desDecryptFile(encryptFile, decryptFile,"12345678","87654321");


      
    }


    public static void desEncryptFile(string sourceFile, string encryptFile,string skey,string siv)
    {

        if (string.IsNullOrEmpty(sourceFile) || string.IsNullOrEmpty(encryptFile))
        {

            return;

        }

        if (!File.Exists(sourceFile))
        {

            return;

        }


        DESCryptoServiceProvider des = new DESCryptoServiceProvider();

        byte[] key = Encoding.ASCII.GetBytes(skey);

        byte[] iv = Encoding.ASCII.GetBytes(siv);



        des.Key = key;

        des.IV = iv;
        //IV屬性是的用來取得或設定對稱算法的初始化向量;即，加解密雙方需要同樣的IV向量


        using (FileStream sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))

        using (FileStream encryptStream = new FileStream(encryptFile, FileMode.Create, FileAccess.Write))
        {

            //檔E案!N加D[密OK

            byte[] dataByteArray = new byte[sourceStream.Length];

            sourceStream.Read(dataByteArray, 0, dataByteArray.Length);



            using (CryptoStream cs = new CryptoStream(encryptStream, des.CreateEncryptor(), CryptoStreamMode.Write))
            {

                cs.Write(dataByteArray, 0, dataByteArray.Length);

                cs.FlushFinalBlock();

            }

        }

    }


    public static void desDecryptFile(string encryptFile, string decryptFile,string skey,string siv)
    {

        if (string.IsNullOrEmpty(encryptFile) || string.IsNullOrEmpty(decryptFile))
        {

            return;

        }

        if (!File.Exists(encryptFile))
        {

            return;

        }



        DESCryptoServiceProvider des = new DESCryptoServiceProvider();

        byte[] key = Encoding.ASCII.GetBytes(skey);

        byte[] iv = Encoding.ASCII.GetBytes(siv);


        des.Key = key;

        des.IV = iv;
        //IV屬性是的用來取得或設定對稱算法的初始化向量;即，加解密雙方需要同樣的IV向量



        using (FileStream encryptStream = new FileStream(encryptFile, FileMode.Open, FileAccess.Read))

        using (FileStream decryptStream = new FileStream(decryptFile, FileMode.Create, FileAccess.Write))
        {

            byte[] dataByteArray = new byte[encryptStream.Length];

            encryptStream.Read(dataByteArray, 0, dataByteArray.Length);

            using (CryptoStream cs = new CryptoStream(decryptStream, des.CreateDecryptor(), CryptoStreamMode.Write))
            {

                cs.Write(dataByteArray, 0, dataByteArray.Length);

                cs.FlushFinalBlock();

            }

        }

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
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sourceFile = Server.MapPath(".") + "\\a.txt";

        string encryptFile = Server.MapPath(".") + "\\b.txt";

        //FileInfo fi;//宣告檔案 
        //fi = new FileInfo(Server.MapPath(".") + "\\a.txt");
        //fi.Delete();

        StreamWriter sw;
        //UTF8Encoding utf8 = new UTF8Encoding();

        // sw.Encoding = System.Text.UTF8Encoding();
        //StreamWriter sw = new StreamWriter(Encoding.UTF8);

        DirectoryInfo di;//宣告目錄 
        FileInfo fi;//宣告檔案 
        //string program_name1 = program_name;
        //di = new DirectoryInfo(Server.MapPath(".") + "\\RUN_LOG\\" ); //DateTime.Now.ToString("yyyyMMdd") 
        di = new DirectoryInfo(Server.MapPath(".")); //DateTime.Now.ToString("yyyyMMdd") 
        //fi = new FileInfo(Server.MapPath(".") + "\\RUN_LOG\\" + DateTime.Now.ToString("yyyyMMdd") + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".log");
        fi = new FileInfo(Server.MapPath(".") + "\\a.txt");
        fi.Delete();
        //if (!di.Exists)
        //{
        //    di.Create();//目錄不存在 產生目錄 
        //}
        if (fi.Exists == true)
        {
            fi.Delete();
           
          
            //檔案存在 寫檔案 
            //sw = File.AppendText(Server.MapPath(".") + "\\RUN_LOG\\" + DateTime.Now.ToString("yyyyMMdd") + ".log");
            sw = File.AppendText(Server.MapPath(".") + "\\a.txt");
        }
        else
        {
            sw = fi.CreateText(); //檔案不存在 產生檔案 
        }

        sw.WriteLine(TextBox2.Text);
       
        //byte[] encodebyte = utf8.GetBytes(sw);
        //string decodestring = utf8.GetString(sw);
        sw.Close();
       

        desEncryptFile(sourceFile, encryptFile, TextBox3.Text, TextBox4.Text);

        ArrayList al = new ArrayList();

        al=func.FileToArray(Server.MapPath(".") + "\\b.txt");
        TextBox1.Text = al[0].ToString();


    }
    protected void Button2_Click(object sender, EventArgs e)
    {


       

        string encryptFile = Server.MapPath(".") + "\\b.txt";

        string decryptFile = Server.MapPath(".") + "\\c.txt";

        //#region MyRegion
        //StreamWriter sw;
        ////UTF8Encoding utf8 = new UTF8Encoding();

        //// sw.Encoding = System.Text.UTF8Encoding();
        ////StreamWriter sw = new StreamWriter(Encoding.UTF8);

        //DirectoryInfo di;//宣告目錄 
        //FileInfo fi;//宣告檔案 
        ////string program_name1 = program_name;
        ////di = new DirectoryInfo(Server.MapPath(".") + "\\RUN_LOG\\" ); //DateTime.Now.ToString("yyyyMMdd") 
        //di = new DirectoryInfo(Server.MapPath(".")); //DateTime.Now.ToString("yyyyMMdd") 
        ////fi = new FileInfo(Server.MapPath(".") + "\\RUN_LOG\\" + DateTime.Now.ToString("yyyyMMdd") + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".log");
        //fi = new FileInfo(Server.MapPath(".") + "\\b.txt");
        //fi.Delete();
        ////if (!di.Exists)
        ////{
        ////    di.Create();//目錄不存在 產生目錄 
        ////}
        //if (fi.Exists == true)
        //{
        //    fi.Delete();


        //    //檔案存在 寫檔案 
        //    //sw = File.AppendText(Server.MapPath(".") + "\\RUN_LOG\\" + DateTime.Now.ToString("yyyyMMdd") + ".log");
        //    sw = File.AppendText(Server.MapPath(".") + "\\b.txt");
        //}
        //else
        //{
        //    sw = fi.CreateText(); //檔案不存在 產生檔案 
        //}

        //sw.WriteLine(TextBox5.Text);

        ////byte[] encodebyte = utf8.GetBytes(sw);
        ////string decodestring = utf8.GetString(sw);
        //sw.Close();
        //#endregion
        
        
        
        desDecryptFile(encryptFile, decryptFile, TextBox6.Text, TextBox7.Text);

        ArrayList al = new ArrayList();

        al = func.FileToArray(Server.MapPath(".") + "\\c.txt");
        TextBox8.Text = al[0].ToString();
    }
}
