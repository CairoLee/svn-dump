#include "Insanity.h"
#include "Splash.h"

int Hook(HMODULE InsaneModule);
void UnHook();

extern "C" {
	/// dummy export, required for Detours
	__declspec(dllexport) void dummy() { };
}

/// main entry point
BOOL APIENTRY DllMain( HMODULE hModule, DWORD ul_reason_for_call, LPVOID lpReserved ){

	switch ( ul_reason_for_call ){
		case DLL_PROCESS_ATTACH: {
				Splash Splash(NULL);
				if (Splash.Show(NULL, 300) == TRUE) {
					Sleep(1000);
				}

				if (Hook(hModule) != 1) {
					MessageBox( 0, L"Failed to initialize Insanity successfully.\n\nPlease restart the Patcher and try again.\nIf this happen more than once, please inform the Admins.\nThank you.", L"Insanity - Client Protection", MB_OK | MB_ICONHAND );
					exit(1);
					return FALSE;
				}
			}
			break;

		case DLL_THREAD_ATTACH:
			break;

		case DLL_THREAD_DETACH:
			break;

		case DLL_PROCESS_DETACH:
			UnHook();
			break;
	}

	log(L"DllMain: returning true!\n");

	return TRUE;
}

