<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Site.ServerInformation" Codebehind="ServerInformation.aspx.cs" %>

<asp:Content ID="main_content" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1><%=Resources.Global.ServerInformationPageTite %></h1>
    <section id="server_information" runat="server" clientidmode="Static"></section>
</asp:Content>

