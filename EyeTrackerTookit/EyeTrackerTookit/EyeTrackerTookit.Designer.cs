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
            // EyeTrackerTookit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 261);
            this.Controls.Add(this.IntroductionText);
            this.Name = "EyeTrackerTookit";
            this.Text = "眼動儀小工具(By 小強)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EyeTrackerTookit_FormClosed);
            this.Load += new System.EventHandler(this.EyeTrackerTookit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer GetGazePointTimer;
        private System.Windows.Forms.Label IntroductionText;
        private System.Windows.Forms.SaveFileDialog outputFileDialog;
    }
}

