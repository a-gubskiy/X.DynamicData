<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Url_Edit.ascx.cs" Inherits="Site.Url_EditField" %>

<div class="input-group">
    <span class="input-group-addon"><i class="glyphicon glyphicon-globe"></i></span>
    <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server" Text='<%# FieldValueEditString %>' Columns="10" TextMode="Url"></asp:TextBox>
</div>

<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" Enabled="false" />
<asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" Enabled="false" />
<asp:DynamicValidator runat="server" ID="DynamicValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" />