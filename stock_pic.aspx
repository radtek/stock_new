<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" CodeFile="stock_pic.aspx.cs" Inherits="stock_pic" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Stock Analysis</title>
  <script type="text/JavaScript">                                                                                                                                                
<!--  
                                                                                                                                                                        
function timedRefresh(timeoutPeriod) {  
                                                                                                                                        
	setTimeout("location.reload(true);",timeoutPeriod);  
	//setTimeout("location.href=location.href;",timeoutPeriod);   
	  
                                                                                                     
}   
                                                                                                                                                                               
function IMG1_onclick() {

}

//   -->                                                                                                                                                                       
</script>  

</head>
<body onload="JavaScript:timedRefresh(60000)">
    <form id="form1" runat="server"  >
    
    <div>
     <fieldset > 
<legend align="center" style="color:blue;text-align:center"><strong><span style="font-size: 14pt;
    font-family: Century Gothic">Stock Analysis:</span></strong></legend> 
    <strong>
美國道瓊指數&nbsp;
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="http://stockcharts.com/h-sc/ui?s=INDU&p=D&b=4&g=0&id=p71999026082"
            Target="_blank">RSI</asp:HyperLink>&nbsp; <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="http://stockcharts.com/def/servlet/SharpChartv05.ServletDriver?c=%24INDU,PWTIDANRRO[PA][D][F1!3!!!2!20]&pnf=y"
            Target="_blank">PF Pattern</asp:HyperLink>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; 德國指數 &nbsp;<asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="http://stockcharts.com/h-sc/ui?s=DAX&p=D&b=4&g=0&id=p71999026082"
            Target="_blank">RSI</asp:HyperLink>
        &nbsp; &nbsp;<asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="http://stockcharts.com/def/servlet/SharpChartv05.ServletDriver?c=%24DAX,PWTADANRRO[PA][D][F1!3!!!2!20]&pnf=y"
            Target="_blank">PF Pattern</asp:HyperLink>
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        <br />
    </strong>
    <table width="200" border="5" bordercolor="#6600FF" bgcolor="#FFCCFF">
<tr>
<td>


<img src="http://ichart.yahoo.com/b?s=^DJI" id="IMG1" onclick="return IMG1_onclick()" />


</td>
<td>
<img src="http://ichart.yahoo.com/b?s=^GDAXI" id="IMG2" onclick="return IMG1_onclick()" />
</td>


</tr>
</table>
         <br />
        
         <br />
<table width="200" border="5" bordercolor="#FF8042" bgcolor="#FFCCFF">
<tr>
<td>


<%--<img src="http://ichart.yahoo.com/b?s=^DJI" />--%>
<img src="http://ichart.finance.yahoo.com/z?s=^DJI&q=c&l=off&z=m&p=m60&a=macd&tt=0&range=1d" />
</td>
<td>


<%--<img src="http://ichart.yahoo.com/b?s=^DJI" />--%>
<img src="http://ichart.finance.yahoo.com/z?s=^GDAXI&q=c&l=off&z=m&p=m60&a=macd&tt=0&range=1d" />
</td>
</tr>
</table>
<br/>
<table width="200" border="5" bordercolor="#8080FF" bgcolor="#FFCCFF">
<tr>
<td>


<%--<img src="http://ichart.yahoo.com/b?s=^DJI" />--%>
<img src="http://ichart.finance.yahoo.com/z?s=^DJI&t=4d&q=c&p=m47&l=off&z=m&p=&a=ss,macd,rsi23" />
</td>
<td>


<%--<img src="http://ichart.yahoo.com/b?s=^DJI" />--%>
<img src="http://ichart.finance.yahoo.com/z?s=^GDAXI&t=4d&q=c&p=m47&l=off&z=m&p=&a=ss,macd,rsi23" />
</td>
</tr>
<tr>
<td>


<%--<img src="http://ichart.yahoo.com/b?s=^DJI" />--%>
<img src="http://ichart.finance.yahoo.com/z?s=^TWII&t=4d&q=c&p=m47&l=off&z=m&p=&a=ss,macd,rsi23" />
</td>
<td>


<%--<img src="http://ichart.yahoo.com/b?s=^DJI" />--%>
<img src="http://ichart.finance.yahoo.com/z?s=000001.SS&t=4d&q=c&p=m47&l=off&z=m&p=&a=ss,macd,rsi23" />
</td>
</tr>
</table>
         <br />
         <br />
        <table width="200" border="10" bordercolor="#FF0000" bgcolor="#FFFFCC">
<tr>
<td>
  <strong>
目前台股大盤指數<br><br><br><br><br><br><br><br>
 </strong>
<img src="http://yamstock.megatime.com.tw:8080/asp/mcs/ws.asp?w=700&h=400&fmt=png&rt=on&min=1&mode=detail&id=M_010300&style=totalmean&dot=2"  />&nbsp;</td>
<td>
<strong>
近期台股大盤K線圖 &nbsp;&nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://schrts.co/8GbnjL"
    Target="_blank">RSI</asp:HyperLink>&nbsp; &nbsp;<asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="http://stockcharts.com/def/servlet/SharpChartv05.ServletDriver?c=%24TWII,PWTADANRRO[PA][D][F1!3!!!2!20]&pnf=y"
            Target="_blank">PF Pattern</asp:HyperLink>&nbsp; &nbsp;<asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="http://stockcharts.com/h-sc/ui?s=%24TWII&p=W&st=2008-06-15&en=(today)&id=p29044150490"
            Target="_blank">Weekly Info</asp:HyperLink>&nbsp; &nbsp;<asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="http://stockcharts.com/h-sc/ui?s=%24GOLD&p=W&b=4&g=0&id=p62030242769"
            Target="_blank">Weekly Gold Info</asp:HyperLink></strong><br />
    <%--<img src="http://stockcharts.com/c-sc/sc?s=%24TWII&p=D&b=4&g=0&i=p26407678585&r=1437312741461" />--%>
    <img src="http://stock.wearn.com/finance_chart.asp?stockid=&timekind=0&timeblock=180&sma1=5&sma2=23&sma3=35&volume=0&indicator1=RSI&indicator2=MACD&indicator3=Vol&=http%3A//stock.wearn.com/CallAjaxStock.asp" /></td>
</tr>
<tr>
<td>
<strong>
電子類股
 </strong>
<img src="http://stock.wearn.com/finance_chart.asp?stockid=IDX23&timekind=0&timeblock=180&sma1=5&sma2=23&sma3=35&volume=0&indicator1=DPO&indicator2=MACD&indicator3=Vol&=http%3A//stock.wearn.com/CallAjaxStock.asp" />
</td>
<td>
<strong>
金融類股
 </strong>
<img src="http://stock.wearn.com/finance_chart.asp?stockid=IDX28&timekind=0&timeblock=180&sma1=5&sma2=23&sma3=35&volume=0&indicator1=DPO&indicator2=MACD&indicator3=Vol&=http%3A//stock.wearn.com/CallAjaxStock.asp" />
</td>
</tr>
</table>
<br>
         <asp:Literal ID="Literal1" runat="server"></asp:Literal></fieldset> 

    </div>
    </form>
</body>
</html>
