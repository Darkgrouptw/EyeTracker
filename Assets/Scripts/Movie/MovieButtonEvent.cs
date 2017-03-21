using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MovieButtonEvent : MonoBehaviour
{

    ////////////////////////////////////////////////////
    // Chromecast相關
    ////////////////////////////////////////////////////
    private bool IsChromecast = false;



    ////////////////////////////////////////////////////
    // 播放欄相關
    ////////////////////////////////////////////////////
    [Header("========== 播放欄相關的 ==========")]
    public RectTransform Navbar;                        // 上面那欄
    public RectTransform Footer;                        // 下面那欄
    
    #region 座標的參數
    private int NavStartPosY, FooterStartPosY;          // 上下一開始的位置
    private int NavbarEndPosY, FooterEndPosY;           // 上下移動終止的地方
    private int NavbarHeight, FooterHeight;             // 上下的寬度
    private float NavbarMoveSpeed, FooterMoveSpeed;        // 上下的距離
    #endregion

    private int HiddenStatus = 0;                       // 0 => 沒有要播動畫、1 => 消失動畫、2 => 消失的狀態、3 => 顯示動畫
    private float HiddenCounter = 0;                    // 計數器
    private const int HiddenTime = 6;                   // 6 秒沒有碰到，就會消失
    private const int HiddenProgress = 1;               // 消失 & 顯示的時間


    void Start()
    {
        // 初始化給的寬
        RectTransform navbarHover = Navbar.GetComponentsInChildren<Transform>()[2].GetComponent<RectTransform>();
        RectTransform footerHover = Footer.GetComponentsInChildren<Transform>()[2].GetComponent<RectTransform>();

        // 寬度
        NavbarHeight = (int)navbarHover.sizeDelta.y;
        FooterHeight = (int)footerHover.sizeDelta.y;

        // 上方
        NavStartPosY = (int)Navbar.transform.localPosition.y;
        NavbarEndPosY = NavStartPosY + NavbarHeight;

        // 下方
        FooterStartPosY = (int)Footer.transform.localPosition.y;
        FooterEndPosY = FooterStartPosY - FooterHeight;
    }

    void Update()
    {
        switch (HiddenStatus)
        {
            case 0:
                HiddenCounter += Time.deltaTime;

                // 判斷是否閒適夠久，如果夠久，就開始縮起來
                if (HiddenCounter >= HiddenTime)
                {
                    HiddenCounter = 0;
                    HiddenStatus = 1;

                    // 從頭到目標的速度
                    NavbarMoveSpeed = NavbarEndPosY - Navbar.transform.localPosition.y;
                    FooterMoveSpeed = FooterEndPosY - Footer.transform.localPosition.y;
                }
                break;
            case 1:
                HiddenCounter += Time.deltaTime;

                // 判斷隱藏的條件
                if (HiddenCounter >= HiddenProgress)
                {
                    HiddenStatus = 2;
                    HiddenCounter = 0;

                    Navbar.transform.localPosition = new Vector3(0, NavbarEndPosY, 0);
                    Footer.transform.localPosition = new Vector3(0, FooterEndPosY, 0);
                }
                else
                {
                    //float Progress = HiddenCounter / HiddenProgress;
                    Navbar.transform.localPosition += new Vector3(0, NavbarMoveSpeed, 0) / HiddenProgress * Time.deltaTime;
                    Footer.transform.localPosition += new Vector3(0, FooterMoveSpeed, 0) / HiddenProgress * Time.deltaTime;
                }
                break;

            case 2:
                // 隱藏，所以不用動作
                break;
            case 3:
                HiddenCounter += Time.deltaTime;

                if(HiddenCounter >= HiddenProgress)
                {
                    HiddenStatus = 0;
                    HiddenCounter = 0;

                    Navbar.transform.localPosition = new Vector3(0, NavStartPosY, 0);
                    Footer.transform.localPosition = new Vector3(0, FooterStartPosY, 0);
                }
                else
                {
                    //float Progress = HiddenCounter / HiddenProgress;
                    Navbar.transform.localPosition -= new Vector3(0, NavbarMoveSpeed, 0) / HiddenProgress * Time.deltaTime;
                    Footer.transform.localPosition -= new Vector3(0, FooterMoveSpeed, 0) / HiddenProgress * Time.deltaTime;
                }
                break;

        }
    }

    public void BarHover()
    {
        switch (HiddenStatus)
        {
            case 0:
                // 重製 Counter
                HiddenCounter = 0;
                break;
            case 1:
            case 2:
                // 從現在到開始的速度
                NavbarMoveSpeed = Navbar.transform.localPosition.y - NavStartPosY;
                FooterMoveSpeed = Footer.transform.localPosition.y - FooterStartPosY;

                HiddenStatus = 3;
                HiddenCounter = 0;
                break;
            case 3:
                // 正在復原，所以不用做事
                break;
        }
    }


    public void ChromecastButton()
    {
        if(!IsChromecast)
        {

        }
    }

}
