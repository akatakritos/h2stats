using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using H2Stats.Data;
using H2Stats.Data.HaloDataSetTableAdapters;
using H2Stats.Data.AggregateDataSetTableAdapters;
using H2Stats.Properties;

namespace H2Stats
{
    public partial class GameSearchForm : Form
    {
        delegate void Invoker();
        private HaloDataSet.MedalInfoDataTable medalInfo;
        private HaloDataSet.ColorInfoDataTable colorInfo;
        private IHaloInfoSupplier infoSupplier;
        private List<IGameViewerLauncher> gameViewers;
        public GameSearchForm(IHaloInfoSupplier infoSupplier, List<IGameViewerLauncher> gameViewers)
        {
            InitializeComponent();
            foreach (HaloDataSet.TagListRow row in infoSupplier.TagList)
                cboGamertags.Items.Add(row.Gamertag);
            cboGamertags.SelectedItem = Settings.Default.LastViewedGamertag;
            this.infoSupplier = infoSupplier;
            this.medalInfo = infoSupplier.MedalInfo;
            this.colorInfo = infoSupplier.ColorInfo;

            foreach (IGameViewerLauncher gameViewer in gameViewers)
                comboBox1.Items.Add(gameViewer.Name);
            if (Properties.Settings.Default.LastUsedGameViewer != null)
                comboBox1.SelectedItem = Properties.Settings.Default.LastUsedGameViewer;
            else
                comboBox1.SelectedIndex = 0;
            this.gameViewers = gameViewers;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dataSorter.ClearAllSelections();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(performSearch), cboGamertags.SelectedItem);
        }

        private void performSearch(object o)
        {
            dataSorter.WriteSortData();
            Invoke(delegate() { progressBar.PerformStep(); });

            GamertagSearchTableAdapter gamertagSearch = new GamertagSearchTableAdapter();
            gamertagSearch.Clear();
            AggregateDataSet.GamertagSearchDataTable gamertags = new AggregateDataSet.GamertagSearchDataTable();
            gamertags.AddGamertagSearchRow(o as string);
            gamertagSearch.Update(gamertags);
            Invoke(delegate() { progressBar.PerformStep(); });
            
            GameSearchTableAdapter gameSearcher = new GameSearchTableAdapter();
            HaloDataSet.GameSearchDataTable searchResults = new HaloDataSet.GameSearchDataTable();
            gameSearcher.Fill(searchResults);
            Invoke(delegate() { progressBar.PerformStep(); });
            Invoke(delegate() { dgvResults.DataSource = searchResults; });
            Invoke(new Invoker(threadFinished));
        }

        private void threadFinished()
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void Invoke(Invoker invoker)
        {
            base.Invoke(invoker);
        }

        private void incrementProgressBar(object param)
        {
            progressBar.PerformStep();
        }

        private void GameSearchForm_Load(object sender, EventArgs e)
        {
            dataSorter.LoadDataAsync();
        }

        private void GameSearchForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (cboGamertags.SelectedItem != null)
                Settings.Default.LastViewedGamertag = (string)cboGamertags.SelectedItem;
            if (comboBox1.SelectedItem != null)
                Settings.Default.LastUsedGameViewer = (string)comboBox1.SelectedItem;
        }

        public override string ToString()
        {
            return this.Text;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(launchGameViewers), 
                new object[]{comboBox1.SelectedItem as string, cboGamertags.SelectedItem as string, dgvResults.SelectedRows});
        }

        private void launchGameViewers(object param)
        {
            object[] parameters = (object[])param;
            string gameViewerName = (string)parameters[0];
            string gamertag = (string)parameters[1];
            DataGridViewSelectedRowCollection selRows = (DataGridViewSelectedRowCollection)parameters[2];
            IGameViewerLauncher launcer = gameViewers[0];

            //Find gameviewer

            for(int i = 0; i < gameViewers.Count; i++)
            {
                if (gameViewers[i].Name == gameViewerName)
                {
                    launcer = gameViewers[i];
                    break;
                }
            }

            foreach (DataGridViewRow row in selRows)
            {
                string gameID = row.Cells[0].Value as string;
                HaloDataSet gameData = new HaloDataSet();

                GameTableAdapter gta = new GameTableAdapter();
                gta.FillByGameID(gameData.Game, gameID);

                GamePlayerTableAdapter gpta = new GamePlayerTableAdapter();
                gpta.FillByGameID(gameData.GamePlayer, gameID);

                GamePlayerMedalTableAdapter gpmta = new GamePlayerMedalTableAdapter();
                gpmta.FillByGameID(gameData.GamePlayerMedal, gameID);

                this.Invoke(new Invoker(delegate(){launcer.Launch(gamertag, gameData.Game[0], this.infoSupplier, this.MdiParent);}));
            }
        }


        private void dgvResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnOpen_Click(null, null);
        }
    }
}