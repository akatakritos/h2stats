namespace H2Stats
{
    partial class TagEditorForm
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
            this.components = new System.ComponentModel.Container();
            this.lbGamertags = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSaveGameViewer = new System.Windows.Forms.CheckBox();
            this.chkDownloadAll = new System.Windows.Forms.CheckBox();
            this.txtQuote = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRemoveTag = new System.Windows.Forms.Button();
            this.txtNewTag = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtNewTags = new System.Windows.Forms.TextBox();
            this.btnAddMany = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.imgPlayerIcon = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayerIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbGamertags
            // 
            this.lbGamertags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbGamertags.FormattingEnabled = true;
            this.lbGamertags.Location = new System.Drawing.Point(0, 0);
            this.lbGamertags.Name = "lbGamertags";
            this.lbGamertags.Size = new System.Drawing.Size(113, 290);
            this.lbGamertags.TabIndex = 0;
            this.lbGamertags.SelectedIndexChanged += new System.EventHandler(this.cboGamertags_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSaveGameViewer);
            this.groupBox1.Controls.Add(this.chkDownloadAll);
            this.groupBox1.Location = new System.Drawing.Point(16, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(130, 68);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // chkSaveGameViewer
            // 
            this.chkSaveGameViewer.AutoSize = true;
            this.chkSaveGameViewer.Location = new System.Drawing.Point(8, 42);
            this.chkSaveGameViewer.Name = "chkSaveGameViewer";
            this.chkSaveGameViewer.Size = new System.Drawing.Size(117, 17);
            this.chkSaveGameViewer.TabIndex = 1;
            this.chkSaveGameViewer.Text = "Save Game Viewer";
            this.chkSaveGameViewer.UseVisualStyleBackColor = true;
            // 
            // chkDownloadAll
            // 
            this.chkDownloadAll.AutoSize = true;
            this.chkDownloadAll.Location = new System.Drawing.Point(8, 19);
            this.chkDownloadAll.Name = "chkDownloadAll";
            this.chkDownloadAll.Size = new System.Drawing.Size(101, 17);
            this.chkDownloadAll.TabIndex = 0;
            this.chkDownloadAll.Text = "Download Stats";
            this.chkDownloadAll.UseVisualStyleBackColor = true;
            // 
            // txtQuote
            // 
            this.txtQuote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuote.Location = new System.Drawing.Point(16, 194);
            this.txtQuote.MaxLength = 255;
            this.txtQuote.Multiline = true;
            this.txtQuote.Name = "txtQuote";
            this.txtQuote.Size = new System.Drawing.Size(197, 65);
            this.txtQuote.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Quote:";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Location = new System.Drawing.Point(200, 334);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(281, 334);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRemoveTag
            // 
            this.btnRemoveTag.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRemoveTag.Location = new System.Drawing.Point(60, 265);
            this.btnRemoveTag.Name = "btnRemoveTag";
            this.btnRemoveTag.Size = new System.Drawing.Size(94, 23);
            this.btnRemoveTag.TabIndex = 6;
            this.btnRemoveTag.Text = "Remove Tag";
            this.btnRemoveTag.UseVisualStyleBackColor = true;
            this.btnRemoveTag.Click += new System.EventHandler(this.btnRemoveTag_Click);
            // 
            // txtNewTag
            // 
            this.txtNewTag.Location = new System.Drawing.Point(8, 30);
            this.txtNewTag.Name = "txtNewTag";
            this.txtNewTag.Size = new System.Drawing.Size(155, 20);
            this.txtNewTag.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(52, 59);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtNewTags
            // 
            this.txtNewTags.AcceptsReturn = true;
            this.txtNewTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNewTags.Location = new System.Drawing.Point(8, 101);
            this.txtNewTags.Multiline = true;
            this.txtNewTags.Name = "txtNewTags";
            this.txtNewTags.Size = new System.Drawing.Size(155, 174);
            this.txtNewTags.TabIndex = 10;
            // 
            // btnAddMany
            // 
            this.btnAddMany.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAddMany.Location = new System.Drawing.Point(52, 281);
            this.btnAddMany.Name = "btnAddMany";
            this.btnAddMany.Size = new System.Drawing.Size(75, 23);
            this.btnAddMany.TabIndex = 11;
            this.btnAddMany.Text = "Add Many";
            this.btnAddMany.UseVisualStyleBackColor = true;
            this.btnAddMany.Click += new System.EventHandler(this.btnAddMany_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.btnAddMany);
            this.groupBox2.Controls.Add(this.txtNewTags);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.txtNewTag);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 313);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add New";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.splitContainer1);
            this.groupBox3.Location = new System.Drawing.Point(196, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(358, 313);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Current List";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lbGamertags);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.imgPlayerIcon);
            this.splitContainer1.Panel2.Controls.Add(this.txtQuote);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.btnRemoveTag);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(352, 294);
            this.splitContainer1.SplitterDistance = 113;
            this.splitContainer1.TabIndex = 7;
            // 
            // imgPlayerIcon
            // 
            this.imgPlayerIcon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.imgPlayerIcon.Location = new System.Drawing.Point(72, 11);
            this.imgPlayerIcon.Name = "imgPlayerIcon";
            this.imgPlayerIcon.Size = new System.Drawing.Size(90, 90);
            this.imgPlayerIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgPlayerIcon.TabIndex = 7;
            this.imgPlayerIcon.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // TagEditorForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(566, 371);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.MinimumSize = new System.Drawing.Size(574, 403);
            this.Name = "TagEditorForm";
            this.Text = "Tag List Editor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgPlayerIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbGamertags;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkSaveGameViewer;
        private System.Windows.Forms.CheckBox chkDownloadAll;
        private System.Windows.Forms.TextBox txtQuote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRemoveTag;
        private System.Windows.Forms.TextBox txtNewTag;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtNewTags;
        private System.Windows.Forms.Button btnAddMany;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox imgPlayerIcon;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}