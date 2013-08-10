using System;
using System.ComponentModel;
using System.Data.Objects.DataClasses;
using System.Web.UI;

namespace Site
{
    public partial class ManyToManyField : System.Web.DynamicData.FieldTemplateUserControl
    {
        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);

            object entity;
            var rowDescriptor = Row as ICustomTypeDescriptor;

            entity = rowDescriptor != null ? rowDescriptor.GetPropertyOwner(null) : Row;

            // Get the collection and make sure it's loaded
            var entityCollection = Column.EntityTypeProperty.GetValue(entity, null);
            var realEntityCollection = entityCollection as RelatedEnd;
            if (realEntityCollection != null && !realEntityCollection.IsLoaded)
            {
                realEntityCollection.Load();
            }


            // Bind the repeater to the list of children entities
            Repeater1.DataSource = entityCollection;
            Repeater1.DataBind();
        }

        public override Control DataControl
        {
            get { return Repeater1; }
        }

    }
}
