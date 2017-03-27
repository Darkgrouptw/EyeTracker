using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class MovieSideEvent : MonoBehaviour
{
    [Header("========== 按下 Time Line 的事件 ==========")]
    public GameObject[] BackgroundImage;

    [Header("========== 龍的事件 ==========")]
    public GameObject Dragon;
    public float MoveSpeed;

    private MissionTimeCounter counter;

    void Start()
    {
        #region 抓 Mission Time Counter
        GameObject MissionTime = GameObject.FindGameObjectWithTag("Mission Time Tracker");
        counter = MissionTime.GetComponent<MissionTimeCounter>();
        #endregion
        // 把資料給進去
        Vector3 angle = Dragon.transform.localEulerAngles;
    }

    public void TimeLineImageButtonEvent(int num)
    {
        BackgroundImage[num].SetActive(true);

        // 任務三開始 (龍被點開)
        if(num == 3)
            counter.UpgradeToNextLevel(2);
    }

    public void CloseSideBackground(int num)
    {
        BackgroundImage[num].SetActive(false);

        // 任務二 & 任務三結束
        counter.RecordTime();
    }

    #region Dragon Event
    public void TurnLeftEvent()
    {
        Vector3 axis = Dragon.transform.forward;
        SetDragonRotation(axis, MoveSpeed);
    }
    public void TurnRightEvent()
    {
        Vector3 axis = Dragon.transform.forward;
        SetDragonRotation(axis, -MoveSpeed);
    }
    public void TurnUpEvent()
    {
        Vector3 axis = Dragon.transform.up;
        SetDragonRotation(axis, -MoveSpeed);
    }
    public void TurnDownEvent()
    {
        Vector3 axis = Dragon.transform.up;
        SetDragonRotation(axis, MoveSpeed);
    }

    private void SetDragonRotation(Vector3 axis, float speed)
    {
        Dragon.transform.RotateAround(Dragon.transform.position, axis, speed);
    }
    #endregion
}