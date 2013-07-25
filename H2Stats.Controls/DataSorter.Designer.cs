namespace H2Stats.Controls
{
    partial class DataSorter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbMaps = new System.Windows.Forms.ListBox();
            this.lbGametypes = new System.Windows.Forms.ListBox();
            this.lbPlaylists = new System.Windows.Forms.ListBox();
            this.mnuPlaylistSelection = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miSelectRanked = new System.Windows.Forms.ToolStripMenuItem();
            this.miSelectUnranked = new System.Windows.Forms.ToolStripMenuItem();
            this.miSelectCurrent = new System.Windows.Forms.ToolStripMenuItem();
            this.lbMatchtypes = new System.Windows.Forms.ListBox();
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lbDates = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblLoading = new System.Windows.Forms.Label();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mnuPlaylistSelection.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Map:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Location = new System.Drawing.Point(158, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Playlist:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Location = new System.Drawing.Point(313, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Gametype:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Location = new System.Drawing.Point(468, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Matchtype:";
            // 
            // lbMaps
            // 
            this.lbMaps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMaps.FormattingEnabled = true;
            this.lbMaps.Location = new System.Drawing.Point(3, 23);
            this.lbMaps.Name = "lbMaps";
            this.lbMaps.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbMaps.Size = new System.Drawing.Size(149, 121);
            this.lbMaps.TabIndex = 5;
            // 
            // lbGametypes
            // 
            this.lbGametypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbGametypes.FormattingEnabled = true;
            this.lbGametypes.Location = new System.Drawing.Point(313, 23);
            this.lbGametypes.Name = "lbGametypes";
            this.lbGametypes.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbGametypes.Size = new System.Drawing.Size(149, 121);
            this.lbGametypes.TabIndex = 6;
            // 
            // lbPlaylists
            // 
            this.lbPlaylists.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPlaylists.ContextMenuStrip = this.mnuPlaylistSelection;
            this.lbPlaylists.FormattingEnabled = true;
            this.lbPlaylists.Location = new System.Drawing.Point(158, 23);
            this.lbPlaylists.Name = "lbPlaylists";
            this.lbPlaylists.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbPlaylists.Size = new System.Drawing.Size(149, 121);
            this.lbPlaylists.TabIndex = 7;
            // 
            // mnuPlaylistSelection
            // 
            this.mnuPlaylistSelection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSelectRanked,
            this.miSelectUnranked,
            this.miSelectCurrent});
            this.mnuPlaylistSelection.Name = "mnuPlaylistSelection";
            this.mnuPlaylistSelection.Size = new System.Drawing.Size(164, 70);
            // 
            // miSelectRanked
            // 
            this.miSelectRanked.Name = "miSelectRanked";
            this.miSelectRanked.Size = new System.Drawing.Size(163, 22);
            this.miSelectRanked.Text = "Select Ranked";
            this.miSelectRanked.Click += new System.EventHandler(this.miSelectRanked_Click);
            // 
            // miSelectUnranked
            // 
            this.miSelectUnranked.Name = "miSelectUnranked";
            this.miSelectUnranked.Size = new System.Drawing.Size(163, 22);
            this.miSelectUnranked.Text = "Select Unranked";
            this.miSelectUnranked.Click += new System.EventHandler(this.miSelectUnranked_Click);
            // 
            // miSelectCurrent
            // 
            this.miSelectCurrent.Name = "miSelectCurrent";
            this.miSelectCurrent.Size = new System.Drawing.Size(163, 22);
            this.miSelectCurrent.Text = "Select Current";
            this.miSelectCurrent.Click += new System.EventHandler(this.miSelectCurrent_Click);
            // 
            // lbMatchtypes
            // 
            this.lbMatchtypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMatchtypes.FormattingEnabled = true;
            this.lbMatchtypes.Location = new System.Drawing.Point(468, 23);
            this.lbMatchtypes.Name = "lbMatchtypes";
            this.lbMatchtypes.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbMatchtypes.Size = new System.Drawing.Size(149, 121);
            this.lbMatchtypes.TabIndex = 8;
            // 
            // calendar
            // 
            this.calendar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.calendar.Location = new System.Drawing.Point(134, 39);
            this.calendar.MaxSelectionCount = 99999;
            this.calendar.Name = "calendar";
            this.calendar.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdd.Location = new System.Drawing.Point(324, 88);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(30, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = ">>";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRemove.Location = new System.Drawing.Point(324, 117);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(30, 23);
            this.btnRemove.TabIndex = 11;
            this.btnRemove.Text = "<<";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lbDates
            // 
            this.lbDates.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbDates.FormattingEnabled = true;
            this.lbDates.Location = new System.Drawing.Point(363, 39);
            this.lbDates.Name = "lbDates";
            this.lbDates.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbDates.Size = new System.Drawing.Size(120, 160);
            this.lbDates.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(131, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Date:";
            // 
            // lblLoading
            // 
            this.lblLoading.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblLoading.AutoSize = true;
            this.lblLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoading.Location = new System.Drawing.Point(266, 12);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(82, 18);
            this.lblLoading.TabIndex = 14;
            this.lblLoading.Text = "Loading...";
            this.lblLoading.Visible = false;
            // 
            // worker
            // 
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbPlaylists, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbGametypes, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbMatchtypes, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbMaps, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.71429F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.28571F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(620, 398);
            this.tableLayoutPanel1.TabIndex = 15;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 4);
            this.panel1.Controls.Add(this.lblLoading);
            this.panel1.Controls.Add(this.calendar);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Controls.Add(this.lbDates);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 158);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(614, 237);
            this.panel1.TabIndex = 9;
            // 
            // DataSorter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DataSorter";
            this.Size = new System.Drawing.Size(628, 407);
            this.mnuPlaylistSelection.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbMaps;
        private System.Windows.Forms.ListBox lbGametypes;
        private System.Windows.Forms.ListBox lbPlaylists;
        private System.Windows.Forms.ListBox lbMatchtypes;
        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListBox lbDates;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblLoading;
        private System.ComponentModel.BackgroundWorker worker;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip mnuPlaylistSelection;
        private System.Windows.Forms.ToolStripMenuItem miSelectRanked;
        private System.Windows.Forms.ToolStripMenuItem miSelectUnranked;
        private System.Windows.Forms.ToolStripMenuItem miSelectCurrent;
    }
}
