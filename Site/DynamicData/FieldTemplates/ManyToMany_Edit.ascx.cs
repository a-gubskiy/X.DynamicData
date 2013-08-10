using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Site
{
    public partial class ManyToMany_EditField : FieldTemplateUserControl
    {
        protected ObjectContext ObjectContext { get; set; }

        public void Page_Load(object sender, EventArgs e)
        {
            // Register for the DataSource's updating event
            var entityDataSource = (EntityDataSource)this.FindDataSourceControl();

            entityDataSource.ContextCreated += (_, ctxCreatedEnventArgs) => ObjectContext = ctxCreatedEnventArgs.Context;

            // This field template is used both for Editing and Inserting
            entityDataSource.Updating += DataSource_UpdatingOrInserting;
            entityDataSource.Inserting += DataSource_UpdatingOrInserting;
        }

        void DataSource_UpdatingOrInserting(object sender, EntityDataSourceChangingEventArgs e)
        {
            MetaTable childTable = ChildrenColumn.ChildTable;

            // Comments assume employee/territory for illustration, but the code is generic
            if (Mode == DataBoundControlMode.Edit)
            {
                ObjectContext.LoadProperty(e.Entity, Column.Name);
            }

            // Get the collection and make sure it's loaded
            dynamic entityCollection = Column.EntityTypeProperty.GetValue(e.Entity, null);

            // Go through all the territories (not just those for this employee)
            foreach (dynamic childEntity in childTable.GetQuery(e.Context))
            {

                // Check if the employee currently has this territory
                var isCurrentlyInList = ListContainsEntity(childTable, entityCollection, childEntity);

                // Find the checkbox for this territory, which gives us the new state
                string pkString = childTable.GetPrimaryKeyString(childEntity);
                ListItem listItem = CheckBoxList1.Items.FindByValue(pkString);
                if (listItem == null)
                    continue;

                // If the states differs, make the appropriate add/remove change
                if (listItem.Selected)
                {
                    if (!isCurrentlyInList)
                    {
                        entityCollection.Add(childEntity);
                    }
                }
                else
                {
                    if (isCurrentlyInList)
                    {
                        entityCollection.Remove(childEntity);
                    }
                }
            }
        }

        private static bool ListContainsEntity(MetaTable table, IEnumerable<object> list, object entity)
        {
            return list.Any(e => AreEntitiesEqual(table, e, entity));
        }

        private static bool AreEntitiesEqual(MetaTable table, object entity1, object entity2)
        {
            return Enumerable.SequenceEqual(table.GetPrimaryKeyValues(entity1), table.GetPrimaryKeyValues(entity2));
        }

        protected void CheckBoxList1_DataBound(object sender, EventArgs e)
        {
            MetaTable childTable = ChildrenColumn.ChildTable;

            // Comments assume employee/territory for illustration, but the code is generic

            IEnumerable<object> entityCollection = null;

            if (Mode == DataBoundControlMode.Edit)
            {
                object entity;
                ICustomTypeDescriptor rowDescriptor = Row as ICustomTypeDescriptor;
                if (rowDescriptor != null)
                {
                    // Get the real entity from the wrapper
                    entity = rowDescriptor.GetPropertyOwner(null);
                }
                else
                {
                    entity = Row;
                }

                // Get the collection of territories for this employee and make sure it's loaded
                entityCollection = (IEnumerable<object>)Column.EntityTypeProperty.GetValue(entity, null);
                var realEntityCollection = entityCollection as RelatedEnd;
                if (realEntityCollection != null && !realEntityCollection.IsLoaded)
                {
                    realEntityCollection.Load();
                }
            }

            // Go through all the territories (not just those for this employee)
            foreach (object childEntity in childTable.GetQuery(ObjectContext))
            {
                // Create a checkbox for it
                ListItem listItem = new ListItem(
                    childTable.GetDisplayString(childEntity),
                    childTable.GetPrimaryKeyString(childEntity));

                // Make it selected if the current employee has that territory
                if (Mode == DataBoundControlMode.Edit)
                {
                    listItem.Selected = ListContainsEntity(childTable, entityCollection, childEntity);
                }

                CheckBoxList1.Items.Add(listItem);
            }
        }

        public override Control DataControl
        {
            get { return CheckBoxList1; }
        }

    }
}
