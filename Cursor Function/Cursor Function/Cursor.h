#pragma once
#include <windows.h>

#define CursorAPI _declspec(dllexport)

extern "C"
{
	// �]�w�ƹ���V
	CursorAPI void SetCursorPosAPI(int, int);

	// �]�w�ƹ��I��
	CursorAPI void CursorClickAPI();
}
