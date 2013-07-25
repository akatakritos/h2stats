using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using H2Stats.Data;

namespace H2Stats.Controls
{
    public partial class LevelDisplayPanel : FlowLayoutPanel
    {
        public LevelDisplayPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the ranks contained within the panel
        /// </summary>
        /// <param name="playerRanks">The data table with all the ranks to display</param>
        /// <param name="iconFilenameFormat">A string that can be formatted to provide the filename for an icon,
        /// for example "C:\\Icons\\Level_{0}.gif"</param>
        public void SetRanks(HaloDataSet.PlayerRankDataTable playerRanks, string iconFilenameFormat)
        {
            for (int i = 0; i < playerRanks.Count; i++)
            {
                if (i < this.Controls.Count)
                {
                    LevelDisplay ld = (LevelDisplay)this.Controls[i];
                    ld.FileName = String.Format(iconFilenameFormat, playerRanks[i].Rank);
                    ld.Percent = playerRanks[i].Percent;
                    ld.PlaylistName = playerRanks[i].Playlist;
                }
                else
                {
                    LevelDisplay ld = new LevelDisplay(
                        String.Format(iconFilenameFormat, playerRanks[i].Rank),
                        playerRanks[i].Playlist,
                        playerRanks[i].Percent);
                    this.Controls.Add(ld);
                }
            }

            //If there are less ranks in the table than levelDisplays, delete extra ones
            while (this.Controls.Count > playerRanks.Count)
            {
                Controls[Controls.Count - 1].Dispose();
                //Controls.RemoveAt(Controls.Count - 1);
            }
        }        
    }
}
