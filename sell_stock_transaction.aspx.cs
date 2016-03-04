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


public partial class sell_stock_transaction : System.Web.UI.Page
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

    DataSet ds_temp = new DataSet();
    DataSet ds_temp1 = new DataSet();
    DataSet ds_temp2 = new DataSet();
    DataSet ds_temp3 = new DataSet();
    Double user_id_asset = 0;
    Double user_id_can_buy_num = 0;
    Int32 user_id_can_buy_num_max = 0;
    Double stock_now_price = 0;
    string global_sn_temp = "";
    string global_stock_id_temp = "";
    string global_user_id_temp = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string sn_temp = Request.QueryString["sn"];
        global_sn_temp = sn_temp;
        string stock_id_temp = Request.QueryString["stock_id"];
        global_stock_id_temp = stock_id_temp;
        string user_id_temp = Request.QueryString["user_id"];
        global_user_id_temp = user_id_temp;

        //sn_temp = "1";
        // stock_id_temp = "3043";
        //user_id_temp = "oscar";

        sql_temp = "select t.sn,t.user_id,t.trade_type,t.stock_id,t.stock_name,t.stock_num,t.buy_total_price,t.buy_price,t.lend_price,t.now_price,t.now_total_price,t.benefit,format(t.dttm,'yyyy/MM/dd') as dttm,t.trade_mode from virtual_current_buy t ";
        sql_temp = sql_temp + " where 1=1 and t.sn=" + sn_temp + " and t.stock_id='" + stock_id_temp + "' and t.user_id='" + user_id_temp + "'  ";

        ds_temp = func.get_dataSet_access(sql_temp, conn);

        Label_user_id.Text = ds_temp.Tables[0].Rows[0]["user_id"].ToString();

        Label_stock_id.Text = ds_temp.Tables[0].Rows[0]["stock_id"].ToString();


        Label_SN.Text = ds_temp.Tables[0].Rows[0]["sn"].ToString();
        Label_stock_name.Text = ds_temp.Tables[0].Rows[0]["stock_name"].ToString();


        Label_stock_can_sell_num.Text = ds_temp.Tables[0].Rows[0]["stock_num"].ToString();



        stock_now_price = Convert.ToDouble(func.Check_function(stock_id_temp));
        Label_stock_price.Text = func.Check_function(stock_id_temp).ToString();




    }


    public Int32 Receive_data()
    {
        sql_temp = "select t.sn,t.user_id,t.trade_type,t.stock_id,t.stock_name,t.stock_num,t.buy_total_price,t.buy_price,t.lend_price,t.now_price,t.now_total_price,t.benefit,format(t.dttm,'yyyy/MM/dd') as dttm,t.trade_mode from virtual_current_buy t wherer 1=1";
        sql_temp = sql_temp + "and t.sn=" + Request.QueryString["sn"] + " and t.stock_id='" + Request.QueryString["stock_id"] + "' and t.dttm=format('" + Request.QueryString["dttm"] + "','yyyy/MM/dd') and t.user_id='" + Session["user_id"] + "'  ";

        ds_temp = func.get_dataSet_access(sql_temp, conn);

        //Label_user_id.Text = ds_temp.Tables[0].Rows[0]["user_id"].ToString();

        //Label_stock_id.Text = ds_temp.Tables[0].Rows[0]["stock_id"].ToString();

        //Label_stock_name.Text = ds_temp.Tables[0].Rows[0]["stock_name"].ToString();


        //Label_stock_can_sell_num.Text = ds_temp.Tables[0].Rows[0]["stock_num"].ToString();
        Int32 stock_can_sell_num = Convert.ToInt32(ds_temp.Tables[0].Rows[0]["stock_num"].ToString());
        return stock_can_sell_num;

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        sql_temp = "select t.user_id as User_Id,t.left_ASSET as Left_Asset  from virtual_asset_account t  where t.user_id='" + Label_user_id.Text + "'";

        ds_temp1 = func.get_dataSet_access(sql_temp, conn);

        Double user_current_asset = Convert.ToDouble(ds_temp1.Tables[0].Rows[0]["left_ASSET"].ToString());

        Double sell_money = Convert.ToDouble(Label_stock_can_sell_num.Text) * Convert.ToDouble(Label_stock_price.Text) * 1000;

        user_current_asset = user_current_asset + sell_money;

        sql_temp2 = "update  virtual_asset_account  set  left_ASSET=" + user_current_asset + "  where user_id='" + Label_user_id.Text + "' ";

        func.get_sql_execute(sql_temp2, conn);

        sql_temp3 = "update  virtual_current_buy t  set  t.finished= 'T'  ,t.dttm=format('" + today + "','yyyy/MM/dd') " + "  where t.sn=" + Label_SN.Text + " ";

        func.get_sql_execute(sql_temp3, conn);

        sql_temp5 = "select t.sn,t.user_id,t.trade_type,t.stock_id,t.stock_name,t.stock_num,t.buy_total_price,t.buy_price,t.lend_price,t.now_price,t.now_total_price,t.benefit,format(t.dttm,'yyyy/MM/dd') as dttm,t.trade_mode from virtual_current_buy t ";
        sql_temp5 = sql_temp5 + " where 1=1 and t.sn=" + global_sn_temp + " and t.stock_id='" + global_stock_id_temp + "' and t.user_id='" + global_user_id_temp + "'  ";

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
        sql_temp4 = sql_temp4 + " values(" + global_sn_temp + ",'" + global_user_id_temp + "','現股','" + global_stock_id_temp + "','" + ds_temp3.Tables[0].Rows[0]["stock_name"].ToString() + "'," + ds_temp3.Tables[0].Rows[0]["stock_num"].ToString() + "," + ds_temp3.Tables[0].Rows[0]["buy_total_price"].ToString() + "," + ds_temp3.Tables[0].Rows[0]["buy_price"].ToString() + "," + ds_temp3.Tables[0].Rows[0]["lend_price"].ToString() + "," + Label_stock_price.Text.ToString() + "," + global_now_total_price.ToString() + "," + global_benefit.ToString() + ",'T',format('" + today + "','yyyy/MM/dd'),'sell')                              ";
        //Response.Write(sql_temp4);
        //Response.End();
        func.get_sql_execute(sql_temp4, conn);

    


       string frmClose = @"<script language='javascript' type='text/JavaScript'>
                  alert('賣股票交易成功!!');
                  window.opener.location=window.opener.location;

                  
                 window.opener=null; window.close();
                 </script>";
       this.Page.RegisterStartupScript("", frmClose);  


    }
}
