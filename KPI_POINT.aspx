<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="KPI_POINT.aspx.cs" Inherits="KPI_POINT" Title="KPI Point" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 621px">
        <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 109px; border-bottom: #000033 thin solid">
                輸入點位</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 109px; border-bottom: #000033 thin solid">
                高點: &nbsp; &nbsp; &nbsp; &nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="60px"></asp:TextBox><br />
                低點: &nbsp; &nbsp;&nbsp; &nbsp;
                <asp:TextBox ID="TextBox2" runat="server" Width="60px"></asp:TextBox><br />
                現在指數:<asp:TextBox ID="TextBox3" runat="server" Width="60px"></asp:TextBox><br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Query" Width="69px" /></td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 143px; border-bottom: #000033 thin solid">
                現在指數: &nbsp;
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="https://tw.stock.yahoo.com/s/tse.php"
                    Target="_blank">指數查詢</asp:HyperLink><br />
                <asp:TextBox ID="TextBox4" runat="server" Width="63px"></asp:TextBox><br />
                隱含波動率:<br />
                <asp:TextBox ID="TextBox5" runat="server" Width="63px"></asp:TextBox><br />
                到期天數:<br />
                <asp:TextBox ID="TextBox6" runat="server"  Width="63px"></asp:TextBox><br />
                已經開盤幾小時<br />
                <asp:TextBox ID="TextBox7" runat="server" Width="63px"></asp:TextBox><br />
                <asp:Button ID="Button2" runat="server" Text="Query" OnClick="Button2_Click" /><br />
                下限: &nbsp;
                <asp:Label ID="Label30" runat="server" Text="Label" Width="68px"></asp:Label>
                ==&gt; &nbsp;
                <asp:Label ID="Label32" runat="server" Text="Label" Width="68px"></asp:Label><br />
                上限: &nbsp;
                <asp:Label ID="Label31" runat="server" Text="Label" Width="68px"></asp:Label>
                ==&gt; &nbsp;
                <asp:Label ID="Label33" runat="server" Text="Label" Width="68px"></asp:Label><br />
                <br />
                相對位置</td>
        </tr>
        <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 109px; border-bottom: #000033 thin solid">
                突破1(0.809)</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 109px; border-bottom: #000033 thin solid">
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>&nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 143px; border-bottom: #000033 thin solid">
                &nbsp;</td>
        </tr>
        <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid; height: 21px;">
                &nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid; height: 21px;">
                &nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 143px; border-bottom: #000033 thin solid; height: 21px;">
                <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>&nbsp;</td>
        </tr>
        <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 109px; border-bottom: #000033 thin solid; height: 11px;">
                突破2(0.618)</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 109px; border-bottom: #000033 thin solid; height: 11px;">
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>&nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 143px; border-bottom: #000033 thin solid; height: 11px;">
                &nbsp;</td>
        </tr>
        <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid">
                &nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid">
                &nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 143px; border-bottom: #000033 thin solid">
                <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>&nbsp;</td>
        </tr>
        <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid">
                突破3(0.500)</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid">
                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>&nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 143px; border-bottom: #000033 thin solid">
                &nbsp;</td>
        </tr>
        <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid">
                &nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid">
                &nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 143px; border-bottom: #000033 thin solid">
                <asp:Label ID="Label18" runat="server" Text="Label"></asp:Label>&nbsp;</td>
        </tr>
         <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 109px; border-bottom: #000033 thin solid">
                突破4(0.382)</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 109px; border-bottom: #000033 thin solid">
                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>&nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 143px; border-bottom: #000033 thin solid">
                &nbsp;</td>
        </tr>
        <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid; height: 19px;">
                &nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid; height: 19px;">
                &nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 143px; border-bottom: #000033 thin solid; height: 19px;">
                <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>&nbsp;</td>
        </tr>
         <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 109px; border-bottom: #000033 thin solid; height: 36px;">
                突破5(0.191)</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 109px; border-bottom: #000033 thin solid; height: 36px;">
                <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>&nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 143px; border-bottom: #000033 thin solid; height: 36px;">
                &nbsp;</td>
        </tr>
         <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 109px; border-bottom: #000033 thin solid; background-color: #ff0000">
                &nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 109px; border-bottom: #000033 thin solid; background-color: #ff0000">
                &nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 143px; border-bottom: #000033 thin solid">
                <asp:Label ID="Label20" runat="server" Text="Label"></asp:Label>&nbsp;</td>
        </tr>
        <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 109px; border-bottom: #000033 thin solid; height: 24px">
                盤整1(0.191)</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 109px; border-bottom: #000033 thin solid; height: 24px">
                <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>&nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 143px; border-bottom: #000033 thin solid; height: 24px">
                &nbsp;</td>
        </tr>
        <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid; height: 25px">
                &nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid; height: 25px">
                &nbsp;
                </td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 143px; border-bottom: #000033 thin solid; height: 25px">
                <asp:Label ID="Label21" runat="server" Text="Label"></asp:Label>&nbsp;</td>
        </tr>
        <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 109px; border-bottom: #000033 thin solid;">
                盤整2(0.382)</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 109px; border-bottom: #000033 thin solid;">
                <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>&nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 143px; border-bottom: #000033 thin solid;">
                &nbsp;</td>
        </tr>
        <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid">
                &nbsp;
               </td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid">
                &nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 143px; border-bottom: #000033 thin solid">
                <asp:Label ID="Label22" runat="server" Text="Label"></asp:Label>&nbsp;</td>
        </tr>
        <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid">
                盤整3(0.500)
            </td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid">
                <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>&nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 143px; border-bottom: #000033 thin solid">
                &nbsp;</td>
        </tr>
        <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid">
                &nbsp;
            </td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid">
                &nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 143px; border-bottom: #000033 thin solid">
                <asp:Label ID="Label23" runat="server" Text="Label"></asp:Label>&nbsp;</td>
        </tr>
       <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 109px; border-bottom: #000033 thin solid">
                盤整4(0.618)</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 109px; border-bottom: #000033 thin solid">
                <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>&nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 143px; border-bottom: #000033 thin solid">
                &nbsp;</td>
        </tr>
        <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid">
                &nbsp;
                </td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid">
                &nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 143px; border-bottom: #000033 thin solid">
                <asp:Label ID="Label24" runat="server" Text="Label"></asp:Label>&nbsp;</td>
        </tr>
        <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid">
                盤整5(0.809)</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid">
                <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>&nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 143px; border-bottom: #000033 thin solid">
                &nbsp;</td>
        </tr>
        <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid; background-color: #009933">
                &nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid; background-color: #009933">
                &nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 143px; border-bottom: #000033 thin solid">
                <asp:Label ID="Label25" runat="server" Text="Label"></asp:Label>&nbsp;</td>
        </tr>
         <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 109px; border-bottom: #000033 thin solid">
                下跌1(0.191)</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 109px; border-bottom: #000033 thin solid">
                <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>&nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 143px; border-bottom: #000033 thin solid">
                &nbsp;</td>
        </tr>
        <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid">
                &nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid">
                &nbsp;
               </td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 143px; border-bottom: #000033 thin solid">
                <asp:Label ID="Label26" runat="server" Text="Label"></asp:Label>&nbsp;</td>
        </tr>
         <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 109px; border-bottom: #000033 thin solid">
                下跌2(0.382)</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 109px; border-bottom: #000033 thin solid">
                <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>&nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 143px; border-bottom: #000033 thin solid">
                &nbsp;</td>
        </tr>
        <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid">
                &nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid">
                &nbsp;
              </td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 143px; border-bottom: #000033 thin solid">
                <asp:Label ID="Label27" runat="server" Text="Label"></asp:Label>&nbsp;</td>
        </tr>
        <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid">
                下跌3(0.500)</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid">
                <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>&nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 143px; border-bottom: #000033 thin solid">
                &nbsp;</td>
        </tr>
        <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid">
                &nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid">
                &nbsp;
            </td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 143px; border-bottom: #000033 thin solid">
                <asp:Label ID="Label28" runat="server" Text="Label"></asp:Label>&nbsp;</td>
        </tr>
         <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 109px; border-bottom: #000033 thin solid">
                下跌4(0.618)</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 109px; border-bottom: #000033 thin solid">
                <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>&nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 143px; border-bottom: #000033 thin solid">
                &nbsp;</td>
        </tr>
        <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid">
                &nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 109px; border-bottom: #000033 thin solid">
                &nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid;
                width: 143px; border-bottom: #000033 thin solid">
                <asp:Label ID="Label29" runat="server" Text="Label"></asp:Label>&nbsp;</td>
        </tr>
        <tr align="left">
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 109px; border-bottom: #000033 thin solid">
                下跌5(0.809)</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 109px; border-bottom: #000033 thin solid">
                <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>&nbsp;</td>
            <td style="border-right: #000033 thin solid; border-top: #000033 thin solid; border-left: #000033 thin solid; width: 143px; border-bottom: #000033 thin solid">
                &nbsp;</td>
        </tr>
    </table>


</asp:Content>

