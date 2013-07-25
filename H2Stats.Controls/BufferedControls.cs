using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace H2Stats.Controls
{
    public class BufferedGroupBox : GroupBox
    {
        public BufferedGroupBox()
            : base()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }
    }

    public class BufferedTabPage : TabPage
    {
        public BufferedTabPage() : base()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }
    }

    public class BufferedTabControl : TabControl
    {
        public BufferedTabControl()
            : base()
        {
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }
    }
}
