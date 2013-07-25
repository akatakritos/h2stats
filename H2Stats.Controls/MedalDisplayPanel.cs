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
    public partial class MedalDisplayPanel : FlowLayoutPanel
    {
        public MedalDisplayPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Adds / removes medals to the panel
        /// </summary>
        /// <param name="medals">An array of datarows to use as source material</param>
        /// <param name="medalIconFilenameFormat">The format to find medal icons. For example:
        /// C:\HaloMedals\{0}.gif" can be formatted to build "C:\HaloMedals\Double Kill.gif"</param>
        public void SetMedals(HaloDataSet.GamePlayerMedalRow[] medals, IMedalsImageCache medalImages)
        {
            for (int i = 0; i < medals.Length; i++)
            {
                if (i < this.Controls.Count)
                {
                    MedalDisplay md = (MedalDisplay)this.Controls[i];
                    md.Image.Dispose();
                    md.Image = medalImages.GetByName(medals[i].MedalName); //Image.FromFile(String.Format(medalIconFilenameFormat, medals[i].MedalName));
                    md.Count = medals[i].Count;
                }
                else
                {
                    MedalDisplay md = new MedalDisplay();
                    md.Image = medalImages.GetByName(medals[i].MedalName); //Image.FromFile(String.Format(medalIconFilenameFormat, medals[i].MedalName));
                    md.Count = medals[i].Count;
                    this.Controls.Add(md);
                }
            }

            //If there are less ranks in the table than levelDisplays, delete extra ones
            while (this.Controls.Count > medals.Length)
            {
                Controls[Controls.Count - 1].Dispose();
                //Controls.RemoveAt(Controls.Count - 1);
            }
        }
    }
}
