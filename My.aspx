<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="My.aspx.cs" Inherits="SimpleCart.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="db" Height="50px" Width="125px">
        <Fields>
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:TemplateField HeaderText="Password" SortExpression="Password">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="Password" Text='<%# Bind("Password") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="Password" Text='<%# Bind("Password") %>' ></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='******'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
            <asp:BoundField DataField="Mobile" HeaderText="Mobile" SortExpression="Mobile" />
            <asp:CommandField ButtonType="Button" ShowEditButton="true" />
        </Fields>
    </asp:DetailsView>
    <asp:SqlDataSource ID="db" runat="server" ConnectionString="<%$ ConnectionStrings:db %>" SelectCommand="SELECT TOP 1 [Email], [Password], [Name], [Address], [Mobile] FROM [Users]" UpdateCommand="UPDATE TOP(1) [Users] SET [Email]=@Email, [Password]=@Password, [Name]=@Name, [Address]=@Address, [Mobile]=@Mobile">
        <UpdateParameters>
            <asp:Parameter Name="Email" />
            <asp:Parameter Name="Password" />
            <asp:Parameter Name="Name" />
            <asp:Parameter Name="Address" />
            <asp:Parameter Name="Mobile" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
