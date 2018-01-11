using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using System.Runtime.InteropServices;
using Tobii.Interaction;

namespace EyeTrackerTookit
{
    public partial class EyeTrackerTookit : Form
    {
        // 眼動相關
        private Host host;
        private GazePointDataStream stream;

        // 傳出的參數
        private double eyeX, eyeY, timeStamp;
        private double lastEyeX, lastEyeY, lastTimeStamp;

        // 備份的游標
        // 全部游標的 Index
        // 原始連結：https://msdn.microsoft.com/en-us/library/windows/desktop/ms648391(v=vs.85).aspx
        private int[] CursorIndex = { 32650, 32512, 32151, 32649, 32651, 32513, 32641, 32648, 32640, 32646, 32643, 32642, 32644, 32516, 32514};
        private IntPtr[] orgCursor;
        private IntPtr targetCursor;

        // 設定變數
        private static SaveFileDialog dialog;
        private static bool IsEnableControl = false;        // 是否要被眼動儀控制
        private static bool IsSingleClickModel = true;      // 是否是單擊模式 ((另外一個是雙擊模式
        private static bool IsRecording = false;            // 是否有在錄影
        private static bool TryToUnRecording = false;       // 試著要解除 Recording 了

        // 紀錄的陣列
        private static List<string> LineData = new List<string>();

        public EyeTrackerTookit()
        {
            InitializeComponent();
        }

        //開啟
        private void EyeTrackerTookit_Load(object sender, EventArgs e)
        {
            // 設定眼動儀
            host = new Host();
            stream = host.Streams.CreateGazePointDataStream();

            // 把 Dialog 抓到 static 中
            dialog = outputFileDialog;

            // 設定游標
            SetupSystemCursorImage();

            // 設定鍵盤 Hook
            SetHook();
        }

        // 關閉
        private void EyeTrackerTookit_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 關閉眼動儀的連線
            host.DisableConnection();

            // 還原滑鼠
            RestoreSytemCursorImage();

            // 解除鍵盤 Hook
            UnHook();
        }

        private void GetGazePointTimer_Tick(object sender, EventArgs e)
        {
            // 抓眼動位置及儲存
            stream.GazePoint((x, y, ts) => CopyToGlobalVariable(x, y, ts));

            // Clipping 到螢幕中
            ClippingTo1920_1080();
            //ClippingTo2160_1440();

            // 代表資料不一樣
            // 要覆蓋 last 的值
            if (lastTimeStamp != timeStamp)
            {
                lastEyeX = eyeX;
                lastEyeY = eyeY;
                lastTimeStamp = timeStamp;

                // 是否要被眼動儀 Control
                if(IsEnableControl)
                    SetCursorPos((int)eyeX, (int)eyeY);

                // 是否要被記錄
                if(IsRecording)
                {
                    string line = eyeX.ToString() + "," + eyeY.ToString() + "," + timeStamp.ToString();
                    LineData.Add(line);

                    if (TryToUnRecording)
                    {
                        // 要暫停 Hook 不然會無法使用鍵盤打檔名
                        GetGazePointTimer.Enabled = false;
                        UnHook();

                        // 找到位置，並儲存
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            // 寫出檔案
                            string outputStr = "X, Y, TimeStamp\n";
                            for (int i = 0; i < LineData.Count; i++)
                                outputStr += LineData[i] + "\n";
                            System.IO.File.WriteAllText(dialog.FileName, outputStr);
                            
                        }
                        LineData.Clear();

                        // 繼續抓
                        GetGazePointTimer.Enabled = true;
                        SetHook();

                        TryToUnRecording = false;
                        IsRecording = false;
                    }
                }


            }
        }

        #region Helper Function
        #region 螢幕相關
        // 將拿到的資訊複製到 Global 變數中
        private void CopyToGlobalVariable(double x, double y, double ts)
        {
            eyeX = x;
            eyeY = y;
            timeStamp = ts;
        }

        // Clipping 到螢幕中
        private void ClippingTo1920_1080()
        {
            if (eyeX < 0)
                eyeX = 0;

            if (eyeX >= 1920)
                eyeX = 1920 - 1;

            if (eyeY < 0)
                eyeY = 0;

            if (eyeY >= 1080)
                eyeY = 1080 - 1;
        }

        private void ClippingTo2160_1440()
        {
            if (eyeX < 0)
                eyeX = 0;

            if (eyeX >= 2160)
                eyeX = 2160 - 1;

            if (eyeY < 0)
                eyeY = 0;

            if (eyeY >= 1440)
                eyeY = 1440 - 1;
        }
        #endregion
        #region 游標相關
        public void SetupSystemCursorImage()
        {
            #region 初始化
            int size = CursorIndex.Count();
            orgCursor = new IntPtr[size];
            #endregion
            #region 複製舊的 Cursor
            for (int i = 0; i < size; i++)
                orgCursor[i] = CopyIcon(LoadCursor(0, CursorIndex[i]));
            #endregion
            #region 將所有的 Cursor 設定成自動的圓
            if (Directory.Exists("Cursor Images"))
            {
                targetCursor = LoadCursorFromFile("./Cursor Images/pin.cur");
                for (int i = 0; i < size; i++)
                    SetSystemCursor(CopyIcon(targetCursor), CursorIndex[i]);
            }
            #endregion
        }

        public void RestoreSytemCursorImage()
        {
            for (int i = 0; i < CursorIndex.Count(); i++)
                SetSystemCursor(orgCursor[i], CursorIndex[i]);
        }


        // 滑鼠點擊的參數
        const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        const int MOUSEEVENTF_LEFTUP = 0x0004;
        public void DoSingleClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        public void DoDoubleClick()
        {
            DoSingleClick();
            DoSingleClick();
        }

        [DllImport("user32.dll")]
        static extern IntPtr CopyIcon(IntPtr pcur);
       
        [DllImport("user32.dll")]
        static extern IntPtr LoadCursor(int a, int b);

        [DllImport("user32.dll")]
        static extern IntPtr LoadCursorFromFile(string lpFileName);

        [DllImport("user32.dll")]
        static extern IntPtr SetSystemCursor(IntPtr hCursor, int id);

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        static extern void mouse_event(int mode, int a, int b, int c, int d);
        #endregion
        #region 鍵盤相關
        // Hook
        public static void SetHook()
        {
            hookPtr = SetWindowsHookEx(WH_KEYBOARD_LL, proc, IntPtr.Zero, 0);
        }

        // 解除 Hook
        public static void UnHook()
        {
            UnhookWindowsHookEx(hookPtr);
        }

        private static IntPtr hookPtr = IntPtr.Zero;
        private static LowLevelKeyboardProc proc = hookProc;

        // LL = Low Level
        const int WH_KEYBOARD_LL = 13;
        const int WM_KEYDOWN = 0x100;

        public static IntPtr hookProc(int code, IntPtr wParam, IntPtr lParam)
        {
            if (code >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);

                if (vkCode == (int)Keys.Z)
                    IsEnableControl = !IsEnableControl;
                else if (vkCode == (int)Keys.X)
                    IsSingleClickModel = !IsSingleClickModel;
                else if(vkCode == (int)Keys.C)
                {
                    // 要結束錄
                    if (IsRecording)
                        TryToUnRecording = true;
                    else
                        IsRecording = !IsRecording;
                }

                return (IntPtr)1;
            }
            else
                return CallNextHookEx(hookPtr, code, (int)wParam, lParam);
        }

        // 設定 process
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc callback, IntPtr hInstance, uint threadId);

        [DllImport("user32.dll")]
        static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, int wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);
        #endregion
        #endregion
    }
}
