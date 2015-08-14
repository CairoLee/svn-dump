#include <windows.h>
#include <tchar.h>
#include <stdio.h>
#include <stdlib.h>

#include <detours.h>

static BOOL CALLBACK ExportCallback( PVOID pContext, ULONG nOrdinal, PCHAR pszSymbol, PVOID pbTarget ){
	if( nOrdinal == 1 )
		*( (BOOL *)pContext ) = TRUE;

	return TRUE;
}

BOOL DetourDoesDllExportOrdinal1( const TCHAR* pszDllPath ){
	HMODULE hDll = LoadLibraryEx( pszDllPath, NULL, DONT_RESOLVE_DLL_REFERENCES );
	BOOL validFlag = FALSE;
	DetourEnumerateExports( hDll, &validFlag, ExportCallback );
	FreeLibrary( hDll );

	return validFlag;
}


bool CreateProcessWithDll( TCHAR* exepath, TCHAR* dllpath ){
#ifdef UNICODE
	char szDllPath[256];
	WideCharToMultiByte( 0, 0, dllpath, wcslen(dllpath)+1, szDllPath, 256, 0, 0 );
#else
	char* szDllPath = dllpath;
#endif

	if ( !DetourDoesDllExportOrdinal1( dllpath ) )
		return false;

	STARTUPINFO si;
	PROCESS_INFORMATION pi;
	ZeroMemory( &si, sizeof( si ) );
	ZeroMemory( &pi, sizeof( pi ) );
	si.cb = sizeof( si );

	BOOL result = DetourCreateProcessWithDll( exepath, NULL, NULL, NULL, TRUE, 0, NULL, NULL, &si, &pi, NULL, szDllPath, NULL );

	ResumeThread( pi.hThread );

	return ( result != 0 );
}


int main( int argc, TCHAR** argv ){
	printf( "GodLesZ's Client Protection - Exe Loader\n" );
	if( argc < 3 ){
		printf( "Usage: %s <exe path> <dll path>\n", argv[ 0 ] );
		return 0;
	}

	TCHAR* exepath = argv[ 1 ];
	TCHAR* dllpath = argv[ 2 ];

	CreateProcessWithDll( exepath, dllpath );

	return 0;
}
