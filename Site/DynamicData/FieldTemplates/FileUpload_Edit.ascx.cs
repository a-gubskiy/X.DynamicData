using System;
using System.Collections.Specialized;
using System.IO;
using System.Web.DynamicData;
using System.Web.UI;
using X.DynamicData.Core;

namespace Site
{
    public partial class FileUpload_Edit : FieldTemplateUserControl
    {
        public override Control DataControl
        {
            get { return Label1; }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);

            //check if field has a value
            if (FieldValue == null)
            {
                return;
            }

            // when there is already a value in the FieldValue then show the icon and label/hyperlink
            Label1.Visible = true;

            var fileName = String.IsNullOrEmpty(FieldValueString)
                               ? String.Empty
                               : FieldValueString.Replace("&amp;", "&");

            HyperLink1.Text = "Загрузить файл";
            HyperLink1.NavigateUrl = Global.Context.StorageUrl + fileName;

        }

        protected override void ExtractValues(IOrderedDictionary dictionary)
        {
            if (FileUpload1.HasFile)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(FileUpload1.FileName);

                try
                {
                    // try to upload the file showing error if it fails
                    Global.UploadFile(FileUpload1.FileBytes, fileName);
                    dictionary[Column.Name] = fileName;
                }
                catch (Exception ex)
                {
                    // display error
                    CustomValidator1.IsValid = false;
                    CustomValidator1.ErrorMessage = ex.Message;
                }
            }
        }
    }

}