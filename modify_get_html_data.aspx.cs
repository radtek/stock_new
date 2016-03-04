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

public partial class modify_get_html_data : System.Web.UI.Page
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            txtCalendar1.Text = today;
            TextBox5.Text = "15";
            TextBox2.Text = "Oscar";

            Bind_data();


        }
    }
    public DataTable Bind_data()
    {

        string sql_query = " ";

        sql_query = "  select format(t3.date1,'yyyy/MM/dd')as date1, t3.stock_id, t3.stock_price, t3.flag, t3.email, t3.sn,t3.user_id,t3.interval_time from stock_on_target_report t3  " +
"  where 1=1 ";

        sql_query += " and t3.date1>=format('" + txtCalendar1.Text + "','yyyy/MM/dd')   ";


        if (!TextBox1.Text.Equals(""))
        {
            sql_query += "and t3.stock_id='" + TextBox1.Text + "'                               ";
        }

        if (!TextBox1.Text.Equals(""))
        {
            sql_query += "and t3.stock_id='" + TextBox1.Text + "'                               ";
        }

        if (!TextBox3.Text.Equals(""))
        {
            sql_query += "and Ucase(t3.email) like '%" + TextBox3.Text.ToUpper() + "%'                               ";
        }

        if (!TextBox2.Text.Equals(""))
        {
            sql_query += "and Ucase(t3.user_id)='" + TextBox2.Text.ToUpper() + "'                                ";
        }

        sql_query += "order by t3.sn desc";


        DataSet ds_query = new DataSet();
        ds_query = func.get_dataSet_access(sql_query, conn);
        GridView1.DataSource = ds_query.Tables[0];


        GridView1.DataBind();

        DataTable DT_QUERY = new DataTable();

        DT_QUERY = ds_query.Tables[0];

        return DT_QUERY;

    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        string strTaskID = string.Empty;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            ImageButton btnDel = new ImageButton();
            btnDel = (ImageButton)e.Row.FindControl("btnDel");
            //btnDel.CommandArgument = ((Label)e.Row.FindControl("lblDefectType")).Text;
            btnDel.Attributes["onclick"] = "javascript:return confirm('確認刪除否? 【Stock_id】:" + ((DataRowView)e.Row.DataItem)["stock_id"] + " 【End Time】:" + ((DataRowView)e.Row.DataItem)["date1"] + "【SN】:" + ((DataRowView)e.Row.DataItem)["SN"] + "');";




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
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = id.ToString();
            }

        }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;

        Bind_data();


    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        Int32 snn;
        string snn1 = "";


        //string userid = "oscar";
        //userid = Session["user_id"].ToString();


        //userid = User.Identity.Name.ToUpper();


        GridViewRow row = GridView1.Rows[e.RowIndex];

        if (row.RowState == DataControlRowState.Normal || row.RowState == DataControlRowState.Alternate)
        {
            snn = Convert.ToInt32(((Label)row.FindControl("lblSN")).Text);
        }
        else
        {

            snn = Convert.ToInt32(((Label)row.FindControl("lblSN")).Text);

        }

        //snn1 = ((Label)row.FindControl("lblonclass")).Text;

        if ((row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)) || (row.RowState == DataControlRowState.Edit))
        {

            //if (func.get_ticket(Server.MapPath(".") + "\\verify\\verify.txt", Session["user_id"].ToString()) == "Y")
            //{
            string abc = "";






            abc = "   update stock_on_target_report                " +
"      set date1 = '" + ((TextBox)row.FindControl("lbldate1")).Text + "',           " +
"          stock_id = '" + ((TextBox)row.FindControl("lblstock_id")).Text + "',         " +
"          stock_price = " + ((TextBox)row.FindControl("lblstock_price")).Text + ",            " +
"          flag = '" + ((TextBox)row.FindControl("lblflag")).Text + "',       " +
"          email = '" + ((TextBox)row.FindControl("lblemail")).Text + "',          " +
"          user_id = '" + ((TextBox)row.FindControl("lbluser_id")).Text + "',          " +
"          interval_time = '" + ((TextBox)row.FindControl("lblinterval_time")).Text + "',          " +
 "          dttm = '" + today_detail + "'          " +

"                                  " +
"    where sn=" + snn + "                  ";


            func.get_sql_execute(abc, conn);
            GridView1.EditIndex = -1;




            //}
            //else
            //{

            //    Response.Write("<script language='javascript'>" + "\n");
            //    Response.Write("alert('工號:[" + Session["user_id"] + "],沒有權限!!!');");
            //    Response.Write("</script>");
            //    return;
            //}

            Bind_data();

        }


    }


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        string strSql = "";
        string snn;
        // string snn1;
        GridViewRow row = GridView1.Rows[e.RowIndex];

        if (row.RowState == DataControlRowState.Normal || row.RowState == DataControlRowState.Alternate)
        {
            snn = ((Label)row.FindControl("lblSN")).Text;
            //snn1 = ((Label)row.FindControl("lblaid2")).Text;

        }

        else
        {
            snn = ((Label)row.FindControl("lblSN")).Text;
            // snn1 = ((Label)row.FindControl("lblaid2_Edit")).Text;

        }

        strSql = "delete from stock_on_target_report where SN=" + snn + "";
        func.get_sql_execute(strSql, conn);
        GridView1.EditIndex = -1;


        Bind_data();


    }



    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;


        Bind_data();


    }
    protected void txtDateTo_TextChanged(object sender, EventArgs e)
    {

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Bind_data();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Int32 max_sn = 0;
        sql_temp1 = "select max(sn)as sn from  stock_on_target_report ";
        ds_temp = func.get_dataSet_access(sql_temp1, conn);
        max_sn = Convert.ToInt32(ds_temp.Tables[0].Rows[0]["sn"].ToString());
        max_sn++;

        sql_temp = " INSERT INTO stock_on_target_report (date1, stock_id, stock_price,flag,email,sn,user_id,dttm,interval_time,last_send_time)" +
" VALUES ('" + txtCalendar1.Text + "', '" + TextBox1.Text + "', " + TextBox4.Text + ",'" + DropDownList1.SelectedValue + "','" + TextBox3.Text + "'," + max_sn + ",'" + TextBox2.Text + "','" + today_detail + "'," + TextBox5.Text + ",'" + today_detail + "')                                       ";

        func.get_sql_execute(sql_temp, conn);

        Bind_data();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        sql_temp3 = " select t.mail  from stock_user t where  t.expire_date>= format('" + today + "','yyyy/MM/dd') and  t.mail  is not null";

        mail_list = func.MergeMailListToString(sql_temp3, conn, "mail");
        TextBox3.Text = mail_list;
    }
}
