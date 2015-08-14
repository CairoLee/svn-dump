#include "pch.h"
#include "DebugLog.h"
#include "HookHelper.h"
#include "PacketInfo.h"


char *mLastDirection;
short mLastOpCode;
char *mLastBuf;
int mLastLen;

void __declspec( naked ) DetourCallback(){

	__asm {
		pushad
		pushfd
		mov ebp, esp;
		mov eax, [esp+0x28]
		mov mLastDirection, eax;
		mov ax, [esp+0x2C]
		mov mLastOpCode, ax;
		mov eax, [esp+0x30]
		mov mLastBuf, eax;
		mov eax, [esp+0x34]
		mov mLastLen, eax;
	}

	LogPacket( mLastDirection, mLastOpCode, mLastBuf, mLastLen );

	__asm {
		popfd
		popad
		mov eax, 0x0000608C;
		jmp ReturnAddress2;
	}
}







/////////////////
/// hooking

struct entry {
	void* funcReal;
	void* funcMine;
	void* funcJump; // trampoline + call to real func
	unsigned char verify[5]; // first 5 bytes of hooked function
};


class CDLL {
private:
	std::map<std::string, entry> table;

public:
	CDLL( void ){
	}

	~CDLL( void ){
	}

	void Hook( const char* name, void* origfunc, void* myfunc ){
		this->table[name].funcMine = myfunc;
		this->table[name].funcReal = origfunc;

		DetourTransactionBegin();
		DetourUpdateThread( GetCurrentThread() );
		DetourAttach( &origfunc, myfunc );
		DetourTransactionCommit();

		this->table[name].funcJump = origfunc;
		memcpy( this->table[name].verify, this->table[name].funcReal, 5 );
	}

	void Unhook( const char* name ){
		void* myfunc = this->table[name].funcMine;
		void* origfunc = this->table[name].funcJump;
		this->table.erase( name );

		DetourTransactionBegin();
		DetourUpdateThread( GetCurrentThread() );
		DetourDetach( &origfunc, myfunc );
		DetourTransactionCommit();
	}

	void* GetOrig( const char* name ){
		return this->table[ name ].funcJump;
	}

	void* GetMine( const char* name ){
		return this->table[ name ].funcMine;
	}

	bool Verify( void ){
		bool result = true;
		for( std::map<std::string, entry>::iterator i = this->table.begin(); i != this->table.end(); i++ ){
			if( memcmp( i->second.funcReal, i->second.verify, 5 ) != 0 ){
				DWORD oldprotect;
				VirtualProtect( i->second.funcReal, 5, PAGE_READWRITE, &oldprotect );
				memcpy( i->second.funcReal, i->second.verify, 5 );
				VirtualProtect( i->second.funcReal, 5, oldprotect, &oldprotect );

				result = false;
			}
		}

		return result;
	}
};


// the global object
CDLL dll;

// macros for accessing hooks
#define f_(x) f_ ##x (dll.GetOrig(#x))


// hook function prototypes
typedef int (PASCAL FAR * f_send)( IN SOCKET s, IN const char FAR * buf, IN int len, IN int flags );
typedef int (PASCAL FAR * f_recv)( IN SOCKET s, char FAR * buf, IN int len, IN int flags );
typedef HMODULE (WINAPI * f_LoadLibraryExW)( LPCWSTR lpLibFileName, HANDLE hFile, DWORD dwFlags );

// globals for hooking dlls without linking with them
bool bHooked = false;


static int PASCAL FAR my_recv( IN SOCKET s, char FAR * buf, IN int len, IN int flags ){
	int bufLen = strlen( buf );
	if( dll.Verify() == false )
		bHooked = true;

	log( "#%d : my_recv, bufLen %d, len %d, flags %d", s, bufLen, len, flags );

	short packetID = ( buf[ 0 ] << 8 ) | buf[ 1 ];
	int packetLen = ( buf[ 2 ] << 24 ) | ( buf[ 3 ] << 16 ) | ( buf[ 4 ] << 8 ) | buf[ 5 ];
	char *packetBuf = NULL;
	
	memcpy( (void*)packetBuf, ( buf + 6 ), packetLen );
	LogBuf( buf, bufLen );
	log( "#%d : Receive bufLen %d, Packet %d (%d bytes), caling internal func", s, bufLen, packetID, packetLen );
	RecvPacket( packetBuf, packetLen );
	//result = f_(recv)( s, buf, len, flags );

	return 0;
}

static int PASCAL FAR my_send( IN SOCKET s, IN const char FAR * buf, IN int len, IN int flags ){
	int result;
	if( dll.Verify() == false )
		bHooked = true;
	
	// need to send the uncrypted buf, so copy it
	if( mLastDirection[ 0 ] == 'S' ){
		// last buf contains send-data, correct!
		log( "#%d : Sending %d uncrypted bytes", s, len );

		char *newBuf = (char*)malloc( mLastLen + 2 );
		newBuf[ 0 ] = (char)( mLastOpCode >> 8 );
		newBuf[ 1 ] = (char)mLastOpCode;
		memcpy( (void*)(newBuf + 2), mLastBuf, mLastLen );
		memset( mLastBuf, 0, mLastLen );	
		
		result = f_(send)( s, newBuf, sizeof( newBuf ), flags );
	} else {
		log( "#%d : Sending %d crypted bytes", s, len );
		
		result = f_(send)( s, buf, len, flags );
	}

	return result;
}

static HMODULE WINAPI my_LoadLibraryExW( LPCWSTR lpLibFileName, HANDLE hFile, DWORD dwFlags ){
	LPCWSTR DllName = wcsrchr( lpLibFileName, '\\' );
	DllName = ( DllName != NULL ) ? DllName + 1 : lpLibFileName;
	DWORD len = wcslen( DllName );

	wchar_t name[ 32 ];
	wcsncpy( name, DllName, 32 );
	_wcslwr( name );


	if( 
		( len == 10 && name[ 0 ] == 'w' && name[ 1 ] == 'p' && name[ 2 ] == 'e' && name[ 3 ] == 's' && name[ 4 ] == 'p' && name[ 5 ] == 'y' ) // WPE
	) {
		MessageBox( 0, L"You've been Caught Cheating!\n\nAnti-Cheating made easy by GodLesZ Client Protection", L"GodLesZ Client Protection", MB_ICONHAND );
		bHooked = true;
		SetLastError( ERROR_DLL_INIT_FAILED );
		return NULL;
	}
	
	return f_(LoadLibraryExW)( lpLibFileName, hFile, dwFlags );
}










void Hook(){
	DWORD dummy;

	do {
		ScanForAddress();
		Sleep( 1 );
	} while( !Address );

	// hook before Packet Crypt
	VirtualProtect( (void *)Address2, 5, PAGE_EXECUTE_READWRITE, &dummy );
	*( BYTE * )( Address2 ) = 233; // E9
	*( DWORD * )( Address2 + 1 ) = ( DWORD )&DetourCallback - Address2 - 5;
	
	// hook WinAPI send & LoadLib
	f_send ws2_send = (f_send)DetourFindFunction( "ws2_32.dll", "send" );
	f_recv ws2_recv = (f_recv)DetourFindFunction( "ws2_32.dll", "recv" );
	f_LoadLibraryExW ke_LoadLibraryExW = (f_LoadLibraryExW)DetourFindFunction( "kernel32.dll", "LoadLibraryExW" );

	dll.Hook( "send"          , ws2_send         , my_send           );
	dll.Hook( "recv"          , ws2_recv         , my_recv           );
	dll.Hook( "LoadLibraryExW", ke_LoadLibraryExW, my_LoadLibraryExW );
}

void UnHook(){
	dll.Unhook( "send"           );
	dll.Unhook( "recv"           );
	dll.Unhook( "LoadLibraryExW" );
}
