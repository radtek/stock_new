<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="stock_list.aspx.cs" Inherits="stock_list"
    Title="Stock_list" %>

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
                                                <span id="Span1" style="font-size: 16pt; font-family: Century Gothic"><strong>查詢Stock紀錄</strong></span></td>
                                            <td align="right" style="font-size: 12px; color: navy; height: 30px;">
                                                <span style="color: #ff0000"></span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr style="font-size: 12pt">
                                <td class="pageTD" align="center" style="height: 7px; width: 10%;">
                                    股票代號</td>
                                <td style="height: 7px; text-align: left;" valign="top" colspan="3">
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
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
                                <td class="pageTD" align="center" style="height: 5px; width: 10%;">
                                    成交價小於</td>
                                <td style="height: 5px; text-align: left;" valign="top" colspan="3">
                                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr style="font-size: 12pt">
                                <td class="pageTD" align="center" style="height: 5px; width: 10%;">
                                    成交價大於</td>
                                <td style="height: 5px; text-align: left;" valign="top" colspan="3">
                                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr style="font-size: 12pt">
                                <td class="pageTD" align="center" style="height: 5px; width: 10%;">
                                    交易量大於</td>
                                <td style="height: 5px; text-align: left;" valign="top" colspan="3">
                                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                    <span style="font-size: 9pt">EXPAND</span><asp:DropDownList ID="DropDownList1" runat="server">
                                        <asp:ListItem>N</asp:ListItem>
                                        <asp:ListItem>Y</asp:ListItem>
                                    </asp:DropDownList>&nbsp; 連續3天強勢<asp:CheckBox ID="CheckBox1" runat="server" />
                                    時光回朔14天<asp:CheckBox ID="CheckBox2" runat="server" /></td>
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
                                                    </asp:UpdatePanel>
                                                    <asp:GridView ID="GridView1" runat="server" Font-Names="Century Gothic" Font-Size="13pt"
                                                        Width="1000px" AutoGenerateColumns="False" CellPadding="3" BackColor="White"
                                                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnRowDataBound="GridView1_RowDataBound"
                                                        EmptyDataText="No Record!!!">
                                                        <RowStyle ForeColor="Black" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="RN"></asp:TemplateField>
                                                            <asp:TemplateField HeaderText="">
                                                                <ItemTemplate>
                                                                    <asp:Image ID="btnShowDetail" runat="server" ImageUrl="~/images/close13.gif" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="stock_id">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblstock_id" runat="server" ForeColor="#000000" Text='<%# Bind("stock_id") %>'></asp:Label></br>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblstock_id" runat="server" ForeColor="#000000" Text='<%# Bind("stock_id") %>'></asp:Label></br>
                                                                    <%--  SN :</br>
                                            <asp:Label ID="lblSN" runat="server" ForeColor="Red" Text='<%# Bind("sn") %>'></asp:Label></br>--%>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="count1">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblcount1" runat="server" ForeColor="#000000" Text='<%# Bind("count1") %>'></asp:Label></br>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="lblcount1" runat="server" ForeColor="#000000" Width="250px" Text='<%# Bind("count1") %>'></asp:TextBox></br>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Stock_id">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#"http://vsoscar.ddns.net:8080/Stock_new/stock_pic.aspx?stock=" + DataBinder.Eval(Container.DataItem, "stock_id") %> '
                                                                        Text='<%# Bind("stock_id") %>' Target='_blank' ForeColor="DeepPink" runat="server"></asp:HyperLink>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="lblStock_id" runat="server" ForeColor="#000000" Width="250px" Text='<%# Bind("Stock_id") %>'></asp:TextBox></br>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="stock_name">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblstock_name" runat="server" ForeColor="#000000" Text='<%# Bind("stock_name") %>'></asp:Label></br>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="lblstock_name" runat="server" ForeColor="#000000" Width="250px"
                                                                        Text='<%# Bind("stock_name") %>'></asp:TextBox></br>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="avg_vol">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblprice" runat="server" ForeColor="#000000" Text='<%# Bind("avg_volume","{0:N0}") %>'></asp:Label></br>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="lblprice" runat="server" ForeColor="#000000" Width="250px" Text='<%# Bind("avg_volume") %>'></asp:TextBox></br>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Cur_vol">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCurrent_volume" runat="server" ForeColor="#000000" Text='<%# Bind("Current_volume","{0:N0}") %>'></asp:Label></br>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="lblCurrent_volume" runat="server" ForeColor="#000000" Width="250px" Text='<%# Bind("Current_volume") %>'></asp:TextBox></br>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                       
                                                            <asp:TemplateField HeaderText="AHP">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblavg_volume" runat="server" ForeColor="#000000" Text='<%# Bind("avg_hot_price") %>'></asp:Label></br>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="lblavg_volume" runat="server" ForeColor="#000000" Width="250px"
                                                                        Text='<%# Bind("avg_hot_price") %>'></asp:TextBox></br>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="AP">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblavg_hot_price" runat="server" ForeColor="#000000" Text='<%# Bind("price") %>'></asp:Label></br>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="lblavg_hot_price" runat="server" ForeColor="#000000" Width="250px"
                                                                        Text='<%# Bind("price") %>'></asp:TextBox></br>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="AT">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblavg_turtle" runat="server" ForeColor="#000000" Text='<%# Bind("avg_turtle") %>'></asp:Label></br>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="lblavg_turtle" runat="server" ForeColor="#000000" Width="250px"
                                                                        Text='<%# Bind("price") %>'></asp:TextBox></br>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="NP">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblNow_price" runat="server" ForeColor="#000000" Text='<%# Bind("Current_price") %>'></asp:Label></br>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="lblNow_price" runat="server" ForeColor="#000000" Width="250px" Text='<%# Bind("Current_price") %>'></asp:TextBox></br>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="diff_PCT">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbldiff_p" runat="server" ForeColor="#000000" Text='<%# Bind("diff_p") %>'></asp:Label></br>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="lbldiff_p" runat="server" ForeColor="#000000" Width="250px" Text='<%# Bind("diff_p") %>'></asp:TextBox></br>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                   
                                                            <asp:TemplateField HeaderText="卷資比">
                                                                <ItemTemplate>
                                                                    <footerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                                                                    <selecteditemstyle backcolor="#C5BBAF" font-bold="True" forecolor="#333333" />
                                                                    <itemtemplate>
                                  
                                        <asp:HyperLink ID="HyperLink2" NavigateUrl='<%#"http://stock.wearn.com/acredit.asp?mode=search&kind=" + DataBinder.Eval(Container.DataItem, "stock_id") %> '
                                            Text='卷資比' runat="server" Target="_blank"></asp:HyperLink>
                                    </itemtemplate>
                                                                    <headerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="主力">
                                                                <ItemTemplate>
                                                                    <footerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                                                                    <selecteditemstyle backcolor="#C5BBAF" font-bold="True" forecolor="#333333" />
                                                                    <itemtemplate>
                                  
                                        <asp:HyperLink ID="HyperLink3" NavigateUrl='<%#"http://jsjustweb.jihsun.com.tw/z/zc/zco/zco_" + DataBinder.Eval(Container.DataItem, "stock_id")+"_5.djhtm" %> '
                                            Text='主力進出' runat="server" Target="_blank"></asp:HyperLink>
                                    </itemtemplate>
                                                                    <headerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="港商">
                                                                <ItemTemplate>
                                                                    <footerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                                                                    <selecteditemstyle backcolor="#C5BBAF" font-bold="True" forecolor="#333333" />
                                                                    <itemtemplate>
                                  
                                        <asp:HyperLink ID="HyperLink4" NavigateUrl='<%#"http://sod.fbs.com.tw/z/zc/zco/zco0/zco0_" + DataBinder.Eval(Container.DataItem, "stock_id")+"_1360.djhtm" %> '
                                            Text='港商麥格里' runat="server" Target="_blank"></asp:HyperLink>
                                    </itemtemplate>
                                                                    <headerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
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

    </DIV>
</asp:Content>
