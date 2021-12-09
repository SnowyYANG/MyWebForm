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
        <div class="col-md-8">
            <asp:ListView ID="products" runat="server">
                <ItemTemplate>
                    <div>
                        <a>
                            <img src="<%# Eval("ImageUrl") %>"/><br />
                            <%# Eval("Title") %> $<%# Eval("Price") %><br />
                            <button>Add to Cart</button>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>

</asp:Content>
