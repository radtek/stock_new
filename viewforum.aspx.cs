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

public partial class viewforum : System.Web.UI.Page
{

    string conn = System.Configuration.ConfigurationSettings.AppSettings["jump"];
    string today = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd");

    string today_minus7 = DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd");

    string today_detail = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd HH:mm");
    string sql_temp = "";
    string sql_temp1 = "";
    DataSet ds_temp = new DataSet();
    DataSet ds_temp1 = new DataSet();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            sql_temp = "select * from (select t.TOPIC_ID,t.TOPIC_NAME,t.TOPIC_ITEM,t.CREATE_USER,format(t.dttm,'yyyy/mm/dd hh:nn')as dttm,(select  format(max(t1.dttm),'yyyy/mm/dd hh:nn') as dttm   from TOPIC t ,RE_TOPIC t1 where  t.topic_id=t1.TOPIC_ID ) as  re_dttm  ,(select  count(t1.TOPIC_ID) from TOPIC t ,RE_TOPIC t1 where  t.topic_id=t1.TOPIC_ID  ) as re_count from TOPIC t ) order by  re_dttm desc,dttm desc ";
            Bind_data1(sql_temp,conn);

        
        }
    }

    public DataSet Bind_data1(string sqlX, string connx)
    {
        sql_temp = sqlX;




        ds_temp = func.get_dataSet_access(sql_temp, connx);


        GridView1.DataSource = ds_temp;


        GridView1.DataBind();



        return ds_temp;

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
            //Double priceX = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "price"));
            // Int32 priceX_top = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "avg_hot_price"));
            // Int32 priceX_cur = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Current_price"));

            //string pp = DataBinder.Eval(e.Row.DataItem, "Current_price").ToString();

            //Int32 pricexx = Convert.ToInt32(price1);



            // if (percent_value >0)
            //e.Row.Cells[0].BackColor = Color.Yellow; 
            // e.Row.Cells[6].Style.Add("background-color", "#FFFF80");
            //if (countX >= 3)
            //    e.Row.Cells[2].Style.Add("background-color", "#95CAFF");
            //if (countX == 2)
            //    e.Row.Cells[2].Style.Add("background-color", "#FFFFB3");

            //if (Convert.ToDouble(pp) > priceX)
            //    e.Row.Cells[4].Style.Add("background-color", "#FF9DFF");


            //if (Flag_satus == "Cancel")
            //    e.Row.Cells[6].Style.Add("background-color", "#FF9DFF"); 
            if (e.Row.RowIndex != -1)
            {
                int RN = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = RN.ToString();
            }

        }
    }
    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddForum.aspx");
    }
}
