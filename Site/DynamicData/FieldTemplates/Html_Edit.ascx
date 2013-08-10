<%@ Control Language="C#" Inherits="Site.Html_EditField" AutoEventWireup="true" CodeBehind="Html_Edit.ascx.cs" %>

<asp:TextBox runat="server"
    ID="editor"
    TextMode="MultiLine"
    Columns="50"
    Rows="10"
    CssClass="html_editor"
    Text="<%#FieldValueEditString %>" />

<script src="/Scripts/ckeditor/ckeditor.js"></script>

<script>
    var editor = CKEDITOR.replace('<%#editor.ClientID %>', {
        language: '<%# System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName%>',
        filebrowserUploadUrl: '/system/CKEditorFileUpload',
        toolbar : 'Full',
 
        toolbar_Full :
        [
            { name: 'document', items : [ 'Source','-','Save','NewPage','DocProps','Preview','Print','-','Templates' ] },
            { name: 'clipboard', items : [ 'Cut','Copy','Paste','PasteText','PasteFromWord','-','Undo','Redo' ] },
            { name: 'editing', items : [ 'Find','Replace','-','SelectAll','-','SpellChecker', 'Scayt' ] },
            //{ name: 'forms', items : [ 'Form', 'Checkbox', 'Radio', 'TextField', 'Textarea', 'Select', 'Button', 'ImageButton',  'HiddenField' ] },
            '/',
            { name: 'basicstyles', items : [ 'Bold','Italic','Underline','Strike','Subscript','Superscript','-','RemoveFormat' ] },
            { name: 'paragraph', items : [ 'NumberedList','BulletedList','-','Outdent','Indent','-','Blockquote','CreateDiv', '-','JustifyLeft','JustifyCenter','JustifyRight','JustifyBlock','-','BidiLtr','BidiRtl' ] },
            { name: 'links', items : [ 'Link','Unlink','Anchor' ] },
            { name: 'insert', items : [ 'Image','Flash','Table','HorizontalRule','Smiley','SpecialChar','PageBreak','Iframe' ] },
            '/',
            { name: 'styles', items : [ 'Styles','Format','Font','FontSize' ] },
            { name: 'colors', items : [ 'TextColor','BGColor' ] },
            { name: 'tools', items : [ 'Maximize', 'ShowBlocks','-','About' ] }
        ],
        removeButtons: 'Save,NewPage,Templates,Flash',

    });
    
    $('.save').click(function() {
        var teaxtarea = $("#" + "<%#editor.ClientID %>");
        var html = CKEDITOR.instances.<%#editor.ClientID %>.getData();
        teaxtarea.val(html);
    });
    
</script>
