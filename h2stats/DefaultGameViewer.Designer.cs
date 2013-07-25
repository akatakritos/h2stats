namespace H2Stats
{
    partial class DefaultGameViewer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imgMap = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tChart1 = new Steema.TeeChart.TChart();
            this.grpMedals = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pie1 = new Steema.TeeChart.Styles.Pie();
            this.lblBetrayals = new H2Stats.Controls.StatLabel();
            this.lblMostKilled = new H2Stats.Controls.StatLabel();
            this.lblMostKilledBy = new H2Stats.Controls.StatLabel();
            this.pnlMedals = new H2Stats.Controls.MedalDisplayPanel();
            this.lblPercentHeadshots = new H2Stats.Controls.StatLabel();
            this.lblHeadshots = new H2Stats.Controls.StatLabel();
            this.lblAccuracy = new H2Stats.Controls.StatLabel();
            this.lblShotsFired = new H2Stats.Controls.StatLabel();
            this.lblShotsHit = new H2Stats.Controls.StatLabel();
            this.lblKpMin = new H2Stats.Controls.StatLabel();
            this.lblKpD = new H2Stats.Controls.StatLabel();
            this.lblSuicides = new H2Stats.Controls.StatLabel();
            this.lblAssists = new H2Stats.Controls.StatLabel();
            this.lblDeaths = new H2Stats.Controls.StatLabel();
            this.lblKills = new H2Stats.Controls.StatLabel();
            this.lblMap = new H2Stats.Controls.LinkedStatLabel();
            this.lblDuration = new H2Stats.Controls.StatLabel();
            this.lblTime = new H2Stats.Controls.StatLabel();
            this.lblDate = new H2Stats.Controls.StatLabel();
            this.lblPlaylist = new H2Stats.Controls.LinkedStatLabel();
            this.lblGametype = new H2Stats.Controls.LinkedStatLabel();
            this.lblMatchtype = new H2Stats.Controls.LinkedStatLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgMap)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpMedals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.lblMatchtype);
            this.panel1.Controls.Add(this.lblGametype);
            this.panel1.Controls.Add(this.lblPlaylist);
            this.panel1.Controls.Add(this.lblMap);
            this.panel1.Controls.Add(this.lblDuration);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.imgMap);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(570, 88);
            this.panel1.TabIndex = 0;
            // 
            // imgMap
            // 
            this.imgMap.Location = new System.Drawing.Point(4, 4);
            this.imgMap.Name = "imgMap";
            this.imgMap.Size = new System.Drawing.Size(87, 75);
            this.imgMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgMap.TabIndex = 0;
            this.imgMap.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tChart1);
            this.groupBox1.Controls.Add(this.lblBetrayals);
            this.groupBox1.Controls.Add(this.lblMostKilled);
            this.groupBox1.Controls.Add(this.lblMostKilledBy);
            this.groupBox1.Controls.Add(this.grpMedals);
            this.groupBox1.Controls.Add(this.lblPercentHeadshots);
            this.groupBox1.Controls.Add(this.lblHeadshots);
            this.groupBox1.Controls.Add(this.lblAccuracy);
            this.groupBox1.Controls.Add(this.lblShotsFired);
            this.groupBox1.Controls.Add(this.lblShotsHit);
            this.groupBox1.Controls.Add(this.lblKpMin);
            this.groupBox1.Controls.Add(this.lblKpD);
            this.groupBox1.Controls.Add(this.lblSuicides);
            this.groupBox1.Controls.Add(this.lblAssists);
            this.groupBox1.Controls.Add(this.lblDeaths);
            this.groupBox1.Controls.Add(this.lblKills);
            this.groupBox1.Location = new System.Drawing.Point(11, 183);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 395);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Details:";
            // 
            // tChart1
            // 
            // 
            // 
            // 
            this.tChart1.Aspect.Elevation = 315;
            this.tChart1.Aspect.ElevationFloat = 315;
            this.tChart1.Aspect.Orthogonal = false;
            this.tChart1.Aspect.Perspective = 0;
            this.tChart1.Aspect.Rotation = 360;
            this.tChart1.Aspect.RotationFloat = 360;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Automatic = true;
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Bottom.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Automatic = true;
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Depth.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Automatic = true;
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.DepthTop.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Left.Automatic = true;
            // 
            // 
            // 
            this.tChart1.Axes.Left.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Left.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Left.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Left.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Left.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Right.Automatic = true;
            // 
            // 
            // 
            this.tChart1.Axes.Right.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Right.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Right.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Right.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Right.Title.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Top.Automatic = true;
            // 
            // 
            // 
            this.tChart1.Axes.Top.Grid.ZPosition = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Top.Labels.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Top.Labels.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Axes.Top.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Axes.Top.Title.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Footer.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Footer.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Header.Font.Shadow.Visible = false;
            this.tChart1.Header.Lines = new string[] {
        "Kill Types"};
            // 
            // 
            // 
            this.tChart1.Header.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Legend.Font.Shadow.Visible = false;
            this.tChart1.Legend.TextStyle = Steema.TeeChart.LegendTextStyles.RightValue;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Legend.Title.Font.Bold = true;
            // 
            // 
            // 
            this.tChart1.Legend.Title.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Legend.Title.Pen.Visible = false;
            // 
            // 
            // 
            this.tChart1.Legend.Title.Shadow.Visible = false;
            this.tChart1.Location = new System.Drawing.Point(108, 145);
            this.tChart1.Name = "tChart1";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Panel.Bevel.Outer = Steema.TeeChart.Drawing.BevelStyles.None;
            // 
            // 
            // 
            this.tChart1.Panel.ImageBevel.Width = 1;
            // 
            // 
            // 
            this.tChart1.Panel.Shadow.Visible = false;
            this.tChart1.Series.Add(this.pie1);
            this.tChart1.Size = new System.Drawing.Size(454, 244);
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.SubFooter.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.SubFooter.Shadow.Visible = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.SubHeader.Font.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.SubHeader.Shadow.Visible = false;
            this.tChart1.TabIndex = 15;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart1.Walls.Back.AutoHide = false;
            // 
            // 
            // 
            this.tChart1.Walls.Back.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Walls.Bottom.AutoHide = false;
            // 
            // 
            // 
            this.tChart1.Walls.Bottom.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Walls.Left.AutoHide = false;
            // 
            // 
            // 
            this.tChart1.Walls.Left.Shadow.Visible = false;
            // 
            // 
            // 
            this.tChart1.Walls.Right.AutoHide = false;
            // 
            // 
            // 
            this.tChart1.Walls.Right.Shadow.Visible = false;
            // 
            // grpMedals
            // 
            this.grpMedals.Controls.Add(this.pnlMedals);
            this.grpMedals.Location = new System.Drawing.Point(262, 18);
            this.grpMedals.Name = "grpMedals";
            this.grpMedals.Size = new System.Drawing.Size(303, 100);
            this.grpMedals.TabIndex = 11;
            this.grpMedals.TabStop = false;
            this.grpMedals.Text = "Medals: 0";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView1.Location = new System.Drawing.Point(11, 106);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(571, 71);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Gamertag";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column2.HeaderText = "Place";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 75;
            // 
            // Column3
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3.HeaderText = "Stat1";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column4.HeaderText = "Stat2";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column5.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column5.HeaderText = "Score";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // pie1
            // 
            // 
            // 
            // 
            this.pie1.Brush.Color = System.Drawing.Color.Red;
            this.pie1.Circled = true;
            this.pie1.LabelMember = "Labels";
            new Steema.TeeChart.Styles.StringList().Add("Cars");
            new Steema.TeeChart.Styles.StringList().Add("Phones");
            new Steema.TeeChart.Styles.StringList().Add("Tables");
            new Steema.TeeChart.Styles.StringList().Add("Monitors");
            new Steema.TeeChart.Styles.StringList().Add("Lamps");
            new Steema.TeeChart.Styles.StringList().Add("Keyboards");
            new Steema.TeeChart.Styles.StringList().Add("Bikes");
            new Steema.TeeChart.Styles.StringList().Add("Chairs");
            // 
            // 
            // 
            // 
            // 
            // 
            this.pie1.Marks.Callout.ArrowHead = Steema.TeeChart.Styles.ArrowHeadStyles.None;
            this.pie1.Marks.Callout.ArrowHeadSize = 8;
            // 
            // 
            // 
            this.pie1.Marks.Callout.Brush.Color = System.Drawing.Color.Black;
            this.pie1.Marks.Callout.Distance = 0;
            this.pie1.Marks.Callout.Draw3D = false;
            this.pie1.Marks.Callout.Length = 8;
            this.pie1.Marks.Callout.Style = Steema.TeeChart.Styles.PointerStyles.Rectangle;
            // 
            // 
            // 
            // 
            // 
            // 
            this.pie1.Marks.Font.Shadow.Visible = false;
            this.pie1.Marks.Style = Steema.TeeChart.Styles.MarksStyles.Percent;
            // 
            // 
            // 
            this.pie1.Shadow.Height = 20;
            this.pie1.Shadow.Width = 20;
            this.pie1.Title = "pie1";
            // 
            // 
            // 
            this.pie1.XValues.DataMember = "Angle";
            this.pie1.XValues.Order = Steema.TeeChart.Styles.ValueListOrder.Ascending;
            // 
            // 
            // 
            this.pie1.YValues.DataMember = "Pie";
            // 
            // lblBetrayals
            // 
            this.lblBetrayals.AutoSize = true;
            this.lblBetrayals.Description = "Betrayals";
            this.lblBetrayals.Location = new System.Drawing.Point(7, 88);
            this.lblBetrayals.Name = "lblBetrayals";
            this.lblBetrayals.Size = new System.Drawing.Size(62, 13);
            this.lblBetrayals.TabIndex = 14;
            this.lblBetrayals.Text = "Betrayals: 0";
            this.lblBetrayals.Value = 0;
            // 
            // lblMostKilled
            // 
            this.lblMostKilled.AutoSize = true;
            this.lblMostKilled.Description = "Most Killed";
            this.lblMostKilled.Location = new System.Drawing.Point(108, 105);
            this.lblMostKilled.Name = "lblMostKilled";
            this.lblMostKilled.Size = new System.Drawing.Size(70, 13);
            this.lblMostKilled.TabIndex = 13;
            this.lblMostKilled.Text = "Most Killed: 0";
            this.lblMostKilled.Value = 0;
            // 
            // lblMostKilledBy
            // 
            this.lblMostKilledBy.AutoSize = true;
            this.lblMostKilledBy.Description = "Most Killed By";
            this.lblMostKilledBy.Location = new System.Drawing.Point(108, 122);
            this.lblMostKilledBy.Name = "lblMostKilledBy";
            this.lblMostKilledBy.Size = new System.Drawing.Size(85, 13);
            this.lblMostKilledBy.TabIndex = 12;
            this.lblMostKilledBy.Text = "Most Killed By: 0";
            this.lblMostKilledBy.Value = 0;
            // 
            // pnlMedals
            // 
            this.pnlMedals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMedals.Location = new System.Drawing.Point(3, 16);
            this.pnlMedals.Name = "pnlMedals";
            this.pnlMedals.Size = new System.Drawing.Size(297, 81);
            this.pnlMedals.TabIndex = 0;
            // 
            // lblPercentHeadshots
            // 
            this.lblPercentHeadshots.AutoSize = true;
            this.lblPercentHeadshots.Description = "% Headshots";
            this.lblPercentHeadshots.Location = new System.Drawing.Point(108, 88);
            this.lblPercentHeadshots.Name = "lblPercentHeadshots";
            this.lblPercentHeadshots.Size = new System.Drawing.Size(81, 13);
            this.lblPercentHeadshots.TabIndex = 10;
            this.lblPercentHeadshots.Text = "% Headshots: 0";
            this.lblPercentHeadshots.Value = 0;
            // 
            // lblHeadshots
            // 
            this.lblHeadshots.AutoSize = true;
            this.lblHeadshots.Description = "Headshots";
            this.lblHeadshots.Location = new System.Drawing.Point(105, 71);
            this.lblHeadshots.Name = "lblHeadshots";
            this.lblHeadshots.Size = new System.Drawing.Size(70, 13);
            this.lblHeadshots.TabIndex = 9;
            this.lblHeadshots.Text = "Headshots: 0";
            this.lblHeadshots.Value = 0;
            // 
            // lblAccuracy
            // 
            this.lblAccuracy.AutoSize = true;
            this.lblAccuracy.Description = "Accuracy";
            this.lblAccuracy.Location = new System.Drawing.Point(105, 54);
            this.lblAccuracy.Name = "lblAccuracy";
            this.lblAccuracy.Size = new System.Drawing.Size(64, 13);
            this.lblAccuracy.TabIndex = 8;
            this.lblAccuracy.Text = "Accuracy: 0";
            this.lblAccuracy.Value = 0;
            // 
            // lblShotsFired
            // 
            this.lblShotsFired.AutoSize = true;
            this.lblShotsFired.Description = "Shots Fired";
            this.lblShotsFired.Location = new System.Drawing.Point(105, 37);
            this.lblShotsFired.Name = "lblShotsFired";
            this.lblShotsFired.Size = new System.Drawing.Size(72, 13);
            this.lblShotsFired.TabIndex = 7;
            this.lblShotsFired.Text = "Shots Fired: 0";
            this.lblShotsFired.Value = 0;
            // 
            // lblShotsHit
            // 
            this.lblShotsHit.AutoSize = true;
            this.lblShotsHit.Description = "Shots Hit";
            this.lblShotsHit.Location = new System.Drawing.Point(105, 20);
            this.lblShotsHit.Name = "lblShotsHit";
            this.lblShotsHit.Size = new System.Drawing.Size(62, 13);
            this.lblShotsHit.TabIndex = 6;
            this.lblShotsHit.Text = "Shots Hit: 0";
            this.lblShotsHit.Value = 0;
            // 
            // lblKpMin
            // 
            this.lblKpMin.AutoSize = true;
            this.lblKpMin.Description = "KpMin";
            this.lblKpMin.Location = new System.Drawing.Point(7, 122);
            this.lblKpMin.Name = "lblKpMin";
            this.lblKpMin.Size = new System.Drawing.Size(49, 13);
            this.lblKpMin.TabIndex = 5;
            this.lblKpMin.Text = "KpMin: 0";
            this.lblKpMin.Value = 0;
            // 
            // lblKpD
            // 
            this.lblKpD.AutoSize = true;
            this.lblKpD.Description = "KpD";
            this.lblKpD.Location = new System.Drawing.Point(7, 105);
            this.lblKpD.Name = "lblKpD";
            this.lblKpD.Size = new System.Drawing.Size(40, 13);
            this.lblKpD.TabIndex = 4;
            this.lblKpD.Text = "KpD: 0";
            this.lblKpD.Value = 0;
            // 
            // lblSuicides
            // 
            this.lblSuicides.AutoSize = true;
            this.lblSuicides.Description = "Suicides";
            this.lblSuicides.Location = new System.Drawing.Point(7, 71);
            this.lblSuicides.Name = "lblSuicides";
            this.lblSuicides.Size = new System.Drawing.Size(59, 13);
            this.lblSuicides.TabIndex = 3;
            this.lblSuicides.Text = "Suicides: 0";
            this.lblSuicides.Value = 0;
            // 
            // lblAssists
            // 
            this.lblAssists.AutoSize = true;
            this.lblAssists.Description = "Assists";
            this.lblAssists.Location = new System.Drawing.Point(7, 54);
            this.lblAssists.Name = "lblAssists";
            this.lblAssists.Size = new System.Drawing.Size(51, 13);
            this.lblAssists.TabIndex = 2;
            this.lblAssists.Text = "Assists: 0";
            this.lblAssists.Value = 0;
            // 
            // lblDeaths
            // 
            this.lblDeaths.AutoSize = true;
            this.lblDeaths.Description = "Deaths";
            this.lblDeaths.Location = new System.Drawing.Point(7, 37);
            this.lblDeaths.Name = "lblDeaths";
            this.lblDeaths.Size = new System.Drawing.Size(53, 13);
            this.lblDeaths.TabIndex = 1;
            this.lblDeaths.Text = "Deaths: 0";
            this.lblDeaths.Value = 0;
            // 
            // lblKills
            // 
            this.lblKills.AutoSize = true;
            this.lblKills.Description = "Kills";
            this.lblKills.Location = new System.Drawing.Point(7, 20);
            this.lblKills.Name = "lblKills";
            this.lblKills.Size = new System.Drawing.Size(37, 13);
            this.lblKills.TabIndex = 0;
            this.lblKills.Text = "Kills: 0";
            this.lblKills.Value = 0;
            // 
            // lblMap
            // 
            this.lblMap.AutoSize = true;
            this.lblMap.Description = "Map";
            this.lblMap.LinkArea = new System.Windows.Forms.LinkArea(5, 1);
            this.lblMap.LinkColor = System.Drawing.SystemColors.ControlText;
            this.lblMap.Location = new System.Drawing.Point(243, 4);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(39, 17);
            this.lblMap.TabIndex = 8;
            this.lblMap.TabStop = true;
            this.lblMap.Text = "Map: 0";
            this.lblMap.Url = "http://www.google.com";
            this.lblMap.UseCompatibleTextRendering = true;
            this.lblMap.Value = 0;
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Description = "Duration";
            this.lblDuration.Location = new System.Drawing.Point(412, 44);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(59, 13);
            this.lblDuration.TabIndex = 7;
            this.lblDuration.Text = "Duration: 0";
            this.lblDuration.Value = 0;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Description = "Time";
            this.lblTime.Location = new System.Drawing.Point(412, 24);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(42, 13);
            this.lblTime.TabIndex = 6;
            this.lblTime.Text = "Time: 0";
            this.lblTime.Value = 0;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Description = "Date";
            this.lblDate.Location = new System.Drawing.Point(412, 4);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(42, 13);
            this.lblDate.TabIndex = 5;
            this.lblDate.Text = "Date: 0";
            this.lblDate.Value = 0;
            // 
            // lblPlaylist
            // 
            this.lblPlaylist.AutoSize = true;
            this.lblPlaylist.Description = "Playlist";
            this.lblPlaylist.LinkArea = new System.Windows.Forms.LinkArea(10, 1);
            this.lblPlaylist.LinkColor = System.Drawing.SystemColors.ControlText;
            this.lblPlaylist.Location = new System.Drawing.Point(243, 24);
            this.lblPlaylist.Name = "lblPlaylist";
            this.lblPlaylist.Size = new System.Drawing.Size(53, 17);
            this.lblPlaylist.TabIndex = 9;
            this.lblPlaylist.TabStop = true;
            this.lblPlaylist.Text = "Playlist: 0";
            this.lblPlaylist.UseCompatibleTextRendering = true;
            this.lblPlaylist.Value = 0;
            // 
            // lblGametype
            // 
            this.lblGametype.AutoSize = true;
            this.lblGametype.Description = "Gametype";
            this.lblGametype.LinkArea = new System.Windows.Forms.LinkArea(10, 1);
            this.lblGametype.LinkColor = System.Drawing.SystemColors.ControlText;
            this.lblGametype.Location = new System.Drawing.Point(243, 44);
            this.lblGametype.Name = "lblGametype";
            this.lblGametype.Size = new System.Drawing.Size(69, 17);
            this.lblGametype.TabIndex = 10;
            this.lblGametype.TabStop = true;
            this.lblGametype.Text = "Gametype: 0";
            this.lblGametype.UseCompatibleTextRendering = true;
            this.lblGametype.Value = 0;
            // 
            // lblMatchtype
            // 
            this.lblMatchtype.AutoSize = true;
            this.lblMatchtype.Description = "Matchtype";
            this.lblMatchtype.LinkArea = new System.Windows.Forms.LinkArea(11, 1);
            this.lblMatchtype.LinkColor = System.Drawing.SystemColors.ControlText;
            this.lblMatchtype.Location = new System.Drawing.Point(243, 64);
            this.lblMatchtype.Name = "lblMatchtype";
            this.lblMatchtype.Size = new System.Drawing.Size(69, 17);
            this.lblMatchtype.TabIndex = 11;
            this.lblMatchtype.TabStop = true;
            this.lblMatchtype.Text = "Matchtype: 0";
            this.lblMatchtype.UseCompatibleTextRendering = true;
            this.lblMatchtype.Value = 0;
            // 
            // DefaultGameViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 595);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "DefaultGameViewer";
            this.Text = "Game Viewer";
            this.Shown += new System.EventHandler(this.DefaultGameViewer_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgMap)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpMedals.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox imgMap;
        private H2Stats.Controls.StatLabel lblDuration;
        private H2Stats.Controls.StatLabel lblTime;
        private H2Stats.Controls.StatLabel lblDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private H2Stats.Controls.StatLabel lblPercentHeadshots;
        private H2Stats.Controls.StatLabel lblHeadshots;
        private H2Stats.Controls.StatLabel lblAccuracy;
        private H2Stats.Controls.StatLabel lblShotsFired;
        private H2Stats.Controls.StatLabel lblShotsHit;
        private H2Stats.Controls.StatLabel lblKpMin;
        private H2Stats.Controls.StatLabel lblKpD;
        private H2Stats.Controls.StatLabel lblSuicides;
        private H2Stats.Controls.StatLabel lblAssists;
        private H2Stats.Controls.StatLabel lblDeaths;
        private H2Stats.Controls.StatLabel lblKills;
        private System.Windows.Forms.GroupBox grpMedals;
        private H2Stats.Controls.MedalDisplayPanel pnlMedals;
        private H2Stats.Controls.StatLabel lblBetrayals;
        private H2Stats.Controls.StatLabel lblMostKilled;
        private H2Stats.Controls.StatLabel lblMostKilledBy;
        private Steema.TeeChart.TChart tChart1;
        private Steema.TeeChart.Styles.Pie pie1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private H2Stats.Controls.LinkedStatLabel lblMap;
        private H2Stats.Controls.LinkedStatLabel lblMatchtype;
        private H2Stats.Controls.LinkedStatLabel lblGametype;
        private H2Stats.Controls.LinkedStatLabel lblPlaylist;
    }
}