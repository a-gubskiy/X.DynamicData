using System;
using System.Web.UI;
using X.DynamicData.Core;

namespace Site
{
    public partial class ChildrenField : System.Web.DynamicData.FieldTemplateUserControl
    {
        public string NavigateUrl { get; set; }

        public override string FieldValueString
        {
            get
            {
                String link;
                String text;

                if (String.IsNullOrEmpty(NavigateUrl))
                {
                    link = ChildrenPath;
                    text = Global.GetText("ViewChildRecords");

                }
                else
                {
                    link = BuildChildrenPath(NavigateUrl);
                    text = ChildrenColumn.ChildTable.DisplayName;
                }

                return String.Format("<a target=\"_{2}\" class=\"btn\" href=\"{0}\" />{1}&nbsp;&nbsp;<i class=\"icon-arrow-right\"></i></a>", link, text, ChildrenColumn.ChildTable.Name);
            }
        }

        public override Control DataControl
        {
            get { return Literal1; }
        }

    }
}
