﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Commonurl3.aspx.cs" Inherits="Commonurl3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>URL3</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        常用的網址<br />
        <br />
        <asp:HyperLink ID="HyperLink39" runat="server" NavigateUrl="checkview.aspx"
            Target="_blank" Text="上帝視角"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink40" runat="server" NavigateUrl="KPI_POINT.aspx"
            Target="_blank" Text="指數計算"></asp:HyperLink><br />
        <br />
       <asp:HyperLink ID="HyperLink42" runat="server" NavigateUrl="http://www.tse.com.tw/zh/page/trading/fund/BFI82U.html" Target="_blank"
            Text="三大法人現貨未平倉"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink57" runat="server" NavigateUrl="https://stockcharts.com/h-sc/ui?s=%24INDU&p=D&b=5&g=0&id=p71333981028"
            Target="_blank" Text="StockChart道瓊"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink58" runat="server" NavigateUrl="https://stockcharts.com/h-sc/ui?s=%24TWII&p=D&b=5&g=0&id=p50926176308"
            Target="_blank" Text="StockChart台灣加權"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink59" runat="server" NavigateUrl="https://stockcharts.com/h-sc/ui?s=%24SOX&p=D&b=5&g=0&id=p08797142880"
            Target="_blank" Text="StockChart費城半導體"></asp:HyperLink><br />
    
        <br />
        <asp:HyperLink ID="HyperLink43" runat="server" NavigateUrl="https://www.taifex.com.tw/cht/5/optIndxFSP" Target="_blank"
            Text="台指期貨最後結算價履歷"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink41" runat="server" NavigateUrl="http://info512.taifex.com.tw/Future/VIXQuote_Norl.aspx"
            Target="_blank" Text="臺指選擇權波動率指數"></asp:HyperLink><br />
        
        <br />
        <asp:HyperLink ID="HyperLink11" target="_blank" Text="台指期選 P/C Ratio"  runat="server" NavigateUrl="https://www.taifex.com.tw/cht/3/pcRatio"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink7" target="_blank" Text="三大法人選擇權"  runat="server" NavigateUrl="https://www.taifex.com.tw/cht/3/optContractsDate"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink17" runat="server" NavigateUrl="https://www.taifex.com.tw/cht/3/largeTraderOptQry"
            Target="_blank" Text="大額交易人"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="https://www.taifex.com.tw/cht/3/futContractsDate" Target="_blank">三大法人期貨</asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink4" target="_blank" Text="選擇權支撐壓力表"  runat="server" NavigateUrl="https://www.wantgoo.com/stock/futures/optionstoday"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink51" target="_blank" Text="台指期未平倉"  runat="server" NavigateUrl="https://stock.wearn.com/taifexphoto.asp"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink52" target="_blank" Text="台灣加權指數技術分析"  runat="server" NavigateUrl="https://hk.investing.com/indices/taiwan-weighted-technical"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink53" target="_blank" Text="MSCI Taiwan期貨技術分析"  runat="server" NavigateUrl="https://hk.investing.com/indices/sgx-msci-taiwan-futures-technical"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink54" runat="server" NavigateUrl="https://www.yuanta.com.tw/eYuanta/securities/Node/Index?MainId=00430&C1=2018040402289271&C2=2018040409866486&ID=2018040409866486&Level=2&rnd=33637"
            Target="_blank" Text="現貨外資買賣超個股"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink60" runat="server" NavigateUrl="http://jsjustweb.jihsun.com.tw/z/zg/zgb/zgb0.djhtm?a=8440&b=8440&c=B&d=1"
            Target="_blank" Text="卷商買賣超個股"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink56" runat="server" NavigateUrl="https://histock.tw/stock/exdividendtable.aspx"
            Target="_blank" Text="除權息扣抵點數"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink13" target="_blank" Text="國發會景氣燈號"  runat="server" NavigateUrl="https://index.ndc.gov.tw//n/zh_tw"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink34" runat="server" NavigateUrl="http://quote.eastmoney.com/gb/zsTWII.html"
            Target="_blank" Text="台灣加權指數(東方)"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink35" runat="server" NavigateUrl="http://quote.eastmoney.com/globalfuture/YM00Y.html"
            Target="_blank" Text="小道期貨(東方)"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink37" runat="server" NavigateUrl="http://quote.eastmoney.com/globalfuture/DINI.html"
            Target="_blank" Text="美元指數(東方)"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink36" runat="server" NavigateUrl="http://quote.eastmoney.com/gb/zsGDAXI.html"
            Target="_blank" Text="DAX指數(東方)"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink38" runat="server" NavigateUrl="https://rate.bot.com.tw/xrt/quote/ltm/USD"
            Target="_blank" Text="台幣匯率"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink33" runat="server" NavigateUrl="http://acer2266.com/blog/"
            Target="_blank" Text="交易醫生"></asp:HyperLink><br /><br />
        <asp:HyperLink ID="HyperLink28" runat="server" NavigateUrl="https://www.moneydj.com/funddj/ya/YP051000.djhtm?a=FA000004"
            Target="_blank" Text="市場風向球"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink24" runat="server" NavigateUrl="https://www.chinatimes.com/newspapers/2602"
            Target="_blank" Text="中時電子報"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink30" runat="server" NavigateUrl="https://money.udn.com/money/index"
            Target="_blank" Text="經濟日報"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink31" runat="server" NavigateUrl="http://ec.ltn.com.tw/"
            Target="_blank" Text="自由時報財經版"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink32" runat="server" NavigateUrl="https://tw.appledaily.com/daily"
            Target="_blank" Text="蘋果財經"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink1" target="_blank" Text="台指期貨日盤走勢"  runat="server" NavigateUrl="http://mis.twse.com.tw/stock/futures.jsp"></asp:HyperLink><br />
       <br />
        <asp:HyperLink ID="HyperLink2" target="_blank" Text="台指期盤後盤"  runat="server" NavigateUrl="http://info512ah.taifex.com.tw/Future/FusaQuote_Norl.aspx"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink25" runat="server" NavigateUrl="https://hk.investing.com/indices/sgx-msci-taiwan-futures-technical"
            Target="_blank" Text="摩台技術分析"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink6" target="_blank" Text="小台指總未平倉量(*未沖銷契約量)"  runat="server" NavigateUrl="http://www.taifex.com.tw/cht/3/futDailyMarketExcel?commodity_id=MTX"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink8" target="_blank" Text="選擇權多空未平倉"  runat="server" NavigateUrl="http://www.taifex.com.tw/cht/3/optContractsDate"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink27" runat="server" NavigateUrl="https://goodinfo.tw/StockInfo/ShowBearishChart.asp?STOCK_ID=%E5%8A%A0%E6%AC%8A%E6%8C%87%E6%95%B8&CHT_CAT=DATE"
            Target="_blank" Text="融資融卷餘額"></asp:HyperLink><br />
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
        <asp:HyperLink ID="HyperLink22" runat="server" NavigateUrl="https://www.wantgoo.com/stock/futures/threefuturescost?type=1"
            Target="_blank">期貨-外資持倉成本/未平倉口數</asp:HyperLink><br />
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
        <asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl="https://www.wantgoo.com/global"
            Target="_blank" Text="全球指數"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink23" runat="server" NavigateUrl="https://hk.investing.com/technical/futures-technical-analysis"
            Target="_blank" Text="道瓊30技術分析"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink26" runat="server" NavigateUrl="https://hk.investing.com/economic-calendar/adp-nonfarm-employment-change-1"
            Target="_blank" Text="美國小非農ADP(每月第一個禮拜三)"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink29" runat="server" NavigateUrl="http://jow.win168.com.tw/z/zg/zg_DD_0_3.djhtm"
            Target="_blank" Text="投信三日買超"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink47" runat="server" NavigateUrl="http://stock.nlog.cc/G/1593"
            Target="_blank" Text="定存概念股"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink44" runat="server" NavigateUrl="http://invest.wessiorfinance.com/stock.html"
            Target="_blank" Text="存股試算"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink45" runat="server" NavigateUrl="Stock_pic.aspx?stock=2330"
            Target="_blank" Text="股票寫真"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink46" runat="server" NavigateUrl="http://www.cmoney.tw/finance/f00043.aspx?s=1730&o=3"
            Target="_blank" Text="股票ROE/ROA"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink48" runat="server" NavigateUrl="OP_COST1.aspx" Target="_blank"
            Text="算數學"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink49" runat="server" NavigateUrl="http://www.taifex.com.tw/cht/3/dlOptDailyMarketView" Target="_blank"
            Text="選擇權資料下載"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink50" runat="server" NavigateUrl="epaper/OP_Modifield.aspx"
            Target="_blank" Text="執行算數學"></asp:HyperLink><br />
        <br />
        <asp:HyperLink ID="HyperLink55" runat="server" NavigateUrl="https://www.buyiju.com/lhl/caishen/"
            Target="_blank" Text="財神方位"></asp:HyperLink><br />
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
