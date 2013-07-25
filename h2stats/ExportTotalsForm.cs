using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using H2Stats.Data;
using H2Stats.Properties;
using System.IO;

namespace H2Stats
{
    public partial class ExportTotalsForm : Form
    {
        delegate void Invoker();
        private HaloDataSet.MedalInfoDataTable medalInfo;
        private HaloDataSet.ColorInfoDataTable colorInfo;
        List<ITotalsExport> mPlugins;

        public ExportTotalsForm(HaloDataSet.TagListDataTable tagList, 
            HaloDataSet.MedalInfoDataTable medalInfo,
            HaloDataSet.ColorInfoDataTable colorInfo)
        {
            InitializeComponent();
            foreach (HaloDataSet.TagListRow row in tagList)
                cboGamertags.Items.Add(row.Gamertag);
            cboGamertags.SelectedItem = Settings.Default.LastViewedGamertag;
            this.medalInfo = medalInfo;
            this.colorInfo = colorInfo;

            loadPlugins();
        }

        private void loadPlugins()
        {
            mPlugins = PluginLoader.GetPlugins<ITotalsExport>(Application.StartupPath + @"\TotExp_*.dll");
            listView1.Items.Clear();
            foreach(ITotalsExport exporter in mPlugins)
            {
                ListViewItem lvi = new ListViewItem(exporter.Name);
                lvi.Tag = exporter;
                lvi.SubItems.Add(exporter.Description);
                listView1.Items.Add(lvi);
            }
        }
    }
}