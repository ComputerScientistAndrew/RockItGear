<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="RockItGear.ShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        var unsaved = false;
        const formatter = new Intl.NumberFormat('en-US', {
            style: 'currency',
            currency: 'USD',
            minimumFractionDigits: 2
         })
                

        function quantityChange(sel) {
            
            var $item = $(sel).closest('tr');                     
            
            var unitPrice = Number.parseFloat($item.find('.unitPrice').text().substr(1));
            console.log(unitPrice);
            
            var itemTotal = formatter.format(unitPrice * $item.find('.quantity').val())
            $item.find('.itemTotal').text(itemTotal);                     
                            

            var sum = 0;
            
            $('.itemTotal').each(function () {
                sum += Number($(this).text().substr(1).split(',').join(''));
                
            });
            console.log('sum is ' + formatter.format(sum));
            $('.orderTotal').text(formatter.format(sum));
            console.log($('.orderTotal').text());
            unsaved = true;
        }
        function saveChanges() {
            unsaved = false;
        };

        function unloadPage(){ 
            if(unsaved){
                return "You have unsaved changes."; 
            }
        }

        window.onbeforeunload = unloadPage;
</script>

    <div id="ShoppingCartTitle" runat="server" class="ContentHead"><h1>Shopping Cart</h1></div>
    <asp:GridView ID="CartList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
        ItemType="RockItGear.Models.CartItem" SelectMethod="GetShoppingCartItems" 
        CssClass="table table-striped table-bordered" >   
        <Columns>
        <asp:BoundField DataField="ProductID" HeaderText="ID" SortExpression="ProductID" />      
        
        <asp:BoundField DataField="Product.ProductName" HeaderText="Name" /> 
        <asp:TemplateField HeaderText="Size">
            <ItemTemplate>              
                <asp:Label ID="lblid" runat="server" Text="<%# Item.Size %>"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Price (each)">
            <ItemTemplate>
                <asp:Label ID="UnitPrice" CssClass="unitPrice" runat="server" Text='<%#: string.Format("{0:c}", Item.Product.UnitPrice) %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>            
        <asp:TemplateField HeaderText="Quantity">
            <ItemTemplate>
                <asp:DropDownList runat="server" Visible="true" ID="QuantityList" CssClass="quantity" onclick="quantityChange(this)" SelectedValue="<%#Item.Quantity %>">
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="2">2</asp:ListItem>
                    <asp:ListItem Value="3">3</asp:ListItem>
                    <asp:ListItem Value="4">4</asp:ListItem>
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="6">6</asp:ListItem>
                    <asp:ListItem Value="7">7</asp:ListItem>
                    <asp:ListItem Value="8">8</asp:ListItem>
                    <asp:ListItem Value="9">9</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                </asp:DropDownList>   
            </ItemTemplate>    
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Item Total">            
                <ItemTemplate>
                   <asp:Label runat="server" CssClass="itemTotal" Text='<%#: String.Format("{0:c}", ((Convert.ToDouble(Item.Quantity)) *  Convert.ToDouble(Item.Product.UnitPrice)))%>'></asp:Label>  
                </ItemTemplate>        
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Remove Item">            
                <ItemTemplate>
                    <asp:CheckBox id="Remove" runat="server"></asp:CheckBox>
                </ItemTemplate>        
        </asp:TemplateField>
        </Columns>    
    </asp:GridView>
    <div>
        <p></p>
        <strong>
            <asp:Label ID="LabelTotalText" runat="server" Text="Order Total: "></asp:Label>
            <asp:Label ID="lblTotal" CssClass="orderTotal" runat="server" EnableViewState="false"></asp:Label>
        </strong> 
    </div>
    <br />
    <table> 
    <tr>
      <td>
        <asp:Button ID="UpdateBtn" ClientIDMode="Static" CssClass="updateButton" runat="server" Text="Update" OnClientClick="saveChanges()" OnClick="UpdateBtn_Click" />
      </td>
      <td>
        <asp:ImageButton OnClientClick="saveChanges()" ID="CheckoutImageBtn" runat="server" 
                      ImageUrl="https://www.paypal.com/en_US/i/btn/btn_xpressCheckout.gif" 
                      Width="145" AlternateText="Check out with PayPal" 
                      OnClick="CheckoutBtn_Click" 
                      BackColor="Transparent" BorderWidth="0" />
      </td>
    </tr>
    </table>
</asp:Content>
