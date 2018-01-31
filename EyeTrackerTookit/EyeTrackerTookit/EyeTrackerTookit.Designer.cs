namespace EyeTrackerTookit
{
    partial class EyeTrackerTookit
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.GetGazePointTimer = new System.Windows.Forms.Timer(this.components);
            this.IntroductionText = new System.Windows.Forms.Label();
            this.outputFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.clickTimeGap = new System.Windows.Forms.HScrollBar();
            this.clickTimeGapText = new System.Windows.Forms.Label();
            this.clickDistanceGapText = new System.Windows.Forms.Label();
            this.clickDistanceGap = new System.Windows.Forms.HScrollBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SmoothingFactorB = new System.Windows.Forms.HScrollBar();
            this.SmoothingFactorBText = new System.Windows.Forms.Label();
            this.SmoothingFactorA = new System.Windows.Forms.HScrollBar();
            this.SmoothingFactorAText = new System.Windows.Forms.Label();
            this.ZFunctionText = new System.Windows.Forms.Label();
            this.XFunctionText = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // GetGazePointTimer
            // 
            this.GetGazePointTimer.Enabled = true;
            this.GetGazePointTimer.Interval = 10;
            this.GetGazePointTimer.Tick += new System.EventHandler(this.GetGazePointTimer_Tick);
            // 
            // IntroductionText
            // 
            this.IntroductionText.AutoSize = true;
            this.IntroductionText.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.IntroductionText.Location = new System.Drawing.Point(12, 9);
            this.IntroductionText.Name = "IntroductionText";
            this.IntroductionText.Size = new System.Drawing.Size(321, 120);
            this.IntroductionText.TabIndex = 0;
            this.IntroductionText.Text = "說明：\r\n目前的版本只能是用在 1920 x1080的解析度\r\n以下是快捷鍵的說明：\r\nZ =>開啟/關閉眼動操控游標的功能\r\nX =>切換單擊/雙擊的 Mode" +
    "\r\nC =>是否要開始寫檔 ";
            // 
            // outputFileDialog
            // 
            this.outputFileDialog.Filter = "Excel 檔|*.csv";
            // 
            // clickTimeGap
            // 
            this.clickTimeGap.Location = new System.Drawing.Point(8, 39);
            this.clickTimeGap.Maximum = 109;
            this.clickTimeGap.Minimum = 1;
            this.clickTimeGap.Name = "clickTimeGap";
            this.clickTimeGap.Size = new System.Drawing.Size(333, 20);
            this.clickTimeGap.TabIndex = 1;
            this.clickTimeGap.Value = 1;
            this.clickTimeGap.ValueChanged += new System.EventHandler(this.clickTimeGap_ValueChanged);
            // 
            // clickTimeGapText
            // 
            this.clickTimeGapText.AutoSize = true;
            this.clickTimeGapText.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.clickTimeGapText.Location = new System.Drawing.Point(6, 18);
            this.clickTimeGapText.Name = "clickTimeGapText";
            this.clickTimeGapText.Size = new System.Drawing.Size(173, 20);
            this.clickTimeGapText.TabIndex = 2;
            this.clickTimeGapText.Text = "多久不動算點擊 (0.1秒)";
            // 
            // clickDistanceGapText
            // 
            this.clickDistanceGapText.AutoSize = true;
            this.clickDistanceGapText.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.clickDistanceGapText.Location = new System.Drawing.Point(6, 98);
            this.clickDistanceGapText.Name = "clickDistanceGapText";
            this.clickDistanceGapText.Size = new System.Drawing.Size(153, 20);
            this.clickDistanceGapText.TabIndex = 4;
            this.clickDistanceGapText.Text = "多少算不動 (16像素)";
            // 
            // clickDistanceGap
            // 
            this.clickDistanceGap.Location = new System.Drawing.Point(3, 128);
            this.clickDistanceGap.Maximum = 137;
            this.clickDistanceGap.Minimum = 16;
            this.clickDistanceGap.Name = "clickDistanceGap";
            this.clickDistanceGap.Size = new System.Drawing.Size(333, 20);
            this.clickDistanceGap.TabIndex = 3;
            this.clickDistanceGap.Value = 16;
            this.clickDistanceGap.ValueChanged += new System.EventHandler(this.clickDistanceGap_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clickDistanceGap);
            this.groupBox1.Controls.Add(this.clickDistanceGapText);
            this.groupBox1.Controls.Add(this.clickTimeGap);
            this.groupBox1.Controls.Add(this.clickTimeGapText);
            this.groupBox1.Location = new System.Drawing.Point(12, 145);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 162);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "點擊相關參數";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SmoothingFactorB);
            this.groupBox2.Controls.Add(this.SmoothingFactorBText);
            this.groupBox2.Controls.Add(this.SmoothingFactorA);
            this.groupBox2.Controls.Add(this.SmoothingFactorAText);
            this.groupBox2.Location = new System.Drawing.Point(12, 332);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 162);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "不抖動相關參數 (Double Exponential Filter)";
            // 
            // SmoothingFactorB
            // 
            this.SmoothingFactorB.Location = new System.Drawing.Point(3, 128);
            this.SmoothingFactorB.Maximum = 19;
            this.SmoothingFactorB.Name = "SmoothingFactorB";
            this.SmoothingFactorB.Size = new System.Drawing.Size(333, 20);
            this.SmoothingFactorB.TabIndex = 3;
            this.SmoothingFactorB.ValueChanged += new System.EventHandler(this.SmoothingFactorB_ValueChanged);
            // 
            // SmoothingFactorBText
            // 
            this.SmoothingFactorBText.AutoSize = true;
            this.SmoothingFactorBText.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.SmoothingFactorBText.Location = new System.Drawing.Point(6, 98);
            this.SmoothingFactorBText.Name = "SmoothingFactorBText";
            this.SmoothingFactorBText.Size = new System.Drawing.Size(192, 20);
            this.SmoothingFactorBText.TabIndex = 4;
            this.SmoothingFactorBText.Text = "SmoothingFactorB = 0.9\r\n";
            // 
            // SmoothingFactorA
            // 
            this.SmoothingFactorA.Location = new System.Drawing.Point(8, 39);
            this.SmoothingFactorA.Maximum = 19;
            this.SmoothingFactorA.Name = "SmoothingFactorA";
            this.SmoothingFactorA.Size = new System.Drawing.Size(333, 20);
            this.SmoothingFactorA.TabIndex = 1;
            this.SmoothingFactorA.ValueChanged += new System.EventHandler(this.SmoothingFactorA_ValueChanged);
            // 
            // SmoothingFactorAText
            // 
            this.SmoothingFactorAText.AutoSize = true;
            this.SmoothingFactorAText.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.SmoothingFactorAText.Location = new System.Drawing.Point(6, 18);
            this.SmoothingFactorAText.Name = "SmoothingFactorAText";
            this.SmoothingFactorAText.Size = new System.Drawing.Size(193, 20);
            this.SmoothingFactorAText.TabIndex = 2;
            this.SmoothingFactorAText.Text = "SmoothingFactorA = 0.1\r\n";
            // 
            // ZFunctionText
            // 
            this.ZFunctionText.AutoSize = true;
            this.ZFunctionText.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.ZFunctionText.Location = new System.Drawing.Point(305, 68);
            this.ZFunctionText.Name = "ZFunctionText";
            this.ZFunctionText.Size = new System.Drawing.Size(51, 20);
            this.ZFunctionText.TabIndex = 7;
            this.ZFunctionText.Text = "(關閉)";
            // 
            // XFunctionText
            // 
            this.XFunctionText.AutoSize = true;
            this.XFunctionText.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.XFunctionText.Location = new System.Drawing.Point(304, 90);
            this.XFunctionText.Name = "XFunctionText";
            this.XFunctionText.Size = new System.Drawing.Size(51, 20);
            this.XFunctionText.TabIndex = 9;
            this.XFunctionText.Text = "(單擊)";
            // 
            // EyeTrackerTookit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 506);
            this.Controls.Add(this.XFunctionText);
            this.Controls.Add(this.ZFunctionText);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.IntroductionText);
            this.Name = "EyeTrackerTookit";
            this.Text = "眼動儀小工具(By 小強)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EyeTrackerTookit_FormClosed);
            this.Load += new System.EventHandler(this.EyeTrackerTookit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer GetGazePointTimer;
        private System.Windows.Forms.Label IntroductionText;
        private System.Windows.Forms.SaveFileDialog outputFileDialog;
        private System.Windows.Forms.HScrollBar clickTimeGap;
        private System.Windows.Forms.Label clickTimeGapText;
        private System.Windows.Forms.Label clickDistanceGapText;
        private System.Windows.Forms.HScrollBar clickDistanceGap;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.HScrollBar SmoothingFactorB;
        private System.Windows.Forms.Label SmoothingFactorBText;
        private System.Windows.Forms.HScrollBar SmoothingFactorA;
        private System.Windows.Forms.Label SmoothingFactorAText;
        private System.Windows.Forms.Label ZFunctionText;
        private System.Windows.Forms.Label XFunctionText;
    }
}

