#include "Cursor.h"

extern "C"
{
	CursorAPI void SetCursorPosAPI(int x, int y)
	{
		SetCursorPos(x, y);
	}

	CursorAPI void CursorClickAPI()
	{
		// ���U�h�n��}�A���M�|�@������
		mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
		mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
	}
}
