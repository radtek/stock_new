<%@ Page Language="C#" AutoEventWireup="true" CodeFile="modify_get_html_data.aspx.cs"
    Inherits="epaper_modify_get_html_data" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="obout" Namespace="OboutInc.Calendar2" Assembly="obout_Calendar2_Net" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Modify_Get_Html_data</title>
    <meta http-equiv="Content-Type" content="text/html; charset=big5" />
    <meta http-equiv="Page-Enter" content="blendTrans(duration=0.5)" />
    <meta http-equiv="Page-Exit" content="blendTrans(duration=0.5)" />

    <script language="Javascript">

function example_ajax_request() {
  $('#example-placeholder').html('<p><img src="../images/ajax-loader.gif" width="200" height="19" /></p>');
  $('#example-placeholder').load("<p>this is a sample</p>");
}


    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <fieldset>
                <legend align="center" style="color: blue; text-align: center"><strong><span style="font-size: 16pt;
                    font-family: Century Gothic">Modify Target Stock Alarm Mail :</span></strong></legend>
                <table hight="100%" width="100%">
                    <tr>
                        <td align='center' valign='middle' style="height: 396px">
                            <table style="width: 933px; height: 137px">
                                <tr>
                                    <td style="width: 110px; background-color: azure; text-align: left; border-right: black thin solid;
                                        border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid;">
                                        End Time&nbsp;</td>
                                    <td style="width: 110px; border-right: black thin solid; border-top: black thin solid;
                                        border-left: black thin solid; border-bottom: black thin solid; background-color: azure;
                                        text-align: left;">
                                        <asp:TextBox ID="txtCalendar1" runat="server" Width="91px"></asp:TextBox><obout:Calendar
                                            ID="Calendar1" runat="server" ScriptPath="~/js/" TextBoxId="txtCalendar1" Columns="1"
                                            DatePickerMode="True" DatePickerImagePath="~/images/calendar.gif" StyleFolder="~/css/"
                                            DateFormat="yyyy/MM/dd" FullDayNames="璆,銝,鈭,銝,?鈭,摮" ShortDayNames="璆,銝,鈭,銝,?鈭,摮">
                                        </obout:Calendar>
                                    </td>
                                    <td style="background-color: azure; text-align: left; border-right: black thin solid;
                                        border-top: black thin solid; border-left: black thin solid; width: 110px; border-bottom: black thin solid;">
                                        股票代號&nbsp;</td>
                                    <td style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid;
                                        width: 110px; border-bottom: black thin solid; background-color: azure; text-align: left">
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 110px; background-color: azure; text-align: left; border-right: black thin solid;
                                        border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid;">
                                        Flag</td>
                                    <td style="width: 110px; border-right: black thin solid; border-top: black thin solid;
                                        border-left: black thin solid; border-bottom: black thin solid; background-color: azure;
                                        text-align: left;">
                                        <asp:DropDownList ID="DropDownList1" runat="server">
                                            <asp:ListItem>Y</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td style="background-color: azure; text-align: left; border-right: black thin solid;
                                        border-top: black thin solid; border-left: black thin solid; width: 110px; border-bottom: black thin solid;">
                                        User_id</td>
                                    <td style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid;
                                        width: 110px; border-bottom: black thin solid; background-color: azure; text-align: left">
                                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 110px; background-color: azure; text-align: left; border-right: black thin solid;
                                        border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid;">
                                        Target Price</td>
                                    <td style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid;
                                        width: 110px; border-bottom: black thin solid; background-color: azure; text-align: left">
                                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                    </td>
                                    <td style="width: 110px; background-color: azure; text-align: left; border-right: black thin solid;
                                        border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid;">
                                        Interval Time(分鐘)</td>
                                    <td style="width: 110px; background-color: azure; text-align: left; border-right: black thin solid;
                                        border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid;">
                                        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="width: 110px; background-color: azure; text-align: left; border-right: black thin solid;
                                        border-top: black thin solid; border-left: black thin solid; border-bottom: black thin solid;">
                                        E-Mail</td>
                                    <td colspan="3" style="border-right: black thin solid; border-top: black thin solid;
                                        border-left: black thin solid; width: 110px; border-bottom: black thin solid;
                                        background-color: azure; text-align: left">
                                        <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine" Width="558px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="border-right: black thin solid; border-top: black thin solid; border-left: black thin solid;
                                        width: 110px; border-bottom: black thin solid; background-color: azure; text-align: left">
                                        &nbsp
                                    </td>
                                    <td colspan="3" style="border-right: black thin solid; border-top: black thin solid;
                                        border-left: black thin solid; width: 110px; border-bottom: black thin solid;
                                        background-color: azure; text-align: left">
                                        <table width="330px">
                                            <tr>
                                                <td style="width: 15px">
                                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add" /></td>
                                                <td style="width: 72px">
                                                    <asp:Button ID="Button2" runat="server" OnClientClick="example_ajax_request()" OnClick="Button2_Click"
                                                        Text="Query" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <asp:GridView ID="GridView1" runat="server" Font-Names="Arial" Font-Size="12px" Width="1000px"
                                AutoGenerateColumns="False" CellPadding="3" BackColor="White" BorderColor="#CCCCCC"
                                BorderStyle="None" BorderWidth="1px" OnRowDataBound="GridView1_RowDataBound"
                                EmptyDataText="No Record!!!" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating"
                                OnRowDeleting="GridView1_RowDeleting" OnRowCancelingEdit="GridView1_RowCancelingEdit">
                                <RowStyle ForeColor="#000066" />
                                <Columns>
                                    <asp:TemplateField HeaderText="RN"></asp:TemplateField>
                                    <asp:TemplateField HeaderText="SN">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblSN" runat="server" ForeColor="#0000FF" Text='<%# Bind("sn") %>'></asp:Label></br>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblSN" runat="server" ForeColor="#0000FF" Text='<%# Bind("sn") %>'></asp:Label></br>
                                            <%--  SN :</br>
                                            <asp:Label ID="lblSN" runat="server" ForeColor="Red" Text='<%# Bind("sn") %>'></asp:Label></br>--%>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="date1">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <asp:Label ID="lbldate1" runat="server" ForeColor="#0000FF" Text='<%# Bind("date1") %>'></asp:Label></br>
                                            Stock_id:</br>
                                            <asp:Label ID="lblstock_id" runat="server" ForeColor="#0000FF" Text='<%# Bind("stock_id") %>'></asp:Label></br>
                                            Stock_Price:</br>
                                            <asp:Label ID="lblstock_price" runat="server" ForeColor="#0000FF" Text='<%# Bind("stock_price") %>'></asp:Label></br>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="lbldate1" runat="server" ForeColor="#0000FF" Width="250px" Text='<%# Bind("date1") %>'></asp:TextBox></br>
                                            Stock_id:</br>
                                            <asp:TextBox ID="lblstock_id" runat="server" ForeColor="#0000FF" Text='<%# Bind("stock_id") %>'></asp:TextBox></br>
                                            Stock_price</br>
                                            <asp:TextBox ID="lblstock_price" runat="server" ForeColor="#0000FF" Width="250px"
                                                Text='<%# Bind("stock_price") %>'></asp:TextBox></br>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Flag">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblflag" runat="server" ForeColor="#0000FF" Text='<%# Bind("flag") %>'></asp:Label></br>
                                            Interval_time:</br>
                                            <asp:Label ID="lblinterval_time" runat="server" ForeColor="#0000FF" Text='<%# Bind("interval_time") %>'></asp:Label></br>
                                            User_id:</br>
                                            <asp:Label ID="lbluser_id" runat="server" ForeColor="#0000FF" Text='<%# Bind("user_id") %>'></asp:Label></br>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                           
                                            Flag:</br>
                                            <asp:TextBox ID="lblflag" runat="server" ForeColor="#0000FF" Width="250px" Text='<%# Bind("flag") %>'>
                                            </asp:TextBox>
                                            </br> Interval_time:</br>
                                            <asp:TextBox ID="lblinterval_time" runat="server" ForeColor="#0000FF" Width="250px"
                                                Text='<%# Bind("interval_time") %>'>
                                            </asp:TextBox>
                                            </br> User_id:</br>
                                            <asp:TextBox ID="lbluser_id" runat="server" ForeColor="#0000FF" Width="250px" Text='<%# Bind("user_id") %>'>
                                            </asp:TextBox></br>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mail TO">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblemail" runat="server" ForeColor="#0000FF" Text='<%# Bind("email") %>'></asp:Label></br>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="lblemail" runat="server" ForeColor="#0000FF" Width="250px" Text='<%# Bind("email") %>'></asp:TextBox></br>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ImageUrl="../images/bdelete.gif" ID="btnDel" runat="server" CommandName="Delete"
                                                ToolTip="刪除" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ShowEditButton="True" ButtonType="Button" />
                                </Columns>
                                <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#DEDFDE" Font-Bold="True" ForeColor="Black" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </form>
</body>
</html>
