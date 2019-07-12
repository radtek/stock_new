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
using System.Drawing;
using System.Text;

public partial class op_COST1 : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["jump"];
    string today = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd");
    string tomorrow = DateTime.Now.AddDays(+1).ToString("yyyy/MM/dd");

    string today_minus30 = DateTime.Now.AddDays(-90).ToString("yyyy/MM/dd");
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
    string callsql = "";
    string putsql = "";
    string combinesql = "";

    DataSet ds_temp = new DataSet();
    DataSet ds_temp1 = new DataSet();
    DataSet ds_temp2 = new DataSet();
    string condition1 = "";
    string condition2 = "";
    string condition3 = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtCalendar1.Text = today_minus30;
            txtCalendar2.Text = tomorrow;
            CheckBox1.Checked = true;

            Label30.Text = "";
            Label31.Text = "";
            Label32.Text = "";
            Label33.Text = "";
            Label2.Text = "";

            sql_temp = @" 

SELECT distinct(t.DUE_TIME) as DUE_TIME
FROM OP_MODIFIED AS t where 1=1
{0}
{1} 
And t.TRADE_TIME='一般' And t.PRICE<>'-' And t.OI<>'-' 

;


";
            if (!txtCalendar1.Text.Equals(""))
            {
                condition1 = @" and format(t.SHIFT_DATE,'yyyy/MM/dd')>='" + txtCalendar1.Text + "'     ";
            }
            if (!txtCalendar2.Text.Equals(""))
            {
                condition2 = @" and format(t.SHIFT_DATE,'yyyy/MM/dd')<='" + txtCalendar2.Text + "'     ";
            }
            if (!DropDownList2.SelectedValue.Equals(""))
            {
                condition3 = @" and DUE_TIME='" + DropDownList2.SelectedValue + "'    ";
            }

            sql_temp = string.Format(sql_temp, condition1, condition2);
            ds_temp = func.get_dataSet_access(sql_temp, conn);

            DropDownList2.DataSource = ds_temp;
            DropDownList2.DataTextField = "DUE_TIME";
            DropDownList2.DataBind();

            if (!CheckBox1.Checked)
            {
                sql_temp = @" 

SELECT t.DUE_TIME, t.TRADE_TYPE, PRODUCT_TYPE, ROUND(SUM(PRICE*OI_CHANG)/SUM(OI_CHANG),2) AS OICHANG_COST_PRICE
FROM OP_MODIFIED AS t where 1=1
{0}
{1} 
And t.TRADE_TIME='一般' And t.PRICE<>'-' And t.OI<>'-' 

GROUP BY t.DUE_TIME, t.TRADE_TYPE, PRODUCT_TYPE
having SUM(OI_CHANG)>0
ORDER BY t.DUE_TIME, t.PRODUCT_TYPE;


";

                //And t.DUE_TIME='201905W4'
                if (!txtCalendar1.Text.Equals(""))
                {
                    condition1 = @" and format(t.SHIFT_DATE,'yyyy/MM/dd')>='" + txtCalendar1.Text + "'     ";
                }
                if (!txtCalendar2.Text.Equals(""))
                {
                    condition2 = @" and format(t.SHIFT_DATE,'yyyy/MM/dd')<='" + txtCalendar2.Text + "'     ";
                }

                sql_temp = string.Format(sql_temp, condition1, condition2);
                ds_temp = func.get_dataSet_access(sql_temp, conn);
            }
            else
            {
                callsql = @" 

SELECT t.DUE_TIME,  t.PRODUCT_TYPE, ROUND(SUM(PRICE*OI_CHANG)/SUM(OI_CHANG),2) AS OICHANG_COST_PRICE
FROM OP_MODIFIED AS t where 1=1
{0}
{1} 
{2}
And t.TRADE_TIME='一般' And t.PRICE<>'-' And t.OI<>'-' 
And TRADE_TYPE='買權'
GROUP BY t.DUE_TIME, t.TRADE_TYPE, PRODUCT_TYPE
having SUM(OI_CHANG)>0
ORDER BY t.DUE_TIME, t.PRODUCT_TYPE


";

                //And t.DUE_TIME='201905W4'
                if (!txtCalendar1.Text.Equals(""))
                {
                    condition1 = @" and format(t.SHIFT_DATE,'yyyy/MM/dd')>='" + txtCalendar1.Text + "'     ";
                }
                if (!txtCalendar2.Text.Equals(""))
                {
                    condition2 = @" and format(t.SHIFT_DATE,'yyyy/MM/dd')<='" + txtCalendar2.Text + "'     ";
                }
                if (!DropDownList2.SelectedValue.Equals(""))
                {
                    condition3 = @" and DUE_TIME='" + DropDownList2.SelectedValue + "'    ";
                }

                callsql = string.Format(callsql, condition1, condition2, condition3);


                putsql = @" 

SELECT t.DUE_TIME, t.PRODUCT_TYPE, ROUND(SUM(t.PRICE*OI_CHANG)/SUM(t.OI_CHANG),2) AS OICHANG_COST_PRICE
FROM OP_MODIFIED AS t where 1=1
{0}
{1} 
{2}
And t.TRADE_TIME='一般' And t.PRICE<>'-' And t.OI<>'-' 
And TRADE_TYPE='賣權'
GROUP BY t.DUE_TIME, t.TRADE_TYPE, PRODUCT_TYPE
having SUM(OI_CHANG)>0
ORDER BY t.DUE_TIME, t.PRODUCT_TYPE


";

                //And t.DUE_TIME='201905W4'
                if (!txtCalendar1.Text.Equals(""))
                {
                    condition1 = @" and format(t.SHIFT_DATE,'yyyy/MM/dd')>='" + txtCalendar1.Text + "'     ";
                }
                if (!txtCalendar2.Text.Equals(""))
                {
                    condition2 = @" and format(t.SHIFT_DATE,'yyyy/MM/dd')<='" + txtCalendar2.Text + "'     ";
                }
                if (!DropDownList2.SelectedValue.Equals(""))
                {
                    condition3 = @" and DUE_TIME='" + DropDownList2.SelectedValue + "'    ";
                }

                putsql = string.Format(putsql, condition1, condition2, condition3);
                string initialprice = TextBox1.Text;
                if (!CheckBox2.Checked)
                {

                    combinesql = @"   select oa.DUE_TIME,oa.OICHANG_COST_PRICE as call_price,oa.PRODUCT_TYPE,(oa.PRODUCT_TYPE+oa.OICHANG_COST_PRICE-ob.OICHANG_COST_PRICE)as cal_index,ob.OICHANG_COST_PRICE as put_price from ({0}) oa ,({1})ob   
                          where  oa.PRODUCT_TYPE=ob.PRODUCT_TYPE
                           order by oa.PRODUCT_TYPE";
                }
                else 
                {

                    combinesql = @"   select oa.DUE_TIME,oa.OICHANG_COST_PRICE+({2}-(oa.PRODUCT_TYPE+oa.OICHANG_COST_PRICE-ob.OICHANG_COST_PRICE)) as call_price,oa.PRODUCT_TYPE,(oa.PRODUCT_TYPE+oa.OICHANG_COST_PRICE-ob.OICHANG_COST_PRICE)as cal_index,ob.OICHANG_COST_PRICE as put_price from ({0}) oa ,({1})ob   
                          where  oa.PRODUCT_TYPE=ob.PRODUCT_TYPE
                           order by oa.PRODUCT_TYPE";
                
                }


                combinesql = string.Format(combinesql, callsql, putsql,initialprice);


                ds_temp = func.get_dataSet_access(combinesql, conn);
            
            
            }

         

            GridView1.DataSource = ds_temp;


            GridView1.DataBind();


           



            sql_temp = @" 

SELECT format(MAX(a.交易日期),'yyyy/MM/dd') as SHIFT_DATE
FROM OP_PRICE AS a where 1=1
and a.交易時段='一般'
union all

SELECT format(MAX(t.SHIFT_DATE),'yyyy/MM/dd') as SHIFT_DATE
FROM OP_MODIFIED AS t where 1=1
{0}
{1} 
And t.TRADE_TIME='一般' And t.PRICE<>'-' And t.OI<>'-' 

;


";
            sql_temp = string.Format(sql_temp, condition1, condition2);
            ds_temp = func.get_dataSet_access(sql_temp, conn);
            Label3.Text = ds_temp.Tables[0].Rows[0][0].ToString();


            Label1.Text = ds_temp.Tables[0].Rows[1][0].ToString();

        }
        



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

    public static DataTable OpenCSV(string filePath)
    {
        FileStream fs = new FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
        StreamReader sr = new StreamReader(fs, Encoding.Default);
        //StreamReader sr = new StreamReader(fs, encoding);
        //string fileContent = sr.ReadToEnd();
        //記錄每次讀取的一行記錄
        DataTable dt = new DataTable();
        string strLine = "";
        //記錄每行記錄中的各字段內容
        string[] aryLine = null;
        string[] tableHead = null;
        //標示列數
        int columnCount = 2;
        //標示是否是讀取的第一行
        bool IsFirst = true;
        //逐行讀取CSV中的數據
        while ((strLine = sr.ReadLine()) != null)
        {
            if (IsFirst == true)
            {
                tableHead = strLine.Split(',');
                IsFirst = false;
                columnCount = tableHead.Length;
                //創建列
                for (int i = 0; i < columnCount; i++)
                {
                    tableHead[i] = tableHead[i].Replace("\"", "");
                    DataColumn dc = new DataColumn(tableHead[i]);
                    dt.Columns.Add(dc);
                }
            }
            else
            {
                aryLine = strLine.Split(',');
                DataRow dr = dt.NewRow();
                for (int j = 0; j < columnCount; j++)
                {
                    dr[j] = aryLine[j].Replace("\"", "").Replace(".0000","");
                }
                dt.Rows.Add(dr);
            }
        }
        if (aryLine != null && aryLine.Length > 0)
        {
            dt.DefaultView.Sort = tableHead[2] + " " + "DESC";
        }
        sr.Close();
        fs.Close();
        return dt;
    }

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
            //Int32 countX = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "count1"));
            //Double priceX = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "price"));
            // Int32 priceX_top = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "avg_hot_price"));
            // Int32 priceX_cur = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Current_price"));
            if (CheckBox1.Checked)
            {

                Double call_price = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "call_price"));
                Double put_price = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "put_price"));





                if (call_price < 50 && call_price>0)
                {
                    e.Row.Cells[2].BackColor = Color.Pink;
                    e.Row.Cells[3].BackColor = Color.Yellow;
                }
                if (call_price > put_price && put_price>0)
                {
                    e.Row.Cells[2].BackColor = Color.Gray;
                    
                }


                if (put_price < 50 && put_price >0)
                {
                    e.Row.Cells[3].BackColor = Color.Yellow;
                    e.Row.Cells[5].BackColor = Color.GreenYellow;
                
                }
                if (put_price > call_price && call_price > 0 || put_price<0)
                {
                    e.Row.Cells[5].BackColor = Color.Gray;

                }

                //if (call_price > put_price )
                //{
                    
                //    e.Row.Cells[2].BackColor = Color.Yellow;
                //}


                //if (put_price < 50 && put_price >0&&put_price >call_price)
                //{

                //    e.Row.Cells[2].BackColor = Color.Yellow;
                //}

                   
            }
            
            //// e.Row.Cells[6].Style.Add("background-color", "#FFFF80");
            //if (countX >= 3)
            //    e.Row.Cells[2].Style.Add("background-color", "#95CAFF");
            //if (countX == 2)
            //    e.Row.Cells[2].Style.Add("background-color", "#FFFFB3");

            //if (current_price < priceX)
            //    e.Row.Cells[11].Style.Add("background-color", "#A2FFA2");


            //if (Flag_satus == "Cancel")
            //    e.Row.Cells[6].Style.Add("background-color", "#FF9DFF"); 
            if (e.Row.RowIndex != -1)
            {
                int RN = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = RN.ToString();
            }


//            sql_temp2 = " select format(t.date1,'yyyy/MM/dd') as date1 ,t.stock_name,t.stock_id,t.price1,t.percent1&'%' as percent1,t.volume1,t.hot_price, round(t.volume1*t.percent1/100,0) as kpi, switch(turtle is null,0, turtle is not null ,turtle) as turtle  from strong_up_history t " +
//" where t.stock_id='" + ((DataRowView)e.Row.DataItem)["stock_id"].ToString() + "'  " +
//" and t.date1>=#" + txtCalendar1.Text + "# and t.date1<=#" + txtCalendar2.Text + "# " +
//" order by t.date1 desc ";

//            ds_temp2 = func.get_dataSet_access(sql_temp2, conn);

//            GridView2.DataSource = ds_temp2.Tables[0];
//            GridView2.DataBind();





            //if (ds_temp2.Tables[0].Rows.Count == 0)
            //{
            //    System.Web.UI.WebControls.Image btnShowDetail = new System.Web.UI.WebControls.Image();
            //    btnShowDetail = (System.Web.UI.WebControls.Image)e.Row.FindControl("btnShowDetail");
            //    btnShowDetail.Visible = false;
            //}
            //else
            //{

            //    #region
            //    GridViewRow r = new GridViewRow(-1, -1, DataControlRowType.DataRow, DataControlRowState.Normal);
            //    StringWriter sw = new StringWriter();
            //    HtmlTextWriter hw = new HtmlTextWriter(sw);

            //    r.Cells.Add(new TableCell());
            //    r.Cells.Add(new TableCell());

            //    r.Cells[1].ColumnSpan = GridView2.Columns.Count - 1;

            //    GridView2.Visible = true;
            //    GridView2.RenderControl(hw);
            //    GridView2.Visible = false;

            //    r.Cells[1].Text = sw.ToString();
            //    sw.Close();

            //    r.ID = "Detail_" + e.Row.RowIndex.ToString();

            //    r.HorizontalAlign = HorizontalAlign.Left;
            //    e.Row.Parent.Controls.Add(r);

            //    System.Web.UI.WebControls.Image btnShowDetail = new System.Web.UI.WebControls.Image();



            //    btnShowDetail = (System.Web.UI.WebControls.Image)e.Row.FindControl("btnShowDetail");

            //    //btnShowDetail.Attributes.Add("onclick", "showHideAnswer('GridView1_" + r.ID + "','" + e.Row.ClientID.ToString() + "_" + btnShowDetail.ID + "');"); 
            //    btnShowDetail.Attributes.Add("onclick", "showHideAnswer('ctl00_ContentPlaceHolder1_GridView1_" + r.ID + "','" + e.Row.ClientID.ToString() + "_" + btnShowDetail.ID + "');");
            //    //btnShowDetail.Attributes.Add("onclick", "showHideAnswer('" + this.ClientID.ToString() + "_GridView1_" + r.ID + "','" + e.Row.ClientID.ToString() + "_" + btnShowDetail.ID + "');"); 

            //    if (lblAIExpand.Text == "Y")
            //    {
            //        r.Style["display"] = "block";
            //        btnShowDetail.ImageUrl = "~/images/close13.gif";
            //    }
            //    else
            //    {
            //        r.Style["display"] = "none";
            //        btnShowDetail.ImageUrl = "~/images/open13.gif";
            //    }


            //    #endregion


            //}

        }
    }
    protected void ButtonQuery_Click(object sender, EventArgs e)
    {
        if (!CheckBox1.Checked)
        {


            sql_temp = @" 

SELECT t.DUE_TIME, t.TRADE_TYPE, PRODUCT_TYPE, ROUND(SUM(PRICE*OI_CHANG)/SUM(OI_CHANG),2) AS OICHANG_COST_PRICE
FROM OP_MODIFIED AS t where 1=1
{0}
{1} 
{2}
And t.TRADE_TIME='一般' And t.PRICE<>'-' And t.OI<>'-' 

GROUP BY t.DUE_TIME, t.TRADE_TYPE, PRODUCT_TYPE
having SUM(OI_CHANG)>0
ORDER BY t.DUE_TIME, t.PRODUCT_TYPE;


";

            //And t.DUE_TIME='201905W4'
            if (!txtCalendar1.Text.Equals(""))
            {
                condition1 = @" and format(t.SHIFT_DATE,'yyyy/MM/dd')>='" + txtCalendar1.Text + "'     ";
            }
            if (!txtCalendar2.Text.Equals(""))
            {
                condition2 = @" and format(t.SHIFT_DATE,'yyyy/MM/dd')<='" + txtCalendar2.Text + "'     ";
            }
            if (!DropDownList2.SelectedValue.Equals(""))
            {
                condition3 = @" and DUE_TIME='" + DropDownList2.SelectedValue + "'    ";
            }

            sql_temp = string.Format(sql_temp, condition1, condition2, condition3);
            ds_temp = func.get_dataSet_access(sql_temp, conn);
        }
        else
        {
            callsql = @" 

SELECT t.DUE_TIME,  t.PRODUCT_TYPE, ROUND(SUM(PRICE*OI_CHANG)/SUM(OI_CHANG),2) AS OICHANG_COST_PRICE
FROM OP_MODIFIED AS t where 1=1
{0}
{1} 
{2}
And t.TRADE_TIME='一般' And t.PRICE<>'-' And t.OI<>'-' 
And TRADE_TYPE='買權'
GROUP BY t.DUE_TIME, t.TRADE_TYPE, PRODUCT_TYPE
having SUM(OI_CHANG)>0
ORDER BY t.DUE_TIME, t.PRODUCT_TYPE


";

            //And t.DUE_TIME='201905W4'
            if (!txtCalendar1.Text.Equals(""))
            {
                condition1 = @" and format(t.SHIFT_DATE,'yyyy/MM/dd')>='" + txtCalendar1.Text + "'     ";
            }
            if (!txtCalendar2.Text.Equals(""))
            {
                condition2 = @" and format(t.SHIFT_DATE,'yyyy/MM/dd')<='" + txtCalendar2.Text + "'     ";
            }
            if (!DropDownList2.SelectedValue.Equals(""))
            {
                condition3 = @" and DUE_TIME='" + DropDownList2.SelectedValue + "'    ";
            }

            callsql = string.Format(callsql, condition1, condition2, condition3);


            putsql = @" 

SELECT t.DUE_TIME, t.PRODUCT_TYPE, ROUND(SUM(t.PRICE*OI_CHANG)/SUM(t.OI_CHANG),2) AS OICHANG_COST_PRICE
FROM OP_MODIFIED AS t where 1=1
{0}
{1} 
{2}
And t.TRADE_TIME='一般' And t.PRICE<>'-' And t.OI<>'-' 
And TRADE_TYPE='賣權'
GROUP BY t.DUE_TIME, t.TRADE_TYPE, PRODUCT_TYPE
having SUM(OI_CHANG)>0
ORDER BY t.DUE_TIME, t.PRODUCT_TYPE


";

            //And t.DUE_TIME='201905W4'
            if (!txtCalendar1.Text.Equals(""))
            {
                condition1 = @" and format(t.SHIFT_DATE,'yyyy/MM/dd')>='" + txtCalendar1.Text + "'     ";
            }
            if (!txtCalendar2.Text.Equals(""))
            {
                condition2 = @" and format(t.SHIFT_DATE,'yyyy/MM/dd')<='" + txtCalendar2.Text + "'     ";
            }
            if (!DropDownList2.SelectedValue.Equals(""))
            {
                condition3 = @" and DUE_TIME='" + DropDownList2.SelectedValue + "'    ";
            }

            putsql = string.Format(putsql, condition1, condition2, condition3);

            string initialprice = TextBox1.Text;
            if (!CheckBox2.Checked)
            {

                combinesql = @"   select oa.DUE_TIME,oa.OICHANG_COST_PRICE as call_price,oa.PRODUCT_TYPE,(oa.PRODUCT_TYPE+oa.OICHANG_COST_PRICE-ob.OICHANG_COST_PRICE)as cal_index,ob.OICHANG_COST_PRICE as put_price from ({0}) oa ,({1})ob   
                          where  oa.PRODUCT_TYPE=ob.PRODUCT_TYPE
                           order by oa.PRODUCT_TYPE";
            }
            else
            {

                combinesql = @"   select oa.DUE_TIME,  IIf((oa.PRODUCT_TYPE+oa.OICHANG_COST_PRICE-ob.OICHANG_COST_PRICE)-{2}<0, oa.OICHANG_COST_PRICE+50, oa.OICHANG_COST_PRICE)  as call_price
                                  
                                 ,oa.PRODUCT_TYPE,(oa.PRODUCT_TYPE+oa.OICHANG_COST_PRICE-ob.OICHANG_COST_PRICE)as cal_index,ob.OICHANG_COST_PRICE  as put_price from ({0}) oa ,({1})ob   
                          where  oa.PRODUCT_TYPE=ob.PRODUCT_TYPE
                           order by oa.PRODUCT_TYPE";

            }


            combinesql = string.Format(combinesql, callsql, putsql, initialprice);


            ds_temp = func.get_dataSet_access(combinesql, conn);





        }

        #region calculator  UPPER BOUND/LOW BOUND
        Double NowPrice = Convert.ToDouble(TextBox2.Text);
        Double WaveRate = Convert.ToDouble(TextBox3.Text);
        Double DueDay = Convert.ToDouble(TextBox4.Text);

        Double LowerPrice = 0;
        Double UpperPrice = 0;
        Double Middle = 0;

        UpperPrice = NowPrice * Math.Pow(1 + WaveRate / 16, DueDay / 3);
        LowerPrice = NowPrice * Math.Pow(1 - WaveRate / 16, DueDay / 3);
        Label31.Text = UpperPrice.ToString("N0");
        Label30.Text = LowerPrice.ToString("N0");
        Label2.Text = Middle.ToString("N0");


        LowerPrice = Math.Round((LowerPrice-25 )/ 50, MidpointRounding.AwayFromZero) * 50;
        UpperPrice = Math.Round((UpperPrice+25) / 50, MidpointRounding.AwayFromZero) * 50;


        Label33.Text = UpperPrice.ToString("N0");
        Label32.Text = LowerPrice.ToString("N0");
        Middle = (LowerPrice + UpperPrice)/2;
        Label2.Text = Middle.ToString("N0");
        #endregion
       

        GridView1.DataSource = ds_temp;


        GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GridView gv = new GridView();

        if (!CheckBox1.Checked)
        {


            sql_temp = @" 

SELECT t.DUE_TIME, t.TRADE_TYPE, PRODUCT_TYPE, ROUND(SUM(PRICE*OI_CHANG)/SUM(OI_CHANG),2) AS OICHANG_COST_PRICE
FROM OP_MODIFIED AS t where 1=1
{0}
{1} 
{2}
And t.TRADE_TIME='一般' And t.PRICE<>'-' And t.OI<>'-' 

GROUP BY t.DUE_TIME, t.TRADE_TYPE, PRODUCT_TYPE
having SUM(OI_CHANG)>0
ORDER BY t.DUE_TIME, t.PRODUCT_TYPE;


";

            //And t.DUE_TIME='201905W4'
            if (!txtCalendar1.Text.Equals(""))
            {
                condition1 = @" and format(t.SHIFT_DATE,'yyyy/MM/dd')>='" + txtCalendar1.Text + "'     ";
            }
            if (!txtCalendar2.Text.Equals(""))
            {
                condition2 = @" and format(t.SHIFT_DATE,'yyyy/MM/dd')<='" + txtCalendar2.Text + "'     ";
            }
            if (!DropDownList2.SelectedValue.Equals(""))
            {
                condition3 = @" and DUE_TIME='" + DropDownList2.SelectedValue + "'    ";
            }

            sql_temp = string.Format(sql_temp, condition1, condition2, condition3);
            ds_temp = func.get_dataSet_access(sql_temp, conn);
        }
        else
        {
            callsql = @" 

SELECT t.DUE_TIME,  t.PRODUCT_TYPE, ROUND(SUM(PRICE*OI_CHANG)/SUM(OI_CHANG),2) AS OICHANG_COST_PRICE
FROM OP_MODIFIED AS t where 1=1
{0}
{1} 
{2}
And t.TRADE_TIME='一般' And t.PRICE<>'-' And t.OI<>'-' 
And TRADE_TYPE='買權'
GROUP BY t.DUE_TIME, t.TRADE_TYPE, PRODUCT_TYPE
having SUM(OI_CHANG)>0
ORDER BY t.DUE_TIME, t.PRODUCT_TYPE


";

            //And t.DUE_TIME='201905W4'
            if (!txtCalendar1.Text.Equals(""))
            {
                condition1 = @" and format(t.SHIFT_DATE,'yyyy/MM/dd')>='" + txtCalendar1.Text + "'     ";
            }
            if (!txtCalendar2.Text.Equals(""))
            {
                condition2 = @" and format(t.SHIFT_DATE,'yyyy/MM/dd')<='" + txtCalendar2.Text + "'     ";
            }
            if (!DropDownList2.SelectedValue.Equals(""))
            {
                condition3 = @" and DUE_TIME='" + DropDownList2.SelectedValue + "'    ";
            }

            callsql = string.Format(callsql, condition1, condition2, condition3);


            putsql = @" 

SELECT t.DUE_TIME, t.PRODUCT_TYPE, ROUND(SUM(t.PRICE*OI_CHANG)/SUM(t.OI_CHANG),2) AS OICHANG_COST_PRICE
FROM OP_MODIFIED AS t where 1=1
{0}
{1} 
{2}
And t.TRADE_TIME='一般' And t.PRICE<>'-' And t.OI<>'-' 
And TRADE_TYPE='賣權'
GROUP BY t.DUE_TIME, t.TRADE_TYPE, PRODUCT_TYPE
having SUM(OI_CHANG)>0
ORDER BY t.DUE_TIME, t.PRODUCT_TYPE


";

            //And t.DUE_TIME='201905W4'
            if (!txtCalendar1.Text.Equals(""))
            {
                condition1 = @" and format(t.SHIFT_DATE,'yyyy/MM/dd')>='" + txtCalendar1.Text + "'     ";
            }
            if (!txtCalendar2.Text.Equals(""))
            {
                condition2 = @" and format(t.SHIFT_DATE,'yyyy/MM/dd')<='" + txtCalendar2.Text + "'     ";
            }
            if (!DropDownList2.SelectedValue.Equals(""))
            {
                condition3 = @" and DUE_TIME='" + DropDownList2.SelectedValue + "'    ";
            }

            putsql = string.Format(putsql, condition1, condition2, condition3);

            string initialprice = TextBox1.Text;
            if (!CheckBox2.Checked)
            {

                combinesql = @"   select oa.DUE_TIME,oa.OICHANG_COST_PRICE as call_price,oa.PRODUCT_TYPE,(oa.PRODUCT_TYPE+oa.OICHANG_COST_PRICE-ob.OICHANG_COST_PRICE)as cal_index,ob.OICHANG_COST_PRICE as put_price from ({0}) oa ,({1})ob   
                          where  oa.PRODUCT_TYPE=ob.PRODUCT_TYPE
                           order by oa.PRODUCT_TYPE";
            }
            else
            {

                combinesql = @"   select oa.DUE_TIME,  IIf((oa.PRODUCT_TYPE+oa.OICHANG_COST_PRICE-ob.OICHANG_COST_PRICE)-{2}<0, oa.OICHANG_COST_PRICE+50, oa.OICHANG_COST_PRICE)  as call_price
                                  
                                 ,oa.PRODUCT_TYPE,(oa.PRODUCT_TYPE+oa.OICHANG_COST_PRICE-ob.OICHANG_COST_PRICE)as cal_index,ob.OICHANG_COST_PRICE  as put_price from ({0}) oa ,({1})ob   
                          where  oa.PRODUCT_TYPE=ob.PRODUCT_TYPE
                           order by oa.PRODUCT_TYPE";

            }


            combinesql = string.Format(combinesql, callsql, putsql, initialprice);


            ds_temp = func.get_dataSet_access(combinesql, conn);

         


        }
        





        gv.DataSource = ds_temp;
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
        filename = "op_cost_" + today_detail_char + ".xls";
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
    
    protected void Button3_Click(object sender, EventArgs e)
    {

        //--註解：網站上的目錄路徑。所以不寫磁碟名稱（不寫 “實體”路徑）。
        //string saveDir = "ddd";
        //string appPath = Request.PhysicalApplicationPath;

        //string tempfileName = "";
        System.Text.StringBuilder myLabel = new System.Text.StringBuilder();
        ////如果事先宣告 using System.Text;
        ////便可改寫成 StringBuilder myLabel = new StringBuilder();

        //for(int i = 1; i <= Request.Files.Count; i++)
        //{
        //    FileUpload myFL = new FileUpload();
        //    myFL = (FileUpload)Page.FindControl("FileUpload" + i);

        //    if (myFL.HasFile) {
        //        string fileName = myFL.FileName;
        //        string pathToCheck = appPath + saveDir + fileName;

        //        //===========================================(Start)

        //  if (!System.IO.File.Exists(pathToCheck))

        //  {
        //            int my_counter  = 2;
        //            while (System.IO.File.Exists(pathToCheck))
        //            {
        //                //--檔名相同的話，目前上傳的檔名（改成 tempfileName），
        //                //  前面會用數字來代替。
        //                tempfileName = my_counter.ToString() + "_" + fileName;
        //                pathToCheck = appPath + saveDir + tempfileName;
        //                my_counter = my_counter + 1;
        //            }
        //            fileName = tempfileName;
        //            Label1.Text += "<br>抱歉，您上傳的檔名發生衝突，檔名修改如下---- " + fileName;

        //        //-- 完成檔案上傳的動作。
        //        string savePath = appPath + saveDir + fileName;
        //        myFL.SaveAs(savePath);


        //  }



        //        //===========================================(End)
        // myLabel.Append("<hr>檔名---- " + fn );
        //    }
        //}

        //Label2.Text = "上傳成功" + myLabel.ToString();
        string strSql123 = "";
        string sql_insert = "";
        for (int i = 1; i <= Request.Files.Count; i++)
        {
            FileUpload myFL = new FileUpload();
            myFL = (FileUpload)this.Master.FindControl("ContentPlaceHolder1").FindControl("FileUpload" + i);
            //myFL = this.Master.FindControl("FileUpload" + i);
           // myFL = (FileUpload)Page.FindControl("FileUpload" + i);
            if (myFL.PostedFile.ContentLength < 15360000)
            //if (myFL.PostedFile.ContentLength < 30720000)
            {

                if ((myFL.PostedFile != null) && (myFL.PostedFile.ContentLength > 0))
                {

                    string fn = System.IO.Path.GetFileName(myFL.PostedFile.FileName);
                    // string SaveLocation = Server.MapPath("../") + "\\upload_file\\" + fn;
                    string SaveLocation = HttpContext.Current.Server.MapPath("~/FILE/") + fn;
                    int file_size = myFL.PostedFile.ContentLength;
                    string file_type = myFL.PostedFile.ContentType;
                    try
                    {
                        myFL.PostedFile.SaveAs(SaveLocation);


                        DataTable dtmp = new DataTable();
                        dtmp = OpenCSV(HttpContext.Current.Server.MapPath("~/File/" + fn));

                        for (int j = 0; j <= dtmp.Rows.Count - 1; j++)
			            {
			 
                               sql_insert = @"insert into op_price 
                                              (交易日期,契約,到期月份,履約價,買賣權,開盤價,最高價,最低價,收盤價,成交量,結算價,未沖銷契約數,最後最佳買價,最後最佳賣價,歷史最高價,歷史最低價,是否因訊息面暫停交易,交易時段)
                                              
                                         values( '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}');

                                               
                                              

                                             ";


                               sql_insert = string.Format(sql_insert, dtmp.Rows[j][0].ToString(), dtmp.Rows[j][1].ToString(), dtmp.Rows[j][2].ToString(), dtmp.Rows[j][3].ToString(), dtmp.Rows[j][4].ToString(), dtmp.Rows[j][5].ToString(), dtmp.Rows[j][6].ToString(), dtmp.Rows[j][7].ToString(), dtmp.Rows[j][8].ToString(), dtmp.Rows[j][9].ToString(), dtmp.Rows[j][10].ToString(), dtmp.Rows[j][11].ToString(), dtmp.Rows[j][12].ToString(), dtmp.Rows[j][13].ToString(), dtmp.Rows[j][14].ToString(), dtmp.Rows[j][15].ToString(), dtmp.Rows[j][16].ToString(), dtmp.Rows[j][17].ToString());

                               func.get_sql_execute(sql_insert, conn);

                              
                          }

                          //sql_insert = @" DELETE from  op_price where ID NOT IN (Select min(ID) From op_price Group By 交易日期,契約,到期月份,履約價,買賣權,開盤價,最高價,最低價,收盤價)";

                          //func.get_sql_execute(sql_insert, conn);

                    }
                    catch (Exception Ex)
                    {
                        Response.Write("上傳檔案失敗");
                    }
                }
            }

            else
            {
                //Label3.Visible = true;
                //Label3.Text = "上傳檔案超過15MB...";

            }




           


        }

       
        // parser_data_in_DB();
    }
}
