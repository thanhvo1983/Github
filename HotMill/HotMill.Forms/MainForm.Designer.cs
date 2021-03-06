namespace Kvics.HotMill.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnPressureDifferenceTotal = new System.Windows.Forms.Button();
            this.btnPreSet = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnDatabaseConfig = new System.Windows.Forms.Button();
            this.btnWorker = new System.Windows.Forms.Button();
            this.btnSetParameter = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFinishSupport2 = new System.Windows.Forms.Button();
            this.btnFinishSupport1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tmrRemoveGamenData = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPressureDifferenceTotal
            // 
            this.btnPressureDifferenceTotal.BackColor = System.Drawing.Color.Silver;
            this.btnPressureDifferenceTotal.ForeColor = System.Drawing.Color.Black;
            this.btnPressureDifferenceTotal.Location = new System.Drawing.Point(7, 554);
            this.btnPressureDifferenceTotal.Margin = new System.Windows.Forms.Padding(6, 10, 6, 10);
            this.btnPressureDifferenceTotal.Name = "btnPressureDifferenceTotal";
            this.btnPressureDifferenceTotal.Size = new System.Drawing.Size(555, 234);
            this.btnPressureDifferenceTotal.TabIndex = 2;
            this.btnPressureDifferenceTotal.Text = "圧下位置差テーブル集計";
            this.btnPressureDifferenceTotal.UseVisualStyleBackColor = false;
            this.btnPressureDifferenceTotal.Click += new System.EventHandler(this.pressureDifferenceTotalButton_Click);
            // 
            // btnPreSet
            // 
            this.btnPreSet.BackColor = System.Drawing.Color.Silver;
            this.btnPreSet.ForeColor = System.Drawing.Color.Black;
            this.btnPreSet.Location = new System.Drawing.Point(595, 10);
            this.btnPreSet.Margin = new System.Windows.Forms.Padding(6, 10, 6, 10);
            this.btnPreSet.Name = "btnPreSet";
            this.btnPreSet.Size = new System.Drawing.Size(555, 234);
            this.btnPreSet.TabIndex = 3;
            this.btnPreSet.Text = "簡易支援画面";
            this.btnPreSet.UseVisualStyleBackColor = false;
            this.btnPreSet.Click += new System.EventHandler(this.preSetButton_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Silver;
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(595, 282);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(6, 10, 6, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(555, 234);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "実績データ検索";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // btnDatabaseConfig
            // 
            this.btnDatabaseConfig.BackColor = System.Drawing.Color.Silver;
            this.btnDatabaseConfig.ForeColor = System.Drawing.Color.Blue;
            this.btnDatabaseConfig.Location = new System.Drawing.Point(1183, 282);
            this.btnDatabaseConfig.Margin = new System.Windows.Forms.Padding(6, 10, 6, 10);
            this.btnDatabaseConfig.Name = "btnDatabaseConfig";
            this.btnDatabaseConfig.Size = new System.Drawing.Size(555, 234);
            this.btnDatabaseConfig.TabIndex = 7;
            this.btnDatabaseConfig.Text = "データベース構成";
            this.btnDatabaseConfig.UseVisualStyleBackColor = false;
            this.btnDatabaseConfig.Click += new System.EventHandler(this.btnDatabaseConfig_Click);
            // 
            // btnWorker
            // 
            this.btnWorker.BackColor = System.Drawing.Color.Silver;
            this.btnWorker.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnWorker.ForeColor = System.Drawing.Color.Black;
            this.btnWorker.Location = new System.Drawing.Point(595, 554);
            this.btnWorker.Margin = new System.Windows.Forms.Padding(7, 9, 7, 9);
            this.btnWorker.Name = "btnWorker";
            this.btnWorker.Size = new System.Drawing.Size(555, 234);
            this.btnWorker.TabIndex = 5;
            this.btnWorker.Text = "圧下士登録";
            this.btnWorker.UseVisualStyleBackColor = false;
            this.btnWorker.Click += new System.EventHandler(this.btnWorker_Click);
            // 
            // btnSetParameter
            // 
            this.btnSetParameter.BackColor = System.Drawing.Color.Silver;
            this.btnSetParameter.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSetParameter.ForeColor = System.Drawing.Color.Blue;
            this.btnSetParameter.Location = new System.Drawing.Point(1183, 10);
            this.btnSetParameter.Margin = new System.Windows.Forms.Padding(6, 10, 6, 10);
            this.btnSetParameter.Name = "btnSetParameter";
            this.btnSetParameter.Size = new System.Drawing.Size(555, 234);
            this.btnSetParameter.TabIndex = 6;
            this.btnSetParameter.Text = "パラメーター設定";
            this.btnSetParameter.UseVisualStyleBackColor = false;
            this.btnSetParameter.Click += new System.EventHandler(this.btnSetParameter_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Maroon;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(1183, 554);
            this.btnExit.Margin = new System.Windows.Forms.Padding(6, 10, 6, 10);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(555, 234);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "システム終了";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnFinishSupport2);
            this.panel1.Controls.Add(this.btnFinishSupport1);
            this.panel1.Controls.Add(this.btnPreSet);
            this.panel1.Controls.Add(this.btnWorker);
            this.panel1.Controls.Add(this.btnDatabaseConfig);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.btnSetParameter);
            this.panel1.Controls.Add(this.btnPressureDifferenceTotal);
            this.panel1.Location = new System.Drawing.Point(82, 215);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1750, 799);
            this.panel1.TabIndex = 6;
            // 
            // btnFinishSupport2
            // 
            this.btnFinishSupport2.BackColor = System.Drawing.Color.Silver;
            this.btnFinishSupport2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFinishSupport2.ForeColor = System.Drawing.Color.Black;
            this.btnFinishSupport2.Location = new System.Drawing.Point(7, 282);
            this.btnFinishSupport2.Margin = new System.Windows.Forms.Padding(7, 9, 7, 9);
            this.btnFinishSupport2.Name = "btnFinishSupport2";
            this.btnFinishSupport2.Size = new System.Drawing.Size(555, 234);
            this.btnFinishSupport2.TabIndex = 1;
            this.btnFinishSupport2.Text = "仕上支援画面(2)";
            this.btnFinishSupport2.UseVisualStyleBackColor = false;
            this.btnFinishSupport2.Click += new System.EventHandler(this.btnFinishSupport2_Click);
            // 
            // btnFinishSupport1
            // 
            this.btnFinishSupport1.BackColor = System.Drawing.Color.Silver;
            this.btnFinishSupport1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnFinishSupport1.ForeColor = System.Drawing.Color.Black;
            this.btnFinishSupport1.Location = new System.Drawing.Point(7, 10);
            this.btnFinishSupport1.Margin = new System.Windows.Forms.Padding(7, 9, 7, 9);
            this.btnFinishSupport1.Name = "btnFinishSupport1";
            this.btnFinishSupport1.Size = new System.Drawing.Size(555, 234);
            this.btnFinishSupport1.TabIndex = 0;
            this.btnFinishSupport1.Text = "仕上支援画面(1)";
            this.btnFinishSupport1.UseVisualStyleBackColor = false;
            this.btnFinishSupport1.Click += new System.EventHandler(this.btnFinishSupport1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(710, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(494, 48);
            this.label1.TabIndex = 8;
            this.label1.Text = "熱延仕上支援システム";
            // 
            // tmrRemoveGamenData
            // 
            this.tmrRemoveGamenData.Enabled = true;
            this.tmrRemoveGamenData.Interval = 600000;
            this.tmrRemoveGamenData.Tick += new System.EventHandler(this.tmrRemoveGamenData_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1914, 1134);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("MS PGothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 10, 6, 10);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "熱延仕上支援システム";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPreSet;
        private System.Windows.Forms.Button btnPressureDifferenceTotal;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnWorker;
        private System.Windows.Forms.Button btnSetParameter;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnDatabaseConfig;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFinishSupport1;
        private System.Windows.Forms.Button btnFinishSupport2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer tmrRemoveGamenData;
    }
}
