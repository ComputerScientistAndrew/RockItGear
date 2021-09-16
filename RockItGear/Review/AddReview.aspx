<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddReview.aspx.cs" Inherits="RockItGear.AddReview" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">        
    <table>
        <tr>
            <td>
                <table class="columns">
                    <tr>
                        <td>
            <asp:FormView ID="productInfo" runat="server" ItemType="RockItGear.Models.Product" SelectMethod ="GetProduct" RenderOuterTable="false">
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
                        <b>Description:</b><br /><%#:Item.Description %>
                        <br />
                        <span><b>Price:</b>&nbsp;<%#: String.Format("{0:c}", Item.UnitPrice) %></span>
                        <br />
                        <span><b>Product Number:</b>&nbsp;<%#:Item.ProductID %></span>
                        <br />
                        <br /> 
                    </td>
                </tr>
            </table>
        </ItemTemplate>
            </asp:FormView>
        </td>
                        <td>
                            <div class="ContentHead">Create Review - <asp:Label ID="ProductName" runat="server" Text="Label"></asp:Label></div>
    <div style="padding: 20px; border-style: solid; border-width: 1px;">
        <span class="NormalBold">Name</span><br />
        <asp:TextBox ID="Name" runat="server" Width="400px"></asp:TextBox><br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="&quot;Name&quot; Must not be left blank." ControlToValidate="Name" CssClass="validationError"></asp:RequiredFieldValidator><br />        
        <span class="NormalBold">Rating</span><br />
        <asp:Rating ID="Rating1" runat="server"
            CurrentRating="0"
            StarCssClass="StarCss"
            FilledStarCssClass="FilledStarCss"
            EmptyStarCssClass="EmptyStarCss"
            WaitingStarCssClass="WaitingStarCss"
            AutoPostBack="true"
            >   
        </asp:Rating>
        <br />
        <span class="NormalBold">Comments</span><br />        
        <asp:TextBox ID="UserComment" runat="server" Height="300" Width="500" TextMode="MultiLine"></asp:TextBox>        
        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Please enter your comments." ControlToValidate="UserComment" CssClass="validationError"></asp:CustomValidator><br />
        <asp:ImageButton ID="ReviewAddButton" runat="server" ImageUrl="/Images/submitbutton.jpg" OnClick="ReviewAddButton_Click" />        
        <label id="ratingStar" runat="server" Text="stars"></label>
    </div>
                        </td>
                        
                    </tr>
                </table>
            
        </td>
        </tr>
    </table>
</asp:Content>
