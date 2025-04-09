namespace Task3
{
    partial class Form1
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.File_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Extension = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Created = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCreateFile = new System.Windows.Forms.Button();
            this.textBoxNewFileName = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.File_Name,
            this.Size,
            this.Extension,
            this.Created});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(27, 78);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(651, 403);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(27, 27);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(503, 22);
            this.textBoxPath.TabIndex = 2;
            this.textBoxPath.Text = "Write path here";
            this.textBoxPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPath_KeyDown);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(568, 22);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(110, 33);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // File_Name
            // 
            this.File_Name.Text = "Name";
            this.File_Name.Width = 200;
            // 
            // Size
            // 
            this.Size.Text = "Size";
            this.Size.Width = 100;
            // 
            // Extension
            // 
            this.Extension.Text = "Extension";
            this.Extension.Width = 100;
            // 
            // Created
            // 
            this.Created.Text = "Created";
            this.Created.Width = 150;
            // 
            // btnCreateFile
            // 
            this.btnCreateFile.Location = new System.Drawing.Point(404, 503);
            this.btnCreateFile.Name = "btnCreateFile";
            this.btnCreateFile.Size = new System.Drawing.Size(82, 40);
            this.btnCreateFile.TabIndex = 4;
            this.btnCreateFile.Text = "Create";
            this.btnCreateFile.UseVisualStyleBackColor = true;
            this.btnCreateFile.Click += new System.EventHandler(this.btnCreateFile_Click);
            // 
            // textBoxNewFileName
            // 
            this.textBoxNewFileName.Location = new System.Drawing.Point(27, 521);
            this.textBoxNewFileName.Name = "textBoxNewFileName";
            this.textBoxNewFileName.Size = new System.Drawing.Size(354, 22);
            this.textBoxNewFileName.TabIndex = 5;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(506, 503);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(89, 40);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 568);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.textBoxNewFileName);
            this.Controls.Add(this.btnCreateFile);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "FileManagerApp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ColumnHeader File_Name;
        private System.Windows.Forms.ColumnHeader Size;
        private System.Windows.Forms.ColumnHeader Extension;
        private System.Windows.Forms.ColumnHeader Created;
        private System.Windows.Forms.Button btnCreateFile;
        private System.Windows.Forms.TextBox textBoxNewFileName;
        private System.Windows.Forms.Button btnDelete;
    }
}

