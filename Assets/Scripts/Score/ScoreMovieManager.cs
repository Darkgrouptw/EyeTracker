using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(RawImage))]
public class ScoreMovieManager : MonoBehaviour
{
    public MovieTexture movie;

    [HideInInspector]
    public AudioSource soundSource;

    void Start()
    {
        RawImage render = this.GetComponent<RawImage>();
        render.texture = movie;

        soundSource = this.gameObject.AddComponent<AudioSource>();
        soundSource.clip = movie.audioClip;

        if (movie != null)
        {
            movie.Play();
            soundSource.Play();
        }
    }
    void Update()
    {
        #region 進度欄的更新
        if (!movie.isPlaying)
            SceneManager.LoadSceneAsync(5);
        #endregion
    }

}
