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
using Excel1 = Microsoft.Office.Interop.Excel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Threading;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

public partial class epaper_Excel2PIC_Get_excel_data2pic : System.Web.UI.Page
{
    Excel1.Application _Excel = null;

    string today_yyyymmdd = DateTime.Now.AddDays(+0).ToString("yyyyMMdd");
    string today_yyyymmddHH = DateTime.Now.AddDays(+0).ToString("yyyyMMddHH");
    string today_detail = DateTime.Now.AddDays(+0).ToString("yyyyMMddHHmmss");
    string today_HH = DateTime.Now.AddDays(+0).ToString("HH");
    string today_DD = DateTime.Now.AddDays(+0).ToString("dd");
    string tool = "";
    string website = "";
    string title = "";
    string strHTML = "";
    string mail_list = "";
    
    
   
    protected void Page_Load(object sender, EventArgs e)
    {


        Session["ForceFlag"] = Request.QueryString["FF"].ToString();
        //Session["ForceFlag"] = "Y";
        // System.Threading.Thread.CurrentThread.ApartmentState = System.Threading.ApartmentState.STA;
        try
        {
            foreach (Process proc in Process.GetProcessesByName("EXCEL"))
            {
                proc.Kill();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }


        member oscar = new member();
      
            Thread myth;
            myth = new Thread(new System.Threading.ThreadStart(Test1));
            myth.ApartmentState = ApartmentState.STA;
            myth.Start();
       
       



        string frmClose = @"<script language='javascript' type='text/JavaScript'> 
window.opener=null; 

window.open('','_self'); 

window.close();

</script>";

        //呼叫 javascript 
        this.Page.RegisterStartupScript("", frmClose);
    }
    public void Test1()
    {
        /* Excel.Application：Excel應用程式
         Excel.Workbook：應用程式裡的活頁簿，預設情況下，不管你開幾個Excel檔案，在工作管理員裡只會出現一個Excel.exe
         Excel.Worksheet：活頁簿裡的工作表
         Excel.Range：工作表裡的儲存格，一格也是Range，多格也是Range，用法Excel.Range[“A1”];
         Excel.Range.Cells：這是儲存格的最小單位，代表一格的Range，用法Excel.Range.Cells[1,1];*/

       

         //if(1==1)
        if ((Convert.ToInt32(today_HH) >= 8 && Convert.ToInt32(today_HH) <= 15) || Convert.ToInt32(today_HH) == 19 || Session["ForceFlag"].ToString().Equals("Y"))
        {
            
            // During Market time   
            initailExcel();

            //openExcel1();
            initailExcel();
            if(Session["ForceFlag"].ToString().Equals("Y"))
            {
                //openExcelDelta();
                //initailExcel();
                //openExcelBuy();
                //initailExcel();
                //openExcelSell();
                
            }
           
            //initailExcel();

            //openExcel5();
         

        }



        if ( Convert.ToInt32(today_HH) == 08)
        {
            //initailExcel();

            //openExcel3();

            //initailExcel();
            //openExcelDelta();
            //initailExcel();
            //openExcelBuy();
            //initailExcel();
            //openExcelSell();
            //openExcel4();

        }
        //if(1==1)
        if (Convert.ToInt32(today_HH) == 17)
        {
           
            //initailExcel();
            //openExcelBuy();
            //initailExcel();
            //openExcelSell();

        }


        //if(1==1)
        if (Convert.ToInt32(today_HH)==17)
        {
            //initailExcel();

            //openExcel();
            //initailExcel();

            //openExcelDelta();
          

        }
        if (Convert.ToInt32(today_DD) == 4 && Convert.ToInt32(today_HH) == 18)
        {
            initailExcel();

            openExcel2();
        }

       
       
        try
        {
            foreach (Process proc in Process.GetProcessesByName("EXCEL"))
            {
                proc.Kill();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }



    }

    public void initailExcel()
    {
        //檢查PC有無Excel在執行
        bool flag = false;


        foreach (Process clsProcess in Process.GetProcesses())
        {
            if (clsProcess.ProcessName == "EXCEL")
            {
                flag = true;
                break;
            }
        }

        if (!flag)
        {
            this._Excel = new Excel1.Application();
        }
        else
        {
            object obj = Marshal.GetActiveObject("Excel.Application");//引用已在執行的Excel
            _Excel = obj as Excel1.Application;
        }

        this._Excel.Visible = false;//設false效能會比較好
    }



   

    public void openExcel()
    {
        member oscar = new member();

        ArrayList maillist = func.FileToArray(Server.MapPath("..\\") + "\\..\\maillist\\fund_price.txt");
        oscar.title = " 配息基金Ranking<分析>快遞【" + today_yyyymmdd + "】";

        oscar.strHTML = "Oscar Group 投資的路上 平安喜樂";
        oscar.mail_list = maillist[1].ToString();


        oscar.today_detail = DateTime.Now.AddDays(+0).ToString("yyyyMMddHHmmss");
        oscar.file_from = Server.MapPath(".") + "\\TAIWAN_BANK_OutSite_Salary_FA.xls";
        //oscar.file_from = @"C:\\TAIWAN_BANK_OutSite_Salary_FA_20160111.xls";
        oscar.save_to = Server.MapPath("..\\") + "..\\File\\" +  oscar.today_detail + ".jpg";
        //oscar.save_to = @"c:\\" + today_detail+".jpg";

        Excel1.Workbook book = null;
        Excel1.Worksheet sheet = null;


        string MapPath = Server.MapPath(".");
        //string path = MapPath + @"\T2Cell_Noon_20150722171337.xls";
        string path = oscar.file_from;
        try
        {
            book = this.ExcelWorkbookOpen(path);//開啟Excel檔


            book.Save();

            //string QQ = _Excel.Version.ToString();




            sheet = (Excel1.Worksheet)book.Sheets[1];//轉換的Sheet


            System.Drawing.Image a = this.SheetToImage(sheet, "A1", "M88");//Sheet轉圖檔
            a.Save(oscar.save_to, System.Drawing.Imaging.ImageFormat.Jpeg);//儲存圖檔
            //a.Save(MapPath + @"\20160112_QOO.Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);//儲存圖檔
            func.SendEmail("vsoscar@ms26.url.com.tw", oscar.mail_list , oscar.title, oscar.strHTML, "", Server.MapPath("..\\..\\") + "\\File\\" + oscar.today_detail + ".jpg");//

        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());

        }
        finally
        {

            book = null;
            sheet = null;
            //releaseObject(book);
            //releaseObject(sheet);
            //releaseObject(_Excel);


        }

     


    }


    public void openExcel1()
    {
        member oscar = new member();

        oscar.title = " 台指選<分析>快遞【" + today_yyyymmdd + "】";

        oscar.strHTML = "Oscar Group 投資的路上 平安喜樂";
        oscar.mail_list = "vsoscar0115@gmail.com,alex9tw@gmail.com,aq3283@gmail.com";


        oscar.today_detail = DateTime.Now.AddDays(+0).ToString("yyyyMMddHHmmss");
        oscar.file_from = Server.MapPath(".") + "\\robert_tpo_sample.xls";
        //oscar.file_from = @"C:\\TAIWAN_BANK_OutSite_Salary_FA_20160111.xls";
        oscar.save_to = Server.MapPath("..\\") + "..\\File\\" +  oscar.today_detail + ".jpg";
        //oscar.save_to = @"c:\\" + today_detail+".jpg";

        Excel1.Workbook book = null;
        Excel1.Worksheet sheet = null;


        string MapPath = Server.MapPath(".");
        //string path = MapPath + @"\T2Cell_Noon_20150722171337.xls";
        string path = oscar.file_from;
        try
        {
            book = this.ExcelWorkbookOpen(path);//開啟Excel檔


            book.Save();

            //string QQ = _Excel.Version.ToString();




            sheet = (Excel1.Worksheet)book.Sheets[2];//轉換的Sheet


            System.Drawing.Image a = this.SheetToImage(sheet, "A1", "AK87");//Sheet轉圖檔
            a.Save(oscar.save_to, System.Drawing.Imaging.ImageFormat.Jpeg);//儲存圖檔
            //a.Save(MapPath + @"\20160112_QOO.Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);//儲存圖檔
            func.SendEmail("vsoscar@ms26.url.com.tw", oscar.mail_list, oscar.title, oscar.strHTML, "", Server.MapPath("..\\..\\") + "\\File\\" + oscar.today_detail + ".jpg");//

        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());

        }
        finally
        {

            //book = null;
            //sheet = null;
            //releaseObject(book);
            //releaseObject(sheet);
            //releaseObject(_Excel);


        }



    }
    public void openExcelDelta()
    {
        member oscar = new member();

        oscar.title = " 台指選Delta<分析>快遞【" + today_yyyymmdd + "】";

        oscar.strHTML = "Oscar Group 投資的路上 平安喜樂!!!";
        oscar.mail_list = "vsoscar0115@gmail.com,alex9tw@gmail.com,aq3283@gmail.com";


        oscar.today_detail = DateTime.Now.AddDays(+0).ToString("yyyyMMddHHmmss");
        oscar.file_from = Server.MapPath(".") + "\\DeltaAnalysis.xls";
        //oscar.file_from = @"C:\\TAIWAN_BANK_OutSite_Salary_FA_20160111.xls";
        oscar.save_to = Server.MapPath("..\\") + "..\\File\\" + oscar.today_detail + ".jpg";
        //oscar.save_to = @"c:\\" + today_detail+".jpg";

        Excel1.Workbook book = null;
        Excel1.Worksheet sheet = null;


        string MapPath = Server.MapPath(".");
        //string path = MapPath + @"\T2Cell_Noon_20150722171337.xls";
        string path = oscar.file_from;
        try
        {
            book = this.ExcelWorkbookOpen(path);//開啟Excel檔


            book.Save();

            //string QQ = _Excel.Version.ToString();




            sheet = (Excel1.Worksheet)book.Sheets[1];//轉換的Sheet


            System.Drawing.Image a = this.SheetToImage(sheet, "B1", "Q330");//Sheet轉圖檔
            a.Save(oscar.save_to, System.Drawing.Imaging.ImageFormat.Jpeg);//儲存圖檔
            //a.Save(MapPath + @"\20160112_QOO.Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);//儲存圖檔
            func.SendEmail("vsoscar@ms26.url.com.tw", oscar.mail_list, oscar.title, oscar.strHTML, "", Server.MapPath("..\\..\\") + "\\File\\" + oscar.today_detail + ".jpg");//

        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());

        }
        finally
        {

            //book = null;
            //sheet = null;
            //releaseObject(book);
            //releaseObject(sheet);
            //releaseObject(_Excel);


        }



    }

    public void openExcelBuy()
    {
        member oscar = new member();

        oscar.title = " 台指選籌碼未平倉<買權>快遞【" + today_yyyymmdd + "】";

        oscar.strHTML = "Oscar Group 投資的路上 平安喜樂!!!";
        oscar.mail_list = "vsoscar0115@gmail.com,alex9tw@gmail.com,aq3283@gmail.com";


        oscar.today_detail = DateTime.Now.AddDays(+0).ToString("yyyyMMddHHmmss");
        oscar.file_from = Server.MapPath(".") + "\\買賣權分析.xls";
        //oscar.file_from = @"C:\\TAIWAN_BANK_OutSite_Salary_FA_20160111.xls";
        oscar.save_to = Server.MapPath("..\\") + "..\\File\\" + oscar.today_detail + ".jpg";
        //oscar.save_to = @"c:\\" + today_detail+".jpg";

        Excel1.Workbook book = null;
        Excel1.Worksheet sheet = null;


        string MapPath = Server.MapPath(".");
        //string path = MapPath + @"\T2Cell_Noon_20150722171337.xls";
        string path = oscar.file_from;
        try
        {
            book = this.ExcelWorkbookOpen(path);//開啟Excel檔


            book.Save();

            //string QQ = _Excel.Version.ToString();




            sheet = (Excel1.Worksheet)book.Sheets[2];//轉換的Sheet


            System.Drawing.Image a = this.SheetToImage(sheet, "A1", "O50");//Sheet轉圖檔
            a.Save(oscar.save_to, System.Drawing.Imaging.ImageFormat.Jpeg);//儲存圖檔
            //a.Save(MapPath + @"\20160112_QOO.Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);//儲存圖檔
            func.SendEmail("vsoscar@ms26.url.com.tw", oscar.mail_list, oscar.title, oscar.strHTML, "", Server.MapPath("..\\..\\") + "\\File\\" + oscar.today_detail + ".jpg");//

        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());

        }
        finally
        {

            //book = null;
            //sheet = null;
            //releaseObject(book);
            //releaseObject(sheet);
            //releaseObject(_Excel);


        }



    }
    public void openExcelSell()
    {
        member oscar = new member();

        oscar.title = " 台指選籌碼未平倉<賣權>快遞【" + today_yyyymmdd + "】";

        oscar.strHTML = "Oscar Group 投資的路上 平安喜樂!!!";
        oscar.mail_list = "vsoscar0115@gmail.com,alex9tw@gmail.com,aq3283@gmail.com";


        oscar.today_detail = DateTime.Now.AddDays(+0).ToString("yyyyMMddHHmmss");
        oscar.file_from = Server.MapPath(".") + "\\買賣權分析.xls";
        //oscar.file_from = @"C:\\TAIWAN_BANK_OutSite_Salary_FA_20160111.xls";
        oscar.save_to = Server.MapPath("..\\") + "..\\File\\" + oscar.today_detail + ".jpg";
        //oscar.save_to = @"c:\\" + today_detail+".jpg";

        Excel1.Workbook book = null;
        Excel1.Worksheet sheet = null;


        string MapPath = Server.MapPath(".");
        //string path = MapPath + @"\T2Cell_Noon_20150722171337.xls";
        string path = oscar.file_from;
        try
        {
            book = this.ExcelWorkbookOpen(path);//開啟Excel檔


            book.Save();

            //string QQ = _Excel.Version.ToString();




            sheet = (Excel1.Worksheet)book.Sheets[3];//轉換的Sheet


            System.Drawing.Image a = this.SheetToImage(sheet, "A1", "O50");//Sheet轉圖檔
            a.Save(oscar.save_to, System.Drawing.Imaging.ImageFormat.Jpeg);//儲存圖檔
            //a.Save(MapPath + @"\20160112_QOO.Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);//儲存圖檔
            func.SendEmail("vsoscar@ms26.url.com.tw", oscar.mail_list, oscar.title, oscar.strHTML, "", Server.MapPath("..\\..\\") + "\\File\\" + oscar.today_detail + ".jpg");//

        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());

        }
        finally
        {

            //book = null;
            //sheet = null;
            //releaseObject(book);
            //releaseObject(sheet);
            //releaseObject(_Excel);


        }



    }
    public void openExcel3()
    {
        member oscar = new member();

        oscar.title = " 台指選盤後<週分析>快遞【" + today_yyyymmdd + "】";

        oscar.strHTML = "Oscar Group 投資的路上 平安喜樂";
        oscar.mail_list = "vsoscar0115@gmail.com,alex9tw@gmail.com,aq3283@gmail.com";


        oscar.today_detail = DateTime.Now.AddDays(+0).ToString("yyyyMMddHHmmss");
        oscar.file_from = Server.MapPath(".") + "\\OPTION_WEEK_MONTH_20160327.xls";
        //oscar.file_from = @"C:\\TAIWAN_BANK_OutSite_Salary_FA_20160111.xls";
        oscar.save_to = Server.MapPath("..\\") + "..\\File\\" + oscar.today_detail + ".jpg";
        //oscar.save_to = @"c:\\" + today_detail+".jpg";

        Excel1.Workbook book = null;
        Excel1.Worksheet sheet = null;


        string MapPath = Server.MapPath(".");
        //string path = MapPath + @"\T2Cell_Noon_20150722171337.xls";
        string path = oscar.file_from;
        try
        {
            book = this.ExcelWorkbookOpen(path);//開啟Excel檔


            book.Save();

            //string QQ = _Excel.Version.ToString();




            sheet = (Excel1.Worksheet)book.Sheets[1];//轉換的Sheet


            System.Drawing.Image a = this.SheetToImage(sheet, "A1", "M30");//Sheet轉圖檔
            a.Save(oscar.save_to, System.Drawing.Imaging.ImageFormat.Jpeg);//儲存圖檔
            //a.Save(MapPath + @"\20160112_QOO.Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);//儲存圖檔
            func.SendEmail("vsoscar@ms26.url.com.tw", oscar.mail_list, oscar.title, oscar.strHTML, "", Server.MapPath("..\\..\\") + "\\File\\" + oscar.today_detail + ".jpg");//

        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());

        }
        finally
        {

            //book = null;
            //sheet = null;
            //releaseObject(book);
            //releaseObject(sheet);
            //releaseObject(_Excel);


        }



    }
    public void openExcel4()
    {
        member oscar = new member();

        oscar.title = " 台指選盤後<月分析>快遞【" + today_yyyymmdd + "】";

        oscar.strHTML = "Oscar Group 投資的路上 平安喜樂";
        oscar.mail_list = "vsoscar0115@gmail.com,alex9tw@gmail.com,aq3283@gmail.com";


        oscar.today_detail = DateTime.Now.AddDays(+0).ToString("yyyyMMddHHmmss");
        oscar.file_from = Server.MapPath(".") + "\\OPTION_WEEK_MONTH_20160327.xls";
        //oscar.file_from = @"C:\\TAIWAN_BANK_OutSite_Salary_FA_20160111.xls";
        oscar.save_to = Server.MapPath("..\\") + "..\\File\\" + oscar.today_detail + ".jpg";
        //oscar.save_to = @"c:\\" + today_detail+".jpg";

        Excel1.Workbook book = null;
        Excel1.Worksheet sheet = null;


        string MapPath = Server.MapPath(".");
        //string path = MapPath + @"\T2Cell_Noon_20150722171337.xls";
        string path = oscar.file_from;
        try
        {
            book = this.ExcelWorkbookOpen(path);//開啟Excel檔


            book.Save();

            //string QQ = _Excel.Version.ToString();




            sheet = (Excel1.Worksheet)book.Sheets[2];//轉換的Sheet


            System.Drawing.Image a = this.SheetToImage(sheet, "A1", "M50");//Sheet轉圖檔
            a.Save(oscar.save_to, System.Drawing.Imaging.ImageFormat.Jpeg);//儲存圖檔
            //a.Save(MapPath + @"\20160112_QOO.Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);//儲存圖檔
            func.SendEmail("vsoscar@ms26.url.com.tw", oscar.mail_list, oscar.title, oscar.strHTML, "", Server.MapPath("..\\..\\") + "\\File\\" + oscar.today_detail + ".jpg");//

        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());

        }
        finally
        {

            //book = null;
            //sheet = null;
            //releaseObject(book);
            //releaseObject(sheet);
            //releaseObject(_Excel);


        }



    }
    public void openExcel5()
    {
        member oscar = new member();

        oscar.title = " 台指選<週分析>快遞【" + today_yyyymmdd + "】";

        oscar.strHTML = "Oscar Group 投資的路上 平安喜樂";
        oscar.mail_list = "vsoscar0115@gmail.com,alex9tw@gmail.com,aq3283@gmail.com";


        oscar.today_detail = DateTime.Now.AddDays(+0).ToString("yyyyMMddHHmmss");
        oscar.file_from = Server.MapPath(".") + "\\WEEK_DATA_SAMPLE.xls";
        //oscar.file_from = Server.MapPath(".") + "\\MONTH_DATA_SAMPLE.xls";
        //oscar.file_from = @"C:\\TAIWAN_BANK_OutSite_Salary_FA_20160111.xls";
        oscar.save_to = Server.MapPath("..\\") + "..\\File\\" + oscar.today_detail + ".jpg";
        //oscar.save_to = @"c:\\" + today_detail+".jpg";

        Excel1.Workbook book = null;
        Excel1.Worksheet sheet = null;


        string MapPath = Server.MapPath(".");
        //string path = MapPath + @"\T2Cell_Noon_20150722171337.xls";
        string path = oscar.file_from;
        try
        {
            book = this.ExcelWorkbookOpen(path);//開啟Excel檔


            book.Save();

            //string QQ = _Excel.Version.ToString();




            sheet = (Excel1.Worksheet)book.Sheets[1];//轉換的Sheet


            System.Drawing.Image a = this.SheetToImage(sheet, "A4", "X82");//Sheet轉圖檔
            a.Save(oscar.save_to, System.Drawing.Imaging.ImageFormat.Jpeg);//儲存圖檔
            //a.Save(MapPath + @"\20160112_QOO.Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);//儲存圖檔
            func.SendEmail("vsoscar@ms26.url.com.tw", oscar.mail_list, oscar.title, oscar.strHTML, "", Server.MapPath("..\\..\\") + "\\File\\" + oscar.today_detail + ".jpg");//

        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());

        }
        finally
        {

            //book = null;
            //sheet = null;
            //releaseObject(book);
            //releaseObject(sheet);
            //releaseObject(_Excel);


        }



    }


    public void openExcel2()
    {
        member oscar = new member();

        oscar.title = " 安聯配息率<分析>快遞【" + today_yyyymmdd + "】";

        oscar.strHTML = "Oscar Group 投資的路上 平安喜樂";
        oscar.mail_list = "vsoscar0115@gmail.com,alex9tw@gmail.com,kiken46@msn.com,k78132@gmail.com,oftens.liang@gmail.com,sarahkevinshieh@gmail.com";


        oscar.today_detail = DateTime.Now.AddDays(+0).ToString("yyyyMMddHHmmss");
        oscar.file_from = Server.MapPath(".") + "\\alianz_analysis.xls";
        //oscar.file_from = @"C:\\TAIWAN_BANK_OutSite_Salary_FA_20160111.xls";
        oscar.save_to = Server.MapPath("..\\") + "..\\File\\" + oscar.today_detail + ".jpg";
        //oscar.save_to = @"c:\\" + today_detail+".jpg";

        Excel1.Workbook book = null;
        Excel1.Worksheet sheet = null;


        string MapPath = Server.MapPath(".");
        //string path = MapPath + @"\T2Cell_Noon_20150722171337.xls";
        string path = oscar.file_from;
        try
        {
            book = this.ExcelWorkbookOpen(path);//開啟Excel檔


            book.Save();

            //string QQ = _Excel.Version.ToString();




            sheet = (Excel1.Worksheet)book.Sheets[1];//轉換的Sheet


            System.Drawing.Image a = this.SheetToImage(sheet, "A1", "J27");//Sheet轉圖檔
            a.Save(oscar.save_to, System.Drawing.Imaging.ImageFormat.Jpeg);//儲存圖檔
            //a.Save(MapPath + @"\20160112_QOO.Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);//儲存圖檔
            func.SendEmail("vsoscar@ms26.url.com.tw", oscar.mail_list, oscar.title, oscar.strHTML, "", Server.MapPath("..\\..\\") + "\\File\\" + oscar.today_detail + ".jpg");//

        }
        catch (Exception ex)
        {
            Response.Write(ex.ToString());

        }
        finally
        {

            //book = null;
            //sheet = null;
            //releaseObject(book);
            //releaseObject(sheet);
            //releaseObject(_Excel);


        }



    }

    /// <summary>
    /// 將Excel的Sheet轉成Image
    /// </summary>
    /// <param name="sheet">工作表</param>
    /// <param name="inFrom">起始位子</param>
    /// <param name="inTo">結束位子</param>
    /// <returns></returns>
    private System.Drawing.Image SheetToImage(Excel1.Worksheet sheet, string inFrom, string inTo)
    {
        Excel1.Range range = null;
        System.Drawing.Image ToImage = null;

        try
        {

            range = sheet.get_Range(inFrom, inTo);

            range.CopyPicture(Excel1.XlPictureAppearance.xlScreen, Excel1.XlCopyPictureFormat.xlBitmap);

            ToImage = System.Windows.Forms.Clipboard.GetImage();


            _Excel = null;

        }
        catch (Exception ex)
        {
            //throw new System.Exception(ex.Message.ToString());

        }
        finally
        {
            System.Windows.Forms.Clipboard.Clear();
        }

        return ToImage;
    }



    /// <summary>
    /// 開啟Excel
    /// </summary>
    /// <param name="inPath">路徑</param>
    /// <returns></returns>
    private Excel1.Workbook ExcelWorkbookOpen(string inPath)
    {

        return _Excel.Workbooks.Open(inPath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    }


    public class member
    {
        private string _file_from;
        public string file_from
        {
            set { _file_from = value; }
            get { return _file_from; }
        }

        private string _save_to;
        public string save_to
        {
            set { _save_to = value; }
            get { return _save_to; }
        }


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

    private void releaseObject(object obj)
    {
        try
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            obj = null;
        }
        catch (Exception ex)
        {
            obj = null;
            MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
        }
        finally
        {
            GC.Collect();
        }
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


    public class GetData
    {
        // Field
        public string name;
        public string flag;
        // Constructor that takes no arguments.
        public GetData()
        {
            name = "unknown";
        }

        // Constructor that takes one argument.
        public GetData(string nm)
        {
            name = nm;
        }

        // Method
        public void GetWeekDayFlag()
        {
            Int32 WeekDay=0;

            int weeknow = 0;
            
            //name = newName;
            string date1 = DateTime.Now.AddDays(+0).ToString("yyyyMMdd");

            string date2 = DateTime.Now.AddDays(+0).ToString("yyyyMM")+"01";
            DateTime dt1 = Convert.ToDateTime(date1);
            DateTime dt2 = Convert.ToDateTime(date2);

            TimeSpan difftime = dt1.Subtract(dt2); //日期相減
            // Get Month Week
            // Delete zero point
            WeekDay = Convert.ToInt32(Math.Floor(Convert.ToDouble(difftime.Days.ToString()) / 7)) + 1;

            // Getvweek

            weeknow = Convert.ToInt32(dt1.DayOfWeek);//今天星期几 

 

        }
    }

}
