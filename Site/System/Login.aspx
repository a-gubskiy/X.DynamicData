<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Site.Login" CodeBehind="Login.aspx.cs" %>

<asp:Content ID="main_content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Login ID="login_control" runat="server" CssClass="login" OnAuthenticate="LoginControlAuthenticate" DisplayRememberMe="False" TitleTextStyle-CssClass="login-title">
        <LoginButtonStyle CssClass="btn" />
    </asp:Login>


</asp:Content>
