using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
public class MovieManger : MonoBehaviour
{
    [Header("========== 影片播放相關 ==========")]
    public MovieTexture movie;                                      // 影片

    public RectTransform FrontBar;                                  // 前面那條 bar
    public RectTransform BlueDot;                                   // 藍色的點

    private int MovieLength;                                        // 影片長度


	void Start ()
    {
        MeshRenderer render = this.GetComponent<MeshRenderer>();
        render.materials[0].mainTexture = movie;

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

    }

}
