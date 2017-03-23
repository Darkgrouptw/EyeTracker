#pragma once
#include <windows.h>

#define CursorAPI _declspec(dllexport)

extern "C"
{
	// 設定滑鼠方向
	CursorAPI void SetCursorPosAPI(int, int);

	// 設定滑鼠點擊
	CursorAPI void CursorClickAPI();
}
