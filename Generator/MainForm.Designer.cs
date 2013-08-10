namespace Generator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtAssemblyPath = new System.Windows.Forms.TextBox();
            this.btnBrowseAssemblyPath = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnRun = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.txtMetadataDirectoryPath = new System.Windows.Forms.TextBox();
            this.btnBrowseMetadataDirectoryPath = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 17);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(141, 13);
            label1.TabIndex = 1;
            label1.Text = "Entity Datacontext Assembly";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(12, 46);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(129, 13);
            label2.TabIndex = 4;
            label2.Text = "Output metadata directory";
            // 
            // txtAssemblyPath
            // 
            this.txtAssemblyPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssemblyPath.Location = new System.Drawing.Point(159, 14);
            this.txtAssemblyPath.Name = "txtAssemblyPath";
            this.txtAssemblyPath.Size = new System.Drawing.Size(239, 20);
            this.txtAssemblyPath.TabIndex = 0;
            // 
            // btnBrowseAssemblyPath
            // 
            this.btnBrowseAssemblyPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseAssemblyPath.Location = new System.Drawing.Point(414, 12);
            this.btnBrowseAssemblyPath.Name = "btnBrowseAssemblyPath";
            this.btnBrowseAssemblyPath.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseAssemblyPath.TabIndex = 1;
            this.btnBrowseAssemblyPath.Text = "Browse...";
            this.btnBrowseAssemblyPath.UseVisualStyleBackColor = true;
            this.btnBrowseAssemblyPath.Click += new System.EventHandler(this.BrowseAssemblyPath);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Assembly FIles|*.dll";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(302, 85);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(187, 23);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "Generate metadata classes";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.GenerateMetadata);
            // 
            // txtMetadataDirectoryPath
            // 
            this.txtMetadataDirectoryPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMetadataDirectoryPath.Location = new System.Drawing.Point(159, 43);
            this.txtMetadataDirectoryPath.Name = "txtMetadataDirectoryPath";
            this.txtMetadataDirectoryPath.Size = new System.Drawing.Size(239, 20);
            this.txtMetadataDirectoryPath.TabIndex = 2;
            // 
            // btnBrowseMetadataDirectoryPath
            // 
            this.btnBrowseMetadataDirectoryPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseMetadataDirectoryPath.Location = new System.Drawing.Point(414, 41);
            this.btnBrowseMetadataDirectoryPath.Name = "btnBrowseMetadataDirectoryPath";
            this.btnBrowseMetadataDirectoryPath.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseMetadataDirectoryPath.TabIndex = 3;
            this.btnBrowseMetadataDirectoryPath.Text = "Browse...";
            this.btnBrowseMetadataDirectoryPath.UseVisualStyleBackColor = true;
            this.btnBrowseMetadataDirectoryPath.Click += new System.EventHandler(this.BrowseMetadataDirectoryPath);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 90);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(81, 13);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "X.DynamicData";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GoToWebsite);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 120);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnBrowseMetadataDirectoryPath);
            this.Controls.Add(this.txtMetadataDirectoryPath);
            this.Controls.Add(label2);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnBrowseAssemblyPath);
            this.Controls.Add(label1);
            this.Controls.Add(this.txtAssemblyPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Metadata Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAssemblyPath;
        private System.Windows.Forms.Button btnBrowseAssemblyPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox txtMetadataDirectoryPath;
        private System.Windows.Forms.Button btnBrowseMetadataDirectoryPath;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

