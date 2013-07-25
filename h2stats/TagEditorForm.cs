using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using H2Stats.Data;
using H2Stats.Data.HaloDataSetTableAdapters;
using H2Stats.Properties;
using System.IO;

namespace H2Stats
{
    public partial class TagEditorForm : Form
    {
        HaloDataSet.TagListDataTable tagList;
        HaloDataSet.TagListRow lastSelectedRow;

        public TagEditorForm(HaloDataSet.TagListDataTable tagList)
        {
            InitializeComponent();
            this.tagList = tagList;
            
            foreach (HaloDataSet.TagListRow row in tagList)
            {
                lbGamertags.Items.Add(row.Gamertag);
            }
        }

        private void cboGamertags_SelectedIndexChanged(object sender, EventArgs e)
        {
            HaloDataSet.TagListRow row = tagList.FindByGamertag((string)lbGamertags.SelectedItem);

            if (row != null)
            {
                saveDetails(lastSelectedRow);
                loadDetails(row);
                lastSelectedRow = row;
            }
        }

        private void saveDetails(HaloDataSet.TagListRow lastSelectedRow)
        {
            if (lastSelectedRow != null)
            {
                lastSelectedRow.Quote = txtQuote.Text;
                lastSelectedRow.SaveGameViewer = chkSaveGameViewer.Checked;
                lastSelectedRow.DownloadAll = chkDownloadAll.Checked;
            }
        }

        private void loadDetails(HaloDataSet.TagListRow row)
        {
            if (this.imgPlayerIcon.Image != null)
                this.imgPlayerIcon.Image.Dispose();

            if (File.Exists(String.Format(Application.StartupPath + @"\Images\PlayerIcons\{0}.bmp", row.Gamertag)))
            {
                imgPlayerIcon.Image = Image.FromFile(String.Format(
                    Application.StartupPath + @"\Images\PlayerIcons\{0}.bmp", row.Gamertag));
            }

            try
            {
                chkDownloadAll.Checked = row.DownloadAll;
            }
            catch (StrongTypingException)
            {
                chkDownloadAll.Checked = true;
                row.DownloadAll = true;
            }

            try
            {
                chkSaveGameViewer.Checked = row.SaveGameViewer;
            }
            catch (StrongTypingException)
            {
                chkSaveGameViewer.Checked = true;
                row.SaveGameViewer = true;
            }

            try
            {
                txtQuote.Text = row.Quote;
            }
            catch (StrongTypingException)
            {
                txtQuote.Text = String.Empty;
                row.Quote = String.Empty;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lbGamertags.Items.Contains(txtNewTag.Text))
            {
                errorProvider1.SetError(txtNewTag, "This gamertag already exists in your gamertag collection.");
            }
            else
            {
                addTag(txtNewTag.Text);
                txtNewTag.Clear();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                TagListTableAdapter adapter = new TagListTableAdapter();
                adapter.Update(this.tagList);
                adapter.Dispose();
                tagList.Dispose();
                this.Close();
            }
            catch (System.Data.OleDb.OleDbException ex)
            {
                MessageBox.Show(ex.Message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            tagList.Dispose();
        }

        private void btnRemoveTag_Click(object sender, EventArgs e)
        {
            string gamertag = (string)lbGamertags.SelectedItem;
            
            if (gamertag == null)
                return;

            DialogResult rslt = MessageBox.Show(String.Format("Are you sure you want to remove\r\n{0} from your collection?", gamertag),
                "Confirm Removal...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rslt == DialogResult.Yes)
            {
                HaloDataSet.TagListRow row = tagList.FindByGamertag(gamertag);
                row.Delete();
                lbGamertags.Items.Remove(gamertag);
                lastSelectedRow = null;
                if (lbGamertags.Items.Count > 0)
                    lbGamertags.SelectedIndex = 0;
                else
                {
                    imgPlayerIcon.Image.Dispose();
                    imgPlayerIcon.Image = imgPlayerIcon.InitialImage;
                }
            }
        }

        private void btnAddMany_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder sBuilder = new StringBuilder(txtNewTags.Text);
            bool errors = false;
            foreach (string gamertag in txtNewTags.Lines)
            {
                if (lbGamertags.Items.Contains(gamertag))
                    errors = true;
                else
                {
                    addTag(gamertag);
                    sBuilder.Replace(gamertag, "");
                }
            }

            if (errors)
            {
                errorProvider1.SetError(txtNewTags, "These gamertags already existed in your collection.");
                txtNewTags.Text = sBuilder.ToString().Trim();
            }
            else
                txtNewTags.Clear();
        }

        private void addTag(string gamertag)
        {
            HaloDataSet.TagListRow row = this.tagList.NewTagListRow();
            row.Gamertag = gamertag;
            row.DownloadAll = true;
            row.SaveGameViewer = true;
            row.Quote = "";

            tagList.AddTagListRow(row);
            lbGamertags.Items.Add(row.Gamertag);
        }

        public override string ToString()
        {
            return this.Text;
        }

    }
}