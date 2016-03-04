<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"  EnableEventValidation="false" CodeFile="viewforum.aspx.cs" Inherits="viewforum" Title="viewforum" %>
<%@ Register TagPrefix="obout" Namespace="OboutInc.Calendar2" Assembly="obout_Calendar2_Net" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>



   
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <link href="app_themes/layout/layout.css" rel="stylesheet" type="text/css" />
 <form id="form1" >
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
                                                <span id="Span1" style="font-size: 16pt; font-family: Century Gothic"><strong>查詢 留言版
                                                    紀錄</strong></span></td>
                                            <td align="right" style="font-size: 12px; color: navy; height: 30px;">
                                                <span style="color: #ff0000"></span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="pageTD" colspan="8" style="height: 35px; text-align: left;">
                                    <table style="width: 236px; height: 7px">
                                        <tr>
                                            <td align='left' valign='top' style="width: 14px; height: 17px;">
                                                <asp:Button ID="ButtonAdd" runat="server" Style="font-size: 12px; font-family: Arial;
                                                    width: 100px;" Text="發表主題" OnClick="ButtonAdd_Click"  />
                                            </td>
                                            <td align='left' valign='top' style="width: 25px; height: 17px;">
                                                </td>
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
                                                    
<asp:UpdatePanel id="UpdatePanel1" runat="server">
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
                                                            <asp:TemplateField HeaderText="TOPIC_NAME">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#"viewtopic.aspx?topicid=" + DataBinder.Eval(Container.DataItem, "TOPIC_ID") %> '
                                                                        Text='<%# Bind("TOPIC_NAME") %>' Target='_blank' ForeColor="DeepPink" runat="server"></asp:HyperLink>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="lblStock_id" runat="server" ForeColor="#000000" Width="250px" Text='<%# Bind("TOPIC_ID") %>'></asp:TextBox></br>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            
                                                           
                                                            
                                                            <asp:TemplateField HeaderText="發表人">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCREATE_USER" runat="server" ForeColor="#000000" Text='<%# Bind("CREATE_USER") %>'></asp:Label></br>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="lblCREATE_USER" runat="server" ForeColor="#000000" Width="250px" Text='<%# Bind("CREATE_USER") %>'></asp:TextBox></br>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            
                                                            <asp:TemplateField HeaderText="回覆">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblstock_name" runat="server" ForeColor="#000000" Text='<%# Bind("re_count") %>'></asp:Label></br>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="lblstock_name" runat="server" ForeColor="#000000" Width="250px"
                                                                        Text='<%# Bind("re_count") %>'></asp:TextBox></br>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                              <asp:TemplateField HeaderText="發表時間">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblavg_hot_price" runat="server" ForeColor="#000000" Text='<%# Bind("DTTM") %>'></asp:Label></br>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="lblavg_hot_price" runat="server" ForeColor="#000000" Width="250px"
                                                                        Text='<%# Bind("DTTM") %>'></asp:TextBox></br>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            
                                                           
                                                            <asp:TemplateField HeaderText="最後回覆時間">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblavg_hot_price" runat="server" ForeColor="#000000" Text='<%# Bind("RE_DTTM") %>'></asp:Label></br>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="lblavg_hot_price" runat="server" ForeColor="#000000" Width="250px"
                                                                        Text='<%# Bind("RE_DTTM") %>'></asp:TextBox></br>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            
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
                                    <span style="font-size: 9pt"></span></td>
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
   </DIV>

</asp:Content>

