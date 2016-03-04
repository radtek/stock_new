Dim FSO,agoDays,modifiedDate,delFolder


agodays = 5
delFolder1 = "D:\Backup_Data\"
'delFolder2 = "D:\Backup_Data\fs1\Tue"


Set FSO = CreateObject("Scripting.FileSystemObject")
modifiedDate = DateAdd("d",-agoDays,Date)


DelFilesInFolder FSO.GetFolder(delFolder1)
'DelFilesInFolder FSO.GetFolder(delFolder2)


Sub DelFilesInFolder(folder)
   Dim file,subFolder
   For Each File In folder.Files
     If((file.DateLastModified <= modifiedDate)) Then
      file.delete
     End IF
   Next         


   For Each subFolder in folder.SubFolders
    DelFilesInFolder subFolder 
   Next
 
End Sub
