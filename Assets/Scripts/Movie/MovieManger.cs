using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class MovieManger : MonoBehaviour
{
    [Header("========== 影片播放相關 ==========")]
    public MovieTexture movie;                                      // 影片

    public RectTransform FrontBar;                                  // 前面那條 bar
    public RectTransform BlueDot;                                   // 藍色的點
    public Text timeLabel;                                          // 時間的 Label

    private const float MovieLength = 417;                          // 影片長度
    private float MoviePlayTime = 0;                                // 影片目前播出的時間
    private const float MovieLoadingLength = 4;                     // 影片的讀取時間


    // 座標參數
    private const int StartPosX = -850;                             // 開始的 X 位置
    private const int EndPosX = 650;                                // 結束的 X 位置
    private const int PosY = -632;                                  // Y 的位置

	void Start ()
    {
        RawImage render = this.GetComponent<RawImage>();
        render.texture = movie;

        AudioSource soundSource = this.gameObject.AddComponent<AudioSource>();
        soundSource.clip = movie.audioClip;

        // 判對他有沒有影片
        if (movie != null)
        {
            movie.Play();
            soundSource.Play();
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
    private float MoviePlayRatio()
    {
        if (MoviePlayTime <= MovieLoadingLength)
            return 0;
        return (MoviePlayTime - MovieLoadingLength) / (MovieLength - MovieLoadingLength);
    }
    #endregion
}
