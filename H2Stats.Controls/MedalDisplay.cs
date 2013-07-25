using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace H2Stats.Controls
{
    public partial class MedalDisplay : UserControl
    {
        private int count;
        public MedalDisplay()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the medal count
        /// </summary>
        [Browsable(true)]
        public int Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
                this.lblCount.Text = count.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the underlying PictureBox's image
        /// </summary>
        [Browsable(true)]
        public Image Image
        {
            get { return this.imgMedal.Image; }
            set { this.imgMedal.Image = value; }
        }
    }
}
