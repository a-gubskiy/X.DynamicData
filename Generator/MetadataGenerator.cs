using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    public class MetadataGenerator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="directory"></param>
        public void Generate(string path, string directory)
        {
            var domain = AppDomain.CreateDomain("x_application_domain");

            var assembly = Assembly.UnsafeLoadFrom(path);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (assembly != null)
            {
                var types = (from o in assembly.GetTypes()
                             where o.BaseType != typeof(DbContext)
                             select o).ToList();

                Parallel.ForEach(types, type =>
                    {
                        CreateClass(type, directory);
                    });
            }

            AppDomain.Unload(domain);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="directory"></param>
        private static void CreateClass(Type type, string directory)
        {
            if (type == null)
            {
                return;
            }

            if (type.Name.Contains("Metadata"))
            {
                return;
            }

            var fileName = type.Name + ".cs";
            var fullName = Path.Combine(directory, fileName);

            var sb = new StringBuilder();

            var className = type.Name;

            sb.AppendLine("using System.ComponentModel;");
            sb.AppendLine("using System.ComponentModel.DataAnnotations;");
            sb.AppendLine("using X.Web;");

            sb.AppendLine(String.Empty);

            sb.AppendLine("namespace DAL");
            sb.AppendLine("{");
            sb.AppendLine("\t[ScaffoldTable(true)]");
            sb.AppendFormat("\t[DisplayName(\"{0}\")]", className);
            sb.AppendLine(String.Empty);
            sb.AppendFormat("\t[MetadataType(typeof({0}Metadata))]", className);
            sb.AppendLine(String.Empty);
            sb.AppendFormat("\tpublic partial class {0}", className);
            sb.AppendLine(String.Empty);
            sb.AppendLine("\t{");
            sb.AppendLine("\t}");

            sb.AppendLine(String.Empty);
            sb.AppendLine(String.Empty);

            sb.AppendFormat("\tpublic class {0}Metadata", className);
            sb.AppendLine(String.Empty);
            sb.AppendLine("\t{");
            sb.AppendLine(String.Empty);

            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                sb.Append(BulildProperty(property));
            }

            sb.AppendLine("\t}");
            sb.AppendLine("}");

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            File.WriteAllText(fullName, sb.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        private static string BulildProperty(PropertyInfo property)
        {
            if (property.PropertyType.Name.Contains("EntityState") || property.PropertyType.Name.Contains("EntityKey"))
            {
                return String.Empty;
            }

            if (property.Name.Contains("Reference"))
            {
                return String.Empty;
            }

            if (property.Name.Contains("Id"))
            {
                return String.Empty;
            }

            var sb = new StringBuilder();

            //DisplayName
            sb.AppendFormat("\t\t[DisplayName(\"{0}\")]", property.Name);
            sb.AppendLine(String.Empty);


            //Browsable
            if ((property.Name.Contains("Content")) ||
                (property.Name == "Name") ||
                (property.Name == "Description") ||
                (property.Name == "Keywords"))
            {
                sb.AppendLine("\t\t[Browsable(false)]");
            }
            else
            {
                sb.AppendLine("\t\t[Browsable(true)]");
            }


            //UIHint
            if (property.Name.Contains("Content"))
            {
                sb.AppendLine("\t\t[UIHint(X.Web.Control.Html)]");
            }
            else if (property.Name.Contains("Image") || property.Name.Contains("Photo"))
            {
                sb.AppendLine("\t\t[UIHint(X.Web.Control.FileImage)]");
            }
            else if (property.Name.Contains("Url"))
            {
                sb.AppendLine("\t\t[UIHint(X.Web.Control.Url)]");
            }
            else if (property.Name.Contains("TimeStamp"))
            {
                sb.AppendLine("\t\t[UIHint(X.Web.Control.DateTime)]");
            }
            else if (property.Name.Contains("Email"))
            {
                sb.AppendLine("\t\t[UIHint(X.Web.Control.Email)]");
            }
            else if (property.Name.Contains("Address"))
            {
                sb.AppendLine("\t\t[UIHint(X.Web.Control.Address)]");
            }

            sb.AppendFormat("\t\tpublic object {0} {{ get; set; }}", property.Name);

            sb.AppendLine(String.Empty);
            sb.AppendLine(String.Empty);

            return sb.ToString();
        }
    }
}
