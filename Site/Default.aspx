<%@ Page Language="C#" MasterPageFile="~/Site.master" CodeBehind="Default.aspx.cs" Inherits="Site._Default" Culture="auto" %>

<asp:Content ID="naib_content" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h3><asp:Literal runat="server" Text="<%$ Resources:Global, WelcomeMessage %>"></asp:Literal></h3>

    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title"><i class="glyphicon glyphicon-credit-card"></i><%=Resources.Global.Status %></h3>
        </div>
        <div class="panel-body" runat="server" clientidmode="Static" id="login_title">
            Panel content
        </div>
    </div>


    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title"><i class="glyphicon glyphicon-credit-card"></i><%=Resources.Global.TableLinks %></h3>
        </div>
        <div class="panel-body" id="table_links" runat="server" clientidmode="Static">
            Panel content
        </div>
    </div>

    <div class="panel panel-default" id="plugin_widget" runat="server">
        <div class="panel-heading">
            <h3 class="panel-title"><i class="glyphicon glyphicon-credit-card"></i><%=Resources.Global.CustomLinks %></h3>
        </div>
        <div class="panel-body" id="custom_links" runat="server" clientidmode="Static">
            Panel content
        </div>
    </div>

    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title"><i class="glyphicon glyphicon-credit-card"></i><%=Resources.Global.SystemLinks %></h3>
        </div>
        <div class="panel-body" id="system_links" runat="server" clientidmode="Static">
            Panel content
        </div>
    </div>


</asp:Content>
