using System;
using System.Collections.Specialized;
using System.Web.UI;

namespace Site
{
    public partial class Password_EditField : System.Web.DynamicData.FieldTemplateUserControl
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (Column.MaxLength < 20)
            {
                TextBox1.Columns = Column.MaxLength;
            }

            
            TextBox1.ToolTip = Column.Description;
        }

        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);
            if (Column.MaxLength > 0)
            {
                TextBox1.MaxLength = Math.Max(FieldValueEditString.Length, Column.MaxLength);
            }

            TextBox1.Attributes.Add("value", FieldValueString);
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