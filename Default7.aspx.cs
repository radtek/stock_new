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

public partial class Default7 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string[] selest_value ={ "item1", "item2", "item3", "item4" };

            for (int i = 0; i <= selest_value.Length - 1; i++)
            {
                ListMulti1.Items.Add(new ListItem(selest_value[i], selest_value[i]));
            }

            //ListMulti1.Items.Add(new ListItem("item1", "item1"));
            //ListMulti1.Items.Add(new ListItem("item2", "item2"));
            //ListMulti1.Items.Add(new ListItem("item3", "item3"));
            //ListMulti1.Items.Add(new ListItem("item4", "item4"));
            //ListMulti1.Items.Add(new ListItem("item5", "item5"));
            //ListMulti1.Items.Add(new ListItem("item6", "item6"));
           
        }

        Response.Write(ListMulti1.Text);
        
    }
}
