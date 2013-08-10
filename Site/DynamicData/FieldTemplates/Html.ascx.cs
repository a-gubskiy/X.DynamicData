using System.Web.DynamicData;
using System.Web.UI;

namespace Site
{
    public partial class Html_Field : FieldTemplateUserControl
    {
        public override Control DataControl
        {
            get { return Literal1; }
        }
    }
}