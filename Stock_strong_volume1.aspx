<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Stock_strong_volume1.aspx.cs"
    Inherits="Stock_strong_volume1" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>stock_jump</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table hight="100%" width="100%">
                <tr>
                    <td align='center' valign='middle'>
                        
                            <legend id="legend3" runat="server" align="center" style="font-weight: bold; font-size: 12px;
                                font-family: Arial; color: black; text-align: center;"><span style="font-size: 14pt;
                                    color: Gray; text-align: center">今日我最夯&lt;==Strong_UP==&gt;</span></legend>
                            <br />
                            <asp:GridView ID="GridView1" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan"
                                BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" AutoGenerateColumns="False"
                                AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound"
                                PageSize="50">
                                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <RowStyle BackColor="#FFFFF4" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField HeaderText="SN" />
                                    <asp:BoundField HeaderText="日期" DataField="date1" />
                                    <asp:BoundField HeaderText="股票名稱" DataField="stock_name" />
                                    <asp:TemplateField HeaderText="股票代號">
                                        <ItemTemplate>
                                            <footerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                                            <selecteditemstyle backcolor="#C5BBAF" font-bold="True" forecolor="#333333" />
                                            <itemtemplate>
                                  
                                        <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#"http://vsoscar007.ddns.net:8080/Stock_new/stock_pic.aspx?stock=" + DataBinder.Eval(Container.DataItem, "stock_id") %> '
                                            Text='<%# Bind("stock_id") %>' runat="server" Target="_blank"></asp:HyperLink>
                                    </itemtemplate>
                                            <headerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="成交價" DataField="price" />
                                    <asp:BoundField HeaderText="漲跌幅" DataField="K_percentage" />
                                    <asp:BoundField HeaderText="交易量" DataField="volume" />
                                    <asp:BoundField HeaderText="昨收" DataField="yesturday_price" />
                                    <asp:BoundField HeaderText="漲停價" DataField="top_price" />
                                    <asp:BoundField HeaderText="KPI" DataField="KPI" />
                                  <asp:BoundField HeaderText="turtle" DataField="turtle" />
                                    <asp:TemplateField HeaderText="卷資比">
                                        <ItemTemplate>
                                            <footerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                                            <selecteditemstyle backcolor="#C5BBAF" font-bold="True" forecolor="#333333" />
                                            <itemtemplate>
                                  
                                        <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#"http://stock.wearn.com/acredit.asp?mode=search&kind=" + DataBinder.Eval(Container.DataItem, "stock_id") %> '
                                            Text='卷資比' runat="server" Target="_blank"></asp:HyperLink>
                                    </itemtemplate>
                                            <headerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="主力進出">
                                        <ItemTemplate>
                                            <footerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                                            <selecteditemstyle backcolor="#C5BBAF" font-bold="True" forecolor="#333333" />
                                            <itemtemplate>
                                  
                                        <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#"http://jsjustweb.jihsun.com.tw/z/zc/zco/zco_" + DataBinder.Eval(Container.DataItem, "stock_id")+"_5.djhtm" %> '
                                            Text='主力進出' runat="server" Target="_blank"></asp:HyperLink>
                                    </itemtemplate>
                                            <headerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="損益表">
                                        <ItemTemplate>
                                            <footerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                                            <selecteditemstyle backcolor="#C5BBAF" font-bold="True" forecolor="#333333" />
                                            <itemtemplate>
                                  
                                        <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#"http://www.cmoney.tw/finance/f00041.aspx?s=" + DataBinder.Eval(Container.DataItem, "stock_id")+"" %> '
                                            Text='損益表' runat="server" Target="_blank"></asp:HyperLink>
                                    </itemtemplate>
                                            <headerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="預估EPS">
                                        <ItemTemplate>
                                            <footerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                                            <selecteditemstyle backcolor="#C5BBAF" font-bold="True" forecolor="#333333" />
                                            <itemtemplate>
                                  
                                        <asp:HyperLink ID="HyperLink2" NavigateUrl='<%#"http://stock.nlog.cc/e/" + DataBinder.Eval(Container.DataItem, "stock_id") %> '
                                            Text='預估EPS' runat="server" Target="_blank"></asp:HyperLink>
                                    </itemtemplate>
                                            <headerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            &nbsp; 
                            <br />
                            動能鉅量股<br />
                            <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#DEDFDE"
        BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"  AutoGenerateColumns="False" OnRowDataBound="GridView2_RowDataBound">
        <RowStyle BackColor="#F7F7DE" />
        <FooterStyle BackColor="#CCCC99" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
         <Columns>
                                    <asp:BoundField HeaderText="SN" />
                                    <asp:BoundField HeaderText="日期" DataField="date1" />
                                    <asp:BoundField HeaderText="股票名稱" DataField="stock_name" />
                                    <asp:TemplateField HeaderText="股票代號">
                                        <ItemTemplate>
                                            <footerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                                            <selecteditemstyle backcolor="#C5BBAF" font-bold="True" forecolor="#333333" />
                                            <itemtemplate>
                                  
                                        <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#"http://vsoscar007.ddns.net:8080/Stock_new/stock_pic.aspx?stock=" + DataBinder.Eval(Container.DataItem, "stock_id") %> '
                                            Text='<%# Bind("stock_id") %>' runat="server" Target="_blank"></asp:HyperLink>
                                    </itemtemplate>
                                            <headerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="成交價" DataField="price1" />
                                     <asp:BoundField DataField="Current_price" HeaderText="NOW PRICE" />
                                     <asp:BoundField DataField="diff" HeaderText="diff price" />
                                     
                                    <asp:BoundField HeaderText="diff_p" DataField="diff_p" />
                                    <asp:BoundField HeaderText="漲跌幅" DataField="K_percentage" />
                                    <asp:BoundField HeaderText="交易量" DataField="volume1" />
                                    <asp:BoundField DataField="Current_volume" HeaderText="NOW交易量" />
                                    <asp:BoundField HeaderText="漲停價" DataField="hot_price" />
                                    <asp:BoundField HeaderText="KPI" DataField="KPI" />
                                     <asp:BoundField HeaderText="turtle" DataField="turtle" />
                                <%--    
                                    <asp:TemplateField HeaderText="卷資比">
                                        <ItemTemplate>
                                            <footerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                                            <selecteditemstyle backcolor="#C5BBAF" font-bold="True" forecolor="#333333" />
                                            <itemtemplate>
                                  
                                        <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#"http://stock.wearn.com/acredit.asp?mode=search&kind=" + DataBinder.Eval(Container.DataItem, "stock_id") %> '
                                            Text='卷資比' runat="server" Target="_blank"></asp:HyperLink>
                                    </itemtemplate>
                                            <headerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="主力進出">
                                        <ItemTemplate>
                                            <footerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                                            <selecteditemstyle backcolor="#C5BBAF" font-bold="True" forecolor="#333333" />
                                            <itemtemplate>
                                  
                                        <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#"http://jsjustweb.jihsun.com.tw/z/zc/zco/zco_" + DataBinder.Eval(Container.DataItem, "stock_id")+"_5.djhtm" %> '
                                            Text='主力進出' runat="server" Target="_blank"></asp:HyperLink>
                                    </itemtemplate>
                                            <headerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   <%-- <asp:TemplateField HeaderText="港商麥格里">
                                        <ItemTemplate>
                                            <footerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                                            <selecteditemstyle backcolor="#C5BBAF" font-bold="True" forecolor="#333333" />
                                            <itemtemplate>
                                  
                                        <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#"http://sod.fbs.com.tw/z/zc/zco/zco0/zco0_" + DataBinder.Eval(Container.DataItem, "stock_id")+"_1360.djhtm" %> '
                                            Text='港商麥格里' runat="server" Target="_blank"></asp:HyperLink>
                                    </itemtemplate>
                                            <headerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                     <asp:TemplateField HeaderText="預估EPS">
                                        <ItemTemplate>
                                            <footerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                                            <selecteditemstyle backcolor="#C5BBAF" font-bold="True" forecolor="#333333" />
                                            <itemtemplate>
                                  
                                        <asp:HyperLink ID="HyperLink2" NavigateUrl='<%#"http://stock.nlog.cc/e/" + DataBinder.Eval(Container.DataItem, "stock_id") %> '
                                            Text='預估EPS' runat="server" Target="_blank"></asp:HyperLink>
                                    </itemtemplate>
                                            <headerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
    </asp:GridView>
                        
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
