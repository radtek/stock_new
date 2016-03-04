<%@ Page Language="C#" aspcompat="true" AutoEventWireup="true" CodeFile="Send_SMS.aspx.cs" Inherits="SMS_Send_SMS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Send SMS</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <fieldset > 
<legend align="center" style="color:blue;text-align:center"><strong><span style="font-family: Century Gothic">
    Send SMS:</span></strong></legend> 
        
        <table hight=100% width=100%><tr><td align='center' valign='middle'> 
<table style="width: 530px">
            <tr>
                <td style="height: 21px">
                    帳號：</td>
                <td style="height: 21px; text-align: left;">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                <td style="height: 21px">
                </td>
            </tr>
            <tr>
                <td style="height: 21px">
                    密碼：</td>
                <td style="height: 21px; text-align: left;">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                <td style="height: 21px">
                </td>
            </tr>
            <tr>
                <td style="height: 26px">
                    手機號碼：</td>
                <td style="height: 26px; text-align: left">
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                <td style="height: 26px">
                </td>
            </tr>
    <tr>
        <td style="height: 69px">
            簡訊內容：</td>
        <td style="height: 69px; text-align: left">
            <asp:TextBox ID="TextBox4" runat="server" Height="75px" TextMode="MultiLine" Width="373px"></asp:TextBox></td>
        <td style="height: 69px">
        </td>
    </tr>
    <tr>
        <td>
            即時傳送：</td>
        <td style="text-align: left">
            <asp:RadioButton ID="RealTime"  runat="server" Text="RealTime"  /></td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            預約傳送：*</td>
        <td style="text-align: left">
            <asp:TextBox ID="TextBox6" runat="server" TextMode="Password" Width="149px"></asp:TextBox></td>
        <td>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td style="text-align: left">
            <asp:Button ID="Button2" runat="server" Text="傳送" OnClick="Button2_Click" /></td>
        <td>
        </td>
    </tr>
        </table>
            *(<span style="color: #ff00ff">EX : 021210110200 表示西元2002年12月10日11點02分</span>)</td></tr></table>

        
        
        
</fieldset> 


    </div>
    </form>
</body>
</html>
