<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>加密解密TEST</title>
   <script type="text/javascript"> 
   var testArray = new Array;  
   testArray=["dddd", "abc", "wer"]; 
   
   
   
   $( "#TextBox2" ).autocomplete({ source: testArray});
   
   </script>
</head>
<body>
    <form id="form1" runat="server" method="post">
    <div>
        <br />
        加密字串<br />
        <br />
        <asp:TextBox ID="TextBox2" runat="server" Width="308px"></asp:TextBox><br />
        加密KEY<br />
        <asp:TextBox ID="TextBox3" runat="server" Width="173px"></asp:TextBox><br />
        <br />
        加密IV<br />
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox><br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="執行加密" Width="83px" OnClick="Button1_Click" /><br />
        <br />
        加密結果<br />
        <asp:TextBox ID="TextBox1" runat="server" Width="296px"></asp:TextBox><br />
        <br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server">HyperLink</asp:HyperLink>
        &nbsp; &nbsp; &nbsp; &nbsp;
        <asp:HyperLink ID="HyperLink2" runat="server">HyperLink</asp:HyperLink><br />
        ******************************************************<br />
        <br />
        解密字串<br />
        <asp:TextBox ID="TextBox5" runat="server" Width="296px"></asp:TextBox><br />
        <br />
        解密KEY<br />
        <asp:TextBox ID="TextBox6" runat="server" Width="173px"></asp:TextBox><br />
        <br />
        解密IV<br />
        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox><br />
        <br />
        <asp:Button ID="Button2" runat="server" Text="執行解密" OnClick="Button2_Click" /><br />
        <br />
        解密結果<br />
        <asp:TextBox ID="TextBox8" runat="server" Width="296px"></asp:TextBox><br />
        <br />
        <asp:HyperLink ID="HyperLink3" runat="server">欲加密網址</asp:HyperLink><br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>
    </form>
</body>
</html>
