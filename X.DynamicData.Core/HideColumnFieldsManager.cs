using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.DynamicData;
using System.Web.UI;

namespace X.DynamicData.Core
{
    public class HideColumnFieldsManager : IAutoFieldGenerator
    {
        private readonly MetaTable _table;

        public HideColumnFieldsManager(MetaTable table)
        {
            _table = table;
        }

        public ICollection GenerateFields(Control control)
        {
            var fields = new List<DynamicField>();

            foreach (var column in _table.Columns)
            {
                // carry on the loop at the next column  if scaffold table is set to false or DenyRead
                if (!column.Scaffold || IsHidden(column))
                {
                    //column.IsLongString ||
                    continue;
                }

                var dynamicField = new DynamicField();
                dynamicField.DataField = column.Name;

                fields.Add(dynamicField);
            }

            return fields;
        }

        private static Boolean IsHidden(MetaColumn column)
        {
            var browsable = column.Attributes.OfType<BrowsableAttribute>().SingleOrDefault();

            if (browsable == null)
            {
                return false;
            }

            return !browsable.Browsable;
        }
    }
}