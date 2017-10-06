using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Kvics.HotMill.Forms
{
    public partial class SubFormFullScreen : Form
    {
        public event FormFinishSupport_KeyEventHandler OnPuPd_Press;
        public SubFormFullScreen()
        {
            InitializeComponent();
        }

        private void SubFormFullScreen_Load(object sender, EventArgs e)
        {
            this.Width = SystemInformation.WorkingArea.Width;
            this.Height = SystemInformation.WorkingArea.Height;

            //this.Width = 1920;
            //this.Height = 1200;

            this.Left = SystemInformation.WorkingArea.Left;
            this.Top = SystemInformation.WorkingArea.Top;

            //this.WindowState = FormWindowState.Maximized;
            /*
            this.Width = SystemInformation.WorkingArea.Width;
            this.Left = SystemInformation.WorkingArea.Left;
            if (this.Owner != null)
            {
                this.Top = this.Owner.Bottom;
                this.Height = SystemInformation.WorkingArea.Height - this.Owner.Bottom;
            }
            else
            {
                this.Top = SystemInformation.WorkingArea.Top + 142;
                this.Height = SystemInformation.WorkingArea.Height - 142;
            }
            */
        }

        private Control FindControl(string controlName, Control parent)
        {
            foreach (Control ctr in parent.Controls)
            {
                if (ctr.Name == controlName)
                {
                    return ctr;
                }
                else
                {
                    Control ctr1 = FindControl(controlName, ctr);
                    if (ctr1 != null)
                    {
                        return ctr1;
                    }
                }
            }

            return null;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.PageUp:
                    if (this.OnPuPd_Press != null)
                    {
                        this.OnPuPd_Press(this, Keys.PageUp);
                    }
                    break;
                case Keys.PageDown:
                    if (this.OnPuPd_Press != null)
                    {
                        this.OnPuPd_Press(this, Keys.PageDown);
                    }
                    break;
                case Keys.Home:
                    if (this.OnPuPd_Press != null)
                    {
                        this.OnPuPd_Press(this, Keys.Home);
                    }
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}