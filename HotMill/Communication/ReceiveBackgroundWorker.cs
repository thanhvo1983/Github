using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Threading;
using System.Diagnostics;
using System.Collections;

using log4net;
using log4net.Config;

namespace Kvics.Communication
{
    /// <summary>
    /// Data packet class for PROCON packet
    /// </summary>
    public class DataPacket
    {
        /// <summary>
        /// Buffer
        /// </summary>
        private Byte[] _Buff = null;

        /// <summary>
        /// Is cancelled
        /// </summary>
        private Boolean _Cancelled = false;

        /// <summary>
        /// Is cancelled
        /// </summary>
        public Boolean Cancelled
        {
            get
            {
                return this._Cancelled;
            }
            set
            {
                this._Cancelled = value;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="buff">Buffer</param>
        public DataPacket(Byte[] buff)
        {
            this._Buff = buff;
            this._Cancelled = false;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cancelled">Cancelled</param>
        public DataPacket(Boolean cancelled)
        {
            this._Cancelled = cancelled;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="buff"></param>
        /// <param name="cancelled"></param>
        public DataPacket(Byte[] buff, Boolean cancelled)
        {
            this._Buff = buff;
            this._Cancelled = cancelled;
        }

        /// <summary>
        /// Get buffer of data packet
        /// </summary>
        public Byte[] Buff
        {
            get
            {
                return this._Buff;
            }
        }

        /// <summary>
        /// Get buffer of data packet
        /// </summary>
        /// <returns></returns>
        public Byte[] GetBuffer()
        {
            return this._Buff;
        }
    }

    /// <summary>
    /// Event handler for packet arrived event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void PacketArrivedEventHandler(Object sender, PacketArrivedEventArgs e);

    /// <summary>
    /// Packet arrived event
    /// </summary>
    public class PacketArrivedEventArgs : EventArgs
    {
        /// <summary>
        /// Data packet
        /// </summary>
        private DataPacket _Data;

        /// <summary>
        /// Line code of data packet
        /// </summary>
        private Object _Line;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pkt">Data packet</param>
        /// <param name="line">Line</param>
        public PacketArrivedEventArgs(DataPacket pkt, Object line)
        {
            if (pkt == null || line == null)
            {
                throw new ArgumentNullException();
            }

            this._Data = pkt;
            this._Line = line;
        }

        /// <summary>
        /// Get data packet
        /// </summary>
        public DataPacket Data
        {
            get
            {
                return this._Data;
            }
        }

        /// <summary>
        /// Get line
        /// </summary>
        public Object Line
        {
            get
            {
                return this._Line;
            }
        }
    }

    /// <summary>
    /// Background worker status changed type
    /// </summary>
    public enum StatusChangedType
    {
        Starting,
        Started,
        Continued,
        StopRequesting,
        StopRequested,
        Stopped
    }

    /// <summary>
    /// Event handler for receiver background worker status changed event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void StatusChangedEventHandler(Object sender, StatusChangedEventArgs e);

    /// <summary>
    /// Class for status changed event
    /// </summary>
    public class StatusChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Changed type
        /// </summary>
        private StatusChangedType _Type;

        /// <summary>
        /// Line
        /// </summary>
        private Object _Line;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Changed type</param>
        /// <param name="line">Line</param>
        public StatusChangedEventArgs(StatusChangedType type, Object line)
        {
            if (line == null)
            {
                throw new ArgumentNullException();
            }
            this._Line = line;
            this._Type = type;
        }

        /// <summary>
        /// Get Line
        /// </summary>
        public Object Line
        {
            get
            {
                return this._Line;
            }
        }

        /// <summary>
        /// Get type
        /// </summary>
        public StatusChangedType Type
        {
            get
            {
                return this._Type;
            }
        }
    }

    /// <summary>
    /// Event handler for receiver background worker status changing event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void StatusChangingEventHandler(Object sender, StatusChangingEventArgs e);

    /// <summary>
    /// Class for status changing event
    /// </summary>
    public class StatusChangingEventArgs : StatusChangedEventArgs
    {
        /// <summary>
        /// Cancel event
        /// </summary>
        private Boolean _Cancel;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type"></param>
        /// <param name="line"></param>
        public StatusChangingEventArgs(StatusChangedType type, Object line)
            : base(type, line)
        {

        }

        /// <summary>
        /// Get or Set cancel event
        /// </summary>
        public Boolean Cancel
        {
            get
            {
                return this._Cancel;
            }
            set
            {
                this._Cancel = value;
            }
        }
    }

    /// <summary>
    /// Abstract class receive background worker
    /// </summary>
    public abstract class ReceiveBackgroundWorker
    {
        private readonly log4net.ILog LOGGER =
            Log.Instance.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Using .NET 2.0 class BackgroundWorker
        /// </summary>
        protected System.ComponentModel.BackgroundWorker _BackgroundWorker = null;

        /// <summary>
        /// Line
        /// </summary>
        protected Object _Line = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="line"></param>
        protected ReceiveBackgroundWorker(Object line)
        {
            // Remember to start communication driver DriverAdapter.StartDriver() 
            // before using background worker or background worker
            // DriverAdapter.StartDriver();
            if (line == null)
            {
                throw new ArgumentNullException();
            }

            this._Line = line;
            InitializeBackgoundWorker();
        }

        /// <summary>
        /// Initialize background worker
        /// </summary>
        private void InitializeBackgoundWorker()
        {
            this._BackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this._BackgroundWorker.WorkerReportsProgress = true;
            this._BackgroundWorker.WorkerSupportsCancellation = true;

            this._BackgroundWorker.DoWork += new DoWorkEventHandler(DoWork);
            this._BackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(RunWorkerCompleted);
            this._BackgroundWorker.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);
        }

        /// <summary>
        /// Start worker
        /// </summary>
        public void StartWorker()
        {
            try
            {
                // Is not running
                if (!this._BackgroundWorker.IsBusy)
                {
                    // Starting event
                    if (!RaiseStatusChangeEvent(true, StatusChangedType.Starting))
                    {
                        return;
                    }
                    this._BackgroundWorker.RunWorkerAsync();
                    // Started event
                    RaiseStatusChangeEvent(false, StatusChangedType.Started);
                }
            }
            catch (InvalidOperationException)
            {

            }
        }

        /// <summary>
        /// Continue receive
        /// </summary>
        protected void ContinueWork()
        {
            this._BackgroundWorker.RunWorkerAsync();
            // RaiseStatusChangeEvent(false, StatusChangedType.Continued);
        }

        /// <summary>
        /// Set CancellationPending is true
        /// </summary>
        public void CancelWorker()
        {
            if (!this._BackgroundWorker.IsBusy || this._BackgroundWorker.CancellationPending)
            {
                return;
            }

            if (!RaiseStatusChangeEvent(true, StatusChangedType.StopRequesting))
            {
                return;
            }
            // Using CancelAsync() to set CancellationPending is true
            // If process has been reached at ReceiveProcess, don't receive packet 
            // and stop at RunWorkerCompleted because receive null packet
            // If process still in ReceivePacket or reached at RunWorkerCompleted 
            // so packet received still fire an event to UI, no packet lost

            // !!! Important !!! Do not use "forever-blocking" ReceivePacket
            // If ReceivePacket is "forever-blocking" func worker blocking still
            // receive a packet (like GetData method)
            this._BackgroundWorker.CancelAsync();

            RaiseStatusChangeEvent(false, StatusChangedType.StopRequested);
        }

        /// <summary>
        /// DoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoWork(Object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            e.Result = ReceiveProcess(worker, e);
        }

        /// <summary>
        /// Receive process
        /// </summary>
        /// <param name="worker"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        DataPacket ReceiveProcess(BackgroundWorker worker, DoWorkEventArgs e)
        {
            DataPacket pkt = null;
            // Abort the operation if the user has canceled.
            // Note that a call to CancelAsync may have set 
            // CancellationPending to true just after the
            // last invocation of this method exits, so this 
            // code will not have the opportunity to set the 
            // DoWorkEventArgs.Cancel flag to true. This means
            // that RunWorkerCompletedEventArgs.Cancelled will
            // not be set to true in your RunWorkerCompleted
            // event handler. This is a race condition.
            if (worker.CancellationPending)
            {
                e.Cancel = true;
            }
            else
            {
                // Code run here can't cancel, blocking here until ReceivePacket return
                // If StopRequested worker will be cancelled at RunWorkerCompleted
                pkt = ReceivePacket();
                // Report change
                // BackgroundWorker.ReportProgress(Int32)          Raises the ProgressChanged event.  
                // BackgroundWorker.ReportProgress(Int32, Object)  Raises the ProgressChanged event.  
                // worker.ReportProgress(...)
            }

            // CancelWorker() is called after process reach ReceivePacket
            // Still fire event to prevent packet loss
            if (pkt == null)
            {
                pkt = new DataPacket(worker.CancellationPending);
            }
            else
            {
                pkt.Cancelled = worker.CancellationPending;
            }

            return pkt;
        }

        /// <summary>
        /// Process data return from ReceiveProcess
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunWorkerCompleted(Object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {

            }
            else
            {
                if (e.Cancelled)
                {                   
                    // CancelWorker() has been called before ReceivePacket is called
                    // No packet receive simple stop
                    RaiseStatusChangeEvent(false, StatusChangedType.Stopped);
                }
                else
                {
                    // Always receive not-null pkt
                    DataPacket pkt = (DataPacket)e.Result;

                    if (pkt.Buff != null)
                    {
                        // Fire event to prevent packet loss
                        RaisePacketArrivedEvent(pkt);
                    }

                    if (pkt.Cancelled)
                    {
                        // CancelWorker() has been called after ReceivePacket is called
                        RaiseStatusChangeEvent(false, StatusChangedType.Stopped);
                    }
                    else
                    {
                        // If code run here before CancelWorker is called, RunWorkerAsync() still run
                        ContinueWork();
                    }
                }
            }
        }

        /// <summary>
        /// Process changed, do nothing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressChanged(Object sender, ProgressChangedEventArgs e)
        {
            // Do something report change
        }

        /// <summary>
        /// Packet arrived event handler
        /// </summary>
        public event PacketArrivedEventHandler PacketArrived;

        /// <summary>
        /// Raise packet arrived event
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected Boolean RaisePacketArrivedEvent(DataPacket data)
        {
            LOGGER.Info("HSG worker #" + this._Line.ToString() + " - Data packet arrived, length: " + data.Buff.Length + " bytes");

            // If there are no handlers.
            if (PacketArrived != null)
            {
                PacketArrived(this, new PacketArrivedEventArgs(data, this._Line));
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        public event StatusChangingEventHandler StatusChangingHandler;

        /// <summary>
        /// 
        /// </summary>
        public event StatusChangedEventHandler StatusChangedHandler;

        /// <summary>
        /// Raise status change event
        /// </summary>
        /// <param name="changing"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        protected Boolean RaiseStatusChangeEvent(Boolean changing, StatusChangedType type)
        {
            LOGGER.Info("HSG worker #" + this._Line.ToString() + " - Status change: " + type.ToString());
            if (changing)
            {
                // If there are no handlers.
                if (StatusChangingHandler == null)
                {
                    return true;
                }

                StatusChangingEventArgs e = new StatusChangingEventArgs(type, this._Line);
                OnStatusChanging(e);

                return !e.Cancel;
            }

            // If there are no handlers.
            if (StatusChangedHandler != null)
            {
                OnStatusChanged(new StatusChangingEventArgs(type, this._Line));
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnStatusChanging(StatusChangingEventArgs e)
        {
            if (StatusChangingHandler == null)
            {
                return;
            }

            foreach (StatusChangingEventHandler handler in StatusChangingHandler.GetInvocationList())
            {
                handler(this, e);
                // If a particular handler cancels the event, stop
                if (e.Cancel)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnStatusChanged(StatusChangedEventArgs e)
        {
            if (StatusChangedHandler != null)
            {
                StatusChangedHandler(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected abstract DataPacket ReceivePacket();
    }

    #region Multiton Pattern
    /// <summary>
    /// Multiton pattern HGSReceiverWorker
    /// </summary>
    public sealed class HGSReceiverWorker : ReceiveBackgroundWorker
    {
        // private static Hashtable instances = new Hashtable(MAX_INSTANCES);

        /// <summary>
        /// 
        /// </summary>
        private static Hashtable _Instances = new Hashtable();

        /// <summary>
        /// 
        /// </summary>
        private static readonly Object _Sync = new Object();

        /// <summary>
        /// 
        /// </summary>
        private const Int32 _Timeout = 10;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        private HGSReceiverWorker(Object line) : base(line)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static HGSReceiverWorker GetInstance(Object line)
        {
            lock (_Sync)
            {
                // Our "per key" singleton
                HGSReceiverWorker instance;

                if ((instance = (HGSReceiverWorker)_Instances[line]) == null)
                {
                    // Lazily create instance
                    instance = new HGSReceiverWorker(line);
                    // Add it to map   
                    _Instances.Add(line, instance);
                }
                return instance;
            }
        }

        /// <summary>
        /// Implementation of ReceiveBackgroundWorker::ReceivePacket
        /// </summary>
        /// <returns></returns>
        protected override DataPacket ReceivePacket()
        {
            DataPacket pkt = null;
            // Recommend not use "forever-blocking" receive function here
            // When communication driver is not running cause ReceivePacket is rapidly called. 
            // When communication driver is running, ReceivePacket is called and 
            // no packet arrive then worker still running "forever" even do CancelWorker()
            // Byte[] buff = DriverAdapter.GetData((Int32)this._DataSource);
            Byte[] buff = DriverAdapter.ReceiveData((Int32)this._Line, _Timeout);
            if (buff.Length > 0)
            {
                pkt = new DataPacket(buff);
            }

            return pkt;
        }
    }
    #endregion
}