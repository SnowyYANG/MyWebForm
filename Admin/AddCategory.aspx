<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="SimpleCart.Admin.AddCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group row">
        <div class="col-sm-12">
            <div class="modal fade bd-example-modal-xl" id="myModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-xl" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Edit Category</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <label>Category:</label>
                                </div>
                                <div class="col-sm-6">
                                    <asp:TextBox runat="server" ID="txtUCategoryName" CssClass="form-control"></asp:TextBox>
                                </div>

                                <div class="col-sm-2">
                                    <asp:HiddenField runat="server" ID="hfCategoryId" />
                                    <asp:Button runat="server" Text="Update" ID="btnUpdate" OnClick="btnUpdate_Click" CssClass="btn btn-info btn-sm" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="form-group row">
        <div class="col-sm-2">
            <label>Category Name:</label>
        </div>
        <div class="col-sm-4">
            <asp:TextBox runat="server" ID="txtCategory" CssClass="form-control" placeholder="Category here..."></asp:TextBox>
        </div>

        <div class="col-sm-2">
            <asp:Button runat="server" Text="Save" ID="btnSaveCategory" CssClass="btn btn-info btn-sm" OnClick="btnSaveCategory_Click" />
        </div>
    </div>
    <div class="form-group row">
        <div class="col-sm-12">
            <asp:GridView ID="GridCategory" runat="server" CssClass="table table-sm" OnRowDataBound="GridCategory_RowDataBound"
                AutoGenerateColumns="false" HeaderStyle-BackColor="#3381ce" ShowHeaderWhenEmpty="true">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:TemplateField>
                        <HeaderTemplate>#</HeaderTemplate>
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CategoryName" HeaderText="Category Name" />
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:Label ID="lblAction" runat="server" Text="Action"></asp:Label>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <b>
                                <asp:LinkButton runat="server" ID="editLink" CommandArgument='<%# Eval("ID") %>'
                                    CausesValidation="false" CssClass="lnkCss" OnClick="editLink_Click"><i class="fa fa-edit"></i></asp:LinkButton>
                                ||
                                    <asp:LinkButton runat="server" ID="lnkDelete"
                                        OnClientClick="return confirm('Are you sure you want to delete?');"
                                        CommandArgument='<%# Eval("ID") %>' CausesValidation="false" CssClass="lnkCss1" OnClick="lnkDelete_Click"><i style="color:red" class="fa fa-trash"></i></asp:LinkButton>
                            </b>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <div>No records found.</div>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </div>
    <script>
        $("#liAddCategory").addClass("active");
    </script>
    <%--    <script src="../Scripts/script/scripts.js"></script>--%>
</asp:Content>
