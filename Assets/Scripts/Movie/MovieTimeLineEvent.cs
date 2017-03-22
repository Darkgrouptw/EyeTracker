using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovieTimeLineEvent : MonoBehaviour
{
    [Header("========== Time Line 的設定 ==========")]
    public GameObject BlueDotEmpty;                     // 空的點
    public GameObject BlueDotFull;                      // 滿的點
    public MovieManger movieM;                          // 專門處理影片播放的 Manager

    [Header("========== 圖片事件相關 ==========")]
    public int[] EventTime;                             // 事件發生的時間
    public string[] EventPeopleName;                    // 事件人物名稱
    public string[] EventPeopleSubName;                 // 事件人物的 sub 名稱
    public Sprite[] Image;                              // 顯示事件的圖片
    public Sprite[] ImageDark;                          // 黑掉的圖片
    public Sprite Line;                                 // 線的
    public Sprite LineDark;                             // 暗掉的線

    // 起始座標 & 終止座標
    private float TimeLineStartX, TimeLineEndX;         // 時間軸 X
    private float TimeLineY;                            // 時間軸 Y
    

    void Start()
    {
        RectTransform Empty = BlueDotEmpty.GetComponent<RectTransform>();
        RectTransform Full = BlueDotFull.GetComponent<RectTransform>();

        // 時間欄設定
        TimeLineStartX = Empty.localPosition.x;
        TimeLineEndX = Full.localPosition.x;
        TimeLineY = Empty.localPosition.y;
    }
}
