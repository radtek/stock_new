<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="epaper_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
<%--<script src="jquery-1.4.1.min.js"></script>--%>
<style type="text/css"> 
#example-placeholder {
  border: 1px solid #ccc;
  padding:  10px;
}
</style>
<script language="javascript"> 
function example_ajax_request() {
  $('#example-placeholder').html('<p><img src="../images/ajax-loader.gif" width="200" height="19" /></p>');
  //setTimeout('example_ajax_request_go()', 2000);
}
function example_ajax_request_go() {
  //$('#example-placeholder').load("/examples/ajax-loaded.html");
  $('#example-placeholder').html("<p>this is a sample</p>");
}
</script>
</head>
<body>
<p><input type="button" value="Click Me!" onclick="example_ajax_request()" /></p> 
<div id="example-placeholder"> 
<p>Placeholding text</p> </div>
</body>
</html>