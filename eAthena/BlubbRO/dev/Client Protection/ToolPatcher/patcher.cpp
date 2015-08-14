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

static BOOL CALLBACK AddBywayCallback( PVOID pContext, PCHAR pszFile, PCHAR *ppszOutFile ){
	static DWORD nByways = 0;
	char* dllpath = (char*)pContext;

	if( pContext == NULL )
		nByways++;
	else if( --nByways == 0 )
		*ppszOutFile = dllpath;

	return TRUE;
}

bool CreateExeWithDllImport( TCHAR* exepath, TCHAR* dllpath ){
#ifdef UNICODE
	char szDllPath[256];
	WideCharToMultiByte( 0, 0, dllpath, wcslen( dllpath ) + 1, szDllPath, 256, 0, 0 );
#else
	char* szDllPath = dllpath;
#endif

	if ( !DetourDoesDllExportOrdinal1( dllpath ) )
		return false;

	HANDLE hOld = INVALID_HANDLE_VALUE;
	HANDLE hNew = INVALID_HANDLE_VALUE;
	PDETOUR_BINARY pBinary = NULL;

	TCHAR newpath[256];
	memset( newpath, 0, sizeof( newpath ) );
	_tcscat( newpath, exepath );
	_tcscat( newpath, _T( ".patched" ) );

	hOld = CreateFile( exepath, GENERIC_READ, FILE_SHARE_READ, NULL, OPEN_EXISTING, FILE_ATTRIBUTE_NORMAL, NULL );
	hNew = CreateFile( newpath, GENERIC_WRITE | GENERIC_READ, 0, NULL, CREATE_ALWAYS, FILE_ATTRIBUTE_NORMAL | FILE_FLAG_SEQUENTIAL_SCAN, NULL );

	pBinary = DetourBinaryOpen( hOld );
	DetourBinaryResetImports( pBinary );

	DetourBinaryEditImports( pBinary, NULL, AddBywayCallback, NULL, NULL, NULL );
	DetourBinaryEditImports( pBinary, szDllPath, AddBywayCallback, NULL, NULL, NULL );

	DetourBinaryWrite( pBinary, hNew );
	DetourBinaryClose( pBinary );

	CloseHandle( hOld );
	CloseHandle( hNew );


	return true;
}

int _tmain( int argc, TCHAR** argv ){
	FILE* fp;

	printf( "Insanity Client Protection - Exe Patcher\n" );
	if( argc < 3 ){
		printf( "Usage: %s <exe path> <dll path>\n", argv[ 0 ] );
		return 0;
	}

	fp = _tfopen( argv[ 1 ], _T( "rb" ) );
	if( fp == NULL ){
		_tprintf( _T( "Could not open Exe %s?\n" ), argv[ 1 ] );
		return 0;
	}
	fclose( fp );

	fp = _tfopen( argv[ 2 ], _T( "rb" ) );
	if( fp == NULL ){
		_tprintf( _T( "Could not open Dll %s?\n" ), argv[ 2 ] );
		return 0;
	}
	fclose( fp );

	TCHAR* exepath = argv[ 1 ];
	TCHAR* dllpath = argv[ 2 ];

	CreateExeWithDllImport( exepath, dllpath );
}
