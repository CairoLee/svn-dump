#include "Insanity.h"
#include <cstdio>
#include <windows.h>
#include <tlhelp32.h>

DWORD GetProcessByName(PCWSTR name) {
    DWORD pid = 0;
	
    HANDLE snapshot = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);
    PROCESSENTRY32 process;
    ZeroMemory(&process, sizeof(process));
    process.dwSize = sizeof(process);

    // Walkthrough all processes.
    if (Process32First(snapshot, &process)) {
        do {
			if (wcscmp(process.szExeFile, name) == 0) {
				pid = process.th32ProcessID;
				break;
			}
        } while (Process32Next(snapshot, &process));
    }

    CloseHandle(snapshot);
	return pid;
}


