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
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

public partial class option_query : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["jump"];
    string today = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd");
    string yesturday = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
    string tomorrow = DateTime.Now.AddDays(+1).ToString("yyyy/MM/dd");
   
    string today_minus4 = DateTime.Now.AddDays(-4).ToString("yyyy/MM/dd");
    string today_minus7 = DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd");
    string today_minus15 = DateTime.Now.AddDays(-15).ToString("yyyy/MM/dd");
    string today_minus30 = DateTime.Now.AddDays(-30).ToString("yyyy/MM/dd");
    string today_add30 = DateTime.Now.AddDays(+30).ToString("yyyyMM");
    string today_detail = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd HH:mm");
    string sql_temp = "";
    string sql_temp1 = "";
    string sql_temp2 = "";
    string sql_temp3 = "";
    string sql_temp4 = "";
    string sql_temp5 = "";
    string combinebo = "";
    string temp_date1 = "";
    string temp_date2 = "";
    string temp_date3 = "";
    string temp_date4 = "";
    string combine = "";
    DataTable dt = new DataTable();
    DataSet ds_temp = new DataSet();
    DataSet ds_temp1 = new DataSet();
    DataSet ds_temp2 = new DataSet();
    DataSet ds_temp3 = new DataSet();
    DataSet ds_temp4 = new DataSet();
    DataSet ds_temp5 = new DataSet();
    Int32 stage1_price = 0;
    Int32 stage1_price_yesturday = 0;
    Int32 stage2_price = 0;
    Int32 stage3_price = 0;
    string UP_down_value = "";

   
    string put_promote_pro_value = "";
    Int32 int_put = 0;
   
    string call_promote_pro_value = "";

    Int32 int_call = 0;

    DateTime strDate = DateTime.Now.AddDays(-1);

    string select_date_add_one = "";
  


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            CheckBox1.Checked = true;
            txtCalendar1.Text = yesturday;
            txtCalendar2.Text = tomorrow;
            
            System.Globalization.DateTimeFormatInfo FInfo = new System.Globalization.DateTimeFormatInfo();
            FInfo.DateSeparator = "/";
            FInfo.TimeSeparator = ":";

            strDate = Convert.ToDateTime(txtCalendar1.Text, FInfo).AddDays(+1);

            select_date_add_one = strDate.ToString("yyyy/MM/dd");

           TextBox1.Text = get_due_date(select_date_add_one);
            //TextBox1.Text = today_add30;

            if (!CheckBox1.Checked)
            {
                sql_temp = @"

         SELECT * from OPTION_DATA tt 
where t.DUE_TIME='{2}' 

and t.dttm=format('{0}','yyyy/MM/dd')


";
            }
            else
            {
                sql_temp = @"

           select tt.DUE_TIME,tt.PRO_VALUE,tt.CP_TYPE,tt.price,tt.volume,tt.OI_volume from ( 

SELECT * from OPTION_DATA tt ,( 
SELECT DUE_TIME,CP_TYPE,max(volume) as volume1,max(OI_volume) as OI_volume1 
FROM OPTION_DATA t 
where t.DUE_TIME='{2}' 
and CP_TYPE='Call' 
and t.dttm=format('{0}','yyyy/MM/dd')

group by DUE_TIME,CP_TYPE) as ot1 
where tt.volume=ot1.volume1 
or tt.OI_volume=ot1.OI_volume1 
and tt.DUE_TIME=ot1.DUE_TIME
and tt.CP_TYPE=ot1.CP_TYPE
union all 


SELECT * from OPTION_DATA tt ,( 
SELECT DUE_TIME,CP_TYPE,max(volume) as volume1,max(OI_volume) as OI_volume1 
FROM OPTION_DATA t 
where t.DUE_TIME='{2}' 
and CP_TYPE='Put'
and t.dttm=format('{0}','yyyy/MM/dd')
 
group by DUE_TIME,CP_TYPE) as ot1 
where tt.volume=ot1.volume1 
or tt.OI_volume=ot1.OI_volume1 

and tt.DUE_TIME=ot1.DUE_TIME
and tt.CP_TYPE=ot1.CP_TYPE
) ot3 

where tt.DUE_TIME='{2}'
order by CInt ( ot3.PRO_VALUE)
";
            }



            sql_temp = string.Format(sql_temp, txtCalendar1.Text, txtCalendar2.Text, TextBox1.Text);

            GridView1.DataSource = Bind_data(sql_temp, conn);
            GridView1.DataBind();

          

            for (int i = 0; i <= Bind_data(sql_temp, conn).Rows.Count-1; i++)
            {
                if (i == 0)
                {
                   // put_promote_duetime = Bind_data(sql_temp, conn).Rows[i]["DUE_TIME"].ToString();
                    put_promote_pro_value = Bind_data(sql_temp, conn).Rows[i]["PRO_VALUE"].ToString();

                  

                   put_promote_pro_value=Convert.ToString((Convert.ToInt32(put_promote_pro_value)-200));
                
                }


                if (i == Bind_data(sql_temp, conn).Rows.Count - 1)
                {

                    //call_promote_duetime = Bind_data(sql_temp, conn).Rows[i]["DUE_TIME"].ToString();
                    call_promote_pro_value = Bind_data(sql_temp, conn).Rows[i]["PRO_VALUE"].ToString();


                    call_promote_pro_value = Convert.ToString((Convert.ToInt32(call_promote_pro_value) +200));
                }


            }


            sql_temp = @"

           select t.DUE_TIME,t.PRO_VALUE,t.CP_TYPE,t.price,t.volume,t.OI_volume from  OPTION_DATA t



where t.DUE_TIME='{2}' 
and 
( CP_TYPE='Put' 
and t.dttm=format('{0}','yyyy/MM/dd')
and t.PRO_VALUE='{3}' )

or

(

t.DUE_TIME='{2}' 
and CP_TYPE='Call' 
and t.dttm=format('{0}','yyyy/MM/dd')
and t.PRO_VALUE='{4}'

)


";

            sql_temp = string.Format(sql_temp, txtCalendar1.Text, txtCalendar2.Text, TextBox1.Text, put_promote_pro_value, call_promote_pro_value);

            GridView2.DataSource = Bind_data(sql_temp, conn);
            GridView2.DataBind();

            Bind_data_add_onedate(select_date_add_one);



            #region MyRegion
            List<string> tempString = new List<string>();

            sql_temp = @" SELECT distinct(t.DUE_TIME) as DUE_TIME from OPTION_DATA t
where t.dttm>=format('{0}','yyyy/MM/dd') ";
            sql_temp = string.Format(sql_temp, today_minus4);
            ds_temp2 = func.get_dataSet_access(sql_temp, conn);

            if (ds_temp2.Tables[0].Rows.Count > 0)
            {
                if (ds_temp2.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i <= ds_temp2.Tables[0].Rows.Count - 1; i++)
                    {

                        tempString.Add(ds_temp2.Tables[0].Rows[i][0].ToString());

                    }
                }
            }


            StringBuilder sb = new StringBuilder();
            sb.Append("<script type='text/javascript'>");
            sb.Append("var testArray = new Array;");
            foreach (string str in tempString)
            {
                sb.Append("testArray.push('" + str + "');");
            }


            //sb.Append(" $( '#TextBox1' ).autocomplete({ source: testArray});");
            sb.Append(" $( '#ctl00_ContentPlaceHolder1_TextBox1' ).autocomplete({ source: testArray});");

            sb.Append("</script>");

            ClientScript.RegisterStartupScript(this.GetType(), "TestArrayScript", sb.ToString());
            #endregion

           
        }
    


    }

    private string get_due_date(string input_date)
    {

        if (Convert.ToInt32(input_date.Substring(8, 2).ToString()) < 15)
        {
            return today.Replace("/","").ToString().Substring(0,6);

        }
        else

        {
            return today_add30.Replace("/", "").ToString().Substring(0, 6);
         
        }


    }

    public void Bind_data_add_onedate( string tmpdate)
    {
        sql_temp = @"

           select tt.DUE_TIME,tt.PRO_VALUE,tt.CP_TYPE,tt.price,tt.volume,tt.OI_volume from ( 

SELECT * from OPTION_DATA tt ,( 
SELECT DUE_TIME,CP_TYPE,max(volume) as volume1,max(OI_volume) as OI_volume1 
FROM OPTION_DATA t 
where t.DUE_TIME='{2}' 
and CP_TYPE='Call' 
and t.dttm=format('{0}','yyyy/MM/dd')

group by DUE_TIME,CP_TYPE) as ot1 
where tt.volume=ot1.volume1 
or tt.OI_volume=ot1.OI_volume1 
and tt.DUE_TIME=ot1.DUE_TIME
and tt.CP_TYPE=ot1.CP_TYPE
union all 


SELECT * from OPTION_DATA tt ,( 
SELECT DUE_TIME,CP_TYPE,max(volume) as volume1,max(OI_volume) as OI_volume1 
FROM OPTION_DATA t 
where t.DUE_TIME='{2}' 
and CP_TYPE='Put'
and t.dttm=format('{0}','yyyy/MM/dd')
 
group by DUE_TIME,CP_TYPE) as ot1 
where tt.volume=ot1.volume1 
or tt.OI_volume=ot1.OI_volume1 

and tt.DUE_TIME=ot1.DUE_TIME
and tt.CP_TYPE=ot1.CP_TYPE
) ot3 

where tt.DUE_TIME='{2}'
order by CInt ( ot3.PRO_VALUE)
";




        sql_temp = string.Format(sql_temp, tmpdate, txtCalendar2.Text, TextBox1.Text);

            GridView3.DataSource = Bind_data(sql_temp, conn);
            GridView3.DataBind();

          

            for (int i = 0; i <= Bind_data(sql_temp, conn).Rows.Count-1; i++)
            {
                if (i == 0)
                {
                   // put_promote_duetime = Bind_data(sql_temp, conn).Rows[i]["DUE_TIME"].ToString();
                    put_promote_pro_value = Bind_data(sql_temp, conn).Rows[i]["PRO_VALUE"].ToString();

                  

                   put_promote_pro_value=Convert.ToString((Convert.ToInt32(put_promote_pro_value)-200));
                
                }


                if (i == Bind_data(sql_temp, conn).Rows.Count - 1)
                {

                    //call_promote_duetime = Bind_data(sql_temp, conn).Rows[i]["DUE_TIME"].ToString();
                    call_promote_pro_value = Bind_data(sql_temp, conn).Rows[i]["PRO_VALUE"].ToString();


                    call_promote_pro_value = Convert.ToString((Convert.ToInt32(call_promote_pro_value) +200));
                }


            }


            sql_temp = @"

           select t.DUE_TIME,t.PRO_VALUE,t.CP_TYPE,t.price,t.volume,t.OI_volume from  OPTION_DATA t



where t.DUE_TIME='{2}' 
and 
( CP_TYPE='Put' 
and t.dttm=format('{0}','yyyy/MM/dd')
and t.PRO_VALUE='{3}' )

or

(

t.DUE_TIME='{2}' 
and CP_TYPE='Call' 
and t.dttm=format('{0}','yyyy/MM/dd')
and t.PRO_VALUE='{4}'

)


";

            sql_temp = string.Format(sql_temp, tmpdate, txtCalendar2.Text, TextBox1.Text, put_promote_pro_value, call_promote_pro_value);

            GridView4.DataSource = Bind_data(sql_temp, conn);
            GridView4.DataBind();




    }


    protected void ButtonQuery_Click(object sender, EventArgs e)
    {


        if (!CheckBox1.Checked)
        {

            sql_temp = @"



SELECT * from OPTION_DATA t
where t.DUE_TIME='{2}' 

and t.dttm=format('{0}','yyyy/MM/dd')




";
        }
        else
        {

            sql_temp = @"

             
           select tt.DUE_TIME,tt.PRO_VALUE,tt.CP_TYPE,tt.price,tt.volume,tt.OI_volume from ( 

SELECT * from OPTION_DATA tt ,( 
SELECT DUE_TIME,CP_TYPE,max(volume) as volume1,max(OI_volume) as OI_volume1 
FROM OPTION_DATA t 
where t.DUE_TIME='{2}' 
and CP_TYPE='Call' 
and t.dttm=format('{0}','yyyy/MM/dd')

group by DUE_TIME,CP_TYPE) as ot1 
where tt.volume=ot1.volume1 
or tt.OI_volume=ot1.OI_volume1 
and tt.DUE_TIME=ot1.DUE_TIME
and tt.CP_TYPE=ot1.CP_TYPE
union all 


SELECT * from OPTION_DATA tt ,( 
SELECT DUE_TIME,CP_TYPE,max(volume) as volume1,max(OI_volume) as OI_volume1 
FROM OPTION_DATA t 
where t.DUE_TIME='{2}' 
and CP_TYPE='Put'
and t.dttm=format('{0}','yyyy/MM/dd')

group by DUE_TIME,CP_TYPE) as ot1 
where tt.volume=ot1.volume1 
or tt.OI_volume=ot1.OI_volume1 
and tt.DUE_TIME=ot1.DUE_TIME
and tt.CP_TYPE=ot1.CP_TYPE
) ot3 
where tt.DUE_TIME='{2}'
order by CInt ( ot3.PRO_VALUE)
";

        }

        sql_temp = string.Format(sql_temp, txtCalendar1.Text, txtCalendar2.Text, TextBox1.Text);

        ds_temp = func.get_dataSet_access(sql_temp, conn);
        dt = ds_temp.Tables[0];
        GridView1.DataSource = dt;
        GridView1.DataBind();


        for (int i = 0; i <= Bind_data(sql_temp, conn).Rows.Count - 1; i++)
        {
            if (i == 0)
            {
                // put_promote_duetime = Bind_data(sql_temp, conn).Rows[i]["DUE_TIME"].ToString();
                put_promote_pro_value = Bind_data(sql_temp, conn).Rows[i]["PRO_VALUE"].ToString();



                put_promote_pro_value = Convert.ToString((Convert.ToInt32(put_promote_pro_value) - 200));

            }


            if (i == Bind_data(sql_temp, conn).Rows.Count - 1)
            {

                //call_promote_duetime = Bind_data(sql_temp, conn).Rows[i]["DUE_TIME"].ToString();
                call_promote_pro_value = Bind_data(sql_temp, conn).Rows[i]["PRO_VALUE"].ToString();


                call_promote_pro_value = Convert.ToString((Convert.ToInt32(call_promote_pro_value) + 200));
            }


        }


        sql_temp = @"

           select t.DUE_TIME,t.PRO_VALUE,t.CP_TYPE,t.price,t.volume,t.OI_volume from  OPTION_DATA t



where t.DUE_TIME='{2}' 
and 
( CP_TYPE='Put' 
and t.dttm=format('{0}','yyyy/MM/dd')
and t.PRO_VALUE='{3}' )

or

(


 t.DUE_TIME='{2}' 
and CP_TYPE='Call' 
and t.dttm=format('{0}','yyyy/MM/dd')
and t.PRO_VALUE='{4}'

)


";

        sql_temp = string.Format(sql_temp, txtCalendar1.Text, txtCalendar2.Text, TextBox1.Text, put_promote_pro_value, call_promote_pro_value);

        GridView2.DataSource = Bind_data(sql_temp, conn);
        GridView2.DataBind();

        System.Globalization.DateTimeFormatInfo FInfo = new System.Globalization.DateTimeFormatInfo();
        FInfo.DateSeparator = "/";
        FInfo.TimeSeparator = ":";





        strDate = Convert.ToDateTime(txtCalendar1.Text, FInfo).AddDays(+1);

        select_date_add_one = strDate.ToString("yyyy/MM/dd");

        Bind_data_add_onedate(select_date_add_one);

    }
    public DataTable Bind_data(string sqlX, string connx)
    {
        sql_temp = sqlX;







        ds_temp = func.get_dataSet_access(sql_temp, conn);
        dt = ds_temp.Tables[0];

        return dt;

  


    }

 

    

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!CheckBox1.Checked)
        {

            sql_temp = @"



SELECT *,round(HIS_HIGH_PRICE/HIS_LOW_PRICE,0) as ratio from OPTION_DATA t
where t.DUE_TIME='{2}' 
 and t.HIS_HIGH_PRICE>0
and t.dttm=format('{0}','yyyy/MM/dd')




";
        }
        else
        {

            sql_temp = @"

             
           select tt.DUE_TIME,tt.PRO_VALUE,tt.CP_TYPE,tt.price,tt.volume,tt.OI_volume from ( 

SELECT * from OPTION_DATA tt ,( 
SELECT DUE_TIME,CP_TYPE,max(volume) as volume1,max(OI_volume) as OI_volume1 
FROM OPTION_DATA t 
where t.DUE_TIME='{2}' 
and CP_TYPE='Call' 
and t.dttm=format('{0}','yyyy/MM/dd')

group by DUE_TIME,CP_TYPE) as ot1 
where tt.volume=ot1.volume1 
or tt.OI_volume=ot1.OI_volume1 
and tt.DUE_TIME=ot1.DUE_TIME
and tt.CP_TYPE=ot1.CP_TYPE
union all 


SELECT * from OPTION_DATA tt ,( 
SELECT DUE_TIME,CP_TYPE,max(volume) as volume1,max(OI_volume) as OI_volume1 
FROM OPTION_DATA t 
where t.DUE_TIME='{2}' 
and CP_TYPE='Put'
and t.dttm=format('{0}','yyyy/MM/dd')

group by DUE_TIME,CP_TYPE) as ot1 
where tt.volume=ot1.volume1 
or tt.OI_volume=ot1.OI_volume1 
and tt.DUE_TIME=ot1.DUE_TIME
and tt.CP_TYPE=ot1.CP_TYPE
) ot3 
where tt.DUE_TIME='{2}'
order by CInt ( ot3.PRO_VALUE)
";

        }




        sql_temp = string.Format(sql_temp, txtCalendar1.Text, txtCalendar2.Text, TextBox1.Text);



        GridView gv = new GridView();
        gv.DataSource = Bind_data(sql_temp, conn);
        gv.DataBind();
        ExportExcel(gv);
    
    }

    private void ExportExcel(GridView SeriesValuesDataGrid)
    {

        string filename = "";
        string today_detail_char = DateTime.Now.AddDays(+0).ToString("yyyy/MM/ddHHmmss").Replace("/", "");
        filename = "option_query_" + today_detail_char + ".xls";
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

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {



        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            //ImageButton btnDel = new ImageButton(); 
            //btnDel = (ImageButton)e.Row.FindControl("btnDel"); 

            //btnDel.Attributes["onclick"] = "javascript:return confirm('蝣箄芸芷文? 箖tock_id?" + ((DataRowView)e.Row.DataItem)["stock_id"] + " 穊nd Time?" + ((DataRowView)e.Row.DataItem)["date1"] + "箖N?" + ((DataRowView)e.Row.DataItem)["SN"] + "');"; 




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
            //Double priceX = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "price")); 
            // Int32 priceX_top = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "avg_hot_price")); 
            // Int32 priceX_cur = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Current_price")); 






          //  string TPO_LEN = DataBinder.Eval(e.Row.DataItem, "Length").ToString();

          //  Int32 TPOCOUNT = Convert.ToInt32(TPO_LEN);









            //if (percent_value >0) 
            //e.Row.Cells[0].BackColor = Color.Yellow; 
            // e.Row.Cells[6].Style.Add("background-color", "#FFFF80"); 
            //if (countX >= 3) 
            // e.Row.Cells[2].Style.Add("background-color", "#95CAFF"); 
            //if (countX == 2) 
            // e.Row.Cells[2].Style.Add("background-color", "#FFFFB3"); 







            //if (TPOCOUNT >= 4)
            //    for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
            //    {
            //        e.Row.Cells[i].Style.Add("background-color", "#F8E085");

            //    }

            //string merge_LEN = DataBinder.Eval(e.Row.DataItem, "MERGE").ToString();

            //if (merge_LEN.IndexOf("A") >= 0 | merge_LEN.IndexOf("B") >= 0)
            //{
            //    for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
            //    {
            //        if (i > e.Row.Cells.Count - 1 - 3)
            //        {
            //            e.Row.Cells[i].Style.Add("background-color", "#DDDDFF");
            //        }


            //    }

            //}






            //if (percent_value >0) 
            //e.Row.Cells[0].BackColor = Color.Yellow; 
            // e.Row.Cells[6].Style.Add("background-color", "#FFFF80"); 
            //if (countX >= 3) 
            // e.Row.Cells[2].Style.Add("background-color", "#95CAFF"); 
            //if (countX == 2) 
            // e.Row.Cells[2].Style.Add("background-color", "#FFFFB3"); 




            //if (Flag_satus == "Cancel") 
            // e.Row.Cells[6].Style.Add("background-color", "#FF9DFF"); 
            if (e.Row.RowIndex != -1)
            {
                int RN = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = RN.ToString();
            }

        }
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {



        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            //ImageButton btnDel = new ImageButton(); 
            //btnDel = (ImageButton)e.Row.FindControl("btnDel"); 

            //btnDel.Attributes["onclick"] = "javascript:return confirm('蝣箄芸芷文? 箖tock_id?" + ((DataRowView)e.Row.DataItem)["stock_id"] + " 穊nd Time?" + ((DataRowView)e.Row.DataItem)["date1"] + "箖N?" + ((DataRowView)e.Row.DataItem)["SN"] + "');"; 




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
            //Double priceX = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "price")); 
            // Int32 priceX_top = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "avg_hot_price")); 
            // Int32 priceX_cur = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Current_price")); 






            //  string TPO_LEN = DataBinder.Eval(e.Row.DataItem, "Length").ToString();

            //  Int32 TPOCOUNT = Convert.ToInt32(TPO_LEN);









            //if (percent_value >0) 
            //e.Row.Cells[0].BackColor = Color.Yellow; 
            // e.Row.Cells[6].Style.Add("background-color", "#FFFF80"); 
            //if (countX >= 3) 
            // e.Row.Cells[2].Style.Add("background-color", "#95CAFF"); 
            //if (countX == 2) 
            // e.Row.Cells[2].Style.Add("background-color", "#FFFFB3"); 







            //if (TPOCOUNT >= 4)
            //    for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
            //    {
            //        e.Row.Cells[i].Style.Add("background-color", "#F8E085");

            //    }

            //string merge_LEN = DataBinder.Eval(e.Row.DataItem, "MERGE").ToString();

            //if (merge_LEN.IndexOf("A") >= 0 | merge_LEN.IndexOf("B") >= 0)
            //{
            //    for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
            //    {
            //        if (i > e.Row.Cells.Count - 1 - 3)
            //        {
            //            e.Row.Cells[i].Style.Add("background-color", "#DDDDFF");
            //        }


            //    }

            //}






            //if (percent_value >0) 
            //e.Row.Cells[0].BackColor = Color.Yellow; 
            // e.Row.Cells[6].Style.Add("background-color", "#FFFF80"); 
            //if (countX >= 3) 
            // e.Row.Cells[2].Style.Add("background-color", "#95CAFF"); 
            //if (countX == 2) 
            // e.Row.Cells[2].Style.Add("background-color", "#FFFFB3"); 




            //if (Flag_satus == "Cancel") 
            // e.Row.Cells[6].Style.Add("background-color", "#FF9DFF"); 
            if (e.Row.RowIndex != -1)
            {
                int RN = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = RN.ToString();
            }

        }
    }

    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {



        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            //ImageButton btnDel = new ImageButton(); 
            //btnDel = (ImageButton)e.Row.FindControl("btnDel"); 

            //btnDel.Attributes["onclick"] = "javascript:return confirm('蝣箄芸芷文? 箖tock_id?" + ((DataRowView)e.Row.DataItem)["stock_id"] + " 穊nd Time?" + ((DataRowView)e.Row.DataItem)["date1"] + "箖N?" + ((DataRowView)e.Row.DataItem)["SN"] + "');"; 




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
            //Double priceX = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "price")); 
            // Int32 priceX_top = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "avg_hot_price")); 
            // Int32 priceX_cur = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Current_price")); 






            //  string TPO_LEN = DataBinder.Eval(e.Row.DataItem, "Length").ToString();

            //  Int32 TPOCOUNT = Convert.ToInt32(TPO_LEN);









            //if (percent_value >0) 
            //e.Row.Cells[0].BackColor = Color.Yellow; 
            // e.Row.Cells[6].Style.Add("background-color", "#FFFF80"); 
            //if (countX >= 3) 
            // e.Row.Cells[2].Style.Add("background-color", "#95CAFF"); 
            //if (countX == 2) 
            // e.Row.Cells[2].Style.Add("background-color", "#FFFFB3"); 







            //if (TPOCOUNT >= 4)
            //    for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
            //    {
            //        e.Row.Cells[i].Style.Add("background-color", "#F8E085");

            //    }

            //string merge_LEN = DataBinder.Eval(e.Row.DataItem, "MERGE").ToString();

            //if (merge_LEN.IndexOf("A") >= 0 | merge_LEN.IndexOf("B") >= 0)
            //{
            //    for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
            //    {
            //        if (i > e.Row.Cells.Count - 1 - 3)
            //        {
            //            e.Row.Cells[i].Style.Add("background-color", "#DDDDFF");
            //        }


            //    }

            //}






            //if (percent_value >0) 
            //e.Row.Cells[0].BackColor = Color.Yellow; 
            // e.Row.Cells[6].Style.Add("background-color", "#FFFF80"); 
            //if (countX >= 3) 
            // e.Row.Cells[2].Style.Add("background-color", "#95CAFF"); 
            //if (countX == 2) 
            // e.Row.Cells[2].Style.Add("background-color", "#FFFFB3"); 




            //if (Flag_satus == "Cancel") 
            // e.Row.Cells[6].Style.Add("background-color", "#FF9DFF"); 
            if (e.Row.RowIndex != -1)
            {
                int RN = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = RN.ToString();
            }

        }
    }
    protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
    {



        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            //ImageButton btnDel = new ImageButton(); 
            //btnDel = (ImageButton)e.Row.FindControl("btnDel"); 

            //btnDel.Attributes["onclick"] = "javascript:return confirm('蝣箄芸芷文? 箖tock_id?" + ((DataRowView)e.Row.DataItem)["stock_id"] + " 穊nd Time?" + ((DataRowView)e.Row.DataItem)["date1"] + "箖N?" + ((DataRowView)e.Row.DataItem)["SN"] + "');"; 




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
            //Double priceX = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "price")); 
            // Int32 priceX_top = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "avg_hot_price")); 
            // Int32 priceX_cur = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Current_price")); 






            //  string TPO_LEN = DataBinder.Eval(e.Row.DataItem, "Length").ToString();

            //  Int32 TPOCOUNT = Convert.ToInt32(TPO_LEN);









            //if (percent_value >0) 
            //e.Row.Cells[0].BackColor = Color.Yellow; 
            // e.Row.Cells[6].Style.Add("background-color", "#FFFF80"); 
            //if (countX >= 3) 
            // e.Row.Cells[2].Style.Add("background-color", "#95CAFF"); 
            //if (countX == 2) 
            // e.Row.Cells[2].Style.Add("background-color", "#FFFFB3"); 







            //if (TPOCOUNT >= 4)
            //    for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
            //    {
            //        e.Row.Cells[i].Style.Add("background-color", "#F8E085");

            //    }

            //string merge_LEN = DataBinder.Eval(e.Row.DataItem, "MERGE").ToString();

            //if (merge_LEN.IndexOf("A") >= 0 | merge_LEN.IndexOf("B") >= 0)
            //{
            //    for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
            //    {
            //        if (i > e.Row.Cells.Count - 1 - 3)
            //        {
            //            e.Row.Cells[i].Style.Add("background-color", "#DDDDFF");
            //        }


            //    }

            //}






            //if (percent_value >0) 
            //e.Row.Cells[0].BackColor = Color.Yellow; 
            // e.Row.Cells[6].Style.Add("background-color", "#FFFF80"); 
            //if (countX >= 3) 
            // e.Row.Cells[2].Style.Add("background-color", "#95CAFF"); 
            //if (countX == 2) 
            // e.Row.Cells[2].Style.Add("background-color", "#FFFFB3"); 




            //if (Flag_satus == "Cancel") 
            // e.Row.Cells[6].Style.Add("background-color", "#FF9DFF"); 
            if (e.Row.RowIndex != -1)
            {
                int RN = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = RN.ToString();
            }

        }
    }
//    protected void TextBox1_TextChanged(object sender, EventArgs e)
//    {
//        List<string> tempString = new List<string>();

//        sql_temp = @" SELECT distinct(t.DUE_TIME) as DUE_TIME from OPTION_DATA t
//where t.dttm=format('{0}','yyyy/MM/dd') ";
//        sql_temp = string.Format(sql_temp, txtCalendar1.Text);
//        ds_temp2 = func.get_dataSet_access(sql_temp, conn);

//        if (ds_temp2.Tables[0].Rows.Count > 0)
//        {
//            if (ds_temp2.Tables[0].Rows.Count > 0)
//            {

//                for (int i = 0; i <= ds_temp2.Tables[0].Rows.Count - 1; i++)
//                {

//                    tempString.Add(ds_temp2.Tables[0].Rows[i][0].ToString());

//                }
//            }
//        }


//        StringBuilder sb = new StringBuilder();
//        sb.Append("<script type='text/javascript'>");
//        sb.Append("var testArray = new Array;");
//        foreach (string str in tempString)
//        {
//            sb.Append("testArray.push('" + str + "');");
//        }



//        sb.Append(" $( '#ctl00$ContentPlaceHolder1$TextBox1' ).autocomplete({ source: testArray});");


//        sb.Append("</script>");

//        ClientScript.RegisterStartupScript(this.GetType(), "TestArrayScript", sb.ToString());
//    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        #region MyRegion
        List<string> tempString = new List<string>();

        sql_temp = @" SELECT distinct(t.DUE_TIME) as DUE_TIME from OPTION_DATA t
where t.dttm>=format('{0}','yyyy/MM/dd') ";
        sql_temp = string.Format(sql_temp, today_minus4);
        ds_temp2 = func.get_dataSet_access(sql_temp, conn);

        if (ds_temp2.Tables[0].Rows.Count > 0)
        {
            if (ds_temp2.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i <= ds_temp2.Tables[0].Rows.Count - 1; i++)
                {

                    tempString.Add(ds_temp2.Tables[0].Rows[i][0].ToString());

                }
            }
        }


        StringBuilder sb = new StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append("var testArray = new Array;");
        foreach (string str in tempString)
        {
            sb.Append("testArray.push('" + str + "');");
        }


        //sb.Append(" $( '#TextBox1' ).autocomplete({ source: testArray});");
        sb.Append(" $( '#ctl00_ContentPlaceHolder1_TextBox1' ).autocomplete({ source: testArray});");

        sb.Append("</script>");

        ClientScript.RegisterStartupScript(this.GetType(), "TestArrayScript", sb.ToString());
        #endregion

    }
}
