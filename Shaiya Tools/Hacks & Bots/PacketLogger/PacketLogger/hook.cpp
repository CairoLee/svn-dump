#include "pch.h"
#include "DebugLog.h"
#include "HookHelper.h"
#include "PacketInfo.h"

char *direction;
short opcode;
char *buf;
int len;

void __declspec( naked ) DetourCallback(){
	__asm {
		pushad
		pushfd
		mov ebp, esp
		mov eax, [esp+0x28]
		mov direction, eax;
		mov ax, [esp+0x2C]
		mov opcode, ax;
		mov eax, [esp+0x30]
		mov buf, eax;
		mov eax, [esp+0x34]
		mov len, eax;
	}

	DisplayPacket( direction, opcode, buf, len );

	__asm {
		popfd
		popad
		mov eax, 0x0000608C
		jmp ReturnAddress2
	}
}




void SendPacket(char *buf, int len ){	
	void ( * InternalCall )( char *, int ) = ( void ( __cdecl * )( char *, int ) )Address;
	( * InternalCall )( buf, len );
}




void Hook(){
	DWORD dummy;

	do {
		ScanForAddress();
		Sleep( 1 );
	} while( !Address );

	log( "Address = %d, Address2 = %d, Address3 = %d\n", Address, Address2, Address3 );

	VirtualProtect( (void *)Address2, 5, PAGE_EXECUTE_READWRITE, &dummy );
	*( BYTE * )( Address2 ) = 233; // E9
	*( DWORD * )( Address2 + 1 ) = ( DWORD )&DetourCallback - Address2 - 5;
}

void UnHook(){
}
