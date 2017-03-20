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

    private float MovieLength = 0;                                  // 影片長度
    private float MoviePlayTime = 0;                                // 影片目前播出的時間


    // 座標參數
    private const int StartPosX = -850;                             // 開始的 X 位置
    private const int EndPosX = 650;                                // 結束的 X 位置
    private const int PosY = -630;                                  // Y 的位置

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
            BlueDot.transform.localPosition = BlueDotLocation();
            FrontBar.transform.localScale = FrontBarRatio();
        }
        #endregion
    }

    // 回傳藍點應該的位置
    private Vector3 BlueDotLocation()
    {
        const float lineWidth = (float)(EndPosX - StartPosX);
        return new Vector3(lineWidth * MoviePlayRatio(), PosY, 0);
    }

    // 回傳藍點的比例
    private Vector3 FrontBarRatio()
    {
        return new Vector3(MoviePlayRatio(), 1, 1);
    }

    // 回傳影片的百分比
    private float MoviePlayRatio()
    {
        return MoviePlayTime / MovieLength;
    }
}
