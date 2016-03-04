<%@ Page Language="C#" enableEventValidation="false" viewStateEncryptionMode ="Never"   MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="virtual_asset.aspx.cs" Inherits="virtual_asset" Title="Virtual_Asset" %>
<%@ Register TagPrefix="obout" Namespace="OboutInc.Calendar2" Assembly="obout_Calendar2_Net" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
<head id="head1" >
    <title>Virtual_Asset</title>
</head>

    <form id="form1" >
  <link href="app_themes/layout/layout.css" rel="stylesheet" type="text/css" />
        <div style="display: inline; z-index: 105; left: 10px; width: 90%; color: black;
            top: 0px; height: 16px; background-color: white">
           <br/> 
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
                                                <span id="Span1" style="font-size: 16pt; font-family: Century Gothic"><strong>查詢Virtual
                                                    Asset紀錄</strong></span></td>
                                            <td align="right" style="font-size: 12px; color: navy; height: 30px;">
                                                <span style="color: #ff0000"></span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr style="font-size: 12pt">
                                <td class="pageTD" align="center" style="height: 7px; width: 10%;">
                                    資產</td>
                                <td style="height: 7px; text-align: left;" valign="top" colspan="3">
                                    <table style="width: 500px">
                                        <tr>
                                            <td style="border-right: lightgrey thin solid; border-top: lightgrey thin solid; border-left: lightgrey thin solid; width: 37px; border-bottom: lightgrey thin solid; background-color: #cccccc">
                                                Left_Asset</td>
                                            <td style="width: 37px; border-right: lightgrey thin solid; border-top: lightgrey thin solid; border-left: lightgrey thin solid; border-bottom: lightgrey thin solid; background-color: #cccccc;">
                                                Now_total_price</td>
                                            <td style="width: 37px; border-right: lightgrey thin solid; border-top: lightgrey thin solid; border-left: lightgrey thin solid; border-bottom: lightgrey thin solid; background-color: #cccccc; text-align: center;">
                                                Buy_total_price</td>
                                            <td style="width: 37px; border-right: lightgrey thin solid; border-top: lightgrey thin solid; border-left: lightgrey thin solid; border-bottom: lightgrey thin solid; background-color: #cccccc;">
                                                Now_Benefit</td>
                                            <td style="width: 37px; border-right: lightgrey thin solid; border-top: lightgrey thin solid; border-left: lightgrey thin solid; border-bottom: lightgrey thin solid; background-color: #cccccc;">
                                                Benefit_Rate</td>
                                        </tr>
                                        <tr>
                                            <td style="background-color: #ffffe7" >
                                    <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333"
                                        GridLines="None" AutoGenerateColumns="False">
                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <RowStyle BackColor="#EFF3FB" />
                                        <EditRowStyle BackColor="#2461BF" />
                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="User_Id" HeaderText="User_Id"  />
                                            <asp:BoundField DataField="Left_Asset" HeaderText="Left_Asset" DataFormatString="{0:N0}" />
                                        </Columns>
                                    </asp:GridView>
                                            </td>
                                            <td style="background-color: #ffffe7" >
                                                <asp:Label ID="Label2" runat="server" Text="Label" Width="104px"></asp:Label></td>
                                            <td style="background-color: #ffffe7" >
                                                <asp:Label ID="Label3" runat="server" Text="Label" Width="104px"></asp:Label></td>
                                            <td style="background-color: #ffffe7" >
                                                <asp:Label ID="Label4" runat="server" Text="Label" Width="104px"></asp:Label></td>
                                            <td style="background-color: #ffffe7" >
                                                <asp:Label ID="Label5" runat="server" Text="Label" Width="104px"></asp:Label></td>
                                        </tr>
                                    </table>
                                    &nbsp;
                                 
                                  
                             </td>
                           
                            </tr>
                            <tr style="font-size: 12pt">
                                <td class="pageTD" align="center" style="height: 5px; width: 10%;">
                                    下單股票(代號)</td>
                                <td style="height: 5px; text-align: left;" valign="top" colspan="3">
                                    <asp:TextBox ID="TextBox_buy_stock_id" runat="server" Width="86px"></asp:TextBox>
                                                <asp:Button ID="ButtonQuery" runat="server" Style="font-size: 12px; font-family: Arial;" Text="Query"  OnClick="ButtonQuery_Click" Width="63px" /></td>
                            </tr>
                            <tr style="font-size: 12pt">
                                <td class="pageTD" align="center" style="height: 5px; width: 10%;">
                                    股名/參考價格</td>
                                <td style="height: 5px; text-align: left;" valign="top" colspan="3">
                                    <asp:Label ID="Label_stock_name" runat="server" Text="Label" Width="91px" Visible="False"></asp:Label>
                                    &nbsp;
                                    /&nbsp;&nbsp;
                                    <asp:Label ID="Label_stock_price" runat="server" Text="Label" Width="88px" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr style="font-size: 12pt">
                                <td class="pageTD" align="center" style="height: 5px; width: 10%;">
                                    下單張數</td>
                                <td style="height: 5px; text-align: left;" valign="top" colspan="3">
                                    <asp:TextBox ID="TextBox_stock_num" runat="server" Width="84px"></asp:TextBox></td>
                            </tr>
                           
                            <tr>
                                <td class="pageTD" colspan="8" style="height: 35px; text-align: left;">
                                    <table style="width: 236px; height: 7px">
                                        <tr>
                                            <td align='left' valign='top' style="width: 14px; height: 17px;">
                                                <asp:Button ID="Button2" runat="server" Text="Buy" Width="53px" OnClick="Button2_Click" /></td>
                                            <td align='left' valign='top' style="width: 54px; height: 17px;">
                                                <asp:Button ID="Button1" runat="server" Text="ExportToExcel" OnClick="Button1_Click" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr> <tr style="font-size: 12pt">
                                <td align="center" class="pageTD" style="width: 10%; height: 5px">
                                    賣出股票</td>
                                <td colspan="3" style="height: 5px; text-align: left" valign="top">
                                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="賣出勾選股票" /></td>
                            </tr>
                            <tr>
                                <td colspan="8" style="height: 271px">
                                    <fieldset>
                                        <legend align="center" style="color: blue; text-align: center"><strong><span style="font-family: Century Gothic">
                                            查詢結果</span></strong>:</legend>
                                        <table hight="100%" width="100%">
                                            <tr>
                                                <td align='center' valign='middle'>
                                                    <asp:GridView ID="GridView1" runat="server" Font-Names="Century Gothic" Font-Size="13pt"
                                                        Width="1000px" AutoGenerateColumns="False" CellPadding="3" BackColor="White"
                                                        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" OnRowDataBound="GridView1_RowDataBound"
                                                        EmptyDataText="No Record!!!" DataKeyNames="SN">
                                                        <RowStyle ForeColor="Black" />
                                                        <Columns>
                                                        <asp:TemplateField> 
<HeaderTemplate> 
<asp:CheckBox ID="CheckAll" runat="server" onclick="javascript: SelectAllCheckboxes(this);" 
Text="全選/取消" ToolTip="全部選擇/全部取消" /> 
</HeaderTemplate> 
<ItemTemplate> 
<asp:CheckBox ID="CheckBox1" runat="server" Text="" /> 
</ItemTemplate> 
</asp:TemplateField> 

                                                            <asp:TemplateField HeaderText="RN"></asp:TemplateField>
                                                            <asp:TemplateField HeaderText="SN">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblsn" runat="server" ForeColor="#000000" Text='<%# Bind("SN") %>'></asp:Label></br>
                                                                   
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lblsn" runat="server" ForeColor="#000000" Text='<%# Bind("SN") %>'></asp:Label></br>
                                                                    <%--  SN :</br>
                                            <asp:Label ID="lblSN" runat="server" ForeColor="Red" Text='<%# Bind("sn") %>'></asp:Label></br>--%>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="User_Id">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbluser_id" runat="server" ForeColor="#000000" Text='<%# Bind("user_id") %>'></asp:Label></br>
                                                                    trade type:<br />
                                                                    <asp:Label ID="lbltrade_type" runat="server" ForeColor="#000000" Text='<%# Bind("trade_type") %>'></asp:Label></br>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:Label ID="lbluser_id" runat="server" ForeColor="#000000" Text='<%# Bind("user_id") %>'></asp:Label></br>
                                                                    <%--  SN :</br>
                                            <asp:Label ID="lblSN" runat="server" ForeColor="Red" Text='<%# Bind("sn") %>'></asp:Label></br>--%>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            
                                                            <asp:TemplateField HeaderText="Stock_id">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    
                                                                          <asp:HyperLink ID="HyperLink2" NavigateUrl='<%#"http://vsoscar.ddns.net:8080/Stock_new/stock_pic.aspx?stock=" + DataBinder.Eval(Container.DataItem, "stock_id") %> '
                                                                        Text='<%# Bind("stock_id") %>' target='_blank' ForeColor="DeepPink" runat="server"></asp:HyperLink><br />
                                                                    Stock_Name:<br />
                                                                    <asp:Label ID="lblstock_name" runat="server" ForeColor="#000000" Text='<%# Bind("stock_name") %>'></asp:Label></br>
                                                                    
                                                                </ItemTemplate>
                                                               
                                                            </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="buy_price" >
                                                                <HeaderStyle HorizontalAlign="Center"  />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblbuy_price" runat="server" ForeColor="#000000" Text='<%# Bind("buy_price") %>'></asp:Label></br>
                                                                     stock_num:<br />
                                                                    <asp:Label ID="lblstock_num" runat="server" ForeColor="#000000" Text='<%# Bind("stock_num","{0:N0}") %>'></asp:Label></br>
                                                                      buy_total_price:<br />
                                                                      
                                                                      <asp:Label ID="Label1" runat="server" ForeColor="#000000"  Text='<%# Bind("buy_total_price", "{0:N0}") %>'></asp:Label></br>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="lblbuy_price" runat="server" ForeColor="#000000" Width="250px" Text='<%# Bind("buy_price") %>'></asp:TextBox></br>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                           
                                                          <asp:TemplateField HeaderText="Now_price">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblnow_price" runat="server" ForeColor="#000000" Text='<%# Bind("now_price") %>'></asp:Label></br>
                                                                     Now_total_price:<br />
                                                                        <asp:Label ID="lblnow_total_price" runat="server" ForeColor="#000000" Text='<%# Bind("now_total_price","{0:N0}") %>'></asp:Label></br>
                                                                        Lend_price:<br />
                                                                         <asp:Label ID="lbllend_price" runat="server" ForeColor="#000000" Text='<%# Bind("lend_price","{0:N0}") %>'></asp:Label></br>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="lblnow_price" runat="server" ForeColor="#000000" Width="250px" Text='<%# Bind("now_price") %>'></asp:TextBox></br>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            
                                                            
                                                            
                                                         
                                                            
                                                              
                                                            
                                                           
                                                             <asp:TemplateField HeaderText="Now_Benefit">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblbenefit" runat="server" ForeColor="#000000" Text='<%# Bind("now_benefit","{0:N0}") %>'></asp:Label></br>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="lblbenefit" runat="server" ForeColor="#000000" Width="250px" Text='<%# Bind("now_benefit") %>'></asp:TextBox></br>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="dttm">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbldttm" runat="server" ForeColor="#000000" Text='<%# Bind("dttm") %>'></asp:Label></br>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="lbldttm" runat="server" ForeColor="#000000" Width="250px" Text='<%# Bind("dttm") %>'></asp:TextBox></br>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                              <%-- <asp:TemplateField HeaderText="Sell ">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                  <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#"http://vsoscar.ddns.net:8080/Stock_new/sell_stock_transaction.aspx?stock_id=" + DataBinder.Eval(Container.DataItem, "stock_id")+"&sn="+DataBinder.Eval(Container.DataItem, "sn")+"&user_id="+DataBinder.Eval(Container.DataItem, "user_id") %> '
                                                                        Text='賣此股票' target='_blank' ForeColor="DeepPink" runat="server"></asp:HyperLink><br />
                                                                
                                                                   
                                                                    
                                                                </ItemTemplate>
                                                               
                                                            </asp:TemplateField>
                                                            --%>
                                                       
                                                           
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
                                    &nbsp;<span style="font-size: 9pt"></span></td>
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
<script type="text/javascript"> function SelectAllCheckboxes(spanChk) { elm=document.forms[0]; for(i=0;i<= elm.length -1;i++) { if(elm[i].type=="checkbox" && elm[i].id!=spanChk ) { if(elm.elements[i].checked!=spanChk.checked && elm[i].id.indexOf("CheckBox1")>=0) elm.elements[i].click(); } } } </script> 


</asp:Content>

