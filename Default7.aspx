<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default7.aspx.cs" Inherits="Default7" %>
<%@Register TagPrefix="uc1" TagName="ListMulti" src="ucl/dropdownmulti.ascx"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>未命名頁面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Here is some text
			<uc1:ListMulti runat="server" id="ListMulti1"></uc1:ListMulti><br>
			and some more text down here.<br>
			and a third Line that is really long which should go underneath the combo box and show how cool absolute positioning can be.&nbsp;
    </div>
    </form>
</body>
</html>

