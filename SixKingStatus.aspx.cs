﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class SixKingStatus : System.Web.UI.Page
{
    string month = "";
    string day = "";
    string today = DateTime.Now.AddDays(-30).ToString("yyyy/MM/dd");

    protected void Page_Load(object sender, EventArgs e)
    {
         

  
        
        //2017/09/06
        if (!IsPostBack)
        {
            txtCalendar1.Text = today;
            HyperLink1.Text = "農民曆";
            HyperLink1.Target = "_blank";
            HyperLink1.NavigateUrl = "http://www.nongli.info/huangli/";
        }
      
       month= txtCalendar1.Text.Replace("/", "").Substring(4,2);
       day = txtCalendar1.Text.Replace("/", "").Substring(6, 2);

       Label1.Text = month;
       Label2.Text = day;
       SixKingE sk = new SixKingE(month, day);
       sk.calculate();

        Label3.Text = sk.cvalue.ToString();

        Label4.Text = sk.combinStatus;
        LabelA1.Text = sk.fstatus[0].ToString();
      
        LabelA2.Text = sk.fstatus[1].ToString();
        LabelA3.Text = sk.fstatus[2].ToString();
        LabelA4.Text = sk.fstatus[3].ToString();

        LabelA5.Text = sk.fstatus[4].ToString();

        LabelA6.Text = sk.fstatus[5].ToString();

        LabelA7.Text = sk.fstatus[6].ToString();

        LabelA8.Text = sk.fstatus[7].ToString();

        LabelA9.Text = sk.fstatus[8].ToString();

        LabelA10.Text = sk.fstatus[9].ToString();

        LabelA11.Text = sk.fstatus[10].ToString();

        LabelA12.Text = sk.fstatus[11].ToString();



      

    }

    public class SixKingE
    {

        public string[] status ={ "大安", "留連", "速喜", "赤口", "小吉", "空亡" };    
        
        public string tmpa;
        public string tmpb;
        public Int32 avalue;
        public Int32 bvalue;
        public Int32 cvalue;
        public string combinStatus = "";

        public string[] fstatus=new string[12];

       public  SixKingE(string a, string b)
        {
            tmpa=a;
            tmpb=b;
        
        }

        public void calculate()
        {
          
           avalue = Convert.ToInt32(tmpa);
           bvalue = Convert.ToInt32(tmpb);
           cvalue = (avalue + bvalue - 1) % 6;
           combinStatus = "";
           for (int i = 0; i <= 11; i++)
           {
               if (i == 0)
               {
                   combinStatus = combinStatus + status[(cvalue + i+6-1) % 6];
               }
               else
               {
                   combinStatus = combinStatus + "," + status[(cvalue + i+6-1) % 6];
               
               }
              
           }

           fstatus = combinStatus.Split(',');


          
        }
      
    
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = month;
        Label2.Text = day;
        SixKingE sk = new SixKingE(month, day);
        sk.calculate();

        Label3.Text = sk.cvalue.ToString();
    }
}
