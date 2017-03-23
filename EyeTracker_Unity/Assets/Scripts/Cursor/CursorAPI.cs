using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class CursorAPI : MonoBehaviour
{

    public static void SetCursorPosAPI(Vector2 pos)
    {
        SetCursorPosAPI((int)pos.x, (int)pos.y);
    }



    [DllImport("Cursor Function")]
    private static extern void SetCursorPosAPI(int x, int y);        // 滑鼠要移動到某個位置

    [DllImport("Cursor Function")]
    private static extern void CursorClickAPI();                     // 要點及功能
}
