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

public partial class epaper_OP_Modifield : System.Web.UI.Page
{


    string conn = System.Configuration.ConfigurationSettings.AppSettings["jump"];
    string today = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd");
    string tomorrow = DateTime.Now.AddDays(+1).ToString("yyyy/MM/dd");

    string today_minus17 = DateTime.Now.AddDays(-60).ToString("yyyy/MM/dd");
    
    string today_detail = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd HH:mm");
    string sql_temp = "";
    string sql_temp1 = "";
    string sql_temp2 = "";

    DataSet ds_temp = new DataSet();
    DataSet ds_temp1 = new DataSet();
    DataSet ds_temp2 = new DataSet();
    Double user_id_stock_price = 0;
    Double user_id_stock_total_price = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        sql_temp = @"SELECT a.到期月份, a.買賣權, a.履約價, a.交易日期, a.收盤價, a.未沖銷契約數, a.交易時段
FROM op_price AS a
WHERE a.交易日期>=format('{0}','yyyy/MM/dd') And a.交易日期<format('{1}','yyyy/MM/dd')  And a.交易時段='一般' And a.收盤價<>'-' And a.未沖銷契約數<>'-' 
ORDER BY a.到期月份, a.買賣權, a.履約價, a.交易日期;
";

        sql_temp = string.Format(sql_temp, today_minus17, tomorrow);

        ds_temp = func.get_dataSet_access(sql_temp, conn);

        string dUE_TIME = "";
        string tRADE_TYPE = "";
        string PRODUCT_TYPE = "";
        string SHIFT_DATE = "";
        string open_interest = "";
        Int32 OI_CHANG = 0;

        string deletesql = @"DELETE FROM OP_MODIFIED   where 1=1 ";

        func.get_sql_execute(deletesql, conn);


        for (int i = 0; i <= ds_temp.Tables[0].Rows.Count - 1; i++)
        {


            if (i == 0 || !PRODUCT_TYPE.Equals(ds_temp.Tables[0].Rows[i]["履約價"].ToString()))
            {
                OI_CHANG = Convert.ToInt32(ds_temp.Tables[0].Rows[i]["未沖銷契約數"].ToString());
                sql_temp1 = @" INSERT INTO OP_MODIFIED (DUE_TIME,TRADE_TYPE	,PRODUCT_TYPE	,SHIFT_DATE	,PRICE	,OI	,TRADE_TIME	,OI_CHANG) 
                            VALUES ('{0}', '{1}', '{2}','{3}','{4}','{5}','{6}','{7}');       ";
                sql_temp1 = string.Format(sql_temp1, ds_temp.Tables[0].Rows[i]["到期月份"].ToString(), ds_temp.Tables[0].Rows[i]["買賣權"].ToString(), ds_temp.Tables[0].Rows[i]["履約價"].ToString(), ds_temp.Tables[0].Rows[i]["交易日期"].ToString(), ds_temp.Tables[0].Rows[i]["收盤價"].ToString(), ds_temp.Tables[0].Rows[i]["未沖銷契約數"].ToString(), ds_temp.Tables[0].Rows[i]["交易時段"].ToString(), OI_CHANG);

            }
            else 


            {

                OI_CHANG = Convert.ToInt32(ds_temp.Tables[0].Rows[i]["未沖銷契約數"].ToString()) - Convert.ToInt32(open_interest);
                sql_temp1 = @" INSERT INTO OP_MODIFIED (DUE_TIME,TRADE_TYPE	,PRODUCT_TYPE	,SHIFT_DATE	,PRICE	,OI	,TRADE_TIME	,OI_CHANG) 
                         VALUES ('{0}', '{1}', '{2}','{3}','{4}','{5}','{6}','{7}');       ";

                sql_temp1 = string.Format(sql_temp1, ds_temp.Tables[0].Rows[i]["到期月份"].ToString(), ds_temp.Tables[0].Rows[i]["買賣權"].ToString(), ds_temp.Tables[0].Rows[i]["履約價"].ToString(), ds_temp.Tables[0].Rows[i]["交易日期"].ToString(), ds_temp.Tables[0].Rows[i]["收盤價"].ToString(), ds_temp.Tables[0].Rows[i]["未沖銷契約數"].ToString(), ds_temp.Tables[0].Rows[i]["交易時段"].ToString(), OI_CHANG);
           
            
            }





            
            func.get_sql_execute(sql_temp1, conn);
            func.write_log("OP_COST_summary", Server.MapPath("..\\") + "\\RUN_LOG\\", "log");
            func.delete_log_file(Server.MapPath("..\\") + "\\RUN_LOG\\", "*.log", -30);
            
            dUE_TIME = ds_temp.Tables[0].Rows[i]["到期月份"].ToString();
            tRADE_TYPE = ds_temp.Tables[0].Rows[i]["買賣權"].ToString();
            PRODUCT_TYPE = ds_temp.Tables[0].Rows[i]["履約價"].ToString();
            open_interest = ds_temp.Tables[0].Rows[i]["未沖銷契約數"].ToString(); 


        }

        //sql_temp1 = "select t.* from virtual_current_buy t where t.finished='F' ";
        //ds_temp2 = func.get_dataSet_access(sql_temp1, conn);

        //for (int i = 0; i <= ds_temp2.Tables[0].Rows.Count - 1; i++)
        //{
        //    user_id_stock_total_price = Convert.ToDouble(ds_temp2.Tables[0].Rows[i]["stock_num"].ToString()) * Convert.ToDouble(ds_temp2.Tables[0].Rows[i]["now_price"].ToString()) * 1000;
        //    sql_temp2 = "update virtual_current_buy t set t.now_total_price='" + user_id_stock_total_price + "' where t.sn=" + ds_temp2.Tables[0].Rows[i]["sn"].ToString() + " ";

        //    func.get_sql_execute(sql_temp2, conn);

        //}

        //Response.Write("<script language='javascript' type='text/JavaScript'>\n");
        //Response.Write("alert('確定關閉視窗!!');\n"); 
        //Response.Write("opener.document.location.reload(); window.opener=null; window.close();\n"); 

        //Response.Write("location = 'onduty_lh_query.aspx';\n"); 

        //Response.Write(" window.navigate(window.location.href);\n"); 

        //Response.Write("window.opener.location=window.opener.location;\n"); 
        //Response.Write("opener.document.location.reload();\n");
        // Response.Write("window.opener=null; window.close();\n");
        //Response.Write("</script>");
        //javascript 語法填入 字串                                                                                                                   
        string frmClose = @"<script language='javascript' type='text/JavaScript'>


window.opener=null; window.open('','_self');window.close();
</script>";

        //呼叫 javascript                                                                                                                            
        this.Page.RegisterStartupScript("", frmClose);



    }

}
