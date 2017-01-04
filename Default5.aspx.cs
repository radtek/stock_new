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

public partial class Default5 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        Int32 fix=9;
        Int32 counter = 0;
        for (int i = 0; i <= 10000; i++)
        {
            if (i % fix == 0)
            {
                counter++;
                // Response.Write(i);
              //  Response.Write("<br>");
            
            }
        }
        Response.Write(counter);
    }
}
