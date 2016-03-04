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
using System.Diagnostics;
using System.Runtime.InteropServices;

public partial class order_master : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["jump"];
    string today = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd");
    string yesturday = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
    string tomorrow = DateTime.Now.AddDays(+1).ToString("yyyy/MM/dd");

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
    DataTable dt = new DataTable();
    DataSet ds_temp = new DataSet();
    DataSet ds_temp1 = new DataSet();
    DataSet ds_temp2 = new DataSet();
    EWinner.EWinner_InterfaceClass objEwinner;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            CheckBox1.Checked = true;
            txtCalendar1.Text = today;
            txtCalendar2.Text = tomorrow;
            
            TextBox1.Text = "TXO0";
            TextBox2.Text = "0";
            TextBox3.Text = "B";
            TextBox5.Text = "0";
            TextBox4.Text = "M";
            TextBox7.Text = "2";
            if (!CheckBox1.Checked)
            {
                sql_temp = @"

              SELECT  NAME,DATETIMES,Switch (Mid ( t.datetimes, 12, 5 )>'08:45' and  Mid ( t.datetimes, 12, 5 )<='09:15','A',Mid ( t.datetimes, 12, 5 )>'09:15' and  Mid ( t.datetimes, 12, 5 )<='09:45','B',Mid ( t.datetimes, 12, 5 )>'09:45' and  Mid ( t.datetimes, 12, 5 )<='10:15','C',Mid ( t.datetimes, 12, 5 )>'10:15' and  Mid ( t.datetimes, 12, 5 )<='10:45','D',Mid ( t.datetimes, 12, 5 )>'10:45' and  Mid ( t.datetimes, 12, 5 )<='11:15','E',Mid ( t.datetimes, 12, 5 )>'11:15' and  Mid ( t.datetimes, 12, 5 )<='11:45','F', Mid ( t.datetimes, 12, 5 )>'11:45' and  Mid ( t.datetimes, 12, 5 )<='12:15','G',Mid ( t.datetimes, 12, 5 )>'12:15' and  Mid ( t.datetimes, 12, 5 )<='12:45','H', Mid ( t.datetimes, 12, 5 )>'12:45' and  Mid ( t.datetimes, 12, 5 )<='13:15','I',Mid ( t.datetimes, 12, 5 )>'13:15' and  Mid ( t.datetimes, 12, 5 )<='13:45' ,'J')  as  timeflag ,PRICE ,BUY_price, SELL_price ,UP_DOWN ,volume ,diff ,yes_price ,open_price ,high_price ,low_price ,format(t.dttm,'yyyy/MM/dd') as dttm
FROM newfutures t
where t.dttm>=format('{0}','yyyy/MM/dd')
and  t.dttm<format('{1}','yyyy/MM/dd')
order by format(DATETIMES,'yyyy/MM/dd HH:mm:ss')
";
            }
            else
            {
                sql_temp = @"

              SELECT  NAME,DATETIMES,Switch (Mid ( t.datetimes, 12, 5 )>'08:45' and  Mid ( t.datetimes, 12, 5 )<='09:15','A',Mid ( t.datetimes, 12, 5 )>'09:15' and  Mid ( t.datetimes, 12, 5 )<='09:45','B',Mid ( t.datetimes, 12, 5 )>'09:45' and  Mid ( t.datetimes, 12, 5 )<='10:15','C',Mid ( t.datetimes, 12, 5 )>'10:15' and  Mid ( t.datetimes, 12, 5 )<='10:45','D',Mid ( t.datetimes, 12, 5 )>'10:45' and  Mid ( t.datetimes, 12, 5 )<='11:15','E',Mid ( t.datetimes, 12, 5 )>'11:15' and  Mid ( t.datetimes, 12, 5 )<='11:45','F', Mid ( t.datetimes, 12, 5 )>'11:45' and  Mid ( t.datetimes, 12, 5 )<='12:15','G',Mid ( t.datetimes, 12, 5 )>'12:15' and  Mid ( t.datetimes, 12, 5 )<='12:45','H', Mid ( t.datetimes, 12, 5 )>'12:45' and  Mid ( t.datetimes, 12, 5 )<='13:15','I',Mid ( t.datetimes, 12, 5 )>'13:15' and  Mid ( t.datetimes, 12, 5 )<='13:45' ,'J')  as  timeflag ,PRICE ,BUY_price, SELL_price ,UP_DOWN ,volume ,diff ,yes_price ,open_price ,high_price ,low_price ,format(t.dttm,'yyyy/MM/dd') as dttm
FROM newfutures t
where t.dttm>=format('{0}','yyyy/MM/dd')
and  t.dttm<format('{1}','yyyy/MM/dd')
order by t.price desc
";
            }



            sql_temp = string.Format(sql_temp, txtCalendar1.Text, txtCalendar2.Text);




            GridView1.DataSource = Bind_data(sql_temp, conn);
            GridView1.DataBind();

        }


    }
    protected void ButtonQuery_Click(object sender, EventArgs e)
    {


        if (!CheckBox1.Checked)
        {

            sql_temp = @"

SELECT NAME, DATETIMES, Switch(Mid(t.datetimes,12,5)>'08:45' And Mid(t.datetimes,12,5)<='09:15','A',Mid(t.datetimes,12,5)>'09:15' And Mid(t.datetimes,12,5)<='09:45','B',Mid(t.datetimes,12,5)>'09:45' And Mid(t.datetimes,12,5)<='10:15','C',Mid(t.datetimes,12,5)>'10:15' And Mid(t.datetimes,12,5)<='10:45','D',Mid(t.datetimes,12,5)>'10:45' And Mid(t.datetimes,12,5)<='11:15','E',Mid(t.datetimes,12,5)>'11:15' And Mid(t.datetimes,12,5)<='11:45','F',Mid(t.datetimes,12,5)>'11:45' And Mid(t.datetimes,12,5)<='12:15','G',Mid(t.datetimes,12,5)>'12:15' And Mid(t.datetimes,12,5)<='12:45','H',Mid(t.datetimes,12,5)>'12:45' And Mid(t.datetimes,12,5)<='13:15','I',Mid(t.datetimes,12,5)>'13:15' And Mid(t.datetimes,12,5)<='13:45','J') AS timeflag, PRICE, BUY_price, SELL_price, UP_DOWN, volume, diff, yes_price, open_price, high_price, low_price, format(t.dttm,'yyyy/MM/dd') AS dttm
FROM newfutures  t
WHERE t.dttm>=format('{0}','yyyy/MM/dd') And t.dttm<format('{1}','yyyy/MM/dd')
ORDER BY format(t.DATETIMES,'yyyy/MM/dd HH:mm:ss');

";
        }
        else
        {

            sql_temp = @"

              SELECT  NAME,DATETIMES ,Switch (Mid ( t.datetimes, 12, 5 )>'08:45' and  Mid ( t.datetimes, 12, 5 )<='09:15','A',Mid ( t.datetimes, 12, 5 )>'09:15' and  Mid ( t.datetimes, 12, 5 )<='09:45','B',Mid ( t.datetimes, 12, 5 )>'09:45' and  Mid ( t.datetimes, 12, 5 )<='10:15','C',Mid ( t.datetimes, 12, 5 )>'10:15' and  Mid ( t.datetimes, 12, 5 )<='10:45','D',Mid ( t.datetimes, 12, 5 )>'10:45' and  Mid ( t.datetimes, 12, 5 )<='11:15','E',Mid ( t.datetimes, 12, 5 )>'11:15' and  Mid ( t.datetimes, 12, 5 )<='11:45','F', Mid ( t.datetimes, 12, 5 )>'11:45' and  Mid ( t.datetimes, 12, 5 )<='12:15','G',Mid ( t.datetimes, 12, 5 )>'12:15' and  Mid ( t.datetimes, 12, 5 )<='12:45','H', Mid ( t.datetimes, 12, 5 )>'12:45' and  Mid ( t.datetimes, 12, 5 )<='13:15','I',Mid ( t.datetimes, 12, 5 )>'13:15' and  Mid ( t.datetimes, 12, 5 )<='13:45' ,'J')  as  timeflag,PRICE ,BUY_price, SELL_price ,UP_DOWN ,volume ,diff ,yes_price ,open_price ,high_price ,low_price ,format(t.dttm,'yyyy/MM/dd') as dttm
FROM newfutures t
where t.dttm>=format('{0}','yyyy/MM/dd')
and  t.dttm<format('{1}','yyyy/MM/dd')
order by t.price desc
";

        }

        sql_temp = string.Format(sql_temp, txtCalendar1.Text, txtCalendar2.Text);

        ds_temp = func.get_dataSet_access(sql_temp, conn);
        dt = ds_temp.Tables[0];
        DataView dv = new DataView();
        dv = dt.DefaultView;

        DataTable dt_price = dv.ToTable(true, "price");

        DataTable dt_timeflag = new DataTable();
        dv.Sort = "timeflag asc ";

        dt_timeflag = dv.ToTable(true, "timeflag");

        DataTable dt_target = new DataTable();

        dt_target.Columns.Add("NAME", typeof(string));
        dt_target.Columns.Add("PRICE", typeof(string));


        for (int i = 0; i <= dt_timeflag.Rows.Count - 1; i++)
        {

            dt_target.Columns.Add(dt_timeflag.Rows[i][0].ToString(), typeof(string));

        }


        for (int j = 0; j <= dt.Rows.Count - 1; j++)
        {
            DataRow dr = dt_target.NewRow();
            dr[0] = dt.Rows[j][0];
            dr[1] = dt.Rows[j][3];

            for (int k = 0; k <= dt_timeflag.Rows.Count - 1; k++)
            {
                dv.RowFilter = "PRICE='" + dt.Rows[j]["price"].ToString() + "' and timeflag='" + dt_timeflag.Rows[k][0].ToString() + "'";

                if (dv.Count > 0)
                {
                    dr[k + 2] = dv[0]["timeflag"].ToString();



                }


            }

            dt_target.Rows.Add(dr);






        }

        DataTable dt_target_add_mer = dt_target;

        dt_target_add_mer.Columns.Add("MERGE", typeof(string));
        dt_target_add_mer.Columns.Add("Length", typeof(string));
        for (int m = 0; m <= dt_target.Rows.Count - 1; m++)
        {
            string mer_value = "";
            for (int p = 0; p <= dt_target.Columns.Count - 1; p++)
            {
                if (p >= 2)
                {
                    mer_value = mer_value + dt_target.Rows[m][p].ToString();
                }


            }


            dt_target_add_mer.Rows[m]["MERGE"] = mer_value;
            dt_target_add_mer.Rows[m]["Length"] = mer_value.Length;



        }


        //dt_target_add_mer = dt_target_add_mer.DefaultView.ToTable(true, "NAME", "PRICE", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "MERGE");
        dt_target_add_mer = dt_target_add_mer.DefaultView.ToTable(true);

        #region MyRegion
        dt_target_add_mer.Columns.Add("COUNTER", typeof(string));
        Int32 tmp_count = 0;
        string tmp_price = "0";
        // Find COP
        for (int p = 0; p <= dt_target_add_mer.Rows.Count - 1; p++)
        {
            if (Convert.ToInt32(dt_target_add_mer.Rows[p]["Length"].ToString()) > tmp_count)
            {
                tmp_count = Convert.ToInt32(dt_target_add_mer.Rows[p]["Length"].ToString());
                tmp_price = dt_target_add_mer.Rows[p]["PRICE"].ToString();
            }

        }
        // Find COP uper COUNT lower count

        Int32 ini_upper_count = 0;
        Int32 ini_lower_count = 0;
        for (int q = 0; q <= dt_target_add_mer.Rows.Count - 1; q++)
        {
            if (Convert.ToInt32(dt_target_add_mer.Rows[q]["PRICE"].ToString()) > Convert.ToInt32(tmp_price))
            {
                ini_upper_count = ini_upper_count + Convert.ToInt32(dt_target_add_mer.Rows[q]["Length"].ToString());

            }

            if (Convert.ToInt32(dt_target_add_mer.Rows[q]["PRICE"].ToString()) < Convert.ToInt32(tmp_price))
            {
                ini_lower_count = ini_lower_count + Convert.ToInt32(dt_target_add_mer.Rows[q]["Length"].ToString());

            }

        }

        for (int r = 0; r <= dt_target_add_mer.Rows.Count - 1; r++)
        {
            if (Convert.ToInt32(dt_target_add_mer.Rows[r]["PRICE"].ToString()) > Convert.ToInt32(tmp_price))
            {
                dt_target_add_mer.Rows[r]["COUNTER"] = ini_upper_count;

            }

            if (Convert.ToInt32(dt_target_add_mer.Rows[r]["PRICE"].ToString()) < Convert.ToInt32(tmp_price))
            {
                dt_target_add_mer.Rows[r]["COUNTER"] = ini_lower_count;
            }

        }


        #endregion




        //GridView1.DataSource = func.get_dataSet_access(sql_temp, conn);
        if (!CheckBox1.Checked)
        {
            sql_temp = @"

              SELECT  NAME,DATETIMES ,Switch (Mid ( t.datetimes, 12, 5 )>'08:45' and  Mid ( t.datetimes, 12, 5 )<='09:15','A',Mid ( t.datetimes, 12, 5 )>'09:15' and  Mid ( t.datetimes, 12, 5 )<='09:45','B',Mid ( t.datetimes, 12, 5 )>'09:45' and  Mid ( t.datetimes, 12, 5 )<='10:15','C',Mid ( t.datetimes, 12, 5 )>'10:15' and  Mid ( t.datetimes, 12, 5 )<='10:45','D',Mid ( t.datetimes, 12, 5 )>'10:45' and  Mid ( t.datetimes, 12, 5 )<='11:15','E',Mid ( t.datetimes, 12, 5 )>'11:15' and  Mid ( t.datetimes, 12, 5 )<='11:45','F', Mid ( t.datetimes, 12, 5 )>'11:45' and  Mid ( t.datetimes, 12, 5 )<='12:15','G',Mid ( t.datetimes, 12, 5 )>'12:15' and  Mid ( t.datetimes, 12, 5 )<='12:45','H', Mid ( t.datetimes, 12, 5 )>'12:45' and  Mid ( t.datetimes, 12, 5 )<='13:15','I',Mid ( t.datetimes, 12, 5 )>'13:15' and  Mid ( t.datetimes, 12, 5 )<='13:45' ,'J')  as  timeflag ,PRICE ,BUY_price, SELL_price ,UP_DOWN ,volume ,diff ,yes_price ,open_price ,high_price ,low_price ,format(t.dttm,'yyyy/MM/dd') as dttm
FROM newfutures t
where t.dttm>=format('{0}','yyyy/MM/dd')
and  t.dttm<format('{1}','yyyy/MM/dd')
order by format(DATETIMES,'yyyy/MM/dd HH:mm:ss')
";
            sql_temp = string.Format(sql_temp, txtCalendar1.Text, txtCalendar2.Text);

            GridView1.DataSource = func.get_dataSet_access(sql_temp, conn);
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = dt_target_add_mer;
            GridView1.DataBind();

        }


    }
    public DataTable Bind_data(string sqlX, string connx)
    {
        sql_temp = sqlX;




        ds_temp = func.get_dataSet_access(sql_temp, connx);


        dt = ds_temp.Tables[0];
        DataView dv = new DataView();
        dv = dt.DefaultView;

        DataTable dt_price = dv.ToTable(true, "price");

        DataTable dt_timeflag = new DataTable();
        dv.Sort = "timeflag asc ";

        dt_timeflag = dv.ToTable(true, "timeflag");

        DataTable dt_target = new DataTable();

        dt_target.Columns.Add("NAME", typeof(string));
        dt_target.Columns.Add("PRICE", typeof(string));


        for (int i = 0; i <= dt_timeflag.Rows.Count - 1; i++)
        {

            dt_target.Columns.Add(dt_timeflag.Rows[i][0].ToString(), typeof(string));

        }


        for (int j = 0; j <= dt.Rows.Count - 1; j++)
        {
            DataRow dr = dt_target.NewRow();
            dr[0] = dt.Rows[j][0];
            dr[1] = dt.Rows[j][3];

            for (int k = 0; k <= dt_timeflag.Rows.Count - 1; k++)
            {
                dv.RowFilter = "PRICE='" + dt.Rows[j]["price"].ToString() + "' and timeflag='" + dt_timeflag.Rows[k][0].ToString() + "'";

                if (dv.Count > 0)
                {
                    dr[k + 2] = dv[0]["timeflag"].ToString();



                }


            }

            dt_target.Rows.Add(dr);






        }

        DataTable dt_target_add_mer = dt_target;

        dt_target_add_mer.Columns.Add("MERGE", typeof(string));
        dt_target_add_mer.Columns.Add("Length", typeof(string));

        for (int m = 0; m <= dt_target.Rows.Count - 1; m++)
        {
            string mer_value = "";
            for (int p = 0; p <= dt_target.Columns.Count - 1; p++)
            {
                if (p >= 2)
                {
                    mer_value = mer_value + dt_target.Rows[m][p].ToString();
                }


            }


            dt_target_add_mer.Rows[m]["MERGE"] = mer_value;
            dt_target_add_mer.Rows[m]["Length"] = mer_value.Length;


        }

        string col_mame = "";


        dt_target_add_mer = dt_target_add_mer.DefaultView.ToTable(true);
        #region MyRegion
        dt_target_add_mer.Columns.Add("COUNTER", typeof(string));
        Int32 tmp_count = 0;
        string tmp_price = "0";
        // Find COP
        for (int p = 0; p <= dt_target_add_mer.Rows.Count - 1; p++)
        {
            if (Convert.ToInt32(dt_target_add_mer.Rows[p]["Length"].ToString()) > tmp_count)
            {
                tmp_count = Convert.ToInt32(dt_target_add_mer.Rows[p]["Length"].ToString());
                tmp_price = dt_target_add_mer.Rows[p]["PRICE"].ToString();
            }

        }
        // Find COP uper COUNT lower count

        Int32 ini_upper_count = 0;
        Int32 ini_lower_count = 0;
        for (int q = 0; q <= dt_target_add_mer.Rows.Count - 1; q++)
        {
            if (Convert.ToInt32(dt_target_add_mer.Rows[q]["PRICE"].ToString()) > Convert.ToInt32(tmp_price))
            {
                ini_upper_count = ini_upper_count + Convert.ToInt32(dt_target_add_mer.Rows[q]["Length"].ToString());

            }

            if (Convert.ToInt32(dt_target_add_mer.Rows[q]["PRICE"].ToString()) < Convert.ToInt32(tmp_price))
            {
                ini_lower_count = ini_lower_count + Convert.ToInt32(dt_target_add_mer.Rows[q]["Length"].ToString());

            }

        }

        for (int r = 0; r <= dt_target_add_mer.Rows.Count - 1; r++)
        {
            if (Convert.ToInt32(dt_target_add_mer.Rows[r]["PRICE"].ToString()) > Convert.ToInt32(tmp_price))
            {
                dt_target_add_mer.Rows[r]["COUNTER"] = ini_upper_count;

            }

            if (Convert.ToInt32(dt_target_add_mer.Rows[r]["PRICE"].ToString()) < Convert.ToInt32(tmp_price))
            {
                dt_target_add_mer.Rows[r]["COUNTER"] = ini_lower_count;
            }

        }


        #endregion



        if (!CheckBox1.Checked)
        {
            sql_temp = @"

              SELECT  NAME,DATETIMES ,Switch (Mid ( t.datetimes, 12, 5 )>'08:45' and  Mid ( t.datetimes, 12, 5 )<='09:15','A',Mid ( t.datetimes, 12, 5 )>'09:15' and  Mid ( t.datetimes, 12, 5 )<='09:45','B',Mid ( t.datetimes, 12, 5 )>'09:45' and  Mid ( t.datetimes, 12, 5 )<='10:15','C',Mid ( t.datetimes, 12, 5 )>'10:15' and  Mid ( t.datetimes, 12, 5 )<='10:45','D',Mid ( t.datetimes, 12, 5 )>'10:45' and  Mid ( t.datetimes, 12, 5 )<='11:15','E',Mid ( t.datetimes, 12, 5 )>'11:15' and  Mid ( t.datetimes, 12, 5 )<='11:45','F', Mid ( t.datetimes, 12, 5 )>'11:45' and  Mid ( t.datetimes, 12, 5 )<='12:15','G',Mid ( t.datetimes, 12, 5 )>'12:15' and  Mid ( t.datetimes, 12, 5 )<='12:45','H', Mid ( t.datetimes, 12, 5 )>'12:45' and  Mid ( t.datetimes, 12, 5 )<='13:15','I',Mid ( t.datetimes, 12, 5 )>'13:15' and  Mid ( t.datetimes, 12, 5 )<='13:45' ,'J')  as  timeflag ,PRICE ,BUY_price, SELL_price ,UP_DOWN ,volume ,diff ,yes_price ,open_price ,high_price ,low_price ,format(t.dttm,'yyyy/MM/dd') as dttm
FROM newfutures t
where t.dttm>=format('{0}','yyyy/MM/dd')
and  t.dttm<format('{1}','yyyy/MM/dd')
order by format(DATETIMES,'yyyy/MM/dd HH:mm:ss')
";

            sql_temp = string.Format(sql_temp, txtCalendar1.Text, txtCalendar2.Text);
            return func.get_dataSet_access(sql_temp, conn).Tables[0];

        }
        else
        {
            return dt_target_add_mer;

        }





    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!CheckBox1.Checked)
        {
            sql_temp = @"

              SELECT  NAME,DATETIMES,Switch (Mid ( t.datetimes, 12, 5 )>'08:45' and  Mid ( t.datetimes, 12, 5 )<='09:15','A',Mid ( t.datetimes, 12, 5 )>'09:15' and  Mid ( t.datetimes, 12, 5 )<='09:45','B',Mid ( t.datetimes, 12, 5 )>'09:45' and  Mid ( t.datetimes, 12, 5 )<='10:15','C',Mid ( t.datetimes, 12, 5 )>'10:15' and  Mid ( t.datetimes, 12, 5 )<='10:45','D',Mid ( t.datetimes, 12, 5 )>'10:45' and  Mid ( t.datetimes, 12, 5 )<='11:15','E',Mid ( t.datetimes, 12, 5 )>'11:15' and  Mid ( t.datetimes, 12, 5 )<='11:45','F', Mid ( t.datetimes, 12, 5 )>'11:45' and  Mid ( t.datetimes, 12, 5 )<='12:15','G',Mid ( t.datetimes, 12, 5 )>'12:15' and  Mid ( t.datetimes, 12, 5 )<='12:45','H', Mid ( t.datetimes, 12, 5 )>'12:45' and  Mid ( t.datetimes, 12, 5 )<='13:15','I',Mid ( t.datetimes, 12, 5 )>'13:15' and  Mid ( t.datetimes, 12, 5 )<='13:45' ,'J')  as  timeflag ,PRICE ,BUY_price, SELL_price ,UP_DOWN ,volume ,diff ,yes_price ,open_price ,high_price ,low_price ,format(t.dttm,'yyyy/MM/dd') as dttm
FROM newfutures t
where t.dttm>=format('{0}','yyyy/MM/dd')
and  t.dttm<format('{1}','yyyy/MM/dd')
order by format(DATETIMES,'yyyy/MM/dd HH:mm:ss')
";
        }
        else
        {
            sql_temp = @"

              SELECT  NAME,DATETIMES,Switch (Mid ( t.datetimes, 12, 5 )>'08:45' and  Mid ( t.datetimes, 12, 5 )<='09:15','A',Mid ( t.datetimes, 12, 5 )>'09:15' and  Mid ( t.datetimes, 12, 5 )<='09:45','B',Mid ( t.datetimes, 12, 5 )>'09:45' and  Mid ( t.datetimes, 12, 5 )<='10:15','C',Mid ( t.datetimes, 12, 5 )>'10:15' and  Mid ( t.datetimes, 12, 5 )<='10:45','D',Mid ( t.datetimes, 12, 5 )>'10:45' and  Mid ( t.datetimes, 12, 5 )<='11:15','E',Mid ( t.datetimes, 12, 5 )>'11:15' and  Mid ( t.datetimes, 12, 5 )<='11:45','F', Mid ( t.datetimes, 12, 5 )>'11:45' and  Mid ( t.datetimes, 12, 5 )<='12:15','G',Mid ( t.datetimes, 12, 5 )>'12:15' and  Mid ( t.datetimes, 12, 5 )<='12:45','H', Mid ( t.datetimes, 12, 5 )>'12:45' and  Mid ( t.datetimes, 12, 5 )<='13:15','I',Mid ( t.datetimes, 12, 5 )>'13:15' and  Mid ( t.datetimes, 12, 5 )<='13:45' ,'J')  as  timeflag ,PRICE ,BUY_price, SELL_price ,UP_DOWN ,volume ,diff ,yes_price ,open_price ,high_price ,low_price ,format(t.dttm,'yyyy/MM/dd') as dttm
FROM newfutures t
where t.dttm>=format('{0}','yyyy/MM/dd')
and  t.dttm<format('{1}','yyyy/MM/dd')
order by t.price desc
";
        }



        sql_temp = string.Format(sql_temp, txtCalendar1.Text, txtCalendar2.Text);



        GridView gv = new GridView();
        gv.DataSource = Bind_data(sql_temp, conn);
        gv.DataBind();
        ExportExcel(gv);
    }

    private void ExportExcel(GridView SeriesValuesDataGrid)
    {

        string filename = "";
        string today_detail_char = DateTime.Now.AddDays(+0).ToString("yyyy/MM/ddHHmmss").Replace("/", "");
        filename = "future_query_" + today_detail_char + ".xls";
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

            //string pp = DataBinder.Eval(e.Row.DataItem, "Current_price").ToString(); 

            //Int32 pricexx = Convert.ToInt32(price1); 



            // if (percent_value >0) 
            //e.Row.Cells[0].BackColor = Color.Yellow; 
            // e.Row.Cells[6].Style.Add("background-color", "#FFFF80"); 
            //if (countX >= 3) 
            // e.Row.Cells[2].Style.Add("background-color", "#95CAFF"); 
            //if (countX == 2) 
            // e.Row.Cells[2].Style.Add("background-color", "#FFFFB3"); 

            //if (Convert.ToDouble(pp) > priceX) 
            // e.Row.Cells[4].Style.Add("background-color", "#FF9DFF"); 


            //if (Flag_satus == "Cancel") 
            // e.Row.Cells[6].Style.Add("background-color", "#FF9DFF"); 
            if (e.Row.RowIndex != -1)
            {
                int RN = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = RN.ToString();
            }

        }
    }

   
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            objEwinner = new EWinner.EWinner_InterfaceClass();
            objEwinner.OnDataResponse += new EWinner.IEWinner_InterfaceEvents_OnDataResponseEventHandler(objEwinner_OnDataResponse);
            Label1.Text = "啟動成功!!\r\n";
        }
        catch (Exception ex)
        {
            Label1.Text = "請先開啟點金靈環球通\r\n";
        }

        try
        {
            objEwinner.SetOpen(1);
        }
        catch (Exception ex)
        {
            Label1.Text = "開啟API下單失敗\r\n";


        }
        
        try
        {

            string txtFutAccount = "F021000-A56-1829177";
            string strProuductType = "";
            if (this.TextBox1.Text.Trim().Substring(0, 1).ToUpper() == "F")
            {

                strProuductType = "F";
            }
            else
            {
                strProuductType = "O";
            }
            
            //Account=F021000-A04-1234567,ProductID=TXO07500J9, BuySell=B, Qty=1, Price=100,PositionEffect=0

            objEwinner.SendOrder(strProuductType, "Account=" + txtFutAccount + ",ProductID=" + this.TextBox1.Text.Trim() + ", BuySell=" + this.TextBox3.Text.Trim() + ", Qty=" + this.TextBox6.Text.Trim() + ", Price=" + this.TextBox4.Text.Trim() + ",PositionEffect=" + this.TextBox5.Text.Trim() + ",TradeKind=" + this.TextBox2.Text.Trim() + ",OrderCond=" + TextBox7.Text);
        }
        catch (Exception ex)
        {
            Label1.Text = "期貨下單失敗!!\r\n";
          
        }

        //objEwinner.SetOpen(0);
    }
  
    void objEwinner_OnDataResponse(int Index, object Value)
    {
        try
        {
            Label1.Text=Index.ToString() + " : " + Convert.ToString(Value).Trim() + "\r\n";
        }
        catch (Exception ex)
        {
            Label1.Text = ex.ToString() + "\r\n";
        }
    }
}
