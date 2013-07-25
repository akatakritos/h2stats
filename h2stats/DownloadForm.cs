using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using H2Stats.Data;
using H2Stats.Data.HaloDataSetTableAdapters;
using H2Stats.Downloader;
using H2Stats.Controls;
using H2Stats.Properties;

namespace H2Stats
{
    public partial class DownloadForm : Form
    {
        

        public DownloadForm()
        {
            InitializeComponent();
        }

        private void DownloadForm_Shown(object sender, EventArgs e)
        {
            TagListTableAdapter tagAdapter = new TagListTableAdapter();
            HaloDataSet.TagListDataTable tagList = tagAdapter.GetData();

            cboGamertags.Items.Clear();
            foreach (HaloDataSet.TagListRow row in tagList)
            {
                cboGamertags.Items.Add(row.Gamertag);
            }
            cboGamertags.SelectedIndex = 0;
        }       

        private void cboGamertags_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlayerRankTableAdapter rankAdapter = new PlayerRankTableAdapter();
            HaloDataSet.PlayerRankDataTable playerRanks = rankAdapter.GetData((string)cboGamertags.SelectedItem);
            this.levelPanel.SetRanks(playerRanks, Application.StartupPath + @"\Images\Levels\L{0:00}.gif");
            rankAdapter.Dispose();

            if (System.IO.File.Exists(Application.StartupPath + @"\Images\PlayerIcons\" +
                (string)cboGamertags.SelectedItem + ".bmp"))
            {
                if(imgCurrentIcon.Image != null)
                    imgCurrentIcon.Image.Dispose();
                imgCurrentIcon.Image = Image.FromFile(Application.StartupPath + @"\Images\PlayerIcons\" +
                    (string)cboGamertags.SelectedItem + ".bmp");
            }

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (btnGo.Text == "Go")
            {
                chkUpdatePlaylists.Enabled = false;
                cboGamertags.Enabled = false;
                rdoAll.Enabled = false;
                rdoCurrentSelection.Enabled = false;
                btnGo.Text = "Cancel";

                List<string> tagsToDownload = new List<string>();

                if (rdoAll.Checked)
                {
                    foreach (string gamertag in cboGamertags.Items)
                        tagsToDownload.Add(gamertag);
                }
                else
                    tagsToDownload.Add((string)cboGamertags.SelectedItem);


                timer1.Enabled = true;
                worker.RunWorkerAsync(tagsToDownload);
            }
            else
            {
                lblGameMap.Text = "";
                lblStatus.Text = "Cancelling download...";
            }
        }

        private void DownloadForm_Load(object sender, EventArgs e)
        {
            this.Size = Settings.Default.DownloadFormSize;
            this.cboGamertags.SelectedItem = Settings.Default.LastViewedGamertag;
            Download.BytesDownloaded = 0;
        }

        private void DownloadForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.LastViewedGamertag = (string)cboGamertags.SelectedItem;
            Settings.Default.DownloadAll = rdoAll.Checked;
            Settings.Default.TotalBytesDL += Download.BytesDownloaded;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblBytesDL.Text = string.Format("{0:0,0} bytes downloaded.", Download.BytesDownloaded);
        }

        
    }
}