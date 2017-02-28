using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Tobii.EyeTracking;

public class TestScene : MonoBehaviour {

    public Text DebugText;
    public RectTransform Circle;


    bool IsUseFilter = true;

    private Vector2 FinalPoint = new Vector2(0, 0);

    #region Double Exponential Filter 參數
    //////////////////////////////////////////////////////////////////////////
    // 參考來源： https://en.wikipedia.org/wiki/Exponential_smoothing
    //////////////////////////////////////////////////////////////////////////
    [Header("Double Exponential Filter 相關設定"),Range(0,1)]
    public float SmoothingFactorA = 0.9f;                                                               // 係數 A
    [Range(0, 1)]
    public float SmoothingFactorB = 0.1f;                                                               // 係數 B

    private Vector2 HistoryPointTime0;                                                                  // 第 0 個 Frame 會用到
    private Vector2 s,b;                                                                                // 前一個 frame 的參數

    private bool IsTime0Past = false;                                                                   // 是否過了 Time0
    private bool IsTime1Past = false;                                                                   // 是否過了 Time1

    #endregion

    void Start()
    {
        EyeTracking.Initialize();
    }
    void Update()
    {
        if (!EyeTracking.GetGazePoint().IsValid)
            return;
        FinalPoint = EyeTracking.GetGazePoint().Screen;

        if (IsUseFilter)
            FinalPoint = DoubleExpFilter(FinalPoint);

        DebugText.text = "Point ( " + FinalPoint + " )";
        Circle.position = FinalPoint;
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

    /*Vector2 FilterFunction(Vector2 InputPos)
    {
        if(!HasHistoryPoint)
        {
            HistoryPoint = InputPos;
            HasHistoryPoint = true;
        }

        Vector2 smoothPos = new Vector2(
            InputPos.x * (1.0f - FilterSmoothingFactor) + HistoryPoint.x * FilterSmoothingFactor,
            InputPos.y * (1.0f - FilterSmoothingFactor) + HistoryPoint.y * FilterSmoothingFactor
            );

        HistoryPoint = smoothPos;
        return smoothPos;
    }*/

    /*void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(EyeTracking.GetGazePoint().Screen - new Vector2(Screen.width / 2, Screen.height / 2), 1);
    }*/
}
