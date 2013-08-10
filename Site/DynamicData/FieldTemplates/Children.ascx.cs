using System;
using System.Web.UI;

namespace Site
{
    public partial class ChildrenField : System.Web.DynamicData.FieldTemplateUserControl
    {
        public string NavigateUrl { get; set; }
        
        public override string FieldValueString
        {
            get
            {
                if (String.IsNullOrEmpty(NavigateUrl))
                {
                    return String.Format("<a href=\"{0}\" />Просмотр записей</a>", ChildrenPath);
                }

                return String.Format("<a href=\"{0}\" />{1}</a>",
                                     BuildChildrenPath(NavigateUrl), ChildrenColumn.ChildTable.DisplayName);
            }
        }

        public override Control DataControl
        {
            get { return Literal1; }
        }

    }
}
