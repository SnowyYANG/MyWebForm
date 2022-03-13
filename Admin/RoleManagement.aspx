<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="RoleManagement.aspx.cs" Inherits="SimpleCart.Admin.RoleManagement" %>

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
    <div class="form-group row" style="display:none">
        <div class="col-sm-2">
            <asp:Button runat="server" ID="Button1" Text="Add New User" CssClass="btn btn-success" OnClick="Button1_Click" />
        </div>
        <div class="col-sm-6"></div>
    </div>
    <div class="form-group row">
        <div class="col-sm-12">
            <div class="modal fade bd-example-modal-xl" id="userModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-xl" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h4 class="modal-title">User information</h4>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="form-group row">
                                <div class="col-sm-3">
                                     <asp:HiddenField runat="server" ID="hfUserId" />
                                    <label>Category:</label>
                                </div>
                                <div class="col-sm-6">
                                    <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control form-group-sm"></asp:DropDownList>
                                </div>
                               
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-2"></div>
                                <div class="col-sm-2">
                                    <label>Name:</label>
                                </div>

                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="TxtName" placeholder="Name here..." CssClass="form-control"></asp:TextBox>

                                </div>
                                <div class="col-sm-2">
                                    <asp:RequiredFieldValidator ControlToValidate="TxtName" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-2"></div>
                                <div class="col-sm-2">
                                    <label>Email:</label>
                                </div>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="TxtEmail" placeholder="Email here..." CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-2">
                                    <asp:RequiredFieldValidator ControlToValidate="TxtEmail" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-2"></div>
                                <div class="col-sm-2">
                                    <label>Password:</label>
                                </div>
                                <div class="col-sm-4">
                                    <asp:TextBox runat="server" ID="TxtPassword" placeholder="Password here..." CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-2">
                                    <asp:RequiredFieldValidator ControlToValidate="TxtPassword" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-2"></div>
                                <div class="col-sm-2">
                                    <label>Gender:</label>
                                </div>
                                <div class="col-sm-1"></div>
                                <div class="col-sm-3">
                                    <asp:RadioButtonList ID="RBGender" CssClass="radio" runat="server">
                                        <asp:ListItem Value="Male" Selected="True">Male</asp:ListItem>
                                        <asp:ListItem Value="Female">Female</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>

                            <div class="form-group row">
                                <div class="col-sm-2"></div>
                                <div class="col-sm-2">
                                    <label>Address:</label>
                                </div>
                                <div class="col-sm-6">
                                    <asp:TextBox runat="server" ID="TxtAddress" TextMode="MultiLine" Rows="3" placeholder="Address here..." CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-sm-2">
                                    <asp:RequiredFieldValidator ControlToValidate="TxtAddress" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Required" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group row">
                                <div class="col-sm-2"></div>
                                <div class="col-sm-2"></div>
                                <div class="col-sm-2">
                                    <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-success" />
                                </div>
                                <div class="col-sm-6"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <div class="form-group row">
        <div class="col-sm-12">
            <asp:GridView ID="GridAllUsers" runat="server" CssClass="table table-sm" OnRowDataBound="GridAllUsers_RowDataBound"
                AutoGenerateColumns="false" HeaderStyle-BackColor="#3381ce" ShowHeaderWhenEmpty="true">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:TemplateField>
                        <HeaderTemplate>#</HeaderTemplate>
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" />
                    <asp:BoundField DataField="RoleName" HeaderText="Role" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Password" HeaderText="Password" />

                    <asp:TemplateField>
                        <HeaderTemplate>Is Active</HeaderTemplate>
                        <ItemTemplate>
                            <label class="switch">
                                <asp:CheckBox ID="chkAccessTo" runat="server" Checked='<%# Convert.ToBoolean(Eval("IsActive")) %>' AutoPostBack="true" OnCheckedChanged="chkAccessTo_CheckedChanged" />
                                <span class="slider round"></span>
                            </label>
                        </ItemTemplate>

                    </asp:TemplateField>
                    <asp:TemplateField Visible="false">
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
                                        CommandArgument='<%# Eval("ID") %>' CausesValidation="false" CssClass="lnkCss1"><i style="color:red" class="fa fa-trash"></i></asp:LinkButton>
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
        $("#liRoleManagement").addClass("active");
    </script>
</asp:Content>
