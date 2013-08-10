using System.Collections.Specialized;

using System.Web.DynamicData;
using System.Web.UI;

namespace Site
{
    public partial class Html_EditField : FieldTemplateUserControl
    {
        protected override void ExtractValues(IOrderedDictionary dictionary)
        {
            dictionary[Column.Name] = System.Web.HttpUtility.HtmlDecode(editor.Text);
        }

        public override Control DataControl
        {
            get { return editor; }
        }
    }
}