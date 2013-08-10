using System;
using System.Collections.Specialized;
using System.Web.DynamicData;
using System.Web.UI;


namespace Site.DynamicData.FieldTemplates
{
    public partial class DateTime_EditField : FieldTemplateUserControl
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            
            TextBox1.ToolTip = Column.Description;

            SetUpValidator(RequiredFieldValidator1);
            SetUpValidator(RegularExpressionValidator1);
            SetUpValidator(DynamicValidator1);
        }

        protected override void ExtractValues(IOrderedDictionary dictionary)
        {
            dictionary[Column.Name] = ConvertEditedValue(TextBox1.Text);
        }

        public bool ReadOnly
        {
            get { return !TextBox1.Enabled; }
            set { TextBox1.Enabled = !value; }
        }

        public override Control DataControl
        {
            get { return TextBox1; }
        }
    }
}
