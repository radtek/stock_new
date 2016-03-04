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
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text;
using System.Text.RegularExpressions;

public partial class Default3 : System.Web.UI.Page
{

    string today = DateTime.Now.AddDays(+0).ToString("yyyyMMdd");
    protected void Page_Load(object sender, EventArgs e)
    {
       // get_loader_data("");

        WebClient w = new WebClient();
        w.Encoding = Encoding.GetEncoding("big5");
        string strHTML = w.DownloadString("http://vsoscar.ddns.net:8080/Stock_new/Stock_strong_volume1.aspx");
        create_directory(Server.MapPath(".") + "\\RUN_LOG\\" + today+"\\","Html_TO_PDF","log");
        ConvertHTMLToPDF(strHTML);


    }


    private void create_directory(string file_path, string program_name, string file_type)
    {


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
    private void ConvertHTMLToPDF(string HTMLCode)
    {
        HttpContext context = HttpContext.Current;

        //Render PlaceHolder to temporary stream
        System.IO.StringWriter stringWrite = new StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        /********************************************************************************/
        //Try adding source strings for each image in content
        string tempPostContent = getImage(HTMLCode);
        /*********************************************************************************/

        StringReader reader = new StringReader(tempPostContent);

        //Create PDF document
        Document doc = new Document(PageSize.A2);
        HTMLWorker parser = new HTMLWorker(doc);
        PdfWriter.GetInstance(doc, new FileStream(Server.MapPath(".") + "\\RUN_LOG" + today + "\\Strong_up.pdf",

        FileMode.Create));
        doc.Open();

        try
        {
            //Parse Html and dump the result in PDF file
            parser.Parse(reader);
        }
        catch (Exception ex)
        {
            //Display parser errors in PDF.
            Paragraph paragraph = new Paragraph("Error!" + ex.Message);
            Chunk text = paragraph.Chunks[0] as Chunk;
            if (text != null)
            {
                text.Font.Color = BaseColor.RED;
            }
            doc.Add(paragraph);
        }
        finally
        {
            doc.Close();
        }
    }

    public string getImage(string input)
    {
        if (input == null)
            return string.Empty;
        string tempInput = input;
        string pattern = @"<img(.|\n)+?>";
        string src = string.Empty;
        HttpContext context = HttpContext.Current;

        //Change the relative URL's to absolute URL's for an image, if any in the HTML code.
        foreach (Match m in Regex.Matches(input, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline |

        RegexOptions.RightToLeft))
        {
            if (m.Success)
            {
                string tempM = m.Value;
                string pattern1 = "src=[\'|\"](.+?)[\'|\"]";
                Regex reImg = new Regex(pattern1, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                Match mImg = reImg.Match(m.Value);

                if (mImg.Success)
                {
                    src = mImg.Value.ToLower().Replace("src=", "").Replace("\"", "");

                    if (src.ToLower().Contains("http://") == false)
                    {
                        //Insert new URL in img tag
                        src = "src=\"" + context.Request.Url.Scheme + "://" +
                        context.Request.Url.Authority + src + "\"";
                        try
                        {
                            tempM = tempM.Remove(mImg.Index, mImg.Length);
                            tempM = tempM.Insert(mImg.Index, src);

                            //insert new url img tag in whole html code
                            tempInput = tempInput.Remove(m.Index, m.Length);
                            tempInput = tempInput.Insert(m.Index, tempM);
                        }
                        catch (Exception e)
                        {

                        }
                    }
                }
            }
        }
        return tempInput;
    }
    public  string get_loader_data(string stock_idX)
    {
        string stock_id = stock_idX;

        // 下載 Yahoo 奇摩股市資料 (範例為 2317 鴻海)
        WebClient client = new WebClient();
        MemoryStream ms = new MemoryStream(client.DownloadData(
    "http://5720.moneydj.com/z/zk/zk3/zkparse_820_NA.asp.htm" + stock_id + ""));


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
        for (int i = 0; i <= nodeHeaders.Count -4; i++)
        {
          
            string[] values = docStockContext.DocumentNode.SelectSingleNode(
  "./tr["+j+"]").InnerText.Trim().Split('\r');

            write_loader_file("stock_today", Server.MapPath(".\\") + "config\\", "txt", values[0].ToString().Replace("加到投資組合", ""));
            
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


    public void write_loader_file(string program_name, string file_path, string file_type,string stock_name)
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


    }
}
