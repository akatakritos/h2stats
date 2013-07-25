using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using H2Stats.Data;
using H2Stats.Data.HaloDataSetTableAdapters;
using H2Stats.Data.AggregateDataSetTableAdapters;
using H2Stats.Data.ListsDataSetTableAdapters;

namespace H2Stats.Controls
{
    public partial class DataSorter : UserControl
    {
        delegate void MarshalToUIThread(DataTable d);
        public DataSorter()
        {
            InitializeComponent();
            rankedPlaylists = new List<string>();
            unRankedPlaylists = new List<string>();
            currentPlaylists = new List<string>();
            //CheckForIllegalCrossThreadCalls = false;
        }

        List<string> rankedPlaylists;
        List<string> unRankedPlaylists;
        List<string> currentPlaylists;

        public void LoadDataAsync()
        {
            foreach (Control c in this.tableLayoutPanel1.Controls)
            {
                if (c.Text == "Loading...")
                    c.Visible = true;
                else
                    c.Visible = false;
            }

            lblLoading.Visible = true;
            lblLoading.BringToFront();

            worker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            using (FindAllPlaylistsTableAdapter playAdapter = new FindAllPlaylistsTableAdapter())
            using (FindAllGametypesTableAdapter gameAdapter = new FindAllGametypesTableAdapter())
            using (FindAllMatchtypesTableAdapter matchAdapter = new FindAllMatchtypesTableAdapter())
            using (FindAllMapsTableAdapter mapAdapter = new FindAllMapsTableAdapter())
            {
                ListsDataSet d = new ListsDataSet();

                playAdapter.Fill(d.FindAllPlaylists);
                gameAdapter.Fill(d.FindAllGametypes);
                matchAdapter.Fill(d.FindAllMatchtypes);
                mapAdapter.Fill(d.FindAllMaps);

                e.Result = d;
            }

            using (PlaylistInfoTableAdapter rankedAdapter = new PlaylistInfoTableAdapter())
            {
                HaloDataSet.PlaylistInfoDataTable playlistInfo = rankedAdapter.GetData();

                foreach(HaloDataSet.PlaylistInfoRow row in playlistInfo)
                {
                    if (row.IsRanked)
                        rankedPlaylists.Add(row.Name);
                    else
                    {
                        if (row.Name != "Arranged Game")
                            unRankedPlaylists.Add(row.Name);
                    }

                    if (row.IsCurrent)
                        currentPlaylists.Add(row.Name);
                }

                playlistInfo.Dispose();
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (Control c in this.tableLayoutPanel1.Controls)
            {
                if (c.Text == "Loading...")
                    c.Visible = false;
                else
                    c.Visible = true;
            }

            lblLoading.Visible = false;

            ListsDataSet data = (ListsDataSet)e.Result;

            lbPlaylists.BeginUpdate();
            lbPlaylists.Items.Clear();
            foreach (ListsDataSet.FindAllPlaylistsRow row in data.FindAllPlaylists)
                lbPlaylists.Items.Add(row.Playlist);
            lbPlaylists.EndUpdate();

            lbMaps.BeginUpdate();
            lbMaps.Items.Clear();
            foreach (ListsDataSet.FindAllMapsRow row in data.FindAllMaps)
                lbMaps.Items.Add(row.Map);
            lbMaps.EndUpdate();

            lbGametypes.BeginUpdate();
            lbGametypes.Items.Clear();
            foreach (ListsDataSet.FindAllGametypesRow row in data.FindAllGametypes)
                lbGametypes.Items.Add(row.Gametype);
            lbGametypes.EndUpdate();

            lbMatchtypes.BeginUpdate();
            lbMatchtypes.Items.Clear();
            foreach (ListsDataSet.FindAllMatchtypesRow row in data.FindAllMatchtypes)
                lbMatchtypes.Items.Add(row.Matchtype);
            lbMatchtypes.EndUpdate();

            data.Dispose();
        }

        public void WriteSortData()
        {
            MatchtypeSearchTableAdapter matchAdapter = new MatchtypeSearchTableAdapter();
            GametypeSearchTableAdapter gametypeAdapter = new GametypeSearchTableAdapter();
            MapSearchTableAdapter mapAdapter = new MapSearchTableAdapter();
            DateSearchTableAdapter dateAdapter = new DateSearchTableAdapter();
            PlaylistSearchTableAdapter playlistAdapter = new PlaylistSearchTableAdapter();

            AggregateDataSet.MatchtypeSearchDataTable matchtypes = new AggregateDataSet.MatchtypeSearchDataTable();
            lbMatchtypes.Invoke(new MarshalToUIThread(copyToMatchtypes), matchtypes);

            AggregateDataSet.MapSearchDataTable maps = new AggregateDataSet.MapSearchDataTable();
            lbMaps.Invoke(new MarshalToUIThread(copyToMaps), maps);

            AggregateDataSet.GametypeSearchDataTable gametypes = new AggregateDataSet.GametypeSearchDataTable();
            lbGametypes.Invoke(new MarshalToUIThread(copyToGametpes), gametypes);

            AggregateDataSet.DateSearchDataTable dates = new AggregateDataSet.DateSearchDataTable();
            lbMaps.Invoke(new MarshalToUIThread(copyToDates), dates);
            dateAdapter.Clear();
            if (dates.Count == 0)                
                dateAdapter.AddAllDates(); //Use query to copy all dates in GamePlayer into DateSearch
            else
                dateAdapter.Update(dates);

            AggregateDataSet.PlaylistSearchDataTable playlists = playlistAdapter.GetData();
            playlists.Clear();
            lbPlaylists.Invoke(new MarshalToUIThread(copyToPlaylists), playlists);

            gametypeAdapter.Clear();
            playlistAdapter.Clear();
            mapAdapter.Clear();
            matchAdapter.Clear();
            //dateAdapter.Clear();

            playlistAdapter.Update(playlists);
            gametypeAdapter.Update(gametypes);
            mapAdapter.Update(maps);
            //dateAdapter.Update(dates);
            matchAdapter.Update(matchtypes);

            //Dispose

            playlistAdapter.Dispose();
            gametypeAdapter.Dispose();
            mapAdapter.Dispose();
            dateAdapter.Dispose();
            matchAdapter.Dispose();

            playlists.Dispose();
            gametypes.Dispose();
            matchtypes.Dispose();
            dates.Dispose();
            maps.Dispose();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TimeSpan ts = new TimeSpan(1, 0,0,0);
            for(DateTime date = calendar.SelectionStart; date <= calendar.SelectionEnd; date += ts)
            {
                if(!lbDates.Items.Contains(date.ToString("M/d/yyyy")))
                    lbDates.Items.Add(date.ToString("M/d/yyyy"));
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            object[] selectedItems = new object[lbDates.SelectedIndices.Count];
            lbDates.SelectedItems.CopyTo(selectedItems, 0);
            foreach (object o in selectedItems)
                lbDates.Items.Remove(o);
        }

        private void miSelectRanked_Click(object sender, EventArgs e)
        {
            lbPlaylists.ClearSelected();
            foreach (string playlist in rankedPlaylists)
                lbPlaylists.SelectedItems.Add(playlist);
        }

        private void miSelectUnranked_Click(object sender, EventArgs e)
        {
            lbPlaylists.ClearSelected();
            foreach (string playlist in unRankedPlaylists)
                lbPlaylists.SelectedItems.Add(playlist);
        }

        private void miSelectCurrent_Click(object sender, EventArgs e)
        {
            lbPlaylists.ClearSelected();
            foreach (string playlist in currentPlaylists)
                lbPlaylists.SelectedItems.Add(playlist);
        }

        public void ClearAllSelections()
        {
            lbMaps.ClearSelected();
            lbMatchtypes.ClearSelected();
            lbDates.Items.Clear();
            lbGametypes.ClearSelected();
            lbPlaylists.ClearSelected();
        }

        #region Access UI Listbox Items
        private void copyToMatchtypes(DataTable d)
        {
            AggregateDataSet.MatchtypeSearchDataTable matchtypes = (AggregateDataSet.MatchtypeSearchDataTable)d;
            if (lbMatchtypes.SelectedItems.Count > 0)
            {
                foreach (string matchtype in lbMatchtypes.SelectedItems)
                    matchtypes.AddMatchtypeSearchRow(matchtype);
            }
            else
            {
                foreach (string matchtype in lbMatchtypes.Items)
                    matchtypes.AddMatchtypeSearchRow(matchtype);
            }
        }

        private void copyToMaps(DataTable d)
        {
            AggregateDataSet.MapSearchDataTable maps = (AggregateDataSet.MapSearchDataTable)d;
            if (lbMaps.SelectedItems.Count > 0)
            {
                foreach (string map in lbMaps.SelectedItems)
                    maps.AddMapSearchRow(map);
            }
            else
            {
                foreach (string map in lbMaps.Items)
                    maps.AddMapSearchRow(map);
            }
        }

        private void copyToGametpes(DataTable d)
        {
            AggregateDataSet.GametypeSearchDataTable gametypes = (AggregateDataSet.GametypeSearchDataTable)d;
            if (lbGametypes.SelectedItems.Count > 0)
            {
                foreach (string gametype in lbGametypes.SelectedItems)
                    gametypes.AddGametypeSearchRow(gametype);
            }
            else
            {
                foreach (string gametype in lbGametypes.Items)
                    gametypes.AddGametypeSearchRow(gametype);
            }
        }

        private void copyToDates(DataTable d)
        {
            AggregateDataSet.DateSearchDataTable dates = (AggregateDataSet.DateSearchDataTable)d;
            if (lbDates.Items.Count > 0)
            {
                foreach (string date in lbDates.Items)
                    dates.AddDateSearchRow(date);
            }
        }

        private void copyToPlaylists(DataTable d)
        {
            AggregateDataSet.PlaylistSearchDataTable playlists = (AggregateDataSet.PlaylistSearchDataTable)d;
            if (lbPlaylists.SelectedItems.Count > 0)
            {
                foreach (string playlist in lbPlaylists.SelectedItems)
                    playlists.AddPlaylistSearchRow(playlist);
            }
            else
            {
                foreach (string playlist in lbPlaylists.Items)
                    playlists.AddPlaylistSearchRow(playlist);
            }
        }
        #endregion
    }
}
