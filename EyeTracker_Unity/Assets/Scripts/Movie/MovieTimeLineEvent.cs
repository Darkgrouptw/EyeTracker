using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MovieSideEvent))]
public class MovieTimeLineEvent : MonoBehaviour
{
    [Header("========== Time Line 的設定 ==========")]
    public GameObject BlueDotEmpty;                     // 空的點
    public GameObject BlueDotFull;                      // 滿的點
    public RectTransform BlueTimeLine;                  // 藍色的 Time Line 更新
    public MovieManger movieM;                          // 專門處理影片播放的 Manager
    private Sprite blueDotImage;                        // Dot 藍色的圖片

    [Header("========== 圖片事件相關 ==========")]
    public int[] EventTime;                             // 事件發生的時間
    public string[] EventPeopleName;                    // 事件人物名稱
    public string[] EventPeopleSubName;                 // 事件人物的 sub 名稱
    public Sprite[] Image;                              // 顯示事件的圖片
    public Sprite[] ImageDark;                          // 黑掉的圖片
    private MovieSideEvent sideEvent;                   // 要新增按下的事件

    [Header("========== Info Block 相關 ==========")]
    public GameObject InfoBlock;                        // 正常的 Block
    public GameObject InfoBlockDark;                    // 黑色的 Block

    // 產生出來的點，後面可以做替換用
    private List<Image> BlueDotList = new List<Image>();
    private List<bool> BlueDotBool = new List<bool>();
    private List<bool> BlockBool = new List<bool>();
    private List<GameObject> InfoBlockList = new List<GameObject>();
    private List<GameObject> InfoBlockDarkList = new List<GameObject>();

    // 起始座標 & 終止座標
    private float TimeLineStartX, TimeLineEndX;         // 時間軸 X
    private float TimeLineY;                            // 時間軸 Y
    private float diff;                                 // 從起始到終點的距離
    

    void Start()
    {
        RectTransform Empty = BlueDotEmpty.GetComponent<RectTransform>();
        RectTransform Full = BlueDotFull.GetComponent<RectTransform>();
        sideEvent = this.GetComponent<MovieSideEvent>();

        #region 拿時間欄的一些數值
        TimeLineStartX = Empty.localPosition.x;
        TimeLineEndX = Full.localPosition.x;
        TimeLineY = Empty.localPosition.y;

        blueDotImage = BlueDotFull.GetComponent<Image>().sprite;
        #endregion
        #region 根據事件，去擺放每一個 Blue Dot
        Transform BlueDotParent = BlueDotEmpty.transform.parent;
        diff = TimeLineEndX - TimeLineStartX;
        for(int i = 0; i < EventTime.Length; i++)
        {
            float CurrentX = diff * EventTime[i] / movieM.GetMovieLength();
            
            #region InfoBlock 的生成
            GameObject temp;
            temp = GameObject.Instantiate(InfoBlock);
            temp.transform.SetParent(BlueDotParent, false);
            temp.transform.localPosition = new Vector3(InfoBlock.transform.localPosition.x + CurrentX,
                                                    InfoBlock.transform.localPosition.y,
                                                    InfoBlock.transform.localPosition.z);
            temp.name = "InfoBlock " + (i + 1);

            // 指定事件 (不會顯示在 Onclick 上面，但是點下去真的會有反應)
            int index = i;
            temp.GetComponent<Button>().onClick.AddListener(() => sideEvent.TimeLineImageButtonEvent(index));

            Transform[] childs = temp.GetComponentsInChildren<Transform>(true);
            childs[1].GetComponent<Image>().sprite = Image[i];
            childs[1].gameObject.SetActive(true);
            childs[2].GetComponent<Text>().text = EventPeopleName[i];
            childs[3].GetComponent<Text>().text = EventPeopleSubName[i];
            
            InfoBlockList.Add(temp);
            #endregion

            #region InfoBlock Dark 的生成
            temp = GameObject.Instantiate(InfoBlockDark);
            temp.transform.SetParent(BlueDotParent, false);
            temp.transform.localPosition = new Vector3(InfoBlockDark.transform.localPosition.x + CurrentX,
                                                    InfoBlockDark.transform.localPosition.y,
                                                    InfoBlockDark.transform.localPosition.z);
            temp.name = "InfoBlock Dark " + (i + 1);

            childs = temp.GetComponentsInChildren<Transform>(true);
            childs[1].GetComponent<Image>().sprite = ImageDark[i];
            childs[1].gameObject.SetActive(true);

            InfoBlockDarkList.Add(temp);
            #endregion

            #region 底下點生成
            temp = GameObject.Instantiate(BlueDotEmpty);
            temp.name = "Event " + (i + 1);
            temp.transform.SetParent(BlueDotParent);
            temp.SetActive(true);

            // 位置設定
            RectTransform rectTemp = temp.GetComponent<RectTransform>();
            rectTemp.localPosition = new Vector3(CurrentX + TimeLineStartX, TimeLineY, 0);
            #endregion

            // 把東西加回到堆節理
            BlueDotList.Add(temp.GetComponent<Image>());
            BlueDotBool.Add(false);
            BlockBool.Add(false);
        }
        #endregion
        #region 刪除不必要的東西
        Destroy(BlueDotEmpty);
        Destroy(BlueDotFull);

        Destroy(InfoBlock);
        Destroy(InfoBlockDark);
        #endregion
    }

    void Update()
    {
        // 去更新 藍色 TimeLine 的長度
        BlueTimeLine.localScale = new Vector3(movieM.MoviePlayRatio() , 1, 1);

        for(int i = 0; i < EventTime.Length; i++)
            if(!BlueDotBool[i] && movieM.GetMoviePlayTime() >= EventTime[i])
            {
                BlueDotBool[i] = true;
                BlueDotList[i].sprite = blueDotImage;

                InfoBlockList[i].SetActive(true);
            }
            else if(!BlockBool[i] && movieM.GetMoviePlayTime() >= EventTime[i] + 4)
            {
                BlockBool[i] = true;

                BlueDotList[i].gameObject.SetActive(false);

                InfoBlockList[i].SetActive(false);
                InfoBlockDarkList[i].SetActive(true);
            }
    }
}