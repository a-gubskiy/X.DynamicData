using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Generator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void BrowseAssemblyPath(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var path = openFileDialog.FileName;
                txtAssemblyPath.Text = path;
                txtMetadataDirectoryPath.Text = GetMetadataDirectoryPath(path);
            }
        }

        private static string GetMetadataDirectoryPath(string path)
        {
            if (path.Contains("DAL"))
            {
                //For internal projects
                path = Path.GetDirectoryName(Path.GetDirectoryName(path));
            }

            return Path.Combine(Path.GetDirectoryName(path), "Entities");
        }

        private void BrowseMetadataDirectoryPath(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                txtMetadataDirectoryPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void GenerateMetadata(object sender, EventArgs e)
        {
            var assemblyPath = txtAssemblyPath.Text;
            var directory = txtMetadataDirectoryPath.Text;

            var generator = new MetadataGenerator();

            try
            {
                generator.Generate(assemblyPath, directory);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while generating metadata: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            MessageBox.Show("Done.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GoToWebsite(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/ernado-x/X.DynamicData"));
        }
    }
}
