function deep1(no,deep)
{
  if(deep == 10)
    return;
  for(var i=0;i<5;i++)
  {
	switch(no)
	{
      case 2:
        eval("pmL"+no+""+deep+""+i+"=new TPopMenu('Menu "+i+"','0','','',' Menu "+deep+" "+i+"');"); 
	    break;
 	  default:
		eval("pmL"+no+""+deep+""+i+"=new TPopMenu('Menu "+i+"','','','',' Menu "+deep+" "+i+"');"); 
	}
       
  }
  deep1(no,++deep);
}
function deep2(par,no,deep)
{ 
  if(deep == 10)
    return;
  var j = Math.round(Math.random()*4);
  for(var i=0;i<5;i++)
  {
    eval(par+".Add(pmL"+no+""+deep+""+i+");");
    if(i== j)
    {  
      var d = deep+1;  
      deep2("pmL"+no+""+deep+""+i,no,d);
    }
  }
}
//xp style
function deep1(no,deep)
{
  if(deep == 10)
    return;
  for(var i=0;i<5;i++)
  {
    switch(no)
    {
      case 2:
        eval("pmL"+no+""+deep+""+i+"=new TPopMenu('Menu "+i+"','0','','',' Menu "+deep+" "+i+"');"); 
        break;
      default:
            eval("pmL"+no+""+deep+""+i+"=new TPopMenu('Menu "+i+"','','','',' Menu "+deep+" "+i+"');"); 
    }
       
  }
  deep1(no,++deep);
}        
        
var mm0 = new TMainMenu('mm0','horizontal');
//mm0.SetWidth(500);
//****�w�g Mark by Oscar 2009/05/21 ******//
//var pmselect_area = new TPopMenu('���O','5','','','�|ĳ�O��E�ƥ��x');
//var area_ary = new TPopMenu('Array�|ĳ','','a',"../ary/main.aspx",'Array�|ĳ');
//var area_cell = new TPopMenu('Cell�|ĳ','','a',"../cell/main.aspx",'Cell�|ĳ');
//var area_cf = new TPopMenu('CF�|ĳ','','a',"../cf/main.aspx",'CF�|ĳ');
//var area_Yield = new TPopMenu('Yield�|ĳ','','a',"../Yield/main.aspx",'Yield�|ĳ');
//var area_Productivity = new TPopMenu('PP�|ĳ','','a',"../Productivity/main.aspx",'PP�|ĳ');
//var area_general = new TPopMenu('�@��|ĳ','','a',"../general/main.aspx",'�@��|ĳ');





var pmFileSharing = new TPopMenu('�\��d��','5','','','�\��d��');


var pmIcon00 = new TPopMenu('�d��Stock�O��','','f',"targetWindow('stock_list.aspx','mainiframe')",'�d��Stock�O��');
//var pmFav00 = new TPopMenu('Favorites','../img/favorites.gif','','','favorites'); 
//var pmHist00 = new TPopMenu('History','../img/history.gif','','','History');
//var pmHome00 = new TPopMenu('Home','../img/home.gif','','','Home');
//var pmSep00 = new TPopMenu('-','','','','');
//var pmRef00 = new TPopMenu('Refresh','../img/refresh.gif','','','Refresh');
//var pmStop00 = new TPopMenu('Stop','../img/stop.gif','','','Stop');

var pmOpen00 = new TPopMenu('Strong_up�O��','','f',"targetWindow('Stock_strong_volume1.aspx','mainiframe')",'Strong_up�O��');
//var pmSame00 = new TPopMenu('in same window','','a','index.html','Open page in same window');
//var pmDiv00 = new TPopMenu('in new window','','f',"targetWindow('index.html','mainiframe')",'Open page in new window');
//var pmL00 = new TPopMenu('Long popup menu','','','','Popup menu demo');
var pmOpen01 = new TPopMenu('Stock_alarm_mail','','f',"targetWindow('modify_get_html_data.aspx','mainiframe')",'Strong_up�O��');
var pmOpen02 = new TPopMenu('�@���ݤ���','','f',"newWindow('http://vsoscar.no-ip.org/stock/stock_ref/stock_id.php','mainiframe')",'�@���ݤ���');
var pmOpen03 = new TPopMenu('EMS','','f',"targetWindow('EMS/EMS_add.aspx','mainiframe')",'EMS');
var pmOpen04 = new TPopMenu('Virtual_Trade','','f',"targetWindow('virtual_asset.aspx','mainiframe')",'Virtual_Trade');

var website_list = new TPopMenu('�����s��','','','','�����s��');

var website_list01 = new TPopMenu('�x�ѽL��','','f',"newWindow('http://tw.stock.yahoo.com/news_list/url/d/e/N2.html','mainiframe')",'�x�ѽL��');
var website_list02 = new TPopMenu('�L�դ��R','','f',"newWindow('http://tw.stock.yahoo.com/report_list/url/d/e/R1.html','mainiframe')",'�L�դ��R');
var website_list03 = new TPopMenu('��s���i','','f',"newWindow('http://tw.stock.yahoo.com/report_index.html','mainiframe')",'��s���i');
var website_list04 = new TPopMenu('�ӪѰʺA','','f',"newWindow('http://tw.stock.yahoo.com/news_list/url/d/e/N3.html','mainiframe')",'�ӪѰʺA');
var website_list05 = new TPopMenu('���ӱ���','','f',"newWindow('http://money.udn.com/report/article_ord.jsp?f_ORDER_BY=D','mainiframe')",'���ӱ���');
var website_list06 = new TPopMenu('�k�NGroup','','f',"newWindow('http://www.wretch.cc/blog/phigroup','mainiframe')",'�k�NGroup');
var website_list08 = new TPopMenu('�k�NGroup_�d�ܼ�','','f',"newWindow('http://www.wretch.cc/blog/phigroup/16426374','mainiframe')",'�k�NGroup_�d�ܼ�');

var website_list07 = new TPopMenu('�i��������','','f',"newWindow('http://www.wretch.cc/blog/chinhowo/27483931','mainiframe')",'�i��������');
var website_list09 = new TPopMenu('���a���','','f',"newWindow('http://sie.com.tw/','mainiframe')",'���a���');
var website_list10 = new TPopMenu('3��D�O�R��W','','f',"newWindow('http://jsjustweb.jihsun.com.tw/z/zk/zk1/zkparse_460_3.asp.htm')",'3��D�O�R��W');




//var E_Meeting_function_Query = new TPopMenu('�ɮ׷j�M','','f',"targetWindow('e_meeting_query.aspx','mainiframe')",'E-Meeting �W�Ƿj�M');
//var E_Meeting_function_upload= new TPopMenu('�ɮפW��','','f',"targetWindow('e_meeting_upload.aspx','mainiframe')",'E-Meeting �ɮפW��');


//var pmDocument_List = new TPopMenu('�оǤ��','','f',"targetWindow('teaching_document.aspx','mainiframe')",'�оǤ��');


//var pmDocument = new TPopMenu('�оǬ�����T','','',"targetWindow('mail_meeting.aspx','mainiframe')",'�оǬ�����T');
//var pmDocument_List = new TPopMenu('�оǤ��','','f',"targetWindow('sop.doc','mainiframe')",'�оǤ��');

//var login_history = new TPopMenu('�έp','','','','�έp');
//var login_history_web = new TPopMenu('�n�J�έp','','f',"targetWindow('statistic_login.aspx','mainiframe')",'�n�J�έp');
//var Meeting_type_statistic = new TPopMenu('Meeting_Type�έp','','f',"targetWindow('statistic_meeting_type.aspx','mainiframe')",'�n�J�έp');




//var pmDocument_NetMeetingConfig = new TPopMenu('NetMeeting�w�˳]�w'Add,'','f',"targetWindow('/Distance/Document_Link/NETMEETING_INST/netmeet_config.htm','mainiframe')",'NetMeeting�]�w');

//var pmTrustView = new TPopMenu('TrustView System','','f',"newWindow('http://inlcndrm01/innolux/')",'�[�K����');
//var pmDistance_Intro = new TPopMenu('���Z�оǥ��x����','','f',"targetWindow('/Distance/Document_Link/Distance_Intro/Distance_Introduction.htm','mainiframe')",'���Z�оǥ��x����');


//var pmInnoWiki = new TPopMenu('InnoWiki�s�Цʬ�','','','','InnoWiki�s�Цʬ�');

//var pmInnoWiki_Main = new TPopMenu('InnoWiki����','','f',"newWindow('InnoWiki.aspx','mainiframe')",'InnoWiki����');
//var pmInnoWiki_Intro = new TPopMenu('InnoWiki�t�Τ���','','f',"newWindow('InnoWiki_Intro.aspx','mainiframe')",'InnoWiki�t�Τ���');

//var pmAbout00 = new TPopMenu('About','','f',"alert('Implement by Bunny')",'About this program');
//var pmAbout00 = new TPopMenu('About','','f',"alert('Implement by Bunny')",'About this program');


//�s�W�n�J���O****�w�g ��X mark ��  oscar 2009/05/21 ******//
//mm0.Add(pmselect_area);
//pmselect_area.Add(area_ary);
//pmselect_area.Add(area_cell);
//pmselect_area.Add(area_cf);
//pmselect_area.Add(area_Yield);
//pmselect_area.Add(area_Productivity);
//pmselect_area.Add(area_general);




//Meeting System Function (Meeting System)
mm0.Add(pmFileSharing);
pmFileSharing.Add(pmIcon00);
pmFileSharing.Add(pmOpen00);
pmFileSharing.Add(pmOpen01);
pmFileSharing.Add(pmOpen02);
pmFileSharing.Add(pmOpen03);
pmFileSharing.Add(pmOpen04);





//pmFileSharing.Add(pmDocument_List);




//E-Meeting Combine(E-Meeting Combine)
mm0.Add(website_list);
website_list.Add(website_list01);
website_list.Add(website_list02);
website_list.Add(website_list03);
website_list.Add(website_list04);
website_list.Add(website_list05);
website_list.Add(website_list06);
website_list.Add(website_list07);
website_list.Add(website_list08);
website_list.Add(website_list09);
website_list.Add(website_list10);








//E_Meeting_function_list.Add(E_Meeting_function_Query);
//E_Meeting_function_list.Add(E_Meeting_function_upload);

//mm0.Add(login_history);
//login_history.Add(login_history_web);
//login_history.Add(Meeting_type_statistic);







//�|ĳ�O���оǤ��(pmDocument)
//mm0.Add(pmDocument);
//pmDocument.Add(pmDocument_List);
//pmDocument_List.Add(pmDocument_NetMeetingConfig);


//pmDocument_List.Add(pmDistance_Intro);
//pmDocument.Add(pmDocument_WebSite);

//pmIcon00.Add(pmFav00);
//pmIcon00.Add(pmHist00);
//pmIcon00.Add(pmHome00);
//pmIcon00.Add(pmSep00);
//pmIcon00.Add(pmRef00);
//pmIcon00.Add(pmStop00);
//pmDemo00.Add(pmSep00);

//pmOpen00.Add(pmSame00);
//pmOpen00.Add(pmDiv00);
//pmDemo00.Add(pmL00);

//InnoWiki�s�Цʬ�
//mm0.Add(pmInnoWiki);
//pmInnoWiki.Add(pmInnoWiki_Main);
//pmInnoWiki.Add(pmInnoWiki_Intro);
//pmAlert00.Add(pmAbout00);
//mm0.Add(pmGoToMainPage);

//pmHelp00.Add(pmAbout00);
//end of xp style      