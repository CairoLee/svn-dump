#include "pch.h"
#include "Form.h"
#include "Detours.h"
#include "AnalyzePacket.h"
#include "Bot.h"

extern CRITICAL_SECTION cs;
extern CRITICAL_SECTION cs2;

DWORD ShowDialog( HMODULE hInstance );
void log( const char *string, ... );


BOOL APIENTRY DllMain( HMODULE hModule, DWORD ul_reason_for_call, LPVOID lpReserved ){

	switch ( ul_reason_for_call ){
		case DLL_PROCESS_ATTACH:
			InitializeCriticalSection(&cs);
			InitializeCriticalSection(&cs2);
			CreateThread( NULL, 0, (LPTHREAD_START_ROUTINE)&BotThread, hModule, 0, NULL );
			CreateThread( NULL, 0, (LPTHREAD_START_ROUTINE)&ShowDialog, hModule, 0, NULL );
			CreateThread( NULL, 0, (LPTHREAD_START_ROUTINE)&CatchKeystrokes, hModule, 0, NULL );
			SetDetour();

			break;

		case DLL_THREAD_ATTACH:
			break;

		case DLL_THREAD_DETACH:
			break;

		case DLL_PROCESS_DETACH:
			break;
	}

	return TRUE;
}

