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
using System.Text;

public partial class ucl_dropdownmulti : System.Web.UI.UserControl
{
    	public ListItemCollection Items{
			get{return lstItemList.Items;}
		}
		public ListBox InnerList{
			get{return lstItemList;}
		}
		public string Text{
			get{return TextBox1.Text;}
			set{TextBox1.Text = value;}
		}
		public bool IsSomethingSelected{
			get{
				if(lstItemList.SelectedIndex<0) return false;
				return true;
			}
		}
		public int SelectedIndex{
			get{return lstItemList.SelectedIndex;}
		}
        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        ///		Required method for Designer support - do not modify
        ///		the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

        }
        #endregion

        protected void btnSelect_Click(object sender, System.EventArgs e)
        {
            lstItemList.Visible = !lstItemList.Visible;
            btnSelect.Text = btnSelect.Text == "V" ? "^" : "V";
            TextBox1.Text = getValues();
        }
        private string getValues()
        {
            if (lstItemList.SelectedIndex < 0) return "";
            StringBuilder returnValue = new StringBuilder();
            foreach (ListItem thisItem in lstItemList.Items)
            {
                if (thisItem.Selected)
                    returnValue.Append("'" + thisItem.Value + "', ");
            }
            returnValue.Remove(returnValue.Length - 2, 2);
            return returnValue.ToString();
        }
    protected void Page_Load(object sender, EventArgs e)
    {
        
	

		
			lstItemList.Attributes.Add("style","position: absolute; left: 0px; top: 20px;");
	

		
    }
}

