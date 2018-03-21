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
<body onload="JavaScript:timedRefresh(120000)">
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
<img src="http://ichart.finance.yahoo.com/z?s=^DJI&t=4d&q=c&p=m58&l=off&z=m&p=&a=ss,macd,rsi23" />
</td>
<td>


<%--<img src="http://ichart.yahoo.com/b?s=^DJI" />--%>
<img src="http://ichart.finance.yahoo.com/z?s=^GDAXI&t=4d&q=c&p=m58&l=off&z=m&p=&a=ss,macd,rsi23" />
</td>
</tr>
<tr>
<td>


<%--<img src="http://ichart.yahoo.com/b?s=^DJI" />--%>
<img src="http://ichart.finance.yahoo.com/z?s=^TWII&t=4d&q=c&p=m58&l=off&z=m&p=&a=ss,macd,rsi23" />
</td>
<td>


<%--<img src="http://ichart.yahoo.com/b?s=^DJI" />--%>
<img src="http://ichart.finance.yahoo.com/z?s=000001.SS&t=4d&q=c&p=m58&l=off&z=m&p=&a=ss,macd,rsi23" />
</td>
</tr>
</table>
         <br />
         <br />
         <table width="900" border="5" bordercolor="#8080FF" bgcolor="#FFCCFF">
             <tr>
                 <td style="width: 990px">
                <iframe src="http://so.cnyes.com/JavascriptGraphic/chartstudy.aspx?country=future&market=future&code=TWCON&divwidth=990&divheight=300&mychartname=%E6%91%A9%E6%A0%B9%E5%8F%B0%E8%82%A1%E6%8C%87%E6%95%B8%E8%BF%91%E6%9C%88" id='Iframe1' scrolling=yes style="width: 990px; height: 512px" ></iframe>
                 </td>
                
             </tr>
             <tr>
                 <td style="width: 990px">
                     <%--<img src="http://ichart.yahoo.com/b?s=^DJI" />--%>
                 <iframe src="http://so.cnyes.com/JavascriptGraphic/chartstudy.aspx?country=future&market=future&code=YMCON&divwidth=990&divheight=300&mychartname=%E9%80%A3%E7%BA%8C%E6%9C%88E-Mini%E9%81%93%E7%93%8A%E6%8C%87%E6%95%B8(YMU7)" id='Iframe2' scrolling=yes style="width: 990px; height: 512px" ></iframe>
                 </td>
                
             </tr>
              <tr>
                 <td style="width: 990px">
                     <%--<img src="http://ichart.yahoo.com/b?s=^DJI" />--%>
               <iframe src="http://so.cnyes.com/JavascriptGraphic/chartstudy.aspx?country=future&market=future&code=DAX&divwidth=990&divheight=300&mychartname=%E5%BE%B7%E5%9C%8BDAX%E6%8C%87%E6%95%B8" id='Iframe3' scrolling=yes style="width: 990px; height: 512px" ></iframe>
                 </td>
                
             </tr>
         </table>
         <br />
         <br />
        <table width="200" border="10" bordercolor="#FF0000" bgcolor="#FFFFCC">
<tr>
<td>
  <strong>
目前台股摩台指數<br><br><br><br><br><br><br>
<iframe src="http://info512.taifex.com.tw/Future/ImgChart.aspx?type=1&contract=TX&CommodityName=%E8%87%BA%E6%8C%87%E9%81%B8" id='inneriframe' scrolling=yes style="width: 698px; height: 512px" ></iframe>
<br>
 </strong>
 
<div id='outerdiv '>
    &nbsp;</div>&nbsp;</td>
<td>
<strong>
近期台股大盤K線圖 &nbsp;&nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://schrts.co/8GbnjL"
    Target="_blank">RSI</asp:HyperLink>&nbsp; &nbsp;<asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="http://stockcharts.com/def/servlet/SharpChartv05.ServletDriver?c=%24TWII,PWTADANRRO[PA][D][F1!3!!!2!20]&pnf=y"
            Target="_blank">PF Pattern</asp:HyperLink>&nbsp; &nbsp;<asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="http://stockcharts.com/h-sc/ui?s=%24TWII&p=W&st=2008-06-15&en=(today)&id=p29044150490"
            Target="_blank">Weekly Info</asp:HyperLink>&nbsp; &nbsp;<asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="http://stockcharts.com/h-sc/ui?s=%24GOLD&p=W&b=4&g=0&id=p62030242769"
            Target="_blank">Weekly Gold Info</asp:HyperLink>&nbsp; &nbsp;<asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="http://mis.twse.com.tw/stock/futures.jsp"
            Target="_blank">委買委賣</asp:HyperLink>&nbsp; &nbsp;<asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="http://info512ah.taifex.com.tw/Future/FusaQuote_Norl.aspx"
            Target="_blank">盤後</asp:HyperLink></strong><br />
    <%--<img src="http://stockcharts.com/c-sc/sc?s=%24TWII&p=D&b=4&g=0&i=p26407678585&r=1437312741461" />--%>
    <img src="http://stock.wearn.com/finance_chart.asp?stockid=&timekind=0&timeblock=180&sma1=5&sma2=58&sma3=100&volume=0&indicator1=ADX&indicator2=MACD&indicator3=Vol&=http%3A//stock.wearn.com/CallAjaxStock.asp" /></td>
</tr>
<tr>
<td>
<strong>
電子類股
 </strong>
<img src="http://stock.wearn.com/finance_chart.asp?stockid=IDX23&timekind=0&timeblock=180&sma1=5&sma2=58&sma3=100&volume=0&indicator1=ADX&indicator2=MACD&indicator3=Vol&=http%3A//stock.wearn.com/CallAjaxStock.asp" />
</td>
<td>
<strong>
金融類股
 </strong>
<img src="http://stock.wearn.com/finance_chart.asp?stockid=IDX28&timekind=0&timeblock=180&sma1=5&sma2=58&sma3=100&volume=0&indicator1=ADX&indicator2=MACD&indicator3=Vol&=http%3A//stock.wearn.com/CallAjaxStock.asp" />
</td>
</tr>
</table>
<br>
         <asp:Literal ID="Literal1" runat="server"></asp:Literal></fieldset> 

    </div>
    </form>
</body>
</html>
