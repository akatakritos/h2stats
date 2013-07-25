using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using H2Stats.Data;
using System.Diagnostics;

namespace CoBPack.Plugin
{
    public partial class BungieGameViewer : Form, IGameViewer
    {
        HaloDataSet.GameRow gameRow;
        IHaloInfoSupplier info;
        public BungieGameViewer(string gamertag, HaloDataSet.GameRow gameRow, IHaloInfoSupplier infoSupplier)
        {
            InitializeComponent();
            this.gameRow = gameRow;
            info = infoSupplier;
        }

        #region IGameViewer Members

        public HaloDataSet.GameRow GameRow
        {
            get { return gameRow; }
        }

        public string GameID
        {
            get { return gameRow.GameID; }
        }

        #endregion

        private void BungieGameViewer_Load(object sender, EventArgs e)
        {
            HaloDataSet.GamePlayerRow[] gamePlayers = gameRow.GetGamePlayerRows();
            loadGameStats();
            loadStatsPanel(gamePlayers);
            loadKillsPanel(gamePlayers);
        }

        private void loadKillsPanel(HaloDataSet.GamePlayerRow[] gps)
        {
            int i = 0;
            foreach (HaloDataSet.GamePlayerRow gp in gps)
            {
                object kills = gp.Kills;
                object deaths = gp.Deaths;
                object assists = gp.Assists;
                object suicides = gp.Suicides;
                dgvKDAS.Rows.Add(gp.Gamertag, kills, deaths, assists, suicides);
                Color bgColor = getColor(gp.ColorHex);
                dgvKDAS.Rows[i].DefaultCellStyle.BackColor = bgColor;
                dgvKDAS.Rows[i].DefaultCellStyle.SelectionBackColor = bgColor;
                i++;
            }

            foreach (DataGridViewRow r in dgvKDAS.Rows)
            {
                DataGridViewLinkCell c = r.Cells[0] as DataGridViewLinkCell;
                if (c != null)
                {
                    c.Tag = createUrl((string)c.Value);
                }
            } 
        }

        private void loadGameStats()
        {
            lblMap.Text = gameRow.Map;
            lblMatchtype.Text = gameRow.Matchtype;
            lblPlaylist.Text = gameRow.Playlist;
            lblDateTime.Text = gameRow.Date + " " + gameRow.Time;
            lblGamelength.Text = "Game Length: " + GameLength.ToTimeString(gameRow.Length);
            pictureBox1.Image = info.Images.Maps.GetByName(gameRow.Map);
        }

        private void loadStatsPanel(HaloDataSet.GamePlayerRow[] gps)
        {
            colStat1.HeaderText = gps[0].Stat1Name;
            colStat2.HeaderText = gps[0].Stat2Name;
            int i = 0;
            foreach(HaloDataSet.GamePlayerRow gp in gps)
            {
                object stat1 = evaluateStatType(gp.Stat1IsTime, gp.Stat1Value);
                object stat2 = evaluateStatType(gp.Stat2IsTime, gp.Stat2Value);
                object score = evaluateStatType(gp.ScoreIsTime, gp.Score);
                dgvStats.Rows.Add(gp.Gamertag, stat1, stat2, score);
                Color bgColor = getColor(gp.ColorHex);
                dgvStats.Rows[i].DefaultCellStyle.BackColor = bgColor;
                dgvStats.Rows[i].DefaultCellStyle.SelectionBackColor = bgColor;
                i++;
            }

            foreach (DataGridViewRow r in dgvStats.Rows)
            {
                DataGridViewLinkCell c = r.Cells[0] as DataGridViewLinkCell;
                if (c != null)
                {
                    c.Tag = createUrl((string)c.Value);
                    
                }
            }
        }

        private string createUrl(string p)
        {
            return "http://www.bungie.net/Stats/PlayerStats.aspx?player=" + p.Replace(" ", "%20");
        }

        private Color getColor(string p)
        {
            return Color.FromArgb(Convert.ToInt32("FF" + p, 16));        
        }

        private object evaluateStatType(bool isTime, short val)
        {
            if (isTime)
                return GameLength.ToTimeString(val);
            else
                return val;
        }

        private void lblMap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://h2.halowiki.net/p/" + ((LinkLabel)sender).Text);
        }
    }

    //public class BungieGameViewerLaunch : IGameViewerLauncher
    //{

    //    #region IGameViewerLauncher Members

    //    public string Name
    //    {
    //        get { return "Bungie Style Game Viewer"; }
    //    }

    //    public void Launch(string gamertag, HaloDataSet.GameRow gameRow, IHaloInfoSupplier infoSupplier, Form mdiParent)
    //    {
    //        BungieGameViewer g = new BungieGameViewer(gamertag, gameRow, infoSupplier);
    //        g.MdiParent = mdiParent;
    //        g.Show();
    //    }

    //    #endregion
    //}
}