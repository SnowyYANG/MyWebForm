<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="SimpleCart.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Shopping Application</title>

    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">

        <div class="container">
            <div class="_divLogin" style="margin-top: 100px; border: 2px solid black; background-color: #9de1da;">
                <div class="form-group row">
                    <div class="col-sm-2"></div>
                    <div class="col-sm-2"></div>
                    <div class="col-sm-4 text-center">
                        <h3>Sign Up</h3>
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
                        <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-success" OnClick="btnSave_Click" />
                    </div>
                     <div class="col-sm-6"> <label>If you have already created account, than please click on </label>
                         <asp:LinkButton ID="lnkSignIn" runat="server" CausesValidation="false" OnClick="lnkSignIn_Click">Sign in</asp:LinkButton></div>
                </div>

            </div>
        </div>

    </form>
</body>
</html>
