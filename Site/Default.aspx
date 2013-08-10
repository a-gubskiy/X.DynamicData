<%@ Page Language="C#" MasterPageFile="~/Site.master" CodeBehind="Default.aspx.cs" Inherits="Site._Default" culture="auto" %>

<asp:Content ID="naib_content" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h3> <asp:Literal runat="server" Text="<%$ Resources:Global, WelcomeMessage %>"></asp:Literal></h3>
    <h4 runat="server" ClientIDMode="Static" id="login_title"><%#Resources.Global.WelcomeMessage %></h4>
    <div class="sidebar-nav startup">
        <ul id="startup_menu" class="nav nav-list" runat="server" clientidmode="Static">
        </ul>
    </div>
</asp:Content>