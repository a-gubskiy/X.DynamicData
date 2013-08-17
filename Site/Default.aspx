<%@ Page Language="C#" MasterPageFile="~/Site.master" CodeBehind="Default.aspx.cs" Inherits="Site._Default" Culture="auto" %>

<asp:Content ID="naib_content" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h3>
        <asp:Literal runat="server" Text="<%$ Resources:Global, WelcomeMessage %>"></asp:Literal></h3>


    <div class="widget">
        <div class="widget-title">
            <%=Resources.Global.Status %>
        </div>
        <div class="widget-body">
            <div runat="server" clientidmode="Static" id="login_title"></div>
        </div>
    </div>


    <div class="widget">
        <div class="widget-title">
            <%=Resources.Global.TableLinks %>
        </div>
        <div class="widget-body" id="table_links" runat="server" clientidmode="Static">
        </div>
    </div>

    <div class="widget" id="plugin_widget" runat="server">
        <div class="widget-title">
            <%=Resources.Global.CustomLinks %>
        </div>
        <div class="widget-body" id="custom_links" runat="server" clientidmode="Static">
        </div>
    </div>

    <div class="widget">
        <div class="widget-title">
            <%=Resources.Global.SystemLinks %>
        </div>
        <div class="widget-body" id="system_links" runat="server" clientidmode="Static">
        </div>
    </div>


</asp:Content>
