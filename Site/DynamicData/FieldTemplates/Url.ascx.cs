using System;
using System.Web.UI;

namespace Site
{
    public partial class UrlField : System.Web.DynamicData.FieldTemplateUserControl
    {
        private static string ProcessUrl(string url)
        {
            if (url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) || url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
            {
                return url;
            }

            return "http://" + url;
        }

        public override string FieldValueString
        {
            get
            {
                if (FieldValue != null && !String.IsNullOrEmpty(FieldValue.ToString()))
                {
                    return String.Format("<a href=\"{0}\" />{1}</a>", ProcessUrl(FieldValue.ToString()), FieldValue);
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
