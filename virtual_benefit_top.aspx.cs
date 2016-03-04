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

public partial class virtual_benefit_top : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (Request.QueryString["page"].ToString() == "1")
            {
                GridView1.AllowPaging = false;
                BindGridView();

            }


        }
        catch (Exception)
        {


            BindGridView();
        }








    }

    public void BindGridView()
    {
        string sql_cnn = System.Configuration.ConfigurationSettings.AppSettings["jump"];
        string sql_str = @"SELECT t.user_id, format(t.dttm,'yyyy/MM') AS yyyyMM, sum(t.benefit) AS benefit 
 FROM virtual_current_buy_his AS t                                               
 WHERE t.finished='T'                                                            
 GROUP BY t.user_id, format(t.dttm,'yyyy/MM')                                    
 ORDER BY format(t.dttm,'yyyy/MM') DESC , sum(t.benefit) DESC "; 
        DataSet myDataSet123 = new DataSet();


        //DATEADD(day, 1, @CountDate)  

        myDataSet123 = func.get_dataSet_access(sql_str, sql_cnn);

        GridView1.DataSource = myDataSet123.Tables["AccessInfo"].DefaultView;
        GridView1.DataBind();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindGridView();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = id.ToString();
            }

            //string[] date1 = { DateTime.Now.AddDays(-4).ToString("yyyy/MM/dd"), DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd"), DateTime.Now.AddDays(-2).ToString("yyyy/MM/dd"), DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd"), DateTime.Now.AddDays(-0).ToString("yyyy/MM/dd") };


            //for (int ii = 0; ii <= date1.Length - 1; ii++)
            //{
            //    if (e.Row.Cells[1].Text == date1[ii])
            //    {
            //        //((TextBox)e.Row.FindControl("T1CellTest")).Text = Convert.ToDouble(((TextBox)e.Row.FindControl("T1CellTest"))).ToString("P1"); ; 

            //        //e.Row.Cells[5].Text = Convert.ToDouble(e.Row.Cells[5].Text).ToString("N1"); 

            //        for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
            //        {
            //            e.Row.Cells[2].Style.Add("background-color", "#C4C4FF");
            //            //e.Row.Cells[2].BackColor = Color.FromName("#C4C4FF");

            //        }
            //    }

            //}



            //// 新增 成交量大於10000張以上 呈現顏色 20100116
            //Int32 standard_volume = Convert.ToInt32(e.Row.Cells[6].Text);
            //if (standard_volume > 10000)
            //{
            //    e.Row.Cells[6].Style.Add("background-color", "#FAADA9");
            //    //e.Row.Cells[2].BackColor = Color.FromName("#C4C4FF");

            //}





        }




    }
}
