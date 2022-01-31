<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SimpleCart._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <style>
        .imageZoom:hover {
            -ms-transform: scale(3.5); /* IE 9 */
            -webkit-transform: scale(3.5); /* Safari 3-8 */
            transform: scale(3.5);
        }
    </style>
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
 <%--           <asp:ListView ID="products" runat="server">
                <ItemTemplate>
                    <div>
                        <a>
                            <img src="<%# Eval("ImageUrl") %>"/><br />
                            <%# Eval("Title") %> $<%# Eval("Price") %><br />
                            <button>Add to Cart</button>
                        </a>
                    </div>
                </ItemTemplate>
            </asp:ListView>--%>
               <asp:DataList ID="products" CssClass="table" runat="server" BorderColor="Black" CellPadding="4"
                CellSpacing="100"
                DataKeyField="ID" RepeatColumns="4"
                RepeatDirection="Horizontal" Font-Bold="False" Font-Italic="False"
                Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False"
                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                <ItemTemplate>
                    <asp:Label ID="LblID" Visible="false" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                    <asp:Image ID="Image1" runat="server" CssClass="imageZoom" Height="100px" ImageUrl='<%# "~/upload/" + ((Eval("ImageUrl")).ToString() != "" ? (Eval("ImageUrl")).ToString() :"default1.jpg") %>' />
                    <br />
                    <asp:Label ID="ItemNameLabel" runat="server" Text='<%# Eval("Title") %>' />
                    <br />
                    $
                    <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Price") %>' />
                    <br />
                    <asp:LinkButton Style="color: #fff;"
                        runat="server" ID="ViewDetail"
                        CausesValidation="false" CssClass="btn btn-success btn-sm">View Detail</asp:LinkButton>
                    <asp:LinkButton Style="border: 1px solid #f57224; background: #f57224; color: #fff;"
                        runat="server" ID="lnkAddToCart"
                        CausesValidation="false" CssClass="btn btn-success btn-sm">Add To Cart</asp:LinkButton>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>

</asp:Content>
