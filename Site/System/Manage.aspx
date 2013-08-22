<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" Inherits="Site.Manage" Codebehind="Manage.aspx.cs" %>

<asp:Content ID="main_content" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1><%=Resources.Global.ManagePageTitle %></h1>
    <%=Resources.Global.ManagePageDescription %>
    
    <br /><br />
    <table class="table control-panel">
        <tr>
            <td><asp:Button CssClass="btn btn-primary" runat="server" ID="restart_site" OnClick="RestartSite" Text="<%$ Resources:Global, RestartWebApplication %>"/></td>
            <td><%=Resources.Global.RestartWebApplicationDescription %></td>
        </tr>
        <tr>
            <td><a href="/System/Logs.aspx" class="btn btn-primary"><%= Resources.Global.LogPageTitle %></a></td>
            <td><%=Resources.Global.SystemLogDescription %></td>
        </tr>
        <tr>
            <td><a href="/System/SystemInformation.aspx" class="btn btn-primary"><%= Resources.Global.SystemInformationPageTite %></a></td>
            <td><%=Resources.Global.SystemInformationDescription %></td>
        </tr>
        <tr>
            <td><a href="/System/ServerInformation.aspx" class="btn btn-primary"><%= Resources.Global.ServerInformationPageTite %></a></td>
            <td><%=Resources.Global.ServerInformationDescription %></td>
        </tr>
    </table>

</asp:Content>


