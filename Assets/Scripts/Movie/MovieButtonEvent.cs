using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovieButtonEvent : MonoBehaviour
{

    ////////////////////////////////////////////////////
    // Chromecast相關
    ////////////////////////////////////////////////////
    [Header("========== Chromecast 相關 ==========")]
    public RectTransform MoviePlane;
    private bool IsChromecast = false;
    private Vector3 CurrentPos;
    private Vector2 Currentsize;
    private Vector3 ChromecastPos = new Vector3(766, -498.5f, 0);
    private Vector2 ChromecastSize = new Vector2(-1662, -1159);
    private const float ChromecastCount = 0.5f;

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
    private float NavbarMoveSpeed, FooterMoveSpeed;     // 上下的距離
    #endregion

    // 0 => 沒有要播動畫
    // 1 => 消失動畫
    // 2 => 消失的狀態
    // 3 => 顯示動畫
    // 4 => Chromecast 消失動畫
    // 5 => Chromecast 之後，縮小的 status
    private int HiddenStatus = 0;                       // 狀態控制                       
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
        NavStartPosY = (int)Navbar.localPosition.y;
        NavbarEndPosY = NavStartPosY + NavbarHeight;

        // 下方
        FooterStartPosY = (int)Footer.localPosition.y;
        FooterEndPosY = FooterStartPosY - FooterHeight;

        // 把 Movie Plane 原始的資料拿下來
        CurrentPos = MoviePlane.localPosition;
        Currentsize = MoviePlane.sizeDelta;

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
                    NavbarMoveSpeed = NavbarEndPosY - Navbar.localPosition.y;
                    FooterMoveSpeed = FooterEndPosY - Footer.localPosition.y;
                }
                break;
            case 1:
                HiddenCounter += Time.deltaTime;

                // 判斷隱藏的條件
                if (HiddenCounter >= HiddenProgress)
                {
                    HiddenStatus = 2;
                    HiddenCounter = 0;

                    Navbar.localPosition = new Vector3(0, NavbarEndPosY, 0);
                    Footer.localPosition = new Vector3(0, FooterEndPosY, 0);
                }
                else
                {
                    Navbar.localPosition += new Vector3(0, NavbarMoveSpeed, 0) / HiddenProgress * Time.deltaTime;
                    Footer.localPosition += new Vector3(0, FooterMoveSpeed, 0) / HiddenProgress * Time.deltaTime;
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

                    Navbar.localPosition = new Vector3(0, NavStartPosY, 0);
                    Footer.localPosition = new Vector3(0, FooterStartPosY, 0);
                }
                else
                {
                    Navbar.localPosition -= new Vector3(0, NavbarMoveSpeed, 0) / HiddenProgress * Time.deltaTime;
                    Footer.localPosition -= new Vector3(0, FooterMoveSpeed, 0) / HiddenProgress * Time.deltaTime;
                }
                break;
            case 4:
                HiddenCounter += Time.deltaTime;

                // 這部分是做當要 chromecast 的時候，會把整個縮小的流程
                if(HiddenCounter >= ChromecastCount)
                {
                    HiddenStatus = 5;
                    HiddenCounter = 0;

                    MoviePlane.localPosition = ChromecastPos;
                    MoviePlane.sizeDelta = ChromecastSize;

                    #region 重新播放
                    MovieManger movieM = MoviePlane.GetComponent<MovieManger>();
                    movieM.movie.Play();
                    MoviePlane.GetComponent<RawImage>().color = Color.white;
                    #endregion
                }
                else
                {
                    Vector3 diffPos = ChromecastPos - CurrentPos;
                    Vector2 diffSize = ChromecastSize - Currentsize;

                    MoviePlane.anchoredPosition3D = diffPos * HiddenCounter / ChromecastCount + CurrentPos;
                    MoviePlane.sizeDelta = diffSize * HiddenCounter / ChromecastCount + Currentsize;
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
                NavbarMoveSpeed = Navbar.localPosition.y - NavStartPosY;
                FooterMoveSpeed = Footer.localPosition.y - FooterStartPosY;

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
            IsChromecast = true;
            HiddenStatus = 4;
            HiddenCounter = 0;

            Navbar.gameObject.SetActive(false);
            Footer.gameObject.SetActive(false);

            #region 暫停播放
            MovieManger movieM = MoviePlane.GetComponent<MovieManger>();
            movieM.movie.Stop();
            MoviePlane.GetComponent<RawImage>().color = Color.black;
            #endregion
            //SceneManager.LoadSceneAsync(3, LoadSceneMode.Additive);
        }
    }

}
