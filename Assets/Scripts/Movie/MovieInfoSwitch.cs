using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MovieInfoSwitch : MonoBehaviour
{
    //////////////////////////////////////////
    // Info 切換相關的 Status
    //////////////////////////////////////////
    [Header("========== Info 切換相關 ==========")]
    public RectTransform[] InfoText;
    public RectTransform SwitchBar;
    private float[] BarPos = { -586, -105, 375.5f };    // Switch bar 動的 X 座標
    private float BarPosY;                              // Switch bar 的 Y 值
    private float centerX, centerY;                     // 中間座標的 X, Y
    private int InfoStatus = 1;                         // 紀錄現在在哪一個 Status (1為開始)

    // 移動的 Counter
    public AnimationCurve curveM;                       // 移動的曲線
    private float StartPosX, EndPosX;                   // 移動的時候，會紀律的座標點
    private bool IsMoving = false;                      // 判斷是否在移動，如果再移動，就不給動
    private float TimeCounter = 0;                      // 時間的 Counter
    private const float MoveTime = 0.5f;                // 移動的時間


    private const int ScreenWidth = 2140;

    void Start()
    {
        // 中心的座標
        centerX = InfoText[0].localPosition.x;
        centerY = InfoText[0].localPosition.y;
        BarPosY = SwitchBar.localPosition.y;

        for (int i = 1; i < InfoText.Length; i++)
            InfoText[i].localPosition = new Vector3(centerX + ScreenWidth, centerY, 0);
    }

    void Update()
    {
        // 移動
        if(IsMoving)
        {
            TimeCounter += Time.deltaTime;
            if(TimeCounter >= MoveTime)
            {
                SwitchBar.localPosition = new Vector3(EndPosX, BarPosY, 0);

                // 取消移動
                TimeCounter = 0;
                IsMoving = false;
            }
            else
            {
                float diff = EndPosX - StartPosX;
                float prograss = curveM.Evaluate(TimeCounter / MoveTime);
                SwitchBar.localPosition = new Vector3(diff * prograss + StartPosX,
                                                    BarPosY, 0);
            }
        }
    }

    public void Info1ButtonEvent()
    {
        if(InfoStatus != 1 && !IsMoving)
        {
            StartPosX = BarPos[InfoStatus - 1];
            EndPosX = BarPos[0];
            InfoStatus = 1;

            IsMoving = true;
        }
    }

    public void Info2ButtonEvent()
    {
        if(InfoStatus != 2 && !IsMoving)
        {
            StartPosX = BarPos[InfoStatus - 1];
            EndPosX = BarPos[1];
            InfoStatus = 2;

            IsMoving = true;
        }
    }

    public void Info3ButtonEvent()
    {
        if(InfoStatus != 3 && !IsMoving)
        {
            StartPosX = BarPos[InfoStatus - 1];
            EndPosX = BarPos[2];
            InfoStatus = 3;

            IsMoving = true;
        }
    }
}