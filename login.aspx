<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SOS login</title>
    <style type="text/css">
#container {
  margin: 0 auto;
  width: 85%;
  font size='3'
}
</style>
<meta http-equiv="Content-Type" content="text/html; charset=big5" />
 <meta http-equiv="Page-Enter" content="blendTrans(duration=0.5)" />
  <meta http-equiv="Page-Exit" content="blendTrans(duration=0.5)" />
</head>
<body background="" style="background-color: #ffffff">
    <form id="form1" runat="server">
        <br />
    <div id="container" align="center">
    
   <%-- <marquee  id="alarm_scroller"  style="FILTER: Alpha(Opacity=200, FinishOpacity=0, Style=2, StartX=150, StartY=150, FinishX=0, FinishY=0); WIDTH: 500px; COLOR:#0000FF; HEIGHT: 50px; TEXT-ALIGN: center" scrollAmount=2 scrollDelay=100 direction=up width=528 bgColor=#FFFF80 height=390 align="middle" border="0" runat="server" >  </marquee>--%>
        <div class="clearfix uiHeaderTop">
            <div>
                <h2>
                    <span class="style1" style="color: #3300ff">
                        <center>
                            <h2>
                                <span class="style1"></span> 會員登入畫面</h2>
                            <hr />
                                </center>
                        <center>
                       <table border="0" bordercolor="#000000" cellpadding="2" cellspacing="1"  style="width: 30% ;height: 20% ">
                                    <tr>
                                        <td align="center" bgcolor="#A2A2A2" style="height: 23px">
                                            <span class="style6" style="font-size: 12pt; color:black;">公佈欄</span></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 164px">
                                            <!------------ JXq}l ------------>
                                            <marquee id="bulletin" runat="server" direction="up" height="160" onmouseout="bulletin.start()"
                                                onmouseover="bulletin.stop()" scrollamount="1" scrolldelay="55" width="100%"><% getBulletinText(); %></marquee>
                                        </td>
                                    </tr>
                                </table>


                            &nbsp;<asp:Label ID="Label1" runat="server" Text="Label" Font-Size="Medium" Height="29px" Width="228px"></asp:Label></center>
                    </span>
                    <table style="width: 345px; height: 113px">
                        <tr>
                           
                            <td style="width: 125px">
                                帳號</td>
                            <td style="width: 296px">
                                <asp:TextBox ID="TextBox1" runat="server" Height="19px" Width="138px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 125px">
                                密碼</td>
                            <td style="width: 296px">
                                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 125px">&nbsp
                            </td>
                            <td style="width: 296px">
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="登入" />
                                </td>
                        </tr>
                    </table>

        <br />
                </h2>
            </div>
        </div>
        
    
    </div>
    </form>
    <table border="0" cellpadding="0" cellspacing="0" style="background-color: white"
                width="100%">
                <tr>
                    <td bgcolor="gray" height="28" style="font-size: 11px; color: #ffffff; line-height: 16px;
                        font-family: Verdana,?啁敦?��?; text-align: center; text-decoration: none">
                        SOS 股市氣象台 版權所有 Copyright &copy; 2010 Oscar Group., Design By Oscar</td>
                </tr>
</table>
</body>
</html>
