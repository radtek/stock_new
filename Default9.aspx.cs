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

public partial class Default9 : System.Web.UI.Page
{

    string conn = System.Configuration.ConfigurationSettings.AppSettings["jump"];
    string today = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd");
    string today_detail = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd HH:mm");

    string sql_temp = "";
    string sql_temp1 = "";
    string sql_temp2 = "";
    string sql_temp3 = "";
    string mail_list = "";
    DataSet ds_temp = new DataSet();
    DataSet ds_temp1 = new DataSet();
    ArrayList al_temp1 = new ArrayList();

    
    protected void Page_Load(object sender, EventArgs e)
    {
     
        sql_temp = "select string1 from hw2_top50";

        ds_temp=func.get_dataSet_access(sql_temp, conn);

        GridView1.DataSource = ds_temp;
        GridView1.DataBind();

        al_temp1=func.FileToArray(Server.MapPath(".\\") + "\\count_outputs\\1.txt");

        Int32 counter = 0;
        for (int i = 0; i <= ds_temp.Tables[0].Rows.Count-1; i++)
        {
           
            for (int j = 0; j <= al_temp1.Count-1; j++)
            {
                
                if (al_temp1[j].ToString().IndexOf(ds_temp.Tables[0].Rows[i][0].ToString())>0)
                {
                    
                    if (counter <= 0)
                    {
                        sql_temp2 = al_temp1[j].ToString()+"_"+i.ToString()+"_"+j.ToString();
                        counter++;
                    }
                    else 
                    {
                        sql_temp2 = sql_temp2 + "," + al_temp1[j].ToString() +"_"+i.ToString() + "_" + j.ToString();
                        counter++;
                    
                    }

                    
                
                }
            }

        }

        Label1.Text = sql_temp2;







    }
}
