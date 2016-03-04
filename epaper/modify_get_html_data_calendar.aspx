﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="modify_get_html_data_calendar.aspx.cs" Inherits="epaper_modify_get_html_data_calendar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Stock_CALENDAR</title>
</head>
<body>
    <form id="form1" runat="server">
   <div style="text-align: center">
       <span style="color: #0000ff"><strong><span style="font-family: Century Gothic">STOCK CALENDAR</span></strong>
       </span>
<asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66" 
BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
ForeColor="#663399" Height="500px" OnDayRender="Calendar1_DayRender" ShowGridLines="True" 
Width="860px" OnSelectionChanged="Calendar1_SelectionChanged"> 
<SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" BorderColor="Black" ForeColor="Black" /> 
<SelectorStyle BackColor="#FFCC66" /> 
<TodayDayStyle BackColor="#FFCC66" ForeColor="DarkRed" /> 
<OtherMonthDayStyle ForeColor="#CC9966" /> 
<NextPrevStyle Font-Size="9pt" ForeColor="#FFFFCC" /> 
<DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" /> 
<TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="9pt" ForeColor="#FFFFCC" /> 
</asp:Calendar> 
</div> 

    </form>
</body>
</html>
