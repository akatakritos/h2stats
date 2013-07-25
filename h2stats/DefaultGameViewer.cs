using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using H2Stats.Data.HaloDataSetTableAdapters;
using H2Stats.Data;

namespace H2Stats
{
    public partial class DefaultGameViewer : Form, IGameViewer
    {
        private string gameID;
        private HaloDataSet.GameRow gameRow;
        private HaloDataSet.MedalInfoDataTable medalInfo;
        private HaloDataSet.ColorInfoDataTable colorInfo;
        private string gamertag;
        private IHaloInfoSupplier info;
        private delegate void RunOnUIThread();
        
        public DefaultGameViewer(string gamertag, HaloDataSet.GameRow gameRow, IHaloInfoSupplier infoSupplier)
        {
            InitializeComponent();
            this.medalInfo = infoSupplier.MedalInfo;
            this.gamertag = gamertag;
            this.colorInfo = infoSupplier.ColorInfo;
            info = infoSupplier;
            this.gameRow = gameRow;
            this.gameID = gameRow.GameID;
        }

        //private void loadGameAsync(object param)
        //{
        //    GameTableAdapter gta = new GameTableAdapter();
        //    gta.FillByGameID(gameData.Game, this.gameID);

        //    GamePlayerTableAdapter gpta = new GamePlayerTableAdapter();
        //    gpta.FillByGameID(gameData.GamePlayer, this.gameID);

        //    GamePlayerMedalTableAdapter gpmta = new GamePlayerMedalTableAdapter();
        //    gpmta.FillByGameID(gameData.GamePlayerMedal, this.gameID);

        //    Invoke(new RunOnUIThread(this.showGameData));
        //}

        const int SPACER = 20;
        const int SCROLLBAR_WIDTH = 15;

        private void showGameData()
        {
            this.SuspendLayout();
            dataGridView1.SuspendLayout();
            dataGridView1.Rows.Clear();
            Color bgColor;
            Color lastColor = Color.Empty;

            //if (gameData.Game[0].TeamGame)
            //    setupTeamScoreTable(gameData.GamePlayer[0].ScoreIsTime);

            if (gameRow.TeamGame)
                createTeamScoreColumn();


            HaloDataSet.GamePlayerRow[] gamePlayers = gameRow.GetGamePlayerRows();
            for (int i = 0; i < gamePlayers.Length; i++)
            {
                HaloDataSet.GamePlayerRow row = gamePlayers[i];

                object stat1;
                object stat2;
                object score;

                stat1 = evaluateScoreType(row.Stat1IsTime, row.Stat1Value);
                stat2 = evaluateScoreType(row.Stat2IsTime, row.Stat2Value);
                score = evaluateScoreType(row.ScoreIsTime, row.Score);

                bgColor = getColor(row);

                if ((gameRow.TeamGame) && (bgColor != lastColor))
                {
                    int teamScore = 0;
                    Color tempColor;
                    lastColor = bgColor;

                    //find team score;
                    for (int j = 0; j < gamePlayers.Length; j++)
                    {
                        tempColor = getColor(gamePlayers[j]);
                        if (tempColor == lastColor)
                            teamScore += gamePlayers[j].Score;
                    }
                    
                    dataGridView1.Rows.Add(row.Gamertag, row.Place, stat1, stat2, score,
                        evaluateScoreType(row.ScoreIsTime, teamScore));

                    dataGridView1.Rows[i].Cells["Team Score"].ToolTipText = colorInfo.FindByColorHex(row.ColorHex).Description + "\'s Score";
                }
                else
                    dataGridView1.Rows.Add(row.Gamertag, row.Place, stat1, stat2, score);

                dataGridView1.Rows[i].DefaultCellStyle.BackColor = bgColor;
                dataGridView1.Rows[i].DefaultCellStyle.SelectionBackColor = bgColor;
                dataGridView1.Rows[i].Tag = row;


            }
            //dataGridView1.AutoSize = true;
            dataGridView1.Height = dataGridView1.ColumnHeadersHeight + 
                (dataGridView1.Rows.Count * dataGridView1.Rows[0].Height) +
                SCROLLBAR_WIDTH;            

            this.groupBox1.Top = dataGridView1.Top + dataGridView1.Height + SPACER;
            this.ClientSize = new Size(this.ClientSize.Width, groupBox1.Top + groupBox1.Height + SPACER);

            fillGameStatsPanel();

            Column3.HeaderText = gamePlayers[0].Stat1Name;
            Column4.HeaderText = gamePlayers[0].Stat2Name;

            this.ResumeLayout();
            dataGridView1.ResumeLayout();

            rdo_CheckedChanged(null, null);
        }

        private void fillGameStatsPanel()
        {
            //imgMap.Image = Image.FromFile(String.Format(@"{0}\Images\Maps\{1}.jpg",
            //    Application.StartupPath, gameData.Game[0].Map));

            imgMap.Image = info.Images.Maps.GetByName(gameRow.Map);

            lblMap.Value = gameRow.Map;
            lblMap.Url = createUrl(gameRow.Map);

            lblPlaylist.Value = gameRow.Playlist;
            lblPlaylist.Url = createUrl(gameRow.Playlist);

            lblMatchtype.Value = gameRow.Matchtype;
            lblMatchtype.Url = createUrl(gameRow.Matchtype);

            lblGametype.Value = gameRow.Gametype;
            lblGametype.Url = createUrl(gameRow.Gametype);

            lblDate.Value = gameRow.Date;
            DateTime time = DateTime.ParseExact(gameRow.Time, "HH:mm:ss", System.Globalization.DateTimeFormatInfo.CurrentInfo);
            lblTime.Value = time.ToString("h:m tt");
            lblDuration.Value = GameLength.ToTimeString(gameRow.Length);
            this.Text = "Game Viewer - " + gameRow.GameID;
        }

        private string createUrl(string p)
        {
            return Properties.Settings.Default.H2WikiBaseUrl + p.Replace(' ', '_');
        }

        private static Color getColor(HaloDataSet.GamePlayerRow row)
        {
            return Color.FromArgb(Convert.ToInt32("FF" + row.ColorHex, 16));
        }

        private static object evaluateScoreType(bool isTime, int value)
        {
            object stat;
            if (isTime)
                stat = GameLength.ToTimeString(value);
            else
                stat = value;
            return stat;
        }

        private void createTeamScoreColumn()
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = "Team Score";
            col.ReadOnly = true;
            col.Name = "Team Score";
            col.DefaultCellStyle.ForeColor = SystemColors.ControlText;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            Column5.Width -= 33;
            Column4.Width -= 33;
            Column3.Width -= 34;

            dataGridView1.Columns.Add(col);
        }

        void rdo_CheckedChanged(object sender, EventArgs e)
        {
            HaloDataSet.GamePlayerRow player = 
                (HaloDataSet.GamePlayerRow)dataGridView1.SelectedRows[0].Tag;
            if (player == null) return;
            groupBox1.Text = "Details: " + player.Gamertag;
            lblKills.Value = player.Kills;
            lblDeaths.Value = player.Deaths;
            lblSuicides.Value = player.Suicides;
            lblAssists.Value = player.Assists;
            if (!player.IsBetrayalsNull())
                lblBetrayals.Value = player.Betrayals;
            else
                lblBetrayals.Value = 0;
            lblHeadshots.Value = player.Headshots;
            lblShotsFired.Value = player.ShotsFired;
            lblShotsHit.Value = player.ShotsHit;
            lblAccuracy.Value = player.Accuracy;
            
            if (player.Deaths != 0)
                lblKpD.Value = Math.Round((player.Kills / (double)player.Deaths), 2);
            else
                lblKpD.Value = player.Kills;

            lblKpMin.Value = Math.Round(player.Kills / ((double)(gameRow.Length % 60)), 2);
            lblMostKilled.Value = player.MostKilled;
            lblMostKilledBy.Value = player.MostKilledBy;
            
            if (player.ShotsFired != 0)
                lblPercentHeadshots.Value = Math.Round(player.Headshots / (double)player.ShotsFired, 2) * 100.0;
            else
                lblPercentHeadshots.Value = 0;

            grpMedals.Text = "Medals: " + player.TotalMedals.ToString();
            HaloDataSet.GamePlayerMedalRow[] medals = player.GetGamePlayerMedalRows();
            pnlMedals.SetMedals(medals, (IMedalsImageCache)info.Images.Medals);
            loadKillTypes(medals, player);
        }

        private void loadKillTypes(HaloDataSet.GamePlayerMedalRow[] medals, HaloDataSet.GamePlayerRow player)
        {
            pie1.BeginUpdate();
            pie1.Clear();
            int stdKills = player.Kills;
            foreach (HaloDataSet.GamePlayerMedalRow medal in medals)
            {
                try
                {
                    if (this.medalInfo.FindByName(medal.MedalName).IsKillType)
                    {
                        pie1.Add(medal.Count, medal.MedalName);
                        stdKills -= medal.Count;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There were errors loading the kill types for this player");
                }
            }

            if (player.Stat2Name == "Ball Kills" && player.Stat2Value > 0)
            {
                pie1.Add(player.Stat2Value, "Ball Kills");
                stdKills -= player.Stat2Value;
            }

            if (stdKills > 0)
                pie1.Add(stdKills, "Std. Kills");
            pie1.EndUpdate();
        }

        public override string ToString()
        {
            return "Game Viewer - " + this.gameID;
        }

        private void DefaultGameViewer_Shown(object sender, EventArgs e)
        {
            //ThreadPool.QueueUserWorkItem(new WaitCallback(this.loadGameAsync));
            showGameData();
        }

        #region IGameViewer Members

        public HaloDataSet.GameRow GameRow
        {
            get
            {
                return gameRow;
            }
        }

        public string GameID
        {
            set
            {
                this.gameID = value;
            }

            get
            {
                return this.gameID;
            }
        }

        #endregion
    }

    public class DefaultGameViewerLauncher : IGameViewerLauncher
    {

        #region IGameViewerLauncher Members

        public string Name
        {
            get { return "Built-In Gameviewer"; }
        }

        public void Launch(string gamertag, HaloDataSet.GameRow gameRow, IHaloInfoSupplier infoSupplier, Form mdiParent)
        {
            DefaultGameViewer gv = new DefaultGameViewer(gamertag, gameRow, infoSupplier);
            gv.MdiParent = mdiParent;
            gv.Show();
        }

        #endregion
    }
}