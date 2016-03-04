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
using System.Xml;
using System.IO;

public partial class Create_xml : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StreamWriter sw;
        DirectoryInfo di;//宣告目錄 
        FileInfo fi;//宣告檔案 
        //string program_name1 = program_name;
        string file_type = "xml";
        string file_path = Server.MapPath(".") + "\\File\\" + DateTime.Now.ToString("yyyyMMdd") + "\\";
        //di = new DirectoryInfo(Server.MapPath(".") + "\\RUN_LOG\\" ); //DateTime.Now.ToString("yyyyMMdd") 
        di = new DirectoryInfo(file_path); //DateTime.Now.ToString("yyyyMMdd") 
        //fi = new FileInfo(Server.MapPath(".") + "\\RUN_LOG\\" + DateTime.Now.ToString("yyyyMMdd") + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".log");
        fi = new FileInfo(file_path + DateTime.Now.ToString("yyyyMMddHHmmss") + "." + file_type);
        string SaveLocation = file_path + DateTime.Now.ToString("yyyyMMddHHmmss") + "." + file_type;
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

        sw.Close();
        sw.Dispose();
        XmlDocument doc = new XmlDocument();
        //doc.LoadXml(Server.MapPath(".") + "\\ALCS_SAMPLE\\AlarmTestXML.xml"); 
        doc.LoadXml(@"<?xml version=""1.0"" encoding=""big5""?> 
<transaction> 
<trx_id>AUTOREPORT</trx_id> 
<type_id>I</type_id> 
<fab_id>T1ARRAY</fab_id> 
<sys_type>ALM_SMS</sys_type> 
<eq_id>SMS</eq_id> 
<alarm_id>67</alarm_id> 
<alarm_text>Alarm test AA</alarm_text> 
<mail_contenttype>Alarm 測試</mail_contenttype> 
<alarm_comment value=""Alarm 測試""/> 
<pc_ip>1</pc_ip> 
<pc_name>1</pc_name> 
<operator>1</operator> 
<issue_date>2012-06-19 11:00:53</issue_date> 
</transaction>");
        //doc.SelectSingleNode("//fab_id").NodeType= 
        doc.SelectSingleNode("//fab_id").ChildNodes[0].InnerText = "T1ARRAY";
        doc.SelectSingleNode("//sys_type").ChildNodes[0].InnerText = "OOS";
        doc.SelectSingleNode("//eq_id").ChildNodes[0].InnerText = "CIM";
        doc.SelectSingleNode("//alarm_id").ChildNodes[0].InnerText = "911";
        //doc.selectSingleNode("//issue_date").nodeTypedValue = rvreceivetime; 
        //doc.selectSingleNode("//alarm_text").nodeTypedValue = phone; 
        //doc.selectSingleNode("//mail_contenttype").nodeTypedValue = MAIL; 
        doc.SelectSingleNode("//alarm_text").ChildNodes[0].InnerText = "就是測試";
        doc.SelectSingleNode("//alarm_comment").Attributes.GetNamedItem("value").InnerText = "就是測試alarm_comment"; 
        //Save the document to a file. 


        doc.Save(SaveLocation);
        func.delete_log_dir(Server.MapPath(".") + "\\File\\", "*.xls", -1);
        string frmClose = @"<script language='javascript' type='text/JavaScript'> 

window.opener=null; 
window.open('','_self'); 
window.close(); 
</script>"; 

//呼叫 javascript 
this.Page.RegisterStartupScript("", frmClose); 



    }
}
