using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChangeEvent : MonoBehaviour
{
    private MissionTimeCounter counter;

    void Start()
    {
        #region 抓 Mission Time Counter
        GameObject MissionTime = GameObject.FindGameObjectWithTag("Mission Time Tracker");
        counter = MissionTime.GetComponent<MissionTimeCounter>();
        #endregion
        // 任務一開始
        //counter.UpgradeToNextLevel(0);
    }

    void Update()
    {
        // 離開程式
        if(Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
    
    public void A1ToA2()
    {
        SceneManager.LoadSceneAsync(1);
        counter.SaveAllState();
    }
    public void A2ToA3()
    {
        SceneManager.LoadSceneAsync(2);

        // 任務一結束
        counter.RecordTime();
        counter.SaveAllState();
    }

    // 中間沒有 A3 到 A4，因為是影片播放完才過去

    public void A4ToA5()
    {
        SceneManager.LoadSceneAsync(4);

        // 任務四結束
        counter.RecordTime();
        counter.SaveAllState();
    }

    public void A5ToA6()
    {
        SceneManager.LoadSceneAsync(5);
        counter.SaveAllState();
    }
    public void A6ToA1()
    {
        SceneManager.LoadSceneAsync(0);
    }
}