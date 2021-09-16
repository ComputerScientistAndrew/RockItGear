<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="RockItGear.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        label {
            font-size: 16px;
        }
    </style>
    <script>               
        function addSize() {

            if ($('.sizeChart').is(":visible")) {
                
                $('#addItem').attr("href", $('#addItem').attr('href') + $('.sizeChart').val());

            }
            else {
                $('#addItem').attr("href", $('#addItem').attr('href') + 'NA');
            }
            
        }
        
    </script>
    <asp:FormView ID="productDetail" runat="server" ItemType="RockItGear.Models.Product" SelectMethod ="GetProduct" OnDataBound="productDetail_DataBound" RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1><%#:Item.ProductName %></h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <img src="/Catalog/Images/<%#:Item.ImagePath %>" style="border:solid; height:300px" alt="<%#:Item.ProductName %>"/>
                    </td>
                    <td>&nbsp;</td>  
                    <td style="vertical-align: top; text-align:left; font-size: 16px">
                        <asp:Image ID="Average_Rating" ImageUrl="<%#RockItGear.Logic.RatingFunctions.GetRatingAverage(Item.ProductID)%>" runat="server"/>
                        <label style="color: dimgrey; font-size: 12px; font-weight: bold"><%#RockItGear.Logic.RatingFunctions.GetRatingCount(Item.ProductID)%></label><br />
                        <b>Description:</b><br /><%#:Item.Description %><br /><span><b>Price:</b>&nbsp;<%#: String.Format("{0:c}", Item.UnitPrice) %></span><br /><span><b>Product Number:</b>&nbsp;<%#:Item.ProductID %></span><br />
                        <div class='size-chart' runat="server" id="sizeChart" visible="<%# Item.CategoryID == 1%>">
                            <label for="sizes">Size:</label>
                            <select class="sizeChart" id="sizes">
                                <option value="6">6</option>
                                <option value="7">7</option>
                                <option value="8">8</option>
                                <option value="9">9</option>
                                <option value="10">10</option>
                                <option value="11">11</option>
                                <option value="12">12</option>
                            </select>
                        </div>
                        <div class='size-chart' runat="server" id="sizeChart2" visible="<%# Item.CategoryID == 2%>">
                            <label for="sizes2">Size:</label>
                            <select class="sizeChart" id="sizes2">
                                <option value="S">S</option>
                                <option value="M">M</option>
                                <option value="L">L</option>
                                <option value="XL">XL</option>                                
                            </select>
                        </div>
                        <a id="addItem" href="/AddToCart.aspx?productID=<%#:Item.ProductID %>&size=" onclick="addSize()">               
                                        <span class="ProductListItem">
                                            <b>Add To Cart<b>
                                        </span>           
                                    </a>                       
                        <br />
                        <div class="SubContentHead">Reviews</div>                        
                         
                        <asp:Label ID="Rating_Count" runat="server"></asp:Label></b>
                        <a id="ReviewList_AddReview" href="/Review/AddReview.aspx?productID=<%#Item.ProductID %>">Write a Review</a>
                        <asp:ListView ID="ListView_Comments" runat="server" ItemType="RockItGear.Models.Review" SelectMethod="GetReviews">
                            <EmptyDataTemplate>
                                <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                                    <tr><td>There are no reviews yet for this product.</td></tr>
                                </table>
                            </EmptyDataTemplate>
                            <ItemTemplate>
                                <tr style="background-color:white; color: #000000;">
                                    <td><asp:Label ID="ReviewIDLabel" runat="server" Text="<%# MaskEmail(Item.CustomerEmail) %>"/></td>
                                    <td><img src= "/Images/reviewrating<%#Item.Rating%>.jpg" /></td>                                    
                                    <td><asp:Label ID="Label1" runat="server" Text="<%# Item.Comment %>" /></td>
                                </tr>
                            </ItemTemplate>
                            <LayoutTemplate>
                                <table runat="server">
                                    <tr runat="server">
                                        <td runat="server">
                                            <table ID="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                                <tr runat="server" style="background-color:#0094ff;color: white;">
                                                    <th runat="server">Customer</th>
                                                    <th runat="server">Rating</th>
                                                    <th runat="server">Comments</th>
                                                </tr>
                                                <tr ID="itemPlaceholder" runat="server"></tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr runat="server">
                                        <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                                            <asp:DataPager ID="DataPager1" runat="server">
                                                <Fields><asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" /></Fields>
                                            </asp:DataPager>
                                        </td>
                                    </tr>
                                </table>
                            </LayoutTemplate>
                        </asp:ListView>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
