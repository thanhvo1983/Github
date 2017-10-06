using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Kvics.Controls.SplashLibrary
{
    public partial class SplashScreen : Form, IDynamicSplashScreen
    {
        private const Int32 TIMER_INTERVAL = 50;
        private const Double _OpacityIncrement = .05;
        private const Double _OpacityDecrement = .05;
        public SplashScreen()
        {
            InitializeComponent();
            this.Opacity = .00;
            this.tTimer.Interval = TIMER_INTERVAL;
            this.tTimer.Start();
        }

        public void SetStatus(String status)
        {
            SendStatusMessage(status);            
        }

        public void SendStatusMessage(String message)
        {
            this.lbStatus.Text = message;
        }

        private void tTimer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += _OpacityIncrement;
            }
        }
    }
}