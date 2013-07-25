namespace H2Stats
{
    partial class DownloadForm
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
            this.cboGamertags = new System.Windows.Forms.ComboBox();
            this.prgBar = new System.Windows.Forms.ProgressBar();
            this.imgCurrentIcon = new System.Windows.Forms.PictureBox();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.rdoCurrentSelection = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkUpdatePlaylists = new System.Windows.Forms.CheckBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblGameMap = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.levelPanel = new H2Stats.Controls.LevelDisplayPanel();
            this.lblBytesDL = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imgCurrentIcon)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboGamertags
            // 
            this.cboGamertags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboGamertags.FormattingEnabled = true;
            this.cboGamertags.Location = new System.Drawing.Point(12, 142);
            this.cboGamertags.Name = "cboGamertags";
            this.cboGamertags.Size = new System.Drawing.Size(234, 21);
            this.cboGamertags.TabIndex = 0;
            this.cboGamertags.SelectedIndexChanged += new System.EventHandler(this.cboGamertags_SelectedIndexChanged);
            // 
            // prgBar
            // 
            this.prgBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.prgBar.Location = new System.Drawing.Point(12, 289);
            this.prgBar.Name = "prgBar";
            this.prgBar.Size = new System.Drawing.Size(234, 23);
            this.prgBar.TabIndex = 3;
            // 
            // imgCurrentIcon
            // 
            this.imgCurrentIcon.Location = new System.Drawing.Point(15, 12);
            this.imgCurrentIcon.Name = "imgCurrentIcon";
            this.imgCurrentIcon.Size = new System.Drawing.Size(108, 108);
            this.imgCurrentIcon.TabIndex = 4;
            this.imgCurrentIcon.TabStop = false;
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Checked = global::H2Stats.Properties.Settings.Default.DownloadAll;
            this.rdoAll.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::H2Stats.Properties.Settings.Default, "DownloadAll", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.rdoAll.Location = new System.Drawing.Point(22, 19);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(36, 17);
            this.rdoAll.TabIndex = 5;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // rdoCurrentSelection
            // 
            this.rdoCurrentSelection.AutoSize = true;
            this.rdoCurrentSelection.Location = new System.Drawing.Point(22, 42);
            this.rdoCurrentSelection.Name = "rdoCurrentSelection";
            this.rdoCurrentSelection.Size = new System.Drawing.Size(106, 17);
            this.rdoCurrentSelection.TabIndex = 6;
            this.rdoCurrentSelection.Text = "Current Selection";
            this.rdoCurrentSelection.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox1.Controls.Add(this.chkUpdatePlaylists);
            this.groupBox1.Controls.Add(this.rdoAll);
            this.groupBox1.Controls.Add(this.rdoCurrentSelection);
            this.groupBox1.Location = new System.Drawing.Point(15, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(231, 70);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Download";
            // 
            // chkUpdatePlaylists
            // 
            this.chkUpdatePlaylists.AutoSize = true;
            this.chkUpdatePlaylists.Location = new System.Drawing.Point(124, 19);
            this.chkUpdatePlaylists.Name = "chkUpdatePlaylists";
            this.chkUpdatePlaylists.Size = new System.Drawing.Size(101, 17);
            this.chkUpdatePlaylists.TabIndex = 7;
            this.chkUpdatePlaylists.Text = "Update Playlists";
            this.chkUpdatePlaylists.UseVisualStyleBackColor = true;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGo.Location = new System.Drawing.Point(92, 352);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 8;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(62, 264);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(24, 13);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Idle";
            // 
            // lblGameMap
            // 
            this.lblGameMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGameMap.Location = new System.Drawing.Point(12, 315);
            this.lblGameMap.Name = "lblGameMap";
            this.lblGameMap.Size = new System.Drawing.Size(234, 17);
            this.lblGameMap.TabIndex = 11;
            this.lblGameMap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Status:";
            // 
            // worker
            // 
            this.worker.WorkerReportsProgress = true;
            this.worker.WorkerSupportsCancellation = true;
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.doDownload);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            this.worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.worker_ProgressChanged);
            // 
            // levelPanel
            // 
            this.levelPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.levelPanel.AutoScroll = true;
            this.levelPanel.Location = new System.Drawing.Point(129, 12);
            this.levelPanel.Name = "levelPanel";
            this.levelPanel.Size = new System.Drawing.Size(117, 108);
            this.levelPanel.TabIndex = 14;
            // 
            // lblBytesDL
            // 
            this.lblBytesDL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBytesDL.Location = new System.Drawing.Point(15, 336);
            this.lblBytesDL.Name = "lblBytesDL";
            this.lblBytesDL.Size = new System.Drawing.Size(231, 13);
            this.lblBytesDL.TabIndex = 15;
            this.lblBytesDL.Text = "0 bytes downloaded";
            this.lblBytesDL.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 389);
            this.Controls.Add(this.lblBytesDL);
            this.Controls.Add(this.levelPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblGameMap);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.imgCurrentIcon);
            this.Controls.Add(this.prgBar);
            this.Controls.Add(this.cboGamertags);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::H2Stats.Properties.Settings.Default, "DownloadFormLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Location = global::H2Stats.Properties.Settings.Default.DownloadFormLocation;
            this.MinimumSize = new System.Drawing.Size(266, 421);
            this.Name = "DownloadForm";
            this.Text = "Download Stats";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DownloadForm_FormClosed);
            this.Shown += new System.EventHandler(this.DownloadForm_Shown);
            this.Load += new System.EventHandler(this.DownloadForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgCurrentIcon)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboGamertags;
        private System.Windows.Forms.ProgressBar prgBar;
        private System.Windows.Forms.PictureBox imgCurrentIcon;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdoCurrentSelection;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblGameMap;
        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker worker;
        private H2Stats.Controls.LevelDisplayPanel levelPanel;
        private System.Windows.Forms.CheckBox chkUpdatePlaylists;
        private System.Windows.Forms.Label lblBytesDL;
        private System.Windows.Forms.Timer timer1;
    }
}