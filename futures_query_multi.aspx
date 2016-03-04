<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="futures_query_multi.aspx.cs" Inherits="futures_query_multi" %>

<%@ Register TagPrefix="obout" Namespace="OboutInc.Calendar2" Assembly="obout_Calendar2_Net" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1">
<link href="app_themes/layout/layout.css" rel="stylesheet" type="text/css" />
            <table id="Table3"   align="center"  border="0" cellpadding="0" cellspacing="0" width="98%">
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
                                                <span id="Span1" style="font-size: 16pt; font-family: Century Gothic"><strong>查詢期貨紀錄(Multi)</strong></span></td>
                                            <td align="right" style="font-size: 12px; color: navy; height: 30px;">
                                                <span style="color: #ff0000"></span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
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
                                    Order TPO</td>
                                <td style="width: 341px; height: 22px; text-align: left" valign="top">
                                    <asp:CheckBox ID="CheckBox1" runat="server" /></td>
                                <td class="pageTD" style="width: 10%; height: 22px; text-align: center">
                                    &nbsp;</td>
                                <td align="left" colspan="1" style="width: 327px; height: 22px; text-align: left"
                                    valign="top">
                                    &nbsp;</td>
                            </tr>
                            <tr style="font-size: 12pt">
                                <td align="center" class="pageTD" style="width: 10%; height: 22px; text-align: center"
                                    valign="middle">
                                    RF Value</td>
                                <td style="width: 341px; height: 22px; text-align: left" valign="top">
                                    <asp:Label ID="Label1" runat="server" Text="Label" Width="110px"></asp:Label></td>
                                <td class="pageTD" style="width: 10%; height: 22px; text-align: center">
                                    上下限&nbsp;</td>
                                <td align="left" colspan="1" style="width: 327px; height: 22px; text-align: left"
                                    valign="top">
                                    <asp:Label ID="Label3" runat="server" Text="Label" Width="102px"></asp:Label></td>
                            </tr>
                            <tr style="font-size: 12pt">
                                <td align="center" class="pageTD" style="width: 10%; height: 22px; text-align: center"
                                    valign="middle">
                                    OP</td>
                                <td style="width: 341px; height: 22px; text-align: left" valign="top">
                                    <asp:Label ID="Label2" runat="server" Text="Label" Width="110px"></asp:Label><br />
                                    <asp:Label ID="Label5" runat="server" Text="Label" Width="294px"></asp:Label><br />
                                    ie:+++-;++-+,+-++,+-++,+--+,-+++,-+-+,--+-,----</td>
                                <td class="pageTD" style="width: 10%; height: 22px; text-align: center">
                                    OP7</td>
                                <td align="left" colspan="1" style="width: 327px; height: 22px; text-align: left"
                                    valign="top">
                                    <asp:Label ID="Label4" runat="server" Text="Label" Width="294px"></asp:Label></td>
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
                                        </tr>
                                    </table>
                                </td>
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
                                                    </asp:UpdatePanel>&nbsp; &nbsp;&nbsp;&nbsp;
                                                    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE"
                                                        BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" EmptyDataText="No Data!!!"  OnRowDataBound="GridView1_RowDataBound" 
>
                                                        <RowStyle BackColor="#F7F7DE" />
                                                        <FooterStyle BackColor="#CCCC99" />
                                                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                        <Columns>
                                                            <asp:BoundField HeaderText="RN" />
                                                        </Columns>
                                                    </asp:GridView>
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




</asp:Content>