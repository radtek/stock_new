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
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;



public partial class Default8 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //func.start_processdelete("net use z: \\192.168.1.22\report 1234 /USER:192.168.1.22\administrator "); 

       
        //DirectoryInfo dir = new DirectoryInfo( Server.MapPath("..\\mynb"));

        //DirectoryInfo dir = new DirectoryInfo(@"z:");
        Microsoft.VisualBasic.Devices.Network Network = new Microsoft.VisualBasic.Devices.Network();

        string fileName = "";
        fileName = "A.txt";
        string sourcefile = @"\\192.168.1.22\report\" + fileName;
        string destinationfile = Server.MapPath(".") + "\\RUN_LOG\\" + fileName;
        try
        {
            Network.DownloadFile(sourcefile, destinationfile, "Administrator", "12345678", false, 100, true);

        }
        catch (Exception)
        {
            
            throw;
        }


        //DirectoryInfo dir = new DirectoryInfo(@"\\192.168.1.22\\report");

        //FileInfo[] files = dir.GetFiles("*.xls");

        //double dayAgo = -360;

        //string fileName = "";
        //for (int i = 0; i <= files.Length - 1; i++)
        //{


        //    if (files[i].CreationTime > DateTime.Now.AddDays(dayAgo))
        //    {
        //        //string sourceFile = System.IO.Path.Combine(@"z:", files[i].Name);
        //        string sourceFile = System.IO.Path.Combine(@"\\192.168.1.22\\report", files[i].Name);
        //        string destFile = System.IO.Path.Combine(Server.MapPath(".") + "\\RUN_LOG\\", files[i].Name);

        //        //files[i].CopyTo(Server.MapPath(".")+"\\File\\"); 

        //        //fileName = files[i].Name; 
        //        //File.Copy(files[i].Name, Server.MapPath(".") + "\\File\\" + fileName, true); 
        //        System.IO.File.Copy(sourceFile, destFile, true);

        //    }






        //}
    }
}