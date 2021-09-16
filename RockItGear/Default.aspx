<%@ Page Title="Welcome" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RockItGear._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <style type="text/css">
            body { background: url(./Images/background.jpg); background-repeat: no-repeat;}
            h1, h2 {color: white; font-weight: bold; font-size: 50px}
            #TitleContent, #CategoryMenu {visibility: hidden;}            
        </style>
        <h1><%: Title %>.</h1>
        <h2>LIVE.CLIMB.REPEAT.</h2>
        <p class="lead">We're all about high quality climbing gear.  You can order any of our gear today.  Each listing will give you detailed information to help you choose the right one for you!</p>
        <asp:label ID="LogoutMessage" CssClass="lead" runat="server" Visible="false">You've been logged out!</asp:label>
</asp:Content>
