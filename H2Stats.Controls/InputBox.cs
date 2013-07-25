using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace H2Stats.Controls
{
    public partial class InputBox
    {
        /// <summary>
        /// Displays a simple form prompting the user for string input
        /// </summary>
        /// <param name="prompt">The prompt text</param>
        /// <returns></returns>
        public static string Show(string prompt)
        {
            frmInputBox f = new frmInputBox();
            f.Prompt = prompt;
            string result;
            if (f.ShowDialog() == DialogResult.OK)
                result = f.Input;
            else
                result = null;
            f.Dispose();
            return result;
            
        }

        /// <summary>
        /// Displays a simple form prompting the user for string input
        /// </summary>
        /// <param name="prompt">The prompt text</param>
        /// <param name="title">The title for the form</param>
        /// <returns></returns>
        public static string Show(string prompt, string title)
        {
            frmInputBox f = new frmInputBox();
            f.Prompt = prompt;
            f.Text = title;
            string result;
            if (f.ShowDialog() == DialogResult.OK)
                result = f.Input;
            else
                result = null;
            f.Dispose();
            return result;
        }

        /// <summary>
        /// Displays a simple form prompting the user for string input
        /// </summary>
        /// <param name="prompt">The prompt text</param>
        /// <param name="title"></param>
        /// <param name="initialText">Initial text in the input box</param>
        /// <returns></returns>
        public static string Show(string prompt, string title, string initialText)
        {
            frmInputBox f = new frmInputBox();
            f.Prompt = prompt;
            f.Text = title;
            f.InitialText = initialText;
            string result;
            if (f.ShowDialog() == DialogResult.OK)
                result = f.Input;
            else
                result = null;
            f.Dispose();
            return result;
        }

        /// <summary>
        /// Displays a simple form prompting the user for string input
        /// </summary>
        /// <param name="prompt">The prompt text</param>
        /// <param name="title"></param>
        /// <param name="initialText">Initial text in the input box</param>
        /// <param name="startPosition">The starting location for the input box</param>
        /// <returns></returns>
        public static string Show(string prompt, string title, string initialText, FormStartPosition startPosition)
        {
            frmInputBox f = new frmInputBox();
            f.Prompt = prompt;
            f.Text = title;
            f.InitialText = initialText;
            f.StartPosition = startPosition;
            string result;
            if (f.ShowDialog() == DialogResult.OK)
                result = f.Input;
            else
                result = null;
            f.Dispose();
            return result;
        }

        private partial class frmInputBox : Form
        {
            public frmInputBox()
            {
                InitializeComponent();
                this.btnOK.Click += new EventHandler(btnOK_Click);
                this.btnCancel.Click += new EventHandler(btnCancel_Click);
                textBox1.Focus();
                textBox1.SelectAll();
            }

            void btnCancel_Click(object sender, EventArgs e)
            {
                this.DialogResult = DialogResult.Cancel;
            }

            void btnOK_Click(object sender, EventArgs e)
            {
                this.DialogResult = DialogResult.OK;
            }

            public string Prompt
            {
                set
                {
                    lblDescription.Text = value;
                }

                get
                {
                    return lblDescription.Text;
                }
            }

            public string InitialText
            {
                set
                {
                    this.textBox1.Text = value;
                }
            }

            public string Input
            {
                get
                {
                    return this.textBox1.Text;
                }
            }
        }
    }
}