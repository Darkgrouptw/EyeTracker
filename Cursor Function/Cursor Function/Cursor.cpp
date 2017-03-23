#include "Cursor.h"

extern "C"
{
	CursorAPI void SetCursorPosAPI(int x, int y)
	{
		SetCursorPos(x, y);
	}

	CursorAPI void CursorClickAPI()
	{
		// 按下去要放開，不然會一直按著
		mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
		mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
	}
}
