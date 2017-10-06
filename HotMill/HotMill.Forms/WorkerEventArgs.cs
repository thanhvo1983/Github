using System;
using System.Collections.Generic;
using System.Text;
using Kvics.HotMill.BL;

namespace Kvics.HotMill.Forms
{
    public class WorkerEventArgs : EventArgs
    {
        protected TWorker _Worker = null;
        public WorkerEventArgs(TWorker worker)
            : base()
        {
            _Worker = worker;
        }

        public TWorker Worker
        {
            get
            {
                return _Worker;
            }
            set
            {
                _Worker = value;
            }
        }
    }

    public delegate void Worker_EventHandler(object sender, WorkerEventArgs e);
}
