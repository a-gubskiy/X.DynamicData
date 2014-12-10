using System;
using System.Collections.Specialized;
using System.IO;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using X.DynamicData.Core;

namespace Site
{
    public partial class FileImage_Edit : FieldTemplateUserControl
    {
        public override Control DataControl
        {
            get { return image_name; }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // add CustomValidator1's event handler
            CustomValidator1.ServerValidate += new ServerValidateEventHandler(ValidateImage);
        }

        private void ValidateImage(object source, ServerValidateEventArgs args)
        {
            if (FileUploadEdit.HasFile)
            {
                var bytes = FileUploadEdit.FileBytes;

                try
                {
                    var image = System.Drawing.Image.FromStream(new MemoryStream(bytes));
                }
                catch
                {
                    // catch any error when user tries to load a file that 
                    // is not an image recognised by System.Drawing
                    args.IsValid = false;
                    CustomValidator1.ErrorMessage = "Not an Image";
                }
            }
            else
            {
                return;
                // no file to download you decide wether this is a valid error
                // to throw comment out
                //if (!FileUploadEdit.HasFile && String.IsNullOrEmpty(ImageEdit.ImageUrl))
                //{
                //    args.IsValid = false;
                //    CustomValidator1.ErrorMessage = "No file to download";
                //}
            }
        }

        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);

            FileUploadEdit.Visible = true;

            if (FieldValue == null)
            {
                return;
            }

            var fileName = (String)FieldValue;

            if (!String.IsNullOrEmpty(fileName))
            {
                ImageEdit.ImageUrl = Global.Context.StorageUrl + fileName;
                image_name.Value = fileName;
                ImageEdit.Visible = true;
            }
            else
            {
                ImageEdit.Visible = false;
            }
        }

        protected override void ExtractValues(IOrderedDictionary dictionary)
        {
            if (FileUploadEdit.HasFile)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(FileUploadEdit.FileName);

                // try to upload the file showing error if it fails
                try
                {
                    Global.UploadFile(FileUploadEdit.FileBytes, fileName);

                    image_name.Value = fileName;
                    ImageEdit.ImageUrl = Global.Context.StorageUrl + fileName;
                }
                catch (Exception ex)
                {
                    // display error
                    CustomValidator1.IsValid = false;
                    CustomValidator1.ErrorMessage = ex.Message;
                    image_name.Value = null;
                }
            }

            dictionary[Column.Name] = image_name.Value;
        }

    }
}