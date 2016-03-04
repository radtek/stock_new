<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frame_main.aspx.cs" Inherits="frame_main" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UserControls/Header.ascx" TagPrefix="innolux" TagName="Header" %>
<%@ Register Src="~/UserControls/HeaderMenuBar.ascx" TagPrefix="innolux" TagName="HeaderMenuBar" %>
<%@ Register Src="~/UserControls/Footer.ascx" TagPrefix="innolux" TagName="Footer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>InnoView</title>
    <style type="text/css">
		 html { overflow:hidden; }
    </style>
   <script type="text/javascript">
    <!-- 
//		document.write('<div id="loadDiv" style="padding-top:150; padding-left:150; font-size:13pt;">'+ '页面正在载入，请等待</div>');   
//		function   window.onload()   
//		{   
//			hiddenDiv.style.display=""; 
//			loadDiv.removeNode(true); 
//		}  
		--> 
    </script> 
</head>
<body onload="CollectGarbage();">
    <form id="mainForm" runat="server">
        
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
       <%--<div  id="hiddenDiv"  style="display:none">--%>    
       
       <telerik:RadFormDecorator ID="RadFormDecorator1" runat="server" Skin="Web20" /> 

        <telerik:RadSplitter ID="radSplitter1" runat="server" Skin="Office2007" Orientation="Horizontal"
            BorderStyle="None" FullScreenMode="true" VisibleDuringInit="False" >
            <telerik:RadPane ID="Radpane1" runat="server" Scrolling="None" Height="110px" BorderStyle="none" >
                <innolux:Header runat="Server" ID="header" />
            </telerik:RadPane>
            <telerik:RadSplitBar ID="RadSplitBar1" runat="server" CollapseMode="Forward" BorderStyle="none" />
            <telerik:RadPane ID="RadPane3" runat="server" Scrolling="None" BorderStyle="none">
                <telerik:RadSplitter ID="RadSplitter2" runat="server" Orientation="Horizontal" BorderStyle="none" width="100%">

                  <%--  <telerik:RadPane ID="RadPane5" runat="server" Height="19px" Width="100%" Scrolling="None" Locked="True" BorderStyle="none">--%>
                    
              <%--      
					<telerik:RadRotator ScrollDirection="left" FrameDuration="0" Width="100%" Height="19px" ScrollDuration="10000" ID="Rotator1" runat="server" BackColor="Black" >
                        <ItemTemplate>
                            <table  width ="300" border="0" cellpadding="0" cellspacing="0"> 
								<tr> 
									<td>
										<span style="color:<%#DataBinder.Eval(Container.DataItem,"NameColor") %> ;font-size: 11px;">
										<strong><%# DataBinder.Eval(Container.DataItem,"Name") %></strong>
										</span>
									</td>
									<td>
										<span style="color:<%#DataBinder.Eval(Container.DataItem,"ValueColor") %> ; font-size: 14px;">
										<strong><%# DataBinder.Eval(Container.DataItem, "Value")%></strong>
										</span>
									</td>
								</tr> 
							</table>      
                        </ItemTemplate>
                    </telerik:RadRotator>--%>

                        <%--<marquee direction="left" scrollamount="20" scrolldelay="500" bgcolor="black" width="100%"
									onmouseover="this.stop()" onmouseout="this.start()"><asp:DataList id="DataList1" Width="100%" RepeatDirection="Horizontal" EditItemIndex="1" Font-Size="Smaller" Runat="server">
								<ItemTemplate>
									<table  width ="100%" border="0" cellpadding="0" cellspacing="0"> 
										<tr> 
											<td>
												<span style="color:<%#DataBinder.Eval(Container.DataItem,"NameColor") %> ;font-size: 11px;">
												<strong><%#DataBinder.Eval(Container.DataItem,"Name") %></strong>
												</span>
											</td>
											<td>
												<span style="color:<%#DataBinder.Eval(Container.DataItem,"ValueColor") %> ; font-size: 14px;">
												<strong><%# DataBinder.Eval(Container.DataItem, "Value")%></strong>
												</span>
											</td>
										</tr> 
									</table>                               
								</ItemTemplate>
							</asp:DataList></marquee>--%>
                 <%--   </telerik:RadPane>--%>
                    <telerik:RadPane ID="RadPane4" runat="server" Height="27px" Scrolling="None" Width="100%" BorderStyle="none">
                        <innolux:HeaderMenuBar runat="server" ID="hearderMenuBar" /> 
                    </telerik:RadPane>                    
                    
                    <telerik:RadPane ID="RadPane2" runat="server" Scrolling="None" BorderStyle="none" Width="100%">
                        <asp:ContentPlaceHolder ID="mainContentplaceholder" runat="server">
                        </asp:ContentPlaceHolder>
                    </telerik:RadPane>
                    
                </telerik:RadSplitter>
            </telerik:RadPane>
        </telerik:RadSplitter>
        <br />
       <%--</div>--%> 
    </form>
</body>
</html>