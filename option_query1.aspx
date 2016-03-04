<%@ Page Language="C#" AutoEventWireup="true" CodeFile="option_query1.aspx.cs" Inherits="option_query1" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>一天一口救台指</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table hight="100%" width="100%">
                                            <tr>
                                                <td align='center' valign='middle'>
                                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                    </asp:ScriptManager>
                                                    
                                                  <legend id="legend3" runat="server" align="center" style="font-weight: bold; font-size: 12px;
                                font-family: Arial; color: black; text-align: center;"><span style="font-size: 14pt;
                                    color: Gray; text-align: center">今日我最夯&lt;==選擇OIV==&gt;</span></legend>

                                                    
                                                    
                                                  
                                                    <table>
                                                    <tr valign="top">
                                                     <td>
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
                                                     <td>
                                                     <asp:GridView ID="GridView3" runat="server" CellPadding="4" ForeColor="Black" GridLines="Vertical" EmptyDataText="No Data!!!"  OnRowDataBound="GridView3_RowDataBound" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" >
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
                                                    
                                                    <tr valign="top">
                                                     <td>
                                                     <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" EmptyDataText="No Data!!!"  OnRowDataBound="GridView2_RowDataBound" 
>
                                                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                        <Columns>
                                                            <asp:BoundField HeaderText="RN" />
                                                        </Columns>
                                                    </asp:GridView>
                                                     </td>
                                                     <td>
                                                     <asp:GridView ID="GridView4" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" EmptyDataText="No Data!!!"  OnRowDataBound="GridView4_RowDataBound" 
>
                                                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                                        <AlternatingRowStyle BackColor="White" />
                                                        <Columns>
                                                            <asp:BoundField HeaderText="RN" />
                                                        </Columns>
                                                    </asp:GridView>
                                                     </td>
                                                    </tr>
                                                    
                                                    </table>
                                                    
                                                    
                                                </td>
                                            </tr>
                                        </table>
    </div>
    </form>
</body>
</html>
