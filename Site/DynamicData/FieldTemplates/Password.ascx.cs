using System.Web.UI;

namespace Site
{
    public partial class PasswordField : System.Web.DynamicData.FieldTemplateUserControl
    {   public override string FieldValueString
        {
            get
            {
                //string value = base.FieldValueString;
                return "********";
            }
        }

        public override Control DataControl
        {
            get
            {
                return Literal1;
            }
        }

    }
}
