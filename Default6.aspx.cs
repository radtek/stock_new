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
using System.Diagnostics;
using System.ServiceProcess;

public partial class Default6 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Int32 receiveday = 0;
        Int32 receiveweeknow = 0;

       //Process[] arrayProcess = Process.GetProcesses();

       // Response.Write(arrayProcess[0].MainModule.ModuleName);
        GetData GetData_c = new GetData();

        GetData_c.GetWeekDayFlag();
       
        Response.Write(GetData_c.WeekDay);
        Response.Write(GetData_c.Weeknow);



    }

    public class GetData
    {
        // Field
        public string name;
        public string flag;
        public Int32 WeekDay;
        public Int32 Weeknow;

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
            

            //name = newName;
            string date1 = DateTime.Now.AddDays(+0).ToString("yyyy-MM-dd");

            string date2 = DateTime.Now.AddDays(+0).ToString("yyyy-MM") + "-01";
            DateTime dt1 = Convert.ToDateTime(date1);
            DateTime dt2 = Convert.ToDateTime(date2);

            TimeSpan difftime = dt1.Subtract(dt2); //日期相減
            // Get Month Week
            // Delete zero point
            WeekDay = Convert.ToInt32(Math.Floor(Convert.ToDouble(difftime.Days.ToString()) / 7)) + 1;

            // Getvweek

            Weeknow = Convert.ToInt32(dt1.DayOfWeek);//今天星期几 



        }
    }

}
