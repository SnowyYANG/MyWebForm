<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="SimpleCart.Admin.AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .switch {
            position: relative;
            display: inline-block;
            width: 60px;
            height: 25px;
        }

            .switch input {
                opacity: 0;
            }


        .slider {
            position: absolute;
            cursor: pointer;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background-color: red;
            -webkit-transition: .4s;
            transition: .4s;
        }

            .slider:before {
                position: absolute;
                content: "";
                height: 20px;
                width: 25px;
                left: 3px;
                bottom: 2px;
                background-color: white;
                -webkit-transition: .4s;
                transition: .4s;
            }

        input:checked + .slider {
            background-color: #05b70a;
        }

        input:focus + .slider {
            box-shadow: 0 0 1px #2196F3;
        }

        input:checked + .slider:before {
            -webkit-transform: translateX(26px);
            -ms-transform: translateX(26px);
            transform: translateX(26px);
        }

        /* Rounded sliders */
        .slider.round {
            border-radius: 11px;
        }

            .slider.round:before {
                border-radius: 50%;
            }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      
    <script src="../Scripts/js/jquery.min.js"></script>
    <script src="../Scripts/js/bootstrap.min.js"></script>
    <div class="form-group row">
        <div class="col-sm-12">
            <div class="modal fade bd-example-modal-xl" id="myProductModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-xl" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">Edit Product information</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="form-group row">
                                <div class="col-sm-3">
                                     <asp:HiddenField runat="server" ID="hfProductId" />
                                    <label>Category:</label>
                                </div>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="ddlUCategory" runat="server" AutoPostBack="true" CssClass="form-control form-group-sm"></asp:DropDownList>
                                </div>
                               
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <label>Product Name:</label>
                                </div>
                                <div class="col-sm-6">
                                    <asp:TextBox runat="server" ID="txtUProduct" ValidationGroup="ModalUpdate" CssClass="form-control form-group-sm" placeholder="Product Name here..."></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="ModalUpdate" ControlToValidate="txtUProduct" runat="server" ErrorMessage="required" ForeColor="red"></asp:RequiredFieldValidator>
                                </div>
                               
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <label>Price:</label>
                                </div>
                                <div class="col-sm-6">
                                    <asp:TextBox runat="server" ID="txtUPrice" ValidationGroup="ModalUpdate" CssClass="form-control form-group-sm" placeholder="Price here..."></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtUPrice" runat="server" ErrorMessage="required" ForeColor="red"></asp:RequiredFieldValidator>
                                </div>
                              
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <label>Description:</label>
                                </div>
                                <div class="col-sm-8">
                                    <asp:TextBox runat="server" TextMode="MultiLine" Rows="5" ValidationGroup="ModalUpdate" ID="txtUDescription" CssClass="form-control form-group-sm" placeholder="Description here..."></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="txtUDescription" runat="server" ErrorMessage="required" ForeColor="red"></asp:RequiredFieldValidator>
                                </div>
                              
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-3">
                                    <label>Picture:</label>
                                </div>
                                <div class="col-sm-6">
                                    <asp:FileUpload ID="productUImageFile" runat="server" />
                                </div>
                               
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-3">
                                </div>
                                <div class="col-sm-6 text-center">
                                    <asp:Button runat="server" Text="Update" ID="btnUpdate" ValidationGroup="ModalUpdate" CssClass="btn btn-info btn-sm" OnClick="btnUpdate_Click"/>
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
            <asp:DropDownList ID="ddlCategoryName" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategoryName_SelectedIndexChanged" CssClass="form-control form-group-sm"></asp:DropDownList>
        </div>
        <div class="col-sm-2"></div>
    </div>
    <div class="form-group row">
        <div class="col-sm-2">
            <label>Product Name:</label>
        </div>
        <div class="col-sm-4">
            <asp:TextBox runat="server" ID="txtProductName" ValidationGroup="VGAdd" CssClass="form-control form-group-sm" placeholder="Product Name here..."></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="VGAdd" ControlToValidate="txtProductName" runat="server" ErrorMessage="required" ForeColor="red"></asp:RequiredFieldValidator>
        </div>
        <div class="col-sm-2"></div>
    </div>
    <div class="form-group row">
        <div class="col-sm-2">
            <label>Price:</label>
        </div>
        <div class="col-sm-4">
            <asp:TextBox runat="server" ID="txtPrice" ValidationGroup="VGAdd" CssClass="form-control form-group-sm" placeholder="Price here..."></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="VGAdd" ControlToValidate="txtPrice" runat="server" ErrorMessage="required" ForeColor="red"></asp:RequiredFieldValidator>
        </div>
        <div class="col-sm-2"></div>
    </div>
    <div class="form-group row">
        <div class="col-sm-2">
            <label>Description:</label>
        </div>
        <div class="col-sm-4">
            <asp:TextBox runat="server" ID="txtDescription" ValidationGroup="VGAdd" TextMode="MultiLine" Rows="3" CssClass="form-control form-group-sm" placeholder="Description here..."></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="VGAdd" ControlToValidate="txtDescription" runat="server" ErrorMessage="required" ForeColor="red"></asp:RequiredFieldValidator>
        </div>
        <div class="col-sm-2"></div>
    </div>
    <div class="form-group row">
        <div class="col-sm-2">
            <label>Picture:</label>
        </div>
        <div class="col-sm-4">
            <asp:FileUpload ID="productImageFile" runat="server" />
        </div>
        <div class="col-sm-2"></div>
    </div>
    <div class="form-group row">
        <div class="col-sm-2">
        </div>
        <div class="col-sm-4 text-center">
            <asp:Button runat="server" Text="Save" ID="btnSave" ValidationGroup="VGAdd" CssClass="btn btn-info btn-sm" OnClick="btnSaveProduct_Click" />
        </div>
        <div class="col-sm-2"></div>
    </div>
    <div class="form-group row">
        <div class="col-sm-12">
            <asp:GridView ID="GridProducts" runat="server" CssClass="table table-sm"
                AutoGenerateColumns="false" HeaderStyle-BackColor="#3381ce" ShowHeaderWhenEmpty="true">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:TemplateField>
                        <HeaderTemplate>#</HeaderTemplate>
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="CategoryID" HeaderText="Category id" />
                    <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                    <asp:BoundField DataField="Prices" HeaderText="Price" />
                    <asp:BoundField DataField="Description" HeaderText="Product Description" />
                    <asp:TemplateField HeaderText="Photo" ItemStyle-Width="50" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Image ImageUrl='<%# "~/ProductImages/" + (Eval("Photo")).ToString() %>' CssClass="imageZoom" runat="server" Height="40" Width="50" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>Is Product Available</HeaderTemplate>
                        <ItemTemplate>
                            <label class="switch">
                                <asp:CheckBox ID="chkAccessTo" runat="server" Checked='<%# Convert.ToBoolean(Eval("IsAvailable")) %>' AutoPostBack="true" OnCheckedChanged="chkAccessTo_CheckedChanged" />
                                <span class="slider round"></span>
                            </label>
                        </ItemTemplate>

                    </asp:TemplateField>
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
                                        CommandArgument='<%# Eval("ID") %>' CausesValidation="false" OnClick="lnkDelete_Click" CssClass="lnkCss1"><i style="color:red" class="fa fa-trash"></i></asp:LinkButton>
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
        $("#liAddProduct").addClass("active");
    </script>
</asp:Content>
