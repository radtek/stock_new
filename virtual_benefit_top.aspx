<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"  EnableEventValidation="false" CodeFile="virtual_benefit_top.aspx.cs" Inherits="virtual_benefit_top" Title="virtual_benefit_top" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
            <table hight="100%" width="100%">
                <tr>
                    <td align='center' valign='middle'>
                        <fieldset style="text-align: center; width: 849px; height: 329px;">
                            <legend id="legend3" runat="server" align="center" style="font-weight: bold; font-size: 12px;
                                font-family: Arial; color: black; text-align: center;"><span style="font-size: 14pt;
                                    color: Gray; text-align: center">Virtual Benefit Top</span></legend>
                            <br />
                            <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE"
                                BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False"
                                AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_RowDataBound"
                                PageSize="50" BorderStyle="None">
                                <FooterStyle BackColor="#CCCC99" />
                                <RowStyle BackColor="#F7F7DE" />
                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField HeaderText="SN" />
                                    <asp:BoundField HeaderText="User_id" DataField="User_id" />
                                    <asp:BoundField HeaderText="年/月" DataField="yyyyMM" />
                                    <asp:BoundField HeaderText="Benefit" DataField="benefit" DataFormatString="{0:N0}" />
                                  
                                   
                                    
                                  
                                </Columns>
                            </asp:GridView>
                        </fieldset>
                    </td>
                </tr>
            </table>
        </div>

</asp:Content>


