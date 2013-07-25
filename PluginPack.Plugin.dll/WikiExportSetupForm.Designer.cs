namespace CoBPack.Plugin
{
    partial class WikiExportSetupForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.chkFile = new System.Windows.Forms.CheckBox();
            this.chkClipboard = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.saveDlg = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.txtFilename);
            this.groupBox1.Controls.Add(this.chkFile);
            this.groupBox1.Controls.Add(this.chkClipboard);
            this.groupBox1.Location = new System.Drawing.Point(12, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Send To";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Enabled = false;
            this.btnBrowse.Location = new System.Drawing.Point(381, 66);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(27, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFilename
            // 
            this.txtFilename.Enabled = false;
            this.txtFilename.Location = new System.Drawing.Point(34, 68);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(341, 20);
            this.txtFilename.TabIndex = 2;
            // 
            // chkFile
            // 
            this.chkFile.AutoSize = true;
            this.chkFile.Location = new System.Drawing.Point(7, 44);
            this.chkFile.Name = "chkFile";
            this.chkFile.Size = new System.Drawing.Size(42, 17);
            this.chkFile.TabIndex = 1;
            this.chkFile.Text = "File";
            this.chkFile.UseVisualStyleBackColor = true;
            this.chkFile.CheckedChanged += new System.EventHandler(this.chkFile_CheckedChanged);
            // 
            // chkClipboard
            // 
            this.chkClipboard.AutoSize = true;
            this.chkClipboard.Checked = true;
            this.chkClipboard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClipboard.Location = new System.Drawing.Point(7, 20);
            this.chkClipboard.Name = "chkClipboard";
            this.chkClipboard.Size = new System.Drawing.Size(103, 17);
            this.chkClipboard.TabIndex = 0;
            this.chkClipboard.Text = "Clipboard (Copy)";
            this.chkClipboard.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(414, 61);
            this.label1.TabIndex = 1;
            this.label1.Text = "Wiki Exporter v1.0\r\nCopyright 2007 by Matt Burke (CoB Leviathan)\r\n\r\nTo use, selec" +
                "t a destination from the \"Send To\" box and then click Export";
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(141, 179);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(222, 179);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // saveDlg
            // 
            this.saveDlg.DefaultExt = "txt";
            this.saveDlg.Filter = "\"Text Files|*.txt|All Files|*.*\"";
            this.saveDlg.Title = "Save Wiki Code";
            // 
            // WikiExportSetupForm
            // 
            this.AcceptButton = this.btnExport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(438, 213);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "WikiExportSetupForm";
            this.Text = "Wiki Export Setup";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.CheckBox chkFile;
        private System.Windows.Forms.CheckBox chkClipboard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.SaveFileDialog saveDlg;
    }
}