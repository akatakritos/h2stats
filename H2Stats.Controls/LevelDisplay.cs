using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace H2Stats.Controls
{
    public partial class LevelDisplay : UserControl
    {
        string filename;
        int percent;
        public LevelDisplay(string imageFilename, string playlistName, int percent)
        {
            InitializeComponent();
            imgLevelIcon.Image = Image.FromFile(imageFilename);
            lblAbbreviation.Text = playlistName;//.Substring(0, 3);
            lblPercent.Text = percent.ToString() + "%";
        }

        /// <summary>
        /// For designer support.
        /// </summary>
        public LevelDisplay()
        {
            InitializeComponent();
        }

        public string FileName
        {
            get
            {
                return filename;
            }

            set
            {
                filename = value;
                imgLevelIcon.Image.Dispose();
                imgLevelIcon.Image = Image.FromFile(value);
            }
        }

        public string PlaylistName
        {
            get
            {
                return lblAbbreviation.Text;
            }

            set
            {
                lblAbbreviation.Text = value;//.Substring(0, 3);
            }
        }

        public int Percent
        {
            get { return percent; }
            set
            {
                percent = value;
                this.lblPercent.Text = value.ToString() + "%";
            }
        }
    }
}
