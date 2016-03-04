<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sell_stock_transaction.aspx.cs" Inherits="sell_stock_transaction" %>


<%@ Register TagPrefix="obout" Namespace="OboutInc.Calendar2" Assembly="obout_Calendar2_Net" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head1" runat="server">
    <title>Sell_Stock_Transation</title>
    <link href="app_themes/layout/layout.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="display: inline; z-index: 105; left: 10px; width: 90%; color: black;
            top: 0px; height: 16px; background-color: white">
            <br />
            <table id="Table3" align="center" border="0" cellpadding="0" cellspacing="0" width="98%">
                <tr>
                    <td style="height: 9px; width: 10px;">
                        <img src="images/tables/default_lt.gif" /></td>
                    <td style="background-image: url(images/tables/default_t.gif); height: 9px;">
                        <img height="9" src="images/tables/transparent.gif" /></td>
                    <td style="height: 9px; width: 10px;">
                        <img src="images/tables/default_rt.gif" /></td>
                </tr>
                <tr>
                    <td style="background-image: url(images/tables/default_l.gif); width: 10px;">
                        <img src="images/tables/transparent.gif" width="9"></td>
                    <td align="middle" width="100%">
                        <table align="center" cellspacing="0" bordercolordark="#ffffff" cellpadding="2" width="100%"
                            bordercolorlight="#7a9cb7" border="1">
                            <tr>
                                <td background="" colspan="4" class="pageTitle">
                                    <table width="100%">
                                        <tr>
                                            <td align="left" style="height: 30px">
                                                <span id="Span1" style="font-size: 16pt; font-family: Century Gothic"><strong>Sell Stock
                                                    Transaction紀錄</strong></span></td>
                                            <td align="right" style="font-size: 12px; color: navy; height: 30px;">
                                                <span style="color: #ff0000"></span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr style="font-size: 12pt">
                                <td class="pageTD" align="center" style="height: 7px; width: 10%;">
                                    SN</td>
                                <td style="height: 7px; text-align: left;" valign="top" colspan="3">
                                    <asp:Label ID="Label_SN" runat="server" Text="Label" Width="88px"></asp:Label></td>
                            </tr>
                            <tr style="font-size: 12pt">
                                <td align="center" class="pageTD" style="width: 10%; height: 7px">
                                    User Id</td>
                                <td colspan="3" style="height: 7px; text-align: left" valign="top">
                                    <asp:Label ID="Label_user_id" runat="server" Text="Label" Width="91px"></asp:Label></td>
                            </tr>
                            <tr style="font-size: 12pt">
                                <td class="pageTD" align="center" style="height: 5px; width: 10%;">
                                    下單股票(代號)</td>
                                <td style="height: 5px; text-align: left;" valign="top" colspan="3">
                                    <asp:Label ID="Label_stock_id" runat="server" Text="Label" Width="91px"></asp:Label></td>
                            </tr>
                            <tr style="font-size: 12pt">
                                <td class="pageTD" align="center" style="height: 5px; width: 10%;">
                                    股名/參考價格</td>
                                <td style="height: 5px; text-align: left;" valign="top" colspan="3">
                                    <asp:Label ID="Label_stock_name" runat="server" Text="Label" Width="91px"></asp:Label>&nbsp;&nbsp;
                                    /&nbsp;&nbsp;
                                    <asp:Label ID="Label_stock_price" runat="server" Text="Label" Width="91px"></asp:Label>
                                </td>
                            </tr>
                            <tr style="font-size: 12pt">
                                <td class="pageTD" align="center" style="height: 5px; width: 10%;">
                                    下單張數</td>
                                <td style="height: 5px; text-align: left;" valign="top" colspan="3">
                                    <asp:Label ID="Label_stock_can_sell_num" runat="server" Text="Label" Width="91px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="pageTD" colspan="8" style="height: 35px; text-align: left;">
                                    <table style="width: 236px; height: 7px">
                                        <tr>
                                            <td align='left' valign='top' style="width: 14px; height: 17px;">
                                                <asp:Button ID="Button2" runat="server" Text="Sell" Width="53px" OnClick="Button2_Click" /></td>
                                           
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="font-size: 12pt; background-image: url(images/tables/default_r.gif); width: 10px;">
                        <img src="images/tables/transparent.gif" width="9"></td>
                </tr>
                <tr style="font-size: 12pt">
                    <td style="height: 9px; width: 10px;">
                        <img src="images/tables/default_lb.gif"></td>
                    <td style="background-image: url(images/tables/default_b.gif); height: 9px;">
                        <img height="9" src="images/tables/transparent.gif"></td>
                    <td style="height: 9px; width: 10px;">
                        <img src="images/tables/default_rb.gif"></td>
                </tr>
            </table>
    </form>
</body>
</html>

<script language="javascript">
function check_field()
{
    if( document.getElementById("TextBox1").value=="")
    {
        alert("請輸入 紀錄人員!!!");
        return false;
    }
    else if( document.getElementById("txtEstimateStartDate").value=="")
    {
        alert("請輸入 發生時間!!!");
        return false;
    }
    else if( document.getElementById("DropDownList1").value=="請選擇")
    {
        alert("請選擇 異常種類!!!");
        return false;
    }
      else if( document.getElementById("DropDownList2").value=="請選擇" )
    {
        alert("請選擇 異常發生廠區!!!");
        return false;
    }
    
    else if( document.getElementById("DropDownList3").value=="請選擇" )
    {
        alert("請選擇 部門!!!");
        return false;
    }
    
    else if( document.getElementById("TextBox5").value=="" )
    {
        alert("請輸入 異常狀況敘述!!!");
        return false;
    }
      
     else if( document.getElementById("TextBox4").value=="" )
    {
        alert("請輸入 通知廠區負責人!!!");
        return false;
    }
   
   
     
     
    else
    {
        return true;
    }
     
}


function AddTask()
{
//   w = window.open("task_apply.aspx?project_id="+ document.getElementById('lblProjectNo').innerText ,"Add_task", "height=600, width=950, left=200, top=150, " +  "location=no,	menubar=no, resizable=yes, " + "scrollbars=yes, titlebar=no, toolbar=no", true);
//   w.focus();
   return false;
}

function OpenTask(task_id)
{
//   w = window.open("task_assign.aspx?task_id="+ task_id ,"task_maintain", "height=600, width=950, left=200, top=150, " +  "location=yes,	menubar=yes, resizable=yes, " + "scrollbars=yes, titlebar=no, toolbar=yes", true);
//   w.focus();
   return false;
}

function showHideAnswer(obj,imgObj)
{
    if (document.getElementById(obj) == null)
        return;
    if(document.getElementById(obj).style.display=='none'){
        document.getElementById(imgObj).src = "../images/close13.gif";
	    document.getElementById(obj).style.display='block';
    }else{
        document.getElementById(imgObj).src = "../images/open13.gif";
	    document.getElementById(obj).style.display='none';
    }		
}
</script>
