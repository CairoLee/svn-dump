#include "pch.h"
#include "DebugLog.h"

void Hook();
void UnHook();

extern "C" {
	/// dummy export, required for Detours
	__declspec(dllexport) void dummy() { };
}


BOOL APIENTRY DllMain( HMODULE hModule, DWORD ul_reason_for_call, LPVOID lpReserved ){

	switch ( ul_reason_for_call ){
		case DLL_PROCESS_ATTACH:
			log( "Shaiya Hook started.." );
			Hook();
			break;

		case DLL_THREAD_ATTACH:
		case DLL_THREAD_DETACH:
			break;

		case DLL_PROCESS_DETACH:
			log( "Shaiya Hook finished.." );
			UnHook();
			break;
	}

	return TRUE;
}

