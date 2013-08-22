<%@ Control Language="C#" CodeBehind="Integer_Edit.ascx.cs" Inherits="Site.Integer_EditField" %>


<div class="input-group">
    <span class="input-group-addon"><i class="glyphicon glyphicon-sound-5-1"></i></span>
    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" Text='<%# FieldValueEditString %>' Columns="10" TextMode="Number"></asp:TextBox>
</div>

<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" Enabled="false" />
<asp:CompareValidator runat="server" ID="CompareValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static"
    Operator="DataTypeCheck" Type="Integer" />
<asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" Enabled="false" />
<asp:RangeValidator runat="server" ID="RangeValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Type="Integer"
    Enabled="false" EnableClientScript="true" MinimumValue="0" MaximumValue="100" Display="Static" />
<asp:DynamicValidator runat="server" ID="DynamicValidator1" CssClass="DDControl DDValidator" ControlToValidate="TextBox1" Display="Static" />