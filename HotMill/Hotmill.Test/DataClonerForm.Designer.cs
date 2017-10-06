namespace Hotmill.Test
{
    partial class DataClonerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnDatabaseConfig = new System.Windows.Forms.Button();
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.chkNoLimit = new System.Windows.Forms.CheckBox();
            this.txtNumberOfRecords = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAutoClearLog = new System.Windows.Forms.CheckBox();
            this.chkDisableLog = new System.Windows.Forms.CheckBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.pgbStatus = new System.Windows.Forms.ProgressBar();
            this.lblInserted = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.tmrRun = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lblTimeElapsed = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTimeRemain = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grpOption.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDatabaseConfig
            // 
            this.btnDatabaseConfig.Location = new System.Drawing.Point(432, 14);
            this.btnDatabaseConfig.Name = "btnDatabaseConfig";
            this.btnDatabaseConfig.Size = new System.Drawing.Size(93, 43);
            this.btnDatabaseConfig.TabIndex = 4;
            this.btnDatabaseConfig.Text = "&Database config";
            this.btnDatabaseConfig.UseVisualStyleBackColor = true;
            this.btnDatabaseConfig.Click += new System.EventHandler(this.btnDatabaseConfig_Click);
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.chkNoLimit);
            this.grpOption.Controls.Add(this.txtNumberOfRecords);
            this.grpOption.Controls.Add(this.label1);
            this.grpOption.Location = new System.Drawing.Point(13, 13);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(230, 70);
            this.grpOption.TabIndex = 1;
            this.grpOption.TabStop = false;
            this.grpOption.Text = "Option";
            // 
            // chkNoLimit
            // 
            this.chkNoLimit.AutoSize = true;
            this.chkNoLimit.Location = new System.Drawing.Point(115, 45);
            this.chkNoLimit.Name = "chkNoLimit";
            this.chkNoLimit.Size = new System.Drawing.Size(60, 17);
            this.chkNoLimit.TabIndex = 3;
            this.chkNoLimit.Text = "No &limit";
            this.chkNoLimit.UseVisualStyleBackColor = true;
            this.chkNoLimit.CheckedChanged += new System.EventHandler(this.chkNoLimit_CheckedChanged);
            // 
            // txtNumberOfRecords
            // 
            this.txtNumberOfRecords.Location = new System.Drawing.Point(115, 19);
            this.txtNumberOfRecords.Name = "txtNumberOfRecords";
            this.txtNumberOfRecords.Size = new System.Drawing.Size(100, 20);
            this.txtNumberOfRecords.TabIndex = 2;
            this.txtNumberOfRecords.Text = "1000";
            this.txtNumberOfRecords.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "&Number of Records:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblTimeRemain);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblTimeElapsed);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.chkAutoClearLog);
            this.groupBox2.Controls.Add(this.chkDisableLog);
            this.groupBox2.Controls.Add(this.txtLog);
            this.groupBox2.Controls.Add(this.pgbStatus);
            this.groupBox2.Controls.Add(this.lblInserted);
            this.groupBox2.Location = new System.Drawing.Point(13, 89);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(767, 465);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log";
            // 
            // chkAutoClearLog
            // 
            this.chkAutoClearLog.AutoSize = true;
            this.chkAutoClearLog.Location = new System.Drawing.Point(90, 48);
            this.chkAutoClearLog.Name = "chkAutoClearLog";
            this.chkAutoClearLog.Size = new System.Drawing.Size(193, 17);
            this.chkAutoClearLog.TabIndex = 5;
            this.chkAutoClearLog.Text = "&Auto clear log when over 100 rows.";
            this.chkAutoClearLog.UseVisualStyleBackColor = true;
            // 
            // chkDisableLog
            // 
            this.chkDisableLog.AutoSize = true;
            this.chkDisableLog.Location = new System.Drawing.Point(6, 48);
            this.chkDisableLog.Name = "chkDisableLog";
            this.chkDisableLog.Size = new System.Drawing.Size(78, 17);
            this.chkDisableLog.TabIndex = 4;
            this.chkDisableLog.Text = "Disa&ble log";
            this.chkDisableLog.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(6, 71);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(755, 388);
            this.txtLog.TabIndex = 3;
            // 
            // pgbStatus
            // 
            this.pgbStatus.Enabled = false;
            this.pgbStatus.Location = new System.Drawing.Point(6, 19);
            this.pgbStatus.Name = "pgbStatus";
            this.pgbStatus.Size = new System.Drawing.Size(755, 23);
            this.pgbStatus.Step = 1;
            this.pgbStatus.TabIndex = 2;
            // 
            // lblInserted
            // 
            this.lblInserted.Location = new System.Drawing.Point(706, 45);
            this.lblInserted.Name = "lblInserted";
            this.lblInserted.Size = new System.Drawing.Size(55, 23);
            this.lblInserted.TabIndex = 1;
            this.lblInserted.Text = "0";
            this.lblInserted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 14);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(93, 43);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(204, 14);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(93, 43);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "St&op";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnPause);
            this.groupBox3.Controls.Add(this.btnClearLog);
            this.groupBox3.Controls.Add(this.btnStart);
            this.groupBox3.Controls.Add(this.btnStop);
            this.groupBox3.Controls.Add(this.btnDatabaseConfig);
            this.groupBox3.Location = new System.Drawing.Point(249, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(531, 70);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(105, 14);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(93, 43);
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "&Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(303, 14);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(93, 43);
            this.btnClearLog.TabIndex = 3;
            this.btnClearLog.Text = "&Clear log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // tmrRun
            // 
            this.tmrRun.Interval = 500;
            this.tmrRun.Tick += new System.EventHandler(this.tmrRun_Tick);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(289, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Time elapsed:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTimeElapsed
            // 
            this.lblTimeElapsed.Location = new System.Drawing.Point(371, 45);
            this.lblTimeElapsed.Name = "lblTimeElapsed";
            this.lblTimeElapsed.Size = new System.Drawing.Size(94, 23);
            this.lblTimeElapsed.TabIndex = 7;
            this.lblTimeElapsed.Text = "(Unknown)";
            this.lblTimeElapsed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(471, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Time remain:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTimeRemain
            // 
            this.lblTimeRemain.Location = new System.Drawing.Point(548, 45);
            this.lblTimeRemain.Name = "lblTimeRemain";
            this.lblTimeRemain.Size = new System.Drawing.Size(94, 23);
            this.lblTimeRemain.TabIndex = 9;
            this.lblTimeRemain.Text = "(Unknown)";
            this.lblTimeRemain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(648, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 23);
            this.label3.TabIndex = 10;
            this.label3.Text = "Records:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DataClonerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpOption);
            this.MaximizeBox = false;
            this.Name = "DataClonerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HotMill - Clone data";
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDatabaseConfig;
        private System.Windows.Forms.GroupBox grpOption;
        private System.Windows.Forms.TextBox txtNumberOfRecords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkNoLimit;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ProgressBar pgbStatus;
        private System.Windows.Forms.Label lblInserted;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Timer tmrRun;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.CheckBox chkDisableLog;
        private System.Windows.Forms.CheckBox chkAutoClearLog;
        private System.Windows.Forms.Label lblTimeRemain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTimeElapsed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}