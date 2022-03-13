<%@ Page Title="" Language="C#" MasterPageFile="~/Site_New.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="SimpleCart.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .imageZoom:hover {
            -ms-transform: scale(3.5); /* IE 9 */
            -webkit-transform: scale(3.5); /* Safari 3-8 */
            transform: scale(3.5);
        }
    </style>
    <div class="modal fade bd-example-modal-xl" id="myImageModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-xl" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="myImageQuestionTitle">Detail Information</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <!-- Modal Content (The Image) -->
                    <div class="form-group row">
                        <div class="col-sm-2"><label>Name:</label></div>
                        <div class="col-sm-10">
                            <asp:Label runat="server" ID="lblName"></asp:Label></div></div>
                    <div class="form-group row">
                       <div class="col-sm-2"><label>Price:</label></div>
                        <div class="col-sm-10">
                            <asp:Label runat="server" ID="lblPrice"></asp:Label></div></div>
                    <div class="form-group row">
                        <div class="col-sm-2"><label>Description:</label></div>
                        <div class="col-sm-10">
                            <asp:Label runat="server" ID="lblDescription"></asp:Label></div></div>
                    <div class="form-group row">
                         <div class="col-sm-2"><label>Image</label></div>
                        <div class="col-sm-10 text-center">
                            <asp:Image ID="ImageModal" runat="server" Height="350px" Style="max-width:400px" /></div>
                    </div>






                    <%--<div id="caption"></div>--%>
                </div>
            </div>
        </div>
        <%--<!-- The Close Button -->
                <span class="close">&times;</span>

                <!-- Modal Content (The Image) -->
                <img src="" class="modal-content" id="img01Modal">

                <!-- Modal Caption (Image Text) -->
                <div id="caption"></div>--%>
    </div>
    <div class="form-group row">
        <div class="col-sm-2">
            <label>Category Name:</label>
        </div>
        <div class="col-sm-4">
            <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true" CssClass="form-control form-group-sm" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="col-sm-2"></div>
    </div>
    <br />
    <div class="form-group row">
        <div class="col-sm-2"></div>
        <div class="col-sm-10">
            <asp:DataList ID="DLProduct" CssClass="table" runat="server" BorderColor="Black" CellPadding="4"
                CellSpacing="100"
                DataKeyField="ID" RepeatColumns="4"
                RepeatDirection="Horizontal" Font-Bold="False" Font-Italic="False"
                Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False"
                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                <%--OnSelectedIndexChanged="DataList1_SelectedIndexChanged"--%>
                <ItemTemplate>
                    <asp:Label ID="LblID" Visible="false" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                    <asp:Image ID="Image1" runat="server" CssClass="imageZoom" Height="100px" ImageUrl='<%# "~/ProductImages/" + ((Eval("Photo")).ToString() != "" ? (Eval("Photo")).ToString() :"default1.jpg") %>' />
                    <br />
                    <asp:Label ID="ItemNameLabel" runat="server" Text='<%# Eval("ProductName") %>' />
                    <br />
                    $
                    <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Prices") %>' />
                    <%--   <br />
                    <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Description") %>' />--%>
                    <%--       $<br />
                <asp:Label ID="AvailablityLabel" runat="server" Text='<%# Eval("Photo") %>' />--%>
                    <%--  <br />
                <div class="rating">
                    <span><i class="fas fa-star"></i></span>
                    <span><i class="fas fa-star"></i></span>
                    <span><i class="far fa-star"></i></span>
                </div>--%>
                    <br />
                    <asp:LinkButton Style="color: #fff;"
                        runat="server" ID="ViewDetail"
                        CausesValidation="false" CssClass="btn btn-success btn-sm" OnClick="ViewDetail_Click">View Detail</asp:LinkButton>
                    <%if (objLogin != null)
                        {%>
                    <%if (objLogin.LoginUserId > 0 && objLogin.Role == "User")
                        {%>
                    <asp:LinkButton Style="border: 1px solid #f57224; background: #f57224; color: #fff;"
                        runat="server" ID="lnkAddToCart"
                        CausesValidation="false" CssClass="btn btn-success btn-sm" OnClick="lnkAddToCart_Click">Add To Cart</asp:LinkButton>
                    <% } %>

                    <% }%>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    <script>
        $("#productId").addClass("active");
    </script>
</asp:Content>
