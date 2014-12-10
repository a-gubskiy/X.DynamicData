<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Site.Login" CodeBehind="Login.aspx.cs" %>

<asp:Content ID="main_content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form-signin">
        <h2 runat="server" id="login_title" class="form-signin-heading">Please sign in</h2>     
        <asp:TextBox ID="t_login" runat="server" CssClass="form-control" placeholder="Login" autofocus></asp:TextBox>      
        <asp:TextBox ID="t_password" runat="server" TextMode="Password" CssClass="form-control" placeholder="Password"></asp:TextBox>
        <asp:Button runat="server" ID="signin" CssClass="btn btn-lg btn-primary btn-block" Text="OK" OnClick="signin_Click"/>
      </div>

</asp:Content>

