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
using System.Globalization;

public partial class virtual_asset : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["jump"];
    string today = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd");

    string today_minus17 = DateTime.Now.AddDays(-17).ToString("yyyy/MM/dd");

    string today_detail = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd HH:mm");
    string sql_temp = "";
    string sql_temp1 = "";
    string sql_temp2 = "";
    string sql_temp3 = "";
    string sql_temp4 = "";
    string sql_temp5 = "";
    string frmscript = "";
    DataSet ds_temp = new DataSet();
    DataSet ds_temp1 = new DataSet();
    DataSet ds_temp2 = new DataSet();
    DataSet ds_temp3 = new DataSet();
   
    Double user_id_asset = 0;
    Double user_id_can_buy_num = 0;
    Int32 user_id_can_buy_num_max = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind_data_all();
        }
        


    }

    public void bind_data_all()

    {
        sql_temp = "select t.user_id as User_Id,t.left_ASSET as Left_Asset  from virtual_asset_account t  where t.user_id='" + Session["user_id"] + "'";

        Bind_data2(sql_temp, conn);

        sql_temp1 = "select t.sn,t.user_id,t.trade_type,t.stock_id,t.stock_name,t.stock_num,t.buy_total_price,t.buy_price,t.lend_price,t.now_price,t.now_total_price,(t.now_total_price-t.buy_total_price) as now_benefit,format(t.dttm,'yyyy/MM/dd') as dttm,t.trade_mode from virtual_current_buy t";
        sql_temp1 = sql_temp1 + " where  t.finished='F' and t.user_id='" + Session["user_id"] + "'";
        Bind_data1(sql_temp1, conn);
    
    }

    public DataSet Bind_data2(string sqlX, string connx)
    {
        sql_temp = sqlX;




        ds_temp = func.get_dataSet_access(sql_temp, connx);


        GridView2.DataSource = ds_temp.Tables[0];


        GridView2.DataBind();

        user_id_asset = Convert.ToDouble(ds_temp.Tables[0].Rows[0]["Left_Asset"].ToString());

        return ds_temp;

    }


    public DataSet Bind_data1(string sqlX, string connx)
    {
        sql_temp = sqlX;




        ds_temp = func.get_dataSet_access(sql_temp, connx);

        DataTable dt_temp = new DataTable();

        dt_temp = ds_temp.Tables[0];




        // filded data//
        for (int i = 0; i <= dt_temp.Rows.Count - 1; i++)
        {
            dt_temp.Rows[i]["now_price"] = func.Check_function(dt_temp.Rows[i]["Stock_id"].ToString());
            dt_temp.Rows[i]["now_total_price"] = Convert.ToDouble(dt_temp.Rows[i]["now_price"].ToString()) * Convert.ToDouble(dt_temp.Rows[i]["stock_num"].ToString()) * 1000;
            dt_temp.Rows[i]["now_benefit"] = Convert.ToDouble(dt_temp.Rows[i]["now_total_price"].ToString()) - Convert.ToDouble(dt_temp.Rows[i]["buy_total_price"].ToString());

        }

        Double AAA = 0;
        Double BBB = 0;
        object o_Now_total_price = dt_temp.Compute(" sum(Now_total_price) ", "");
        object o_buy_total_price = dt_temp.Compute(" sum(buy_total_price) ", "");

        object o_now_benefit = dt_temp.Compute(" sum(now_benefit) ", "");
        object o_benefit_rate = "0%";

        if (o_buy_total_price.ToString().Equals(""))
        {
            o_Now_total_price = 0;
            o_now_benefit = 0;
            o_buy_total_price = 0;
            o_benefit_rate = "0%";

        }
        else
        {
            AAA = Convert.ToDouble(o_now_benefit);
            BBB = Convert.ToDouble(o_buy_total_price);
            o_benefit_rate = Convert.ToString(Math.Round(AAA / BBB * 100, 2)) + "%";
        }







        // Setup Filter and Sort Criteria 
        //string strExpr = "user_id='' ";
        //string  strSort = "OrderDate DESC";

        // Use the Select method to find all rows matching the filter. 
        //foundRows = myTable.Select(strExpr, strSort); 




        DataRow dRow = dt_temp.NewRow();

        dRow["user_id"] = Session["user_id"];

        dRow["trade_type"] = "盈虧(%)<br>" + o_benefit_rate;

        dRow["buy_total_price"] = o_buy_total_price;
        dRow["Now_total_price"] = o_Now_total_price;
        dRow["now_benefit"] = o_now_benefit;



        dt_temp.Rows.Add(dRow);

        String.Format("{0:0,0}", 38560);
        //"{0:#,0.0}"
        Label2.Text = String.Format("{0:#,0}", o_Now_total_price);
        Label3.Text = String.Format("{0:#,0}", o_buy_total_price);
        Label4.Text = String.Format("{0:#,0}", o_now_benefit);
        Label5.Text = Convert.ToString(o_benefit_rate);


        GridView1.DataSource = dt_temp;


        GridView1.DataBind();

        ds_temp = dt_temp.DataSet;

        return ds_temp;

    }

    public Int32 max_num_can_buy()
    {
        string stock_price_name = "";

        stock_price_name = func.Check_function_price_stock_name(TextBox_buy_stock_id.Text);
        string[] stock_info = stock_price_name.Split(',');

        Label_stock_name.Visible = true;
        Label_stock_price.Visible = true;
        //Label_stock_name.Text = stock_info[1].ToString().Replace("加到投資組合", "");
        // Label_stock_price.Text = stock_info[0].ToString();

        Double temp_stock_price = 0;
        temp_stock_price = Convert.ToDouble(stock_info[0].Trim().ToString());
        user_id_can_buy_num = user_id_asset / (Convert.ToDouble(Label_stock_price.Text.ToString()) * 1000);
        //user_id_can_buy_num=user_id_asset/Convert.ToInt32(Label_stock_price.Text.ToString());
        Int32 temp_stock_num = 0;
        temp_stock_num = (Int32)(user_id_can_buy_num);
        user_id_can_buy_num_max = (Int32)(user_id_can_buy_num);
        temp_stock_num = temp_stock_num;

        //TextBox_stock_num.Text = Convert.ToString(temp_stock_num);

        return user_id_can_buy_num_max;
    }
    public void ButtonQuery_Click(object sender, EventArgs e)
    {
        bind_data_all();
        
        
        string stock_price_name = "";

        stock_price_name = func.Check_function_price_stock_name(TextBox_buy_stock_id.Text);
        string[] stock_info = stock_price_name.Split(',');

        Label_stock_name.Visible = true;
        Label_stock_price.Visible = true;
        Label_stock_name.Text = stock_info[1].ToString().Replace("加到投資組合", "");
        Label_stock_price.Text = stock_info[0].ToString();

        Double temp_stock_price = 0;
        temp_stock_price = Convert.ToDouble(stock_info[0].Trim().ToString());
        user_id_can_buy_num = user_id_asset / (Convert.ToDouble(Label_stock_price.Text.ToString()) * 1000);
        //user_id_can_buy_num=user_id_asset/Convert.ToInt32(Label_stock_price.Text.ToString());
        Int32 temp_stock_num = 0;
        temp_stock_num = (Int32)(user_id_can_buy_num);
        user_id_can_buy_num_max = (Int32)(user_id_can_buy_num);
        temp_stock_num = temp_stock_num;

        TextBox_stock_num.Text = Convert.ToString(temp_stock_num);
        //TextBox_stock_num.Text = Convert.ToString(user_id_can_buy_num);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GridView gv = new GridView();

        sql_temp1 = "select t.sn,t.user_id,t.trade_type,t.stock_id,t.stock_name,t.stock_num,t.buy_total_price,t.buy_price,t.lend_price,t.now_price,t.now_total_price,(t.now_total_price-t.buy_total_price) as now_benefit,format(t.dttm,'yyyy/MM/dd') as dttm,t.trade_mode from virtual_current_buy t";
        sql_temp1 = sql_temp1 + " where  t.finished='F' and t.user_id='" + Session["user_id"] + "'";

        gv.DataSource = Bind_data1(sql_temp1, conn);
        gv.DataBind();
        ExportExcel(gv);

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
            //Int32 priceX = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "price"));

            // Int32 priceX_top = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "avg_hot_price"));
            // Int32 priceX_cur = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Current_price"));

            //string pp = DataBinder.Eval(e.Row.DataItem, "Current_price").ToString();

            //Int32 pricexx = Convert.ToInt32(price1);



            // if (percent_value >0)
            //e.Row.Cells[0].BackColor = Color.Yellow; 
            // e.Row.Cells[6].Style.Add("background-color", "#FFFF80");
            //if (countX > 3)
            //e.Row.Cells[2].Style.Add("background-color", "#95CAFF");
            //if (countX == 3)
            //e.Row.Cells[2].Style.Add("background-color", "#FFFFB3");

            //if (Convert.ToInt32(pp) > priceX)
            //    e.Row.Cells[5].Style.Add("background-color", "#FFFFB3");


            //if (Flag_satus == "Cancel")
            //    e.Row.Cells[6].Style.Add("background-color", "#FF9DFF"); 
            if (e.Row.RowIndex != -1)
            {
                int RN = e.Row.RowIndex + 1;
                e.Row.Cells[1].Text = RN.ToString();
            }

        }
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        // base.VerifyRenderingInServerForm(control); 
    }

    private void ExportExcel(GridView SeriesValuesDataGrid)
    {

        string filename = "";
        string today_detail_char = DateTime.Now.AddDays(+0).ToString("yyyy/MM/ddHHmmss").Replace("/", "");
        filename = "VirtualAsset_" + today_detail_char + ".xls";
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

    public void Button2_Click(object sender, EventArgs e)
    {
        bind_data_all();
        
        Double buy_price = 0;
        Double buy_num = 0;
        Double transation_money = 0;
        Double finish_money = 0;
        Int32 current_sn = 0;

        buy_price = Convert.ToDouble(Label_stock_price.Text.ToString());

        buy_num = Convert.ToDouble(TextBox_stock_num.Text.ToString());

        transation_money = buy_price * buy_num * 1000;

        finish_money = user_id_asset - transation_money;

        sql_temp2 = "select max(t.sn) as sn from virtual_current_buy t ";

        ds_temp2 = func.get_dataSet_access(sql_temp2, conn);

        current_sn = Convert.ToInt32(ds_temp2.Tables[0].Rows[0]["sn"].ToString()) + 1;

        if (buy_num >= 1 && buy_num <= max_num_can_buy())
        {
            sql_temp3 = "insert into virtual_current_buy (SN,user_id,trade_type,stock_id,stock_name,stock_num,buy_total_price,buy_price,lend_price,now_price,now_total_price,benefit,finished,dttm,trade_mode) ";
            sql_temp3 = sql_temp3 + " values(" + current_sn + ",'" + Session["user_id"] + "','現股','" + TextBox_buy_stock_id.Text + "','" + Label_stock_name.Text + "'," + buy_num + "," + transation_money + "," + buy_price + ",0," + buy_price + "," + transation_money + ",0,'F',format('" + today + "','yyyy/MM/dd'),'buy') ";

            func.get_sql_execute(sql_temp3, conn);

            sql_temp3 = "insert into virtual_current_buy_his (SN,user_id,trade_type,stock_id,stock_name,stock_num,buy_total_price,buy_price,lend_price,now_price,now_total_price,benefit,finished,dttm,trade_mode) ";
            sql_temp3 = sql_temp3 + " values(" + current_sn + ",'" + Session["user_id"] + "','現股','" + TextBox_buy_stock_id.Text + "','" + Label_stock_name.Text + "'," + buy_num + "," + transation_money + "," + buy_price + ",0," + buy_price + "," + transation_money + ",0,'F',format('" + today + "','yyyy/MM/dd'),'buy') ";

            func.get_sql_execute(sql_temp3, conn);


            sql_temp3 = "update virtual_asset_account set left_ASSET=" + finish_money + " where user_id='" + Session["user_id"] + "' ";

            func.get_sql_execute(sql_temp3, conn);

            //Response.Write("<script language='javascript' type='text/JavaScript'>\n");
            //Response.Write("alert('交易成功!!');\n");
            //Response.Write("location = 'virtual_asset.aspx';\n");
            //Response.Write("</script>");

            frmscript = @"<script language='javascript' type='text/JavaScript'>
alert('交易成功!!');
location = 'virtual_asset.aspx';
</script>";

            this.Page.RegisterStartupScript("", frmscript);

        }
        else
        {
            //Response.Write("<script language='javascript' type='text/JavaScript'>\n");
            //Response.Write("alert('金額不足!!');\n");
            //Response.Write("location = 'virtual_asset.aspx';\n");
            //Response.Write("</script>");


            frmscript = @"<script language='javascript' type='text/JavaScript'>
alert('金額不足!!');
location = 'virtual_asset.aspx';
</script>";
            this.Page.RegisterStartupScript("", frmscript);

        }





    }
    protected void Button3_Click(object sender, EventArgs e)
    {

        DataTable dt4 = new DataTable();


        func.Table_add_column(dt4, "SN");

        #region get select row to Datatable
        for (int i = 0; i < GridView1.Rows.Count; i++) 
        {
            CheckBox cb1 = (CheckBox)GridView1.Rows[i].Cells[0].FindControl("CheckBox1");

            //Response.Write(i.ToString()+"cb1" + cb1.Checked.ToString()+"<br>");

            if (cb1.Checked)
            {

                DataRow dr_temp = dt4.NewRow();

                dr_temp["SN"] = GridView1.DataKeys[GridView1.Rows[i].RowIndex][0].ToString();


                if (!dr_temp["SN"].ToString().Equals(""))
                {
                    dt4.Rows.Add(dr_temp);
                }
               

            }
        }
        #endregion

            for (int j = 0; j <= dt4.Rows.Count - 1; j++)
            {

                sql_temp = "select t.user_id as User_Id,t.left_ASSET as Left_Asset  from virtual_asset_account t  where t.user_id='" + Session["user_id"] + "'";

                ds_temp1 = func.get_dataSet_access(sql_temp, conn);

                Double user_current_asset = Convert.ToDouble(ds_temp1.Tables[0].Rows[0]["left_ASSET"].ToString());

                sql_temp = "select t.sn,t.user_id,t.trade_type,t.stock_id,t.stock_name,t.stock_num,t.buy_total_price,t.buy_price,t.lend_price,t.now_price,t.now_total_price,t.benefit,format(t.dttm,'yyyy/MM/dd') as dttm,t.trade_mode from virtual_current_buy t ";
                sql_temp = sql_temp + " where 1=1 and t.sn=" + dt4.Rows[j]["SN"].ToString() + " ";
                ds_temp = func.get_dataSet_access(sql_temp, conn);

                //Label_user_id.Text = ds_temp.Tables[0].Rows[0]["user_id"].ToString();
                string stock_idXX = ds_temp.Tables[0].Rows[0]["stock_id"].ToString();


                string snxx = ds_temp.Tables[0].Rows[0]["sn"].ToString();
                string stock_namexx = ds_temp.Tables[0].Rows[0]["stock_name"].ToString();


                string stock_numxx = ds_temp.Tables[0].Rows[0]["stock_num"].ToString();
                Double stock_now_price = Convert.ToDouble(func.Check_function(stock_idXX));

                Double sell_money = Convert.ToDouble(stock_numxx) * stock_now_price * 1000;

                user_current_asset = user_current_asset + sell_money;

                // update virtual_asset_account
                sql_temp2 = "update  virtual_asset_account  set  left_ASSET=" + user_current_asset + "  where user_id='" + Session["user_id"] + "' ";

                func.get_sql_execute(sql_temp2, conn);

                sql_temp3 = "update  virtual_current_buy t  set  t.finished= 'T'  ,t.dttm=format('" + today + "','yyyy/MM/dd') " + "  where t.sn=" + dt4.Rows[j]["SN"].ToString() + " ";

                func.get_sql_execute(sql_temp3, conn);

                sql_temp5 = "select t.sn,t.user_id,t.trade_type,t.stock_id,t.stock_name,t.stock_num,t.buy_total_price,t.buy_price,t.lend_price,t.now_price,t.now_total_price,t.benefit,format(t.dttm,'yyyy/MM/dd') as dttm,t.trade_mode from virtual_current_buy t ";
                sql_temp5 = sql_temp5 + " where 1=1 and t.sn=" + dt4.Rows[j]["SN"].ToString() + " and t.stock_id='" + stock_idXX + "' and t.user_id='" + Session["user_id"] + "'  ";

                ds_temp3 = func.get_dataSet_access(sql_temp5, conn);

                Double global_now_total_price = 0;
                Double global_benefit = 0;

                global_now_total_price = Convert.ToDouble(ds_temp3.Tables[0].Rows[0]["stock_num"].ToString()) * stock_now_price * 1000;




                //Response.Write(global_now_total_price);
                //Response.End();

                global_benefit = global_now_total_price - Convert.ToDouble(ds_temp3.Tables[0].Rows[0]["buy_total_price"].ToString());

                // Response.Write(Convert.ToInt32(global_sn_temp));
                // Response.End();


                sql_temp4 = "insert into virtual_current_buy_his (SN,user_id,trade_type,stock_id,stock_name,stock_num,buy_total_price,buy_price,lend_price,now_price,now_total_price,benefit,finished,dttm,trade_mode) ";
                sql_temp4 = sql_temp4 + " values(" + dt4.Rows[j]["SN"].ToString() + ",'" + Session["user_id"] + "','現股','" + stock_idXX + "','" + ds_temp3.Tables[0].Rows[0]["stock_name"].ToString() + "'," + ds_temp3.Tables[0].Rows[0]["stock_num"].ToString() + "," + ds_temp3.Tables[0].Rows[0]["buy_total_price"].ToString() + "," + ds_temp3.Tables[0].Rows[0]["buy_price"].ToString() + "," + ds_temp3.Tables[0].Rows[0]["lend_price"].ToString() + "," + stock_now_price + "," + global_now_total_price.ToString() + "," + global_benefit.ToString() + ",'T',format('" + today + "','yyyy/MM/dd'),'sell')                              ";
                //Response.Write(sql_temp4);
                //Response.End();
                func.get_sql_execute(sql_temp4, conn);


            }













            string frmClose = @"<script language='javascript' type='text/JavaScript'>
                  alert('勾選賣股票交易成功!!');
                  //window.opener.location=window.opener.location;

                  
                 //window.opener=null; window.close();
                 </script>";
            this.Page.RegisterStartupScript("", frmClose);
            bind_data_all();
      
    }
}
