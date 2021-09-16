<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="RockItGear.Account.OrderDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:FormView runat="server" CellPadding="4" ItemType="RockItGear.Models.Order" SelectMethod="GetOrder" Width="250px">
        <ItemTemplate>
          Order ID : <%# Item.OrderId %><br />
          Customer Email : <%# Item.Username %><br />
          Order Date : <%# Item.OrderDate %><br />
          Shipped : <%# Item.HasBeenShipped ? "Yes" : "No" %><br />
        </ItemTemplate>
    </asp:FormView>

    <asp:GridView ID="GridView_OrderDetails" runat="server" AutoGenerateColumns="false" CellPadding="4"  ViewStateMode="Disabled" ItemType="RockItGear.Models.OrderDetail" SelectMethod="GetOrderDetail">
        <RowStyle HorizontalAlign="Center" />
        <Columns>
            <asp:BoundField DataField="ProductId" HeaderText="Product ID" ReadOnly="true" SortExpression="ProductId" />
            <asp:TemplateField>                
                <ItemTemplate>
                    <asp:Image runat="server" href='<%#"~/ProductDetails.aspx?productID=" + Item.ProductId.ToString() %>' ImageUrl='<%#GetImage(Item.ProductId)%>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>Product Name</HeaderTemplate>
                <ItemTemplate>
                    <asp:HyperLink runat="server" NavigateUrl='<%#"~/ProductDetails.aspx?productID=" + Item.ProductId.ToString() %>' Text="<%#GetProductName(Item.ProductId) %>"></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
                       
            <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" ReadOnly="True" 
                     SortExpression="UnitPrice" DataFormatString="{0:c}" />            
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" ReadOnly="True" 
                     SortExpression="Quantity" />
            <asp:TemplateField>
                <HeaderTemplate>Item Total</HeaderTemplate>
                <ItemTemplate>
                    <%# string.Format("{0:c}", (Convert.ToDouble(Item.Quantity) * Convert.ToDouble(Item.UnitPrice))) %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
       
</asp:Content>
