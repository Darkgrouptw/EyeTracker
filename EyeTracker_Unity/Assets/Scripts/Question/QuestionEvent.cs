using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionEvent : MonoBehaviour
{
    public GameObject SendButton;

    public void QuestionChooseA()
    {
        SendButton.SetActive(true);
    }
}
