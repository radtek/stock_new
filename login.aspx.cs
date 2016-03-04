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
using System.Drawing;

public partial class login : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["jump"];
    string sql = "";
    string sql_temp = "";
    DataSet ds_temp = new DataSet();
    DataSet ds_temp1 = new DataSet();
    DateTime dt_expire;
    string today = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd");
    string today_detail = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd HH:mm");

    protected void Page_Load(object sender, EventArgs e)
    {
        //string marquee="";

        //marquee = "<p>歡迎光臨     </p><p> " ;
        //marquee = "<p>歡迎光臨     </p><p> " + Session["user_dept"].ToString() + "</p>   <p> " + Session["user_name"].ToString() + "</p> ";

        Session.Clear();
        //Response.Write( marquee);
       //alarm_scroller.InnerHtml=marquee;
        if (!IsPostBack)
        {
            Label1.Visible = false;
        }
       
        
    }

    public void getBulletinText()
    {
        try
        {
            //DataTable dt = new DataTable();
            string sText = "";
            string sSubject = "";
            string sContext = "";
            sql = "SELECT MARQUEE_ID,format(DATETIME,'yyyy/mm/dd') as date1,LINK,CONTENT,NAME FROM stock_MARQUEE ORDER BY format(DATETIME,'yyyy/mm/dd') DESC";


          ds_temp = func.get_dataSet_access(sql, conn);

            

            for (int i = 0; i <= ds_temp.Tables[0].Rows.Count-1; i++)
            {
                sContext = ds_temp.Tables[0].Rows[i]["CONTENT"].ToString();
                string sMarqueeId = ds_temp.Tables[0].Rows[i]["MARQUEE_ID"].ToString();
                string sTime = ds_temp.Tables[0].Rows[i]["date1"].ToString();
                string sLink = ds_temp.Tables[0].Rows[i]["LINK"].ToString();
                string sname = ds_temp.Tables[0].Rows[i]["NAME"].ToString();

                if (!sLink.Equals(""))
                {
                    sSubject = "<a href='" + sLink + "' target='blank' style='TEXT-DECORATION: underline'><font face='Verdana, Arial, Helvetica, sans-serif' color='#FF0000' size='1'>" + sContext + "</font></a>";

                }
                else
                {
                    sSubject = "<font face='Verdana, Arial, Helvetica, sans-serif' color='#FF0000' size='2'>" + sContext + "</font><br>";

                 


                }
                sText = sText + "<font face='Verdana, Arial, Helvetica, sans-serif' color='#0000ff' size='2'>" + sTime + "<br>"  + sname +"</font>"+ "<br>" + sSubject;
                   
            }

     

            //byte[] bt; 

            //bt = System.Text.Encoding.Default.GetBytes(sText); 
            //string cc = System.Text.Encoding.GetEncoding("BIG5").GetString(bt); 
            //bt = System.Text.Encoding.Convert(System.Text.Encoding.UTF8, System.Text.Encoding.GetEncoding("BIG5"), bt); 
            //string scontent = System.Text.Encoding.Default.GetString(bt); 
            // System.Text.Encoding.UTF8.GetString(scontent); 

            Response.Write(sText);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected DataSet bind_data()
    {
        string sql = " select count(*) as count1 from stock_user t1                             " +
 " where t1.account='" + TextBox1.Text + "' and t1.password='" + TextBox2.Text + "'                                                           ";


        Session["user_id"] = TextBox1.Text;
        //sql += " order by start_time desc ";

        //sql = "select rownum,t.* from (" + sql + ")t  ";

        ds_temp = func.get_dataSet_access(sql, conn);
        
        //GridView1.DataSource = ds_temp;
        //GridView1.DataBind();

       if (Convert.ToInt32(ds_temp.Tables[0].Rows[0]["count1"].ToString()) > 0 )
        {
            DataSet ds_group = new DataSet();
            string sql_group = "select t2.group,t2.expire_date from stock_user t2 " +
             " where t2.account='" + TextBox1.Text + "' and t2.password='" + TextBox2.Text + "'                                                            ";
            ds_group = func.get_dataSet_access(sql_group, conn);
            dt_expire = Convert.ToDateTime(ds_group.Tables[0].Rows[0]["expire_date"].ToString());



            System.DateTime time1 = Convert.ToDateTime(today);
            System.DateTime time2 = dt_expire;


            TimeSpan ts = time2.Subtract(time1);
            Int32 diffm = Convert.ToInt32(ts.TotalDays);

            if (diffm > 0)
            {
                
                if (ds_group.Tables[0].Rows[0]["group"].ToString() == "A")
                {
                    FormsAuthentication.SetAuthCookie(TextBox1.Text, false);
                    Response.Redirect("Stock_strong_volume.aspx");


                }

                if (ds_group.Tables[0].Rows[0]["group"].ToString() == "B")
                {
                    FormsAuthentication.SetAuthCookie(TextBox1.Text, false);
                    Response.Redirect("Stock_strong_volume.aspx");


                }

                if (ds_group.Tables[0].Rows[0]["group"].ToString() == "C")
                {
                    FormsAuthentication.SetAuthCookie(TextBox1.Text, false);
                    Response.Redirect("virtual_asset.aspx");


                }



            }
            else
            {
                Label1.Text = "帳號過期,請續約!!!";
                Label1.Visible = true;
                Label1.ForeColor = Color.Red;
            
            }

          
        }
        else
        {
            Label1.Text = "帳號或密碼輸入錯誤!!!";
            Label1.Visible = true;
            Label1.ForeColor = Color.Red;
        }

        return ds_temp;




    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        bind_data();
    }
}
