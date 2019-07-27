<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="op_COST1.aspx.cs" Inherits="op_COST1"
    Title="OP_COST" %>

<%@ Register TagPrefix="obout" Namespace="OboutInc.Calendar2" Assembly="obout_Calendar2_Net" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<link href="app_themes/layout/layout.css" rel="stylesheet" type="text/css" />
    <form id="form1">
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
                                                <span id="Span1" style="font-size: 16pt; font-family: Century Gothic"><strong>查詢OP_COST紀錄</strong></span></td>
                                            <td align="right" style="font-size: 12px; color: navy; height: 30px;">
                                                <span style="color: #ff0000"></span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr style="font-size: 12pt">
                                <td align="center" class="pageTD" style="width: 10%; height: 7px">
                                    DUE_TIME</td>
                                <td colspan="3" style="height: 7px; text-align: left" valign="top">
                                    <asp:DropDownList ID="DropDownList2" runat="server" Width="94px">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr style="font-size: 12pt">
                                <td class="pageTD" align="center" valign="middle" style="height: 22px; width: 10%;
                                    text-align: center;">
                                    資料時間範圍 Start</td>
                                <td style="text-align: left; width: 341px; height: 22px;" valign="top">
                                    <asp:TextBox ID="txtCalendar1" runat="server" Width="91px"></asp:TextBox><obout:Calendar
                                        ID="Calendar1" runat="server" ScriptPath="~/js/" TextBoxId="txtCalendar1" Columns="1"
                                        DatePickerMode="True" DatePickerImagePath="~/images/calendar.gif" StyleFolder="~/css/"
                                        DateFormat="yyyy/MM/dd" FullDayNames="璆,銝,鈭,銝,?鈭,摮" ShortDayNames="璆,銝,鈭,銝,?鈭,摮">
                                    </obout:Calendar>
                                </td>
                                <td class="pageTD" style="width: 10%; height: 22px; text-align: center;">
                                    資料時間範圍 End</td>
                                <td colspan="1" align="left" valign="top" style="text-align: left; height: 22px;
                                    width: 327px;">
                                    <asp:TextBox ID="txtCalendar2" runat="server" Width="91px"></asp:TextBox><obout:Calendar
                                        ID="Calendar2" runat="server" Columns="1" DateFormat="yyyy/MM/dd" DatePickerImagePath="~/images/calendar.gif"
                                        DatePickerMode="True" FullDayNames="璆,銝,鈭,銝,?鈭,摮" ScriptPath="~/js/" ShortDayNames="璆,銝,鈭,銝,?鈭,摮"
                                        StyleFolder="~/css/" TextBoxId="txtCalendar2">
                                    </obout:Calendar>
                                </td>
                            </tr>
                            <tr style="font-size: 12pt">
                                <td align="center" class="pageTD" style="width: 10%; height: 22px; text-align: center"
                                    valign="middle">
                                    T字型</td>
                                <td style="width: 341px; height: 22px; text-align: left" valign="top">
                                    <asp:CheckBox ID="CheckBox1" runat="server" /></td>
                                <td class="pageTD" style="width: 10%; height: 22px; text-align: center">
                                    還原權值&nbsp;</td>
                                <td align="left" colspan="1" style="width: 327px; height: 22px; text-align: left"
                                    valign="top">
                                    &nbsp;<asp:CheckBox ID="CheckBox2" runat="server" /></td>
                            </tr>
                            <tr style="font-size: 12pt">
                                <td align="center" class="pageTD" style="width: 10%; height: 22px; text-align: center"
                                    valign="middle">
                                    上傳資料</td>
                                <td style="width: 341px; height: 22px; text-align: left" valign="top">
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="檔案上傳" /></td>
                                <td class="pageTD" style="width: 10%; height: 22px; text-align: center">
                                    當時指數</td>
                                <td align="left" colspan="1" style="width: 327px; height: 22px; text-align: left"
                                    valign="top">
                                    &nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="89px"></asp:TextBox>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="https://www.yuanta.com.tw/eYuanta/Securities/Node/Index?MainId=00430&C1=2018040303170547&ID=2018040303170547&Level=1"
                                        Target="_blank">大盤K線</asp:HyperLink>&nbsp;
                                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="https://www.wantgoo.com/stock/futures/optionstoday"
                                        Target="_blank">最大未平倉</asp:HyperLink></td>
                            </tr>
                            <tr style="font-size: 12pt">
                                <td align="center" class="pageTD" style="width: 10%; height: 18px; text-align: center"
                                    valign="middle">
                                    &nbsp;未平倉量/成交量</td>
                                <td style="width: 341px; height: 18px; text-align: left" valign="top">
                                    &nbsp;<asp:RadioButtonList ID="RadioButtonList1" runat="server">
                                        <asp:ListItem Selected="True">未平倉量</asp:ListItem>
                                        <asp:ListItem>成交量</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td class="pageTD" style="width: 10%; height: 18px; text-align: center">
                                    上周結算價/波動率/到期天數</td>
                                <td align="left" colspan="1" style="width: 327px; height: 18px; text-align: left"
                                    valign="top">
                                    &nbsp;<asp:TextBox ID="TextBox2" runat="server" Width="89px">0</asp:TextBox>&nbsp;
                                    /<asp:TextBox ID="TextBox3" runat="server" Width="31px">0.16</asp:TextBox>/<asp:TextBox
                                        ID="TextBox4" runat="server" Width="19px">5</asp:TextBox>
                                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="https://www.taifex.com.tw/cht/5/optIndxFSP"
                                        Target="_blank">上周結算價</asp:HyperLink><br />
                                    下限: &nbsp;
                                    <asp:Label ID="Label30" runat="server" Text="Label" Width="68px"></asp:Label>
                                    ==&gt; &nbsp;
                                    <asp:Label ID="Label32" runat="server" Text="Label" Width="68px"></asp:Label><br />
                                    中心點 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; ==&gt; &nbsp;
                                    <asp:Label ID="Label2" runat="server" Text="Label" Width="68px"></asp:Label><br />
                                    上限: &nbsp;
                                    <asp:Label ID="Label31" runat="server" Text="Label" Width="68px"></asp:Label>
                                    ==&gt; &nbsp;
                                    <asp:Label ID="Label33" runat="server" Text="Label" Width="68px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="pageTD" colspan="8" style="height: 35px; text-align: left;">
                                    <table style="width: 236px; height: 7px">
                                        <tr>
                                            <td align='left' valign='top' style="width: 14px; height: 17px;">
                                                <asp:Button ID="ButtonQuery" runat="server" Style="font-size: 12px; font-family: Arial;
                                                    width: 100px;" Text="Query" OnClick="ButtonQuery_Click" />
                                            </td>
                                            <td align='left' valign='top' style="width: 25px; height: 17px;">
                                                <asp:Button ID="Button1" runat="server" Text="ExportToExcel" OnClick="Button1_Click" /></td>
                                                <td align='left' valign='top' style="width: 25px; height: 17px;">
                                                <asp:Button ID="Button4" runat="server" Text="大道至簡56789" OnClick="Button4_Click"  /></td>
                                        </tr>
                                    </table>RawData最大時間:
                                    <asp:Label ID="Label3" runat="server" Text="Label" Width="80px"></asp:Label>,結算資料最大時間:
                                    <asp:Label ID="Label1" runat="server" Text="Label" Width="80px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="8" style="height: 271px">
                                    <fieldset>
                                        <legend align="center" style="color: blue; text-align: center"><strong><span style="font-family: Century Gothic">
                                            查詢結果</span></strong>:</legend>
                                        <table hight="100%" width="100%">
                                            <tr>
                                                <td align='center' valign='middle'>
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        <ContentTemplate>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <asp:GridView ID="GridView1" runat="server" Font-Names="Century Gothic" Font-Size="13pt"
                                                        Width="1000px" CellPadding="3" BackColor="White"
                                                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnRowDataBound="GridView1_RowDataBound"
                                                        EmptyDataText="No Record!!!">
                                                        <RowStyle ForeColor="Black" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="RN"></asp:TemplateField>
                                                           
                                                        </Columns>
                                                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle BackColor="#DEDFDE" Font-Bold="True" ForeColor="Black" />
                                                    </asp:GridView>
                                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                        ForeColor="#333333" GridLines="None" OnRowDataBound="GridView2_RowDataBound">
                                                        <RowStyle BackColor="#EFF3FB" />
                                                        <Columns>
                                                            <asp:BoundField HeaderText="SN" />
                                                            <asp:BoundField DataField="date1" HeaderText="date1" />
                                                            <asp:BoundField DataField="stock_id" HeaderText="stock_id" />
                                                            <asp:BoundField DataField="stock_name" HeaderText="stock_name" />
                                                            <asp:BoundField DataField="volume1" HeaderText="volume1" />
                                                            <asp:BoundField DataField="percent1" HeaderText="percent1" />
                                                            <asp:BoundField DataField="KPI" HeaderText="KPI" />
                                                            <asp:BoundField DataField="hot_price" HeaderText="hot_price" />
                                                            <asp:BoundField DataField="price1" HeaderText="price1" />
                                                             <asp:BoundField DataField="turtle" HeaderText="turtle" />
                                                        </Columns>
                                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#2461BF" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                    </asp:GridView>
                                                    <br />
                                                    <asp:GridView ID="GridView3" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                        <EditRowStyle BackColor="#999999" />
                                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                    </asp:GridView>
                                                    <br />
                                                    <br />
                                                    <asp:Label runat="server" ID="lblAIExpand" Style="display: none"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                    <span style="font-size: 9pt"></span>
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

    <script language='javascript' type="text/javascript"> 
function showHideAnswer(obj,imgObj) 
{ 
if(document.getElementById(obj).style.display=='block'){ 
document.getElementById(imgObj).src = "images/open13.gif"; 
document.getElementById(obj).style.display='none'; 
}else{ 
document.getElementById(imgObj).src = "images/close13.gif"; 
document.getElementById(obj).style.display='block'; 
} 
} 

    </script>

 <%--   </DIV>--%>




</asp:Content>
