using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Kvics.HotMill.BL;
using System.Text.RegularExpressions;
using log4net;
using Kvics.DBAccess;
using System.Threading;

namespace Hotmill.Test
{
    public partial class DataClonerForm : Form
    {
        private static readonly ILog log = Kvics.DBAccess.Log.Instance.GetLogger(typeof(DataClonerForm));

        protected FormDatabaseConfig frmDatabaseConfig = null;
        protected int _NumberOfRecords = 0;
        protected int _MaxRecords = 1000;
        protected RunningStatus _Status = RunningStatus.STOPPED;
        protected DateTime _StartTime = DateTime.Now;
        protected DateTime _StartPauseTime = DateTime.MinValue;
        protected bool _StoppedFlag = true;

        public DataClonerForm()
        {
            InitializeComponent();

            //this.backgroundWorkerInsertData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerInsertData_RunWorkerCompleted);
        }

        private void btnDatabaseConfig_Click(object sender, EventArgs e)
        {
            string currentConnectionString = Kvics.DBAccess.DBAccessor.DefaultConnectionString;

            if (frmDatabaseConfig == null)
            {
                frmDatabaseConfig = new FormDatabaseConfig();
            }

            frmDatabaseConfig.HotMillDatabaseConnectionString = Kvics.DBAccess.DBAccessor.DefaultConnectionString;
            while (frmDatabaseConfig.ShowDialog(this) == DialogResult.OK)
            {
                Kvics.DBAccess.DBAccessor.DefaultConnectionString = frmDatabaseConfig.HotMillDatabaseConnectionString;
                if (CheckData())
                {
                    FormDatabaseConfig.ApplyConnectionString(frmDatabaseConfig.HotMillDatabaseConnectionString);
                    return;
                }
                else
                {
                    ShowError(HotMillErrorType.DATABASE_ERROR);
                }
            }
            Kvics.DBAccess.DBAccessor.DefaultConnectionString = null;
        }

        private bool CheckData()
        {
            try
            {
                TMapping tMapping = new TMapping();
                DataSet ds = tMapping.GetAll();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void ShowError(HotMillErrorType errorType)
        {
            switch (errorType)
            {
                case HotMillErrorType.DATABASE_ERROR:
                    MessageBox.Show("データベースに接続出来ません。若しくはデータベースは異常です。データベース又はデータベース構成を確認して下さい。");
                    break;
                case HotMillErrorType.UNKNOWN_ERROR:
                    MessageBox.Show("データベースよりデータを取得している内にエラーが発生しました。管理者にこのエラーを連絡して下さい。");
                    break;
                default:
                    break;
            }
        }

        private void chkNoLimit_CheckedChanged(object sender, EventArgs e)
        {
            txtNumberOfRecords.Enabled = !chkNoLimit.Checked;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this._Status == RunningStatus.PAUSE)
            {
                _StartTime.AddSeconds(((TimeSpan)DateTime.Now.Subtract(this._StartPauseTime)).TotalSeconds);
                this._Status = RunningStatus.RUNNING;
                this.btnPause.Enabled = true;
                this.btnStart.Enabled = false;
                return;
            }

            if (!this.chkNoLimit.Checked)
            {
                this.txtNumberOfRecords.Text = this.txtNumberOfRecords.Text.Trim();
                string pattern = @"^[0-9]+$";
                if (!Regex.IsMatch(this.txtNumberOfRecords.Text, pattern))
                {
                    MessageBox.Show("Number Is Invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtNumberOfRecords.Focus();
                    this.txtNumberOfRecords.SelectAll();
                    return;
                }
                this._MaxRecords = Int32.Parse(this.txtNumberOfRecords.Text);
            }
            else
            {
                this._MaxRecords = -1;
            }

            this._StartTime = DateTime.Now;
            this._Status = RunningStatus.RUNNING;
            this._StoppedFlag = false;
            this._NumberOfRecords = 0;

            grpOption.Enabled = false;
            btnStart.Enabled = false;
            btnDatabaseConfig.Enabled = false;
            btnStop.Enabled = true;
            btnPause.Enabled = true;

            pgbStatus.Value = 0;
            if (chkNoLimit.Checked)
            {
                pgbStatus.Style = ProgressBarStyle.Marquee;
            }

            Thread demoThread = new Thread(new ThreadStart(this.InserDataThread));
            Console.WriteLine("The thread " + demoThread.ManagedThreadId.ToString() + " was started.");
            demoThread.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            grpOption.Enabled = true;
            btnStart.Enabled = true;
            btnDatabaseConfig.Enabled = true;
            btnStop.Enabled = false;
            btnPause.Enabled = false;

            if (chkNoLimit.Checked)
            {
                pgbStatus.Style = ProgressBarStyle.Blocks;
                pgbStatus.Value = pgbStatus.Maximum;
            }

            this._Status = RunningStatus.STOPPED;
            tmrRun.Stop();
        }

        private void tmrRun_Tick(object sender, EventArgs e)
        {
            if (this._Status == RunningStatus.PAUSE)
            {
                return;
            }
            
            this._NumberOfRecords += 1;
            lblInserted.Text = this._NumberOfRecords.ToString();

            if (this._MaxRecords > 0)
            {
                lblInserted.Text += "/" + this._MaxRecords.ToString();

                double percentCompleted = 0;
                percentCompleted = (this._NumberOfRecords * 1.0) / (this._MaxRecords * 1.0);
                pgbStatus.Value = Convert.ToInt32(percentCompleted * this.pgbStatus.Maximum);
            }

            this.Log("Record " + this._NumberOfRecords.ToString() + ": " + DateTime.Now.ToString("hh:MM:ss,fff"));
            
            // Code here for insert data
            try
            {
                InsertData();
            }
            catch (Exception ex)
            {
                this.Log(ex.Message + System.Environment.NewLine + ex.StackTrace);
                log.Error("Insert data error. ", ex);
            }
            // End code here

            if (this._MaxRecords > 0 && this._NumberOfRecords >= this._MaxRecords)
            {
                btnStop_Click(null, null);
            }
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            this.txtLog.Text = "";
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            this._StartPauseTime = DateTime.Now;
            this._Status = RunningStatus.PAUSE;

            this.btnPause.Enabled = false;
            this.btnStart.Enabled = true;
            this.pgbStatus.Enabled = false;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            btnStop_Click(null, null);

            base.OnClosing(e);
        }

        private void InsertData()
        {
            DBAccessor db = null;
            try
            {
                db = new DBAccessor();

                int randomT900ID = GetRandomIDT900();
                if (randomT900ID > 0)
                {
                    DateTime timeStart = DateTime.Now;
                    object objTemp;

                    T900 t900 = new T900(randomT900ID);
                    objTemp = t900.R081;
                    objTemp = t900.R131;
                    objTemp = t900.R145;
                    objTemp = t900.R169;
                    objTemp = t900.R183;
                    objTemp = t900.R197;
                    objTemp = t900.R213;
                    objTemp = t900.R227;
                    objTemp = t900.R241;
                    objTemp = t900.R255;
                    objTemp = t900.R269;
                    objTemp = t900.R283;
                    objTemp = t900.R297;
                    objTemp = t900.R311;
                    objTemp = t900.R325;
                    objTemp = t900.R339;
                    objTemp = t900.R353;
                    objTemp = t900.R367;
                    objTemp = t900.R379;
                    objTemp = t900.R391;
                    objTemp = t900.R405;
                    objTemp = t900.R419;
                    objTemp = t900.R433;
                    objTemp = t900.R447;
                    objTemp = t900.R501;
                    objTemp = t900.R543;
                    objTemp = t900.R557;
                    objTemp = t900.R585;
                    objTemp = t900.R599;
                    objTemp = t900.R613;
                    objTemp = t900.R627;
                    objTemp = t900.R713;
                    objTemp = t900.R801;
                    objTemp = t900.R815;
                    objTemp = t900.R851;

                    DateTime timeReadT900Finished = DateTime.Now;
                    TimeSpan timeSub_ReadT900 = timeReadT900Finished.Subtract(timeStart);
                    this.Log("Time to read T900: " + this.TimeSpanToString(timeSub_ReadT900));

                    T800 t800 = T800.GetCoilDetailOfYear(t900.R025, t900.R033);
                    objTemp = t800.R083;
                    objTemp = t800.R097;
                    objTemp = t800.R121;
                    objTemp = t800.R135;
                    objTemp = t800.R149;
                    objTemp = t800.R163;
                    objTemp = t800.R165;
                    objTemp = t800.R179;
                    objTemp = t800.R193;
                    objTemp = t800.R207;
                    objTemp = t800.R221;
                    objTemp = t800.R235;
                    objTemp = t800.R249;
                    objTemp = t800.R263;
                    objTemp = t800.R277;
                    objTemp = t800.R291;
                    objTemp = t800.R305;
                    objTemp = t800.R319;
                    objTemp = t800.R331;
                    objTemp = t800.R343;
                    objTemp = t800.R357;
                    objTemp = t800.R371;
                    objTemp = t800.R385;
                    objTemp = t800.R399;
                    objTemp = t800.R413;
                    objTemp = t800.R427;
                    objTemp = t800.R501;
                    objTemp = t800.R521;
                    objTemp = t800.R541;
                    objTemp = t800.R561;
                    objTemp = t800.R575;
                    objTemp = t800.R589;
                    objTemp = t800.R603;
                    objTemp = t800.R617;
                    objTemp = t800.R631;
                    objTemp = t800.R645;
                    objTemp = t800.R659;
                    objTemp = t800.R673;
                    objTemp = t800.R687;
                    objTemp = t800.R701;
                    objTemp = t800.R703;
                    objTemp = t800.R715;
                    objTemp = t800.R729;
                    objTemp = t800.R743;
                    objTemp = t800.R757;
                    objTemp = t800.R771;
                    objTemp = t800.R785;
                    objTemp = t800.R799;
                    objTemp = t800.R813;
                    objTemp = t800.R827;

                    DateTime timeReadT800Finished = DateTime.Now;
                    TimeSpan timeSub_ReadT800 = timeReadT800Finished.Subtract(timeReadT900Finished);
                    this.Log("Time to read T800: " + this.TimeSpanToString(timeSub_ReadT800));


                    T1800 t1800 = T1800.GetCoilDetailOfYear(t900.R025, t900.R033);
                    objTemp = t1800.R0075;
                    objTemp = t1800.R0097;
                    objTemp = t1800.R0125;
                    objTemp = t1800.R0139;
                    objTemp = t1800.R0167;
                    objTemp = t1800.R0195;
                    objTemp = t1800.R0223;
                    objTemp = t1800.R0237;
                    objTemp = t1800.R0251;
                    objTemp = t1800.R0279;
                    //objTemp = t1800.R0291;
                    objTemp = t1800.R0401;
                    objTemp = t1800.R0491;
                    objTemp = t1800.R0581;
                    objTemp = t1800.R0671;
                    objTemp = t1800.R0761;
                    objTemp = t1800.R0851;
                    objTemp = t1800.R0941;
                    objTemp = t1800.R1031;
                    objTemp = t1800.R1121;
                    objTemp = t1800.R1211;
                    objTemp = t1800.R1301;
                    objTemp = t1800.R1391;
                    objTemp = t1800.R1481;
                    objTemp = t1800.R1571;

                    DateTime timeReadT1800Finished = DateTime.Now;
                    TimeSpan timeSub_ReadT1800 = timeReadT1800Finished.Subtract(timeReadT800Finished);
                    this.Log("Time to read T1800: " + this.TimeSpanToString(timeSub_ReadT1800));

                    Gamen gamenT900 = new Gamen(t900.ID, 1);
                    Gamen gamenT800 = new Gamen(t800.ID, 2);
                    Gamen gamenT1800 = new Gamen(t1800.ID, 3);

                    DateTime timeReadGamenFinished = DateTime.Now;
                    TimeSpan timeSub_ReadGamen = timeReadGamenFinished.Subtract(timeReadT1800Finished);
                    this.Log("Time to read Gamen: " + this.TimeSpanToString(timeSub_ReadGamen));

                    t1800.R0025 = t800.R025 = t900.R025 = t900.ID.ToString();
                    t1800.R0033 = t800.R033 = t900.R033 = Convert.ToInt16(DateTime.Now.ToString("yyyy"));
                    t1800.R0035 = t800.R035 = t900.R035 = Convert.ToInt16(DateTime.Now.ToString("MM"));
                    t1800.R0037 = t800.R037 = t900.R037 = Convert.ToInt16(DateTime.Now.ToString("dd"));

                    gamenT900.Values = t900.R025.Trim() + gamenT900.Values.Substring(gamenT900.Values.IndexOf(";"));
                    gamenT800.Values = t800.R025.Trim() + gamenT800.Values.Substring(gamenT800.Values.IndexOf(";"));
                    gamenT1800.Values = t1800.R0025.Trim() + gamenT1800.Values.Substring(gamenT1800.Values.IndexOf(";"));

                    DateTime timeBuildFinished = DateTime.Now;
                    TimeSpan timeSub_Build = timeBuildFinished.Subtract(timeReadGamenFinished);
                    this.Log("Time to build: " + this.TimeSpanToString(timeSub_Build));

                    
                    DateTime timeReadFinished = DateTime.Now;
                    TimeSpan timeSub_Read = timeReadFinished.Subtract(timeStart);
                    this.Log("Time to read: " + this.TimeSpanToString(timeSub_Read));

                    t900.Insert();
                    DateTime timeT900Inserted = DateTime.Now;
                    TimeSpan timeSub_T900 = timeT900Inserted.Subtract(timeReadFinished);
                    this.Log("Time to insert T900: " + this.TimeSpanToString(timeSub_T900));
                    t800.Insert();
                    DateTime timeT800Inserted = DateTime.Now;
                    TimeSpan timeSub_T800 = timeT800Inserted.Subtract(timeT900Inserted);
                    this.Log("Time to insert T800: " + this.TimeSpanToString(timeSub_T800));
                    t1800.Insert();
                    DateTime timeT1800Inserted = DateTime.Now;
                    TimeSpan timeSub_T1800 = timeT1800Inserted.Subtract(timeT800Inserted);
                    this.Log("Time to insert T1800: " + this.TimeSpanToString(timeSub_T1800));

                    gamenT900.MasterID = t900.ID;
                    gamenT900.MasterType = 1;
                    gamenT800.MasterID = t800.ID;
                    gamenT800.MasterType = 2;
                    gamenT1800.MasterID = t1800.ID;
                    gamenT1800.MasterType = 3;

                    gamenT900.Insert();
                    gamenT800.Insert();
                    gamenT1800.Insert();

                    DateTime timeGamenInserted = DateTime.Now;
                    TimeSpan timeSub_Gamen = timeGamenInserted.Subtract(timeT1800Inserted);
                    this.Log("Time to insert Gamen: " + this.TimeSpanToString(timeSub_Gamen));

                    DateTime timeTotal = DateTime.Now;
                    TimeSpan timeSub_Total = timeTotal.Subtract(timeStart);
                    this.Log("Time total: " + this.TimeSpanToString(timeSub_Total));
                }
            }
            catch (Exception ex)
            {
                log.Error("InsertData", ex);
                throw ex;
            }
            finally
            {
                if (db != null)
                    db.Dispose();
            }
        }

        private int GetRandomIDT900()
        {
            DBAccessor db = null;
            try
            {
                db = new DBAccessor();
                Random rand = new Random();
                int timeExpire = 20, times = 0;
                bool existing = false;
                int randID = -1;

                int objMin = (int)db.MinValue(T900.TABLE_NAME, T900.ID__COLUMN_NAME);
                int objMax = (int)db.MaxValue(T900.TABLE_NAME, T900.ID__COLUMN_NAME);
                /*
                if (objMin == null)
                {
                    return -1;
                }
                */
                do
                {
                    randID = rand.Next(objMax - objMin) + objMin;

                    existing = db.FindValue(T900.TABLE_NAME, T900.ID__COLUMN_NAME, randID);

                    times++;
                } while (!existing && times < timeExpire);

                return existing ? randID : -1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db != null)
                    db.Dispose();
            }
        }

        private void Log(string logMessage)
        {
            if (this.txtLog.InvokeRequired)
            {
                LogTextCallback d = new LogTextCallback(Log);
                this.Invoke(d, new object[] { logMessage });
                return;
            }

            if (!this.chkDisableLog.Checked)
            {
                if (this.chkAutoClearLog.Checked)
                {
                    if (txtLog.Text.Split(new string[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Length >= 100)
                    {
                        txtLog.Text = "";
                    }
                }

                txtLog.Text = logMessage + System.Environment.NewLine + txtLog.Text;
            }
            log.Info(logMessage);
        }

        private void InserDataThread()
        {
            //this.backgroundWorkerInsertData.RunWorkerAsync();
            string insertedText = this._NumberOfRecords.ToString();
            if (this._MaxRecords > 0)
            {
                insertedText += "/" + this._MaxRecords.ToString();
            }
            this.SetInsertedText(insertedText);

            while (this._Status != RunningStatus.STOPPED)
            {
                OnInserData();
            }

            this._StoppedFlag = true;
        }

        private void OnInserData()
        {
            if (this._Status == RunningStatus.PAUSE)
            {
                return;
            }

            this._NumberOfRecords += 1;
            // Code here for insert data
            try
            {
                InsertData();

                string insertedText = this._NumberOfRecords.ToString();
                if (this._MaxRecords > 0)
                {
                    insertedText += "/" + this._MaxRecords.ToString();

                    double percentCompleted = 0;
                    percentCompleted = (this._NumberOfRecords * 1.0) / (this._MaxRecords * 1.0);
                    SetStatus(Convert.ToInt32(percentCompleted * this.pgbStatus.Maximum));
                }

                this.SetInsertedText(insertedText);
                this.Log("Record " + this._NumberOfRecords.ToString() + ": " + DateTime.Now.ToString("hh:mm:ss,fff"));
            }
            catch (Exception ex)
            {
                this.Log(ex.Message + System.Environment.NewLine + ex.StackTrace);
            }
            // End code here

            if (this._MaxRecords > 0 && this._NumberOfRecords >= this._MaxRecords)
            {
                StopInsert();
            }
        }

        private void StopInsert()
        {
            if (this.grpOption.InvokeRequired)
            {
                StopInsertCallback d = new StopInsertCallback(StopInsert);
                this.Invoke(d);
                return;
            }

            this._Status = RunningStatus.STOPPED;

            grpOption.Enabled = true;
            btnStart.Enabled = true;
            btnDatabaseConfig.Enabled = true;
            btnStop.Enabled = false;
            btnPause.Enabled = false;

            if (chkNoLimit.Checked)
            {
                pgbStatus.Style = ProgressBarStyle.Blocks;
                pgbStatus.Value = pgbStatus.Maximum;
            }
        }

        private void SetInsertedText(string text)
        {
            if (lblInserted.InvokeRequired)
            {
                SetInsertedTextCallback d = new SetInsertedTextCallback(SetInsertedText);
                this.Invoke(d, new object[] { text });

            }
            else
            {
                lblInserted.Text = text;
                
                TimeSpan time = DateTime.Now.Subtract(this._StartTime);
                lblTimeElapsed.Text = time.TotalSeconds.ToString("###,##0;-###,##0;0") + " s";

                lblTimeElapsed.Text = TimeSpanToString(time);

                if (this._MaxRecords > 0 && this._NumberOfRecords > 0)
                {
                    TimeSpan remainTime = TimeSpan.FromSeconds((this._MaxRecords * time.TotalSeconds) / (this._NumberOfRecords * 1.0) - time.TotalSeconds);
                    lblTimeRemain.Text = TimeSpanToString(remainTime);
                }
                else
                {
                    lblTimeRemain.Text = "(Unknown)";
                }
            }
        }

        private void SetStatus(int value)
        {
            if (this.pgbStatus.InvokeRequired)
            {
                SetStatusCallback d = new SetStatusCallback(SetStatus);
                this.Invoke(d, new object[] { value });

            }
            else
            {
                pgbStatus.Value = value;
            }
        }

        private void backgroundWorkerInsertData_RunWorkerCompleted(
            object sender,
            RunWorkerCompletedEventArgs e)
        {
            this.Log("Stopped.");
        }

        private string TimeSpanToString(TimeSpan time)
        {
            string timeToString = "";
            if (time.TotalDays >= 1)
            {
                timeToString += time.TotalDays.ToString("###,##0;-###,##0;0") + " days ";
            }
            if (time.Hours >= 1)
            {
                timeToString += time.Hours.ToString("00;-00;00") + ":";
            }
            if (time.Minutes >= 1)
            {
                timeToString += time.Minutes.ToString("00;-00;00") + ":";
            }
            timeToString += time.Seconds.ToString("00;-00;00") + "s" + time.Milliseconds.ToString("000;-000;000");
            return timeToString;
        }

        delegate void SetInsertedTextCallback(string text);
        delegate void LogTextCallback(string text);
        delegate void SetStatusCallback(int value);
        delegate void StopInsertCallback();
        //private BackgroundWorker backgroundWorkerInsertData= new System.ComponentModel.BackgroundWorker();
    }

    public enum HotMillErrorType
    {
        DATABASE_ERROR,
        UNKNOWN_ERROR
    }

    public enum RunningStatus
    {
        STOPPED,
        PAUSE,
        RUNNING
    }
}