Dim iURL 
Dim objShell

iURL = "http://localhost:8080/stock_new/epaper/Excel2PIC/Get_excel_data2pic.aspx"

set objShell = CreateObject("Shell.Application")
objShell.ShellExecute "chrome.exe", iURL, "", "", 1