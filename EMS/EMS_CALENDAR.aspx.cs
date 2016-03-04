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
using System.Drawing;



public partial class EMS_EMS_CALENDAR : System.Web.UI.Page
{
    public DataView dv = new DataView();
    DataSet ds = new DataSet();
    string conn = System.Configuration.ConfigurationSettings.AppSettings["jump"];
    string today = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd");

    string today_minus17 = DateTime.Now.AddDays(-17).ToString("yyyy/MM/dd");

    string today_detail = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd HH:mm");
    string sql_temp = "";
    string sql_temp1 = "";
    DataSet ds_temp = new DataSet();
    DataSet ds_temp1 = new DataSet();
    //string navigateUrl = "http://www.kimo.com.tw";
    string navigateUrl = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        //DBUtil.setUserData(); 
        if (!Page.IsPostBack)
        {
            // setDept(); 
        }
        getProjectTaskDs();
        //setColorList(); 

    }

    public Color getStatusColor(string status)
    {
        switch (status)
        {
            case "Receiving":
                return Color.SpringGreen;
                break;
            case "Processing":
                return Color.LightSkyBlue;
                break;
            case "Close":
                return Color.Gray;
                break;
            case "Pending":
                return Color.Yellow;
                break;
            case "Delay":
                return Color.Red;
                break;
            default:
                //return Color.FromName("#FAEBD7");
                return Color.Yellow;
                break;
        }
    }
    public void addControl(DayRenderEventArgs e, string project_id, string project_name, string status, DateTime estimate_start_dttm, DateTime estimate_end_dttm, string navigateUrl)
    {
        string strStartText = "<div align='left' style='padding:2px'>";
        string strEndText = "</div>";

        if ((status != "Close" && status != "Pending") && estimate_end_dttm < DateTime.Now)
            status = "Delay";

        //蝜摰璆緮澆亙唳∪蝔? 
        if (e.Day.Date >= estimate_start_dttm && e.Day.Date <= estimate_end_dttm)
        {
            HyperLink link = new HyperLink();

            string strNavigateUrl = navigateUrl + project_id;
            string statusColor = getStatusColor(status).Name;
            string strToolTip = "開啟[" + project_name + "]檢視";

            project_name = "<span style='background-color:" + statusColor + ";'>" + project_name + "</span>";

            if (e.Day.Date == estimate_start_dttm)
                strStartText += "<span style='font-weight:bold; font-size:15px; color:red'>{</span>";
            if (e.Day.Date == estimate_end_dttm)
                strEndText = "<span style='font-weight:bold; font-size:15px; color:red'>}</span>" + strEndText;

            link.Text = strStartText + project_name + strEndText;
            link.Target = "_blank";
            link.NavigateUrl = strNavigateUrl;
            link.ToolTip = strToolTip;

            e.Cell.Controls.Add(link);
        }

        //緡蹂賊寄ighlight憿鞎 
        if (e.Day.Date >= DateTime.Now && e.Day.Date < DateTime.Now.AddDays(7))
        {
            e.Cell.BackColor = System.Drawing.Color.Azure;
        }
    }
    private DataSet getProjectTaskDs()
    {
        string strSql = string.Empty;
        string selectedDept = "''";

        //strSql = @"select project_id, project_name, to_char(t.estimate_start_date,'yyyy/mm/dd') estimate_start_date, to_char(t.estimate_end_date,'yyyy/mm/dd') estimate_end_date, 
        //status from tms_project t where t.applicant_dept in ({0}) and nvl(t.status,'N/A') not in ('Cancel') "; 

        strSql = @"select sn, event_name, format(t.event_dttm,'yyyy/MM/dd') as date_time,
flag as status  from EMS_EVENT t  ";

        //if(chkDept.SelectedIndex > -1) 
        // selectedDept = dsutil.getCheckbox2Sql(chkDept); 
        //strSql = string.Format(strSql, selectedDept); 

        strSql = string.Format(strSql, selectedDept);

        ds = func.get_dataSet_access(strSql, conn);
        // ds = DBUtil.GetDataset(strSql); 

        return ds;

    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        getProjectList(Calendar1.SelectedDate.ToString("yyyy/MM/dd"));
    }

    private void getProjectList(string strSelectedDate)
    {
        //string strSql = string.Empty; 

        //strSql = "select a.*,rownum rn from ( "; 
        //strSql += "select t.project_id , t.project_name , t.applicant, t.apply_date , to_char(t.estimate_start_date,'YYYY/MM/DD') estimate_start_date , to_char(t.estimate_end_date,'YYYY/MM/DD') estimate_end_date , to_char(t.actual_start_date,'YYYY/MM/DD') actual_start_date, to_char(t.actual_end_date,'YYYY/MM/DD') actual_end_date , t.priority, t.status,x.ai_total,x.ai_processing,x.ai_hour,x.ai_unclose_ratio,t1.project_group "; 
        //strSql += " from tms_project t,tms_project_group t1, "; 
        //strSql += "(select t2.*,decode(t2.ai_total,0,0,round(((t2.ai_total-t2.ai_processing)/t2.ai_total),4)*100) ai_unclose_ratio from ( "; 
        //strSql += "select t.project_id,count(*) ai_total, "; 
        //strSql += "sum(decode(t1.status,'Receiving',1,'Processing',1,'Pending',1,0)) ai_processing, "; 
        //strSql += "sum(t1.ai_hour) ai_hour "; 
        //strSql += "from tms_task t,tms_action_item t1 "; 
        //strSql += "where t.task_id=t1.task_id "; 
        //strSql += "and t1.status <> 'Cancel' "; 
        //strSql += "group by t.project_id) t2) x where t.project_id=x.project_id(+) and t.project_group_id = t1.project_id(+) "; 
        //strSql += "and to_date('" + strSelectedDate + "','yyyy/mm/dd') between t.estimate_start_date and t.estimate_end_date and t.status not in ('Cancel') ) a"; 

        ////strSql = @"select t.project_id , t.project_name , t.applicant, t.apply_date , to_char(t.estimate_start_date,'YYYY/MM/DD') estimate_start_date , to_char(t.estimate_end_date,'YYYY/MM/DD') estimate_end_date , to_char(t.actual_start_date,'YYYY/MM/DD') actual_start_date, to_char(t.actual_end_date,'YYYY/MM/DD') actual_end_date , t.priority, t.status 
        //// from tms_project t where to_date('" + strSelectedDate + "','yyyy/mm/dd') between t.estimate_start_date and t.estimate_end_date and status not in ('Cancel') "; 

        //Project_list1.bindGV(strSql); 
        //Project_list1.getCalendarProject(strSelectedDate); 
    }

    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        string estimate_start_date, estimate_end_date = string.Empty;
        string project_id = string.Empty;
        string project_name = string.Empty;
        string status = string.Empty;
        DateTime estimate_start_dttm, estimate_end_dttm = new DateTime();

        DateTime currentData = DateTime.Now.Date;
        dv = ds.Tables[0].DefaultView;
        ////dv.RowFilter = e.Day.Date.ToString("yyyy/MM/dd") + " between estimate_start_date and estimate_end_date "; 
        //dv.RowFilter = string.Format("estimate_start_date <= '{0}' and estimate_end_date >= '{0}'", e.Day.Date.ToString("yyyy/MM/dd")); 
        dv.RowFilter = string.Format("date_time <= '{0}' and date_time >= '{0}'", e.Day.Date.ToString("yyyy/MM/dd"));
        foreach (DataRow Rows in dv.ToTable().Rows)
        {
            estimate_start_date = Rows["date_time"].ToString();
            estimate_end_date = Rows["date_time"].ToString();
            //project_id = Rows["TASK_NAME"].ToString(); 
            project_name = "●" + Rows["event_name"].ToString();
            status = Rows["status"].ToString();

            estimate_start_dttm = DateTime.Parse(estimate_start_date);
            estimate_end_dttm = DateTime.Parse(estimate_end_date);

            addControl(e, project_id, project_name, status, estimate_start_dttm, estimate_end_dttm, navigateUrl);
        }

    }
}
