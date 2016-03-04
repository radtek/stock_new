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
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;



public partial class usercontrol_WebUserControl : System.Web.UI.UserControl
{
    private BackgroundWorker bw = new BackgroundWorker();
    protected void Page_Load(object sender, EventArgs e)
    {
        InitializeComponent();

        bw.WorkerReportsProgress = true;
        bw.WorkerSupportsCancellation = true;
        bw.DoWork += new DoWorkEventHandler(bw_DoWork);
        bw.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
        bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
    }



    private void buttonStart_Click(object sender, RoutedEventArgs e)
    {
        if (bw.IsBusy != true)
        {
            bw.RunWorkerAsync();
        }
    }
    private void buttonCancel_Click(object sender, RoutedEventArgs e)
    {
        if (bw.WorkerSupportsCancellation == true)
        {
            bw.CancelAsync();
        }
    }
    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        BackgroundWorker worker = sender as BackgroundWorker;

        for (int i = 1; (i <= 10); i++)
        {
            if ((worker.CancellationPending == true))
            {
                e.Cancel = true;
                break;
            }
            else
            {
                // Perform a time consuming operation and report progress.
                System.Threading.Thread.Sleep(500);
                worker.ReportProgress((i * 10));
            }
        }
    }
    private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if ((e.Cancelled == true))
        {
            this.tbProgress.Text = "Canceled!";
        }

        else if (!(e.Error == null))
        {
            this.tbProgress.Text = ("Error: " + e.Error.Message);
        }

        else
        {
            this.tbProgress.Text = "Done!";
        }
    }
    private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        this.tbProgress.Text = (e.ProgressPercentage.ToString() + "%");
    }

}
