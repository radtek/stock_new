<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Commonurl2.aspx.cs" Inherits="Commonurl2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Url2</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        常用的網址<br />
        <br />
        <asp:HyperLink ID="HyperLink1" target="_blank" Text="台指期貨日盤走勢"  runat="server" NavigateUrl="http://mis.twse.com.tw/stock/futures.jsp"></asp:HyperLink><br />
       <br />
        <asp:HyperLink ID="HyperLink2" target="_blank" Text="台指期盤後盤"  runat="server" NavigateUrl="http://info512ah.taifex.com.tw/Future/FusaQuote_Norl.aspx"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink25" runat="server" NavigateUrl="https://hk.investing.com/indices/sgx-msci-taiwan-futures-technical"
            Target="_blank" Text="摩台技術分析"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink7" target="_blank" Text="三大法人區分各區期貨未平倉餘額"  runat="server" NavigateUrl="http://www.taifex.com.tw/cht/3/futContractsDate"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink6" target="_blank" Text="小台指總未平倉量(*未沖銷契約量)"  runat="server" NavigateUrl="http://www.taifex.com.tw/cht/3/futDailyMarketExcel?commodity_id=MTX"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink11" target="_blank" Text="選擇權大額交易人未沖銷部位"  runat="server" NavigateUrl="http://www.taifex.com.tw/cht/3/largeTraderOptQry"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink8" target="_blank" Text="選擇權多空未平倉"  runat="server" NavigateUrl="http://www.taifex.com.tw/cht/3/optContractsDate"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink4" target="_blank" Text="現貨三大法人"  runat="server" NavigateUrl="http://www.tse.com.tw/zh/page/trading/fund/BFI82U.html"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink19" runat="server" NavigateUrl="https://www.wantgoo.com/option/futures/quotes?StockNo=WTXM%26"
            Target="_blank" Text="台指多空力道"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink18" runat="server" NavigateUrl="https://www.wantgoo.com/stock/marketbidsellchart/index"
            Target="_blank" Text="台股多空力道即時監控"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink20" runat="server" NavigateUrl="https://www.wantgoo.com/global/stockindex?stockno=B1YM%26"
            Target="_blank" Text="小道瓊多空力道"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink21" runat="server" NavigateUrl="https://www.wantgoo.com/global/stockindex?StockNo=tsm"
            Target="_blank" Text="台積ADR多空力道"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="https://stock.wearn.com/taifexphoto.asp" Target="_blank">期貨法人未平倉</asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink22" runat="server" NavigateUrl="https://www.wantgoo.com/stock/futures/threefuturescost?type=1"
            Target="_blank">期貨-外資持倉成本/未平倉口數</asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink17" runat="server" NavigateUrl="https://www.wantgoo.com/stock/futures/optionstoday"
            Target="_blank" Text="選擇權支撐壓力表"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink27" runat="server" NavigateUrl="https://goodinfo.tw/StockInfo/ShowBearishChart.asp?STOCK_ID=%E5%8A%A0%E6%AC%8A%E6%8C%87%E6%95%B8&CHT_CAT=DATE"
            Target="_blank" Text="融資融卷餘額"></asp:HyperLink><br />
         <br />
        <asp:HyperLink ID="HyperLink15" target="_blank" Text="GAN9"  runat="server" NavigateUrl="http://www.pivottrading.co.in/pages/gannSquareof9.php"></asp:HyperLink><br />
        
         <br />
        <asp:HyperLink ID="HyperLink3" target="_blank" Text="鉅亨網"  runat="server" NavigateUrl="http://www.cnyes.com/twoption/closing.aspx"></asp:HyperLink><br />
         
         <br />
        <asp:HyperLink ID="HyperLink5" target="_blank" Text="臺指選擇權(TXO)Put/Call Ratio"  runat="server" NavigateUrl="http://www.taifex.com.tw/cht/3/pcRatio"></asp:HyperLink><br />
         
         <br />
        <asp:HyperLink ID="HyperLink9" target="_blank" Text="金十財經"  runat="server" NavigateUrl="https://rili.jin10.com"></asp:HyperLink><br />
         
         <br />
        <asp:HyperLink ID="HyperLink10" target="_blank" Text="凱基期貨"  runat="server" NavigateUrl="https://www.kgifutures.com.tw/content/research01.asp"></asp:HyperLink><br />
         
         <br />
        <asp:HyperLink ID="HyperLink12" target="_blank" Text="東方財富"  runat="server" NavigateUrl="http://quote.eastmoney.com/centerv2/hszs"></asp:HyperLink><br />
         
         <br />
        <asp:HyperLink ID="HyperLink13" target="_blank" Text="國發會景氣燈號"  runat="server" NavigateUrl="https://index.ndc.gov.tw//n/zh_tw"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl="https://www.wantgoo.com/global"
            Target="_blank" Text="全球指數"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink23" runat="server" NavigateUrl="https://hk.investing.com/technical/futures-technical-analysis"
            Target="_blank" Text="道瓊30技術分析"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink24" runat="server" NavigateUrl="https://hk.investing.com/technical/germany-30-futures-technical-analysis"
            Target="_blank" Text="德國技術技術分析"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink26" runat="server" NavigateUrl="https://hk.investing.com/economic-calendar/adp-nonfarm-employment-change-1"
            Target="_blank" Text="美國小非農ADP(每月第一個禮拜三)"></asp:HyperLink><br />
        <br />
        <br />
        <br />
        <br />
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
