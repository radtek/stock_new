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

public partial class KPI_POINT : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string today_detail = DateTime.Now.AddDays(+0).ToString("HH:mm");
        Double lefthour = 0;
        today_detail = today_detail.Replace(":", "");

        if(!IsPostBack)
        {

            Label1.Text = "0";
            Label2.Text = "0";
            Label3.Text = "0";
            Label4.Text = "0";
            Label5.Text = "0";
            Label6.Text = "0";

            Label7.Text = "0";
            Label8.Text = "0";
            Label9.Text = "0";
            Label10.Text = "0";
            Label11.Text = "0";
            Label12.Text = "0";

            Label13.Text = "0";
            Label14.Text = "0";
            Label15.Text = "0";
           


            Label16.Text = "";
            Label17.Text = "";
            Label18.Text = "";
            Label19.Text = "";
            Label20.Text = "";
            Label21.Text = "";
            Label22.Text = "";
            Label23.Text = "";
            Label24.Text = "";
            Label25.Text = "";
            Label26.Text = "";
            Label27.Text = "";
            Label28.Text = "";
            Label29.Text = "";
            Label30.Text = "";
            Label31.Text = "";
            Label32.Text = "";
            Label33.Text = "";
            TextBox5.Text = "0.16";

            DateTime dt = DateTime.Now.AddDays(+0);
           
            string tmp2 = dt.DayOfWeek.ToString("d");//tmp2 = 4 
            string leftdaytmp = "1";
            switch (tmp2)
            {
                case "1":
                    if (string.Compare(today_detail, "1345") < 0)
                    {
                        leftdaytmp = "3";
                    }
                    else
                    {
                        leftdaytmp = "3";
                    }
                    break;
                case "2":
                    
                    if (string.Compare(today_detail, "1345") < 0)
                    {
                        leftdaytmp = "2";
                    }
                    else
                    {
                        leftdaytmp = "1";
                    }
                    break;
                case "3":
                    
                    if (string.Compare(today_detail, "1345") < 0)
                    {
                        leftdaytmp = "1";
                    }
                    else
                    {
                        leftdaytmp = "5";
                    }
                    break;
                case "4":
                    
                    if (string.Compare(today_detail, "1345") < 0)
                    {
                        leftdaytmp = "5";
                    }
                    else
                    {
                        leftdaytmp = "4";
                    }
                    break;
                case "5":
                    if (string.Compare(today_detail, "1345") < 0)
                    {
                        leftdaytmp = "4";
                    }
                    else
                    {
                        leftdaytmp = "3";
                    }
                    break;
                case "6":
                    leftdaytmp = "3";
                    break;
                case "0":
                    leftdaytmp = "3";
                    break;
                
                default:
                    break;
            }


            TextBox6.Text = leftdaytmp;

            if (string.Compare(today_detail, "0845") > 0 && string.Compare(today_detail, "1345") < 0)
            {
                lefthour = Convert.ToDouble(today_detail.Substring(0, 2).ToString()) - 8;
                TextBox6.Text = Convert.ToString(Convert.ToDouble(TextBox6.Text) - Convert.ToDouble(lefthour / 5));
            }

            if (string.Compare(today_detail, "1500") > 0 && string.Compare(today_detail, "2359") < 0)
            {
                lefthour = Convert.ToDouble(today_detail.Substring(0, 2).ToString()) - 15;
                
                TextBox6.Text = Convert.ToString(Math.Round(Convert.ToDouble(TextBox6.Text) - Convert.ToDouble(lefthour )/ 14, 2, MidpointRounding.AwayFromZero));
            }
            if (string.Compare(today_detail, "0000") > 0 && string.Compare(today_detail, "0500") < 0)
            {
                lefthour = 9+Convert.ToDouble(today_detail.Substring(0, 2).ToString());

                TextBox6.Text = Convert.ToString(Math.Round(Convert.ToDouble(TextBox6.Text) - Convert.ToDouble(lefthour )/ 14, 2, MidpointRounding.AwayFromZero));
            }



            TextBox7.Text = lefthour.ToString();

        }


        





    }

       public class Calculator

       {
         // Field
        public Double highPoint;
        public Double lowPoint;
        public Double nowPoint;

        public Double diffPoint;
        public Double breakout1;
        public Double breakout2;
        public Double breakout3;
        public Double breakout4;
        public Double breakout5;
        
        public Double bracket1;
        public Double bracket2;
        public Double bracket3;
        public Double bracket4;
        public Double bracket5;
        
        public Double fall1;
        public Double fall2;
        public Double fall3;
        public Double fall4;
        public Double fall5;
        


        // Constructor that takes no arguments.
           public  Calculator()
        {
            //name = "unknown";
        }

        // Constructor that takes one argument.
           public  Calculator(string high, string low, string now)
        {
            highPoint=Convert.ToDouble(high);
            lowPoint=Convert.ToDouble(low);
            nowPoint=Convert.ToDouble(now);
            diffPoint=Convert.ToDouble(highPoint)-Convert.ToDouble(lowPoint);
        }

        // Method
        public void DoCalculate()
        {
            
            breakout1=highPoint+diffPoint*0.809;
            breakout2=highPoint+diffPoint*0.618;
            breakout3=highPoint+diffPoint*0.5;
            breakout4=highPoint+diffPoint * 0.382;
            breakout5=highPoint+diffPoint*0.191;
            
            bracket1=highPoint-diffPoint*0.191;
            bracket2=highPoint-diffPoint*0.382;
            bracket3=highPoint-diffPoint*0.5;
            bracket4=highPoint-diffPoint*0.618;
            bracket5=highPoint-diffPoint*0.809;



            fall1=lowPoint-diffPoint*0.191;
            fall2=lowPoint-diffPoint*0.382;
            fall3=lowPoint-diffPoint*0.5;
            fall4 = lowPoint - diffPoint * 0.618;
            fall5 = lowPoint - diffPoint * 0.809;



        }
       }
      
    
protected void  Button1_Click(object sender, EventArgs e)
{

    TextBox4.Text = TextBox3.Text;
    Calculator _cal = new Calculator(TextBox1.Text, TextBox2.Text, TextBox3.Text);
    _cal.DoCalculate();
    Label1.Text = _cal.breakout1.ToString("N0");
    Label2.Text = _cal.breakout2.ToString("N0");
    Label3.Text = _cal.breakout3.ToString("N0");
    Label4.Text = _cal.breakout4.ToString("N0");
    Label5.Text = _cal.breakout5.ToString("N0");

    Label6.Text = _cal.bracket1.ToString("N0");
    Label7.Text = _cal.bracket2.ToString("N0");
    Label8.Text = _cal.bracket3.ToString("N0");
    Label9.Text = _cal.bracket4.ToString("N0");
    Label10.Text = _cal.bracket5.ToString("N0");

    Label11.Text = _cal.fall1.ToString("N0");
    Label12.Text = _cal.fall2.ToString("N0");
    Label13.Text = _cal.fall3.ToString("N0");
    Label14.Text = _cal.fall4.ToString("N0");
    Label15.Text = _cal.fall5.ToString("N0");


    if (_cal.nowPoint < _cal.breakout1 && _cal.nowPoint >= _cal.breakout2)
    {
        Label16.Text = "Y";

    }
    else
    {
        Label16.Text = "";

    }

    if (_cal.nowPoint < _cal.breakout2 && _cal.nowPoint >= _cal.breakout3)
    {
        Label17.Text = "Y";

    }
    else
    {
        Label17.Text = "";
    }



    if (_cal.nowPoint < _cal.breakout3 && _cal.nowPoint >= _cal.breakout4)
    {
        Label18.Text = "Y";

    }
    else
    {
        Label18.Text = "";
    }


    if (_cal.nowPoint < _cal.breakout4 && _cal.nowPoint >= _cal.breakout5)
    {
        Label19.Text = "Y";

    }
    else
    {
        Label19.Text = "";
    }






    if (_cal.nowPoint < _cal.breakout5 && _cal.nowPoint >= _cal.bracket1)
    {
        Label20.Text = "Y";

    }

    else
    {
        Label20.Text = "";
    }

    // Bracket Area
    if (_cal.nowPoint < _cal.bracket1 && _cal.nowPoint >= _cal.bracket2)
    {
        Label21.Text = "Y";

    }
    else
    {
        Label21.Text = "";
    }

    if (_cal.nowPoint < _cal.bracket2 && _cal.nowPoint >= _cal.bracket3)
    {
        Label22.Text = "Y";

    }
    else
    {
        Label22.Text = "";
    }


    if (_cal.nowPoint < _cal.bracket3 && _cal.nowPoint >= _cal.bracket4)
    {
        Label23.Text = "Y";

    }
    else
    {
        Label23.Text = "";
    }




    if (_cal.nowPoint < _cal.bracket4 && _cal.nowPoint >= _cal.bracket5)
    {
        Label24.Text = "Y";

    }
    else
    {
        Label24.Text = "";
    }


    if (_cal.nowPoint < _cal.bracket5 && _cal.nowPoint >= _cal.fall1)
    {
        Label25.Text = "Y";

    }
    else
    {
        Label25.Text = "";
    }




    if (_cal.nowPoint < _cal.fall1 && _cal.nowPoint >= _cal.fall2)
    {
        Label26.Text = "Y";

    }
    else
    {
        Label26.Text = "";
    }

    if (_cal.nowPoint < _cal.fall2 && _cal.nowPoint >= _cal.fall3)
    {
        Label27.Text = "Y";

    }
    else
    {
        Label27.Text = "";
    }
    
    if (_cal.nowPoint < _cal.fall3 && _cal.nowPoint >= _cal.fall4)
    {
        Label28.Text = "Y";

    }
    else
    {
        Label28.Text = "";
    }

    if (_cal.nowPoint < _cal.fall4 && _cal.nowPoint >= _cal.fall5)
    {
        Label29.Text = "Y";

    }
    else
    {
        Label29.Text = "";
    }




}



    protected void Button2_Click(object sender, EventArgs e)
    {
        Double NowPrice = Convert.ToDouble(TextBox4.Text);
        Double WaveRate = Convert.ToDouble(TextBox5.Text);
        Double DueDay = Convert.ToDouble(TextBox6.Text);

        Double LowerPrice = 0;
        Double UpperPrice = 0;

        UpperPrice = NowPrice * Math.Pow(1 + WaveRate / 16, DueDay / 3);
        LowerPrice = NowPrice * Math.Pow(1 - WaveRate / 16, DueDay / 3);
        Label31.Text = UpperPrice.ToString("N0");
        Label30.Text = LowerPrice.ToString("N0");



        LowerPrice = Math.Round((LowerPrice-25 )/ 50, MidpointRounding.AwayFromZero) * 50;
        UpperPrice = Math.Round((UpperPrice+25) / 50, MidpointRounding.AwayFromZero) * 50;


        Label33.Text = UpperPrice.ToString("N0");
        Label32.Text = LowerPrice.ToString("N0");


    }
 
}
