using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Kvics.HotMill.Forms
{
    public partial class SubFormFull : Form
    {
        public SubFormFull()
        {
            InitializeComponent();
        }

        private void SubForm_Load(object sender, EventArgs e)
        {
            this.Width = SystemInformation.WorkingArea.Width;
            this.Left = SystemInformation.WorkingArea.Left;
            this.Top = SystemInformation.WorkingArea.Top;
            /*
            //this.Left = (SystemInformation.WorkingArea.Width - this.Width)/2;
            if (this.Owner != null)
            {
                this.Top = this.Owner.Bottom;
                //this.Height = SystemInformation.WorkingArea.Height - this.Owner.Bottom;
            }
            else
            {
                this.Top = SystemInformation.WorkingArea.Top + 142;
                //this.Height = SystemInformation.WorkingArea.Height - 142;
            }*/
        }
    }
}