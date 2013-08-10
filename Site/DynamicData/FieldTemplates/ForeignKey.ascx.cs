using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class ForeignKeyField : System.Web.DynamicData.FieldTemplateUserControl
    {
        public string NavigateUrl { get; set; }

        public bool AllowNavigation { get; set; }

        private string GetDisplayString()
        {
            object value = FieldValue;

            if (value == null)
            {
                return FormatFieldValue(ForeignKeyColumn.GetForeignKeyString(Row));
            }
            
            return FormatFieldValue(ForeignKeyColumn.ParentTable.GetDisplayString(value));
        }

        private string GetNavigateUrl()
        {
            if (!AllowNavigation)
            {
                return null;
            }

            if (String.IsNullOrEmpty(NavigateUrl))
            {
                return ForeignKeyPath;
            }

            return BuildForeignKeyPath(NavigateUrl);
        }

        public override string FieldValueString
        {
            get
            {
                if (FieldValue != null && !String.IsNullOrEmpty(FieldValue.ToString()))
                {
                    return String.Format("<a href=\"{0}\" />{1}</a>", GetNavigateUrl(), GetDisplayString());
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
