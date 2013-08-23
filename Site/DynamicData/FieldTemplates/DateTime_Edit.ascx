<%@ Control Language="C#" AutoEventWireup="true" Inherits="Site.DynamicData.FieldTemplates.DateTime_EditField" CodeBehind="DateTime_Edit.ascx.cs" %>


<div class="input-group">
    <span class="input-group-addon"><i class="glyphicon glyphicon-calendar"></i></span>
    <asp:TextBox ID="TextBox1" TextMode="Date" runat="server" CssClass="droplist date" Text='<%# FieldValueEditString %>' Columns="20"></asp:TextBox>
</div>



<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" CssClass="droplist" ControlToValidate="TextBox1" Display="Dynamic" Enabled="false" />
<asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" CssClass="droplist" ControlToValidate="TextBox1" Display="Dynamic" Enabled="false" />
<asp:DynamicValidator runat="server" ID="DynamicValidator1" CssClass="droplist" ControlToValidate="TextBox1" Display="Dynamic" />