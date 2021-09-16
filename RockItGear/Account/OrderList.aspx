<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="RockItGear.Account.OrderList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ContentHead"><b>Order History</b></div><br />
    <asp:GridView ID="Grid_OrderList" runat="server" AllowPaging="True" 
                  GridLines="None" CellPadding="4" Width="100%" AutoGenerateColumns="False" 
                  ItemType="RockItGear.Models.Order" SelectMethod="Grid_OrderList_GetData">
        <Columns>
            <asp:BoundField DataField="OrderId" HeaderText="Order ID" ReadOnly="true" SortExpression="OrderId" />
            <asp:BoundField DataField="Username" HeaderText="Email" SortExpression="UserName" />
            <asp:BoundField DataField="OrderDate" HeaderText="Order Date" SortExpression="OrderDate" />
            <asp:TemplateField HeaderText="Shipped">
                <ItemTemplate>              
                    <asp:Label ID="Ship" runat="server" Text='<%# Item.HasBeenShipped ? "Yes" : "No" %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>            
            <asp:HyperLinkField HeaderText="Show Details" Text="Show Details" DataNavigateUrlFields="OrderId" 
                                DataNavigateUrlFormatString="~/Account/OrderDetails.aspx?OrderId={0}" />
        </Columns>
        <emptydatatemplate>                                       
            No orders found.                 
        </emptydatatemplate> 
    </asp:GridView>
</asp:Content>
