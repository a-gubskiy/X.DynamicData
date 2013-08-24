using System;
using System.Collections.Specialized;
using System.Text;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;

namespace Site
{
    public partial class Video_EditField : FieldTemplateUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Column.MaxLength < 20)
            {
                TextBox1.Columns = Column.MaxLength;
            }

            TextBox1.ToolTip = Column.Description;

            SetUpValidator(RequiredFieldValidator1);
            SetUpValidator(RegularExpressionValidator1);
            SetUpValidator(DynamicValidator1);
        }

        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);

            if (Column.MaxLength > 0)
            {
                TextBox1.MaxLength = Math.Max(FieldValueEditString.Length, Column.MaxLength);
            }


            if (FieldValue == null)
            {
                return;
            }

            var code = (String)FieldValue;

            if (!String.IsNullOrEmpty(code))
            {
                video_container.InnerHtml = code;
            }
        }

        protected override void ExtractValues(IOrderedDictionary dictionary)
        {
            dictionary[Column.Name] = ConvertEditedValue(TextBox1.Text);
        }

        public override Control DataControl
        {
            get { return TextBox1; }
        }
    }
}