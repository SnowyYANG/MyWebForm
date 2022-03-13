<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_new.aspx.cs" Inherits="SimpleCart.Login_new" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Store</title>
        <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.4.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
                <div class="container">
            <div class="_divLogin" style="margin-top: 100px;border:2px solid black;background-color:#9de1da;">
                 <div class="form-group row">
                    <div class="col-sm-2"></div>
                     <div class="col-sm-2"></div>
                    <div class="col-sm-4 text-center">
                        <h3>Welcome to Login</h3>
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
                </div>
                <div class="form-group row">
                    <div class="col-sm-2"></div>
                    <div class="col-sm-2">
                        <label>Password:</label>
                    </div>
                    <div class="col-sm-4">
                        <asp:TextBox runat="server" ID="TxtPassword" placeholder="Password here..." TextMode="Password" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class="col-sm-4"></div>
                    <div class="col-sm-4 text-center">
                        <asp:Button runat="server" ID="btnLogin" Text="Login" CssClass="btn btn-success" OnClick="btnLogin_Click" />
                       
                    </div>
                     <div class="col-sm-4">
                         <asp:Label runat="server" ID="lblMessage" Style="color: red; font-style: italic"></asp:Label>
                         
                         </div>
                    
                </div>
                <div class="form-group row">
                    <div class="col-sm-4"></div>
                    <div class="col-sm-6"><label>If you have not created an account click on </label> <asp:LinkButton ID="lnkSignUp" runat="server" OnClick="lnkSignUp_Click">Sign Up</asp:LinkButton></div>
              
                </div>
            </div>
        </div>
    </form>
</body>
</html>
