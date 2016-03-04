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

public partial class class_study : System.Web.UI.Page
{
    Int32 aaa = 0;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        IMyInterface abcdef = new InterfaceImplementer();
        //InterfaceImplementer abc = new InterfaceImplementer();

        aaa = abcdef.MethodToImplement();
        Response.Write(aaa);

    }

    interface IMyInterface
    {
        void MethodToImplement();
    }

      class InterfaceImplementer : IMyInterface
    {
        public InterfaceImplementer()
    {
      
    }


        public Int32 MethodToImplement()
        {
            Int32 bbb = 0;
            for (int i = 0; i < 10; i++)
            {
                bbb++;
            }
           // Response.Write("MethodToImplement() called.");
            return bbb;
        }
    }



}
