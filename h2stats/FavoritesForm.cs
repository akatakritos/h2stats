using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using H2Stats.Data;
using System.Threading;
using H2Stats.Data.HaloDataSetTableAdapters;

namespace H2Stats
{
    public partial class FavoritesForm : Form
    {
        public IHaloInfoSupplier infoSupplier;
        delegate void Invoker();
        List<IGameViewerLauncher> gameViewers;

        public FavoritesForm(IHaloInfoSupplier infoSupplier, List<IGameViewerLauncher> gameViewers)
        {
            InitializeComponent();
            this.infoSupplier = infoSupplier;
            this.gameViewers = gameViewers;
            foreach (IGameViewerLauncher launcher in gameViewers)
            {
                comboBox1.Items.Add(launcher.Name);
            }
            if (Properties.Settings.Default.LastUsedGameViewer != null)
                comboBox1.SelectedItem = Properties.Settings.Default.LastUsedGameViewer;
            else
                comboBox1.SelectedIndex = 0;
        }

        private void FavoritesForm_Shown(object sender, EventArgs e)
        {
            foreach (HaloDataSet.FavoritesRow row in infoSupplier.Favorites)
            {
                this.dataGridView1.Rows.Add(row.GameID, row.Matchtype, row.Date, row.Time,
                    row.Map, row.Playlist);
                this.dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = row.Description;
                //this.dataGridView1.Selection
            }
            dataGridView1_SelectionChanged(null, null); //force a selection event so the description box is edited
            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 1)
            {
                txtDescription.Text = "";
                txtDescription.ReadOnly = true;
            }
            else
            {
                txtDescription.Text = dataGridView1.SelectedRows[0].Tag as string;
                txtDescription.ReadOnly = false;
            }

            btnSaveChanges.Enabled = false;
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnSaveChanges.Enabled = true;
        }

        private void btnSaveChanges_KeyPress(object sender, EventArgs e)
        {
            dataGridView1.SelectedRows[0].Tag = txtDescription.Text;
            HaloDataSet.FavoritesRow row = infoSupplier.Favorites.FindByGameID(
                (string)dataGridView1.SelectedRows[0].Cells[0].Value);
            row.Description = txtDescription.Text;
        }

        //remove button
        private void btnRemove_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
            infoSupplier.Favorites.RemoveFavoritesRow(
                infoSupplier.Favorites.FindByGameID(
                (string)dataGridView1.SelectedRows[0].Cells[0].Value));
        }

        //open
        private void btnOpen_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(launchGameViewers),
                new object[] { comboBox1.SelectedItem as string, Properties.Settings.Default.LastViewedGamertag, dataGridView1.SelectedRows });
        }

        private void launchGameViewers(object param)
        {
            object[] parameters = (object[])param;
            string gameViewerName = (string)parameters[0];
            string gamertag = (string)parameters[1];
            DataGridViewSelectedRowCollection selRows = (DataGridViewSelectedRowCollection)parameters[2];
            IGameViewerLauncher launcer = gameViewers[0];

            //Find gameviewer

            for (int i = 0; i < gameViewers.Count; i++)
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

                this.Invoke(new Invoker(delegate() { launcer.Launch(gamertag, gameData.Game[0], this.infoSupplier, this.MdiParent); }));
            }
        }

        public override string ToString()
        {
            return "Favorite Games";
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnOpen_Click(null, null);
        }

    }
}