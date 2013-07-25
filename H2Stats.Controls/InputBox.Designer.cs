namespace H2Stats.Controls
{
    public partial class InputBox
    {
        partial class frmInputBox
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
                this.lblDescription = new System.Windows.Forms.Label();
                this.textBox1 = new System.Windows.Forms.TextBox();
                this.btnOK = new System.Windows.Forms.Button();
                this.btnCancel = new System.Windows.Forms.Button();
                this.SuspendLayout();
                // 
                // lblDescription
                // 
                this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.lblDescription.Location = new System.Drawing.Point(13, 7);
                this.lblDescription.Name = "lblDescription";
                this.lblDescription.Size = new System.Drawing.Size(306, 38);
                this.lblDescription.TabIndex = 0;
                this.lblDescription.Text = "Description";
                // 
                // textBox1
                // 
                this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
                this.textBox1.Location = new System.Drawing.Point(16, 48);
                this.textBox1.Name = "textBox1";
                this.textBox1.Size = new System.Drawing.Size(306, 20);
                this.textBox1.TabIndex = 1;
                // 
                // btnOK
                // 
                this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
                this.btnOK.Location = new System.Drawing.Point(82, 74);
                this.btnOK.Name = "btnOK";
                this.btnOK.Size = new System.Drawing.Size(75, 23);
                this.btnOK.TabIndex = 2;
                this.btnOK.Text = "OK";
                this.btnOK.UseVisualStyleBackColor = true;
                // 
                // btnCancel
                // 
                this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
                this.btnCancel.Location = new System.Drawing.Point(173, 74);
                this.btnCancel.Name = "btnCancel";
                this.btnCancel.Size = new System.Drawing.Size(75, 23);
                this.btnCancel.TabIndex = 3;
                this.btnCancel.Text = "Cancel";
                this.btnCancel.UseVisualStyleBackColor = true;
                // 
                // frmInputBox
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(331, 110);
                this.Controls.Add(this.btnCancel);
                this.Controls.Add(this.btnOK);
                this.Controls.Add(this.textBox1);
                this.Controls.Add(this.lblDescription);
                this.Name = "frmInputBox";
                this.Text = "Input";
                this.ResumeLayout(false);
                this.PerformLayout();

            }

            #endregion

            private System.Windows.Forms.Label lblDescription;
            private System.Windows.Forms.TextBox textBox1;
            private System.Windows.Forms.Button btnOK;
            private System.Windows.Forms.Button btnCancel;
        }
    }
}