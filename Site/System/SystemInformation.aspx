<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Site.SystemInformation" Codebehind="SystemInformation.aspx.cs" %>

<asp:Content ID="main_content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1><%=Resources.Global.SystemInformationPageTite %></h1>
    <section id="information" runat="server" clientidmode="Static"></section>
</asp:Content>
