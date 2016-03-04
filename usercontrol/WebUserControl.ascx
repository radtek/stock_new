<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl.ascx.cs" Inherits="usercontrol_WebUserControl" %>



<UserControl x:Class="usercontrol_WebUserControl.Page"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" 
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml" 
    Width="400" Height="300">
    <Grid x:Name="LayoutRoot" Background="White">
        <StackPanel Height="30" Orientation="Horizontal" 
                    HorizontalAlignment="Left" VerticalAlignment="Top" 
                    Margin="10" >
            <Button x:Name="buttonStart" Content="Start" Click="buttonStart_Click"
                    Width="200" Height="30"/>
            <Button x:Name="buttonCancel" Content="Cancel" Click="buttonCancel_Click"
                    Width="200" Height="30"/>
        </StackPanel>
        <StackPanel Margin="10,50,0,0" Orientation="Horizontal">
            <TextBlock Text="Progress: "/>
            <TextBlock x:Name="tbProgress"/>
        </StackPanel>
    </Grid>
</UserControl>




