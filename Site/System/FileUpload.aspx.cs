using System;
using System.IO;
using X.DynamicData.Core;

namespace Site
{
    public partial class FileUploadPage : XPage
    {

        protected void do_upload_Click(object sender, EventArgs e)
        {
            if (!file_upload.HasFile)
            {
                return;
            }

            try
            {
                var name = Guid.NewGuid() + Path.GetExtension(file_upload.FileName);
                var url = Global.UploadFile(file_upload.FileBytes, name);

                result.Visible = true;
                prependedInput.Value = url;

                if (name.Contains("jpg") ||
                    name.Contains("jpeg") ||
                    name.Contains("png") ||
                    name.Contains("gif") ||
                    name.Contains("bmp"))
                {
                    uploaded_image.Src = url;
                    uploaded_image.Visible = true;
                }
            }
            catch (Exception ex)
            {
                result.InnerText = ex.Message;
            }
        }
    }
}