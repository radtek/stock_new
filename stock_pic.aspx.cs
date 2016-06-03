﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class stock_pic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string temp = "";
        string yesturday = DateTime.Now.AddDays(-1).ToString("yyyyMMdd");
        string today = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd");
        string today_detail = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd HH:mm");
        temp = Request.QueryString["stock"];

        //temp = "1409";

        Literal1.Text = " <b>" + temp + "</b>  <a href='http://tw.stock.yahoo.com/q/h?s=" + temp + "' target='_blank'><b>個股新聞消息</b></a>   <a href='http://stock.wearn.com/asale.asp?mode=search&kind=" + temp + "' target='_blank'><b>個股月營收狀況</b></a>   <a href='http://stock.wearn.com/financial.asp?mode=search&kind=" + temp + "' target='_blank'><b>個股年度財報</b></a>   <a href='http://stock.wearn.com/dividend.asp?mode=search&kind=" + temp + "' target='_blank'><b>個股權息紅利</b></a>   <a href='http://stock.wearn.com/acredit.asp?mode=search&kind=" + temp + "' target='_blank'><b>個股卷資比</b></a>   <a href='http://jsjustweb.jihsun.com.tw/z/zc/zca/zca_" + temp + ".djhtm'&off=1 target='_blank'><b>股票資料</b></a>     <a href='http://histock.tw/stock/financial.aspx?no=" + temp + "&t=2' target='_blank'><b>扣抵稅率</b></a>  <a href='http://jsjustweb.jihsun.com.tw/z/zc/zco/zco_" + temp + "_5.djhtm' target='_blank'><b>主力進出</b></a>   <a href='http://stock.nlog.cc/e/" + temp + "' target='_blank'><b>股票分析</b></a> <a href='http://jsjustweb.jihsun.com.tw/z/zc/zcl/zcl_" + temp + ".asp.htm' target='_blank'><b>法人持股</b></a> <a href='http://www.kgifutures.com.tw/images_G1/wtxo-" + yesturday + ".pdf' target='_blank'><b>期貨選擇權</b></a> <a href='http://www.cmoney.tw/finance/f00041.aspx?s=" + temp + "' target='_blank'><b>損益表</b></a>" +
  " <table width=\"200\" border=\"10\" bordercolor=\"#3333FF\" bgcolor=\"#D7E3F9\">                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       " +
  "   <tr>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                " +
  "     <td>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              " +
  "<img src='http://yamstock.megatime.com.tw:8080/asp/mcs/tick.asp?&id="+temp+"&w=680&h=420&fmt=png&mode=detail&style=best5&rt=on&overlap=0&chartstyle=&t=1400850724859'>" +
  "     </td>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             " +
  "     <td> <img src='http://stock.wearn.com/finance_chart.asp?stockid=" + temp + "&timekind=0&timeblock=180&sma1=5&sma2=23&sma3=35&volume=0&indicator1=RSI&indicator2=MACD&indicator3=Vol&=http%3A//stock.wearn.com/CallAjaxStock.asp '> </td>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                " +
  "   </tr>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               " +
  "   <tr>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                " +
  "     <td> <img src='http://stock.wearn.com/finance_chart.asp?stockid=" + temp + "&timekind=0&timeblock=180&sma1=&sma2=&sma3=&volume=0&indicator1=DPO&indicator2=MACD&indicator3=Vol&=http%3A//stock.wearn.com/CallAjaxStock.asp' > </td>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       " +
  "     <td> <img src='http://stock.wearn.com/foreign_buy.asp?stockid=" + temp + "'> </td>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        " +
  "   </tr>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               " +
  " </table>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              ";
        
        
       
      
    }
}
