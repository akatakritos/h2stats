using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace H2Stats.Controls
{
    public partial class StatLabel : Label
    {
        public StatLabel() : base()
        {
            m_value = 0;
            Description = "Stat";       
        }

        private object m_value;
        private string m_description;

        /// <summary>
        /// Gets or sets the stat value.
        /// </summary>
        [Browsable(false)]
        public object Value
        {
            get
            {
                return m_value;
            }

            set
            {
                m_value = value;
                this.Text = m_description + ": " + m_value.ToString();
            }
        }

        /// <summary>
        /// Gets or sets the stat description. ": " is appended automatically.
        /// </summary>
        [Browsable(true)]
        public string Description
        {
            get { return m_description; }
            set
            {
                m_description = value;
                this.Text = m_description + ": " + m_value.ToString();
            }
        }

        [Browsable(false)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }
    }
}
