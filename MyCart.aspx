<%@ Page Title="" Language="C#" MasterPageFile="~/Site_New.Master" AutoEventWireup="true" CodeBehind="MyCart.aspx.cs" Inherits="SimpleCart.MyCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .table tr td img:hover {
            -ms-transform: scale(2.5); /* IE 9 */
            -webkit-transform: scale(2.5); /* Safari 3-8 */
            transform: scale(2.5);
        }
    </style>
    <div class="form-group row">
        <div class="col-sm-12">
            <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="Your Orders"></asp:Label>&nbsp;&nbsp;
        </div>
    </div>
    <div class="form-group row">
        <div class="col-sm-12">
            <asp:GridView ID="GDCartList" runat="server" CssClass="table table-sm" AutoGenerateColumns="false"
                CellPadding="4" OnRowDataBound="GDCartList_RowDataBound" EmptyDataText="There are no items in the cart" ForeColor="#333333" Style="margin-right: 1px">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Cart Id">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField>
                        <HeaderTemplate>#</HeaderTemplate>
                        <ItemTemplate><%#Container.DataItemIndex + 1 %></ItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:BoundField DataField="sno" HeaderText="S.no">
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>--%>
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Image" ItemStyle-Width="150" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%-- <asp:Image ImageUrl='<%# "../profileImages/" + (Eval("image")).ToString().Substring((Eval("image")).ToString().LastIndexOf("_") + 1) %>' runat="server" Height="25" Width="25" />--%>
                            <asp:Image ImageUrl='<%# "~/ProductImages/" + ((Eval("Photo")).ToString() != "" ? (Eval("Photo")).ToString() :"default1.jpg") %>' CssClass="imageZoom" runat="server" Height="120" Width="130" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Description" HeaderText="Descripiton">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Prices" HeaderText="Price">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <%--    <asp:CommandField ShowDeleteButton="True" />--%>
                    <asp:TemplateField>
                        <HeaderTemplate>Action</HeaderTemplate>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" ID="lnkDelete"
                                OnClientClick="return confirm('Are you sure you want to delete?');"
                                CommandArgument='<%# Eval("ID") %>' CausesValidation="false" OnClick="lnkDelete_Click">Remove</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
            <%--<asp:DataList ID="DLProduct" CssClass="table" runat="server" BorderColor="Black" CellPadding="4"
                CellSpacing="100"
                DataKeyField="ID"
                RepeatDirection="Vertical" Font-Bold="False" Font-Italic="False"
                Font-Overline="False" Font-Strikeout="False" Font-Underline="False">
                <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False"
                    Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                <ItemTemplate>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="LblID" Visible="false" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                <asp:Label ID="ItemNameLabel" runat="server" Text='<%# Eval("ProductName") %>' /></td>
                            <td>$
                                 <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Prices") %>' /></td>
                            <td>
                                <asp:Image ID="Image1" runat="server" CssClass="imageZoom" Height="100px" ImageUrl='<%# "~/ProductImages/" + ((Eval("Photo")).ToString() != "" ? (Eval("Photo")).ToString() :"default1.jpg") %>' /></td>
                        </tr>
                    </table>






                </ItemTemplate>
            </asp:DataList>--%>
        </div>
    </div>
    <script>
        $("#myCartId").addClass("active");
    </script>
</asp:Content>
