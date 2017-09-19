<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SixKingStatus.aspx.cs" Inherits="SixKingStatus" %>
<%@ Register TagPrefix="obout" Namespace="OboutInc.Calendar2" Assembly="obout_Calendar2_Net" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>掐指一算(六王壬)</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 251pt; border-collapse: collapse"
            width="334">
            <colgroup>
                <col style="width: 54pt" width="72" />
                <col style="width: 110pt; mso-width-source: userset; mso-width-alt: 4672" width="146" />
                <col style="width: 87pt; mso-width-source: userset; mso-width-alt: 3712" width="116" />
            </colgroup>
            <tr height="22" style="height: 16.5pt">
                <td class="xl63" height="22" style="border-right: windowtext 0.5pt solid; border-top: windowtext 0.5pt solid;
                    border-left: windowtext 0.5pt solid; width: 80pt; border-bottom: windowtext 0.5pt solid;
                    height: 16.5pt; background-color: transparent">
                    <span style="font-family: 新細明體">農曆 (月/日)</span></td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext 0.5pt solid;
                    border-left: windowtext; width: 110pt; border-bottom: windowtext 0.5pt solid;
                    font-family: 新細明體; background-color: transparent" width="146">
                    <asp:TextBox ID="txtCalendar1" runat="server" Width="91px"></asp:TextBox><obout:calendar
                        id="Calendar1" runat="server" columns="1" dateformat="yyyy/MM/dd" datepickerimagepath="~/images/calendar.gif"
                        datepickermode="True" fulldaynames="璆,銝,鈭,銝,?鈭,摮" scriptpath="~/js/" shortdaynames="璆,銝,鈭,銝,?鈭,摮"
                        stylefolder="~/css/" textboxid="txtCalendar1"> </obout:calendar></td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext 0.5pt solid;
                    border-left: windowtext; width: 87pt; border-bottom: windowtext 0.5pt solid;
                    font-family: 新細明體; background-color: transparent" width="116">
                    狀態<br />
                    <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink></td>
            </tr>
            <tr height="22" style="font-family: 新細明體; height: 16.5pt">
                <td class="xl63" height="22" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext 0.5pt solid; border-bottom: windowtext 0.5pt solid; height: 16.5pt;
                    background-color: transparent; width: 80pt;">
                    </td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext; border-bottom: windowtext 0.5pt solid; background-color: transparent">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="計算" /></td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext; border-bottom: windowtext 0.5pt solid; background-color: transparent">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr height="22" style="font-family: 新細明體; height: 16.5pt">
                <td class="xl63" height="22" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext 0.5pt solid; border-bottom: windowtext 0.5pt solid; height: 16.5pt;
                    background-color: transparent; width: 80pt;">
                </td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext; border-bottom: windowtext 0.5pt solid; background-color: transparent">
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext; border-bottom: windowtext 0.5pt solid; background-color: transparent">
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr height="22" style="font-family: 新細明體; height: 16.5pt">
                <td class="xl64" height="22" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext 0.5pt solid; border-bottom: windowtext 0.5pt solid; height: 16.5pt;
                    background-color: transparent; width: 80pt;">
                    子</td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext; border-bottom: windowtext 0.5pt solid; background-color: transparent">
                    23~01</td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext; border-bottom: windowtext 0.5pt solid; background-color: transparent">
                    <asp:Label ID="LabelA1" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr height="22" style="font-family: 新細明體; height: 16.5pt">
                <td class="xl64" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext 0.5pt solid; border-bottom: windowtext 0.5pt solid; height: 17pt;
                    background-color: transparent; width: 80pt;">
                    丑</td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext; border-bottom: windowtext 0.5pt solid; background-color: transparent; height: 17pt;">
                    01~03</td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext; border-bottom: windowtext 0.5pt solid; background-color: transparent; height: 17pt;">
                    <asp:Label ID="LabelA2" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr height="22" style="font-family: 新細明體; height: 16.5pt">
                <td class="xl64" height="22" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext 0.5pt solid; border-bottom: windowtext 0.5pt solid; height: 16.5pt;
                    background-color: transparent; width: 80pt;">
                    寅</td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext; border-bottom: windowtext 0.5pt solid; background-color: transparent">
                    03~05</td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext; border-bottom: windowtext 0.5pt solid; background-color: transparent">
                    <asp:Label ID="LabelA3" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr height="22" style="font-family: 新細明體; height: 16.5pt">
                <td class="xl65" height="22" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext 0.5pt solid; border-bottom: windowtext 0.5pt solid; height: 16.5pt;
                    background-color: transparent; width: 80pt;">
                    <span style="font-family: 細明體">卯</span></td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext; border-bottom: windowtext 0.5pt solid; font-family: 新細明體;
                    background-color: transparent">
                    05~07</td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext; border-bottom: windowtext 0.5pt solid; font-family: 新細明體;
                    background-color: transparent">
                    <asp:Label ID="LabelA4" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr height="22" style="font-family: 新細明體; height: 16.5pt">
                <td class="xl63" height="22" style="border-right: windowtext 0.5pt solid; border-bottom: windowtext 0.5pt solid;
                    background-color: #ffff99; border-left-color: windowtext; border-top-color: windowtext;">
                    辰</td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext; border-bottom: windowtext 0.5pt solid; background-color: #ffff99">
                    07~09</td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext; border-bottom: windowtext 0.5pt solid; background-color: #ffff99">
                    <asp:Label ID="LabelA5" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr height="22" style="font-family: 新細明體; height: 16.5pt">
                <td class="xl63" height="22" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext 0.5pt solid; border-bottom: windowtext 0.5pt solid; height: 16.5pt;
                    background-color: transparent; width: 80pt;">
                    已</td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext; border-bottom: windowtext 0.5pt solid; background-color: transparent">
                    09~11</td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext; border-bottom: windowtext 0.5pt solid; background-color: transparent">
                    <asp:Label ID="LabelA6" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr height="22" style="font-family: 新細明體; height: 16.5pt">
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext 0.5pt solid; border-bottom: windowtext 0.5pt solid; height: 17pt;
                    background-color: transparent; width: 80pt;">
                    午</td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext; border-bottom: windowtext 0.5pt solid; height: 17pt;
                    background-color: transparent">
                    11~13</td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext; border-bottom: windowtext 0.5pt solid; height: 17pt;
                    background-color: transparent">
                    <asp:Label ID="LabelA7" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr height="22" style="font-family: 新細明體; height: 16.5pt">
                <td class="xl63" height="22" style="border-right: windowtext 0.5pt solid; border-bottom: windowtext 0.5pt solid;
                    background-color: #ffcc66; border-left-color: windowtext; border-top-color: windowtext;">
                    未</td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext; border-bottom: windowtext 0.5pt solid; background-color: #ffcc66">
                    13~15</td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext; border-bottom: windowtext 0.5pt solid; background-color: #ffcc66">
                    <asp:Label ID="LabelA8" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr height="22" style="font-family: 新細明體; height: 16.5pt">
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext 0.5pt solid; border-bottom: windowtext 0.5pt solid; height: 17pt;
                    background-color: transparent; width: 80pt;">
                    申</td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext; border-bottom: windowtext 0.5pt solid; background-color: transparent; height: 17pt;">
                    15~17</td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext; border-bottom: windowtext 0.5pt solid; background-color: transparent; height: 17pt;">
                    <asp:Label ID="LabelA9" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr height="22" style="font-family: 新細明體; height: 16.5pt">
                <td class="xl63" height="22" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext 0.5pt solid; border-bottom: windowtext 0.5pt solid; height: 16.5pt;
                    background-color: transparent; width: 80pt;">
                    酉</td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext; border-bottom: windowtext 0.5pt solid; background-color: transparent">
                    17~19</td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext; border-bottom: windowtext 0.5pt solid; background-color: transparent">
                    <asp:Label ID="LabelA10" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr height="22" style="font-family: 新細明體; height: 16.5pt">
                <td class="xl63" height="22" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext 0.5pt solid; border-bottom: windowtext 0.5pt solid; height: 16.5pt;
                    background-color: transparent; width: 80pt;">
                    戌</td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext; border-bottom: windowtext 0.5pt solid; background-color: transparent">
                    19~21</td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext; border-bottom: windowtext 0.5pt solid; background-color: transparent">
                    <asp:Label ID="LabelA11" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr height="22" style="font-family: 新細明體; height: 16.5pt">
                <td class="xl63" height="22" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext 0.5pt solid; border-bottom: windowtext 0.5pt solid; height: 16.5pt;
                    background-color: transparent; width: 80pt;">
                    亥</td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext; border-bottom: windowtext 0.5pt solid; background-color: transparent">
                    21~23</td>
                <td class="xl63" style="border-right: windowtext 0.5pt solid; border-top: windowtext;
                    border-left: windowtext; border-bottom: windowtext 0.5pt solid; background-color: transparent">
                    <asp:Label ID="LabelA12" runat="server" Text="Label"></asp:Label></td>
            </tr>
        </table>
    
    </div>
        <asp:Label ID="Label4" runat="server" Text="Label" Width="842px"></asp:Label>
    </form>
</body>
</html>
