using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(RawImage))]
public class MovieManger : MonoBehaviour
{
    [Header("========== 影片播放相關 ==========")]
    public MovieTexture movie;                                      // 影片
    public MovieButtonEvent movieEvent;                             // 要拿它來使用按鈕

    [HideInInspector]
    public AudioSource soundSource;

    public RectTransform FrontBar;                                  // 前面那條 bar
    public RectTransform BlueDot;                                   // 藍色的點
    public Text timeLabel;                                          // 時間的 Label

    private float MoviePlayTime = 0;                                // 影片目前播出的時間
    private float MovieLength = 417;                                // 影片長度
    private const float MovieLoadingLength = 5;                     // 影片的讀取時間


    // 座標參數
    private const int StartPosX = -850;                             // 開始的 X 位置
    private const int EndPosX = 650;                                // 結束的 X 位置
    private const int PosY = -632;                                  // Y 的位置

    private MissionTimeCounter counter;

	void Start ()
    {
        #region 抓 Mission Time Counter
        GameObject MissionTime = GameObject.FindGameObjectWithTag("Mission Time Tracker");
        counter = MissionTime.GetComponent<MissionTimeCounter>();
        #endregion
        RawImage render = this.GetComponent<RawImage>();
        render.texture = movie;

        soundSource = this.gameObject.AddComponent<AudioSource>();
        soundSource.clip = movie.audioClip;

        // 判對他有沒有影片
        if (movie != null)
        {
            movie.Play();
            soundSource.Play();

            movieEvent.SetPlayButton(false);
        }
	}

    void Update()
    {
        #region 進度欄的更新
        if(movie.isPlaying)
        {
            MoviePlayTime += Time.deltaTime;
            BlueDot.localPosition = BlueDotLocation();
            FrontBar.localScale = FrontBarRatio();
            timeLabel.text = MovieTimeText();
        }
        else if(MoviePlayTime + MovieLoadingLength >= MovieLength)
        {
            // 任務四開始
            counter.SaveAllState();
            counter.UpgradeToNextLevel(3);

            // 換場景
            SceneManager.LoadSceneAsync(3);
        }
        #endregion
    }



    #region 影片進度相關的 Function
    // 回傳藍點應該的位置
    private Vector3 BlueDotLocation()
    {
        const float lineWidth = (float)(EndPosX - StartPosX);
        return new Vector3(lineWidth * MoviePlayRatio() + StartPosX, PosY, 0);
    }

    // 回傳藍點的比例
    private Vector3 FrontBarRatio()
    {
        return new Vector3(MoviePlayRatio(), 1, 1);
    }

    private string MovieTimeText()
    {
        int secs = (int)(MoviePlayTime - MovieLoadingLength);

        // 要扣掉 loading 的時間
        if (secs < 0)
            secs = 0;

        int mins = secs / 60;                       // Unity 的 int 會無條件捨去

        return TimeFormat(mins) + ":" + TimeFormat(secs);
    }

    private string TimeFormat(int num)
    {
        if (num < 10)
            return "0" + num.ToString();
        return num.ToString();
    }

    // 回傳影片的百分比
    public float MoviePlayRatio()
    {
        if (MoviePlayTime <= MovieLoadingLength)
            return 0;
        return (MoviePlayTime - MovieLoadingLength) / (MovieLength - MovieLoadingLength);
    }


    // 重新播放後，時間要歸零
    public void ResetTime()
    {
        MoviePlayTime = 0;
    }


    // 拿影片時間，會扣掉 loading 時間
    public float GetMoviePlayTime()
    {
        return MoviePlayTime - MovieLoadingLength;
    }
    public float GetMovieLength()
    {
        return MovieLength - MovieLoadingLength;
    }
    #endregion
}
