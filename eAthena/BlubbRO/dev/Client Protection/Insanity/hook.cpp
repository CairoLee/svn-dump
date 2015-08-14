#include "Insanity.h"
#include "HookUtil.h"
#include "Tools.h"
#include <psapi.h>

HookUtil hookUtil;

DWORD exe_checksum = 0;
DWORD dll_checksum = 0;
DWORD grf1_checksum = 0;
DWORD grf2_checksum = 0;

#define ALLOWED_FILE_COUNT 40
WCHAR *ALLOWED_FILES[ALLOWED_FILE_COUNT] = {
	L"blubbro.exe",
	L"sis7012.sys",
	L"msctf.dll",
	L"dinput.dll",
	L"d3dim700.dll",
	L"mp3dec.asi",
	L"mssfast.m3d",
	L"dsound.dll",
	L"gdi32.dll",
	L"hid.dll",
	L"ksuser.dll",
	L"setupapi.dll",
	L"user32.dll",
	L"wintrust.dll",
	L"advapi32.dll",
	L"comctl32.dll",
	L"kernel32.dll",
	L"midimap.dll",
	L"msacm32.drv",
	L"oleaut32.dll",
	L"rpcrt4.dll",
	L"setupapi.dll",
	L"t2embed.dll",
	L"vct3216.acm",
	L"wdmaud.drv",
	L"ws2_32.dll",
	L"mswsock.dll",
	L"winrnr.dll",
	L"mdnsnsp.dll",
	L"dnsapi.dll",
	L"iphlpapi",
	L"hnetcfg.dll",
	L"wshtcpip.dll",
	L"rasadhlp.dll",
	L"user32",
	L"advapi32",
	L"dbghelp.dll",
	L"uxtheme.dll",
	L"mspdb100.dll", // VS 2010
	L"propsys.dll" // Win7 only?
};



//#define LOGGING
void log(const wchar_t *string, ...){
#ifdef LOGGING
	FILE *mProtectionLog = NULL;
	va_list ap;
	va_start(ap, string);

	char prefix[80];
	time_t t = time( NULL );
	strftime(prefix, 80, "[%H:%M:%S]", localtime(&t));

	mProtectionLog = fopen("Insanity.log", "a");
	fprintf(mProtectionLog, "%s ", prefix);
	vfwprintf(mProtectionLog, string, ap);
	fclose(mProtectionLog);

	va_end( ap );
#endif
}




#define MOD_ADLER 65521 
DWORD DoAdler32(BYTE *data, size_t len){
	DWORD a = 1, b = 0;

	while (len > 0) {
		size_t tlen = len > 5550 ? 5550 : len;
		len -= tlen;
		do {
			a += *data++;
			b += a;
		} while (--tlen);

		a %= MOD_ADLER;
		b %= MOD_ADLER;
	}

	return (b << 16) | a;
}

DWORD GetChecksumFile(TCHAR* path){
	DWORD checksum;

	HANDLE hFile = CreateFile(path, GENERIC_READ, FILE_SHARE_READ|FILE_SHARE_WRITE, 0, OPEN_EXISTING, 0, 0);
	if (hFile == INVALID_HANDLE_VALUE) {
		return 0;
	}

	DWORD sizeFile = GetFileSize(hFile, NULL), sizeRead = 0, sizeReadCur = 0;
	DWORD MAX_READ = 65536;
	BYTE* buf = (BYTE*)malloc(MAX_READ);
		
	DWORD a = 1, b = 0, j;
	while (sizeRead < sizeFile) {
		if (ReadFile(hFile, buf, MAX_READ, &sizeReadCur, NULL) == FALSE) {
			break;
		}		
		if (sizeReadCur < 1) {
			break;
		}

		sizeRead += sizeReadCur;
		while (sizeReadCur > 0) {
			size_t tlen = sizeReadCur > 5550 ? 5550 : sizeReadCur;
			sizeReadCur -= tlen;
			j = 0;
			do {
				a += buf[j++];
				b += a;
			} while (--tlen);

			a %= MOD_ADLER;
			b %= MOD_ADLER;
		}
		
	}
	
	free(buf);
	CloseHandle(hFile);

	checksum = (b << 16) | a;


	return checksum;
}

DWORD GetChecksumGrf(TCHAR* path){
	DWORD checksum;

	HANDLE hFile = CreateFile(path, GENERIC_READ, FILE_SHARE_READ|FILE_SHARE_WRITE, 0, OPEN_EXISTING, 0, 0);
	if (hFile == INVALID_HANDLE_VALUE) {
		return 0;
	}

	DWORD sizeFile = GetFileSize(hFile, NULL), sizeRead = 0, sizeReadCur = 0;
	DWORD MAX_READ = 65536;
	BYTE* buf = (BYTE*)malloc(MAX_READ);
	


	
	free(buf);
	CloseHandle(hFile);

	checksum = 1;


	return checksum;
}
/*
DWORD GetChecksumRegistry(TCHAR* regName) {
	HKEY hKey;
	DWORD dwNumber = 0;
	DWORD dwData = sizeof(DWORD);
	 
	LSTATUS lReturn = RegOpenKeyEx(HKEY_CURRENT_USER, L"Software\\InsaneRO\\Patcher", 0L, KEY_ALL_ACCESS, &hKey);
	if (lReturn == ERROR_SUCCESS){
		LPDWORD dwType = 0;
		lReturn = RegQueryValueExW(hKey, regName, 0, dwType, (BYTE*)&dwNumber, &dwData);
		if (lReturn != ERROR_SUCCESS){
			WCHAR errorMsg[255];
			wsprintf(errorMsg, L"Failed to read from registery.\nError code: %ld", lReturn);
			MessageBoxW(0, errorMsg, L"Insanity - Client Protection", MB_ICONERROR);
		}

		// delete after access
		RegDeleteValue(hKey, regName);
	} else {
		WCHAR errorMsg[255];
		wsprintf(errorMsg, L"Failed to open registery.\nError code: %ld", lReturn);
		MessageBoxW(0, errorMsg, L"Insanity - Client Protection", MB_ICONERROR);
	}
	RegCloseKey(hKey);

	return dwNumber;
}
*/


#define f_(x) f_ ##x (hookUtil.GetOrig(#x))
typedef int (PASCAL FAR * f_send)(IN SOCKET s, IN const char FAR * buf, IN int len, IN int flags);
typedef int (PASCAL FAR * f_recv)(IN SOCKET s, char FAR * buf, IN int len, IN int flags);
typedef HMODULE (WINAPI * f_LoadLibraryExW)(LPCWSTR lpLibFileName, HANDLE hFile, DWORD dwFlags);


bool bHashSend = false;
static int PASCAL FAR my_send(IN SOCKET s, IN const char FAR * buf, IN int len, IN int flags){
	int result;
	unsigned short opcode = *(unsigned short*)buf;

	log(L"send: 0x%4.4x %d (strlen: %d) bytes\n", opcode, len, strlen(buf));

	if (opcode == 0x0204 && len != 18) {
		char out[18];
		for (int i = 0; i < sizeof(out); i++) {
			out[i] = 1 + (rand() % 255);
		}

		out[0] = '\x04';
		out[1] = '\x02';

		buf = out;
		len = 18;

		log(L"send: 0x%4.4x - fixed packet missmatch\n", opcode);
	} else if (opcode == 0x64 && len == 55) {
		char out[85];
		for (int i = 0; i < 85; i++) {
			out[i] = 1 + (rand() % 255);
		}

		DWORD version = *(DWORD*)(&buf[ 2]);
		char* username = (char*)( &buf[ 6]);
		char* password = (char*)( &buf[30]);
		BYTE version2 = *(BYTE*)( &buf[54]);

		out[0] = '\xb0';
		out[1] = '\x02';
		memcpy(&out[ 2], &version, 4);
		memcpy(&out[ 6], username, strlen(username) + 1);
		memcpy(&out[30], password, strlen(password) + 1);
		memcpy(&out[54], &version2, 1);
		
		memcpy(&out[56], &exe_checksum, 4);
		memcpy(&out[60], &dll_checksum, 4);
		memcpy(&out[64], &grf1_checksum, 4);
		memcpy(&out[68], &grf2_checksum, 4);
		
		buf = out;
		len = 85;
	
		log(L"send: 0x%4.4x - send packet 0x02b0\n", opcode);
	}/* else if (opcode == 0x7d && len == 2){
		char buf[2] = { 
			0x42, 
			0x00 
		};
		f_(send)( s, buf, sizeof( buf ), flags );
	}*/

	result = f_(send)(s, buf, len, flags);
	if (opcode == 0x64 && result == 85) {
		log(L"send: 0x%4.4x - result = %d, set to 55\n", opcode, result);
		result = 55; 
	}

	return result;
}

static int PASCAL FAR my_recv(IN SOCKET s, char FAR * buf, IN int len, IN int flags){
	log(L"recv: %d (strlen: %d) bytes\n", len, strlen(buf));

	return f_(recv)(s, buf, len, flags);
}


static HMODULE WINAPI my_LoadLibraryExW(LPCWSTR lpLibFileName, HANDLE hFile, DWORD dwFlags){
	LPCWSTR DllName = wcsrchr(lpLibFileName, '\\');
	DllName = (DllName != NULL ? DllName + 1 : lpLibFileName);
	DWORD len = wcslen(DllName);

	wchar_t name[32];
	wcsncpy(name, DllName, 32);
	_wcslwr_s(name, sizeof(name));

	int i;
	for (i = 0; i < ALLOWED_FILE_COUNT; i++) {
		if (wcscmp(name, ALLOWED_FILES[i]) == 0) {
			break; // found, break out
		}
	}

	// not found?
	if (i >= ALLOWED_FILE_COUNT) {
		log(L"Failed to find include: %s\n", name);

		//MessageBox(0, L"Don't use hacks here!\nYour IP and login has been logged.", L"Insanity - Client Protection", MB_ICONHAND);
		//SetLastError(ERROR_DLL_INIT_FAILED);
		//return NULL;
	}

	return f_(LoadLibraryExW)(lpLibFileName, hFile, dwFlags);
}


int LoadChecksums(void){
	TCHAR name[256], dir[256], path[256];
	TCHAR* pName;
	GetProcessImageFileName(GetCurrentProcess(), name, 256);
	pName = wcsrchr(name, '\\');

	GetCurrentDirectory(256, dir);

	wcscpy(path, dir);
	wcscat(path, pName);

	exe_checksum = GetChecksumFile(path);

	HMODULE hModule = GetModuleHandle(L"Insanity.dll");
	GetModuleFileName(hModule, path, 256);
	dll_checksum = GetChecksumFile(path);

	grf1_checksum = GetChecksumGrf(L"data.grf");
	if (grf1_checksum == 0) {
		MessageBox(0, L"Please start the Patcher.", L"Insanity - Client Protection", MB_ICONHAND);
		return 0;
	}
	log(L"LoadChecksums: grf1_checksum: %d\n", grf1_checksum);

	grf2_checksum = GetChecksumGrf(L"rdata.grf");
	if (grf2_checksum == 0) {
		MessageBox(0, L"Please start the Patcher.", L"Insanity - Client Protection", MB_ICONHAND);
		return 0;
	}
	log(L"LoadChecksums: grf2_checksum: %d\n", grf2_checksum);

	return 1;
}


void InitializeSupport() {
	// set prio of ragnarok lower..
	DWORD pid = 0;
	
	pid = GetProcessByName(L"BlubbRO.exe");
	if (pid == 0) {
		pid = GetProcessByName(L"BlubbRO.GM.exe");
		if (pid == 0) {			
			log(L"InitializeSupport: failed to load pID from BlubbRO process\n");
			return;
		} else {
			log(L"InitializeSupport: Loaded pID from BlubbRO [GM]\n");
		}
	} else {
		log(L"InitializeSupport: Loaded pID from BlubbRO\n");
	}

	HANDLE hProcess = OpenProcess(PROCESS_QUERY_INFORMATION + PROCESS_VM_READ + PROCESS_TERMINATE, FALSE, pid);
	if (hProcess != NULL) {
		if (SetPriorityClass(hProcess, BELOW_NORMAL_PRIORITY_CLASS) == 0) {
			log(L"InitializeSupport: Priority change success\n");
		} else {
			log(L"InitializeSupport: Priority change failed - errNo %d\n", GetLastError());
		}
		CloseHandle(hProcess);
	} else {
		log(L"InitializeSupport: unable to open process handle\n");
	}
}


int Hook(HMODULE InsaneModule){
	log(L"[Initialize Insanity]\n");
	f_send ws2_send = (f_send)DetourFindFunction("ws2_32.dll", "send");
	f_recv ws2_recv = (f_recv)DetourFindFunction("ws2_32.dll", "recv");
	f_LoadLibraryExW ke_LoadLibraryExW = (f_LoadLibraryExW)DetourFindFunction("kernel32.dll", "LoadLibraryExW");

	hookUtil.Hook("send", ws2_send, my_send);
	hookUtil.Hook("recv", ws2_recv, my_recv);
	hookUtil.Hook("LoadLibraryExW", ke_LoadLibraryExW, my_LoadLibraryExW);
	
	InitializeSupport();

	return LoadChecksums();
}

void UnHook(){
	int i = 0;
	hookUtil.Unhook("send");
	hookUtil.Unhook("recv");
	hookUtil.Unhook("LoadLibraryExW");	

	log(L"[Insanity closed successfull]\n");
}
