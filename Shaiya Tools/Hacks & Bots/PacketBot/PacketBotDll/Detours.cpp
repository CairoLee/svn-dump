#include "pch.h"

DWORD Address = 0;
DWORD ReturnAddress = 0;
DWORD Address2 = 0;
DWORD ReturnAddress2 = 0;
DWORD Address3 = 0;

void DisplayPacket( char *direction, char *buf, int len );
void AnalyzePacket( char *direction, WORD opcode, char *buf, int len );

char *direction;
short opcode;
char *buf;
int len;


void __declspec( naked ) Detour2(){
	__asm {
		pushad
		pushfd
		mov ebp, esp
		mov eax, [ esp + 0x28 ]
		mov direction, eax;
		//mov ax, [ esp + 0x2C ]
		mov eax, [ esp + 0x2C ]
		mov opcode, eax;
		mov eax, [ esp + 0x30 ]
		mov buf, eax;
		mov eax, [ esp + 0x34 ]
		mov len, eax;
	}

	DisplayPacket( direction, buf, len );
	AnalyzePacket( direction, opcode, buf, len );

	__asm {
		popfd
		popad
		mov eax, 0x0000608C
		jmp ReturnAddress2
	}
}

void SetDetour(){
	do {
		ScanForAddress();
		Sleep( 1 );
	}
	while( !Address );

	DWORD temp;

	VirtualProtect( (void *)Address2, 5, PAGE_EXECUTE_READWRITE, &temp );
	*(BYTE *)(Address2) = 0xE9;
	*(DWORD *)(Address2 + 1) = (DWORD)&Detour2 - Address2 - 5;
}

void SendPacket( char *buf, int len ){	
	void(* InternalCall)(char *, int) = (void (__cdecl *)(char *, int)) Address;
	(* InternalCall)(buf, len);
}

bool ScanForAddress(){
	DWORD Base = 0x00400000;
	DWORD SizeOfCode;

	DWORD i = Base;
	while( memcmp( (void *)i, "PE", 4 ) && i <= Base + 4096 )
		i++;

	if( i <= Base + 4096 )
		SizeOfCode = *(DWORD *)(i + 0x1C);

	BYTE Signature[] = {0x8B, 0xCB, 0x8B, 0xD1, 0xC1, 0xE9, 0x02, 0x8D, 0x43, 0x02, 0x66, 0x89, 0x44, 0x24, 0x20};
	BYTE Signature2[] = {0xB8, 0x8C, 0x60, 0x00, 0x00, 0xE8};
	BYTE Signature3[] = {0x8B, 0x54, 0x24, 0x04, 0x0F, 0xB7, 0xC2, 0x3D};

	Address = dwFindPattern(  Base + 4096, SizeOfCode, Signature, "xxxxxxxxxxxxxxx" ) - 0x38;
	ReturnAddress = Address + 6;
	Address2 = dwFindPattern( Base + 4096, SizeOfCode, Signature2, "xxxxxx" );
	ReturnAddress2 = Address2 + 5;
	Address3 = dwFindPattern( Base + 4096, SizeOfCode, Signature3, "xxxxxxxx" );

	if( Address )
		return true;
	else
		return false;
}

bool bDataCompare( const BYTE* pData, const BYTE* bMask, const char* szMask ){
    for( ; *szMask; ++szMask, ++pData, ++bMask )
        if( *szMask == 'x' && *pData != *bMask ) 
            return false;
    return (*szMask) == NULL;
}

DWORD dwFindPattern( DWORD dwAddress, DWORD dwLen, BYTE *bMask, char * szMask ){
    for( DWORD i = 0; i < dwLen; i++ )
        if( bDataCompare( (BYTE*)(dwAddress + i), bMask, szMask ) )
            return (DWORD)(dwAddress + i);  
    return 0;
}

void RecvPacket( char *buf, DWORD len ){
	RecvPacketStruct *Packet = new RecvPacketStruct;
	memcpy( Packet->Data, buf, len );
	Packet->len = len;
	Packet->ptr = (RecvPacketStruct *)((DWORD)Packet + 2);

	WORD Opcode;
	memcpy( &Opcode, Packet, sizeof( WORD ) );

	void(* ReceivePacketPtr)( WORD Opcode, RecvPacketStruct *Packet ) = ( void (__cdecl *)(WORD, RecvPacketStruct *) )Address3;
	(* ReceivePacketPtr)( Opcode, Packet );

	delete Packet;
}
