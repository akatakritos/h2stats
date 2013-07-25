using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using H2Stats.Controls;
using H2Stats.Data;
using H2Stats.Data.AggregateDataSetTableAdapters;
using H2Stats.Data.HaloDataSetTableAdapters;
using System.Threading;
using H2Stats.Properties;

namespace H2Stats
{
    public partial class TotalsForm : Form
    {
        Dictionary<string, MedalDisplay> medalLookup;
        const double NOTAVAILABLE = 0.0;
        private HaloDataSet.TagListDataTable tagList;
        private HaloDataSet.MedalInfoDataTable medalInfo;
        private bool mTotalsCalculated = false;

        public TotalsForm(HaloDataSet.TagListDataTable tagList, HaloDataSet.MedalInfoDataTable medalInfo)
        {
            InitializeComponent();
            this.tagList = tagList;
            this.medalInfo = medalInfo;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            //BufferedTabPage tb = new BufferedTabPage();
            //tabControl1.TabPages.Add(tb);

            //foreach (Control c in tabPage2.Controls)
            //    tb.Controls.Add(c);

            medalLookup = new Dictionary<string, MedalDisplay>();
            medalLookup.Add("Assassin", mdlAssassin);
            medalLookup.Add("Berserker", mdlBerserker);
            medalLookup.Add("Killing Spree", mdlKillingSpree);
            medalLookup.Add("Rampage", mdlRampage);
            medalLookup.Add("Running Riot", mdlRunningRiot);
            medalLookup.Add("Triple Kill", mdlTripleKill);
            medalLookup.Add("Killtacular", mdlKilltacular);
            medalLookup.Add("Kill Frenzy", mdlKillFrenzy);
            medalLookup.Add("Killtrocity", mdlKilltrocity);
            medalLookup.Add("Double Kill", mdlDoubleKill);
            medalLookup.Add("Flag Returned", mdlFlagReturn);
            medalLookup.Add("Flag Carrier Kill", mdlFlagKill);
            medalLookup.Add("Flag Taken", mdlFlagSteal);
            medalLookup.Add("Bomb Carrier Kill", mdlBombKill);
            medalLookup.Add("Bomb Planted", mdlBombPlant);
            medalLookup.Add("Roadkill", mdlSplatter);
            medalLookup.Add("Carjacking", mdlVehicleJack);
            medalLookup.Add("Bonecracker", mdlBeatdown);
            medalLookup.Add("Stick It", mdlStick);
            medalLookup.Add("Sniper Kill", mdlSniper);

            cboGamertags.Items.Clear();
            foreach (HaloDataSet.TagListRow row in tagList)
            {
                cboGamertags.Items.Add(row.Gamertag);
            }
            cboGamertags.SelectedItem = Settings.Default.LastViewedGamertag;

            rdoGametype.Tag = dgvGametypeDetails;
            rdoMaps.Tag = dgvMapDetails;
            rdoPlaylists.Tag = dgvPlaylistDetails;
            rdoMatchtype.Tag = dgvMatchtypeDetails;
        }

        public override string ToString()
        {
            return this.Text;
        }

        public bool TotalsCalculated
        {
            get { return mTotalsCalculated; }
        }

        public AggregateDataSet TotalsDataSet
        {
            get { return this.dataSet; }
        }

        public string Gamertag
        {
            get
            {
                if (dataSet != null)
                    return dataSet.Kills_Aggregate[0].Gamertag;
                else
                    return null;
            }
        }

        private void TotalsForm_Load(object sender, EventArgs e)
        {
            dataSorter.LoadDataAsync();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (cboGamertags.SelectedIndex != -1)
            {
                progressBar.Visible = true;
                progressBar.Value = 0;
                this.Text = "Player Overview - " + cboGamertags.SelectedItem.ToString();
                worker.RunWorkerAsync(cboGamertags.SelectedItem.ToString());
                
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dataSorter.ClearAllSelections();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            worker.ReportProgress(0);
            dataSorter.WriteSortData();
            worker.ReportProgress(0);

            GamertagSearchTableAdapter gamertagAdapter = new GamertagSearchTableAdapter();
            gamertagAdapter.Clear();
            AggregateDataSet.GamertagSearchDataTable gamerTable = new AggregateDataSet.GamertagSearchDataTable();
            gamerTable.AddGamertagSearchRow((string)e.Argument);
            gamertagAdapter.Update(gamerTable);
            gamertagAdapter.Dispose();
            gamerTable.Dispose();
            worker.ReportProgress(0);

            lock (this.dataSet)
            {
                Kills_AggregateTableAdapter killsAdapter = new Kills_AggregateTableAdapter();
                Deaths_AggregateTableAdapter deathsAdapter = new Deaths_AggregateTableAdapter();
                Assists_AggregateTableAdapter assistsAdapter = new Assists_AggregateTableAdapter();
                Suicides_AggregateTableAdapter suicidesAdapter = new Suicides_AggregateTableAdapter();
                Betrayals_AggregateTableAdapter betrayalsAdapter = new Betrayals_AggregateTableAdapter();
                Stat1_AggregateTableAdapter stat1Adapter = new Stat1_AggregateTableAdapter();
                Stat2_AggregateTableAdapter stat2Adapter = new Stat2_AggregateTableAdapter();
                Total_Medals_AggregateTableAdapter totalMedalsAdapter = new Total_Medals_AggregateTableAdapter();
                Medals_AggregateTableAdapter medalsAdapter = new Medals_AggregateTableAdapter();
                Accuracy_AggregateTableAdapter accuracyAdapter = new Accuracy_AggregateTableAdapter();
                Headshots_AggregateTableAdapter headshotsAdapter = new Headshots_AggregateTableAdapter();
                Shots_Fired_AggregateTableAdapter shotsFiredAdapter = new Shots_Fired_AggregateTableAdapter();
                Shots_Hit_AggregateTableAdapter shotsHitAdapter = new Shots_Hit_AggregateTableAdapter();
                Game_Length_AggregateTableAdapter gameLengthAdapter = new Game_Length_AggregateTableAdapter();
                GametypeDetailsTableAdapter gametypeAdapter = new GametypeDetailsTableAdapter();
                MatchTypeDetailsTableAdapter matchtypeAdapter = new MatchTypeDetailsTableAdapter();
                PlaylistDetailsTableAdapter playlistAdapter = new PlaylistDetailsTableAdapter();
                MapDetailsTableAdapter mapDetails = new MapDetailsTableAdapter();
                Game_Count_AggregateTableAdapter gameCountAdapter = new Game_Count_AggregateTableAdapter();
                GametypeDetailsTableAdapter gametypeDetailsAdapter = new GametypeDetailsTableAdapter();
                WinsByGametypeTableAdapter winsByGametypeAdapter = new WinsByGametypeTableAdapter();
                Score_AggregateTableAdapter scoreAdapter = new Score_AggregateTableAdapter();
                MapDetailsTableAdapter mapAdapter = new MapDetailsTableAdapter();
                
                worker.ReportProgress(0);

                dataSet.Clear();

                killsAdapter.Fill(this.dataSet.Kills_Aggregate);
                worker.ReportProgress(0);
                deathsAdapter.Fill(this.dataSet.Deaths_Aggregate);
                worker.ReportProgress(0);
                assistsAdapter.Fill(this.dataSet.Assists_Aggregate);
                worker.ReportProgress(0);
                suicidesAdapter.Fill(this.dataSet.Suicides_Aggregate);
                worker.ReportProgress(0);
                betrayalsAdapter.Fill(this.dataSet.Betrayals_Aggregate);
                worker.ReportProgress(0);
                stat1Adapter.Fill(this.dataSet.Stat1_Aggregate);
                worker.ReportProgress(0);
                stat2Adapter.Fill(this.dataSet.Stat2_Aggregate);
                worker.ReportProgress(0);
                totalMedalsAdapter.Fill(this.dataSet.Total_Medals_Aggregate);
                worker.ReportProgress(0);
                medalsAdapter.Fill(this.dataSet.Medals_Aggregate);
                worker.ReportProgress(0);
                accuracyAdapter.Fill(this.dataSet.Accuracy_Aggregate);
                worker.ReportProgress(0);
                shotsFiredAdapter.Fill(this.dataSet.Shots_Fired_Aggregate);
                worker.ReportProgress(0);
                shotsHitAdapter.Fill(this.dataSet.Shots_Hit_Aggregate);
                worker.ReportProgress(0);
                headshotsAdapter.Fill(this.dataSet.Headshots_Aggregate);
                worker.ReportProgress(0);
                gameLengthAdapter.Fill(this.dataSet.Game_Length_Aggregate);
                worker.ReportProgress(0);
                gametypeAdapter.Fill(this.dataSet.GametypeDetails);
                worker.ReportProgress(0);
                matchtypeAdapter.Fill(this.dataSet.MatchTypeDetails);
                worker.ReportProgress(0);
                playlistAdapter.Fill(this.dataSet.PlaylistDetails);
                worker.ReportProgress(0);
                mapDetails.Fill(this.dataSet.MapDetails);
                worker.ReportProgress(0);
                gameCountAdapter.Fill(this.dataSet.Game_Count_Aggregate);
                worker.ReportProgress(0);
                gametypeDetailsAdapter.Fill(this.dataSet.GametypeDetails);
                worker.ReportProgress(0);
                winsByGametypeAdapter.Fill(this.dataSet.WinsByGametype);
                worker.ReportProgress(0);
                scoreAdapter.Fill(this.dataSet.Score_Aggregate);
                worker.ReportProgress(0);

                killsAdapter.Dispose();
                deathsAdapter.Dispose();
                assistsAdapter.Dispose();
                suicidesAdapter.Dispose();
                stat1Adapter.Dispose();
                stat2Adapter.Dispose();
                totalMedalsAdapter.Dispose();
                medalsAdapter.Dispose();
                accuracyAdapter.Dispose();
                shotsFiredAdapter.Dispose();
                shotsHitAdapter.Dispose();
                gameLengthAdapter.Dispose();
                gametypeAdapter.Dispose();
                matchtypeAdapter.Dispose();
                playlistAdapter.Dispose();
                mapDetails.Dispose();                
                gameCountAdapter.Dispose();
                headshotsAdapter.Dispose();
                gametypeDetailsAdapter.Dispose();
                worker.ReportProgress(0);
                winsByGametypeAdapter.Dispose();
                GC.Collect();
            }
            mTotalsCalculated = true;
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar.Increment(1);
            if(dataSet.Kills_Aggregate.Count > 0)
                lblKills.Value = (int)dataSet.Kills_Aggregate[0].Sum;
            if (dataSet.Deaths_Aggregate.Count > 0)
                lblDeaths.Value = (int)dataSet.Deaths_Aggregate[0].Sum;
            if (dataSet.Assists_Aggregate.Count > 0)
                lblAssists.Value = (int)dataSet.Assists_Aggregate[0].Sum;
            if (dataSet.Suicides_Aggregate.Count > 0)
                lblSuicides.Value = (int)dataSet.Suicides_Aggregate[0].Sum;
            if (dataSet.Betrayals_Aggregate.Count > 0)
                lblBetrayals.Value = (int)dataSet.Betrayals_Aggregate[0].Sum;
            lblKpD.Value = Math.Round(((int)lblKills.Value) / dataSet.Deaths_Aggregate[0].Sum, 3);
            lblKApD.Value = Math.Round(((int)lblKills.Value + (int)lblAssists.Value) / dataSet.Deaths_Aggregate[0].Sum, 3);
            if (dataSet.Game_Length_Aggregate.Count > 0)
                lblTime.Value = new GameLength((int)dataSet.Game_Length_Aggregate[0].Sum);
            lblKpMin.Value = Math.Round(((int)lblKills.Value) / dataSet.Game_Length_Aggregate[0].Sum, 3);
            if (dataSet.Shots_Hit_Aggregate.Count > 0)
                lblShotsHit.Value = (int)dataSet.Shots_Hit_Aggregate[0].Sum;
            if (dataSet.Shots_Fired_Aggregate.Count > 0)
                lblShotsFired.Value = (int)dataSet.Shots_Fired_Aggregate[0].Sum;
            if (dataSet.Accuracy_Aggregate.Count > 0)
                lblAccuracy.Value = (int)dataSet.Accuracy_Aggregate[0].Avg;
            if (dataSet.Headshots_Aggregate.Count > 0)
                lblHeadshots.Value = (int)dataSet.Headshots_Aggregate[0].Sum;
            if (dataSet.Game_Count_Aggregate.Count > 0)
                lblGames.Value = (int)dataSet.Game_Count_Aggregate[0].Count;
            if (dataSet.Game_Count_Aggregate.Count > 0)
                bufferedGroupBox1.Text = "Medals: " + (int)dataSet.Game_Count_Aggregate[0].Count;
            if (dataSet.Kills_Aggregate.Count > 0 && dataSet.Shots_Fired_Aggregate.Count > 0)
            {
                double SpK = dataSet.Shots_Fired_Aggregate[0].Sum / dataSet.Kills_Aggregate[0].Sum;
                lblSpK.Value = Math.Round(SpK, 3);
            }

            progressBar.Increment(1);
            foreach(MedalDisplay md in bufferedGroupBox1.Controls)
                md.Count = 0;
            foreach (AggregateDataSet.Medals_AggregateRow row in dataSet.Medals_Aggregate)
                medalLookup[row.MedalName].Count = (int)row.Sum;

            fillStatsTable();
            fillMedalsTable();
            parseGametypeDetails();

            fillGametypeDetails();
            fillMapDetails();
            fillPlaylistDetails();
            fillMatchtypeDetails();
            GraphType_CheckedChanged(rdoGametype, EventArgs.Empty);

            buildKillTypes();

            progressBar.Visible = false;
            if (tabControl1.SelectedTab == tabPage1)
                tabControl1.SelectedTab = tabPage2;

            ((MainForm)MdiParent).EnableTotalsExport();
        }

        private void buildKillTypes()
        {
            double stdKills = dataSet.Kills_Aggregate[0].Sum;

            AggregateDataSet.Stat2_AggregateRow ballKills = dataSet.Stat2_Aggregate.FindByStat2Name("Ball Kills");
            if ((ballKills != null) && (ballKills.Sum > 0))
            {
                pie2.Add(ballKills.Sum, "Oddball Kills");
                stdKills -= ballKills.Sum;
            }

            foreach (AggregateDataSet.Medals_AggregateRow medal in dataSet.Medals_Aggregate)
            {
                HaloDataSet.MedalInfoRow row = medalInfo.FindByName(medal.MedalName);
                if ((row != null) && (row.IsKillType))
                {
                    pie2.Add(medal.Sum, medal.MedalName);
                    stdKills -= medal.Sum;
                }
            }

            pie2.Add(stdKills, "Std Kills");
        }

        private void fillMatchtypeDetails()
        {
            dgvMatchtypeDetails.Rows.Clear();
            foreach (AggregateDataSet.MatchTypeDetailsRow row in dataSet.MatchTypeDetails)
            {
                dgvMatchtypeDetails.Rows.Add(row.Matchtype, row.Count_Of_Game,
                    new GameLength((int)row.Sum_Of_Length),
                    new GameLength((int)row.Avg_Of_Length));
            }
        }

        private void fillPlaylistDetails()
        {
            dgvPlaylistDetails.Rows.Clear();
            foreach (AggregateDataSet.PlaylistDetailsRow row in dataSet.PlaylistDetails)
            {
                dgvPlaylistDetails.Rows.Add(row.Playlist, row.Count_Of_Game,
                    new GameLength((int)row.Sum_Of_Length),
                    new GameLength((int)row.Avg_Of_Length));
            }
        }

        private void fillMapDetails()
        {
            dgvMapDetails.Rows.Clear();
            foreach (AggregateDataSet.MapDetailsRow row in dataSet.MapDetails)
            {
                dgvMapDetails.Rows.Add(row.Map, row.Count_Of_Game,
                    new GameLength((int)row.Sum_Of_Length),
                    new GameLength((int)row.Avg_Of_Length));
            }
        }

        private void fillGametypeDetails()
        {
            dgvGametypeDetails.Rows.Clear();
            foreach (AggregateDataSet.GametypeDetailsRow row in dataSet.GametypeDetails)
            {
                dgvGametypeDetails.Rows.Add(row.Gametype, row.Count_Of_Game, 
                    new GameLength((int)row.Sum_Of_Length), 
                    new GameLength((int)row.Avg_Of_Length));
            }
        }

        private void fillMedalsTable()
        {
            string FileName = Application.StartupPath + "\\Images\\Medals\\{0}.gif";
            dgvMedals.Rows.Clear();
            foreach (AggregateDataSet.Medals_AggregateRow row in dataSet.Medals_Aggregate)
            {
                if(row.IsStdDevNull())
                    dgvMedals.Rows.Add(Image.FromFile(String.Format(FileName, row.MedalName)), row.MedalName, row.Sum, row.Avg, row.Min, row.MAX, NOTAVAILABLE);
                else
                    dgvMedals.Rows.Add(Image.FromFile(String.Format(FileName, row.MedalName)), row.MedalName, row.Sum, row.Avg, row.Min, row.MAX, row.StdDev);
            }
        }

        private void parseGametypeDetails()
        {
            int slayerGames = 0;
            int slayerWins = 0;
            int slayerAvgLife = 0;
            int oddBallGames = 0;
            int oddBalWins = 0;
            int kothGames = 0;
            int kothWins = 0;
            int terrGames = 0;
            int terrWins = 0;

            foreach (AggregateDataSet.GametypeDetailsRow row in dataSet.GametypeDetails)
            {
                if (row.Gametype.Contains("Slayer"))
                    slayerGames += row.Count_Of_Game;
                else if (row.Gametype.Contains("Oddball"))
                    oddBallGames += row.Count_Of_Game;
                else if (row.Gametype.Contains("KOTH"))
                    kothGames += row.Count_Of_Game;
                else if (row.Gametype.Contains("Territories"))
                    terrGames += row.Count_Of_Game;
                else if (row.Gametype == "CTF")
                    lblCtfGames.Value = row.Count_Of_Game;
                else if (row.Gametype == "Assault")
                    lblAssaultGames.Value = row.Count_Of_Game;
            }

            lblSlayerGames.Value = slayerGames;
            lblOddballGames.Value = oddBallGames;
            lblKothGames.Value = kothGames;
            lblTerrGames.Value = terrGames;

            foreach (AggregateDataSet.WinsByGametypeRow row in dataSet.WinsByGametype)
            {
                if (row.Gametype.Contains("Slayer"))
                    slayerWins += row.Wins;
                else if (row.Gametype.Contains("Oddball"))
                    oddBalWins += row.Wins;
                else if (row.Gametype.Contains("KOTH"))
                    kothWins += row.Wins;
                else if (row.Gametype.Contains("Territories"))
                    terrWins += row.Wins;
                else if (row.Gametype == "CTF")
                    lblCtfWins.Value = row.Wins;
                else if (row.Gametype == "Assault")
                    lblAssaultWins.Value = row.Wins;
            }

            if (slayerGames != 0)
                lblSlayerWinPer.Value = Math.Round(slayerWins / (double)slayerGames, 3) * 100;
            else
                lblSlayerWinPer.Value = 0;

            if (oddBalWins != 0)
                lblOddballWinPer.Value = Math.Round(oddBalWins / (double)oddBallGames, 3) * 100;
            else 
                lblOddballWinPer.Value = 0;

            if (kothGames != 0)
                lblKothWinPer.Value = Math.Round(kothWins / (double)kothGames, 3) * 100;
            else
                lblKothWinPer.Value = 0;

            if (terrGames != 0)
                lblTerrWinPer.Value = Math.Round(terrWins / (double)terrGames, 3) * 100;
            else
                lblTerrWinPer.Value = 0;

            if ((int)lblCtfWins.Value != 0)
                lblCtfWinPer.Value = Math.Round((int)lblCtfWins.Value / (double)((int)lblCtfGames.Value), 3) * 100;
            else
                lblCtfWinPer.Value = 0;

            if ((int)lblAssaultWinPer.Value != 0)
                lblAssaultWinPer.Value = Math.Round((int)lblAssaultWins.Value / (double)((int)lblAssaultGames.Value), 3) * 100;
            else
                lblAssaultWinPer.Value = 0;

            setStat1Values();
            setStat2Values();
            setScoreValues();

        }

        private void setScoreValues()
        {
            lblSlayerScore.Value = 0;
            lblTerrTime.Value = 0;
            lblOddballTime.Value = 0;
            lblKothTime.Value = 0;
            foreach (AggregateDataSet.Score_AggregateRow row in dataSet.Score_Aggregate)
            {
                if (row.Gametype.Contains("Slayer"))
                    lblSlayerScore.Value = ((int)lblSlayerScore.Value) + (int)row.Sum;
                else if (row.Gametype.Contains("Oddball"))
                    lblOddballTime.Value = ((int)lblOddballTime.Value) + (int)row.Sum;
                else if (row.Gametype.Contains("KOTH"))
                    lblKothTime.Value = ((int)lblKothTime.Value) + (int)row.Sum;
                else if (row.Gametype.Contains("Territories"))
                    lblTerrTime.Value = ((int)lblTerrTime.Value) + (int)row.Sum;
                else if (row.Gametype == "CTF")
                    lblCtfCaptured.Value = (int)row.Sum;
                else if (row.Gametype == "Assault")
                    lblAssaultPlanted.Value = mdlBombPlant.Count;
            }

            lblTerrTime.Value = new GameLength((int)lblTerrTime.Value);
            lblOddballTime.Value = new GameLength((int)lblOddballTime.Value);
            lblKothTime.Value = new GameLength((int)lblKothTime.Value);
        }

        private void setStat2Values()
        {
            AggregateDataSet.Stat2_AggregateRow stat2Row = dataSet.Stat2_Aggregate.FindByStat2Name("Territories Lost");
            if (stat2Row != null)
                lblTerrLost.Value = (int)stat2Row.Sum;

            stat2Row = dataSet.Stat2_Aggregate.FindByStat2Name("Best Spree");
            if (stat2Row != null)
                lblSlayerBestSpree.Value = (int)stat2Row.Max;

            stat2Row = dataSet.Stat2_Aggregate.FindByStat2Name("Kills From");
            if (stat2Row != null)
                lblKothKillsFrom.Value = (int)stat2Row.Sum;

            stat2Row = dataSet.Stat2_Aggregate.FindByStat2Name("Ball Kills");
            if (stat2Row != null)
                lblOddballBallKills.Value = (int)stat2Row.Sum;

            lblAssaultBombersKilled.Value = mdlBombKill.Count;
            lblCtfTaken.Value = mdlFlagSteal.Count;
        }

        private void setStat1Values()
        {
            AggregateDataSet.Stat1_AggregateRow stat1Row;

            stat1Row = dataSet.Stat1_Aggregate.FindByStat1Name("Avg. Life");
            if (stat1Row != null)
                lblSlayerAvgLife.Value = new GameLength((int)stat1Row.Sum);

            stat1Row = dataSet.Stat1_Aggregate.FindByStat1Name("Bomb Grabs");
            if (stat1Row != null)
                lblAssaultTaken.Value = (int)stat1Row.Sum;

            stat1Row = dataSet.Stat1_Aggregate.FindByStat1Name("Territories Taken");
            if (stat1Row != null)
                lblTerrTaken.Value = (int)stat1Row.Sum;

            stat1Row = dataSet.Stat1_Aggregate.FindByStat1Name("Kings Killed");
            if (stat1Row != null)
                lblKothKingsKilled.Value = (int)stat1Row.Sum;

            stat1Row = dataSet.Stat1_Aggregate.FindByStat1Name("Carrier Kills");
            if (stat1Row != null)
                lblOddballCarrierKills.Value = (int)stat1Row.Sum;

            lblCtfSaved.Value = mdlFlagKill.Count;           
        }

        private void fillStatsTable()
        {
            dgvStats.Rows.Clear();

            AggregateDataSet.Kills_AggregateRow kills = dataSet.Kills_Aggregate[0];
            if (kills.IsStdDevNull())
                dgvStats.Rows.Add("Kills", kills.Sum, kills.Avg, kills.Min, kills.Max, NOTAVAILABLE);
            else
                dgvStats.Rows.Add("Kills", kills.Sum, kills.Avg, kills.Min, kills.Max, kills.StdDev);

            AggregateDataSet.Deaths_AggregateRow deaths = dataSet.Deaths_Aggregate[0];
            if(deaths.IsStdDevNull())
                dgvStats.Rows.Add("Deaths", deaths.Sum, deaths.Avg, deaths.Min, deaths.Max, NOTAVAILABLE);
            else
                dgvStats.Rows.Add("Deaths", deaths.Sum, deaths.Avg, deaths.Min, deaths.Max, deaths.StdDev);

            AggregateDataSet.Assists_AggregateRow assists = dataSet.Assists_Aggregate[0];
            if(assists.IsStdDevNull())
                dgvStats.Rows.Add("Assists", assists.Sum, assists.Avg, assists.Min, assists.Max, NOTAVAILABLE);
            else
                dgvStats.Rows.Add("Assists", assists.Sum, assists.Avg, assists.Min, assists.Max, assists.StdDev);

            AggregateDataSet.Suicides_AggregateRow suicides = dataSet.Suicides_Aggregate[0];
            if(suicides.IsStdDevNull())
                dgvStats.Rows.Add("Suicides", suicides.Sum, suicides.Avg, suicides.Min, suicides.Max, NOTAVAILABLE);
            else
                dgvStats.Rows.Add("Suicides", suicides.Sum, suicides.Avg, suicides.Min, suicides.Max, suicides.StdDev);

            AggregateDataSet.Betrayals_AggregateRow betrayals = dataSet.Betrayals_Aggregate[0];
            if(betrayals.IsStdDevNull())
                dgvStats.Rows.Add("Betrayals", betrayals.Sum, betrayals.Avg, betrayals.Min, betrayals.Max, NOTAVAILABLE);
            else
                dgvStats.Rows.Add("Betrayals", betrayals.Sum, betrayals.Avg, betrayals.Min, betrayals.Max, betrayals.StdDev);

            AggregateDataSet.Shots_Fired_AggregateRow shotsFired = dataSet.Shots_Fired_Aggregate[0];
            if(shotsFired.IsStdDevNull())
                dgvStats.Rows.Add("Shots Fired", shotsFired.Sum, shotsFired.Avg, shotsFired.Min, shotsFired.Max, NOTAVAILABLE);
            else
                dgvStats.Rows.Add("Shots Fired", shotsFired.Sum, shotsFired.Avg, shotsFired.Min, shotsFired.Max, shotsFired.StdDev);

            AggregateDataSet.Shots_Hit_AggregateRow shotsHit = dataSet.Shots_Hit_Aggregate[0];
            if(shotsHit.IsStdDevNull())
                dgvStats.Rows.Add("Shots Hit", shotsHit.Sum, shotsHit.Avg, shotsHit.Min, shotsHit.Max, NOTAVAILABLE);
            else
                dgvStats.Rows.Add("Shots Hit", shotsHit.Sum, shotsHit.Avg, shotsHit.Min, shotsHit.Max, shotsHit.StdDev);

            AggregateDataSet.Headshots_AggregateRow headshots = dataSet.Headshots_Aggregate[0];
            if(headshots.IsStdDevNull())
                dgvStats.Rows.Add("Headshots", headshots.Sum, headshots.Avg, headshots.Min, headshots.Max, NOTAVAILABLE);
            else
                dgvStats.Rows.Add("Headshots", headshots.Sum, headshots.Avg, headshots.Min, headshots.Max, headshots.StdDev);

            AggregateDataSet.Accuracy_AggregateRow accuracy = dataSet.Accuracy_Aggregate[0];
            if(accuracy.IsStdDevNull())
                dgvStats.Rows.Add("Accuracy", NOTAVAILABLE, accuracy.Avg, accuracy.Min, accuracy.Max, NOTAVAILABLE);
            else
                dgvStats.Rows.Add("Accuracy", NOTAVAILABLE, accuracy.Avg, accuracy.Min, accuracy.Max, accuracy.StdDev);

            AggregateDataSet.Total_Medals_AggregateRow totalMedals = dataSet.Total_Medals_Aggregate[0];
            if(totalMedals.IsStdDevNull())
                dgvStats.Rows.Add("Total Medals", totalMedals.Sum, totalMedals.Avg, totalMedals.Min, totalMedals.Max, NOTAVAILABLE);
            else
                dgvStats.Rows.Add("Total Medals", totalMedals.Sum, totalMedals.Avg, totalMedals.Min, totalMedals.Max, totalMedals.StdDev);

            foreach (AggregateDataSet.Stat1_AggregateRow row in dataSet.Stat1_Aggregate)
            {
                if (row.IsStdDevNull())
                {
                    if (row.Stat1IsTime)
                    {
                        dgvStats.Rows.Add(row.Stat1Name, new GameLength((int)row.Sum), new GameLength((int)(row.Avg + .5)),
                            new GameLength((int)row.Min), new GameLength(row.Max), "N/A");
                    }
                    else
                        dgvStats.Rows.Add(row.Stat1Name, row.Sum, row.Avg, row.Min, row.Max, "N/A");
                }
                else
                {
                    if (row.Stat1IsTime)
                    {
                        dgvStats.Rows.Add(row.Stat1Name, new GameLength((int)row.Sum), new GameLength((int)(row.Avg + .5)),
                            new GameLength((int)row.Min), new GameLength(row.Max), new GameLength((int)(row.StdDev + .5)));
                    }
                    else
                        dgvStats.Rows.Add(row.Stat1Name, row.Sum, row.Avg, row.Min, row.Max, row.StdDev);
                }
            }

            foreach (AggregateDataSet.Stat2_AggregateRow row in dataSet.Stat2_Aggregate)
            {
                if (row.IsStdDevNull())
                {
                    if (row.Stat2IsTime)
                    {
                        dgvStats.Rows.Add(row.Stat2Name, new GameLength((int)row.Sum), new GameLength((int)(row.Avg + .5)),
                            new GameLength((int)row.Min), new GameLength(row.Max), "N/A");
                    }
                    else
                        dgvStats.Rows.Add(row.Stat2Name, row.Sum, row.Avg, row.Min, row.Max, "N/A");
                }
                else
                {
                    if (row.Stat2IsTime)
                    {
                        dgvStats.Rows.Add(row.Stat2Name, new GameLength((int)row.Sum), new GameLength((int)(row.Avg + .5)),
                            new GameLength((int)row.Min), new GameLength(row.Max), new GameLength((int)(row.StdDev + .5)));
                    }
                    else
                        dgvStats.Rows.Add(row.Stat2Name, row.Sum, row.Avg, row.Min, row.Max, row.StdDev);
                }
            }
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Increment(1);
        }

        private void TotalsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.StatNameColumnWidth = statNameColumn.Width;
            Settings.Default.StatAverageColumnWidth = statAvgColumn.Width;
            Settings.Default.StatMaxColumnWidth = statMaxColumn.Width;
            Settings.Default.StatMinColumnWidth = statMinColumn.Width;
            Settings.Default.StatStdDevColumnWidth = statStdDevColumn.Width;
            Settings.Default.StatTotalColumnWidth = statTotalColumn.Width;

            Settings.Default.MedalAvgColumnWidth = medalAvgColumn.Width;
            Settings.Default.MedalIconColumnWidth = medalIconColumn.Width;
            Settings.Default.MedalMaxColumnWidth = medalMaxColumn.Width;
            Settings.Default.MedalMinColumnWidth = medalMinColumn.Width;
            Settings.Default.MedalTotalColumnWidth = medalTotalColumn.Width;
            Settings.Default.MedalStdDevColumnWidth = medalStdDevColumn.Width;
            Settings.Default.MedalNameColumnWidth = medalNameColumn.Width;

            if (cboGamertags.SelectedIndex != -1)
                Settings.Default.LastViewedGamertag = (string)cboGamertags.SelectedItem;
        }

        private void cboGamertag_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlayerRankTableAdapter rankAdapter = new PlayerRankTableAdapter();
            HaloDataSet.PlayerRankDataTable playerRanks = rankAdapter.GetData((string)cboGamertags.SelectedItem);
            this.levelPanel.SetRanks(playerRanks, Application.StartupPath + @"\Images\Levels\L{0:00}.gif");
            rankAdapter.Dispose();

            if (System.IO.File.Exists(Application.StartupPath + @"\Images\PlayerIcons\" +
                (string)cboGamertags.SelectedItem + ".bmp"))
            {
                if (imgCurrentIcon.Image != null)
                    imgCurrentIcon.Image.Dispose();
                imgCurrentIcon.Image = Image.FromFile(Application.StartupPath + @"\Images\PlayerIcons\" +
                    (string)cboGamertags.SelectedItem + ".bmp");
            }
        }

        private void GraphType_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if ((rb != null)&&(rb.Checked))
            {
                DataGridView dgv = (DataGridView)rb.Tag;
                pie1.Clear();
                pie1.BeginUpdate();
                for (int i = 0; i < dgv.Rows.Count; i++)
                    pie1.Add((int)dgv.Rows[i].Cells[1].Value,
                        (string)dgv.Rows[i].Cells[0].Value);
                pie1.EndUpdate();
                tChart1.Text = rb.Text;
            }
        }
    }
}