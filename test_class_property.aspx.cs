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
using System;
using System.Reflection;
public partial class test_class_property : System.Web.UI.Page
{
    


    protected void Page_Load(object sender, EventArgs e)
    {
        func.Customer cus = new func.Customer();

        
        cus.ID = 34;
        cus.Name = "NameXXXXXX";
        cus.tel = "11223344";
        cus.event_id = "oscar3388";
        cus.Fab_id = "T1ARRAY";
        cus.alarm_id = "24";
        cus.event_name = "oscar_test_3481";

        Response.Write("<br>1.");
        Response.Write(cus.ID);
        Response.Write("<br>2.");
         Response.Write(cus.Name);
         Response.Write("<br>3.");
         Response.Write(cus.tel);
         Response.Write("<br>4.");
         Response.Write(cus.event_id);
         Response.Write("<br>5.");
         Response.Write(cus.Fab_id);
         Response.Write("<br>6.");
         Response.Write(cus.alarm_id);
         Response.Write("<br>7.");
         Response.Write(cus.event_name);
       
    }
}
