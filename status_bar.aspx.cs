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
using System.Collections.Generic;

public partial class status_bar : System.Web.UI.Page
{
    Dictionary<int, int> Datas 
    { 
        
        get 
        
        { 
           Dictionary<int, int> d = new Dictionary<int, int>();
           for (int i = 0; i < 100-1; i++)
           {

               d.Add(i, i); 

           }
           //d.Add(1, 35); 
           //d.Add(2, 45); 
           //d.Add(3, 95); 
          return d;
        } 
    
    
    
    } 
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Data_Binding();
    }

    private void Data_Binding() 
    {
        int totals = 100; 
        
        
        
     foreach (KeyValuePair<int, int> kvp in Datas) 
     
     { 
         double rate = kvp.Value / (double)totals; 
         double width = rate * 300; 
         switch (kvp.Key) 
     
     { 
         case 1:                      
         this.Label1.Text = GradientImage(width, rate);
         break;
         case 2:  
         this.Label2.Text = GradientImage(width, rate); 
         break;
         case 3:                      
        this.Label3.Text = GradientImage(width, rate); 
         break; 
     } 
     } 
    }      
    private string GradientImage(double width, double rate) 
    { return "<IMG height='21' src='images/bar.gif' width='" + width + "' align='absMiddle'> " + rate.ToString("p"); }
}
