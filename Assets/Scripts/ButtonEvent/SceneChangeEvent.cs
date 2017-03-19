using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChangeEvent : MonoBehaviour
{
    void Update()
    {
        // 離開程式
        if(Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
    
    public void A1ToA2()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void A2ToA3()
    {
        SceneManager.LoadSceneAsync(2);
    }
}