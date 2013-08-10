<%@ Control Language="C#" Inherits="Site.FileImage" EnableViewState="false" CodeBehind="FileImage.ascx.cs" %>

<ul class="thumbnails">
    <li class="span4">
        <a href="#" class="thumbnail">
            <asp:Literal runat="server" ID="Literal1" Text="<%# FieldValueString %>" />
        </a>
    </li>
</ul>