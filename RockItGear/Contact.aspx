﻿<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="RockItGear.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Rock It Gear</h3>
    <address>
        One Microsoft Way<br />
        Houston, TX 77082<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@rockitgear.com">Support@rockitgear.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@rockitgear.com">Marketing@rockitgear.com</a>
    </address>
</asp:Content>
