using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class CursorAPI : MonoBehaviour
{

    /* 測試
    void Start()
    {
        StartCoroutine(test());
    }
    IEnumerator test()
    {
        while(true)
        {
            yield return new WaitForSeconds(2);
            //SetCursorPosAPI(46, 758);
            CursorClickAPI();
        }
    }*/

    [DllImport("Cursor Function")]
    public static extern void SetCursorPosAPI(int x, int y);        // 滑鼠要移動到某個位置

    [DllImport("Cursor Function")]
    public static extern void CursorClickAPI();                     // 要點及功能
}
