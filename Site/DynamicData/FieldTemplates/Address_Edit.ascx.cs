using System;
using System.Collections.Specialized;
using System.Text;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;

namespace Site
{
    public partial class Address_EditField : FieldTemplateUserControl
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

            var address = (String) FieldValue;

            if (!String.IsNullOrEmpty(address))
            {
                String.Format(
                    "<iframe class=\"map\" src=\"{0}\" width=\"600\" height=\"250\" frameborder=\"0\" scrolling=\"no\" marginheight=\"0\" marginwidth=\"0\"></iframe>",
                    GenerateMapUrl(address));
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

        private string GenerateMapUrl(string address)
        {
            var sb = new StringBuilder();
            sb.Append("http://maps.google.com/maps?");
            sb.Append("f=q");
            sb.Append("&source=s_q");
            //sb.Append("&amp;q=%D0%91%D0%BE%D1%8F%D1%80%D0%BA%D0%B0");
            sb.AppendFormat("&q={0}", address, HttpUtility.UrlEncode(address));
            sb.Append("&ie=UTF8");
            sb.Append("&t=m");
            sb.Append("&z=14");
            sb.Append("&iwloc=A");
            sb.Append("&output=embed");

            return sb.ToString();
        }

    }

}