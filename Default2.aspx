<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
   <script type="text/javascript"> 
   var testArray = new Array;  
   testArray=["dddd", "abc", "wer"]; 
   
   
   
   $( "#TextBox1" ).autocomplete({ source: testArray});
   
   </script>
</head>
<body>
    <form id="form1" runat="server" method="post">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></div>
    </form>
</body>
</html>
