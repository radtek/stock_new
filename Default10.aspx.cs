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

public partial class Default10 : System.Web.UI.Page
{

    public DataView dv = new DataView();
    DataSet ds = new DataSet();
    string conn = System.Configuration.ConfigurationSettings.AppSettings["jump"];
    string conn1 = System.Configuration.ConfigurationSettings.AppSettings["Query_excel2"];
    string today = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd");

    string today_minus17 = DateTime.Now.AddDays(-17).ToString("yyyy/MM/dd");

    string today_detail = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd HH:mm");
    string sql_temp = "";
    string sql_temp1 = "";
    string sql_temp2 = "";
    DataSet ds_temp = new DataSet();
    DataSet ds_temp1 = new DataSet();
    DataSet ds_temp2 = new DataSet();
    Int32 counter = 0;
  
    protected void Page_Load(object sender, EventArgs e)
    {

        func2();


    }

    public void func2()
    {
        sql_temp = @"SELECT  distinct(t.POST_ID)

FROM hw2_2 AS t
order by  t.POST_ID";

        ds_temp = func.get_dataSet_access(sql_temp, conn);

        for (int i = 0; i <= ds_temp.Tables[0].Rows.Count-1; i++)
        {

            sql_temp1 = @" SELECT t.*
FROM hw2_2 AS t where t.POST_ID='{0}'
order by  t.POST_ID,t.FREQUENCE desc";

            sql_temp1 = string.Format(sql_temp1, ds_temp.Tables[0].Rows[i]["POST_ID"].ToString());
            
            ds_temp1 = func.get_dataSet_access(sql_temp1, conn);

            for (int j = 0; j <= 32; j++)
            {
                sql_temp2 = @"INSERT INTO HW2_3 (POST_ID,WORD,FREQUENCE,TFIDF)
VALUES ('{0}','{1}','{2}','{3}') ";


                sql_temp2 = string.Format(sql_temp2, ds_temp1.Tables[0].Rows[j]["POST_ID"].ToString(), ds_temp1.Tables[0].Rows[j]["WORD"].ToString().Replace("'","''"), ds_temp1.Tables[0].Rows[j]["FREQUENCE"].ToString(), ds_temp1.Tables[0].Rows[j]["TFIDF"].ToString());

                func.get_sql_execute(sql_temp2, conn);
            }


        }
        
//        sql_temp1 = @" select * from [Sheet1$] ";

//        ds_temp = func.get_dataSet_access(sql_temp, conn1);

//        counter = ds_temp.Tables[0].Rows.Count;
//        Label1.Text = counter.ToString();

//        for (int i = 0; i <= ds_temp.Tables[0].Rows.Count - 1; i++)
//        {
//            sql_temp1 = @"  INSERT INTO HW2_2 (SEQ,POST_ID,WORD,WORD_TYPE,FREQUENCE,TF,IDF,TFIDF)
//VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}') 
//";
//            sql_temp1 = string.Format(sql_temp1, ds_temp.Tables[0].Rows[i][0].ToString(), ds_temp.Tables[0].Rows[i][1].ToString(), ds_temp.Tables[0].Rows[i][2].ToString().Replace("'", "''"), ds_temp.Tables[0].Rows[i][3].ToString(), ds_temp.Tables[0].Rows[i][4].ToString(), ds_temp.Tables[0].Rows[i][5].ToString(), ds_temp.Tables[0].Rows[i][6].ToString(), ds_temp.Tables[0].Rows[i][7].ToString());

//            func.get_sql_execute(sql_temp1, conn);
//        }




        //GridView1.DataSource = ds_temp.Tables[0];
        //GridView1.DataBind();




    }

    public void func1()
    {
        sql_temp = @" SELECT * from [Sheet1$]
 ";

        ds_temp = func.get_dataSet_access(sql_temp, conn);

        counter = ds_temp.Tables[0].Rows.Count;
        Label1.Text = counter.ToString();

        for (int i = 0; i <= ds_temp.Tables[0].Rows.Count - 1; i++)
        {
            sql_temp1 = @"  INSERT INTO HW2_3 (POST_ID,WORD,FREQUENCE,TFIDF)
VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}') 
";
            sql_temp1 = string.Format(sql_temp1, ds_temp.Tables[0].Rows[i][0].ToString(), ds_temp.Tables[0].Rows[i][1].ToString(), ds_temp.Tables[0].Rows[i][2].ToString().Replace("'", "''"), ds_temp.Tables[0].Rows[i][3].ToString(), ds_temp.Tables[0].Rows[i][4].ToString(), ds_temp.Tables[0].Rows[i][5].ToString(), ds_temp.Tables[0].Rows[i][6].ToString(), ds_temp.Tables[0].Rows[i][7].ToString());

            func.get_sql_execute(sql_temp1, conn);
        }




        //GridView1.DataSource = ds_temp.Tables[0];
        //GridView1.DataBind();




    }

}
