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

namespace H2Stats
{
    partial class DownloadForm
    {
        struct ProgressReport
        {
            public string Gamertag;
            public string Status;
            public string GameDetails;
            public int CurrentGame;
            public int TotalGames;
            public Image Icon;
            public HaloDataSet.PlayerRankDataTable NewRanks;
            public int BytesDL;
        }

        private void doDownload(object sender, DoWorkEventArgs e)
        {
            List<string> tags = (List<string>)e.Argument;
            foreach (string gamertag in tags)
            {
                if (worker.CancellationPending)
                    return;
                downloadPlayer(gamertag);
            }

            bool dlPlaylists = chkUpdatePlaylists.Checked;

            if (dlPlaylists)
            {
                ProgressReport p = new ProgressReport();
                p.Status = "Updating playlist information...";
                worker.ReportProgress(0, p);
                Download.UpdatePlaylistInfoTable();
            }           

        }

        private void downloadPlayer(string gamerTag)
        {
            ProgressReport report = new ProgressReport();
            report.Gamertag = gamerTag;
            report.Status = "Updating Player Details...";
            report.GameDetails = "";
            worker.ReportProgress(0, report);
            

            report = new ProgressReport();
            string html = Download.GetStatsHomeHtml(gamerTag);
            report.Icon = Download.GetPlayerIcon(html);            

            //Create adapters
            GameTableAdapter gameAdapter = new GameTableAdapter();
            GamePlayerTableAdapter gamePlayerAdapter = new GamePlayerTableAdapter();
            GamePlayerMedalTableAdapter gamePlayerMedalAdapter = new GamePlayerMedalTableAdapter();
            PlayerRankTableAdapter playerRankAdapter = new PlayerRankTableAdapter();
            TagListTableAdapter tagListAdapter = new TagListTableAdapter();
            HaloDataSet.TagListDataTable tagList = tagListAdapter.GetData();

            HaloDataSet.PlayerRankDataTable playerRank = new HaloDataSet.PlayerRankDataTable();
            playerRankAdapter.Fill(playerRank, gamerTag);

            Parse.UpdatePlayerRanks(playerRank, html, gamerTag);
            report.NewRanks = playerRank;
            report.Status = "Finding new games...";

            worker.ReportProgress(0, report);

            List<string> games = Download.FindNewGames(gamerTag);

            for (int i = 0; i < games.Count; i++)
            {
                if (worker.CancellationPending)
                    break;

                HaloDataSet dataSet = new HaloDataSet();
                string game = games[i];
                report = new ProgressReport();
                report.TotalGames = games.Count;
                report.CurrentGame = i + 1;
                report.Status = String.Format("Downloading game {0} of {1} ({2:p})", i + 1, games.Count, ((float)(i + 1)) / ((float)games.Count));

                string html2 = Download.GetGameHTML(StatsPanel.Stats, game);

                HaloDataSet.GameRow gameRow = dataSet.Game.NewGameRow();
                gameRow.GameID = game;

                Parse.FillGameStats(gameRow, html2);
                if (gameRow.BaseGametype == "JUGGERNAUT")
                    continue;
                dataSet.Game.AddGameRow(gameRow);

                report.GameDetails = string.Format("{0} on {1}.", gameRow.Matchtype, gameRow.Map);
                worker.ReportProgress(0, report);

                Parse.CreateAndFillGamePlayerTable(gameRow, dataSet.GamePlayer, html2);
                Parse.FillMedalsStats(dataSet.GamePlayerMedal, dataSet.GamePlayer, gameRow.GameID, html2);

                tagList.FindByGamertag(gamerTag).LastGameID = games[i];
                tagList.FindByGamertag(gamerTag).LastDL = DateTime.Now;

                //if (!tagList.FindByGamertag(gamerTag).SaveGameViewer)
                //{
                //    DataRow[] gamePlayers = dataSet.GamePlayer.Select("Gamertag <> '" + gamerTag + "'");
                //    foreach (DataRow gamePlayer in gamePlayers)
                //        gamePlayer.Delete();

                //    DataRow[] gamePlayerMedals = dataSet
                //}

                try
                {
                    gameAdapter.Update(dataSet.Game);               
                    gamePlayerAdapter.Update(dataSet.GamePlayer);
                    gamePlayerMedalAdapter.Update(dataSet.GamePlayerMedal);
                }
                catch (System.Data.OleDb.OleDbException ex)
                {
                    MessageBox.Show(ex.Message, "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dataSet.Dispose();
            }

            tagListAdapter.Update(tagList);
            tagList.Dispose();
            tagListAdapter.Dispose();

            playerRankAdapter.Update(playerRank);
            gamePlayerAdapter.Dispose();
            gamePlayerMedalAdapter.Dispose();
            gameAdapter.Dispose();
            playerRankAdapter.Dispose();
        }        

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressReport report = (ProgressReport)e.UserState;

            if (report.GameDetails != null)
            {
                this.lblGameMap.Text = report.GameDetails;
                if (report.GameDetails != "")
                    Properties.Settings.Default.GamesDL++;
            }

            if (report.Gamertag != null)
                this.cboGamertags.SelectedItem = report.Gamertag;

            if (report.Icon != null)
            {
                try
                {
                    if (imgCurrentIcon.Image != null)
                        imgCurrentIcon.Image.Dispose();
                    
                    Bitmap newBitmap = new Bitmap(report.Icon.Width, report.Icon.Height,
                        System.Drawing.Imaging.PixelFormat.Format16bppRgb555);

                    using (Graphics g = Graphics.FromImage(newBitmap))
                    {
                        g.DrawImage(report.Icon, new Point(0, 0));
                    }
                    report.Icon.Dispose();

                    this.imgCurrentIcon.Image = newBitmap;
                    newBitmap.Save(Application.StartupPath + @"\Images\PlayerIcons\" + (string)cboGamertags.SelectedItem + ".bmp");

                    //imgCurrentIcon.Image = report.Icon;
                    //imgCurrentIcon.Image.Save(Application.StartupPath + @"\Images\PlayerIcons\" + (string)cboGamertags.SelectedItem + ".bmp");
                }
                catch (Exception ex)
                {

                }
            }

            if (report.NewRanks != null)
                levelPanel.SetRanks(report.NewRanks, Application.StartupPath + @"\Images\Levels\L{0:00}.gif");

            if (report.Status != null)
                this.lblStatus.Text = report.Status;

            if (report.TotalGames != 0)
                this.prgBar.Maximum = report.TotalGames;

            if (report.CurrentGame != 0)
                this.prgBar.Value = report.CurrentGame;
        }
        
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatus.Text = "Idle";
            lblGameMap.Text = "";
            chkUpdatePlaylists.Enabled = true;
            prgBar.Value = 0;
            cboGamertags.Enabled = true;
            rdoAll.Enabled = true;
            rdoCurrentSelection.Enabled = true;
            btnGo.Text = "Go";
            timer1.Enabled = false;
        }
    }
}