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
using H2Stats.Properties;
using System.Threading;
using System.Diagnostics;

namespace H2Stats
{
    public partial class MainForm : Form, IHaloInfoSupplier
    {
        private HaloDataSet.TagListDataTable tagList;
        private HaloDataSet.MedalInfoDataTable medalInfo;
        private HaloDataSet.FavoritesDataTable favorites;
        private HaloDataSet.ColorInfoDataTable colorInfo;
        private HaloDataSet.PlaylistInfoDataTable playlistInfo;
        private List<IGameViewerLauncher> gameViewers;
        private List<ITotalsExport> totalsExporters;
        private List<IGameExport> gameExporters;
        private IImageCache mImages = new MasterImageCache();

        public MainForm()
        {
            InitializeComponent();
            tagList = new HaloDataSet.TagListDataTable();
            medalInfo = new HaloDataSet.MedalInfoDataTable();
            favorites = new HaloDataSet.FavoritesDataTable();
            colorInfo = new HaloDataSet.ColorInfoDataTable();
            playlistInfo = new HaloDataSet.PlaylistInfoDataTable();
            gameViewers = new List<IGameViewerLauncher>();
            gameViewers.Add(new DefaultGameViewerLauncher());
            totalsExporters = new List<ITotalsExport>();
            gameExporters = new List<IGameExport>();
            
            //ThreadPool.QueueUserWorkItem(new WaitCallback(loadMedalInfoAsync));
            //ThreadPool.QueueUserWorkItem(new WaitCallback(loadFavoritesListAsync));
            //ThreadPool.QueueUserWorkItem(new WaitCallback(loadColorInfoAsync));
        }

        private void loadColorInfoAsync(object param)
        {
            using (ColorInfoTableAdapter colAdapter = new ColorInfoTableAdapter())
            {
                colAdapter.Fill(colorInfo);
            }

        }

        private void loadFavoritesListAsync(object param)
        {
            FavoritesTableAdapter favAdapter = new FavoritesTableAdapter();
            lock (favorites)
            {
                favAdapter.Fill(favorites);
            }
            favAdapter.Dispose();
        }
        delegate void invoker();
        private void loadTagListAsync(object param)
        {

            Invoke(new invoker(delegate() { lblStatus.Text = "Loading tag list..."; }));
            TagListTableAdapter tagAdapter = new TagListTableAdapter();
            lock (tagList)
            {
                tagAdapter.Fill(tagList);
            }
            tagAdapter.Dispose();

            Invoke(new invoker(delegate(){
                lblStatus.Text = "Loading medal information...";
                progress.PerformStep();
            }));
            loadMedalInfoAsync(param);

            Invoke(new invoker(delegate(){
                lblStatus.Text = "Loading favorites list...";
                progress.PerformStep();
            }));
            loadFavoritesListAsync(param);

            Invoke(new invoker(delegate(){
                lblStatus.Text = "Loading color information...";
                progress.PerformStep();
            }));
            loadColorInfoAsync(param);

            Invoke(new invoker(delegate(){
                lblStatus.Text = "Loading playlist information...";
                progress.PerformStep();
            }));
            loadPlaylistInfo(param);            
            
           
        }

        private void loadPlaylistInfo(object param)
        {
            using (PlaylistInfoTableAdapter playlistAdapter = new PlaylistInfoTableAdapter())
            {
                playlistAdapter.Fill(playlistInfo);
            }
        }

        private void loadMedalInfoAsync(object param)
        {
            MedalInfoTableAdapter medalAdapter = new MedalInfoTableAdapter();
            lock (medalInfo)
            {
                medalAdapter.Fill(medalInfo);
            }
            medalAdapter.Dispose();
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }        

        private void miDownload_Click(object sender, EventArgs e)
        {
            DownloadForm df = new DownloadForm();
            df.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Settings.Default.Upgrade();
            Settings.Default.Reload();
            ThreadPool.QueueUserWorkItem(new WaitCallback(performBackgroundOperations));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }

        private void miTagList_Click(object sender, EventArgs e)
        {
            TagEditorForm f = new TagEditorForm(this.tagList);
            f.MdiParent = this;
            f.Show();
        }

        private void totalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TotalsForm f = new TotalsForm(tagList, medalInfo);
            f.MdiParent = this;
            f.Show();
        }

        void mdiChildClosed(object sender, FormClosedEventArgs e)
        {
            cboWindows.Items.Remove(sender);
            if (cboWindows.Items.Count == 0)
                cboWindows.Text = "";
            
        }

        private void cboWindows_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((Form)cboWindows.SelectedItem).Focus();
        }

        private void gameViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameSearchForm f = new GameSearchForm(this, gameViewers);
            f.MdiParent = this;
            f.Show();
        }

        private void MainForm_MdiChildActivate(object sender, EventArgs e)
        {
            Form f = this.ActiveMdiChild;
            if (f != null && !this.cboWindows.Items.Contains(f))
            {
                cboWindows.Items.Add(f);
                f.FormClosed += new FormClosedEventHandler(mdiChildClosed);
            }

            cboWindows.SelectedItem = f;
            if (f is IGameViewer)
            {
                this.btnDeleteGame.Enabled = true;
                this.btnViewOnline.Enabled = true;
                this.miExportGame.Enabled = true;

                if (favorites.FindByGameID(((IGameViewer)f).GameID) != null)
                    this.btnSaveFavorite.Enabled = false;
                else
                    this.btnSaveFavorite.Enabled = true;
            }
            else
            {
                this.btnDeleteGame.Enabled = false;
                this.btnViewOnline.Enabled = false;
                this.btnSaveFavorite.Enabled = false;
                this.miExportGame.Enabled = false;
            }

            if (f is TotalsForm)
            {
                if (((TotalsForm)f).TotalsCalculated)
                    miExportTotals.Enabled = true;
                else
                    miExportTotals.Enabled = false;
            }
            else
                miExportTotals.Enabled = false;
        }

        private void btnViewOnline_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild is IGameViewer)
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "http://www.bungie.net/Stats/GameStats.aspx?gameID=" + ((IGameViewer)this.ActiveMdiChild).GameID;
                psi.UseShellExecute = true;
                Process.Start(psi);
            }
        }

        private void btnCascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void btnCloseAll_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
                f.Close();
        }

        private void btnSaveFavorite_Click(object sender, EventArgs e)
        {
            IGameViewer currGame = this.ActiveMdiChild as IGameViewer;

            if (currGame != null)
            {
                if (favorites.FindByGameID(currGame.GameID) == null)
                {
                    HaloDataSet.FavoritesRow row = favorites.NewFavoritesRow();
                    row.GameID = currGame.GameRow.GameID;
                    row.Date = currGame.GameRow.Date;
                    row.Time = currGame.GameRow.Time;
                    row.Matchtype = currGame.GameRow.Matchtype;
                    row.Map = currGame.GameRow.Map;
                    row.Playlist = currGame.GameRow.Playlist;
                    string desc = H2Stats.Controls.InputBox.Show(
                        String.Format("Enter a description for this game ({0} on {1}).", row.Matchtype, row.Map),
                        "Favorites Game Description");

                    if (desc != null)
                    {
                        row.Description = desc;
                        favorites.AddFavoritesRow(row);
                        ThreadPool.QueueUserWorkItem(new WaitCallback(writeFavoritesAsync));
                    }
                }
            }
        }

        private void writeFavoritesAsync(object param)
        {
            using (FavoritesTableAdapter favAdapter = new FavoritesTableAdapter())
            {
                favAdapter.Update(favorites);
            }
        }

        private void miOpen_Click(object sender, EventArgs e)
        {
            //string gameID = 
            //    H2Stats.Controls.InputBox.Show("Enter the GameID for the game you would like to open.", "Open Game");
            //if (gameID != null)
            //{
            //    DefaultGameViewer f = new DefaultGameViewer(Settings.Default.LastViewedGamertag, this);
            //    f.GameID = gameID;
            //    f.MdiParent = this;
            //    f.Show();
            //}
        }

        #region IHaloInfoSupplier Members

        public HaloDataSet.ColorInfoDataTable ColorInfo
        {
            get { return this.colorInfo; }
        }

        public HaloDataSet.PlaylistInfoDataTable PlaylistInfo
        {
            get { return this.playlistInfo; }
        }

        public HaloDataSet.TagListDataTable TagList
        {
            get { return this.tagList; }
        }

        public HaloDataSet.MedalInfoDataTable MedalInfo
        {
            get { return this.medalInfo; }
        }

        public HaloDataSet.FavoritesDataTable Favorites
        {
            get { return this.favorites; }
        }

        public IImageCache Images
        {
            get { return mImages; }
        }

        #endregion

        private void favoritesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FavoritesForm f = new FavoritesForm(this, gameViewers);
            f.MdiParent = this;
            f.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm f = new AboutForm();
            f.ShowDialog();
        }

        private void performBackgroundOperations(object param)
        {
            loadTagListAsync(null);
            loadPlugins();
        }

        private void loadPlugins()
        {
            Invoke(new invoker(delegate()
            {
                lblStatus.Text = "Loading plugins...";
                progress.PerformStep();
            }));

            PluginLoader.FillPluginLists(Application.StartupPath + @"\Plugins", gameViewers, totalsExporters, gameExporters);
            Invoke(new invoker(delegate()
               {
                   lblStatus.Text = "Done.";
                   progress.Value = 0;
               }));

            Invoke(new invoker(fillPluginMenus));
            
        }

        private void fillPluginMenus()
        {
            foreach (ITotalsExport totalsExporter in totalsExporters)
            {
                ToolStripMenuItem mi = new ToolStripMenuItem();
                mi.Text = totalsExporter.Name;
                mi.ToolTipText = totalsExporter.Description;
                mi.Tag = totalsExporter;
                mi.Click += new EventHandler(TotalsExporter_Click);
                miExportTotals.DropDownItems.Add(mi);
            }

            foreach (IGameExport gameExporter in gameExporters)
            {
                ToolStripMenuItem mi = new ToolStripMenuItem();
                mi.Text = gameExporter.Name;
                mi.ToolTipText = gameExporter.Description;
                mi.Tag = gameExporter;
                mi.Click += new EventHandler(GameExporter_Click);
                miExportGame.DropDownItems.Add(mi);
            }
        }

        void GameExporter_Click(object sender, EventArgs e)
        {
            IGameExport gameExporter = (IGameExport)((ToolStripMenuItem)sender).Tag;
            IGameViewer gameViewer = ActiveMdiChild as IGameViewer;
            if (gameViewer != null)
                gameExporter.Export(gameViewer.GameRow, this);
        }

        void TotalsExporter_Click(object sender, EventArgs e)
        {
            ITotalsExport totalsExporter = (ITotalsExport)((ToolStripMenuItem)sender).Tag;
            TotalsForm totalsForm = ActiveMdiChild as TotalsForm;
            if (totalsForm != null)
                totalsExporter.Export(totalsForm.Gamertag, totalsForm.TotalsDataSet, this);
        }

        public void EnableTotalsExport()
        {
            miExportTotals.Enabled = true;
        }
    }
}