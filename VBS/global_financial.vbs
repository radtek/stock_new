Dim iURL 
Dim objShell

iURL = "http://localhost:8080/stock_new/epaper/finance_create_pdf.aspx"

set objShell = CreateObject("Shell.Application")
objShell.ShellExecute "chrome.exe", iURL, "", "", 1

