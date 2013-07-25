using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace H2Stats.Controls
{
    public class LinkedStatLabel : System.Windows.Forms.LinkLabel
    {
        public LinkedStatLabel()
            : base()
        {
            m_value = 0;
            Description = "Stat";
            this.LinkColor = SystemColors.ControlText;
            
            this.LinkArea = new System.Windows.Forms.LinkArea(Description.Length + 1, Value.ToString().Length);
            this.LinkClicked += new LinkLabelLinkClickedEventHandler(LinkedStatLabel_LinkClicked);
        }

        void LinkedStatLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(url);
        }

        private object m_value;
        private string m_description;
        private string url = "http://wwww.google.com";

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
                this.LinkArea = new LinkArea(Description.Length + 2, Value.ToString().Length);
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
                this.LinkArea = new LinkArea(Description.Length + 2, Value.ToString().Length);
            }
        }

        [Browsable(true), DefaultValue("http://wwww.google.com")]
        public string Url
        {
            set { url = value; }
            get { return url; }
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
