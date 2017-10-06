using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Kvics.HotMill.Forms
{
    public partial class SubFormDialog : Form
    {
        public SubFormDialog()
        {
            InitializeComponent();
        }

        private void SubFormDialog_Load(object sender, EventArgs e)
        {
            /*
            this.Left = (SystemInformation.WorkingArea.Right - SystemInformation.WorkingArea.Left - this.Width) / 2;
            if (this.Owner != null)
            {
                this.Top = this.Owner.Bottom;
            }
            else
            {
                this.Top = SystemInformation.WorkingArea.Top + 142;
            }
            */
        }

        protected void textBox_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                ((TextBox)sender).SelectAll();
            }
        }

        private void SubFormDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Focus();
            }
        }
    }
}