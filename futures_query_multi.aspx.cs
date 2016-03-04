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

public partial class futures_query_multi : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["jump"];
    string today = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd");
    string yesturday = DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd");
    string tomorrow = DateTime.Now.AddDays(+1).ToString("yyyy/MM/dd");
    string today_minus6 = DateTime.Now.AddDays(-6).ToString("yyyy/MM/dd");
    string today_minus7 = DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd");
    string today_minus15 = DateTime.Now.AddDays(-15).ToString("yyyy/MM/dd");
    string today_minus30 = DateTime.Now.AddDays(-30).ToString("yyyy/MM/dd");
    string today_detail = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd HH:mm");
    string now_hour = DateTime.Now.AddDays(+0).ToString("HH");
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
    DataSet ds_temp6 = new DataSet();
    Int32 stage1_price = 0;
    Int32 stage1_price_yesturday = 0;
    Int32 stage2_price = 0;
    Int32 stage3_price = 0;
    string UP_down_value = "";
    Int32 MAX_A = 0;
    Int32 MIN_A = 0;
    Int32 MAX_B = 0;
    Int32 MIN_B = 0;
    Int32 MAX_C = 0;
    Int32 MIN_C = 0;
    Int32 MAX_D = 0;
    Int32 MIN_D = 0;
    Int32 MAX_E = 0;
    Int32 MIN_E = 0;
    Int32 MAX_F = 0;
    Int32 MIN_F = 0;
    Int32 MAX_G = 0;
    Int32 MIN_G = 0;
    Int32 MAX_H = 0;
    Int32 MIN_H = 0;
    Int32 MIN_I = 0;
    Int32 MAX_I = 0;
    Int32 MIN_J = 0;
    Int32 MAX_J = 0;
    string price_curX = "";
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {

            CheckBox1.Checked = true;
            txtCalendar1.Text = today_minus6;
            txtCalendar2.Text = tomorrow;

            if (!CheckBox1.Checked)
            {
                sql_temp = @"

              SELECT  NAME,DATETIMES,Switch (Mid ( t.datetimes, 12, 5 )>'08:45' and  Mid ( t.datetimes, 12, 5 )<='09:15','A',Mid ( t.datetimes, 12, 5 )>'09:15' and  Mid ( t.datetimes, 12, 5 )<='09:45','B',Mid ( t.datetimes, 12, 5 )>'09:45' and  Mid ( t.datetimes, 12, 5 )<='10:15','C',Mid ( t.datetimes, 12, 5 )>'10:15' and  Mid ( t.datetimes, 12, 5 )<='10:45','D',Mid ( t.datetimes, 12, 5 )>'10:45' and  Mid ( t.datetimes, 12, 5 )<='11:15','E',Mid ( t.datetimes, 12, 5 )>'11:15' and  Mid ( t.datetimes, 12, 5 )<='11:45','F', Mid ( t.datetimes, 12, 5 )>'11:45' and  Mid ( t.datetimes, 12, 5 )<='12:15','G',Mid ( t.datetimes, 12, 5 )>'12:15' and  Mid ( t.datetimes, 12, 5 )<='12:45','H', Mid ( t.datetimes, 12, 5 )>'12:45' and  Mid ( t.datetimes, 12, 5 )<='13:15','I',Mid ( t.datetimes, 12, 5 )>'13:15' and  Mid ( t.datetimes, 12, 5 )<='13:45' ,'J',Mid ( t.datetimes, 12, 5 )>'13:45','J')  as  timeflag ,PRICE ,BUY_price, SELL_price ,UP_DOWN ,volume ,diff ,yes_price ,open_price ,high_price ,low_price ,format(t.dttm,'yyyy/MM/dd') as dttm
FROM newfutures t
where t.dttm>=format('{0}','yyyy/MM/dd')
and  t.dttm<format('{1}','yyyy/MM/dd')
order by format(DATETIMES,'yyyy/MM/dd HH:mm:ss')
";
            }
            else
            {
                sql_temp = @"

              SELECT  NAME,DATETIMES,Switch (Mid ( t.datetimes, 12, 5 )>'08:45' and  Mid ( t.datetimes, 12, 5 )<='09:15','A',Mid ( t.datetimes, 12, 5 )>'09:15' and  Mid ( t.datetimes, 12, 5 )<='09:45','B',Mid ( t.datetimes, 12, 5 )>'09:45' and  Mid ( t.datetimes, 12, 5 )<='10:15','C',Mid ( t.datetimes, 12, 5 )>'10:15' and  Mid ( t.datetimes, 12, 5 )<='10:45','D',Mid ( t.datetimes, 12, 5 )>'10:45' and  Mid ( t.datetimes, 12, 5 )<='11:15','E',Mid ( t.datetimes, 12, 5 )>'11:15' and  Mid ( t.datetimes, 12, 5 )<='11:45','F', Mid ( t.datetimes, 12, 5 )>'11:45' and  Mid ( t.datetimes, 12, 5 )<='12:15','G',Mid ( t.datetimes, 12, 5 )>'12:15' and  Mid ( t.datetimes, 12, 5 )<='12:45','H', Mid ( t.datetimes, 12, 5 )>'12:45' and  Mid ( t.datetimes, 12, 5 )<='13:15','I',Mid ( t.datetimes, 12, 5 )>'13:15' and  Mid ( t.datetimes, 12, 5 )<='13:45' ,'J',Mid ( t.datetimes, 12, 5 )>'13:45','J')  as  timeflag ,PRICE ,BUY_price, SELL_price ,UP_DOWN ,volume ,diff ,yes_price ,open_price ,high_price ,low_price ,format(t.dttm,'yyyy/MM/dd') as dttm
FROM newfutures t
where t.dttm>=format('{0}','yyyy/MM/dd')
and  t.dttm<format('{1}','yyyy/MM/dd')
order by t.price desc
";
            }



            sql_temp = string.Format(sql_temp, txtCalendar1.Text, txtCalendar2.Text);




            GridView1.DataSource = Bind_data(sql_temp, conn);
            GridView1.DataBind();
            RF();



        }

      






        #region OPEN POSITION

        //stage1
        sql_temp = @"
  
 SELECT 
*

FROM newfutures t
where  t.datetimes>=format('{0}','yyyy/MM/dd HH:mm')
and  t.datetimes<format('{1}','yyyy/MM/dd HH:mm')

order by t.datetimes desc
 



";
        sql_temp = string.Format(sql_temp, txtCalendar1.Text + " 08:45", txtCalendar1.Text + " 08:50");

        ds_temp3 = func.get_dataSet_access(sql_temp, conn);

        if (ds_temp3.Tables[0].Rows.Count > 0)
        {
            stage1_price = Convert.ToInt32(ds_temp3.Tables[0].Rows[0]["PRICE"].ToString());
            stage1_price_yesturday = Convert.ToInt32(ds_temp3.Tables[0].Rows[0]["YES_PRICE"].ToString());
        }

        sql_temp = @"
  
 SELECT 
*

FROM newfutures t
where  t.datetimes>=format('{0}','yyyy/MM/dd HH:mm')
and  t.datetimes<format('{1}','yyyy/MM/dd HH:mm')

order by t.datetimes desc
 



";
        sql_temp = string.Format(sql_temp, txtCalendar1.Text + " 08:50", txtCalendar1.Text + " 08:55");

        ds_temp3 = func.get_dataSet_access(sql_temp, conn);

        if (ds_temp3.Tables[0].Rows.Count > 0)
        {
            stage2_price = Convert.ToInt32(ds_temp3.Tables[0].Rows[0]["PRICE"].ToString());
            stage1_price_yesturday = Convert.ToInt32(ds_temp3.Tables[0].Rows[0]["YES_PRICE"].ToString());
        }

        sql_temp = @"
  
 SELECT 
*

FROM newfutures t
where  t.datetimes>=format('{0}','yyyy/MM/dd HH:mm')
and  t.datetimes<format('{1}','yyyy/MM/dd HH:mm')

order by t.datetimes desc
 



";
        sql_temp = string.Format(sql_temp, txtCalendar1.Text + " 08:55", txtCalendar1.Text + " 09:00");

        ds_temp3 = func.get_dataSet_access(sql_temp, conn);

        if (ds_temp3.Tables[0].Rows.Count > 0)
        {
            stage3_price = Convert.ToInt32(ds_temp3.Tables[0].Rows[0]["PRICE"].ToString());
            stage1_price_yesturday = Convert.ToInt32(ds_temp3.Tables[0].Rows[0]["YES_PRICE"].ToString());

        }

        if (Convert.ToInt32(stage1_price) > Convert.ToInt32(stage1_price_yesturday) + 5)
        {

            combine = "+";
        }
        else
        {
            combine = "-";

        }

        if (Convert.ToInt32(stage2_price) > Convert.ToInt32(stage1_price) + 5)
        {

            combine += "+";
        }
        else
        {
            combine += "-";

        }
        if (Convert.ToInt32(stage3_price) > Convert.ToInt32(stage2_price) + 5)
        {

            combine += "+";
        }
        else
        {
            combine += "-";

        }
        if (combine.Equals("+++") | combine.Equals("-++"))
        {

            combine += ": 多";
        }
        else if (combine.Equals("---") | combine.Equals("+--"))
        {

            combine += ": 空";
        }
        else
        {
            combine += ": NA";

        }

        combine = combine + "<br>昨收: " + stage1_price_yesturday;

        sql_temp = @"

              SELECT  NAME,DATETIMES ,Switch (Mid ( t.datetimes, 12, 5 )>'08:45' and  Mid ( t.datetimes, 12, 5 )<='09:15','A',Mid ( t.datetimes, 12, 5 )>'09:15' and  Mid ( t.datetimes, 12, 5 )<='09:45','B',Mid ( t.datetimes, 12, 5 )>'09:45' and  Mid ( t.datetimes, 12, 5 )<='10:15','C',Mid ( t.datetimes, 12, 5 )>'10:15' and  Mid ( t.datetimes, 12, 5 )<='10:45','D',Mid ( t.datetimes, 12, 5 )>'10:45' and  Mid ( t.datetimes, 12, 5 )<='11:15','E',Mid ( t.datetimes, 12, 5 )>'11:15' and  Mid ( t.datetimes, 12, 5 )<='11:45','F', Mid ( t.datetimes, 12, 5 )>'11:45' and  Mid ( t.datetimes, 12, 5 )<='12:15','G',Mid ( t.datetimes, 12, 5 )>'12:15' and  Mid ( t.datetimes, 12, 5 )<='12:45','H', Mid ( t.datetimes, 12, 5 )>'12:45' and  Mid ( t.datetimes, 12, 5 )<='13:15','I',Mid ( t.datetimes, 12, 5 )>'13:15' and  Mid ( t.datetimes, 12, 5 )<='13:45' ,'J',Mid ( t.datetimes, 12, 5 )>'13:45','J')  as  timeflag ,PRICE ,BUY_price, SELL_price ,UP_DOWN ,volume ,diff ,yes_price ,open_price ,high_price ,low_price ,format(t.dttm,'yyyy/MM/dd') as dttm
FROM newfutures t
where t.dttm>=format('{0}','yyyy/MM/dd')
and  t.dttm<format('{1}','yyyy/MM/dd')
order by format(DATETIMES,'yyyy/MM/dd HH:mm:ss') desc
";

        sql_temp = string.Format(sql_temp, txtCalendar1.Text, txtCalendar2.Text);
       
        if (func.get_dataSet_access(sql_temp, conn).Tables[0].Rows.Count > 0)
        {
            price_curX = func.get_dataSet_access(sql_temp, conn).Tables[0].Rows[0]["PRICE"].ToString();

            UP_down_value = Convert.ToString(Convert.ToInt32(price_curX) - Convert.ToInt32(stage1_price_yesturday));
        }
        else
        {
            price_curX = "NA";
            UP_down_value = "NA";
        }

        Label2.Text = combine + "<br>今收: " + price_curX + "<br>漲跌: " + UP_down_value;

        #region Get upper  downer range

        DateTime dt1 = DateTime.Parse(txtCalendar1.Text);

        DateTime dt2 = dt1.AddDays(-30);





        string upper_downer = @"SELECT  min(t.price) as up ,max(t.price) as down
FROM newfutures t
where t.dttm>=format('{0}','yyyy/MM/dd')
and  t.dttm<=format('{1}','yyyy/MM/dd')


";
        upper_downer = string.Format(upper_downer, dt2.ToString("yyyy/MM/dd"), dt1.ToString("yyyy/MM/dd"));

        ds_temp4 = func.get_dataSet_access(upper_downer, conn);

        upper_downer = @"SELECT  round(min(t.price)/100,0)*100 as up ,round(max(t.price)/100,0)*100 as down
FROM newfutures t
where t.dttm>=format('{0}','yyyy/MM/dd')
and  t.dttm<=format('{1}','yyyy/MM/dd')


";
        upper_downer = string.Format(upper_downer, dt2.ToString("yyyy/MM/dd"), dt1.ToString("yyyy/MM/dd"));
        ds_temp5 = func.get_dataSet_access(upper_downer, conn);

        Label3.Text = ds_temp4.Tables[0].Rows[0][0].ToString() + "=>" + ds_temp5.Tables[0].Rows[0][0].ToString() + "<br>" + ds_temp4.Tables[0].Rows[0][1].ToString() + "=>" + ds_temp5.Tables[0].Rows[0][1].ToString();
        #endregion



        #endregion

        #region market profile
        onepiece_7();
        Initial_balance();
        #endregion



    }

    protected void onepiece_7()
    {
        DateTime targetDt=new DateTime();

        string aabbcc = "";


        Double AB_MAX = 0;

        Double AB_MIN = 0;


        Double CJ_MAX = 0;


        Double CJ_MIN = 0;


        Double AJ_AVG = 0;

        Double AJ_STD = 0;


        Double AJ_CPK_U = 0;

        Double AJ_CPK_L = 0;

        Double CJ_TOP = 0;
        Double CJ_BOTTLE = 0;


        Int32 current_price = 0;
        string Day_type = "";
        
        sql_temp = @"

                 select   ot1.timeflag,max(ot1.PRICE) as max_price,min(ot1.PRICE) as min_price, avg(ot1.price)as avg_price,stdev(ot1.price) as std_price      from(


 SELECT  NAME,DATETIMES,Switch (Mid ( t.datetimes, 12, 5 )>'08:45' and  Mid ( t.datetimes, 12, 5 )<='09:45','AB',Mid ( t.datetimes, 12, 5 )>'09:45' and  Mid ( t.datetimes, 12, 5 )<='13:45' ,'CJ')  as  timeflag ,PRICE ,BUY_price, SELL_price ,UP_DOWN ,volume ,diff ,yes_price ,open_price ,high_price ,low_price ,format(t.dttm,'yyyy/MM/dd') as dttm
FROM newfutures t
where t.dttm=format('{0}','yyyy/MM/dd')

order by format(DATETIMES,'yyyy/MM/dd HH:mm:ss')


) ot1  

group by     ot1.timeflag

union all

select * from (

 select   ot3.timeflag,max(ot3.PRICE) as max_price,min(ot3.PRICE) as min_price,avg(ot3.price)as avg_price,stdev(ot3.price) as std_price     from(


 SELECT  NAME,DATETIMES,Switch (Mid ( t.datetimes, 12, 5 )>'08:45' ,'AJ')  as  timeflag ,PRICE ,BUY_price, SELL_price ,UP_DOWN ,volume ,diff ,yes_price ,open_price ,high_price ,low_price ,format(t.dttm,'yyyy/MM/dd') as dttm
FROM newfutures t
where t.dttm=format('{0}','yyyy/MM/dd')

order by format(DATETIMES,'yyyy/MM/dd HH:mm:ss')


) ot3  

group by     ot3.timeflag


)ot5


";

        if (Convert.ToInt32(now_hour) <= 09)
        {



            DateTime dynamic_yes = Convert.ToDateTime(txtCalendar2.Text).AddDays(-2); 



            //targetDt = Convert.ToDateTime(txtCalendar2.Text);

            aabbcc = dynamic_yes.ToString("yyyy/MM/dd");

            sql_temp = string.Format(sql_temp, dynamic_yes.ToString("yyyy/MM/dd"));
        }

        else
        {

            DateTime dynamic_tod = DateTime.ParseExact(txtCalendar2.Text, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces).AddDays(-1);
            sql_temp = string.Format(sql_temp, dynamic_tod.ToString("yyyy/MM/dd"));
            aabbcc = dynamic_tod.ToString("yyyy/MM/dd");
        
        }



       ds_temp6=func.get_dataSet_access(sql_temp,conn);


       for (int i = 0; i <= ds_temp6.Tables[0].Rows.Count-1; i++)
        {
            if (ds_temp6.Tables[0].Rows[i]["timeflag"].ToString().Equals("AB"))


            {

                AB_MAX = Convert.ToDouble(ds_temp6.Tables[0].Rows[i]["max_price"].ToString());

                AB_MIN = Convert.ToDouble(ds_temp6.Tables[0].Rows[i]["min_price"].ToString());


                
            }

            if (ds_temp6.Tables[0].Rows[i]["timeflag"].ToString().Equals("CJ"))
            {
                CJ_MAX = Convert.ToDouble(ds_temp6.Tables[0].Rows[i]["max_price"].ToString());

                CJ_MIN = Convert.ToDouble(ds_temp6.Tables[0].Rows[i]["min_price"].ToString());
                CJ_TOP = Math.Round(CJ_MIN + (CJ_MAX - CJ_MIN) * 1.382, 0);
                CJ_BOTTLE = Math.Round(CJ_MAX -(CJ_MAX - CJ_MIN) * 1.382, 0);
            }


            if (ds_temp6.Tables[0].Rows[i]["timeflag"].ToString().Equals("AJ"))
            {
                AJ_AVG = Convert.ToDouble(ds_temp6.Tables[0].Rows[i]["avg_price"].ToString());

                AJ_STD = Convert.ToDouble(ds_temp6.Tables[0].Rows[i]["std_price"].ToString());

                AJ_CPK_U = Math.Round((AB_MAX - AJ_AVG) / (3 * AJ_STD), 2);
                AJ_CPK_L = Math.Round((AJ_AVG - AB_MIN) / (3 * AJ_STD), 2); 
                AJ_AVG=Math.Round(AJ_AVG, 0); 
              

            }

        }

        if (Convert.ToInt32(AB_MAX) <= Convert.ToInt32(CJ_MAX) && Convert.ToInt32(AB_MIN) >= Convert.ToInt32(CJ_MIN) )
        {
            if (Convert.ToInt32(AB_MAX) >= Convert.ToInt32(price_curX) && (Convert.ToInt32(AB_MIN) <= Convert.ToInt32(price_curX)))
           {
               Day_type = "Normal Neutral Day(3)";
           }
           else if (Convert.ToInt32(AB_MAX) <= Convert.ToInt32(price_curX))
           {
               Day_type = "Hight Neutral Day(5)";

           }
           else if (Convert.ToInt32(AB_MIN) >=Convert.ToInt32(price_curX))
           {
               Day_type = "Low Neutral Day(5)";
           }
                
           
        }
        else if (Convert.ToInt32(AB_MAX) <= Convert.ToInt32(CJ_MAX) | Convert.ToInt32(AB_MIN) >= Convert.ToInt32(CJ_MIN))
        {
            if (Convert.ToInt32(AB_MAX) <=Convert.ToInt32(price_curX))
           {
               Day_type = "Normal Variation Day Up(4)";
           }
           if (Convert.ToInt32(AB_MAX) >= Convert.ToInt32(price_curX) && Convert.ToInt32(AB_MIN) <= Convert.ToInt32(price_curX))
           {
               Day_type = "Normal Variation Day (4)";
           }
           if (Convert.ToInt32(AB_MIN) >=Convert.ToInt32(price_curX))
           {
               Day_type = "Normal Variation Day Down(4)";
           }

           
        }
        else if (Convert.ToInt32(AB_MAX) >= Convert.ToInt32(CJ_MAX) | Convert.ToInt32(AB_MIN) <= Convert.ToInt32(CJ_MIN))
        {
            Day_type = "NormalDay (2)";
        }
        else
        {
            Day_type = "Undefined";
        
        }

        Label4.Text = "Date:" + aabbcc + "<br>AB_MAX=>" + AB_MAX + "  CJ_MAX=>" + CJ_MAX + "<br> AB_ MIN=>" + AB_MIN + "  CJ_ MIN=>" + CJ_MIN + "<br>AJ_AVG=>" + AJ_AVG + " Now_price=>" + price_curX + "<br>AJ_CPK_U=>" + AJ_CPK_U + " AJ_CPK_L=>" + AJ_CPK_L + "<br>" + Day_type + "<br>" + "CJ_TOP=>" + CJ_TOP + " " + "CJ_BOTTLE=>" + CJ_BOTTLE;


    }


    protected void Initial_balance()
    {
        DateTime targetDt = new DateTime();

        string aabbcc = "";



        Int32 current_price = 0;
        string Day_type = "";

        sql_temp = @"

             select   ot1.dttm,ot1.timeflag,max(ot1.PRICE) as AB_MAX,min(ot1.PRICE) as AB_MIN  from ( 
SELECT  NAME,DATETIMES,Switch (Mid ( t.datetimes, 12, 5 )>'08:45' and  Mid ( t.datetimes, 12, 5 )<='09:45','AB',Mid ( t.datetimes, 12, 5 )>'09:45' and  Mid ( t.datetimes, 12, 5 )<='13:45' ,'CJ')  as  timeflag ,PRICE ,BUY_price, SELL_price ,UP_DOWN ,volume ,diff ,yes_price ,open_price ,high_price ,low_price ,format(t.dttm,'yyyy/MM/dd') as dttm
FROM newfutures t
where t.dttm>=format('{0}','yyyy/MM/dd')
    and t.dttm<=format('{1}','yyyy/MM/dd')
order by format(DATETIMES,'yyyy/MM/dd HH:mm:ss')


 )ot1
where ot1.timeflag='AB'
group by ot1.dttm,ot1.timeflag

order by ot1.dttm desc


";

        if (Convert.ToInt32(now_hour) <= 09)
        {



            DateTime dynamic_yes = Convert.ToDateTime(txtCalendar2.Text).AddDays(-2);


            DateTime dynamic_yes_start = Convert.ToDateTime(txtCalendar1.Text).AddDays(-0);

            //targetDt = Convert.ToDateTime(txtCalendar2.Text);

            aabbcc = dynamic_yes.ToString("yyyy/MM/dd");



            sql_temp = string.Format(sql_temp, dynamic_yes_start.ToString("yyyy/MM/dd"), dynamic_yes.ToString("yyyy/MM/dd"));
        }

        else
        {

            //DateTime dynamic_tod = DateTime.ParseExact(txtCalendar2.Text, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.AllowWhiteSpaces).AddDays(-1);
            //sql_temp = string.Format(sql_temp, dynamic_tod.ToString("yyyy/MM/dd"));
            //aabbcc = dynamic_tod.ToString("yyyy/MM/dd");


            DateTime dynamic_yes = Convert.ToDateTime(txtCalendar2.Text).AddDays(-1);


            DateTime dynamic_yes_start = Convert.ToDateTime(txtCalendar1.Text).AddDays(-0);

            //targetDt = Convert.ToDateTime(txtCalendar2.Text);

            aabbcc = dynamic_yes.ToString("yyyy/MM/dd");



            sql_temp = string.Format(sql_temp, dynamic_yes_start.ToString("yyyy/MM/dd"), dynamic_yes.ToString("yyyy/MM/dd"));




        }



        ds_temp6 = func.get_dataSet_access(sql_temp, conn);

        string AB1 = "";
        string AB2 = "";
        string AB3 = "";
        Double AB_TMP = 0;
        string AB_COMBOO = AB1 + AB2 + AB3;
        if (ds_temp6.Tables[0].Rows.Count>=4)

        {
            for (int i = 0; i <= 3; i++)
            {
                if (i == 0)
                {

                    AB_TMP = Convert.ToDouble(ds_temp6.Tables[0].Rows[i]["AB_MAX"].ToString());





                }

                if (i == 1)
                {
                    if (AB_TMP >= Convert.ToDouble(ds_temp6.Tables[0].Rows[i]["AB_MAX"].ToString()))
                    {
                        AB3 = "+";

                    }
                    else
                    {
                        AB3 = "-";

                    }
                    AB_TMP = Convert.ToDouble(ds_temp6.Tables[0].Rows[i]["AB_MAX"].ToString());

                }
                if (i == 2)
                {
                    if (AB_TMP >= Convert.ToDouble(ds_temp6.Tables[0].Rows[i]["AB_MAX"].ToString()))
                    {
                        AB2 = "+";

                    }
                    else
                    {
                        AB2 = "-";

                    }
                    AB_TMP = Convert.ToDouble(ds_temp6.Tables[0].Rows[i]["AB_MAX"].ToString());

                }
                if (i == 3)
                {
                    if (AB_TMP >= Convert.ToDouble(ds_temp6.Tables[0].Rows[i]["AB_MAX"].ToString()))
                    {
                        AB1 = "+";

                    }
                    else
                    {
                        AB1 = "-";

                    }
                    AB_TMP = Convert.ToDouble(ds_temp6.Tables[0].Rows[i]["AB_MAX"].ToString());

                }

            }

            AB_COMBOO = AB1 + AB2 + AB3;

            if (AB_COMBOO.Equals("+++"))
            {
                AB_COMBOO += "-空";
            }
            if (AB_COMBOO.Equals("++-"))
            {
                AB_COMBOO += "+多";
            }
            if (AB_COMBOO.Equals("+-+"))
            {
                AB_COMBOO += "+多";
            }
            if (AB_COMBOO.Equals("+--"))
            {
                AB_COMBOO += "+多";
            }
            if (AB_COMBOO.Equals("-++"))
            {
                AB_COMBOO += "+多";
            }
            if (AB_COMBOO.Equals("-+-"))
            {
                AB_COMBOO += "+多";
            }
            if (AB_COMBOO.Equals("--+"))
            {
                AB_COMBOO += "-空";
            }
            if (AB_COMBOO.Equals("---"))
            {
                AB_COMBOO += "+多";
            }

        
        }

       


        Label5.Text = "Date:" + aabbcc + "<br>" + "Initial Balace=>" + AB_COMBOO;


    }

    protected void ButtonQuery_Click(object sender, EventArgs e)
    {


        if (!CheckBox1.Checked)
        {

            sql_temp = @"

SELECT NAME, DATETIMES, Switch(Mid(t.datetimes,12,5)>'08:45' And Mid(t.datetimes,12,5)<='09:15','A',Mid(t.datetimes,12,5)>'09:15' And Mid(t.datetimes,12,5)<='09:45','B',Mid(t.datetimes,12,5)>'09:45' And Mid(t.datetimes,12,5)<='10:15','C',Mid(t.datetimes,12,5)>'10:15' And Mid(t.datetimes,12,5)<='10:45','D',Mid(t.datetimes,12,5)>'10:45' And Mid(t.datetimes,12,5)<='11:15','E',Mid(t.datetimes,12,5)>'11:15' And Mid(t.datetimes,12,5)<='11:45','F',Mid(t.datetimes,12,5)>'11:45' And Mid(t.datetimes,12,5)<='12:15','G',Mid(t.datetimes,12,5)>'12:15' And Mid(t.datetimes,12,5)<='12:45','H',Mid(t.datetimes,12,5)>'12:45' And Mid(t.datetimes,12,5)<='13:15','I',Mid(t.datetimes,12,5)>'13:15' And Mid(t.datetimes,12,5)<='13:45','J',Mid ( t.datetimes, 12, 5 )>'13:45','J') AS timeflag, PRICE, BUY_price, SELL_price, UP_DOWN, volume, diff, yes_price, open_price, high_price, low_price, format(t.dttm,'yyyy/MM/dd') AS dttm
FROM newfutures  t
WHERE t.dttm>=format('{0}','yyyy/MM/dd') And t.dttm<format('{1}','yyyy/MM/dd')
ORDER BY format(t.DATETIMES,'yyyy/MM/dd HH:mm:ss');

";
        }
        else
        {

            sql_temp = @"

              SELECT  NAME,DATETIMES ,Switch (Mid ( t.datetimes, 12, 5 )>'08:45' and  Mid ( t.datetimes, 12, 5 )<='09:15','A',Mid ( t.datetimes, 12, 5 )>'09:15' and  Mid ( t.datetimes, 12, 5 )<='09:45','B',Mid ( t.datetimes, 12, 5 )>'09:45' and  Mid ( t.datetimes, 12, 5 )<='10:15','C',Mid ( t.datetimes, 12, 5 )>'10:15' and  Mid ( t.datetimes, 12, 5 )<='10:45','D',Mid ( t.datetimes, 12, 5 )>'10:45' and  Mid ( t.datetimes, 12, 5 )<='11:15','E',Mid ( t.datetimes, 12, 5 )>'11:15' and  Mid ( t.datetimes, 12, 5 )<='11:45','F', Mid ( t.datetimes, 12, 5 )>'11:45' and  Mid ( t.datetimes, 12, 5 )<='12:15','G',Mid ( t.datetimes, 12, 5 )>'12:15' and  Mid ( t.datetimes, 12, 5 )<='12:45','H', Mid ( t.datetimes, 12, 5 )>'12:45' and  Mid ( t.datetimes, 12, 5 )<='13:15','I',Mid ( t.datetimes, 12, 5 )>'13:15' and  Mid ( t.datetimes, 12, 5 )<='13:45' ,'J',Mid ( t.datetimes, 12, 5 )>'13:45','J')  as  timeflag,PRICE ,BUY_price, SELL_price ,UP_DOWN ,volume ,diff ,yes_price ,open_price ,high_price ,low_price ,format(t.dttm,'yyyy/MM/dd') as dttm
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

        DataTable dt_price = new DataTable();
        dv.Sort = " price desc";
        dt_price = dv.ToTable(true, "price");



        DataTable dt_dttm = dv.ToTable(true, "dttm");
        dv.Sort = " dttm asc";
        dt_dttm = dv.ToTable(true, "dttm");



        DataTable dt_timeflag = new DataTable();
        dv.Sort = "timeflag asc ";

        dt_timeflag = dv.ToTable(true, "timeflag");

        DataTable dt_target = new DataTable();

       

        dt_target.Columns.Add("NAME", typeof(string));
        dt_target.Columns.Add("PRICE", typeof(string));

        DataColumn NAME = dt_target.Columns["NAME"];
        DataColumn PRICE = dt_target.Columns["PRICE"];
        DataColumn TIMEFLAG = dt_target.Columns["TIMEFLAG"];

        dt_target.PrimaryKey = new DataColumn[] { NAME, PRICE, TIMEFLAG };




        for (int s = 0; s <= dt_dttm.Rows.Count - 1; s++)
        {


            for (int i = 0; i <= dt_timeflag.Rows.Count - 1; i++)
            {

                dt_target.Columns.Add(dt_timeflag.Rows[i][0].ToString() + (s+1).ToString(), typeof(string));

            }


        }

       





        for (int w = 0; w <= dt_price.Rows.Count-1; w++)
            {

                DataRow dr = dt_target.NewRow();
                dr[0] ="台指期";
                dr[1] = dt_price.Rows[w][0];
                
                
                
                for (int y = 0; y <= dt_dttm.Rows.Count - 1; y++)
                {



                    for (int k = 0; k <= dt_timeflag.Rows.Count - 1; k++)
                    {
                        dv.RowFilter = "PRICE='" + dt_price.Rows[w][0].ToString() + "' and timeflag='" + dt_timeflag.Rows[k][0].ToString() + "'" + " and dttm='" + dt_dttm.Rows[y][0].ToString() + "'";

                        if (dv.Count > 0)
                        {
                            dr[k +2+ y * dt_timeflag.Rows.Count] = dv[0]["timeflag"].ToString();

                           

                        }


                    }


                  


                   

                }

                dt_target.Rows.Add(dr);

            }






        DataTable dt_target_add_mer = dt_target;
        AddMerge_Length(dt_target, dt_target_add_mer);

        //dt_target_add_mer = dt_target_add_mer.DefaultView.ToTable(true, "NAME", "PRICE", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "MERGE");
        dt_target_add_mer = dt_target_add_mer.DefaultView.ToTable(true);

        #region MyRegion
        AddCounter(dt_target_add_mer);


        #endregion
        AddPrice1(dt_price, dt_target_add_mer);

        AddRF(dt_target_add_mer);


        //GridView1.DataSource = func.get_dataSet_access(sql_temp, conn);
        if (!CheckBox1.Checked)
        {
            sql_temp = @"

              SELECT  NAME,DATETIMES ,Switch (Mid ( t.datetimes, 12, 5 )>'08:45' and  Mid ( t.datetimes, 12, 5 )<='09:15','A',Mid ( t.datetimes, 12, 5 )>'09:15' and  Mid ( t.datetimes, 12, 5 )<='09:45','B',Mid ( t.datetimes, 12, 5 )>'09:45' and  Mid ( t.datetimes, 12, 5 )<='10:15','C',Mid ( t.datetimes, 12, 5 )>'10:15' and  Mid ( t.datetimes, 12, 5 )<='10:45','D',Mid ( t.datetimes, 12, 5 )>'10:45' and  Mid ( t.datetimes, 12, 5 )<='11:15','E',Mid ( t.datetimes, 12, 5 )>'11:15' and  Mid ( t.datetimes, 12, 5 )<='11:45','F', Mid ( t.datetimes, 12, 5 )>'11:45' and  Mid ( t.datetimes, 12, 5 )<='12:15','G',Mid ( t.datetimes, 12, 5 )>'12:15' and  Mid ( t.datetimes, 12, 5 )<='12:45','H', Mid ( t.datetimes, 12, 5 )>'12:45' and  Mid ( t.datetimes, 12, 5 )<='13:15','I',Mid ( t.datetimes, 12, 5 )>'13:15' and  Mid ( t.datetimes, 12, 5 )<='13:45' ,'J',Mid ( t.datetimes, 12, 5 )>'13:45','J')  as  timeflag ,PRICE ,BUY_price, SELL_price ,UP_DOWN ,volume ,diff ,yes_price ,open_price ,high_price ,low_price ,format(t.dttm,'yyyy/MM/dd') as dttm
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
        RF();
        onepiece_7();
        Initial_balance();
        
    }

    private static void AddCounter(DataTable dt_target_add_mer)
    {
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
    }

    private static void AddPrice1(DataTable dt_price, DataTable dt_target_add_mer)
    {
        dt_target_add_mer.Columns.Add("PRICE1", typeof(string));

        for (int z = 0; z <= dt_price.Rows.Count - 1; z++)
        {

            dt_target_add_mer.Rows[z]["PRICE1"] = dt_price.Rows[z][0].ToString();


        }
    }
    public DataTable Bind_data(string sqlX, string connx)
    {
        sql_temp = sqlX;




      


        ds_temp = func.get_dataSet_access(sql_temp, conn);
        dt = ds_temp.Tables[0];
        DataView dv = new DataView();
        dv = dt.DefaultView;

        DataTable dt_price = new DataTable();
        dv.Sort = " price desc";
        dt_price = dv.ToTable(true, "price");



        DataTable dt_dttm = dv.ToTable(true, "dttm");
        dv.Sort = " dttm asc";
        dt_dttm = dv.ToTable(true, "dttm");



        DataTable dt_timeflag = new DataTable();
        dv.Sort = "timeflag asc ";

        dt_timeflag = dv.ToTable(true, "timeflag");

        DataTable dt_target = new DataTable();

        dt_target.Columns.Add("NAME", typeof(string));
        dt_target.Columns.Add("PRICE", typeof(string));


        DataColumn NAME = dt_target.Columns["NAME"];
        DataColumn PRICE = dt_target.Columns["PRICE"];
        DataColumn TIMEFLAG = dt_target.Columns["TIMEFLAG"];

        dt_target.PrimaryKey = new DataColumn[] { NAME, PRICE, TIMEFLAG };


        for (int s = 0; s <= dt_dttm.Rows.Count - 1; s++)
        {


            for (int i = 0; i <= dt_timeflag.Rows.Count - 1; i++)
            {

                dt_target.Columns.Add(dt_timeflag.Rows[i][0].ToString() + (s + 1).ToString(), typeof(string));

            }


        }





        for (int w = 0; w <= dt_price.Rows.Count - 1; w++)
        {

            DataRow dr = dt_target.NewRow();
            dr[0] = "台指選";
            dr[1] = dt_price.Rows[w][0];



            for (int y = 0; y <= dt_dttm.Rows.Count - 1; y++)
            {



                for (int k = 0; k <= dt_timeflag.Rows.Count - 1; k++)
                {
                    dv.RowFilter = "PRICE='" + dt_price.Rows[w][0].ToString() + "' and timeflag='" + dt_timeflag.Rows[k][0].ToString() + "'" + " and dttm='" + dt_dttm.Rows[y][0].ToString() + "'";

                    if (dv.Count > 0)
                    {
                        dr[k + 2 + y * dt_timeflag.Rows.Count] = dv[0]["timeflag"].ToString();



                    }


                }







            }

            dt_target.Rows.Add(dr);

        }


        DataTable dt_target_add_mer = dt_target;

        AddMerge_Length(dt_target, dt_target_add_mer);

        string col_mame = "";


        dt_target_add_mer = dt_target_add_mer.DefaultView.ToTable(true);
       
        AddCounter(dt_target_add_mer);

       
        AddPrice1(dt_price, dt_target_add_mer);

        AddRF(dt_target_add_mer);


        if (!CheckBox1.Checked)
        {
            sql_temp = @"

              SELECT  NAME,DATETIMES ,Switch (Mid ( t.datetimes, 12, 5 )>'08:45' and  Mid ( t.datetimes, 12, 5 )<='09:15','A',Mid ( t.datetimes, 12, 5 )>'09:15' and  Mid ( t.datetimes, 12, 5 )<='09:45','B',Mid ( t.datetimes, 12, 5 )>'09:45' and  Mid ( t.datetimes, 12, 5 )<='10:15','C',Mid ( t.datetimes, 12, 5 )>'10:15' and  Mid ( t.datetimes, 12, 5 )<='10:45','D',Mid ( t.datetimes, 12, 5 )>'10:45' and  Mid ( t.datetimes, 12, 5 )<='11:15','E',Mid ( t.datetimes, 12, 5 )>'11:15' and  Mid ( t.datetimes, 12, 5 )<='11:45','F', Mid ( t.datetimes, 12, 5 )>'11:45' and  Mid ( t.datetimes, 12, 5 )<='12:15','G',Mid ( t.datetimes, 12, 5 )>'12:15' and  Mid ( t.datetimes, 12, 5 )<='12:45','H', Mid ( t.datetimes, 12, 5 )>'12:45' and  Mid ( t.datetimes, 12, 5 )<='13:15','I',Mid ( t.datetimes, 12, 5 )>'13:15' and  Mid ( t.datetimes, 12, 5 )<='13:45' ,'J',Mid ( t.datetimes, 12, 5 )>'13:45','J')  as  timeflag ,PRICE ,BUY_price, SELL_price ,UP_DOWN ,volume ,diff ,yes_price ,open_price ,high_price ,low_price ,format(t.dttm,'yyyy/MM/dd') as dttm
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



        RF();
        onepiece_7();
        Initial_balance();

    }

    private static void AddMerge_Length(DataTable dt_target, DataTable dt_target_add_mer)
    {
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
    }

    private void AddRF(DataTable dt_target_add_mer)
    {
        dt_target_add_mer.Columns.Add("RF", typeof(string));

        sql_temp = @"

              SELECT  NAME,DATETIMES ,Switch (Mid ( t.datetimes, 12, 5 )>'08:45' and  Mid ( t.datetimes, 12, 5 )<='09:15','A',Mid ( t.datetimes, 12, 5 )>'09:15' and  Mid ( t.datetimes, 12, 5 )<='09:45','B',Mid ( t.datetimes, 12, 5 )>'09:45' and  Mid ( t.datetimes, 12, 5 )<='10:15','C',Mid ( t.datetimes, 12, 5 )>'10:15' and  Mid ( t.datetimes, 12, 5 )<='10:45','D',Mid ( t.datetimes, 12, 5 )>'10:45' and  Mid ( t.datetimes, 12, 5 )<='11:15','E',Mid ( t.datetimes, 12, 5 )>'11:15' and  Mid ( t.datetimes, 12, 5 )<='11:45','F', Mid ( t.datetimes, 12, 5 )>'11:45' and  Mid ( t.datetimes, 12, 5 )<='12:15','G',Mid ( t.datetimes, 12, 5 )>'12:15' and  Mid ( t.datetimes, 12, 5 )<='12:45','H', Mid ( t.datetimes, 12, 5 )>'12:45' and  Mid ( t.datetimes, 12, 5 )<='13:15','I',Mid ( t.datetimes, 12, 5 )>'13:15' and  Mid ( t.datetimes, 12, 5 )<='13:45' ,'J',Mid ( t.datetimes, 12, 5 )>'13:45','J')  as  timeflag ,PRICE ,BUY_price, SELL_price ,UP_DOWN ,volume ,diff ,yes_price ,open_price ,high_price ,low_price ,format(t.dttm,'yyyy/MM/dd') as dttm
FROM newfutures t
where t.dttm>=format('{0}','yyyy/MM/dd')
and  t.dttm<format('{1}','yyyy/MM/dd')
order by format(DATETIMES,'yyyy/MM/dd HH:mm:ss') desc
";

        sql_temp = string.Format(sql_temp, txtCalendar1.Text, txtCalendar2.Text);

        if (func.get_dataSet_access(sql_temp, conn).Tables[0].Rows.Count > 0)
        {
            string price_cur = func.get_dataSet_access(sql_temp, conn).Tables[0].Rows[0]["PRICE"].ToString();

            for (int u = 0; u <= dt_target_add_mer.Rows.Count - 1; u++)
            {

                if (dt_target_add_mer.Rows[u]["PRICE"].ToString().Equals(price_cur))
                {

                    dt_target_add_mer.Rows[u]["RF"] = RF().ToString();


                }

            }

        }
    }


    protected Int32 RF()
    {
        sql_temp = @"

              SELECT  NAME,DATETIMES,Switch (Mid ( t.datetimes, 12, 5 )>'08:45' and  Mid ( t.datetimes, 12, 5 )<='09:15','A',Mid ( t.datetimes, 12, 5 )>'09:15' and  Mid ( t.datetimes, 12, 5 )<='09:45','B',Mid ( t.datetimes, 12, 5 )>'09:45' and  Mid ( t.datetimes, 12, 5 )<='10:15','C',Mid ( t.datetimes, 12, 5 )>'10:15' and  Mid ( t.datetimes, 12, 5 )<='10:45','D',Mid ( t.datetimes, 12, 5 )>'10:45' and  Mid ( t.datetimes, 12, 5 )<='11:15','E',Mid ( t.datetimes, 12, 5 )>'11:15' and  Mid ( t.datetimes, 12, 5 )<='11:45','F', Mid ( t.datetimes, 12, 5 )>'11:45' and  Mid ( t.datetimes, 12, 5 )<='12:15','G',Mid ( t.datetimes, 12, 5 )>'12:15' and  Mid ( t.datetimes, 12, 5 )<='12:45','H', Mid ( t.datetimes, 12, 5 )>'12:45' and  Mid ( t.datetimes, 12, 5 )<='13:15','I',Mid ( t.datetimes, 12, 5 )>'13:15' and  Mid ( t.datetimes, 12, 5 )<='13:45' ,'J',Mid ( t.datetimes, 12, 5 )>'13:45','J')  as  timeflag ,PRICE ,BUY_price, SELL_price ,UP_DOWN ,volume ,diff ,yes_price ,open_price ,high_price ,low_price ,format(t.dttm,'yyyy/MM/dd') as dttm
FROM newfutures t
where t.dttm>=format('{0}','yyyy/MM/dd')
and  t.dttm<format('{1}','yyyy/MM/dd')
order by format(DATETIMES,'yyyy/MM/dd HH:mm:ss')
";



        sql_temp = string.Format(sql_temp, txtCalendar1.Text, txtCalendar2.Text);

        ds_temp2 = func.get_dataSet_access(sql_temp, conn);



        DataTable dt_timeflag = ds_temp2.Tables[0].DefaultView.ToTable(true, "timeflag");

        string last_timeflag = "";
        if (dt_timeflag.Rows.Count > 0)
        {
            last_timeflag = dt_timeflag.Rows[dt_timeflag.Rows.Count - 1]["timeflag"].ToString();
        }



        for (int i = 0; i <= dt_timeflag.Rows.Count - 1; i++)
        {
            sql_temp = @"

select max(t.price) as price1,min(t.price) as price2 from (

SELECT  NAME,DATETIMES,Switch (Mid ( t.datetimes, 12, 5 )>'08:45' and  Mid ( t.datetimes, 12, 5 )<='09:15','A',Mid ( t.datetimes, 12, 5 )>'09:15' and  Mid ( t.datetimes, 12, 5 )<='09:45','B',Mid ( t.datetimes, 12, 5 )>'09:45' and  Mid ( t.datetimes, 12, 5 )<='10:15','C',Mid ( t.datetimes, 12, 5 )>'10:15' and  Mid ( t.datetimes, 12, 5 )<='10:45','D',Mid ( t.datetimes, 12, 5 )>'10:45' and  Mid ( t.datetimes, 12, 5 )<='11:15','E',Mid ( t.datetimes, 12, 5 )>'11:15' and  Mid ( t.datetimes, 12, 5 )<='11:45','F', Mid ( t.datetimes, 12, 5 )>'11:45' and  Mid ( t.datetimes, 12, 5 )<='12:15','G',Mid ( t.datetimes, 12, 5 )>'12:15' and  Mid ( t.datetimes, 12, 5 )<='12:45','H', Mid ( t.datetimes, 12, 5 )>'12:45' and  Mid ( t.datetimes, 12, 5 )<='13:15','I',Mid ( t.datetimes, 12, 5 )>'13:15' and  Mid ( t.datetimes, 12, 5 )<='13:45' ,'J',Mid ( t.datetimes, 12, 5 )>'13:45','J')  as  timeflag ,PRICE ,BUY_price, SELL_price ,UP_DOWN ,volume ,diff ,yes_price ,open_price ,high_price ,low_price ,format(t.dttm,'yyyy/MM/dd') as dttm
FROM newfutures t
where t.dttm>=format('{0}','yyyy/MM/dd')
and  t.dttm<format('{1}','yyyy/MM/dd')

order by t.price desc
) ot1     
where ot1.timeflag='{2}'         



";



            sql_temp = string.Format(sql_temp, txtCalendar1.Text, txtCalendar2.Text, dt_timeflag.Rows[i]["timeflag"].ToString());

            ds_temp3 = func.get_dataSet_access(sql_temp, conn);

            if (dt_timeflag.Rows[i]["timeflag"].ToString().Equals("A"))
            {

                MAX_A = Convert.ToInt32(ds_temp3.Tables[0].Rows[0]["price1"].ToString());
                MIN_A = Convert.ToInt32(ds_temp3.Tables[0].Rows[0]["price2"].ToString());
            }
            if (dt_timeflag.Rows[i]["timeflag"].ToString().Equals("B"))
            {
                MAX_B = Convert.ToInt32(ds_temp3.Tables[0].Rows[0]["price1"].ToString());
                MIN_B = Convert.ToInt32(ds_temp3.Tables[0].Rows[0]["price2"].ToString());
            }

            if (dt_timeflag.Rows[i]["timeflag"].ToString().Equals("C"))
            {

                MAX_C = Convert.ToInt32(ds_temp3.Tables[0].Rows[0]["price1"].ToString());
                MIN_C = Convert.ToInt32(ds_temp3.Tables[0].Rows[0]["price2"].ToString());
            }
            if (dt_timeflag.Rows[i]["timeflag"].ToString().Equals("D"))
            {

                MAX_D = Convert.ToInt32(ds_temp3.Tables[0].Rows[0]["price1"].ToString());
                MIN_D = Convert.ToInt32(ds_temp3.Tables[0].Rows[0]["price2"].ToString());
            }
            if (dt_timeflag.Rows[i]["timeflag"].ToString().Equals("E"))
            {

                MAX_E = Convert.ToInt32(ds_temp3.Tables[0].Rows[0]["price1"].ToString());
                MIN_E = Convert.ToInt32(ds_temp3.Tables[0].Rows[0]["price2"].ToString());
            }
            if (dt_timeflag.Rows[i]["timeflag"].ToString().Equals("F"))
            {
                MAX_F = Convert.ToInt32(ds_temp3.Tables[0].Rows[0]["price1"].ToString());
                MIN_F = Convert.ToInt32(ds_temp3.Tables[0].Rows[0]["price2"].ToString());
            }
            if (dt_timeflag.Rows[i]["timeflag"].ToString().Equals("G"))
            {

                MAX_G = Convert.ToInt32(ds_temp3.Tables[0].Rows[0]["price1"].ToString());
                MIN_G = Convert.ToInt32(ds_temp3.Tables[0].Rows[0]["price2"].ToString());
            }
            if (dt_timeflag.Rows[i]["timeflag"].ToString().Equals("H"))
            {

                MAX_H = Convert.ToInt32(ds_temp3.Tables[0].Rows[0]["price1"].ToString());
                MIN_H = Convert.ToInt32(ds_temp3.Tables[0].Rows[0]["price2"].ToString());
            }
            if (dt_timeflag.Rows[i]["timeflag"].ToString().Equals("I"))
            {

                MAX_I = Convert.ToInt32(ds_temp3.Tables[0].Rows[0]["price1"].ToString());
                MIN_I = Convert.ToInt32(ds_temp3.Tables[0].Rows[0]["price2"].ToString());
            }
            if (dt_timeflag.Rows[i]["timeflag"].ToString().Equals("J"))
            {

                MAX_J = Convert.ToInt32(ds_temp3.Tables[0].Rows[0]["price1"].ToString());
                MIN_J = Convert.ToInt32(ds_temp3.Tables[0].Rows[0]["price2"].ToString());
            }




        }

        Int32 counter_RF = 0;
        if (MAX_B > MAX_A)
        {

            counter_RF++;
        }
        else
        {
            counter_RF--;


            if (MAX_B == MAX_A)
            {
                counter_RF++;
            }

        }
        if (MAX_C > MAX_B)
        {

            counter_RF++;
        }
        else
        {
            counter_RF--;

            if (MAX_C == MAX_B)
            {
                counter_RF++;
            }


        }
        if (MAX_D > MAX_C)
        {

            counter_RF++;
        }
        else
        {
            counter_RF--;


            if (MAX_D == MAX_C)
            {
                counter_RF++;
            }



        }
        if (MAX_E > MAX_D)
        {

            counter_RF++;

        }
        else
        {
            counter_RF--;

            if (MAX_E == MAX_D)
            {
                counter_RF++;
            }


        }
        if (MAX_F > MAX_E)
        {

            counter_RF++;
        }
        else
        {
            counter_RF--;

            if (MAX_F == MAX_E)
            {
                counter_RF++;
            }


        }
        if (MAX_G > MAX_F)
        {

            counter_RF++;
        }
        else
        {
            counter_RF--;


            if (MAX_G == MAX_F)
            {
                counter_RF++;
            }

        }
        if (MAX_H > MAX_G)
        {

            counter_RF++;
        }
        else
        {
            counter_RF--;


            if (MAX_H == MAX_G)
            {
                counter_RF++;
            }

        }

        if (MAX_I > MAX_H)
        {

            counter_RF++;
        }
        else
        {
            counter_RF--;
            if (MAX_I == MAX_H)
            {
                counter_RF++;

            }
        }
        if (MAX_J > MAX_I)
        {

            counter_RF++;
        }
        else
        {
            counter_RF--;
            if (MAX_J == MAX_I)
            {
                counter_RF++;
            }

        }

        if (MIN_B > MIN_A)
        {

            counter_RF++;
        }
        else
        {
            counter_RF--;
            if (MIN_B == MIN_A)
            {
                counter_RF++;
            }

        }
        if (MIN_C > MIN_B)
        {

            counter_RF++;
        }
        else
        {
            counter_RF--;

            if (MIN_C == MIN_B)
            {
                counter_RF++;
            }


        }
        if (MIN_D > MIN_C)
        {

            counter_RF++;
        }
        else
        {
            counter_RF--;
            if (MIN_D == MIN_C)
            {
                counter_RF++;
            }

        }
        if (MIN_E > MIN_D)
        {

            counter_RF++;
        }
        else
        {
            counter_RF--;
            if (MIN_E == MIN_D)
            {
                counter_RF++;
            }

        }
        if (MIN_F > MIN_E)
        {

            counter_RF++;
        }
        else
        {
            counter_RF--;

            if (MIN_F == MIN_E)
            {
                counter_RF++;
            }

        }
        if (MIN_G > MIN_F)
        {

            counter_RF++;
        }
        else
        {
            counter_RF--;
            if (MIN_G == MIN_F)
            {
                counter_RF++;

            }
        }
        if (MIN_H > MIN_G)
        {

            counter_RF++;
        }
        else
        {
            counter_RF--;

            if (MIN_H == MIN_G)
            {
                counter_RF++;
            }

        }
        if (MIN_I > MIN_H)
        {

            counter_RF++;

        }
        else
        {
            counter_RF--;

            if (MIN_I == MIN_H)
            {
                counter_RF++;
            }

        }
        if (MIN_J > MIN_I)
        {

            counter_RF++;
        }
        else
        {

            counter_RF--;
            if (MIN_J == MIN_I)
            {
                counter_RF++;
            }

        }

        if ((!last_timeflag.Equals("J")) && (!last_timeflag.Equals("")))
        {
            counter_RF += 2;
        }

        Label1.Text = counter_RF.ToString();

        return counter_RF;



    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!CheckBox1.Checked)
        {
            sql_temp = @"

              SELECT  NAME,DATETIMES,Switch (Mid ( t.datetimes, 12, 5 )>'08:45' and  Mid ( t.datetimes, 12, 5 )<='09:15','A',Mid ( t.datetimes, 12, 5 )>'09:15' and  Mid ( t.datetimes, 12, 5 )<='09:45','B',Mid ( t.datetimes, 12, 5 )>'09:45' and  Mid ( t.datetimes, 12, 5 )<='10:15','C',Mid ( t.datetimes, 12, 5 )>'10:15' and  Mid ( t.datetimes, 12, 5 )<='10:45','D',Mid ( t.datetimes, 12, 5 )>'10:45' and  Mid ( t.datetimes, 12, 5 )<='11:15','E',Mid ( t.datetimes, 12, 5 )>'11:15' and  Mid ( t.datetimes, 12, 5 )<='11:45','F', Mid ( t.datetimes, 12, 5 )>'11:45' and  Mid ( t.datetimes, 12, 5 )<='12:15','G',Mid ( t.datetimes, 12, 5 )>'12:15' and  Mid ( t.datetimes, 12, 5 )<='12:45','H', Mid ( t.datetimes, 12, 5 )>'12:45' and  Mid ( t.datetimes, 12, 5 )<='13:15','I',Mid ( t.datetimes, 12, 5 )>'13:15' and  Mid ( t.datetimes, 12, 5 )<='13:45' ,'J',Mid ( t.datetimes, 12, 5 )>'13:45','J')  as  timeflag ,PRICE ,BUY_price, SELL_price ,UP_DOWN ,volume ,diff ,yes_price ,open_price ,high_price ,low_price ,format(t.dttm,'yyyy/MM/dd') as dttm
FROM newfutures t
where t.dttm>=format('{0}','yyyy/MM/dd')
and  t.dttm<format('{1}','yyyy/MM/dd')
order by format(DATETIMES,'yyyy/MM/dd HH:mm:ss')
";
        }
        else
        {
            sql_temp = @"

              SELECT  NAME,DATETIMES,Switch (Mid ( t.datetimes, 12, 5 )>'08:45' and  Mid ( t.datetimes, 12, 5 )<='09:15','A',Mid ( t.datetimes, 12, 5 )>'09:15' and  Mid ( t.datetimes, 12, 5 )<='09:45','B',Mid ( t.datetimes, 12, 5 )>'09:45' and  Mid ( t.datetimes, 12, 5 )<='10:15','C',Mid ( t.datetimes, 12, 5 )>'10:15' and  Mid ( t.datetimes, 12, 5 )<='10:45','D',Mid ( t.datetimes, 12, 5 )>'10:45' and  Mid ( t.datetimes, 12, 5 )<='11:15','E',Mid ( t.datetimes, 12, 5 )>'11:15' and  Mid ( t.datetimes, 12, 5 )<='11:45','F', Mid ( t.datetimes, 12, 5 )>'11:45' and  Mid ( t.datetimes, 12, 5 )<='12:15','G',Mid ( t.datetimes, 12, 5 )>'12:15' and  Mid ( t.datetimes, 12, 5 )<='12:45','H', Mid ( t.datetimes, 12, 5 )>'12:45' and  Mid ( t.datetimes, 12, 5 )<='13:15','I',Mid ( t.datetimes, 12, 5 )>'13:15' and  Mid ( t.datetimes, 12, 5 )<='13:45' ,'J',Mid ( t.datetimes, 12, 5 )>'13:45','J' )  as  timeflag ,PRICE ,BUY_price, SELL_price ,UP_DOWN ,volume ,diff ,yes_price ,open_price ,high_price ,low_price ,format(t.dttm,'yyyy/MM/dd') as dttm
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
        RF();
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

            string TPO_LEN = DataBinder.Eval(e.Row.DataItem, "Length").ToString();

            Int32 TPOCOUNT = Convert.ToInt32(TPO_LEN);

            e.Row.Cells[e.Row.Cells.Count - 4].Attributes.Add("align", "left");




            //if (percent_value >0) 
            //e.Row.Cells[0].BackColor = Color.Yellow; 
            // e.Row.Cells[6].Style.Add("background-color", "#FFFF80"); 
            //if (countX >= 3) 
            // e.Row.Cells[2].Style.Add("background-color", "#95CAFF"); 
            //if (countX == 2) 
            // e.Row.Cells[2].Style.Add("background-color", "#FFFFB3"); 

            //if (TPOCOUNT >= 4)
            //    for (int i = 0; i <=  e.Row.Cells.Count-1; i++)
            //    {
            //        e.Row.Cells[i].Style.Add("background-color", "#F8E085"); 

            //    }




            string merge_LEN = DataBinder.Eval(e.Row.DataItem, "MERGE").ToString();

            if (merge_LEN.IndexOf("A")>=0 | merge_LEN.IndexOf("B")>= 0)

            {
                for (int i = 0; i <= e.Row.Cells.Count - 1; i++)
                {
                    if (i > e.Row.Cells.Count - 1-3)
                    {
                        e.Row.Cells[i].Style.Add("background-color", "#FFD9EC");
                    }
                   

                }
            
            }


         



          
                for (int j = 0; j <= e.Row.Cells.Count - 1; j++)
                {
                  



                        if (e.Row.Cells[j].Text.Equals("A") || e.Row.Cells[j].Text.Equals("B"))
                        {
                            e.Row.Cells[j].Style.Add("background-color", "#DDDDFF");
                         
                        }
                           
                 


                }

          


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
}
