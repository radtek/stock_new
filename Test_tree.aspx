<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test_tree.aspx.cs" Inherits="Test_tree" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;&nbsp;<asp:TreeView ID="TreeView1" runat="server" ImageSet="News" NodeIndent="10">
            <ParentNodeStyle Font-Bold="False" />
            <HoverNodeStyle Font-Underline="True" />
            <SelectedNodeStyle Font-Underline="True" HorizontalPadding="0px" VerticalPadding="0px" />
            <NodeStyle Font-Names="Arial" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px"
                NodeSpacing="0px" VerticalPadding="0px" />
        </asp:TreeView>
        <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>&nbsp;<br />
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    </div>
    </form>
</body>
</html>
