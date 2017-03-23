using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class MovieSideEvent : MonoBehaviour
{
    [Header("========== 按下 Time Line 的事件 ==========")]
    public GameObject[] BackgroundImage;

    public void TimeLineImageButtonEvent(int num)
    {
        BackgroundImage[num].SetActive(true);
    }

    public void CloseSideBackground(int num)
    {
        BackgroundImage[num].SetActive(false);
    }
}