<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProcessStart.aspx.cs" Inherits="ProcessStart" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ProcessStart Sample</title>
</head>
<body>
    <form id="form1" runat="server">
        
    <div>
   <asp:Button ID="Button1" runat="server" Text="Start" OnClick="Button1_Click" />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" Text="End" OnClick="Button2_Click" /><br />
        <asp:TextBox ID="TextBox1" runat="server" Height="301px" TextMode="MultiLine" Width="621px"></asp:TextBox></div>
    </form>
</body>
</html>
