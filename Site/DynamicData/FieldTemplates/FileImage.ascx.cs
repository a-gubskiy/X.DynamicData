using System;
using System.Web.DynamicData;
using System.Web.UI;
using X.DynamicData.Core;

namespace Site
{
    public partial class FileImage : FieldTemplateUserControl
    {
        public override string FieldValueString
        {
            get
            {
                var url = (String) FieldValue;

                if (!String.IsNullOrEmpty(url))
                {
                    if (!url.ToLower().Contains("http://"))
                    {
                        url = Global.Context.FileStorageUrl + url;
                    }

                   
                    return String.Format("<img src=\"{0}\" />", url);
                }

                return String.Empty;
            }
        }


        public override Control DataControl
        {
            get { return Literal1; }
        }
    }

}