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
            <%=Resources.Global.Status %>
        </div>
        <div class="widget-body">            
                <ul id="startup_menu" class="nav menu" runat="server" clientidmode="Static">
                </ul>            
        </div>
    </div>


</asp:Content>
