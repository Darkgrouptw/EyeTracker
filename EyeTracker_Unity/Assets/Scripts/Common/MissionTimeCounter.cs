using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using System.IO;

public class MissionTimeCounter : MonoBehaviour
{
    public float TimeCounter = 0;                                // 計數的時間
    private int StateIndex = 0;                                  // 現在在第幾個關卡
    public bool IsRecordBefore = false;                          // 只要一個 State 有被 Record 過，就會變成 True

    void Start()
    {
        // 判斷不是是進入的 A1，就要抓前面的訊息
        if(SceneManager.GetActiveScene().buildIndex != 0)
        {
            StateIndex = PlayerPrefs.GetInt("StateIndex");
            TimeCounter = PlayerPrefs.GetFloat("Time");
            IsRecordBefore = (PlayerPrefs.GetInt("IsRecordBefore") == 0) ? false : true;
        }
    }

    public void SaveAllState()
    {
        // 在切換場景的時候，所有的變數會重新設定，所以要存起來
        PlayerPrefs.SetInt("StateIndex", StateIndex);
        PlayerPrefs.SetFloat("Time", TimeCounter);
        PlayerPrefs.SetInt("IsRecordBefore", IsRecordBefore ? 1 : 0);
    }
    // 會下一個階段
    public void UpgradeToNextLevel(int index)
    {
        TimeCounter = 0;
        // 如果有這個情形的話，代表要跳關
        if ((StateIndex + 1) % 4 != index || !IsRecordBefore)
        {
            for (; StateIndex != index; StateIndex = ++StateIndex % 4)   // 總共有 4 個任務
                RecordBlank();
        }
        IsRecordBefore = false;
        StateIndex = index;                                            
    }

    // 將時間寫入檔案
    public void RecordTime()
    {
        if(!IsRecordBefore)
        {
            // 判斷路徑有沒有存在
            if (!Directory.Exists("./Records"))
                Directory.CreateDirectory("./Records");


            string outputStr = "Mission " + (StateIndex + 1).ToString() + "," + TimeCounter + "\n";
            File.AppendAllText("./Records/Mission Time.csv", outputStr);

            IsRecordBefore = true;
        }
    }
    public void RecordBlank()
    {
        // 判斷路徑有沒有存在
        if (!Directory.Exists("./Records"))
            Directory.CreateDirectory("./Records");

        string outputStr = "Mission " + (StateIndex + 1).ToString() + "," + 0 + "\n";
        File.AppendAllText("./Records/Mission Time.csv", outputStr);

        IsRecordBefore = true;
    }
}