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
using System.Threading;
using System.Collections.Generic;
using System.IO;


public partial class SemaphoreDemo : System.Web.UI.Page
{
    public static Semaphore Pool = new Semaphore(1, 1);
    private static List<Thread> _threads = new List<Thread>();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i = 0; i <= 100-1; i++)
        {

            //Thread t = new Thread(new ThreadStart(DoWork));

            //Thread t = new Thread(DoWork(i));

            new Thread(DoWork).Start(i);

            //t.Start(i);
            //_threads.Add(t);
            Thread.Sleep(200);
        }

        for (int j = 0; j <= _threads.Count-1; j++)
        {

            Thread.Sleep(200);
          
            String TEMP = "";
            TEMP = string.Format("Thread[{0}]:{1},<BR>.", _threads[j].ManagedThreadId, _threads[j].ThreadState);
            Response.Write(TEMP);
            //_threads[j].Start();
            //Thread.Sleep(200);
           // Response.Write(TEMP);

        }

        Response.Write("MAIN END");

       
    }

    public  void DoWork(object id) 
     
{ 
          
// Wait on a semaphore slot to become available 

        string tmp="";
        tmp = id.ToString()+Thread.CurrentThread.ManagedThreadId.ToString()+"_"+ Thread.CurrentThread.ThreadState.ToString();
        Response.Write(tmp);         
Pool.WaitOne();



Response.Write("Acquired slot... <br>"); 
           
for (int k = 0; k <= 1000; k++) 
            
{

    Response.Write(k + 1); 
           
}

Response.Write("Released slot... <br>");



Response.Write("last "+tmp);      
// Release the semaphore slot 
            
Pool.Release();
Thread.Sleep(200);       
}

    public static void DeleteRecursivelyWithMagicDust(string destinationDir)
    {
        const int magicDust = 10;
        for (var gnomes = 1; gnomes <= magicDust; gnomes++)
        {
            try
            {
                Directory.Delete(destinationDir, true);
            }
            catch (DirectoryNotFoundException)
            {
                return;  // good!
            }
            catch (IOException)
            { // System.IO.IOException: The directory is not empty
                //System.Diagnostics.Debug.WriteLine("Gnomes prevent deletion of {0}! Applying magic dust, attempt #{1}.", destinationDir, gnomes);

                // see http://stackoverflow.com/questions/329355/cannot-delete-directory-with-directory-deletepath-true for more magic
                Thread.Sleep(50);
                continue;
            }
            return;
        }
        // depending on your use case, consider throwing an exception here
    }
}
