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
using System.IO;

public partial class stock_list : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["jump"];
    string today = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd");

    string today_minus7 = DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd");
    string today_minus15 = DateTime.Now.AddDays(-15).ToString("yyyy/MM/dd");

    string today_detail = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd HH:mm");
    string sql_temp = "";
    string sql_temp1 = "";
    string sql_temp2 = "";
    string sql_temp3 = "";
    string sql_temp4 = "";
    string sql_temp5 = "";
    string temp_date1 = "";
    string temp_date2 = "";
    string temp_date3 = "";
    string temp_date4 = "";
    
    DataSet ds_temp = new DataSet();
    DataSet ds_temp1 = new DataSet();
     DataSet ds_temp2 = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtCalendar1.Text = today_minus7;
            txtCalendar2.Text = today;

            sql_temp = " select    t2.stock_id,t2.stock_name,count(t2.stock_id) as count1 ,round(avg(price1),2) as price  ,round(avg(volume1),0) as avg_volume ,round(avg(hot_price),2) as avg_hot_price, round(avg( IIf(turtle is null,0, turtle)  ),2) as avg_turtle from ( " +
"                                                                                                                                                                           " +
" SELECT *                                                                                                                                                                  " +
" FROM strong_up_history AS t                                                                                                                                               " +
" WHERE 1=1                                                                                                                                                   ";
            if (!txtCalendar1.Text.Equals(""))
            {
                sql_temp += " and format(t.date1,'yyyy/MM/dd')>='" + txtCalendar1.Text + "'     ";
            }
            if (!txtCalendar2.Text.Equals(""))
            {
                sql_temp += " and format(t.date1,'yyyy/MM/dd')<='" + txtCalendar2.Text + "'     ";
            }
            if (!TextBox3.Text.Equals(""))
            {
                sql_temp += "and t.price1>=" + TextBox3.Text + "     ";
            }
            if (!TextBox2.Text.Equals(""))
            {
                sql_temp += "and t.price1<=" + TextBox2.Text + "     ";
            }
            if (!TextBox4.Text.Equals(""))
            {
                sql_temp += "and t.volume1>=" + TextBox4.Text + "     ";
            }

            if (!TextBox1.Text.Equals(""))
            {
                sql_temp += "and t.stock_id=" + TextBox1.Text + "     ";
            }

            sql_temp += " ORDER BY date1 DESC                                                                                                                                                       ";
            sql_temp += "                                                                                                                                                                           ";
            sql_temp += " ) t2                                                                                                                                                                      ";
            sql_temp += "                                                                                                                                                                           ";
            sql_temp += " group by  stock_id ,stock_name                                                                                                                                                       ";
            sql_temp += "                                                                                                                                                                           ";
            sql_temp += " order by count(t2.stock_id) desc,avg(volume1) desc                                                                                                                            ";


            Bind_data1(sql_temp, conn);
            
        }
        lblAIExpand.Text = DropDownList1.SelectedValue; 

    

    }
    public DataSet Bind_data1(string sqlX, string connx)
    {
        sql_temp = sqlX;




        ds_temp = func.get_dataSet_access(sql_temp, connx);

        #region fill_add_data

        DataTable fill_data = new DataTable();

        fill_data = func.add_column(ds_temp, "Current_price");

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
            fill_data.Rows[i]["diff"] = Convert.ToString(Math.Round(Convert.ToDouble(fill_data.Rows[i]["Current_price"].ToString()) - Convert.ToDouble(fill_data.Rows[i]["price"].ToString()), 2));
        }
        fill_data = func.Table_add_column(fill_data, "diff_p");
        for (int i = 0; i <= fill_data.Rows.Count - 1; i++)
        {
            fill_data.Rows[i]["diff_p"] = Convert.ToString(Math.Round(Convert.ToDouble(fill_data.Rows[i]["diff"].ToString()) / Convert.ToDouble(fill_data.Rows[i]["price"].ToString()) * 100, 2)) + "%";
        }

        #endregion

        GridView1.DataSource = fill_data;


        GridView1.DataBind();



        return ds_temp;

    }

    //private DataTable add_column(DataSet ds, string add_col)

    //{
    //    DataSet ds_x = new DataSet();

    //    DataTable dtNew = new DataTable();

    //    ds_x = ds;
    //    dtNew=ds_x.Tables[0];

    //    dtNew.Columns.Add(add_col, typeof(string));

    //    return dtNew;

    //}

    //private DataTable rotation(DataSet ds, string row_name, string column_name)
    // {
    //     DataView dv = ds.Tables[0].DefaultView;

    //     DataTable EQPTable, STEPIDTable;
    //     //?瘞璊grade distinct璅? 
    //     EQPTable = ds.Tables[0].DefaultView.ToTable(true, row_name);
    //     STEPIDTable = ds.Tables[0].DefaultView.ToTable(true, column_name, "seq");

    //     DataView EQPGV = EQPTable.DefaultView;
    //     DataView STEPIDGV = STEPIDTable.DefaultView;
    //     EQPGV.Sort = row_name;
    //     STEPIDGV.Sort = "seq";

    //     DataTable dtNew = new DataTable();
    //     //瘞憓 DataTable 
    //     dtNew.Columns.Add(txtCalendar1.Text.Replace("/", ""), typeof(string));//蝚砌豢? 
    //     dtNew.Columns.Add("Qty", typeof(string));//蝚砌箸? 

    //     //瑽怠喳豢?span style="color:#FFA34F">column鋆靚曄? 
    //     /*for (int i = 0; i < dateTable.Rows.Count; i++) 
    //     { 
    //     dtNew.Columns.Add(dateTable.Rows[i][column_name].ToString(), typeof(string)); 
    //     }*/

    //     //string[] arr_date ={ }; 

    //     //for (int K = 0; K < 12; K++) 
    //     //{ 

    //     // arr_date[K] = DateTime.Now.Year.ToString() ; 

    //     ////} 

    //     //瘞憓撊隞甈雿鞈? 
    //     for (int i = 0; i <= STEPIDGV.Count - 1; i++)
    //     {

    //         dtNew.Columns.Add(STEPIDGV[i][column_name].ToString(), typeof(string));


    //     }

    //     int colnum = 0;
    //     //鳿亙泗ade瘙鋆隢閰函閬ow璅? 
    //     for (int i = 0; i < EQPGV.Count; i++)
    //     {
    //         //瘞憓 ROW 撠 dtNew 

    //         DataRow drNew = dtNew.NewRow();
    //         drNew[txtCalendar1.Text.Replace("/", "")] = EQPGV[i][row_name].ToString();
    //         drNew[1] = "Rework";
    //         colnum = 0;
    //         foreach (DataRow dr in STEPIDTable.Rows)
    //         {
    //             //甇貏亦歲ow?蝺芣吶lumn靚暹曄? 
    //             dv.RowFilter = column_name + "='" + dr[0].ToString() + "' and " + row_name + "='" + EQPGV[i][row_name].ToString() + "' ";
    //             if (dv.Count > 0)
    //             {
    //                 //drNew[colnum + 2] = (Convert.ToDouble(dv[0]["STEPID"])).ToString("#,##0"); 
    //                 // drNew[colnum + 2] = dv[0]["STEPID"].ToString(); 
    //                 // drNew[colnum + 3] = dv[0]["EQPID"].ToString(); 
    //                 drNew[colnum + 2] = dv[0]["REWORK"].ToString();
    //                 // drNew[colnum + 5] = dv[0]["TOTAL"].ToString(); 

    //             }

    //             else
    //                 drNew[colnum + 2] = "0";

    //             colnum++;
    //         }
    //         dtNew.Rows.Add(drNew);


    //         drNew = dtNew.NewRow();
    //         drNew[txtCalendar1.Text.Replace("/", "")] = EQPGV[i][row_name].ToString();
    //         drNew[1] = "Total";
    //         colnum = 0;
    //         foreach (DataRow dr in STEPIDTable.Rows)
    //         {
    //             //甇貏亦歲ow?蝺芣吶lumn靚暹曄? 
    //             dv.RowFilter = column_name + "='" + dr[0].ToString() + "' and " + row_name + "='" + EQPGV[i][row_name].ToString() + "' ";
    //             if (dv.Count > 0)
    //             {
    //                 //drNew[colnum + 2] = (Convert.ToDouble(dv[0]["STEPID"])).ToString("#,##0"); 
    //                 // drNew[colnum + 2] = dv[0]["STEPID"].ToString(); 
    //                 // drNew[colnum + 3] = dv[0]["EQPID"].ToString(); 
    //                 drNew[colnum + 2] = dv[0]["Total"].ToString();
    //                 // drNew[colnum + 5] = dv[0]["TOTAL"].ToString(); 

    //             }

    //             else
    //                 drNew[colnum + 2] = "0";

    //             colnum++;
    //         }
    //         dtNew.Rows.Add(drNew);



    //     }
    //     return dtNew;
    // } 



    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        string strTaskID = string.Empty;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            //ImageButton btnDel = new ImageButton();
            //btnDel = (ImageButton)e.Row.FindControl("btnDel");

            //btnDel.Attributes["onclick"] = "javascript:return confirm('確認刪除否? 【Stock_id】:" + ((DataRowView)e.Row.DataItem)["stock_id"] + " 【End Time】:" + ((DataRowView)e.Row.DataItem)["date1"] + "【SN】:" + ((DataRowView)e.Row.DataItem)["SN"] + "');";




            //string conn = System.Configuration.ConfigurationSettings.AppSettings["DBCONN_Meeting"];
            //string strSql_Pro;
            //string snn1;

            ////GridViewRow row = GridView2.Rows[e.RowIndex];



            //DataSet ds = new DataSet();

            //strSql_Pro = "select distinct(t.prod_name) from tlms_tmp t ";
            //strSql_Pro += "where t.tool_id='" + ((DataRowView)e.Row.DataItem)["TOOL_ID"] + "'";


            //ds = func.get_dataSet_access(strSql_Pro, conn);


            //((DataList)e.Row.FindControl("DataList1")).DataSource = ds.Tables[0];
            //((DataList)e.Row.FindControl("DataList1")).DataBind();



            //strTaskID = ((DataRowView)e.Row.DataItem)["task_id"].ToString();
            // dv.RowFilter = "task_id=" + strTaskID;
            //dv.Sort = "is_owner desc";

            //task member datalist
            //((DataList)e.Row.FindControl("dlTaskMember")).DataSource = dv;
            //((DataList)e.Row.FindControl("dlTaskMember")).DataBind();

            //image link to task content

            //string sMessage = String.Format("return(OpenTask('{0}'));", strTaskID);
            //((ImageButton)e.Row.FindControl("btnEdit")).OnClientClick = sMessage;//"if (OpenTask('" + sMessage + "')==false) {return false;}";
            //Int32 percent_value = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "percent1"));
            Int32 countX = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "count1"));
            Double priceX = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "price"));
            // Int32 priceX_top = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "avg_hot_price"));
            // Int32 priceX_cur = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Current_price"));

            Double current_price = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "Current_price"));

            //Int32 pricexx = Convert.ToInt32(price1);



            // if (percent_value >0)
            //e.Row.Cells[0].BackColor = Color.Yellow; 
            // e.Row.Cells[6].Style.Add("background-color", "#FFFF80");
            if (countX >= 3)
                e.Row.Cells[2].Style.Add("background-color", "#95CAFF");
            if (countX == 2)
                e.Row.Cells[2].Style.Add("background-color", "#FFFFB3");

            if (current_price < priceX)
                e.Row.Cells[11].Style.Add("background-color", "#A2FFA2");


            //if (Flag_satus == "Cancel")
            //    e.Row.Cells[6].Style.Add("background-color", "#FF9DFF"); 
            if (e.Row.RowIndex != -1)
            {
                int RN = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = RN.ToString();
            }


            sql_temp2 = " select format(t.date1,'yyyy/MM/dd') as date1 ,t.stock_name,t.stock_id,t.price1,t.percent1&'%' as percent1,t.volume1,t.hot_price, round(t.volume1*t.percent1/100,0) as kpi, switch(turtle is null,0, turtle is not null ,turtle) as turtle  from strong_up_history t " + 
" where t.stock_id='" + ((DataRowView)e.Row.DataItem)["stock_id"].ToString() + "'  " + 
" and t.date1>=#" + txtCalendar1.Text + "# and t.date1<=#" + txtCalendar2.Text + "# " + 
" order by t.date1 desc "; 

ds_temp2 = func.get_dataSet_access(sql_temp2,conn); 

GridView2.DataSource = ds_temp2.Tables[0]; 
GridView2.DataBind(); 





if (ds_temp2.Tables[0].Rows.Count == 0) 
{ 
System.Web.UI.WebControls.Image btnShowDetail = new System.Web.UI.WebControls.Image(); 
btnShowDetail = (System.Web.UI.WebControls.Image)e.Row.FindControl("btnShowDetail"); 
btnShowDetail.Visible = false; 
} 
else 
{ 

#region 
GridViewRow r = new GridViewRow(-1, -1, DataControlRowType.DataRow, DataControlRowState.Normal); 
StringWriter sw = new StringWriter(); 
HtmlTextWriter hw = new HtmlTextWriter(sw); 

r.Cells.Add(new TableCell()); 
r.Cells.Add(new TableCell()); 

r.Cells[1].ColumnSpan = GridView2.Columns.Count - 1; 

GridView2.Visible = true; 
GridView2.RenderControl(hw); 
GridView2.Visible = false; 

r.Cells[1].Text = sw.ToString(); 
sw.Close(); 

r.ID = "Detail_" + e.Row.RowIndex.ToString(); 

r.HorizontalAlign = HorizontalAlign.Left; 
e.Row.Parent.Controls.Add(r); 

System.Web.UI.WebControls.Image btnShowDetail = new System.Web.UI.WebControls.Image();



btnShowDetail = (System.Web.UI.WebControls.Image)e.Row.FindControl("btnShowDetail");

//btnShowDetail.Attributes.Add("onclick", "showHideAnswer('GridView1_" + r.ID + "','" + e.Row.ClientID.ToString() + "_" + btnShowDetail.ID + "');"); 
btnShowDetail.Attributes.Add("onclick", "showHideAnswer('ctl00_ContentPlaceHolder1_GridView1_" + r.ID + "','" + e.Row.ClientID.ToString() + "_" + btnShowDetail.ID + "');"); 
//btnShowDetail.Attributes.Add("onclick", "showHideAnswer('" + this.ClientID.ToString() + "_GridView1_" + r.ID + "','" + e.Row.ClientID.ToString() + "_" + btnShowDetail.ID + "');"); 

if (lblAIExpand.Text == "Y") 
{ 
r.Style["display"] = "block"; 
btnShowDetail.ImageUrl = "~/images/close13.gif"; 
} 
else 
{ 
r.Style["display"] = "none"; 
btnShowDetail.ImageUrl = "~/images/open13.gif"; 
} 


#endregion 

        
    }

        }
    }
    protected void ButtonQuery_Click(object sender, EventArgs e)
    {

        if (CheckBox1.Checked)
        {
            DateTime dt = DateTime.Parse(today);
            string AA = dt.ToString("dddd");
            string temp_date = "";
            if (AA.Equals("星期一"))
            {
                temp_date = DateTime.Now.AddDays(-5).ToString("yyyy/MM/dd");
            }
            if (AA.Equals("星期二"))
            {
                temp_date = DateTime.Now.AddDays(-5).ToString("yyyy/MM/dd");
            }
            if (AA.Equals("星期三"))
            {
                temp_date = DateTime.Now.AddDays(-5).ToString("yyyy/MM/dd");
            }
            if (AA.Equals("星期四"))
            {
                temp_date = DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd");
            }
            if (AA.Equals("星期五"))
            {
                temp_date = DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd");
            }
            if (AA.Equals("星期六"))
            {
                temp_date = DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd");
            }
            if (AA.Equals("星期日"))
            {
                temp_date = DateTime.Now.AddDays(-4).ToString("yyyy/MM/dd");
            }

            txtCalendar1.Text = temp_date;
            temp_date1 = temp_date;
            txtCalendar2.Text = today;
            temp_date2 = today;
        
        
        }

        if (CheckBox2.Checked)
        {
            DateTime dt = DateTime.Parse(today_minus15);
            string AA = dt.ToString("dddd");
            string temp_date = "";
            if (AA.Equals("星期一"))
            {
                temp_date = DateTime.Now.AddDays(-20).ToString("yyyy/MM/dd");
            }
            if (AA.Equals("星期二"))
            {
                temp_date = DateTime.Now.AddDays(-20).ToString("yyyy/MM/dd");
            }
            if (AA.Equals("星期三"))
            {
                temp_date = DateTime.Now.AddDays(-20).ToString("yyyy/MM/dd");
            }
            if (AA.Equals("星期四"))
            {
                temp_date = DateTime.Now.AddDays(-18).ToString("yyyy/MM/dd");
            }
            if (AA.Equals("星期五"))
            {
                temp_date = DateTime.Now.AddDays(-18).ToString("yyyy/MM/dd");
            }
            if (AA.Equals("星期六"))
            {
                temp_date = DateTime.Now.AddDays(-18).ToString("yyyy/MM/dd");
            }
            if (AA.Equals("星期日"))
            {
                temp_date = DateTime.Now.AddDays(-19).ToString("yyyy/MM/dd");
            }

            txtCalendar1.Text = temp_date;
            temp_date3 = temp_date;
            txtCalendar2.Text = today_minus15;
            temp_date4 = today_minus15;



        }

        if (CheckBox1.Checked && CheckBox2.Checked)
        {
            sql_temp3 = " select    t2.stock_id,t2.stock_name,count(t2.stock_id) as count1 ,round(avg(price1),2) as price  ,round(avg(volume1),0) as avg_volume ,round(avg(hot_price),2) as avg_hot_price,round(avg(  IIf(turtle is null,0, turtle)   ),2) as avg_turtle  from ( " +
"                                                                                                                                                                           " +
" SELECT *                                                                                                                                                                  " +
" FROM strong_up_history AS t                                                                                                                                               " +
" WHERE 1=1                                                                                                                                                   ";
        if (!txtCalendar1.Text.Equals(""))
        {
            sql_temp3 += " and format(t.date1,'yyyy/MM/dd')>='" + temp_date1 + "'     ";
        }
        if (!txtCalendar2.Text.Equals(""))
        {
            sql_temp3 += " and format(t.date1,'yyyy/MM/dd')<='" + temp_date2 + "'     ";
        }
        if (!TextBox3.Text.Equals(""))
        {
            sql_temp3 += "and t.price1>=" + TextBox3.Text + "     ";
        }
        if (!TextBox2.Text.Equals(""))
        {
            sql_temp3 += "and t.price1<=" + TextBox2.Text + "     ";
        }
        if (!TextBox4.Text.Equals(""))
        {
            sql_temp3 += "and t.volume1>=" + TextBox4.Text + "     ";
        }

        if (!TextBox1.Text.Equals(""))
        {
            sql_temp3 += "and t.stock_id='" + TextBox1.Text + "'     ";
        }


        sql_temp3 += " ORDER BY date1 DESC                                                                                                                                                       ";
        sql_temp3 += "                                                                                                                                                                           ";
        sql_temp3 += " ) t2                                                                                                                                                                      ";
        sql_temp3 += "                                                                                                                                                                           ";
        sql_temp3 += " group by  stock_id ,stock_name                                                                                                                                                       ";
        sql_temp3 += "                                                                                                                                                                           ";
        sql_temp3 += " order by count(t2.stock_id) desc,avg(volume1) desc             ";


        sql_temp4 = " select    t2.stock_id,t2.stock_name,count(t2.stock_id) as count1 ,round(avg(price1),2) as price  ,round(avg(volume1),0) as avg_volume ,round(avg(hot_price),2) as avg_hot_price,round(avg(  IIf(turtle is null,0, turtle)   ),2) as avg_turtle  from ( " +
"                                                                                                                                                                           " +
" SELECT *                                                                                                                                                                  " +
" FROM strong_up_history AS t                                                                                                                                               " +
" WHERE 1=1                                                                                                                                                   ";
        if (!txtCalendar1.Text.Equals(""))
        {
            sql_temp4 += " and format(t.date1,'yyyy/MM/dd')>='" + temp_date3 + "'     ";
        }
        if (!txtCalendar2.Text.Equals(""))
        {
            sql_temp4 += " and format(t.date1,'yyyy/MM/dd')<='" + temp_date4 + "'     ";
        }
        if (!TextBox3.Text.Equals(""))
        {
            sql_temp4 += "and t.price1>=" + TextBox3.Text + "     ";
        }
        if (!TextBox2.Text.Equals(""))
        {
            sql_temp4 += "and t.price1<=" + TextBox2.Text + "     ";
        }
        if (!TextBox4.Text.Equals(""))
        {
            sql_temp4 += "and t.volume1>=" + TextBox4.Text + "     ";
        }

        if (!TextBox1.Text.Equals(""))
        {
            sql_temp4 += "and t.stock_id='" + TextBox1.Text + "'     ";
        }


        sql_temp4 += " ORDER BY date1 DESC                                                                                                                                                       ";
        sql_temp4 += "                                                                                                                                                                           ";
        sql_temp4 += " ) t2                                                                                                                                                                      ";
        sql_temp4 += "                                                                                                                                                                           ";
        sql_temp4 += " group by  stock_id ,stock_name                                                                                                                                                       ";
        sql_temp4 += "                                                                                                                                                                           ";
        sql_temp4 += " order by count(t2.stock_id) desc,avg(volume1) desc             ";


        sql_temp5 = " select ot2.* from (" + sql_temp3 + ") ot1,(" + sql_temp4 + ")ot2  where ot1.stock_id=ot2.stock_id  order by ot2.count1 desc ";

        sql_temp = sql_temp5;

        
        }
        else
        {

            sql_temp = " select    t2.stock_id,t2.stock_name,count(t2.stock_id) as count1 ,round(avg(price1),2) as price  ,round(avg(volume1),0) as avg_volume ,round(avg(hot_price),2) as avg_hot_price,round(avg(  IIf(turtle is null,0, turtle)   ),2) as avg_turtle  from ( " +
"                                                                                                                                                                           " +
" SELECT *                                                                                                                                                                  " +
" FROM strong_up_history AS t                                                                                                                                               " +
" WHERE 1=1                                                                                                                                                   ";
        if (!txtCalendar1.Text.Equals(""))
        {
            sql_temp += " and format(t.date1,'yyyy/MM/dd')>='" + txtCalendar1.Text + "'     ";
        }
        if (!txtCalendar2.Text.Equals(""))
        {
            sql_temp += " and format(t.date1,'yyyy/MM/dd')<='" + txtCalendar2.Text + "'     ";
        }
        if (!TextBox3.Text.Equals(""))
        {
            sql_temp += "and t.price1>=" + TextBox3.Text + "     ";
        }
        if (!TextBox2.Text.Equals(""))
        {
            sql_temp += "and t.price1<=" + TextBox2.Text + "     ";
        }
        if (!TextBox4.Text.Equals(""))
        {
            sql_temp += "and t.volume1>=" + TextBox4.Text + "     ";
        }

        if (!TextBox1.Text.Equals(""))
        {
            sql_temp += "and t.stock_id='" + TextBox1.Text + "'     ";
        }


        sql_temp += " ORDER BY date1 DESC                                                                                                                                                       ";
        sql_temp += "                                                                                                                                                                           ";
        sql_temp += " ) t2                                                                                                                                                                      ";
        sql_temp += "                                                                                                                                                                           ";
        sql_temp += " group by  stock_id ,stock_name                                                                                                                                                       ";
        sql_temp += "                                                                                                                                                                           ";
        sql_temp += " order by count(t2.stock_id) desc,avg(volume1) desc                                                                                                                            ";







        
        }
        
       




        Bind_data1(sql_temp, conn);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GridView gv = new GridView();

        if (CheckBox1.Checked)
        {
            DateTime dt = DateTime.Parse(today);
            string AA = dt.ToString("dddd");
            string temp_date = "";
            if (AA.Equals("星期一"))
            {
                temp_date = DateTime.Now.AddDays(-5).ToString("yyyy/MM/dd");
            }
            if (AA.Equals("星期二"))
            {
                temp_date = DateTime.Now.AddDays(-5).ToString("yyyy/MM/dd");
            }
            if (AA.Equals("星期三"))
            {
                temp_date = DateTime.Now.AddDays(-5).ToString("yyyy/MM/dd");
            }
            if (AA.Equals("星期四"))
            {
                temp_date = DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd");
            }
            if (AA.Equals("星期五"))
            {
                temp_date = DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd");
            }
            if (AA.Equals("星期六"))
            {
                temp_date = DateTime.Now.AddDays(-3).ToString("yyyy/MM/dd");
            }
            if (AA.Equals("星期日"))
            {
                temp_date = DateTime.Now.AddDays(-4).ToString("yyyy/MM/dd");
            }

            txtCalendar1.Text = temp_date;
            temp_date1 = temp_date;
            txtCalendar2.Text = today;
            temp_date2 = today;


        }

        if (CheckBox2.Checked)
        {
            DateTime dt = DateTime.Parse(today_minus15);
            string AA = dt.ToString("dddd");
            string temp_date = "";
            if (AA.Equals("星期一"))
            {
                temp_date = DateTime.Now.AddDays(-20).ToString("yyyy/MM/dd");
            }
            if (AA.Equals("星期二"))
            {
                temp_date = DateTime.Now.AddDays(-20).ToString("yyyy/MM/dd");
            }
            if (AA.Equals("星期三"))
            {
                temp_date = DateTime.Now.AddDays(-20).ToString("yyyy/MM/dd");
            }
            if (AA.Equals("星期四"))
            {
                temp_date = DateTime.Now.AddDays(-18).ToString("yyyy/MM/dd");
            }
            if (AA.Equals("星期五"))
            {
                temp_date = DateTime.Now.AddDays(-18).ToString("yyyy/MM/dd");
            }
            if (AA.Equals("星期六"))
            {
                temp_date = DateTime.Now.AddDays(-18).ToString("yyyy/MM/dd");
            }
            if (AA.Equals("星期日"))
            {
                temp_date = DateTime.Now.AddDays(-19).ToString("yyyy/MM/dd");
            }

            txtCalendar1.Text = temp_date;
            temp_date3 = temp_date;
            txtCalendar2.Text = today_minus15;
            temp_date4 = today_minus15;



        }

        if (CheckBox1.Checked && CheckBox2.Checked)
        {
            sql_temp3 = " select    t2.stock_id,t2.stock_name,count(t2.stock_id) as count1 ,round(avg(price1),2) as price  ,round(avg(volume1),0) as avg_volume ,round(avg(hot_price),2) as avg_hot_price,round(avg(  IIf(turtle is null,0, turtle)   ),2) as avg_turtle  from ( " +
 "                                                                                                                                                                           " +
 " SELECT *                                                                                                                                                                  " +
 " FROM strong_up_history AS t                                                                                                                                               " +
 " WHERE 1=1                                                                                                                                                   ";
            if (!txtCalendar1.Text.Equals(""))
            {
                sql_temp3 += " and format(t.date1,'yyyy/MM/dd')>='" + temp_date1 + "'     ";
            }
            if (!txtCalendar2.Text.Equals(""))
            {
                sql_temp3 += " and format(t.date1,'yyyy/MM/dd')<='" + temp_date2 + "'     ";
            }
            if (!TextBox3.Text.Equals(""))
            {
                sql_temp3 += "and t.price1>=" + TextBox3.Text + "     ";
            }
            if (!TextBox2.Text.Equals(""))
            {
                sql_temp3 += "and t.price1<=" + TextBox2.Text + "     ";
            }
            if (!TextBox4.Text.Equals(""))
            {
                sql_temp3 += "and t.volume1>=" + TextBox4.Text + "     ";
            }

            if (!TextBox1.Text.Equals(""))
            {
                sql_temp3 += "and t.stock_id='" + TextBox1.Text + "'     ";
            }


            sql_temp3 += " ORDER BY date1 DESC                                                                                                                                                       ";
            sql_temp3 += "                                                                                                                                                                           ";
            sql_temp3 += " ) t2                                                                                                                                                                      ";
            sql_temp3 += "                                                                                                                                                                           ";
            sql_temp3 += " group by  stock_id ,stock_name                                                                                                                                                       ";
            sql_temp3 += "                                                                                                                                                                           ";
            sql_temp3 += " order by count(t2.stock_id) desc,avg(volume1) desc             ";


            sql_temp4 = " select    t2.stock_id,t2.stock_name,count(t2.stock_id) as count1 ,round(avg(price1),2) as price  ,round(avg(volume1),0) as avg_volume ,round(avg(hot_price),2) as avg_hot_price,round(avg(  IIf(turtle is null,0, turtle)   ),2) as avg_turtle  from ( " +
    "                                                                                                                                                                           " +
    " SELECT *                                                                                                                                                                  " +
    " FROM strong_up_history AS t                                                                                                                                               " +
    " WHERE 1=1                                                                                                                                                   ";
            if (!txtCalendar1.Text.Equals(""))
            {
                sql_temp4 += " and format(t.date1,'yyyy/MM/dd')>='" + temp_date3 + "'     ";
            }
            if (!txtCalendar2.Text.Equals(""))
            {
                sql_temp4 += " and format(t.date1,'yyyy/MM/dd')<='" + temp_date4 + "'     ";
            }
            if (!TextBox3.Text.Equals(""))
            {
                sql_temp4 += "and t.price1>=" + TextBox3.Text + "     ";
            }
            if (!TextBox2.Text.Equals(""))
            {
                sql_temp4 += "and t.price1<=" + TextBox2.Text + "     ";
            }
            if (!TextBox4.Text.Equals(""))
            {
                sql_temp4 += "and t.volume1>=" + TextBox4.Text + "     ";
            }

            if (!TextBox1.Text.Equals(""))
            {
                sql_temp4 += "and t.stock_id='" + TextBox1.Text + "'     ";
            }


            sql_temp4 += " ORDER BY date1 DESC                                                                                                                                                       ";
            sql_temp4 += "                                                                                                                                                                           ";
            sql_temp4 += " ) t2                                                                                                                                                                      ";
            sql_temp4 += "                                                                                                                                                                           ";
            sql_temp4 += " group by  stock_id ,stock_name                                                                                                                                                       ";
            sql_temp4 += "                                                                                                                                                                           ";
            sql_temp4 += " order by count(t2.stock_id) desc,avg(volume1) desc             ";


            sql_temp5 = " select ot2.* from (" + sql_temp3 + ") ot1,(" + sql_temp4 + ")ot2  where ot1.stock_id=ot2.stock_id  order by ot2.count1 desc ";

            sql_temp = sql_temp5;


        }
        else
        {

            sql_temp = " select    t2.stock_id,t2.stock_name,count(t2.stock_id) as count1 ,round(avg(price1),2) as price  ,round(avg(volume1),0) as avg_volume ,round(avg(hot_price),2) as avg_hot_price,round(avg( IIf(turtle is null,0, turtle)   ),2) as avg_turtle  from ( " +
 "                                                                                                                                                                           " +
 " SELECT *                                                                                                                                                                  " +
 " FROM strong_up_history AS t                                                                                                                                               " +
 " WHERE 1=1                                                                                                                                                   ";
            if (!txtCalendar1.Text.Equals(""))
            {
                sql_temp += " and format(t.date1,'yyyy/MM/dd')>='" + txtCalendar1.Text + "'     ";
            }
            if (!txtCalendar2.Text.Equals(""))
            {
                sql_temp += " and format(t.date1,'yyyy/MM/dd')<='" + txtCalendar2.Text + "'     ";
            }
            if (!TextBox3.Text.Equals(""))
            {
                sql_temp += "and t.price1>=" + TextBox3.Text + "     ";
            }
            if (!TextBox2.Text.Equals(""))
            {
                sql_temp += "and t.price1<=" + TextBox2.Text + "     ";
            }
            if (!TextBox4.Text.Equals(""))
            {
                sql_temp += "and t.volume1>=" + TextBox4.Text + "     ";
            }

            if (!TextBox1.Text.Equals(""))
            {
                sql_temp += "and t.stock_id='" + TextBox1.Text + "'     ";
            }


            sql_temp += " ORDER BY date1 DESC                                                                                                                                                       ";
            sql_temp += "                                                                                                                                                                           ";
            sql_temp += " ) t2                                                                                                                                                                      ";
            sql_temp += "                                                                                                                                                                           ";
            sql_temp += " group by  stock_id ,stock_name                                                                                                                                                       ";
            sql_temp += "                                                                                                                                                                           ";
            sql_temp += " order by count(t2.stock_id) desc,avg(volume1) desc                                                                                                                            ";








        }
        

        gv.DataSource = Bind_data1(sql_temp, conn);
        gv.DataBind();
        ExportExcel(gv);
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        // base.VerifyRenderingInServerForm(control); 
       
    }

    private void ExportExcel(GridView SeriesValuesDataGrid)
    {

        string filename = "";
        string today_detail_char = DateTime.Now.AddDays(+0).ToString("yyyy/MM/ddHHmmss").Replace("/", "");
        filename = "StockList_" + today_detail_char + ".xls";
        filename = "attachment;filename=" + filename;
        Response.Clear();
        Response.Buffer = true;

        Response.AddHeader("content-disposition", filename);

        //Response.AddHeader("content-disposition", "attachment;filename=\"" + filename + "\";"); 

        Response.Charset = "big5";

        // If you want the option to open the Excel file without saving than 

        // comment out the line below 

        // Response.Cache.SetCacheability(HttpCacheability.NoCache); 

        Response.ContentType = "application/vnd.xls";

        System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        SeriesValuesDataGrid.AllowPaging = false;
        SeriesValuesDataGrid.DataBind();

        SeriesValuesDataGrid.RenderControl(htmlWrite);

        string head = " <html> " +
        " <head><meta http-equiv='Content-Type' content='text/html; charset=big5'></head> " +
        " <body> ";

        string footer = " </body>" +
        " </html>";

        Response.Write(head + stringWrite.ToString() + footer);

        Response.End();

        SeriesValuesDataGrid.AllowPaging = true;
        SeriesValuesDataGrid.DataBind();





    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        string strTaskID = string.Empty;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            if (e.Row.RowIndex != -1)
            {
                int RN = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = RN.ToString();
            }



        }
    }
}
    