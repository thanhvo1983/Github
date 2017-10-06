namespace Hotmill.Test
{
    partial class BackupDataForm
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
            this.grpOption = new System.Windows.Forms.GroupBox();
            this.txtCoinNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnDatabaseConfig = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.grpOption.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpOption
            // 
            this.grpOption.Controls.Add(this.txtYear);
            this.grpOption.Controls.Add(this.label2);
            this.grpOption.Controls.Add(this.txtCoinNo);
            this.grpOption.Controls.Add(this.label1);
            this.grpOption.Location = new System.Drawing.Point(12, 12);
            this.grpOption.Name = "grpOption";
            this.grpOption.Size = new System.Drawing.Size(230, 80);
            this.grpOption.TabIndex = 2;
            this.grpOption.TabStop = false;
            this.grpOption.Text = "Option";
            // 
            // txtCoinNo
            // 
            this.txtCoinNo.Location = new System.Drawing.Point(116, 19);
            this.txtCoinNo.Name = "txtCoinNo";
            this.txtCoinNo.Size = new System.Drawing.Size(100, 20);
            this.txtCoinNo.TabIndex = 2;
            this.txtCoinNo.Text = "O04578";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ÉRÉCÉãÇmÇèÅD";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnStart);
            this.groupBox3.Controls.Add(this.btnDatabaseConfig);
            this.groupBox3.Location = new System.Drawing.Point(248, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(234, 80);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStart.Location = new System.Drawing.Point(6, 14);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(110, 60);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Backup";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnDatabaseConfig
            // 
            this.btnDatabaseConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDatabaseConfig.Location = new System.Drawing.Point(118, 14);
            this.btnDatabaseConfig.Name = "btnDatabaseConfig";
            this.btnDatabaseConfig.Size = new System.Drawing.Size(110, 60);
            this.btnDatabaseConfig.TabIndex = 4;
            this.btnDatabaseConfig.Text = "&Database config";
            this.btnDatabaseConfig.UseVisualStyleBackColor = true;
            this.btnDatabaseConfig.Click += new System.EventHandler(this.btnDatabaseConfig_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "DATA files|*.dat";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Year:";
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(116, 45);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(100, 20);
            this.txtYear.TabIndex = 4;
            this.txtYear.Text = "2010";
            // 
            // BackupDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 106);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpOption);
            this.Name = "BackupDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HSS - Backup Data";
            this.grpOption.ResumeLayout(false);
            this.grpOption.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpOption;
        private System.Windows.Forms.TextBox txtCoinNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnDatabaseConfig;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label label2;
    }
}