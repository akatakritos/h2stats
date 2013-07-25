namespace CoBPack.Plugin
{
    partial class BungieGameViewer
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvStats = new System.Windows.Forms.DataGridView();
            this.colGamertag = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colStat1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStat2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvKDAS = new System.Windows.Forms.DataGridView();
            this.colKillsGamertag = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colKills = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeaths = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssists = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSuicides = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblPlaylist = new System.Windows.Forms.LinkLabel();
            this.lblMap = new System.Windows.Forms.LinkLabel();
            this.lblMatchtype = new System.Windows.Forms.LinkLabel();
            this.lblGamelength = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colPvPGamertag = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colMostKilled = new System.Windows.Forms.DataGridViewLinkColumn();
            this.colMostKilledBy = new System.Windows.Forms.DataGridViewLinkColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStats)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKDAS)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(12, 132);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(554, 366);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvStats);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(546, 340);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Stats";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvStats
            // 
            this.dgvStats.AllowUserToAddRows = false;
            this.dgvStats.AllowUserToDeleteRows = false;
            this.dgvStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGamertag,
            this.colStat1,
            this.colStat2,
            this.colScore});
            this.dgvStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStats.Location = new System.Drawing.Point(3, 3);
            this.dgvStats.Name = "dgvStats";
            this.dgvStats.ReadOnly = true;
            this.dgvStats.Size = new System.Drawing.Size(540, 334);
            this.dgvStats.TabIndex = 0;
            // 
            // colGamertag
            // 
            this.colGamertag.HeaderText = "Gamertag";
            this.colGamertag.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.colGamertag.LinkColor = System.Drawing.Color.Black;
            this.colGamertag.Name = "colGamertag";
            this.colGamertag.ReadOnly = true;
            this.colGamertag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colGamertag.TrackVisitedState = false;
            this.colGamertag.VisitedLinkColor = System.Drawing.Color.Black;
            this.colGamertag.Width = 200;
            // 
            // colStat1
            // 
            this.colStat1.HeaderText = "Stat1";
            this.colStat1.Name = "colStat1";
            this.colStat1.ReadOnly = true;
            this.colStat1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colStat1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colStat2
            // 
            this.colStat2.HeaderText = "Stat2";
            this.colStat2.Name = "colStat2";
            this.colStat2.ReadOnly = true;
            this.colStat2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colStat2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colScore
            // 
            this.colScore.HeaderText = "Score";
            this.colScore.Name = "colScore";
            this.colScore.ReadOnly = true;
            this.colScore.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colScore.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvKDAS);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(546, 340);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Kills";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvKDAS
            // 
            this.dgvKDAS.AllowUserToAddRows = false;
            this.dgvKDAS.AllowUserToDeleteRows = false;
            this.dgvKDAS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKDAS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colKillsGamertag,
            this.colKills,
            this.colDeaths,
            this.colAssists,
            this.colSuicides});
            this.dgvKDAS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKDAS.Location = new System.Drawing.Point(3, 3);
            this.dgvKDAS.Name = "dgvKDAS";
            this.dgvKDAS.ReadOnly = true;
            this.dgvKDAS.Size = new System.Drawing.Size(540, 334);
            this.dgvKDAS.TabIndex = 0;
            // 
            // colKillsGamertag
            // 
            this.colKillsGamertag.HeaderText = "Gamertag";
            this.colKillsGamertag.LinkColor = System.Drawing.SystemColors.ControlText;
            this.colKillsGamertag.Name = "colKillsGamertag";
            this.colKillsGamertag.ReadOnly = true;
            this.colKillsGamertag.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.colKillsGamertag.Width = 200;
            // 
            // colKills
            // 
            this.colKills.HeaderText = "Kills";
            this.colKills.Name = "colKills";
            this.colKills.ReadOnly = true;
            this.colKills.Width = 75;
            // 
            // colDeaths
            // 
            this.colDeaths.HeaderText = "Deaths";
            this.colDeaths.Name = "colDeaths";
            this.colDeaths.ReadOnly = true;
            this.colDeaths.Width = 75;
            // 
            // colAssists
            // 
            this.colAssists.HeaderText = "Assists";
            this.colAssists.Name = "colAssists";
            this.colAssists.ReadOnly = true;
            this.colAssists.Width = 75;
            // 
            // colSuicides
            // 
            this.colSuicides.HeaderText = "Suicides";
            this.colSuicides.Name = "colSuicides";
            this.colSuicides.ReadOnly = true;
            this.colSuicides.Width = 75;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(546, 340);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "PvP";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(546, 340);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Medals";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(546, 340);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Hits";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(98, 92);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lblPlaylist
            // 
            this.lblPlaylist.LinkColor = System.Drawing.SystemColors.ControlText;
            this.lblPlaylist.Location = new System.Drawing.Point(343, 20);
            this.lblPlaylist.Name = "lblPlaylist";
            this.lblPlaylist.Size = new System.Drawing.Size(220, 16);
            this.lblPlaylist.TabIndex = 4;
            this.lblPlaylist.TabStop = true;
            this.lblPlaylist.Text = "<Playlist>";
            this.lblPlaylist.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblPlaylist.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.lblPlaylist.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblMap_LinkClicked);
            // 
            // lblMap
            // 
            this.lblMap.AutoSize = true;
            this.lblMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMap.LinkColor = System.Drawing.SystemColors.ControlText;
            this.lblMap.Location = new System.Drawing.Point(116, 12);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(69, 24);
            this.lblMap.TabIndex = 7;
            this.lblMap.TabStop = true;
            this.lblMap.Text = "<Map>";
            this.lblMap.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.lblMap.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblMap_LinkClicked);
            // 
            // lblMatchtype
            // 
            this.lblMatchtype.AutoSize = true;
            this.lblMatchtype.LinkColor = System.Drawing.SystemColors.ControlText;
            this.lblMatchtype.Location = new System.Drawing.Point(116, 51);
            this.lblMatchtype.Name = "lblMatchtype";
            this.lblMatchtype.Size = new System.Drawing.Size(69, 13);
            this.lblMatchtype.TabIndex = 8;
            this.lblMatchtype.TabStop = true;
            this.lblMatchtype.Text = "<Matchtype>";
            this.lblMatchtype.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.lblMatchtype.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblMap_LinkClicked);
            // 
            // lblGamelength
            // 
            this.lblGamelength.Location = new System.Drawing.Point(346, 76);
            this.lblGamelength.Name = "lblGamelength";
            this.lblGamelength.Size = new System.Drawing.Size(217, 17);
            this.lblGamelength.TabIndex = 9;
            this.lblGamelength.Text = "Game Length: <Game Length>";
            this.lblGamelength.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDateTime
            // 
            this.lblDateTime.Location = new System.Drawing.Point(346, 51);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(222, 13);
            this.lblDateTime.TabIndex = 10;
            this.lblDateTime.Text = "<Date> <Time>";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPvPGamertag,
            this.colMostKilled,
            this.colMostKilledBy});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(540, 334);
            this.dataGridView1.TabIndex = 0;
            // 
            // colPvPGamertag
            // 
            this.colPvPGamertag.HeaderText = "Gamertag";
            this.colPvPGamertag.LinkColor = System.Drawing.SystemColors.ControlText;
            this.colPvPGamertag.Name = "colPvPGamertag";
            this.colPvPGamertag.ReadOnly = true;
            this.colPvPGamertag.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.colPvPGamertag.Width = 200;
            // 
            // colMostKilled
            // 
            this.colMostKilled.HeaderText = "Most Killed";
            this.colMostKilled.Name = "colMostKilled";
            this.colMostKilled.ReadOnly = true;
            this.colMostKilled.Width = 150;
            // 
            // colMostKilledBy
            // 
            this.colMostKilledBy.HeaderText = "Most Killed By";
            this.colMostKilledBy.LinkColor = System.Drawing.SystemColors.ControlText;
            this.colMostKilledBy.Name = "colMostKilledBy";
            this.colMostKilledBy.ReadOnly = true;
            this.colMostKilledBy.VisitedLinkColor = System.Drawing.SystemColors.ControlText;
            this.colMostKilledBy.Width = 150;
            // 
            // BungieGameViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 510);
            this.Controls.Add(this.lblDateTime);
            this.Controls.Add(this.lblGamelength);
            this.Controls.Add(this.lblMatchtype);
            this.Controls.Add(this.lblMap);
            this.Controls.Add(this.lblPlaylist);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
            this.Name = "BungieGameViewer";
            this.Text = "Bungie Style Game Viewer";
            this.Load += new System.EventHandler(this.BungieGameViewer_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStats)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKDAS)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.DataGridView dgvStats;
        private System.Windows.Forms.DataGridViewLinkColumn colGamertag;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStat1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStat2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScore;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel lblPlaylist;
        private System.Windows.Forms.LinkLabel lblMap;
        private System.Windows.Forms.LinkLabel lblMatchtype;
        private System.Windows.Forms.Label lblGamelength;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.DataGridView dgvKDAS;
        private System.Windows.Forms.DataGridViewLinkColumn colKillsGamertag;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKills;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeaths;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssists;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSuicides;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewLinkColumn colPvPGamertag;
        private System.Windows.Forms.DataGridViewLinkColumn colMostKilled;
        private System.Windows.Forms.DataGridViewLinkColumn colMostKilledBy;
    }
}