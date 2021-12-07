<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SimpleCart._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Zakka House</h1>
        <p class="lead">A lot of products</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <a href="#"><div>Food</div></a>
            <a href="#"><div>Fashion</div></a>
            <a href="#"><div>Mobile</div></a>
        </div>
        <asp:ListView runat="server" ItemType="SimpleCart.Product" SelectMethod="GetProducts">
            <ItemTemplate>
                <div>
                    <a>
                        <img src="<%#:Item.ImageUrl %>"/><br />
                        <%#:Item.Title %> $<%#:Item.Price %><br />
                        <button>Add to Cart</button>
                    </a>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>

</asp:Content>
