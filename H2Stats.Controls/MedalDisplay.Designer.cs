namespace H2Stats.Controls
{
    partial class MedalDisplay
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
            this.imgMedal = new System.Windows.Forms.PictureBox();
            this.lblCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgMedal)).BeginInit();
            this.SuspendLayout();
            // 
            // imgMedal
            // 
            this.imgMedal.Location = new System.Drawing.Point(0, 2);
            this.imgMedal.Name = "imgMedal";
            this.imgMedal.Size = new System.Drawing.Size(31, 27);
            this.imgMedal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgMedal.TabIndex = 0;
            this.imgMedal.TabStop = false;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(32, 10);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(13, 13);
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "0";
            // 
            // MedalDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.imgMedal);
            this.Name = "MedalDisplay";
            this.Size = new System.Drawing.Size(69, 32);
            ((System.ComponentModel.ISupportInitialize)(this.imgMedal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox imgMedal;
        private System.Windows.Forms.Label lblCount;
    }
}
