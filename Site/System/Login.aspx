<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Site.Login" CodeBehind="Login.aspx.cs" %>

<asp:Content ID="main_content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Login ID="login_control" RenderOuterTable="False" runat="server" OnAuthenticate="LoginControlAuthenticate" DisplayRememberMe="False" TitleTextStyle-CssClass="login-title">
        <LoginButtonStyle CssClass="btn btn-default" />
    </asp:Login>

</asp:Content>
