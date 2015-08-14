// dllmain.cpp : Definiert den Einstiegspunkt für die DLL-Anwendung.
#include "stdafx.h"
#include "Form.h"
#include "Detours.h"
#include "AnalyzePacket.h"
#include "Bot.h"
#include <stdio.h>


extern CRITICAL_SECTION cs;
extern CRITICAL_SECTION cs2;

DWORD ShowDialog(HMODULE hInstance);

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
					 )
{
	switch (ul_reason_for_call)
	{
	case DLL_PROCESS_ATTACH:
		InitializeCriticalSection(&cs);
		InitializeCriticalSection(&cs2);
		CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)&BotThread, hModule, 0, NULL);
		CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)&ShowDialog, hModule, 0, NULL);
		CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)&CatchKeystrokes, hModule, 0, NULL);
		SetDetour();
	case DLL_THREAD_ATTACH:
	case DLL_THREAD_DETACH:
	case DLL_PROCESS_DETACH:
		break;
	}
	return TRUE;
}