using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace H2Stats
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            float simplified = Properties.Settings.Default.TotalBytesDL;
            string fmt = "KB";

            if (Properties.Settings.Default.TotalBytesDL < 1048576)
                simplified = Properties.Settings.Default.TotalBytesDL / 1024;
            else if (Properties.Settings.Default.TotalBytesDL < 1073741824)
            {
                simplified = Properties.Settings.Default.TotalBytesDL / 1048576;
                fmt = "MB";
            }
            else
            {
                simplified = Properties.Settings.Default.TotalBytesDL / 1073741824;
                fmt = "GB";
            }

            label3.Text = string.Format("{0:0,0} bytes ({1:#.##} {2}) downloaded", Properties.Settings.Default.TotalBytesDL, simplified, fmt);
            label4.Text = Properties.Settings.Default.GamesDL.ToString() + " games downloaded";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}