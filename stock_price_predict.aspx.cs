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

public partial class stock_price_predict : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["jump"];
    string today = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd");

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

    DataSet ds_temp = new DataSet();
    DataSet ds_temp1 = new DataSet();
    DataSet ds_temp2 = new DataSet();

    DataTable dt_temp = new DataTable();
    DataTable dt_temp2 = new DataTable();
    DataTable dt_ajustted = new DataTable();
    DataTable dt_main = new DataTable();
    DataTable dt_main_predict = new DataTable();
    Double[] TraningData_Rij = new Double[7];
    Double predict_value=0;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        dt_main_predict = getdata();
        dt_main=getdata();


        TraningData_Rij = calculate_rij(dt_main);

        string[] col_name = new string[7];


        //initial_value[0]="3481";     //stock_id
        col_name[0] = "count1";        //count1
        col_name[1] = "price";         //price
        col_name[2] = "avg_volume";    //avg_volume
        col_name[3] = "avg_hot_price"; //avg_hot_price
        col_name[4] = "Current_volume";//Current_volume
        col_name[5] = "diff";          //diff
        col_name[6] = "diff_p";        //diff_p



        string [] initial_value=new string[7];


        //initial_value[0]="3481"; //stock_id
        initial_value[0]="39";   //count1
        initial_value[1]= "81.35";//price
        initial_value[2] ="43938";//avg_volume
        initial_value[3] = "86.97"; //avg_hot_price
        initial_value[4] = "80797";//Current_volume
        initial_value[5] = "3.85";//diff
        initial_value[6] = "0.0473";//diff_p


        predict_value = prediction_price(dt_main_predict, "Current_price", initial_value, TraningData_Rij);

        Response.Write(predict_value);

        //normalize_col(".stock_id", "count1");
        //normalize_col("stock_id", "price");
        //normalize_col("stock_id", "avg_volume");

        //normalize_col("stock_id", "avg_hot_price");
        //normalize_col("stock_id", "Current_price");
        //normalize_col("stock_id", "Current_volume");
        //normalize_col("stock_id", "diff");
        //normalize_col("stock_id", "diff_p");
 



       // dt_temp2.Columns.Add("id", typeof(string));

       // dt_temp2.Columns.Add("count1", typeof(Double));

       // for (int i = 0; i <= dt_main.Rows.Count-1; i++)  

       // {

       //     DataRow dRow = dt_temp2.NewRow();

       //     dRow["id"] = dt_main.Rows[i]["stock_id"].ToString();

       //     dRow["count1"] = Convert.ToDouble(dt_main.Rows[i]["count1"].ToString());

       //     dt_temp2.Rows.Add(dRow);  
       // }

       //object count1_adjust = dt_temp2.Compute(" avg(count1) ", "");

       //for (int i = 0; i <= dt_main.Rows.Count - 1; i++)
       //{

       //    dt_main.Rows[i]["count1"] = Convert.ToDouble(dt_main.Rows[i]["count1"].ToString()) - Convert.ToDouble(count1_adjust);


          
       //}

        //#region calculate Rij son

        //Double rij_son_count1_Current_price = calculate_rij_son(dt_main, "count1", "Current_price");

        //Double rij_son_price_Current_price = calculate_rij_son(dt_main, "price", "Current_price");

        //Double rij_son_avg_volume_Current_price = calculate_rij_son(dt_main, "avg_volume", "Current_price");

        //Double rij_son_avg_hot_price_Current_price = calculate_rij_son(dt_main, "avg_hot_price", "Current_price");
        //Double rij_son_Current_volume_Current_price = calculate_rij_son(dt_main, "Current_volume", "Current_price");
        //Double rij_son_diff_Current_price = calculate_rij_son(dt_main, "diff", "Current_price");
        //Double rij_son_diff_p_Current_price = calculate_rij_son(dt_main, "diff_p", "Current_price");
        
        //#endregion

        //#region calculate Rij mon

        //Double rij_mon_count1_Current_price = calculate_rij_mon(dt_main, "count1", "Current_price");

        //Double rij_mon_price_Current_price = calculate_rij_mon(dt_main, "price", "Current_price");

        //Double rij_mon_avg_volume_Current_price = calculate_rij_mon(dt_main, "avg_volume", "Current_price");

        //Double rij_mon_avg_hot_price_Current_price = calculate_rij_mon(dt_main, "avg_hot_price", "Current_price");
        //Double rij_mon_Current_volume_Current_price = calculate_rij_mon(dt_main, "Current_volume", "Current_price");
        //Double rij_mon_diff_Current_price = calculate_rij_mon(dt_main, "diff", "Current_price");
        //Double rij_mon_diff_p_Current_price = calculate_rij_mon(dt_main, "diff_p", "Current_price");

        //#endregion
        //#region  calculate Rij=Rij son/Rij mon

        //Double Rij_count1_Current_price=rij_son_count1_Current_price/rij_mon_count1_Current_price;

        //Double Rij_price_Current_price = rij_son_price_Current_price / rij_mon_price_Current_price;

        //Double Rij_avg_volume_Current_price = rij_son_avg_volume_Current_price / rij_mon_avg_volume_Current_price;
        //Double Rij_avg_hot_price_Current_price = rij_son_avg_hot_price_Current_price / rij_son_avg_hot_price_Current_price;
        //Double Rij_Current_volume_Current_price = rij_son_Current_volume_Current_price / rij_mon_Current_volume_Current_price;
        //Double Rij_diff_Current_price = rij_son_diff_Current_price / rij_mon_diff_Current_price;
        //Double Rij_diff_p_Current_price = rij_son_diff_p_Current_price / rij_mon_diff_p_Current_price;

        //Double[] Rij_info = new double();

        //Rij_info[1] = Rij_count1_Current_price;
        //Rij_info[1] = Rij_price_Current_price;
        //Rij_info[1] = Rij_avg_volume_Current_price;
        //Rij_info[1] = Rij_avg_hot_price_Current_price;
        //Rij_info[1] = Rij_Current_volume_Current_price;
        //Rij_info[1] = Rij_diff_Current_price;
        //Rij_info[1] = Rij_diff_p_Current_price;


        //#endregion


       


       GridView1.DataSource = dt_main;

       GridView1.DataBind();


         



    }


    public Double col_bar(DataTable dt_main_predict, String colname)
    {

        dt_temp2.Columns.Clear();
        dt_temp2.Rows.Clear();


        dt_temp2.Columns.Add(colname, typeof(Double));

        for (int i = 0; i <= dt_main_predict.Rows.Count - 1; i++)
        {

            DataRow dRow = dt_temp2.NewRow();



            dRow[colname] = Convert.ToDouble(dt_main_predict.Rows[i][colname].ToString());

            dt_temp2.Rows.Add(dRow);
        }

        object abc = dt_temp2.Compute(" avg(" + colname + ") ", "");

        Double col_bar = Convert.ToDouble(abc);


        return col_bar;
       
    
    }


    public Double prediction_price(DataTable dt_main_predict,string col,string[] initial_value,Double[] Rij)
    {

       

        Double[] col_barX=new Double[7];

        col_barX[0] = col_bar(dt_main_predict, "count1");
        col_barX[1] = col_bar(dt_main_predict, "price");
        col_barX[2] = col_bar(dt_main_predict, "avg_volume");
        col_barX[3] = col_bar(dt_main_predict, "avg_hot_price");
        col_barX[4] = col_bar(dt_main_predict, "Current_volume");
        col_barX[5] = col_bar(dt_main_predict, "diff");
        col_barX[6] = col_bar(dt_main_predict, "diff_p");



        //col_name[0] = "count1";        //count1
        //col_name[1] = "price";         //price
        //col_name[2] = "avg_volume";    //avg_volume
        //col_name[3] = "avg_hot_price"; //avg_hot_price
        //col_name[4] = "Current_volume";//Current_volume
        //col_name[5] = "diff";          //diff
        //col_name[6] = "diff_p";        //diff_p


        


        Double son=0;
        Double mon=0;

for (int i = 0; i <= initial_value.Length-1; i++)
			
{

    son = son + (Convert.ToDouble(initial_value[i]) - col_barX[i]) * Rij[i];	

}


for (int i = 0; i <= initial_value.Length-1; i++)
			
{
        
		mon=mon+(Math.Abs(Convert.ToDouble(Rij[i])));

}

Double Current_price_bar = col_bar(dt_main_predict, "Current_price");

        predict_value=Convert.ToDouble(Current_price_bar)+son/mon;




  
        
       
        return predict_value;
    }

    public Double[] calculate_rij(DataTable dt_main)
    {

        normalize_col("stock_id", "count1");
        normalize_col("stock_id", "price");
        normalize_col("stock_id", "avg_volume");

        normalize_col("stock_id", "avg_hot_price");
        normalize_col("stock_id", "Current_price");//target need normallize
        normalize_col("stock_id", "Current_volume");
        normalize_col("stock_id", "diff");
        normalize_col("stock_id", "diff_p");




        // dt_temp2.Columns.Add("id", typeof(string));

        // dt_temp2.Columns.Add("count1", typeof(Double));

        // for (int i = 0; i <= dt_main.Rows.Count-1; i++)  

        // {

        //     DataRow dRow = dt_temp2.NewRow();

        //     dRow["id"] = dt_main.Rows[i]["stock_id"].ToString();

        //     dRow["count1"] = Convert.ToDouble(dt_main.Rows[i]["count1"].ToString());

        //     dt_temp2.Rows.Add(dRow);  
        // }

        //object count1_adjust = dt_temp2.Compute(" avg(count1) ", "");

        //for (int i = 0; i <= dt_main.Rows.Count - 1; i++)
        //{

        //    dt_main.Rows[i]["count1"] = Convert.ToDouble(dt_main.Rows[i]["count1"].ToString()) - Convert.ToDouble(count1_adjust);



        //}

        #region calculate Rij son

        Double rij_son_count1_Current_price = calculate_rij_son(dt_main, "count1", "Current_price");

        Double rij_son_price_Current_price = calculate_rij_son(dt_main, "price", "Current_price");

        Double rij_son_avg_volume_Current_price = calculate_rij_son(dt_main, "avg_volume", "Current_price");

        Double rij_son_avg_hot_price_Current_price = calculate_rij_son(dt_main, "avg_hot_price", "Current_price");
        Double rij_son_Current_volume_Current_price = calculate_rij_son(dt_main, "Current_volume", "Current_price");
        Double rij_son_diff_Current_price = calculate_rij_son(dt_main, "diff", "Current_price");
        Double rij_son_diff_p_Current_price = calculate_rij_son(dt_main, "diff_p", "Current_price");

        #endregion

        #region calculate Rij mon

        Double rij_mon_count1_Current_price = calculate_rij_mon(dt_main, "count1", "Current_price");

        Double rij_mon_price_Current_price = calculate_rij_mon(dt_main, "price", "Current_price");

        Double rij_mon_avg_volume_Current_price = calculate_rij_mon(dt_main, "avg_volume", "Current_price");

        Double rij_mon_avg_hot_price_Current_price = calculate_rij_mon(dt_main, "avg_hot_price", "Current_price");
        Double rij_mon_Current_volume_Current_price = calculate_rij_mon(dt_main, "Current_volume", "Current_price");
        Double rij_mon_diff_Current_price = calculate_rij_mon(dt_main, "diff", "Current_price");
        Double rij_mon_diff_p_Current_price = calculate_rij_mon(dt_main, "diff_p", "Current_price");

        #endregion
        #region  calculate Rij=Rij son/Rij mon

        Double Rij_count1_Current_price = rij_son_count1_Current_price / rij_mon_count1_Current_price;

        Double Rij_price_Current_price = rij_son_price_Current_price / rij_mon_price_Current_price;

        Double Rij_avg_volume_Current_price = rij_son_avg_volume_Current_price / rij_mon_avg_volume_Current_price;
        Double Rij_avg_hot_price_Current_price = rij_son_avg_hot_price_Current_price / rij_son_avg_hot_price_Current_price;
        Double Rij_Current_volume_Current_price = rij_son_Current_volume_Current_price / rij_mon_Current_volume_Current_price;
        Double Rij_diff_Current_price = rij_son_diff_Current_price / rij_mon_diff_Current_price;
        Double Rij_diff_p_Current_price = rij_son_diff_p_Current_price / rij_mon_diff_p_Current_price;

        Double[] Rij_info = new Double[7];

        Rij_info[0] = Rij_count1_Current_price;
        Rij_info[1] = Rij_price_Current_price;
        Rij_info[2] = Rij_avg_volume_Current_price;
        Rij_info[3] = Rij_avg_hot_price_Current_price;
        Rij_info[4] = Rij_Current_volume_Current_price;
        Rij_info[5] = Rij_diff_Current_price;
        Rij_info[6] = Rij_diff_p_Current_price;


        #endregion

        return Rij_info;
       
    }




    public Double calculate_rij_son(DataTable dt,string itemi, string itemj)
    {

        dt_temp2.Columns.Clear();
        dt_temp2.Rows.Clear();

        dt_temp2.Columns.Add(itemi, typeof(Double));

        dt_temp2.Columns.Add(itemj, typeof(Double));

        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {

            DataRow dRow = dt_temp2.NewRow();

            dRow[itemi] = Convert.ToDouble(dt.Rows[i][itemi].ToString());

            dRow[itemj] = Convert.ToDouble(dt.Rows[i][itemj].ToString());

            dt_temp2.Rows.Add(dRow);
        }

        Double result_total_value = 0;


        for (int i = 0; i <= dt_temp2.Rows.Count - 1; i++)
        {

            result_total_value =result_total_value+ Convert.ToDouble(dt_temp2.Rows[i][itemi].ToString()) * Convert.ToDouble(dt_temp2.Rows[i][itemj].ToString());



        }

        return result_total_value;
    }

    public Double calculate_rij_mon(DataTable dt, string itemi, string itemj)
    {

        dt_temp2.Columns.Clear();
        dt_temp2.Rows.Clear();

        dt_temp2.Columns.Add(itemi, typeof(Double));

        dt_temp2.Columns.Add(itemj, typeof(Double));

        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {

            DataRow dRow = dt_temp2.NewRow();

            dRow[itemi] = Convert.ToDouble(dt.Rows[i][itemi].ToString());

            dRow[itemj] = Convert.ToDouble(dt.Rows[i][itemj].ToString());

            dt_temp2.Rows.Add(dRow);
        }

        Double result_itemi_value = 0;
        Double result_itemj_value = 0;
        Double result_total_value = 0;
        Double per_itemi_value = 0;
        Double per_itemj_value = 0;
        for (int i = 0; i <= dt_temp2.Rows.Count - 1; i++)
        {

            per_itemi_value=Math.Pow(Convert.ToDouble(dt_temp2.Rows[i][itemi].ToString()), 2);

            per_itemj_value = result_total_value + Math.Pow(Convert.ToDouble(dt_temp2.Rows[i][itemj].ToString()), 2);

            result_itemi_value = result_itemi_value + per_itemi_value;
            result_itemj_value = result_itemj_value + per_itemj_value;
            
        }

        //Response.Write(result_itemi_value);

        //Response.Write(result_itemj_value);

        result_total_value = Math.Sqrt(result_itemi_value) * Math.Sqrt(result_itemj_value);

        


        return result_total_value;

    }



    public void normalize_col(string id, string col)
    {

        dt_temp2.Columns.Clear();

        dt_temp2.Columns.Add(id, typeof(string));

        dt_temp2.Columns.Add(col, typeof(Double));

        for (int i = 0; i <= dt_main.Rows.Count - 1; i++)
        {

            DataRow dRow = dt_temp2.NewRow();

            dRow[id] = dt_main.Rows[i][id].ToString();

            dRow[col] = Convert.ToDouble(dt_main.Rows[i][col].ToString());

            dt_temp2.Rows.Add(dRow);
        }

        object count1_adjust = dt_temp2.Compute(" avg(" + col + ") ", "");

        for (int i = 0; i <= dt_main.Rows.Count - 1; i++)
        {

            dt_main.Rows[i][col] = Convert.ToDouble(dt_main.Rows[i][col].ToString()) - Convert.ToDouble(count1_adjust);



        }

    }



    public DataTable getdata()
    {
        sql_temp = @"select * from predict ";

        ds_temp = func.get_dataSet_access(sql_temp, conn);

        dt_temp = ds_temp.Tables[0];

        return dt_temp;

    }


}
