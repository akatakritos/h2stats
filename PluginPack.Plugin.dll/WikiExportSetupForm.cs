using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CoBPack.Plugin
{
    public partial class WikiExportSetupForm : Form
    {
        public WikiExportSetupForm()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                txtFilename.Text = saveDlg.FileName;
            }
        }

        private void chkFile_CheckedChanged(object sender, EventArgs e)
        {
            txtFilename.Enabled = btnBrowse.Enabled = chkFile.Checked;
        }

        /// <summary>
        /// Returns the filename to save wiki code to. Empty string if user opted out
        /// </summary>
        public string FileName
        {
            get
            {
                if (chkFile.Checked)
                    return txtFilename.Text;
                else
                    return "";
            }
        }

        /// <summary>
        /// Gets a value indicating if results should be copied to the clipboard
        /// </summary>
        public bool CopyToClipboard
        {
            get { return chkClipboard.Checked; }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (!chkClipboard.Checked && !chkFile.Checked)
            {
                DialogResult rslt = MessageBox.Show("You have not chosen any destinations. Do you really want to cancel?",
                    "No destinations chosen.", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (rslt == DialogResult.Yes)
                {
                    this.DialogResult = DialogResult.Cancel;
                    Close();
                }
                else
                    return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}