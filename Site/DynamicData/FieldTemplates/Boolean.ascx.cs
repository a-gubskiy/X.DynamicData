using System.Web.DynamicData;
using System.Web.UI;

namespace Site
{
    public partial class BooleanField : FieldTemplateUserControl
    {
        public override string FieldValueString
        {
            get
            {
                object val = FieldValue;

                if (val != null && (bool)val == true)
                {
                    return "<input type=\"checkbox\" disabled=\"True\" checked=\"True\" />";
                }

                return "<input type=\"checkbox\" disabled=\"True\" />";
            }
        }

        public override Control DataControl
        {
            get { return Literal1; }
        }
    }
}
