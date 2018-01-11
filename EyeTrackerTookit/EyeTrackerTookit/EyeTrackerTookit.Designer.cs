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
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.clickTimeGap = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hScrollBar2 = new System.Windows.Forms.HScrollBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.hScrollBar3 = new System.Windows.Forms.HScrollBar();
            this.label2 = new System.Windows.Forms.Label();
            this.hScrollBar4 = new System.Windows.Forms.HScrollBar();
            this.label3 = new System.Windows.Forms.Label();
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
            this.IntroductionText.Text = "說明：\r\n目前的版本只能是用在 1920 x1080的解析度\r\n以下是快捷鍵的說明：\r\nZ =>開啟/關閉眼動操控游標的功能\r\nY =>切換單擊/雙擊的 Mode" +
    "\r\nC =>是否要開始寫檔 ";
            // 
            // outputFileDialog
            // 
            this.outputFileDialog.Filter = "文字檔|*.txt";
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(8, 39);
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(333, 20);
            this.hScrollBar1.TabIndex = 1;
            // 
            // clickTimeGap
            // 
            this.clickTimeGap.AutoSize = true;
            this.clickTimeGap.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.clickTimeGap.Location = new System.Drawing.Point(6, 18);
            this.clickTimeGap.Name = "clickTimeGap";
            this.clickTimeGap.Size = new System.Drawing.Size(121, 20);
            this.clickTimeGap.TabIndex = 2;
            this.clickTimeGap.Text = "多久不動算點擊";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label1.Location = new System.Drawing.Point(6, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "多少算不動";
            // 
            // hScrollBar2
            // 
            this.hScrollBar2.Location = new System.Drawing.Point(3, 128);
            this.hScrollBar2.Name = "hScrollBar2";
            this.hScrollBar2.Size = new System.Drawing.Size(333, 20);
            this.hScrollBar2.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.hScrollBar2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.hScrollBar1);
            this.groupBox1.Controls.Add(this.clickTimeGap);
            this.groupBox1.Location = new System.Drawing.Point(12, 145);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 162);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "點擊相關參數";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.hScrollBar3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.hScrollBar4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 332);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 162);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "不抖動相關參數";
            // 
            // hScrollBar3
            // 
            this.hScrollBar3.Location = new System.Drawing.Point(3, 128);
            this.hScrollBar3.Name = "hScrollBar3";
            this.hScrollBar3.Size = new System.Drawing.Size(333, 20);
            this.hScrollBar3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label2.Location = new System.Drawing.Point(6, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "多少算不動";
            // 
            // hScrollBar4
            // 
            this.hScrollBar4.Location = new System.Drawing.Point(8, 39);
            this.hScrollBar4.Name = "hScrollBar4";
            this.hScrollBar4.Size = new System.Drawing.Size(333, 20);
            this.hScrollBar4.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label3.Location = new System.Drawing.Point(6, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "多久不動算點擊";
            // 
            // EyeTrackerTookit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 506);
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
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Label clickTimeGap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.HScrollBar hScrollBar2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.HScrollBar hScrollBar3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.HScrollBar hScrollBar4;
        private System.Windows.Forms.Label label3;
    }
}

