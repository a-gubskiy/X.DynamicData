<%@ Control Language="C#" CodeBehind="MultilineText_Edit.ascx.cs" Inherits="Site.MultilineText_EditField" %>

<div class="input-group">
    <span class="input-group-addon"><i class="glyphicon glyphicon-align-left"></i></span>
    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" TextMode="MultiLine" Text='<%# FieldValueEditString %>' Columns="80" Rows="5"></asp:TextBox>
</div>

<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" Enabled="false" />
<asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" Enabled="false" />
<asp:DynamicValidator runat="server" ID="DynamicValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" />

