namespace H2Stats.Controls
{
    partial class LevelDisplay
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
            this.imgLevelIcon = new System.Windows.Forms.PictureBox();
            this.lblAbbreviation = new System.Windows.Forms.Label();
            this.lblPercent = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgLevelIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // imgLevelIcon
            // 
            this.imgLevelIcon.Location = new System.Drawing.Point(3, 0);
            this.imgLevelIcon.Name = "imgLevelIcon";
            this.imgLevelIcon.Size = new System.Drawing.Size(36, 32);
            this.imgLevelIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgLevelIcon.TabIndex = 0;
            this.imgLevelIcon.TabStop = false;
            // 
            // lblAbbreviation
            // 
            this.lblAbbreviation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblAbbreviation.Location = new System.Drawing.Point(0, 35);
            this.lblAbbreviation.Name = "lblAbbreviation";
            this.lblAbbreviation.Size = new System.Drawing.Size(78, 32);
            this.lblAbbreviation.TabIndex = 1;
            this.lblAbbreviation.Text = "<Playlist Name Here>";
            this.lblAbbreviation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPercent
            // 
            this.lblPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercent.Location = new System.Drawing.Point(40, 0);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(35, 32);
            this.lblPercent.TabIndex = 2;
            this.lblPercent.Text = "99%";
            this.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LevelDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.lblAbbreviation);
            this.Controls.Add(this.imgLevelIcon);
            this.Name = "LevelDisplay";
            this.Size = new System.Drawing.Size(78, 67);
            ((System.ComponentModel.ISupportInitialize)(this.imgLevelIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgLevelIcon;
        private System.Windows.Forms.Label lblAbbreviation;
        private System.Windows.Forms.Label lblPercent;
    }
}
