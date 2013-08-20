<%@ Control Language="C#" AutoEventWireup="true" Inherits="Site.FileImage_Edit" Codebehind="FileImage_Edit.ascx.cs" %>

<ul class="thumbnails">
    <li class="col-md-4">
        <a href="#" class="thumbnail">
            <asp:Image CssClass="imageControl" ID="ImageEdit" ImageUrl="<%# String.IsNullOrEmpty(FieldValueString) ? String.Empty : X.DynamicData.Core.Global.Context.FileStorageUrl + FieldValueString %>" runat="server" />
        </a>
    </li>
</ul>

<br />

<asp:FileUpload ID="FileUploadEdit" runat="server"  />
<asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage=""></asp:CustomValidator>
<asp:HiddenField ID="image_name" Value="<%# FieldValueString %>" runat="server" />