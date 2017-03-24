using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Tobii.EyeTracking;

using UnityEngine.SceneManagement;
using System.IO;

public class EyeTrackCursor : MonoBehaviour
{
    [Header("========== 眼動相關設定 ==========")]
    public bool IsDebugMode = false;                                                                    // 是否是 Debug Mode
    public bool IsUseFilter = true;                                                                     // 是否要使用 Filter

    #region Debug 訊息 & 點的資料
    public GUIStyle style = new GUIStyle();                                                             // 顯示 Debug Mode 的型態
    private float FPS;                                                                                  // 顯示 FPS
    private Vector2 FinalPoint = new Vector2(0, 0);                                                     // 最後要位移到的那個點
    #endregion
    #region Double Exponential Filter 參數
    //////////////////////////////////////////////////////////////////////////
    // 參考來源： https://en.wikipedia.org/wiki/Exponential_smoothing
    //////////////////////////////////////////////////////////////////////////
    [Header("Double Exponential Filter 相關設定"),Range(0,1)]
    public float SmoothingFactorA = 0.1f;                                                               // 係數 A
    [Range(0, 1)]
    public float SmoothingFactorB = 0.9f;                                                               // 係數 B

    private Vector2 HistoryPointTime0;                                                                  // 第 0 個 Frame 會用到
    private Vector2 s,b;                                                                                // 前一個 frame 的參數

    private bool IsTime0Past = false;                                                                   // 是否過了 Time0
    private bool IsTime1Past = false;                                                                   // 是否過了 Time1


    [Header("========== 滑鼠相關參數 =========")]
    public float DiffTime = 1;                                                                          // 一秒過後，如果還在範圍裏面，就會放大
    private float DiffCounter = 0;                                                                      // 差距的計數器
    public float DiffDistance = 30;                                                                     // 差距在這個以內，就會計數

    [Header("========== 錄影相關 =========")]
    public bool IsRecord = true;
    private List<Vector2> recordData = new List<Vector2>();                                             // 存下來的所有 Data

    #endregion

    void Start()
    {
        EyeTracking.Initialize();

        // 設定 Debug 的 Style
        style.normal.textColor = Color.white;
        style.fontSize = 50;

        StartCoroutine(FPSCounter());
    }

    void Update()
    {
        #region 判斷是否要開啟 Debug 的訊息
        if (Input.GetKeyDown(KeyCode.D))
            IsDebugMode = !IsDebugMode;
        #endregion
        #region 眼動儀抓點
        if (!EyeTracking.GetGazePoint().IsValid)
            return;
        FinalPoint = ScreenToWorld(EyeTracking.GetGazePoint().Screen);
        if (IsUseFilter)
            FinalPoint = DoubleExpFilter(FinalPoint);

        recordData.Add(FinalPoint);
        #endregion
        #region 移動滑鼠 & 點擊判斷
        CursorAPI.SetCursorPosAPI(FinalPoint);

        // 判斷距離有沒有在設定的範圍內，有的話就加時間
        float dist = Vector3.Distance(HistoryPointTime0, FinalPoint);
        if (dist <= DiffDistance)
            DiffCounter += Time.deltaTime;
        else
            DiffCounter = 0;

        // 如果超過 DiffTime 代表傳送點擊事件
        if (DiffCounter >= DiffTime)
        {
            CursorAPI.CursorClickAPI();
            DiffCounter = 0;
        }


        // 最後要更新過去的點
        HistoryPointTime0 = FinalPoint;
        #endregion
    }


    void OnDestroy()
    {
        // 錄影的部分
        if(!Directory.Exists("./Records"))
            Directory.CreateDirectory("../Records");

        int index = SceneManager.GetActiveScene().buildIndex;
        string outputStr = "";

        for (int i = 0; i < recordData.Count; i++)
            outputStr += recordData[i].x + ", " + recordData[i].y + "\n";

        File.WriteAllText("./Records/Page " + (index + 1).ToString() + ".csv", outputStr);
    }

    void OnGUI()
    {
        if(IsDebugMode)
        {
            GUI.Box(new Rect(8, 8, 600, 200), "Debug Message");
            GUI.Label(new Rect(8, 8, 600, 80), "FPS \t=> " + FPS, style);
            GUI.Label(new Rect(8, 58, 600, 50), "Point \t=> " + FinalPoint, style);
            GUI.Label(new Rect(8, 108, 600, 50), "Counter \t=> " + DiffCounter, style);
        }
    }


    IEnumerator FPSCounter()
    {
        while(true)
        {
            FPS = Mathf.Round(1.0f / Time.deltaTime * 100) / 100;
            yield return new WaitForSeconds(1);
        }
    }


    Vector2 ScreenToWorld(Vector2 pos)
    {
        return new Vector2(Mathf.Clamp(pos.x, 0, Screen.width),
            Mathf.Clamp(Screen.height - pos.y, 0 ,Screen.height));
    }

    Vector2 DoubleExpFilter(Vector2 InputPos)
    {
        // s0
        if(!IsTime0Past)
        {
            HistoryPointTime0 = InputPos;
            IsTime0Past = true;
            return InputPos;
        }

        // s1
        if(!IsTime1Past)
        {
            s = InputPos;
            b = InputPos - HistoryPointTime0;
            IsTime1Past = true;
            return s + b;
        }

        Vector2 NextS, NextB;
        NextS = SmoothingFactorA * InputPos +  Mathf.Clamp01(1 - SmoothingFactorA) * (s - b);
        NextB = SmoothingFactorB * (NextS - s) + Mathf.Clamp01(1 - SmoothingFactorB) * b;
        s = NextS;
        b = NextB;
        return s + b;
    }
}
