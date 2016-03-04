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

public partial class Stock_strong_volume1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            if (Request.QueryString["page"].ToString() == "1")
            {
                GridView1.AllowPaging = false;
                BindGridView();
                BindGridView2();

            }


        }
        catch (Exception)
        {


            BindGridView();
            BindGridView2();
        }








    }

    public void BindGridView()
    {
        string sql_cnn = System.Configuration.ConfigurationSettings.AppSettings["jump"];
        string sql_str = " SELECT format(t.dttm,'yyyy/MM/dd') as date1,t.stock_id,Mid ( t.stock_name,5, 5 )as stock_name ,t.price,t.price-t.yesturday_price as up_down ,round((t.price-t.yesturday_price)/t.yesturday_price,4)*100 &'%' as K_percentage,t.yesturday_price,t.volume,round(t.price*1.0691,2) as top_price, round(round((t.price-t.yesturday_price)/t.yesturday_price,4)*t.volume,0) as kpi,round(((price-low_price)-(top_price-price)),2) as turtle " +
" FROM strong_up_myself t                                                                                                                                                                                                                                                                      " +
" where  format(t.dttm,'yyyy/MM/dd')>=format(now()-1,'YYYY/MM/DD')                                                                                                                                                                                                                             " +
" and t.volume>=8000   order by format(t.dttm,'yyyy/MM/dd') desc,round(t.volume*(t.price-t.yesturday_price)/t.yesturday_price,0) desc                                                                                                                                                                                                                                                                         ";
        DataSet myDataSet123 = new DataSet();


        //DATEADD(day, 1, @CountDate)  

        myDataSet123 = func.get_dataSet_access(sql_str, sql_cnn);

        GridView1.DataSource = myDataSet123.Tables["AccessInfo"].DefaultView;
        GridView1.DataBind();
    }

    public void BindGridView2()
    {
        string sql_cnn = System.Configuration.ConfigurationSettings.AppSettings["jump"];
        string sql_str = @" select format(t.date1,'yyyy/MM/dd')as date1,t.stock_id,t.volume1,t.stock_name,t.price1,t.percent1  &'%' as K_percentage ,t.hot_price,t.kpi,turtle
from strong_up_history t
where t.kpi>1500  and format(t.date1,'yyyy/MM/dd')>=format(now()-30,'YYYY/MM/DD')   order by format(t.date1,'yyyy/MM/dd') desc,turtle desc  ";
        DataSet myDataSet123 = new DataSet();

        myDataSet123 = func.get_dataSet_access(sql_str, sql_cnn);

        //DATEADD(day, 1, @CountDate)  
        DataTable fill_data = new DataTable();

        fill_data = func.add_column(myDataSet123, "Current_price");

        // filded data//
        for (int i = 0; i <= fill_data.Rows.Count - 1; i++)
        {
            fill_data.Rows[i]["Current_price"] = func.Check_function(fill_data.Rows[i]["Stock_id"].ToString());
        }





        fill_data = func.Table_add_column(fill_data, "Current_volume");

        for (int i = 0; i <= fill_data.Rows.Count - 1; i++)
        {
            fill_data.Rows[i]["Current_volume"] = func.Check_function_volume(fill_data.Rows[i]["Stock_id"].ToString());
        }

        fill_data = func.Table_add_column(fill_data, "diff");
        for (int i = 0; i <= fill_data.Rows.Count - 1; i++)
        {

            if (fill_data.Rows[i]["Current_price"].ToString().Equals("－"))
            {
                fill_data.Rows[i]["Current_price"] = "0";
            }
            
            
            fill_data.Rows[i]["diff"] = Convert.ToString(Math.Round(Convert.ToDouble(fill_data.Rows[i]["Current_price"].ToString()) - Convert.ToDouble(fill_data.Rows[i]["price1"].ToString()), 2));
        }
        fill_data = func.Table_add_column(fill_data, "diff_p");
        for (int i = 0; i <= fill_data.Rows.Count - 1; i++)
        {
            fill_data.Rows[i]["diff_p"] = Convert.ToString(Math.Round(Convert.ToDouble(fill_data.Rows[i]["diff"].ToString()) / Convert.ToDouble(fill_data.Rows[i]["price1"].ToString()) * 100, 2)) + "%";
        }



        GridView2.DataSource = fill_data;
        GridView2.DataBind();
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

            string[] date1 = { DateTime.Now.AddDays(-4).ToString("yyyy/MM/dd"), DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd"), DateTime.Now.AddDays(-2).ToString("yyyy/MM/dd"), DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd"), DateTime.Now.AddDays(-0).ToString("yyyy/MM/dd") };


            for (int ii = 0; ii <= date1.Length - 1; ii++)
            {
                if (e.Row.Cells[1].Text == date1[ii])
                {
                    //((TextBox)e.Row.FindControl("T1CellTest")).Text = Convert.ToDouble(((TextBox)e.Row.FindControl("T1CellTest"))).ToString("P1"); ; 

                    //e.Row.Cells[5].Text = Convert.ToDouble(e.Row.Cells[5].Text).ToString("N1"); 

                    for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
                    {
                        e.Row.Cells[2].Style.Add("background-color", "#C4C4FF");
                        //e.Row.Cells[2].BackColor = Color.FromName("#C4C4FF");

                    }
                }

            }



            // 新增 成交量大於10000張以上 呈現顏色 20100116
            Int32 standard_volume = Convert.ToInt32(e.Row.Cells[6].Text);
            if (standard_volume > 10000)
            {
                e.Row.Cells[6].Style.Add("background-color", "#FAADA9");
                //e.Row.Cells[2].BackColor = Color.FromName("#C4C4FF");

            }

            Double turtle_value = Convert.ToDouble(e.Row.Cells[10].Text);
            if (turtle_value > 0)
            {
                e.Row.Cells[10].Style.Add("background-color", "#FFFF80");
                //e.Row.Cells[2].BackColor = Color.FromName("#C4C4FF");

            }





        }




    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
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



            // 新增 now_price<topprice 呈現顏色 20100116
            double top_price = Convert.ToDouble(e.Row.Cells[4].Text);
            double now_price = Convert.ToDouble(e.Row.Cells[5].Text);
            if (top_price > now_price)
            {
                e.Row.Cells[5].Style.Add("background-color", "#A2FFA2");
                //e.Row.Cells[2].BackColor = Color.FromName("#C4C4FF");

            }

            Double turtle_value = 0;
            if (!e.Row.Cells[13].Text.Equals("&nbsp;"))
            {

                turtle_value = Convert.ToDouble(e.Row.Cells[13].Text.Equals(""));
            }
            else
            {
                e.Row.Cells[13].Text = turtle_value.ToString();
            
            }
            
            if (turtle_value > 0)
            {
                e.Row.Cells[10].Style.Add("background-color", "#FFFF80");
                //e.Row.Cells[2].BackColor = Color.FromName("#C4C4FF");

            }




        }




    }


}
