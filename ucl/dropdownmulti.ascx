<%@ Control Language="C#" AutoEventWireup="true" CodeFile="dropdownmulti.ascx.cs" Inherits="ucl_dropdownmulti" %>
<span style="position: relative">
<asp:TextBox id="TextBox1" runat="server"></asp:TextBox>
<asp:Button id="btnSelect" runat="server" Text="V" onclick="btnSelect_Click"></asp:Button>
<asp:ListBox id="lstItemList" runat="server" Width="176px" Visible="False" SelectionMode="Multiple" Height="106px"></asp:ListBox><BR>
</span>
